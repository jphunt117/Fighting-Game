using System;


class Program
{
    static void Main()
    {
        Random rng = new Random();

        int warriorHealth = 120;
        int mageHealth = 95;
        int rage = 0;
        int mana = 35;
        int warriorDamage = 0;
        int fireball = 0;
        int mortal_strike = 0;
        int frostbolt = 0;
        bool gameOver = false;
        string turn;
        string warriorTurn = string.Empty;
        string mageTurn = string.Empty;


        Console.Write("Enter the warriors name: ");
        string warriorName = Console.ReadLine();
        Console.Write("Enter the mages name: ");
        string mageName = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine();
        stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);

        while (!gameOver)
        {
            turn = warriorTurn;

            if (turn == warriorTurn)
            {
                warriorDamage = rng.Next(4, 6);
                mortal_strike = rng.Next(8, 10);
                Console.WriteLine("Melee: Strikes the target for 4 to 6 damage. Generates 7 to 12 rage.");
                Console.WriteLine("Mortal Strike: Mortally wounds the target for 7 to 9 damage. Costs 10 rage.");
                Console.Write("Choice: ");
                string attackChoice = Console.ReadLine();
                Console.WriteLine();
                if (attackChoice == "Mortal Strike" && rage >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.Write("mortally struck ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {mortal_strike} damage!");
                    mageHealth -= mortal_strike;
                    rage -= 10;
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }
                else if (attackChoice == "Mortal Strike" && rage < 10)
                {
                    Console.WriteLine("Insufficient rage. Used Melee instead.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.Write("struck ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {warriorDamage} damage!");
                    mageHealth -= warriorDamage;
                    rage += rng.Next(5, 12);
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }
                if (attackChoice == "Melee")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.Write("struck ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {warriorDamage} damage!");
                    mageHealth -= warriorDamage;
                    rage += rng.Next(5, 12);
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }

                if (mageHealth <= 0)
                {
                    warriorVictory(warriorName, mageName);
                    Console.WriteLine();
                    System.Environment.Exit(1);
                }
                Console.WriteLine();
                turn = mageTurn;
            }

            if (turn == mageTurn)
            {
                fireball = rng.Next(6, 8);
                frostbolt = rng.Next(13, 16);
                Console.WriteLine("Fireball: Strikes the target for 6 to 8 damage.");
                Console.WriteLine("Frostbolt: Casts a Frostbolt at the target for 13 to 16 damage. Costs 7 Mana");
                Console.Write("Choice: ");
                string attackChoice = Console.ReadLine();
                Console.WriteLine();
                if (attackChoice == "Frostbolt" && mana > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName}'s ");
                    Console.ResetColor();
                    Console.Write("frostbolt struck ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {frostbolt} damage!");
                    warriorHealth -= frostbolt;
                    mana -= 7;
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }
                if (attackChoice == "Frostbolt" && mana == 0)
                {
                    Console.WriteLine("Insufficient mana. Used Fireball instead.");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName}'s ");
                    Console.ResetColor();
                    Console.Write("fireball struck ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {fireball} damage!");
                    warriorHealth -= fireball;
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }
                if (attackChoice == "Fireball")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{mageName}'s ");
                    Console.ResetColor();
                    Console.Write("fireball struck ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{warriorName} ");
                    Console.ResetColor();
                    Console.WriteLine($"for {fireball} damage!");
                    warriorHealth -= fireball;
                    stats(warriorName, warriorHealth, rage, mageName, mageHealth, mana);
                }

                if (warriorHealth <= 0)
                {
                    mageVictory(warriorName, mageName);
                    Console.WriteLine();
                    System.Environment.Exit(1);
                }
                Console.WriteLine();
                turn = warriorTurn;
            }
        }
    }

    static void warriorVictory(string warriorName, string mageName)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{warriorName} ");
        Console.ResetColor();
        Console.Write("has defeated ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{mageName}!");
        Console.ResetColor();
    }

    static void mageVictory(string warriorName, string mageName)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($"{mageName} ");
        Console.ResetColor();
        Console.Write("has defeated ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{warriorName}!");
        Console.ResetColor();
    }
    static void stats(string warriorName, int warriorHealth, int rage, string mageName, int mageHealth, int mana)
    {
        Console.WriteLine("*************************************");
        Console.Write($"{warriorName}\t");
        Console.WriteLine($"\t{mageName}");
        Console.WriteLine($"Health: {warriorHealth}\tHealth: {mageHealth}");
        Console.WriteLine($"Rage: {rage}\tMana: {mana}");
        Console.WriteLine("*************************************");
        Console.WriteLine();
        Console.WriteLine();
    }
}