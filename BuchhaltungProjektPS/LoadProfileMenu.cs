using System.IO;
namespace BuchhaltungProjektPS;

public class LoadProfileMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Wähle ein Profil aus:");
        Console.WriteLine("---------------------");
        ShowProfiles();
        Console.WriteLine();
        string profilePath = InputProfileName();
        
        ProfileManager.LoadProfile(profilePath);

        if (profilePath != "cancel")
        {
            ProfileManager.LoadProfile(profilePath);
            Menu nextMenu = new MainMenu();
        }
        else
        {
            Menu nextMenu = new StartMenu();    
        }
        
    }

    private void ShowProfiles()
    {
        string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");

        if (profileFiles.Length == 0)
        {
            Console.Clear();
            Console.WriteLine("Es gibt noch kein zu ladendes Profil.");
            Console.WriteLine("Bitte legen Sie im nächsten Schritt ein neues Profil an.");

            Console.ReadKey();

            Menu nextMenu = new CreateProfileMenu();
        }
        else
        {
            foreach (string file in profileFiles)
            {
                Console.WriteLine("- " + Path.GetFileName(file));
            }
        }
        
    }

    private string InputProfileName()
    {
        string input = "";

        while (true)
        {
            Console.Write("Zu ladendes Profil [\"cancel\" zum abbrechen]: ");
            input = Console.ReadLine();
            string[] profileFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.prof");
            bool correctInput = false;

            if (input == "cancel")
            {
                correctInput = true;
            }
            else
            {
                for (int i = 0; i < profileFiles.Length; i++)
                {
                    profileFiles[i] = Path.GetFileName(profileFiles[i]);

                    if (input == profileFiles[i])
                    {
                        correctInput = true;
                        input = AppContext.BaseDirectory + input;
                        break;
                    }
                }
            }

            if (correctInput)
            {
                break;
            }
            else
            {
                Error.Message("Profil");
            }

        }
        return input;
    }
}