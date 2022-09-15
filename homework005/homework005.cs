//0005 Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

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

void GetTopRow(int[,] array, int left, int right, int top, ref int index)
{
    for (int i = left; i <= right; i++)
    {
        array[top, i] = index++;
    }
}
void GetRightColumn(int[,] array, int right, int top, int bottom, ref int index)
{
    for (int i = top; i <= bottom; i++)
    {
        array[i, right] = index++;
    }
}
void GetBottomRow(int[,] array, int left, int right, int bottom, ref int index)
{
    for (int i = right; i >= left; i--)
    {
        array[bottom, i] = index++;
    }
}
void GetLeftColumn(int[,] array, int left, int top, int bottom, ref int index)
{
    for (int i = bottom; i >= top; i--)
    {
        array[i, left] = index++;
    }
}



void GetSpiralArray(int[,] array)
{
    int top = 0, bottom = array.GetLength(0) - 1;
    int left = 0, right = array.GetLength(1) - 1;
    int index = 0;

    while (true)
    {
        if (left > right) { break; }
        GetTopRow(array, left, right, top, ref index);            // печатаем верхнюю строку
        top++;
        if (top > bottom) { break; }
        GetRightColumn(array, right, top, bottom, ref index);    // печатаем правый столбец
        right--;
        if (left > right) { break; }
        GetBottomRow(array, left, right, bottom, ref index);     // печатаем нижнюю строку
        bottom--;
        if (top > bottom) { break; }
        GetLeftColumn(array, left, top, bottom, ref index);     // печатаем левый столбец
        left++;
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
GetSpiralArray(newArray);
Print2dArray(newArray);

