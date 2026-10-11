using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    public class BubbleSortClass1
    {
        public BubbleSortClass1(int[] array)
        {
            Array = array;
        }

        public int[] Array { get; set; }

        public int[] Sort()
        {
            for(int i = 0; i < Array.Length; i++)
            {
                for(int j = 0; j < Array.Length - 1 - i; j++)
                {
                    if(Array[j] > Array[j + 1])
                    {
                        int helper = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = helper;
                    }
                }
            }
            return Array;
        }
    }
}
