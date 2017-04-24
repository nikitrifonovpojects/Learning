using System;

namespace SortArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var unsortedArray = ParseInput(input);
            //int[] sortedArray = SortArray(unsortedArray);
            int[] sortedArray = SortArrayAlternative(unsortedArray);
            string result = GetResultString(sortedArray);
            Console.WriteLine(result);
        }

        private static int[] ParseInput(string arr) //2,4,1
        {
            string[] splitArray = arr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] parsedSplitArray = new int[splitArray.Length];
            for (int i = 0; i < splitArray.Length; i++)
            {
                int parsedNumber = int.Parse(splitArray[i]);
                parsedSplitArray[i] = parsedNumber;
            }

            return parsedSplitArray;
        }

        private static string GetResultString(int[] sortedArray)
        {
            string finalString = string.Empty;

            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (i < sortedArray.Length - 1)
                {
                    finalString += sortedArray[i] + ",";
                }
                else
                {
                    finalString += sortedArray[i];
                }
            }

            return finalString;
        }

        //private static int[] SortArray(int[] unsortedArray)
        //{
        //    int[] sorted = new int[unsortedArray.Length];
        //    int max = int.MinValue;
        //    int currentMax = 0;
        //    int previousMax = int.MaxValue;
        //    bool[] usedIndex = new bool[unsortedArray.Length];
        //    int maxIndex = int.MinValue;
        //    for (int i = 0; i < unsortedArray.Length; i++)
        //    {
        //        for (int f = 0; f < unsortedArray.Length; f++)
        //        {
        //            currentMax = unsortedArray[f];
        //            if (currentMax > max && currentMax <= previousMax && !usedIndex[f])
        //            {
        //                max = currentMax;
        //                maxIndex = f;
        //            }
        //        }
        //        previousMax = max;
        //        sorted[unsortedArray.Length - 1 - i] = max;
        //        max = int.MinValue;
        //        usedIndex[maxIndex] = true;
        //    }

        //    return sorted;
        //}

        private static int[] SortArrayAlternative(int[] unsortedArray)
        {
            int max = int.MinValue;
            int previousMax = int.MaxValue;
            int currentMax = 0;
            int position = 0;
            int currentValuePosition = 0;
            for (int i = 0; i < unsortedArray.Length; i++)
            {
                for (int f = 0; f < unsortedArray.Length - i; f++)
                {
                    currentMax = unsortedArray[f];
                    if (currentMax > max)
                    {
                        max = currentMax;
                        currentValuePosition = f;
                    }
                }
                previousMax = max;
                position = unsortedArray.Length - 1 - i;
                SwapElementsInArray(unsortedArray, currentValuePosition, position);
                max = int.MinValue;
            }
            return unsortedArray;
        }
        public static int[] SwapElementsInArray(int[] theArray, int index1, int index2)
        {
            int tempHolder = theArray[index1];
            theArray[index1] = theArray[index2];
            theArray[index2] = tempHolder;
            return theArray;
        }
    }
}
