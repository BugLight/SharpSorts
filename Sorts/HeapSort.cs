using System;

namespace Sorts
{
    public static partial class Sort
    {
        /// <summary>
        /// Heap sort (pyramid)
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
        public static void HeapSort<T>(this T[] array, int startIndex = 0, int endIndex = -1) where T : IComparable
        {
            if (endIndex == -1)
                endIndex = array.Length;
            BuildHeap(array, startIndex, endIndex);
            for (int i = endIndex - 1; i > startIndex; i--)
            {
                T tmp = array[i];
                array[i] = array[0];
                array[0] = tmp;
                Heapify(array, startIndex, i);
            }
        }

        private static void Heapify<T>(T[] array, int startIndex, int endIndex) where T : IComparable
        {
            int left = (startIndex << 1) + 1;
            int right = left + 1;
            int max = startIndex;
            if (left < endIndex && array[left].CompareTo(array[max]) > 0)
                max = left;
            if (right < endIndex && array[right].CompareTo(array[max]) > 0)
                max = right;
            if (max != startIndex)
            {
                T tmp = array[max];
                array[max] = array[startIndex];
                array[startIndex] = tmp;
                Heapify(array, max, endIndex);
            }
        }

        private static void BuildHeap<T>(T[] array, int startIndex, int endIndex) where T : IComparable
        {
            for (int i = (endIndex + startIndex) >> 1; i >= startIndex; i--)
                Heapify(array, i, endIndex);
        }
    }
}