namespace BuchhaltungProjektPS;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class ProfileManager
{
    public static Profile CurrentProfile { get; private set; }

    public static void CreateProfile(string name, decimal balance)
    {
        CurrentProfile = new Profile(name, balance);
        SaveProfile(CurrentProfile);
    }

    public static void SaveProfile(Profile profile)
    {
        string filePath = AppContext.BaseDirectory + profile.Name + ".prof";
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                binaryFormatter.Serialize(fs, profile);
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }

    public static void LoadProfile(string profilePath)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        try
        {
            using (FileStream fs = new FileStream(profilePath, FileMode.Open))
            {
                CurrentProfile = (Profile)binaryFormatter.Deserialize(fs);
            }
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
    }

    public static bool CheckIfProfileExists(string profileName)
    {
        string fullPath = AppContext.BaseDirectory + profileName + ".prof";
        return File.Exists(fullPath);
    }
}