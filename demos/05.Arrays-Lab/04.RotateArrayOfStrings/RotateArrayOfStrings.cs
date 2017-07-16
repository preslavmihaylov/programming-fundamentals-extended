using System;

class RotateArrayOfStrings
{
    static void Main()
    {
        string[] arr = Console.ReadLine().Split(' ');

        string elementToRotate = arr[arr.Length - 1];
        for (int cnt = 0; cnt < arr.Length; ++cnt)
        {
            string temp = arr[cnt];
            arr[cnt] = elementToRotate;
            elementToRotate = temp;
        }

        for (int cnt = 0; cnt < arr.Length; cnt++)
        {
            Console.Write(arr[cnt] + " ");
        }

        Console.WriteLine();
    }
}
