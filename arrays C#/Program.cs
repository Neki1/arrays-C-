using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int k;
        while (true)
        {
            Console.WriteLine("Введите размерность массива:");
            if (int.TryParse(Console.ReadLine(), out k))
                break;
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
        }

        Console.Clear();

        Console.WriteLine("Данный массив: ");

        int[] arr = new int[k];
        Random random = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(1, 100);
            Console.WriteLine(arr[i]);
        }

        while (true)
        {
            Console.WriteLine("\n============================================================");
            Console.WriteLine("\t\tВыберите действие:");
            Console.WriteLine("============================================================");
            Console.WriteLine("1. Найти сумму всех элементов");
            Console.WriteLine("2. Найти максимальное значение");
            Console.WriteLine("3. Найти второе по величине значение");
            Console.WriteLine("4. Найти количество уникальных элементов");
            Console.WriteLine("5. Найти первый уникальный элемент");
            Console.WriteLine("6. Поменять местами минимальный и максимальный элементы");
            Console.WriteLine("7. Обменять местами первый и последний элементы");
            Console.WriteLine("8. Отсортировать массив по возрастанию");
            Console.WriteLine("9. Отсортировать массив по убыванию");
            Console.WriteLine("10. Переместить четные элементы в начало, нечетные — в конец");
            Console.WriteLine("0. Завершить работу");
            Console.WriteLine("============================================================\n");

            switch (Console.ReadLine())
            {
                case "1":
                    int sum = arr.Sum();
                    Console.WriteLine($"Сумма всех элементов: {sum}");
                    break;
                case "2":
                    int max = arr.Max();
                    Console.WriteLine($"Максимальное значение: {max}");
                    break;
                case "3":
                    int secondMax = arr.OrderByDescending(x => x).Skip(1).FirstOrDefault();
                    Console.WriteLine($"Второе по величине значение: {secondMax}");
                    break;
                case "4":
                    int uniqueCount = arr.Distinct().Count();
                    Console.WriteLine($"Количество уникальных элементов: {uniqueCount}");
                    break;
                case "5":
                    int firstUnique = arr.GroupBy(x => x).Where(g => g.Count() == 1).Select(g => g.Key).FirstOrDefault();
                    Console.WriteLine($"Первый уникальный элемент: {firstUnique}");
                    break;
                case "6":
                    int minIndex = Array.IndexOf(arr, arr.Min());
                    int maxIndex = Array.IndexOf(arr, arr.Max());
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[maxIndex];
                    arr[maxIndex] = temp;
                    Console.WriteLine("Массив после обмена минимального и максимального элементов:");
                    Console.WriteLine(string.Join(", ", arr));
                    break;
                case "7":
                    int first = arr[0];
                    arr[0] = arr[k - 1];
                    arr[k - 1] = first;
                    Console.WriteLine("Массив после обмена первого и последнего элементов:");
                    Console.WriteLine(string.Join(", ", arr));
                    break;
                case "8":
                    Array.Sort(arr);
                    Console.WriteLine("Отсортированный массив по возрастанию:");
                    Console.WriteLine(string.Join(", ", arr));
                    break;
                case "9":
                    Array.Sort(arr);
                    Array.Reverse(arr);
                    Console.WriteLine("Отсортированный массив по убыванию:");
                    Console.WriteLine(string.Join(", ", arr));
                    break;
                case "10":
                    int[] sortedArr = arr.OrderBy(x => x % 2 == 0 ? 0 : 1).ToArray();
                    Console.WriteLine("Массив после перемещения четных элементов в начало:");
                    Console.WriteLine(string.Join(", ", sortedArr));
                    break;
                case "0":
                    Console.WriteLine("Программа завершена.");
                    return;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }
}
    