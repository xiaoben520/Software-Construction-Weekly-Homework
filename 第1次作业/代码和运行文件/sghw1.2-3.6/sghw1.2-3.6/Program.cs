using System;
namespace MyFirstCSharpApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int lowerBound = 0;
            int upperBound = 0;
            try
            {
                Console.Write("请输入查找素数的下限数据：");
                lowerBound = int.Parse(Console.ReadLine());
                Console.Write("请输入查找素数的上限数据：");
                upperBound = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("输入无效，请输入整数！");
                Console.ReadLine();
                return; 
            }
            if (lowerBound > upperBound)
            {
                int temp = lowerBound;
                lowerBound = upperBound;
                upperBound = temp;
            }

            Console.WriteLine($"\n[{lowerBound}, {upperBound}] 之间的素数有：");

            int primeCount = 0; 

            // 循环遍历上下限之间的所有数字
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write(i + "\t");
                    primeCount++;
                    if (primeCount % 10 == 0)
                    {
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadLine();
        }
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i * i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false; 
                }
            }
            return true;
        }
    }
}
