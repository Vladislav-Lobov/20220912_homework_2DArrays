// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите 
// программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int[,,] CreateRandomArray(int m, int n, int p)
{
    Random random = new Random();
    int[,,] array = new int[m, n, p];
    int value = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                while (IsRepeatValue(array, value))
                {
                    value = random.Next(10, 100);
                }
                array[i, j, k] = value;

            }
        }
    }

    return array;
}

bool IsRepeatValue(int[,,] array, int value)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == value)
                {
                    return true;
                }
            }
        }
    }
    return false;
}

void Print3DArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]} ({i},{j},{k}) ");
            }
            Console.Write("    ");
        }
        Console.WriteLine();
    }
}





Console.WriteLine("Введите m массива (m x n x p):");
bool isNumberM = int.TryParse(Console.ReadLine(), out int m);


Console.WriteLine("Введите n массива (m x n x p):");
bool isNumberN = int.TryParse(Console.ReadLine(), out int n);

Console.WriteLine("Введите p массива (m x n x p):");
bool isNumberP = int.TryParse(Console.ReadLine(), out int p);



if (!isNumberM || m < 1 || !isNumberN || n < 1 || !isNumberP || p < 1)
{
    Console.WriteLine("Некорректный ввод размера массива");
    return;
}

int[,,] newArray = new int[m, n, p];
newArray = CreateRandomArray(m, n, p);
Print3DArray(newArray);