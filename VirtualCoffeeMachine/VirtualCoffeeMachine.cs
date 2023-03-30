using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualCoffeeMachine
{
    public class CoffeeMachine
    {
        public decimal Price { get; set; } = 2.50M;
        public decimal Balance { get; private set; } = 0M;
        public decimal TotalSales { get; private set; } = 0M;
        public int CupsOfCoffee { get; private set; } = 10;
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
                return true;
            }
            return false;
        }

        public bool SelectCoffee()
        {
            if (Balance >= Price && CupsOfCoffee > 0)
            {
                // Dispense coffee
                Balance -= Price;
                TotalSales += Price;
                CupsOfCoffee--;
                return true;
            }
            return false;
        }

        public Dictionary<decimal, int> ReturnChange()
        {
            Dictionary<decimal, int> change = new Dictionary<decimal, int>();
            decimal amountToReturn = Balance;

            foreach (KeyValuePair<decimal, int> kvp in ChangeAvailable.OrderByDescending(kvp => kvp.Key))
            {
                int coinsToReturn = (int)Math.Floor(amountToReturn / kvp.Key);

                if (coinsToReturn > kvp.Value)
                {
                    coinsToReturn = kvp.Value;
                }

                if (coinsToReturn > 0)
                {
                    change.Add(kvp.Key, coinsToReturn);
                    amountToReturn -= kvp.Key * coinsToReturn;
                    ChangeAvailable[kvp.Key] -= coinsToReturn;
                }

                if (amountToReturn == 0)
                {
                    Balance = 0M;
                    return change;
                }
            }

            return null;
        }

        
    



}
}
