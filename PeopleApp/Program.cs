using Services;
using Models;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Xml.Linq;
using PeopleApp.Encryption;

//CultureInfo ci = new CultureInfo("en-US", false);
//Thread.CurrentThread.CurrentCulture = ci;
//Thread.CurrentThread.CurrentUICulture = ci;

var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var file = Path.Combine(folder, "myFile.txt");
ICache cache = new FileDataProvider(file);

//await cache.WriteAsync("Hello!");

IAsyncService<Product> service = new ProductsService(await LoadFromXmlAsync());

await MainLoopAsync(service);




#region Methods
void ShowMenu()
{
    //var role = Roles.Delete | Roles.Read;

    //if(role.HasFlag(Roles.Write))
    //{

    //}

    var menuOptions = Enum.GetValues<MenuOptions>();

    foreach (var line in menuOptions.Select(item => $"{(int)item}. {Resources.Properties.Resources.ResourceManager.GetString(item.ToString())}"))
    {
        Console.WriteLine(line);
    }
    //foreach (var item in menuOptions)
    //{
    //    Console.WriteLine($"{(int)item}. {Resources.Properties.Resources.ResourceManager.GetString(item.ToString())}");
    //}

    /*Console.WriteLine($"1. {Resources.Properties.Resources.Add}");
    Console.WriteLine($"2. {Resources.Properties.Resources.Edit}");
    Console.WriteLine($"3. {Resources.Properties.Resources.Delete}");
    Console.WriteLine($"4. {Resources.Properties.Resources.End}");
    Console.WriteLine($"5. DoSth");*/
}

int AskForId()
{
    Console.WriteLine("Podaj id:");
    var input = Console.ReadLine();

    try
    {
        var id = int.Parse(input);
        return id;
    }
    catch (FormatException ex)
    {
        Console.WriteLine(ex.Message);
        return AskForId();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        return 0;
    }
}

async Task MainLoopAsync(IAsyncService<Product> service)
{
    bool exit = false;

    do
    {
        Console.Clear();
        var entities = await service.GetAsync();
        //entities.ToList().ForEach(x => Console.WriteLine(x));
        foreach (var entity in entities)
        {
            Console.WriteLine(entity);
        }

        ShowMenu();
        var input = PeopleService.GetData("Wybierz co chcesz zrobić:");

        //if(Enum.TryParse(typeof(MenuOptions), input, true, out var selectedOption))
        if (!Enum.TryParse<MenuOptions>(input, true, out var selectedOption))
        {
            continue;
        }

        switch (selectedOption)
        {
            case MenuOptions.Add:
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                await service.CreateAsync();
                break;
            case MenuOptions.Edit:
                {
                    var id = AskForId();
                    await service.UpdateAsync(id);
                }
                break;
            case MenuOptions.Delete:
                {
                    var id = AskForId();
                    await service.DeleteAsync(id);
                }
                break;
            case MenuOptions.End:
                SaveToXmlAsync(entities);
                //SaveToJsonAsync(entities);
                exit = true;
                break;
            //case "5":
            //service.MethodForPeople();
            //break;
            default:
                Console.WriteLine(Resources.Properties.Resources.BadCommand);
                break;
        }
    } while (!exit);
} 


async Task SaveToJsonAsync(IEnumerable<Product> entities)
{
    var options = new JsonSerializerOptions();
    options.WriteIndented = true;
    options.IgnoreReadOnlyProperties = true;
    //options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;

    var json = JsonSerializer.Serialize(entities, options);
    await cache.WriteAsync(json);
}
async Task<IEnumerable<Product>> LoadFromJsonAsync()
{
    try
    {
        var json = await cache.ReadAsync();

        var jsonDocument = JsonDocument.Parse(json);
        //Możemy odczytywać dane z jsona bez potrzeby deserializowania całości do postaci obiektu
        var names = jsonDocument.RootElement.EnumerateArray().Select(x => x.GetProperty(nameof(Product.Name))).Select(x => x.GetString()).ToList();

        var entities = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
        return entities;
    }
    catch
    {
        return new List<Product>();
    }
}

async Task SaveToXmlAsync(IEnumerable<Product> entities)
{

    var serialize = new XmlSerializer(entities.GetType());
    using var memoryStream = new MemoryStream();
    serialize.Serialize(memoryStream, entities);
    var xml = Encoding.Default.GetString(memoryStream.ToArray());

    //await cache.WriteAsync(xml);
    var data = new AsymmetricEncryptor().Encrypt(xml, "CN=localhost");
    await cache.WriteAsync(data);
}
async Task<IEnumerable<Product>> LoadFromXmlAsync()
{
    try
    {
        //var xml = await cache.ReadAsync();
        var data = await cache.ReadBytesAsync();
        var xml = Encoding.Default.GetString(new AsymmetricEncryptor().Decrypt(data, "CN=localhost"));

        //XmlDocument - System.Xml - brak wsparcia dla LINQ
        //XDocument - System.Linq.Xml - wsparcie dla LINQ

        var xDocument = XDocument.Parse(xml);
        var names = xDocument.Root.Elements().SelectMany(x => x.Elements().Where(xx => xx.Name == nameof(Product.Name))).Select(x => x.Value).ToList();

        var xmlSerializer = new XmlSerializer(typeof(List<Product>));
        var memoryStream = new MemoryStream();
        xDocument.Save(memoryStream);
        memoryStream.Position = 0;
        var entities = (IEnumerable<Product>)xmlSerializer.Deserialize(memoryStream);
        return entities;
    }
    catch
    {
        return new List<Product>();
    }
}
#endregion