using System;

namespace _07.TrainingHallEquipment
{
    class TrainingHallEquipment
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            double subtotal = 0;
            int itemsCnt = int.Parse(Console.ReadLine());

            for (int cnt = 0; cnt < itemsCnt; cnt++)
            {
                string itemName = Console.ReadLine();
                double itemPrice = double.Parse(Console.ReadLine());
                int quantity = int.Parse(Console.ReadLine());

                if (quantity > 1)
                {
                    itemName += 's';
                }
                Console.WriteLine("Adding {0} {1} to cart.", quantity, itemName);
                subtotal += quantity * itemPrice;
            }

            Console.WriteLine("Subtotal: ${0:F2}", subtotal);
            double result = money - subtotal;

            if (result > 0)
            {
                Console.WriteLine("Money left: ${0:F2}", result);
            }
            else
            {
                result = -result;
                Console.WriteLine("Not enough. We need ${0:F2} more.", result);
            }
        }
    }
}
