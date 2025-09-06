using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // --------------------------------------------------------------
        // PLAN:
        // 1. Create an array with size = length.
        // 2. Loop through from index 0 up to length - 1.
        // 3. At each index i, store number * (i + 1).
        // 4. After the loop, return the array.
        // --------------------------------------------------------------

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// Example: List<int>{1,2,3,4,5,6,7,8,9}, amount=3 → {7,8,9,1,2,3,4,5,6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    /// 
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // --------------------------------------------------------------
        // PLAN:
        // 1. Identify the last "amount" elements that should move to the front.
        //    Use data.GetRange(data.Count - amount, amount).
        // 2. Identify the first part of the list (everything before that).
        //    Use data.GetRange(0, data.Count - amount).
        // 3. Clear the original list.
        // 4. Add the last part first, then add the first part.
        //    This rebuilds the list in rotated order.
        // --------------------------------------------------------------

        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}
