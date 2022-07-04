using Services;
using Models;

IService<Product> service = new ProductsService();

bool exit = false;

do
{
    Console.Clear();

    var entities = service.Get();
    foreach (var entity in entities)
    {
        Console.WriteLine(entity);
    }

    ShowMenu();
    var input = PeopleService.GetData("Wybierz co chcesz zrobić:");

    switch (input)
    {
        case "1":
        case "dodaj":
        case "add":
            service.Create();
            break;
        case "2":
            {
            var id = AskForId();
            service.Update(id);
            }
            break;
        case "3":
            {
            var id = AskForId();
            service.Delete(id);
            }
            break;
        case "4":
            exit = true;
            break;
        default:
            Console.WriteLine(Resources.Properties.Resources.BadCommand);
            break;
    }
} while (!exit);

void ShowMenu()
{
    Console.WriteLine($"1. {Resources.Properties.Resources.Add}");
    Console.WriteLine($"2. {Resources.Properties.Resources.Edit}");
    Console.WriteLine($"3. {Resources.Properties.Resources.Delete}");
    Console.WriteLine($"4. {Resources.Properties.Resources.End}");
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