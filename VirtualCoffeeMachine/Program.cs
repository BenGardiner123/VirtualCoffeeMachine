// See https://aka.ms/new-console-template for more information
using VirtualCoffeeMachine;
CoffeeMachine coffeeMachine = new CoffeeMachine();


while (true)
{
    Console.WriteLine("Current balance: {0:C}", coffeeMachine.Balance);

    Console.WriteLine("Enter 'A' to add coins");

    if (coffeeMachine.Balance >= 3.50M)
    {
        Console.WriteLine("Enter 1 to buy Cappuccino");
    }

    if (coffeeMachine.Balance >= 3.00M)
    {
        Console.WriteLine("Enter 2 to buy Latte");
    }

    if (coffeeMachine.Balance >= 4.00M)
    {
        Console.WriteLine("Enter 3 to buy Decaf");
    }

    Console.WriteLine("Enter 0 to exit");

    string choice = Console.ReadLine().ToLower();

    switch (choice)
    {
        case "0":
            if (coffeeMachine.Balance > 0M)
            {
                Dictionary<decimal, int> change = coffeeMachine.ReturnChange();
                Console.WriteLine("Dispensing change:");
                foreach (KeyValuePair<decimal, int> kvp in change)
                {
                    Console.WriteLine("{0:C} x {1}", kvp.Key, kvp.Value);
                }
            }
            Environment.Exit(0);
            break;
        case "1":
            if (coffeeMachine.Price <= coffeeMachine.Balance)
            {
                if (coffeeMachine.SelectCoffee())
                {
                    Console.WriteLine("Enjoy your Cappuccino!");
                }
                else
                {
                    Console.WriteLine("Unable to dispense Cappuccino.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to buy Cappuccino.");
            }
            break;
        case "2":
            if (coffeeMachine.Price <= coffeeMachine.Balance)
            {
                if (coffeeMachine.SelectCoffee())
                {
                    Console.WriteLine("Enjoy your Latte!");
                }
                else
                {
                    Console.WriteLine("Unable to dispense Latte.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to buy Latte.");
            }
            break;
        case "3":
            if (coffeeMachine.Price <= coffeeMachine.Balance)
            {
                if (coffeeMachine.SelectCoffee())
                {
                    Console.WriteLine("Enjoy your Decaf!");
                }
                else
                {
                    Console.WriteLine("Unable to dispense Decaf.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to buy Decaf.");
            }
            break;
        case "a":
            Console.WriteLine("Enter coin value (0.1, 0.2, 0.5, 1, 2):");
            decimal coinValue = decimal.Parse(Console.ReadLine());
            if (coffeeMachine.InsertCoin(coinValue))
            {
                Console.WriteLine("Coin accepted.");
            }
            else
            {
                Console.WriteLine("Invalid coin.");
            }
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

    Console.WriteLine();
}







