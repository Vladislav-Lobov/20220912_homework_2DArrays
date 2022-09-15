//0002 Задача 56: Задайте прямоугольный двумерный массив. Напишите 
//программу, которая будет находить строку с наименьшей суммой элементов.

int[,] CreateRandomArray(int m, int n)
{
    Random random = new Random();
    int[,] array = new int[m, n];


    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(-9, 10);
        }
    }

    return array;
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[] SumsArray(int[,] array)
{
    int[] sumsOfRow = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumsOfRow[i] = sumsOfRow[i] + array[i, j];
        }
    }
    return sumsOfRow;
}

int MinSumRow(int[,] array)
{
    int[] sumsOfRow = new int[array.GetLength(0)];
    sumsOfRow = SumsArray(array);
    int min = sumsOfRow[0];
    int minIndex = 0;
    for (int i = 0; i < sumsOfRow.Length; i++)
    {
        if (min > sumsOfRow[i])
        {
            min = sumsOfRow[i];
            minIndex = i;

        }
    }
    return minIndex;
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}


Console.WriteLine("Введите размер массива m:");
bool isNumberM = int.TryParse(Console.ReadLine(), out int m);


Console.WriteLine("Введите размер массива n:");
bool isNumberN = int.TryParse(Console.ReadLine(), out int n);

if (!isNumberM || m < 1 || !isNumberN || n < 1)
{
    Console.WriteLine("Некорректный ввод размера массива");
    return;
}

int[,] newArray = new int[m, n];
newArray = CreateRandomArray(m, n);
Print2DArray(newArray);

int[] sumsArr = new int[m];
sumsArr = SumsArray(newArray);
Console.WriteLine("Суммы строк:");
PrintArray(sumsArr);
Console.WriteLine();
Console.WriteLine($"{MinSumRow(newArray) + 1} строка с наименьшей суммой чисел");
Console.WriteLine($"индекс строки с наименьшей суммой чисел: {MinSumRow(newArray)}");
