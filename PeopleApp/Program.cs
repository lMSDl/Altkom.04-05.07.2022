using Services;
using Models;

IPeopleService peopleService = new PeopleService();

bool exit = false;

do
{
    Console.Clear();

    var people = peopleService.GetPeople();
    foreach (var person in people)
    {
        //var line = person.Id + "\t" + person.LastName + " " + person.FirstName + person.Age;
        //var line = string.Format("{0} {2} {1} {3}", person.Id, person.FirstName, person.LastName, person.Age);

        var line = $"{person.Id,-3}{person.LastName,-15}{person.FirstName,-10}{person.Age,-3}";
        Console.WriteLine(line);
    }

    ShowMenu();
    var input = PeopleService.GetData("Wybierz co chcesz zrobić:");

    switch (input)
    {
        case "1":
        case "dodaj":
        case "add":
            peopleService.Create();
            break;
        case "2":
            {
            var id = AskForId();
            peopleService.Update(id);
            }
            break;
        case "3":
            {
            var id = AskForId();
            peopleService.Delete(id);
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