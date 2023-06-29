using System;
using System.Diagnostics; 
using System.Threading;

class Program
{   // quicksort 
    //метод для обмена элементов массива
    static void Swap(ref int x, ref int y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //метод возвращающий индекс опорного элемента
    static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    //быстрая сортировка
    static int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        QuickSort(array, minIndex, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int[] QuickSort(int[] array)
    {
        return QuickSort(array, 0, array.Length - 1);
    }
    static void Record(int[] a)
    {
        Stopwatch time = new Stopwatch();
        time.Start();             
        Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort(a)));
        time.Stop();
        Console.WriteLine(time.Elapsed);

        Console.ReadLine();
    }

    //heapsort

    static void HeapSort(int[] arr)
    {
        int n = arr.Length;

        // Перегруппируем массив в кучу
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(arr, n, i);

        // Извлекаем элементы из кучи в упорядоченном порядке
        for (int i = n - 1; i >= 0; i--)
        {
            // Перемещаем текущий корень в конец массива
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;

            // Вызываем процедуру Heapify на уменьшенной куче
            Heapify(arr, i, 0);
        }
    }

    // Превращаем массив в кучу
    static void Heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;

        // Если левый дочерний элемент больше корня
        if (l < n && arr[l] > arr[largest])
            largest = l;

        // Если правый дочерний элемент больше самого большого элемента на данный момент
        if (r < n && arr[r] > arr[largest])
            largest = r;

        // Если самый большой элемент не корень
        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;

            // Рекурсивно превращаем поддерево в кучу
            Heapify(arr, n, largest);
        }
    }
    static void PrintArray(int[] arr)
    {
        foreach (int item in arr)
            Console.Write(item + " ");
        Console.WriteLine();
    }
    static void HeapRecord(int[] a)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        Console.Write("Колличество элементов: ");
               
        time.Stop();

        
        
        // Выполняем сортировку массива
        HeapSort(a);

        // Выводим отсортированный массив на экран
        Console.WriteLine("Отсортированный массив:");
       
        PrintArray(a);
        
        Console.WriteLine("Время работы алгоритма: ");
        Console.WriteLine(time.Elapsed);
      
        Console.ReadKey();

    }
    static void StandartSort(int []a)
    {
        Stopwatch time = new Stopwatch();
        time.Start();
        
        Array.Sort(a);
        Console.WriteLine("Время работы алгоритма: ");
        Console.WriteLine(time.Elapsed);
    }

    static void Main(string[] args)
    {
        Console.Write("Колличество элементов: ");
        var len = Convert.ToInt32(Console.ReadLine());
        var a = new int[len];
        for (var i = 0; i < a.Length; ++i)
        {
            Console.Write("a[{0}] = ", i);
            a[i] = Convert.ToInt32(Console.ReadLine());
        }
        int ans;
        do
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. QuickSort");
            Console.WriteLine("2. HeapSort");
            Console.WriteLine("3. Стандартная сортировка");
            Console.WriteLine("4. Exit");
            ans = Convert.ToInt32(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    {
                        Console.WriteLine("Быстрая сортировка (quicksort): ");
                        Record(a);

                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Быстрая сортировка (heapsort): ");
                        HeapRecord(a);
                    }
                    break;

                case 3:
                    {
                        Console.WriteLine("Стандартная сортировка: ");
                        StandartSort(a);

                    }
                    break;
            }
        } while (ans != 3);
    }
}