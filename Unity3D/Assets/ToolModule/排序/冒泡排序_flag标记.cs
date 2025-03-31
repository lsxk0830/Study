using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
	/// <summary>
	/// 【场景分析】
	///  在某次遍历中如果没有数据交换，说明整个数组已经有序。
	///  若初始序列就是排序好的，如果用基础的冒泡排序方法，仍然还要比较O(N^2)次，但无交换次数。
	///  【改进思路】
	///  通过设置标志位来记录此次遍历有无数据交换，进而可以判断是否要继续循环，设置一个flag标记，
	///  当在一趟序列中没有发生交换，则该序列已排序好，但优化后排序的时间复杂度没有发生量级的改变
	/// </summary>
	public class 冒泡排序_flag标记 : MonoBehaviour
	{
		private List<int> numList = new List<int>() { 9, 7, 8, 6, 5, 4, 3, 2, 1, 0 };
		private int count = 0;

		void Start()
		{
			Sort();

			string sortStr = "";
			for (int i = 0; i < numList.Count; i++)
			{
				sortStr += numList[i] + "、";
			}
			Debug.Log($"改进A次数:{count}。{sortStr}");
		}

		private void Sort()
		{
			for (int i = 0; i < numList.Count - 1; i++)
			{
				bool exchange = true;  //冒泡的改进，若在一趟中没有发生逆序，则该序列已有序

				for (int j = 0; j < numList.Count - 1 - i; j++)
				{
					if (numList[j] < numList[j + 1])
					{
						int temp = numList[j];
						numList[j] = numList[j + 1];
						numList[j + 1] = temp;

						exchange = false;
					}
					count++;
				}
				if (exchange)
				{
					return;
				}
			}
		}
	}
}