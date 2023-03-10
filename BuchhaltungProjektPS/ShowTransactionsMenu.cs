namespace BuchhaltungProjektPS;

public class ShowTransactionsMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Geben Sie einen Zeitraum ein");
        Console.WriteLine("----------------------------");

        DateTime startDate = InputStartDate();
        DateTime endDate = InputEndDate(startDate);
        Console.WriteLine();

        Console.WriteLine("------------------------------------------------------------------");
        PrintTransactionsFromTo(startDate, endDate);
        Console.WriteLine("------------------------------------------------------------------");

        Console.WriteLine("Drücke eine Taste um in das Hauptmenü zurück zu kehren.");
        Console.ReadKey();
        Menu nextMenu = new MainMenu();
    }

    private DateTime InputStartDate()
    {
        DateTime input;
        bool correctInput = true;

        do
        {

            Console.Write("Startdatum (TT.MM.JJJJ): ");

            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out input))
            {
                correctInput = false;
                Error.Message("Datum");
            }

        } while (!correctInput);

        return input;
    }
    
    private DateTime InputEndDate(DateTime startDate)
    {
        DateTime input;
        bool correctInput = true;

        do
        {

            Console.Write("Enddatum (TT.MM.JJJJ): ");

            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null,
                    System.Globalization.DateTimeStyles.None, out input) || input < startDate)
            {
                correctInput = false;
                Error.Message("Datum");
            }

        } while (!correctInput);

        return input;
    }

    private void PrintTransactionsFromTo(DateTime startDate, DateTime endDate)
    {
        foreach (Transaction transaction in ProfileManager.CurrentProfile.Transactions)
        {
            if (transaction.Date >= startDate && transaction.Date < endDate)
            {
                if (transaction.Amount < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
        
                Console.WriteLine(transaction.ToString());
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    
}