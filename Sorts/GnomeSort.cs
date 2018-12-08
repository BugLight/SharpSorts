using System;

namespace Sorts
{
    public static partial class Sort
    {
        /// <summary>
        /// Gnome sort
        /// https://dickgrune.com/Programs/gnomesort.html
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <term>Best case complexity</term>
        /// <description>O(n)</description>
        /// </item>
        /// <item>
        /// <term>Average case complexity</term>
        /// <description>O(n^2)</description>
        /// </item>
        /// <item>
        /// <term>Worst case complexity</term>
        /// <description>O(n^2)</description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <typeparam name="T">Elements type</typeparam>
        /// <param name="array">Array to sort</param>
        public static void GnomeSort<T>(this T[] array) where T : IComparable
        {
            int i = 1;
            while (i != array.Length)
            {
                if (i == 0 || array[i - 1].CompareTo(array[i]) <= 0)
                {
                    i++;
                }
                else
                {
                    T tmp = array[i];
                    array[i] = array[i - 1];
                    array[i - 1] = tmp;
                    i--;
                }
            }
        }
    }
}