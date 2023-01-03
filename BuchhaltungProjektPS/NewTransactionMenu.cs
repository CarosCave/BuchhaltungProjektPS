namespace BuchhaltungProjektPS;

public class NewTransactionMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Neue Transaktion");
        Console.WriteLine("----------------");

        string newTransactionName = InputTransactionName();
        decimal newTransactionAmount = InputTransactionAmount();
        DateTime newTransactionDate = InputTransactionDate();

        Transaction transaction = new Transaction(newTransactionName, newTransactionAmount, newTransactionDate);
        ProfileManager.CurrentProfile.AddTransaction(transaction);
        Console.WriteLine("Die folgende Transaktion wurde hinzugefügt");

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
        Console.ReadKey();

        Menu nextMenu = new MainMenu();
    }

    private string InputTransactionName()
    {
        Console.Write("Transaktions-Name: ");
        return Console.ReadLine();
    }

    private decimal InputTransactionAmount()
    {
        decimal input;
        bool correctInput = true;
        do
        {
            Console.Write("Euro-Betrag: ");

            if (!decimal.TryParse(Console.ReadLine(), out input))
            {
                correctInput = false;

                Error.Message("Betrag");
            }

        } while (!correctInput);
        return input;
    }

    private DateTime InputTransactionDate()
    {
        DateTime input;
        bool correctInput = true;

        do
        {
            Console.Write("Datum (TT.MM.JJJJ): ");


            if (!DateTime.TryParseExact(Console.ReadLine(), "dd.MM.YYYY", null,
                    System.Globalization.DateTimeStyles.None, out input))
            {
                correctInput = false;
                Error.Message("Datum");
            }

        } while (!correctInput);

        return input;
    }
}