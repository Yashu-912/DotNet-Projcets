
using System.Collections.Generic;

internal class InsertionSort {

    internal static void Sort<T>(IList<T> arr_list, Func<T, T, bool> compare) {

        int i, j;
        T key;

        for (i = 1; i < arr_list.Count; i++) {
            
            key = arr_list[i];
            j = i - 1;
 
            while (j >= 0 && compare(arr_list[j], key)) {

                arr_list[j + 1] = arr_list[j];
                j = j - 1;
            }

            arr_list[j + 1] = key;
        }
    }
}