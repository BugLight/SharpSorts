using System;

namespace Sorts
{
    public static partial class Sort
    {
        /// <summary>
        /// Introspective sort
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <term>Complexity</term>
        /// <description>O(nlogn)</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <typeparam name="T">Elements type</typeparam>
        /// <param name="array">Array to sort</param>
        /// <param name="startIndex">Sorting start index</param>
        /// <param name="endIndex">Sorting end index (-1 means array end)</param>
        /// <param name="maxDepth">Max recursion depth (log(endIndex - startIndex) by default)</param>
        public static void IntroSort<T>(this T[] array, int startIndex = 0, int endIndex = -1, int maxDepth = -1) where T : IComparable
        {
            if (endIndex == -1)
                endIndex = array.Length;
            if (maxDepth == -1)
                maxDepth = (int)Math.Log(endIndex - startIndex, 2);
            if (endIndex - startIndex <= 1)
                return;
            T medianValue = SelectPivot(array, startIndex, endIndex);
            int p = startIndex;
            int q = endIndex - 1;
            while (p < q)
            {
                while (array[p].CompareTo(medianValue) < 0)
                    p++;
                while (array[q].CompareTo(medianValue) > 0)
                    q--;
                if (p < q)
                {
                    T tmp = array[p];
                    array[p] = array[q];
                    array[q] = tmp;
                }
            }
            maxDepth--;
            if (maxDepth > 0)
            {
                IntroSort(array, startIndex, p, maxDepth);
                IntroSort(array, p + 1, endIndex, maxDepth);
            }
            else
            {
                HeapSort(array, startIndex, p);
                HeapSort(array, p + 1, endIndex);
            }
        }

        private static T SelectPivot<T>(T[] array, int startIndex, int endIndex) where T : IComparable
        {
            int median = (endIndex + startIndex) / 2;
            if (array[startIndex].CompareTo(array[median]) > 0)
            {
                T tmp = array[startIndex];
                array[startIndex] = array[median];
                array[median] = tmp;
            }
            if (array[median].CompareTo(array[endIndex - 1]) > 0)
            {
                T tmp = array[median];
                array[median] = array[endIndex - 1];
                array[endIndex - 1] = tmp;
                if (array[startIndex].CompareTo(array[median]) > 0)
                {
                    tmp = array[startIndex];
                    array[startIndex] = array[median];
                    array[median] = tmp;
                }
            }
            return array[median];
        }
    }
}