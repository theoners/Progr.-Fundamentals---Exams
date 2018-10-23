using System;

namespace _01._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGameCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headset = 0;
            int mouse = 0;
            int keyboard = 0;
            int display = 0;

            for (int i = 1; i <= lostGameCount; i++)
            {
                if (i%2==0)
                {
                    headset++;
                }
                if (i%3==0)
                {
                    mouse++;
                }
                if (i%2==0&& i%3==0)
                {
                    keyboard++;
                    if (keyboard % 2 == 0 && keyboard != 0)
                    {
                        display++;
                    }
                }

                
            }

            double totalExpenses = headsetPrice * headset + mousePrice * mouse + keyboardPrice * keyboard + displayPrice * display;
            Console.WriteLine($"Rage expenses: {totalExpenses:F2} lv.");
        }
    }
}
