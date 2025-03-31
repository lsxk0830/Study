using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.Sort
{
    /// <summary>
    /// 【实现逻辑】
    /// 1. 第一轮从下标为 1 到下标为 n-1 的元素中选取最小值，若小于第一个数，则交换
    /// 2. 第二轮从下标为 2 到下标为 n-1 的元素中选取最小值，若小于第二个数，则交换
    /// 3. 依次类推下去…
    /// </summary>
    public class 选择排序 : MonoBehaviour
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
            Debug.Log($"默认次数：{sortStr}");
        }

        private void Sort()
        {
            for (int i = 0; i < numList.Count - 1; i++)
            {
                int min = i;
                //每轮需要比较的次数n-i
                for (int j = i + 1; j < numList.Count; j++)
                {
                    if (numList[min] > numList[j]) // 当此数大于后一个数
                    {
                        // 记录目前能找到的最小值元素的下标
                        min = j;
                    }
                }
                int temp = numList[i];
                numList[i] = numList[min];
                numList[min] = temp;
            }
        }
    }
}