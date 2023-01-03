namespace BuchhaltungProjektPS;

public class StartMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Willkommen zur Buchhaltung-Software!");
        Console.WriteLine();
        Console.WriteLine("Was möchtest du tun?");
        Console.WriteLine("--------------------");
        Console.WriteLine("[1] Neues Profil erstellen");
        Console.WriteLine("[2] Profil laden");
        Console.WriteLine();

        InputOption();
    }

    private void InputOption()
    {
        string input;
        Menu nextMenu;
        bool correctInput = true;

        do
        {
            Console.Write("Eingabe: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    nextMenu = new CreateProfileMenu();
                    break;
                case "2":
                    nextMenu = new LoadProfileMenu();
                    break;
                default:
                    correctInput = false;

                    Error.Message("Eingabe");
                    break;
            }

        } while (!correctInput);
    }
}