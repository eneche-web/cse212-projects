using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        

        //plan:
        // 1. Create an array with spaces enough for the multiples requested
        // 2. Use a loop to calculate each multiples.
        // 3. Multiply the given number by the position number plus 1.
        // 4. Store each multiple in the arrey.
        // 5. Return the completed arrey.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return  multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. From where the last "amount" items begins, find the index.
        // 2. Get the last "amount" items from the list.
        // 3. From the beginning of the list get the remaining items.
        // 4. Clear the original list.
        // 5. To the beginning of the list, add the last items
        // 6. After the last items, add the remaining items.

        int splitIndex = data.Count - amount;

        List<int> endPart = data.GetRange(splitIndex, amount);

        List<int> beginningPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(endPart);

        data.AddRange(beginningPart);
    }
}
