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

        //Plan:
        // 1. I'll determine the required size of the array based on the 'length' input parameter.
        // 2. I'll create a new array of doubles with the specified size.
        // 3. I'll iterate from 1 up to 'length' (inclusive) to fill the array.
        // 4. In each iteration, I'll calculate the multiple by multiplying 'number' with the current index (i.e i * number).
        // 5. I'll assign the calculated multiple to the corresponding index in the array.
        // 6. Finally, I'll return the populated array.

        // Implementation:

        // 1. Initialize the result array with the specified length.
        double[] result = new double[length];

        // 2. Iterate from 1 up to 'length' (inclusive).
        for (int i = 1; i <= length; i++)
        {
            // 3. Calculate the multiple and store it in the array
            // Since the loop index 'i' starts at 1, we use 'i-1' for the array index.
            result[i - 1] = number * i;
        }

        // 4. Return the populated array.
        return result;
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
        // 1. I'll need to identify the elements that need to be moved to the front. These are the last 'amount' elements of the list.
        // 2. I'll then extract these 'amount' elements using 'GetRange' method. The starting index for this range will be 'data.Count - amount', and the count will be 'amount'.
        // 3. After extracting the elements, I'll remove them from the original list using 'RemoveRange'. The arguments for 'RemoveRange' will be the same as for the 'GetRange': starting index 'data.Count - amount' and count 'amount'.
        // 4. Finally, I'll insert the extracted elements at the beginning of the list using 'InsertRange'.

        // Implementation:

        // 1. Handle the case where the list is empty or the amount is zero. 
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // No rotation needed
        }

        // 2. Calculate the starting index for the elements to be moved.
        int startIndex = data.Count - amount;

        // 3. Extract the elements that need to be moved to the front.
        List<int> elementsToMove = data.GetRange(startIndex, amount);
        // 4. Remove the elements from the original list.
        data.RemoveRange(startIndex, amount);
        // 5. Insert the extracted elements at the beginning of the list.
        data.InsertRange(0, elementsToMove);
    }
}
