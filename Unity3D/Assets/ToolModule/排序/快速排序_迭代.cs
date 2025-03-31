using System.Collections.Generic;
using UnityEngine;

namespace Unity3D.Demo.Sort
{
    /// <summary>
    /// 【场景分析】
    /// 递归是一种使用相同的方法，通过解决问题的子集以达到解决整个问题的方法，
    /// 是一种使用有限代码解决“无限”计算的方法。在C/C++语言中递归表现在函数对自身的直接/间接的调用上，
    /// 在实现上，递归依赖于语言的运行时调用堆栈，使用堆栈来保存每一次递归调用返回时所需要的条件。
    /// 递归通常具有简洁的编码和清晰的思路，但这种简洁是有代价的。一方面，是函数调用的负担；另一方面，是堆栈占用的负担（堆栈的大小是有限的）。
    /// 【改进思路】
    /// 递归转化为迭代。迭代的思想主要在于，在同一栈帧中不断使用现有数据计算出新的数据，然后使用新的数据来替换原有数据。
    /// </summary>
    public class 快速排序_迭代 : MonoBehaviour
    {
        private List<int> list = new List<int>() { 10, 3, 55, 8, 22, 71, 18, 23 };

        void Start()
        {
            Sort(list);

            string sortStr = "";
            for (int i = 0; i < list.Count; i++)
            {
                sortStr += list[i] + "、";
            }
            Debug.Log($"快排_迭代:{sortStr}");
        }

        public void Sort(List<int> list)
        {
            Stack<(int Start, int End)> stack = new Stack<(int, int)>();
            stack.Push((0, list.Count - 1));

            while (stack.Count > 0)
            {
                var (Start, End) = stack.Pop(); // 移除并返回栈顶的元素
                if (End - Start < 1) continue;

                int mid = list[Start]; // 选择基准元素
                int s = Start, e = End;

                while (s < e)
                {
                    while (s < e && mid <= list[e])
                        e--;
                    list[s] = list[e];

                    while (s < e && list[s] < mid)
                        s++;
                    list[e] = list[s];
                }
                list[s] = mid; // s=e时放入基准元素

                // 将新的区间推入栈中
                stack.Push((Start, s - 1)); // 左区间
                stack.Push((s + 1, End)); // 右区间
            }
        }
    }
}