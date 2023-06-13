using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateDifferentCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cartridges = { 10, 50, 100 };
            int[] payouts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            foreach (int amount in payouts)
            {
                string str = string.Empty;
                string strarry = string.Empty;

                List<List<int>> combinations = CalculateCombinations(amount, cartridges);
                foreach (List<int> combination in combinations)
                {
                    str = string.Empty;
                    foreach (int item in combination)
                    {
                        str = str + ", " + item.ToString();
                    }
                    strarry = strarry + ", {" + str.TrimStart(',') + "}";
                }

                Console.WriteLine("Possible combinations for {amount} EUR are:" + strarry.TrimStart(','));
                
            }
            Console.Read();
        }

        private static List<List<int>> CalculateCombinations(int payoutAmount, int[] cartridges)
        {
            List<List<int>> combinations = new List<List<int>>();
            int cartridgeCount = cartridges.Length;

            for (int i = 0; i <= payoutAmount / cartridges[0]; i++)
            {
                int remAmount1 = payoutAmount - (i * cartridges[0]);

                for (int j = 0; j <= remAmount1 / cartridges[1]; j++)
                {
                    int remAmount2 = remAmount1 - (j * cartridges[1]);

                    if (remAmount2 % cartridges[2] == 0)
                    {
                        int count3 = remAmount2 / cartridges[2];
                        combinations.Add(new List<int> { i, j, count3 });
                    }
                }
            }

            return combinations;
        }       
    }
}
