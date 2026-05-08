using System;
using System.Collections;
using System.Collections.Generic;

namespace laba7;

public class MyShortList : IMyList
{
    private Node? _head;
    private Node? _tail;
    private int _count;

    /// <summary>
    /// Кількість елементів.
    /// </summary>
    public int Count => _count;

    /// <summary>
    /// Індексатор для доступу на читання.[cite: 1]
    /// </summary>
    public short this[int index]
    {
        get
        {
            if (index < 0 || index >= _count) throw new IndexOutOfRangeException();
            var current = _head;
            for (var i = 0; i < index; i++) current = current?.Next;
            return current!.Data;
        }
    }

    /// <summary>
    /// Додавання в кінець списку.[cite: 1]
    /// </summary>
    public void AddToEnd(short value)
    {
        var newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            _tail = newNode;
        }
        _count++;
    }

    /// <summary>
    /// Видалення елемента за його номером (від 1).[cite: 1]
    /// </summary>
    public void RemoveAt(int number)
    {
        var index = number - 1;
        if (index < 0 || index >= _count) return;

        if (index == 0)
        {
            _head = _head?.Next;
            if (_head == null) _tail = null;
        }
        else
        {
            var current = _head;
            for (var i = 0; i < index - 1; i++) current = current?.Next;
            if (current?.Next != null)
            {
                current.Next = current.Next.Next;
                if (current.Next == null) _tail = current;
            }
        }
        _count--;
    }

    // --- Методи варіанту 6 ---[cite: 1]

    public short? FindFirstMultiple(short divisor)
    {
        foreach (var item in this) if (item % divisor == 0) return item;
        return null;
    }

    public void ReplaceEvenWithZero()
    {
        var current = _head;
        for (var i = 1; current != null; i++)
        {
            if (i % 2 == 0) current.Data = 0;
            current = current.Next;
        }
    }

    public IMyList FilterGreater(short threshold)
    {
        var newList = new MyShortList();
        foreach (var item in this) if (item > threshold) newList.AddToEnd(item);
        return newList;
    }

    public void RemoveOddPositions()
    {
        for (var i = _count; i >= 1; i--)
        {
            if (i % 2 != 0) RemoveAt(i);
        }
    }

    // --- IEnumerable ---[cite: 1]

    public IEnumerator<short> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}