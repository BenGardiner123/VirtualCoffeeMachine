// See https://aka.ms/new-console-template for more information
using VirtualCoffeeMachine;
CoffeeMachine coffeeMachine = new CoffeeMachine();

while (true)
{
    if (coffeeMachine.showGreeting)
    {
        Console.WriteLine("Hi, Welcome to the Virtual Coffee Machine");
        Console.WriteLine("-----------------------------------------");
        coffeeMachine.showGreeting = false;
    }


    Console.WriteLine("Current balance: {0:C}", coffeeMachine.Balance);

    Console.WriteLine("Enter 'A' to add coins");

    if (coffeeMachine.Balance > 0)
    {
        Console.WriteLine("Enter 'R' to refund balamce");
    }


    foreach (Coffee coffee in coffeeMachine.Coffees)
    {
        if (coffeeMachine.Balance >= coffee.Price)
        {
            Console.WriteLine($"Press #{coffee.Id} for {coffee.Name} ({coffee.Price:C})");
        }
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
            // find the coffee with the id of 1, then get the price of that coffee
            var locatedCap = coffeeMachine.Coffees.Find(c => c.Id == 1);
            if (locatedCap != null && coffeeMachine.GetPrice(locatedCap) <= coffeeMachine.Balance)

            {
                if (coffeeMachine.SelectCoffee(locatedCap))
                {
                    Console.WriteLine("Enjoy your Cappuccino!");
                }
                else
                {
                    Console.WriteLine("Unable to dispense Cappuccino. We're out of stock");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to buy Cappuccino.");
            }
            break;
        case "2":
            var locatedLatte = coffeeMachine.Coffees.Find(c => c.Id == 2);
            if (locatedLatte != null && coffeeMachine.GetPrice(locatedLatte) <= coffeeMachine.Balance)
            {
                if (coffeeMachine.SelectCoffee(locatedLatte))
                {
                    Console.WriteLine("Enjoy your Latte!");
                }
                else
                {
                    Console.WriteLine("Unable to dispense Latte. We're out of stock");
                }
            }
            else
            {
                Console.WriteLine("Insufficient balance to buy Latte.");
            }
            break;
        case "3":
            var locatedDecaf = coffeeMachine.Coffees.Find(c => c.Id == 3);
            if (locatedDecaf != null && coffeeMachine.GetPrice(locatedDecaf) <= coffeeMachine.Balance)
            {
                if (coffeeMachine.SelectCoffee(locatedDecaf))
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
            decimal parsedCoinValue;
            // use tryParse to check if the input is a valid decimal
            if (decimal.TryParse(Console.ReadLine(), out parsedCoinValue))
            {
                if (coffeeMachine.InsertCoin(parsedCoinValue))
                {
                    Console.WriteLine("Coin accepted. Thank you");
                }
                else
                {
                    Console.WriteLine("** Invalid Coin **.");
                }
            }
            else
            {
                Console.WriteLine("** Invalid input. Please enter a valid coin value. **");
            }
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
        case "r":
            if (coffeeMachine.Balance > 0M)
            {
                Dictionary<decimal, int> change = coffeeMachine.ReturnChange();
                Console.WriteLine("Dispensing change:");
                foreach (KeyValuePair<decimal, int> kvp in change)
                {
                    Console.WriteLine("{0:C} x {1}", kvp.Key, kvp.Value);
                }
            }
            break;  
    }

    Console.WriteLine();
}







