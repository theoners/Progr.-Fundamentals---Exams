using System;

namespace _01._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amountOfMoney = double.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalEquipmentPrice = lightsaberPrice * (Math.Ceiling(countOfStudents * 1.1)) + robePrice * countOfStudents
                + beltPrice * (countOfStudents - (countOfStudents / 6));

            if (totalEquipmentPrice > amountOfMoney)
            {
                Console.WriteLine($"Ivan Cho will need {(totalEquipmentPrice - amountOfMoney):F2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalEquipmentPrice:F2}lv.");
            }
        }
    }
}
