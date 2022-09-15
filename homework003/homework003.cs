//0003 Задача 58: Задайте две матрицы. Напишите программу, 
//которая будет находить произведение двух матриц.

int[,] CreateRandomArray(int m, int n)
{
    Random random = new Random();
    int[,] array = new int[m, n];


    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = random.Next(0, 10);
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

int[,] MultiplyArray(int[,] arrA, int[,] arrB)
{
    int m = arrA.GetLength(0);
    int p = arrB.GetLength(1);
    int[,] resultArray = new int[m, p];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < p; j++)
        {
            resultArray[i, j] = ElementValue(arrA, arrB, i, j);
        }
    }
    return resultArray;
}


int ElementValue(int[,] arrA, int[,] arrB, int i, int j)
{
    int result = 0;
    int n = arrA.GetLength(1);
    for (int c = 0; c < n; c++)
    {
        result = result + arrA[i, c] * arrB[c, j];
    }
    return result;
}




Console.WriteLine("Введите размер m матрицы A(m x n):");
bool isNumberM = int.TryParse(Console.ReadLine(), out int m);


Console.WriteLine("Введите размер n матриц A(m x n) B(n x p):");
bool isNumberN = int.TryParse(Console.ReadLine(), out int n);

Console.WriteLine("Введите размер p матрицы B(n x p):");
bool isNumberP = int.TryParse(Console.ReadLine(), out int p);

if (!isNumberM || m < 1 || !isNumberN || n < 1 || !isNumberP || p < 1)
{
    Console.WriteLine("Некорректный ввод размера массива");
    return;
}

int[,] arrayA = new int[m, n];
arrayA = CreateRandomArray(m, n);
Print2DArray(arrayA);
Console.WriteLine();

int[,] arrayB = new int[n, p];
arrayB = CreateRandomArray(n, p);
Print2DArray(arrayB);
Console.WriteLine();

int[,] multiply = new int[m, p];
multiply = MultiplyArray(arrayA, arrayB);
Console.WriteLine("Результат умножения - матрица (m x p):");
Print2DArray(multiply);

