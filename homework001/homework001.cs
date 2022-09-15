//0001 Задача 54: Задайте двумерный массив. Напишите программу, которая 
//упорядочит по убыванию элементы каждой строки двумерного массива.

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

void Print2dArray(int[,] array)
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

void RangeRowArray(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int max = array[i];
        int maxIndex = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] > max)
            {
                max = array[j];
                maxIndex = j;
            };
        };
        int temp = array[i];
        array[i] = array[maxIndex];
        array[maxIndex] = temp;
    };
}

int[] FillTempArray(int[,] array, int i)
{
    int[] fillTempArray = new int[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        fillTempArray[j] = array[i, j];
    }
    return fillTempArray;
}

void FillResultArray(int[,] array, int[] tempArray, int i)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        array[i, j] = tempArray[j];
    }
}

void RangeResultArray(int[,] resultArray)
{
    int[] tempArray = new int[resultArray.GetLength(1)];
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        tempArray = FillTempArray(resultArray, i);
        RangeRowArray(tempArray);
        FillResultArray(resultArray, tempArray, i);
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
Print2dArray(newArray);
RangeResultArray(newArray);
Console.WriteLine("Отсортированный массив:");
Print2dArray(newArray);