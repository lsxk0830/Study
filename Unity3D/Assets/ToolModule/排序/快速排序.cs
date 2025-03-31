using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.Sort
{
    /// <summary>
    /// 【实现逻辑】
    /// 1. 选择基准元素： 从数组中选择一个基准元素，通常是数组的第一个或最后一个元素。
    /// 2. 分割数组： 将数组中小于基准元素的元素移到基准元素的左边，大于基准元素的元素移到基准元素的右边。这个过程称为分割。
    /// 3. 递归排序： 对基准元素左边和右边的子数组进行递归地快速排序。
    /// 4. 合并： 已经有序
    /// </summary>
    public class 快速排序 : MonoBehaviour
    {
        private List<int> list = new List<int>() { 10, 3, 55, 8, 22, 71, 18, 23 };

        void Start()
        {
            Sort(list, 0, list.Count - 1);

            string sortStr = "";
            for (int i = 0; i < list.Count; i++)
            {
                sortStr += list[i] + "、";
            }
            Debug.Log($"快排:{sortStr}");
        }

        public void Sort(List<int> list, int Start, int End)
        {
            if (End - Start < 1) return;

            int mid = list[Start]; // 选择基准元素
            int s = Start; int e = End;
            while (s < e) // s=e 结束循环
            {
                while (s < e && mid <= list[e])
                    e--;
                list[s] = list[e]; // 小于基准元素的元素移到基准元素的左边

                while (s < e && list[s] < mid)
                    s++;
                list[e] = list[s]; // 大于基准元素的元素移到基准元素的右边
            }
            list[s] = mid; // s=e时放入基准元素

            // 递归排序
            Sort(list, Start, s - 1);
            Sort(list, s + 1, End);
        }
    }
}