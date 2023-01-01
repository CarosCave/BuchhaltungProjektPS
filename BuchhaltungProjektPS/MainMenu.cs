﻿namespace BuchhaltungProjektPS;

public class MainMenu : Menu
{
    public override void DisplayMenu()
    {
        Console.WriteLine("Profil: " + ProfileManager.CurrentProfile.Name);
        Console.WriteLine("Aktueller Kontostand: " + ProfileManager.CurrentProfile.Balance + "Euro");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine();
        Console.WriteLine("[1] Neue Transaktion");
        Console.WriteLine("[2] Zeige Transaktionen");
        Console.WriteLine("[3] Zurück ins Startmenü");
        Console.WriteLine();
        InputOption();

    }

    private void InputOption()
    {
        string input;
        while (true)
        {
            Console.WriteLine("Eingabe: ");
            input = Console.ReadLine();
            bool correctInput = true;
            Menu nextMenu;

            switch (input)
            {
                case "1":
                    nextMenu = new NewTransactionMenu();
                    break;
                
                case "2":
                    nextMenu = new ShowTransactionsMenu();
                    break;
                
                case "3":
                    nextMenu = new StartMenu();
                    break;
                
                default:
                    correctInput = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEHLER: Ungültige Eingabe");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            if (correctInput)
            {
                break;
            }
        }
    }
}