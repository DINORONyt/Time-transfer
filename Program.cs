using System;

namespace Lab01_Variant12
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            do
            {
                // Вывод меню
                Console.WriteLine("==============================================");
                Console.WriteLine("   ПЕРЕВОД ВРЕМЕНИ - ВАРИАНТ 12");
                Console.WriteLine("==============================================");
                Console.WriteLine();
                Console.WriteLine("ЗАДАЧИ:");
                Console.WriteLine("1. Перевод секунд в минуты и секунды");
                Console.WriteLine("2. Перевод секунд в часы, минуты и секунды");
                Console.WriteLine("3. Процент от суток");
                Console.WriteLine("4. Выход из программы");
                Console.WriteLine();
                Console.Write("Введите номер задачи (1-4): ");

                // Обработка ввода меню
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Ошибка: введите число от 1 до 4!");
                    Console.WriteLine();
                    continue;
                }

                // Выбор задачи
                switch (choice)
                {
                    case 1:
                        Task1_ConvertSecondsToMinutes();
                        break;
                    case 2:
                        Task2_ConvertSecondsToHoursMinutesSeconds();
                        break;
                    case 3:
                        Task3_PercentageOfDay();
                        break;
                    case 4:
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Ошибка: введите число от 1 до 4!");
                        break;
                }

                if (choice != 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (choice != 4);
        }

        /// <summary>
        /// Валидация ввода положительного целого числа
        /// </summary>
        /// <param name="prompt">Приглашение к вводу</param>
        /// <returns>Валидное положительное число</returns>
        static int ReadPositiveInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                // Проверка на пустой ввод
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Ошибка: ввод не может быть пустым!");
                    Console.WriteLine();
                    continue;
                }

                // Проверка на то, что введено число
                if (!int.TryParse(input, out value))
                {
                    Console.WriteLine("Ошибка: введите корректное целое число до 2 147 483 647");
                    Console.WriteLine();
                    continue;
                }

                // Проверка на положительность
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: значение должно быть неотрицательным!");
                    Console.WriteLine();
                    continue;
                }

                return value;
            }
        }

        /// <summary>
        /// ЗАДАЧА 1: Перевод секунд в минуты и секунды
        /// </summary>
        static void Task1_ConvertSecondsToMinutes()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("  ЗАДАЧА 1: Перевод секунд в минуты и секунды");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            // Ввод количества секунд
            int totalSeconds = ReadPositiveInt("Введите количество секунд: ");

            // Вычисление минут и оставшихся секунд
            // Формула: минуты = секунды / 60
            int minutes = totalSeconds / 60;

            // Формула: остаток секунд = секунды % 60
            int remainingSeconds = totalSeconds % 60;

            // Вывод результата
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("РЕЗУЛЬТАТ:");
            Console.WriteLine($"  {totalSeconds} сек = {minutes} мин {remainingSeconds} сек");
            Console.WriteLine("==============================================");
        }

        /// <summary>
        /// ЗАДАЧА 2: Перевод секунд в часы, минуты и секунды
        /// </summary>
        static void Task2_ConvertSecondsToHoursMinutesSeconds()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("  ЗАДАЧА 2: Перевод секунд в часы, минуты и секунды");
            Console.WriteLine("==================================================");
            Console.WriteLine();

            // Ввод количества секунд
            int totalSeconds = ReadPositiveInt("Введите количество секунд: ");

            // Вычисление часов, минут и секунд
            // Формула: часы = секунды / 3600
            int hours = totalSeconds / 3600;

            // Остаток после выделения часов
            int remainingAfterHours = totalSeconds % 3600;

            // Минуты из остатка
            // Формула: минуты = остаток / 60
            int minutes = remainingAfterHours / 60;

            // Секунды - остаток от деления на 60
            // Формула: секунды = остаток % 60
            int seconds = remainingAfterHours % 60;

            // Вывод результата
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("РЕЗУЛЬТАТ:");
            Console.WriteLine($"  {totalSeconds} сек = {hours} ч {minutes} мин {seconds} сек");
            Console.WriteLine("==============================================");
        }

        /// <summary>
        /// ЗАДАЧА 3: Процент от суток
        /// </summary>
        static void Task3_PercentageOfDay()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("  ЗАДАЧА 3: Процент от суток");
            Console.WriteLine("==============================================");
            Console.WriteLine();

            // Ввод количества секунд
            int secondsInput = ReadPositiveInt("Введите количество секунд: ");

            // Константа: количество секунд в сутках
            // Формула: 24 часа × 60 минут × 60 секунд = 86400 секунд
            const int SECONDS_IN_DAY = 24 * 60 * 60;

            // Вычисление процента от суток
            // Формула: процент = (секунды / секунды_в_сутках) × 100
            double percentage = (secondsInput * 100.0) / SECONDS_IN_DAY;

            // Вывод результата
            Console.WriteLine();
            Console.WriteLine("==============================================");
            Console.WriteLine("РЕЗУЛЬТАТ:");
            Console.WriteLine($"  Количество секунд в сутках: {SECONDS_IN_DAY}");
            Console.WriteLine($"  Процент от суток: {percentage:F2}%");
            Console.WriteLine("==============================================");
        }
    }
}