using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.Sort
{
    /// <summary>
    /// 【实现逻辑】
    /// 1. 从第一个元素开始，该元素可以认为已经被排序
    /// 2. 取出下一个元素，在已经排序的元素序列中从后向前扫描
    /// 3. 如果该元素（已排序）大于新元素，将该元素移到下一位置
    /// 4. 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置
    /// 5. 将新元素插入到该位置后
    /// 6. 重复步骤2~5
    /// </summary>
    public class 插入排序 : MonoBehaviour
    {
        private List<int> numList = new List<int>() { 1, 5, 6, 5, 8, 2, 1, 3, 4, 9 };

        void Start()
        {
            Sort();

            string sortStr = "";
            for (int i = 0; i < numList.Count; i++)
            {
                sortStr += numList[i] + "、";
            }
            Debug.Log($"插入:{sortStr}");
        }

        private void Sort()
        {
            for (int i = 1; i < numList.Count; i++)
            {
                int temp = numList[i], j;
                for (j = i - 1; j >= 0; j--) // 遍历排在此数前面的数
                {
                    if (numList[j] > temp) // 如果前面的一个数大于此数,交换位置,直到前面数比此数小为止
                    {
                        numList[j + 1] = numList[j];
                    }
                    else
                    {
                        break;
                    }
                }
                numList[j + 1] = temp;
            }
        }
    }
}