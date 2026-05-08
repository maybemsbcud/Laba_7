using System;
using System.Collections.Generic;
using laba7;

namespace SinglyLinkedListApp;

class Program
{
    static void Main()
    {
        IMyList myList = new MyShortList();

        Console.WriteLine("Оберіть спосіб заповнення:");
        Console.WriteLine("1 - ввести елементи вручну");
        Console.WriteLine("2 - використати тестові дані");
        Console.Write("Ваш вибір (1 або 2): ");
        
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Введіть кількість елементів: ");
            if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Елемент {i + 1}: ");
                    if (short.TryParse(Console.ReadLine(), out short val))
                    {
                        myList.AddToEnd(val);
                    }
                    else
                    {
                        Console.WriteLine("Помилка вводу. Будь ласка, введіть ціле число типу short.");
                        i--;
                    }
                }
            }
        }
        else
        {
            short[] testData = { 10, 14, 21, 30, 45, 8, 15 };
            Console.Write("Використано тестові дані: ");
            Console.WriteLine(string.Join(", ", testData));
            foreach (var val in testData)
            {
                myList.AddToEnd(val);
            }
        }

        Console.WriteLine("\nПочатковий список: " + string.Join(" -> ", myList));

        Console.Write("\nЗавдання 1 - введіть число для пошуку кратного: ");
        if (short.TryParse(Console.ReadLine(), out short div) && div != 0)
        {
            var firstMultiple = myList.FindFirstMultiple(div);
            if (firstMultiple.HasValue)
                Console.WriteLine($"Перший елемент, кратний {div} = {firstMultiple.Value}");
            else
                Console.WriteLine($"Елементів, кратних {div}, не знайдено.");
        }
        else
        {
            Console.WriteLine("Некоректний дільник (або 0).");
        }

        myList.ReplaceEvenWithZero();
        Console.WriteLine("Завдання 2: Список після заміни парних позицій на 0:");
        Console.WriteLine(string.Join(" -> ", myList));

        Console.Write("\nЗавдання 3 - введіть порогове значення: ");
        if (short.TryParse(Console.ReadLine(), out short threshold))
        {
            var filteredList = myList.FilterGreater(threshold);
            Console.WriteLine($"Елементи > {threshold}:");
            Console.WriteLine(string.Join(" -> ", filteredList));
        }

        myList.RemoveOddPositions();
        Console.WriteLine("\nЗавдання 4: Список після видалення непарних позицій:");
        Console.WriteLine(string.Join(" -> ", myList));
    }
}