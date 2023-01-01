namespace BuchhaltungProjektPS;

public static class Error
{
    public static void Message(string error)
    {
        string errorMessage = "FEHLER: ";

        switch (error)
        {
            case "Profil":
                errorMessage += "Ungültiges Profil";
                break;
            case "Eingabe":
                errorMessage += "Ungültige Eingabe";
                break;
            case "Betrag":
                errorMessage += "Ungültiger Geldbetrag";
                break;
            case "Datum":
                errorMessage += "Ungültiges Datum";
                break;
            default:
                errorMessage += "Allgemeiner Fehler";
                break;
        }

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(errorMessage);
        Console.ForegroundColor = ConsoleColor.White;
    }
}
//"FEHLER: Ungültiges Profil"
//"FEHLER: Ungültige Eingabe");
//"FEHLER: Ungültiger Geldbetrag
//"FEHLER: Ungültiges Datum"