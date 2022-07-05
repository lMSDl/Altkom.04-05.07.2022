﻿using Services;
using Models;
using System.Globalization;

//CultureInfo ci = new CultureInfo("en-US", false);
//Thread.CurrentThread.CurrentCulture = ci;
//Thread.CurrentThread.CurrentUICulture = ci;

var folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
var file = Path.Combine(folder, "myFile.txt");
ICache cache = new FileDataProvider(file);

await cache.WriteAsync("Hello!");


IAsyncService<Product> service = new ProductsService();

await MainLoopAsync(service);




















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