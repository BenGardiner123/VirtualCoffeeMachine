
namespace VirtualCoffeeMachine
{
    public class CoffeeMachine
    {
        public bool showGreeting { get; set; } = true;
        public List<Coffee> Coffees { get; private set; }
        public decimal Balance { get; private set; } = 0M;
        public decimal TotalSales { get; private set; } = 0M;
        public int CupsOfCoffee { get; private set; } = 50;

        public CoffeeMachine()
        {
            Coffees = new List<Coffee>()
            {
                new Coffee("Cappuccino", 3.50M, 1),
                new Coffee("Latte", 3.00M, 2),
                new Coffee("Decaf", 4.00M, 3)
            };
        }   

        
        public decimal GetPrice(Coffee coffeeType)
        {
            // ideally returning zero here is not the best, but it will work for now
            if (!Coffees.Contains(coffeeType))
            {
                return 0;
            }
            return coffeeType.Price;
        }

        public Dictionary<decimal, int> ChangeAvailable { get; private set; } = new Dictionary<decimal, int>()
        {
            { 2M, 100 },
            { 1M, 100 },
            { 0.5M, 100 },
            { 0.2M, 100 },
            { 0.1M, 100 }
        };

        public bool InsertCoin(decimal coin)
        {
            if (coin == 2M || coin == 1M || coin == 0.5M || coin == 0.2M || coin == 0.1M)
            {
                Balance += coin;
                // adding a coin increase the change on hand
                ChangeAvailable[coin]++;
                return true;
            }
            else if (coin == 0.01M || coin == 0.02M)
            {
                Console.WriteLine("** Coin returned - 1c and 2c Coins are not useable **.");
                return false;
            }
            return false;
        }

        public bool SelectCoffee(Coffee coffee)
        {

            var price = GetPrice(coffee);
            // try and find the price of the coffee type, if found set the price variable, then check the rest
            if (Balance >= price && CupsOfCoffee > 0)
            {
                // Updated the balance, total sales and cups of coffee available
                Balance -= price;
                TotalSales += price;
                CupsOfCoffee--;
                return true;
            }
            return false;
        }

        public Dictionary<decimal, int>? ReturnChange()
        {
            // this will hold all the change to return
            var change = new Dictionary<decimal, int>();

            // get the current balance
            decimal amountToReturn = Balance;
                
            // loop through the change available dictionary, order by the key (coin value) in descending order
            foreach (KeyValuePair<decimal, int> kvp in ChangeAvailable.OrderByDescending(kvp => kvp.Key))
            {
                // work out how many coins fit into the amount to return for this iteration
                int coinsToReturn = (int)Math.Floor(amountToReturn / kvp.Key);

                // if the number of coins to return is greater than the number of coins available, set the number of coins to return to the number of coins available
                if (coinsToReturn > kvp.Value)
                {
                    coinsToReturn = kvp.Value;
                }

                // if there are coins to return, add them to the change dictionary and update the amount to return
                if (coinsToReturn > 0)
                {
                    change.Add(kvp.Key, coinsToReturn);
                    amountToReturn -= kvp.Key * coinsToReturn;
                    ChangeAvailable[kvp.Key] -= coinsToReturn;
                }

                // if the amount to return is 0, set the balance to 0 and return the dictionary of all the change
                if (amountToReturn == 0)
                {
                    Balance = 0M;
                    return change;
                }
            }
            // if we got here then there is no change to return and the machine is dry
            Console.WriteLine("No more change left.");
            return null;
        }

      
    }

    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Coffee(string name, decimal price, int id)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
