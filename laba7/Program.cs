using System;
using laba7;

namespace laba7;

/// <summary>
/// Програма для демонстрації роботи списку.[cite: 1]
/// </summary>
class Program
{
    static void Main()
    {
        IMyList myList = new MyShortList();
        short[] initialData = { 10, 14, 21, 30, 45 };

        // Наповнення
        foreach (var val in initialData) myList.AddToEnd(val);
        Console.WriteLine("Початковий список:");
        Print(myList);

        // 1. Пошук кратного
        short div = 7;
        Console.WriteLine($"\n1. Перший кратний {div}: {myList.FindFirstMultiple(div)}");

        // 2. Заміна парних позицій на 0
        myList.ReplaceEvenWithZero();
        Console.WriteLine("\n2. Список після заміни парних позицій на 0:");
        Print(myList);

        // 3. Фільтрація (новий список)
        short threshold = 15;
        var filtered = myList.FilterGreater(threshold);
        Console.WriteLine($"\n3. Елементи більше {threshold} у новому списку:");
        Print(filtered);

        // 4. Видалення непарних позицій
        myList.RemoveOddPositions();
        Console.WriteLine("\n4. Список після видалення непарних позицій:");
        Print(myList);
    }

    /// <summary>
    /// Метод для виведення даних (вважається використанням списку).[cite: 1]
    /// </summary>
    static void Print(IEnumerable<short> list)
    {
        foreach (var item in list) Console.Write($"{item} ");
        Console.WriteLine();
    }
}