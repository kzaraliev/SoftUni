using System;
using System.Linq;
using System.Text;

class Program
{
    static int[] Exchange(int[] arr, int position)
    {
        if (position >= arr.Length || position < 0)
        {
            Console.WriteLine("Invalid index");
            return arr;
        }

        int[] tempArray = new int[arr.Length];
        int newPosition = 0;
        for (int i = position + 1; i < arr.Length; i++)
        {
            tempArray[newPosition] = arr[i];
            newPosition++;
        }
        for (int i = 0; i <= position; i++)
        {
            tempArray[newPosition] = arr[i];
            newPosition++;
        }
        return tempArray;
    }

    static void MaxEven(int[] arr)
    {
        int maxEvenValue = int.MinValue;
        int maxEvenIndex = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 0 && arr[i] >= maxEvenValue)
            {
                maxEvenIndex = i;
                maxEvenValue = arr[i];
            }
        if (maxEvenIndex == -1) Console.WriteLine("No matches");
        else Console.WriteLine(maxEvenIndex);
    }

    static void MaxOdd(int[] arr)
    {
        int maxOddValue = int.MinValue;
        int maxOddIndex = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 1 && arr[i] >= maxOddValue)
            {
                maxOddIndex = i;
                maxOddValue = arr[i];
            }
        if (maxOddIndex == -1) Console.WriteLine("No matches");
        else Console.WriteLine(maxOddIndex);
    }

    static void MinEven(int[] arr)
    {
        int minEvenValue = int.MaxValue;
        int minEvenIndex = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 0 && arr[i] <= minEvenValue)
            {
                minEvenIndex = i;
                minEvenValue = arr[i];
            }
        if (minEvenIndex == -1) Console.WriteLine("No matches");
        else Console.WriteLine(minEvenIndex);
    }

    static void MinOdd(int[] arr)
    {
        int minOddValue = int.MaxValue;
        int minOddIndex = -1;
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] % 2 == 1 && arr[i] <= minOddValue)
            {
                minOddIndex = i;
                minOddValue = arr[i];
            }
        if (minOddIndex == -1) Console.WriteLine("No matches");
        else Console.WriteLine(minOddIndex);
    }

    static void FirstEven(int[] arr, int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 0)
            {
                sb.Append(arr[i] + ", ");
                if (--count == 0) break;
            }
        }
        if (sb.Length > 1) sb.Remove(sb.Length - 2, 2);
        sb.Append("]");
        Console.WriteLine(sb.ToString());
    }

    static void FirstOdd(int[] arr, int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] % 2 == 1)
            {
                sb.Append(arr[i] + ", ");
                if (--count == 0) break;
            }
        }
        if (sb.Length > 1) sb.Remove(sb.Length - 2, 2);
        sb.Append("]");
        Console.WriteLine(sb.ToString());
    }

    static void LastEven(int[] arr, int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("]");
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] % 2 == 0)
            {
                sb.Insert(0, ", " + arr[i]);
                if (--count == 0) break;
            }
        }
        if (sb.Length > 1) sb.Remove(0, 2);
        sb.Insert(0, "[");
        Console.WriteLine(sb.ToString());
    }

    static void LastOdd(int[] arr, int count)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("]");
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i] % 2 == 1)
            {
                sb.Insert(0, ", " + arr[i]);
                if (--count == 0) break;
            }
        }
        if (sb.Length > 1) sb.Remove(0, 2);
        sb.Insert(0, "[");
        Console.WriteLine(sb.ToString());
    }

    static void Main()
    {
        int[] mainArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] command = input.Split().ToArray();
            switch (command[0])
            {
                case "exchange":
                    mainArray = Exchange(mainArray, int.Parse(command[1]));
                    break;
                case "max":
                    if (command[1] == "even") MaxEven(mainArray);
                    else if (command[1] == "odd") MaxOdd(mainArray);
                    break;
                case "min":
                    if (command[1] == "even") MinEven(mainArray);
                    else if (command[1] == "odd") MinOdd(mainArray);
                    break;
                case "first":
                    if ((int.Parse(command[1]) > mainArray.Length)) Console.WriteLine("Invalid count");
                    else if (command[2] == "even") FirstEven(mainArray, int.Parse(command[1]));
                    else if (command[2] == "odd") FirstOdd(mainArray, int.Parse(command[1]));
                    break;
                case "last":
                    if ((int.Parse(command[1]) > mainArray.Length)) Console.WriteLine("Invalid count");
                    else if (command[2] == "even") LastEven(mainArray, int.Parse(command[1]));
                    else if (command[2] == "odd") LastOdd(mainArray, int.Parse(command[1]));
                    break;
            }
        }
        Console.Write("[");
        for (int i = 0; i < mainArray.Length - 1; i++)
        {
            Console.Write(mainArray[i] + ", ");
        }
        Console.WriteLine(mainArray[mainArray.Length - 1] + (string)"]");
    }
}