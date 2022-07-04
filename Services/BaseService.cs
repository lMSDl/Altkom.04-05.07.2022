﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public abstract class BaseService<T> : IService<T> where T : Entity //gdzie T dziedziczyć po Entity
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

        protected abstract T CreateInstace();


        public void Delete(int id)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                if (entity.Id == id)
                {
                    entities.RemoveAt(i);
                    break;
                }
            }
        }

        public IEnumerable<T> Get()
        {
            return entities;
        }

        public T Get(int id)
        {
            foreach (var person in entities)
            {
                if (person.Id == id)
                    return person;
            }

            return default;
        }

        public void Update(int id)
        {
            var entity = Get(id);
            if (entity != null)
                Edit(entity);
        }

        private int GenerateId()
        {
            int id = 0;
            foreach(var person in entities)
            {
                id = Math.Max(id, person.Id);
            }

            return id + 1;
        }

        public static string GetData(string label)
        {
            Console.WriteLine(label);
            return Console.ReadLine();
        }
        protected abstract void Edit(T entity);
    }
}