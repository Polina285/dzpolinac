using System;
using System.Text;

class Program
{
    static void Main()
    {
        ShowProgramInfo();
        
        while (true)
        {
            try
            {
                Console.WriteLine("\n=== Меню програми ===");
                Console.WriteLine("1. Перевірка ділення");
                Console.WriteLine("2. Оцінка рівня");
                Console.WriteLine("3. Сума найбільших чисел");
                Console.WriteLine("4. Калькулятор BMI");
                Console.WriteLine("5. Гра \"Вгадай число\"");
                Console.WriteLine("6. Генератор паролів");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВиберіть опцію (0-6): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CheckDivision();
                        break;
                    case "2":
                        CheckScore();
                        break;
                    case "3":
                        SumLargestNumbers();
                        break;
                    case "4":
                        CalculateBMI();
                        break;
                    case "5":
                        PlayGuessNumber();
                        break;
                    case "6":
                        GeneratePassword();
                        break;
                    case "0":
                        Console.WriteLine("Дякуємо за використання програми!");
                        Console.WriteLine("Роботу виконано успішно!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: Введено некоректні дані. Будь ласка, вводьте тільки числа.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Виникла помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть Enter для продовження...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    static void ShowProgramInfo()
    {
        Console.WriteLine("===========================================");
        Console.WriteLine("           Багатофункціональна           ");
        Console.WriteLine("         програма-калькулятор            ");
        Console.WriteLine("===========================================");
        Console.WriteLine("Автор: [Ваше ім'я]");
        Console.WriteLine("Версія: 1.1");
        Console.WriteLine("Дата: " + DateTime.Now.ToString("dd.MM.yyyy"));
        Console.WriteLine("===========================================\n");
    }

    static bool TryReadDouble(string prompt, out double result)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Помилка: Введіть число!");
                result = 0;
                return false;
            }
            
            if (double.TryParse(input, out result))
            {
                return true;
            }
            
            Console.WriteLine("Помилка: Введіть коректне число!");
        }
    }

    static void CheckDivision()
    {
        Console.WriteLine("=== Перевірка ділення ===");
        
        if (!TryReadDouble("Введіть число x: ", out double x))
            return;
            
        if (!TryReadDouble("Введіть число d: ", out double d))
            return;
        
        if (d == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль неможливе!");
            return;
        }
        
        if (x % d == 0)
            Console.WriteLine($"Число {x} ділиться на {d} без залишку");
        else
            Console.WriteLine($"Число {x} не ділиться на {d} без залишку (залишок: {x % d})");
    }

    static void CheckScore()
    {
        Console.WriteLine("=== Перевірка оцінки ===");
        
        if (!TryReadDouble("Введіть оцінку (0-100): ", out double score))
            return;
        
        if (score < 0 || score > 100)
        {
            Console.WriteLine("Помилка: Оцінка повинна бути від 0 до 100!");
            return;
        }
        
        string рівень = score switch
        {
            >= 90 => "Відмінний",
            >= 70 => "Високий",
            >= 50 => "Середній",
            _ => "Низький"
        };
        
        Console.WriteLine($"Ваш рівень: {рівень} ({score:F1} балів)");
    }

    static void SumLargestNumbers()
    {
        Console.WriteLine("=== Сума найбільших чисел ===");
        
        Console.Write("Введіть три числа (a, b, c) через пробіл: ");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Помилка: Введіть три числа!");
            return;
        }
        
        string[] numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (numbers.Length != 3)
        {
            Console.WriteLine("Помилка: Потрібно ввести рівно три числа!");
            return;
        }
        
        if (!double.TryParse(numbers[0], out double a) ||
            !double.TryParse(numbers[1], out double b) ||
            !double.TryParse(numbers[2], out double c))
        {
            Console.WriteLine("Помилка: Введіть коректні числа!");
            return;
        }
        
        var sortedNumbers = new[] { a, b, c }.OrderByDescending(x => x).ToArray();
        double sum = sortedNumbers[0] + sortedNumbers[1];
        
        Console.WriteLine($"Введені числа: {a}, {b}, {c}");
        Console.WriteLine($"Два найбільших числа: {sortedNumbers[0]} і {sortedNumbers[1]}");
        Console.WriteLine($"Їх сума: {sum}");
    }

    static void CalculateBMI()
    {
        Console.WriteLine("=== Калькулятор індексу маси тіла (BMI) ===");
        
        if (!TryReadDouble("Введіть вашу вагу (кг): ", out double weight))
            return;
            
        if (!TryReadDouble("Введіть ваш зріст (м): ", out double height))
            return;

        if (weight <= 0 || height <= 0)
        {
            Console.WriteLine("Помилка: Вага та зріст повинні бути більше 0!");
            return;
        }

        double bmi = weight / (height * height);
        Console.WriteLine($"\nВаш індекс маси тіла (BMI): {bmi:F2}");

        string категорія = bmi switch
        {
            < 16.0 => "Виражений дефіцит маси",
            < 18.5 => "Недостатня маса",
            < 25.0 => "Нормальна маса",
            < 30.0 => "Надмірна маса",
            < 35.0 => "Ожиріння I ступеня",
            < 40.0 => "Ожиріння II ступеня",
            _ => "Ожиріння III ступеня"
        };

        Console.WriteLine($"Категорія: {категорія}");
        
        // Додаткова інформація
        double idealWeight = 22 * height * height; // середнє значення норми
        Console.WriteLine($"\nРекомендована вага для вашого зросту: {idealWeight:F1} кг");
        if (weight > idealWeight)
            Console.WriteLine($"Рекомендується зменшити вагу на {(weight - idealWeight):F1} кг");
        else if (weight < idealWeight)
            Console.WriteLine($"Рекомендується набрати {(idealWeight - weight):F1} кг");
    }

    static void PlayGuessNumber()
    {
        Console.WriteLine("=== Гра \"Вгадай число\" ===");
        
        Random random = new Random();
        int number = random.Next(1, 101);
        int attempts = 0;
        int maxAttempts = 7;
        HashSet<int> usedNumbers = new HashSet<int>();

        Console.WriteLine($"Я загадав число від 1 до 100. У вас {maxAttempts} спроб.");

        while (attempts < maxAttempts)
        {
            Console.Write($"\nСпроба {attempts + 1}/{maxAttempts}. Введіть число: ");
            if (!int.TryParse(Console.ReadLine(), out int guess))
            {
                Console.WriteLine("Будь ласка, введіть правильне число!");
                continue;
            }

            if (guess < 1 || guess > 100)
            {
                Console.WriteLine("Число повинно бути від 1 до 100!");
                continue;
            }

            if (usedNumbers.Contains(guess))
            {
                Console.WriteLine("Ви вже вводили це число! Спробуйте інше.");
                continue;
            }

            usedNumbers.Add(guess);
            attempts++;

            if (guess == number)
            {
                Console.WriteLine($"\nВітаємо! Ви вгадали число {number} за {attempts} спроб!");
                if (attempts == 1)
                    Console.WriteLine("Неймовірно! Ви вгадали з першої спроби!");
                else if (attempts <= 3)
                    Console.WriteLine("Чудовий результат!");
                return;
            }
            
            int diff = Math.Abs(number - guess);
            string підказка = diff switch
            {
                <= 5 => "Дуже гаряче!",
                <= 10 => "Гаряче!",
                <= 20 => "Тепло",
                <= 30 => "Прохолодно",
                _ => "Холодно"
            };

            Console.WriteLine($"{підказка} Загадане число {(guess < number ? "більше" : "менше")}!");
        }

        Console.WriteLine($"\nГра закінчена! Загадане число було: {number}");
        Console.WriteLine("Спробуйте ще раз, можливо наступного разу пощастить!");
    }

    static void GeneratePassword()
    {
        Console.WriteLine("=== Генератор надійних паролів ===");
        
        Console.Write("Введіть довжину пароля (мінімум 8 символів): ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length < 8)
        {
            Console.WriteLine("Помилка: Довжина пароля повинна бути не менше 8 символів!");
            return;
        }

        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

        StringBuilder password = new StringBuilder();
        Random random = new Random();

        // Гарантуємо наявність хоча б одного символу кожного типу
        password.Append(upperChars[random.Next(upperChars.Length)]);
        password.Append(lowerChars[random.Next(lowerChars.Length)]);
        password.Append(numberChars[random.Next(numberChars.Length)]);
        password.Append(specialChars[random.Next(specialChars.Length)]);

        // Додаємо решту символів
        string allChars = upperChars + lowerChars + numberChars + specialChars;
        for (int i = 4; i < length; i++)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }

        // Перемішуємо символи
        string finalPassword = new string(password.ToString().ToCharArray()
            .OrderBy(x => random.Next()).ToArray());

        Console.WriteLine($"\nЗгенерований пароль: {finalPassword}");
        
        // Оцінка надійності пароля
        int strength = 0;
        strength += finalPassword.Any(char.IsUpper) ? 25 : 0;
        strength += finalPassword.Any(char.IsLower) ? 25 : 0;
        strength += finalPassword.Any(char.IsDigit) ? 25 : 0;
        strength += finalPassword.Any(c => specialChars.Contains(c)) ? 25 : 0;

        string надійність = strength switch
        {
            100 => "Відмінна",
            75 => "Добра",
            50 => "Середня",
            _ => "Слабка"
        };

        Console.WriteLine("\nХарактеристики пароля:");
        Console.WriteLine($"- Довжина: {finalPassword.Length} символів");
        Console.WriteLine($"- Містить великі літери: {(finalPassword.Any(char.IsUpper) ? "Так" : "Ні")}");
        Console.WriteLine($"- Містить малі літери: {(finalPassword.Any(char.IsLower) ? "Так" : "Ні")}");
        Console.WriteLine($"- Містить цифри: {(finalPassword.Any(char.IsDigit) ? "Так" : "Ні")}");
        Console.WriteLine($"- Містить спеціальні символи: {(finalPassword.Any(c => specialChars.Contains(c)) ? "Так" : "Ні")}");
        Console.WriteLine($"- Надійність пароля: {надійність} ({strength}%)");
    }
}
