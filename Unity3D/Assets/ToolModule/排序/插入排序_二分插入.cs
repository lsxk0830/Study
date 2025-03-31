using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.Sort
{
    /// <summary>
    /// 【实现逻辑】
    /// 1. 从第一个元素开始，该元素可以认为已经被排序
    /// 2. 取出下一个元素，在已经排序的元素序列中二分查找到第一个比它大的数的位置
    /// 3. 将新元素插入到该位置后
    /// 4. 重复上述两步
    /// </summary>
    public class 插入排序_二分插入 : MonoBehaviour
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
            Debug.Log($"插入排序_二分插入:{sortStr}");
        }

        private void Sort()
        {
            int key, left, right, middle;
            for (int i = 1; i < numList.Count; i++)
            {
                key = numList[i];
                left = 0;
                right = i - 1;
                while (left <= right)
                {
                    middle = (left + right) / 2;
                    if (numList[middle] > key)
                        right = middle - 1;
                    else
                        left = middle + 1;
                }

                for (int j = i - 1; j >= left; j--)
                {
                    numList[j + 1] = numList[j];
                }

                numList[left] = key;
            }
        }
    }
}