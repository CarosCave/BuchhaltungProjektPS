namespace BuchhaltungProjektPS;

public class CreateProfileMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Profil erstellen");
        Console.WriteLine();

        string profileName = InputName();
        decimal profileStartBalance = InputStartBalance();
        
        ProfileManager.CreateProfile(profileName, profileStartBalance);

        Menu nextMenu = new MainMenu();
    }

    private string InputName()
    {
        while (true)
        {
            string input = "";
            Console.Write("Profilname: ");
            input = Console.ReadLine();

            if (ValidateName(input))
            {
                return input;
            }
            else
            {
                Error.Message("Name");
            }
            
        }
    }

    private decimal InputStartBalance()
    {
        while (true)
        {
            Console.Write("Start Kontostand: ");
            decimal input;
            string strInput = Console.ReadLine();

            if (!decimal.TryParse(strInput, out input))
            {
                Error.Message("Betrag");
                continue;
            }

            return input;
        }
    }

    private bool ValidateName(string name)
    {
        if (ProfileManager.CheckIfProfileExists(name))
        {
            return false;
        }
        
        foreach (char c in name)
        {
            if (!char.IsLetterOrDigit(c))
            {
                return false;
            }
        }
        
        return true;
    }
}