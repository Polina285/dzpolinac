// using System;

// class Program
// {
//     static void Main()
//     {
//         // Перевірка на ділення без залишку
//         Console.Write("Введіть число x: ");
//         int x = int.Parse(Console.ReadLine());
//         Console.Write("Введіть число d: ");
//         int d = int.Parse(Console.ReadLine());
        
//         if (x % d == 0)
//             Console.WriteLine("Ділиться");
//         else
//             Console.WriteLine("Не ділиться");
        
//         // Визначення рівня оцінки
//         Console.Write("Введіть оцінку (score): ");
//         int score = int.Parse(Console.ReadLine());
        
//         if (score < 50)
//             Console.WriteLine("Низький");
//         else if (score < 70)
//             Console.WriteLine("Середній");
//         else if (score < 90)
//             Console.WriteLine("Високий");
//         else
//             Console.WriteLine("Відмінний");
        
//         // Знаходження суми двох найбільших чисел
//         Console.Write("Введіть три числа (a, b, c): ");
//         string[] input = Console.ReadLine().Split(' ');
//         double a = double.Parse(input[0]);
//         double b = double.Parse(input[1]);
//         double c = double.Parse(input[2]);
        
//         double sum = a + b + c - Math.Min(a, Math.Min(b, c));
//         Console.WriteLine("Сума двох найбільших чисел: " + sum);
//     }
// }
