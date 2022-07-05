using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class BaseService<T> : IService<T>, IAsyncService<T> where T : Entity //gdzie T dziedziczyć po Entity
    {
        private IList<T> entities;

        public BaseService()
        {
            entities = new List<T>();
        }


        public void Create()
        {
            var entity = CreateInstace();
            Edit(entity);

            entity.Id = GenerateId();

            entities.Add(entity);
        }

        public Task CreateAsync()
        {
            return Task.Run(() => Create());
        }

        protected abstract T CreateInstace();


        public void Delete(int id)
        {
            entities.Remove(entities.SingleOrDefault(x => x.Id == id));

            //for (int i = 0; i < entities.Count; i++)
            //{
            //    var entity = entities[i];
            //    if (entity.Id == id)
            //    {
            //        entities.RemoveAt(i);
            //        break;
            //    }
            //}
        }
        public Task DeleteAsync(int id)
        {
            return Task.Run(() => Delete(id));
        }

        public IEnumerable<T> Get()
        {
            return entities;
        }
        public Task<IEnumerable<T>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
            //foreach (var person in entities)
            //{
            //    if (person.Id == id)
            //        return person;
            //}

            //return default;
        }
        public Task<T> GetAsync(int id)
        {
            return Task.Run(() => Get(id));
        }

        public void Update(int id)
        {
            var entity = Get(id);
            if (entity != null)
                Edit(entity);
        }
        public Task UpdateAsync(int id)
        {
            return Task.Run(() => UpdateAsync(id));
        }

        private int GenerateId()
        {
            return entities.Select(x => x.Id)
                           .DefaultIfEmpty()
                           .Max() + 1;

            //int id = 0;
            //foreach(var person in entities)
            //{
            //    id = Math.Max(id, person.Id);
            //}

            //return id + 1;
        }

        public static string GetData(string label)
        {
            Console.WriteLine(label);
            return Console.ReadLine();
        }

        protected void GetValidData(string label, Func<string, bool> func)
        {
            var success = false;
            while (!success)
            {
                var input = GetData(label);
                success = func(input);
            }
        }
        protected abstract void Edit(T entity);



    }
}
