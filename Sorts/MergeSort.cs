using System;

namespace Sorts
{
    public static partial class Sort
    {
        /// <summary>
        /// Merge sort
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
        public static void MergeSort<T>(this T[] array, int startIndex = 0, int endIndex = -1) where T : IComparable
        {
            if (endIndex == -1)
                endIndex = array.Length;
            // Allocate additional memory only once
            int copyLength = (endIndex - startIndex) >> 1;
            T[] left = new T[copyLength];
            T[] right = new T[copyLength];
            _MergeSort(array, left, right, startIndex, endIndex);
        }

        private static void _MergeSort<T>(T[] array, T[] left, T[] right, int start, int end) where T : IComparable
        {
            if (end - start == 1)
                return;
            int middle = (start + end) >> 1;
            _MergeSort(array, left, right, start, middle);
            _MergeSort(array, left, right, middle, end);
            Merge(array, left, right, start, middle, end);
        }

        private static void Merge<T>(T[] array, T[] left, T[] right, int start, int edge, int end) where T : IComparable
        {
            int leftLength = edge - start;
            int rightLength = end - edge;
            for (int i = start, j = 0; i < edge; i++, j++)
                left[j] = array[i];
            for (int i = edge, j = 0; i < end; i++, j++)
                right[j] = array[i];
            for (int i = start, p = 0, q = 0; i < end; i++)
            {
                if (q >= rightLength || p < leftLength && left[p].CompareTo(right[q]) <= 0)
                {
                    array[i] = left[p];
                    p++;
                }
                else
                {
                    array[i] = right[q];
                    q++;
                }
            }
        }
    }
}
