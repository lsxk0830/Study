using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
	/// <summary>
	/// 【实现逻辑】
	/// 依次比较相邻的两个元素，进行交换
	/// 循环冒泡，次数为数据个数-1
	/// </summary>
	public class 冒泡排序 : MonoBehaviour
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
			Debug.Log($"默认次数：{count}。{sortStr}");
		}

		private void Sort()
		{
			for (int i = 0; i < numList.Count - 1; i++)
			{
				for (int j = 0; j < numList.Count - 1 - i; j++)
				{
					if (numList[j] < numList[j + 1]) //相邻的两个数，前面的值比后面的大，则两两交换值
					{
						int temp = numList[j];
						numList[j] = numList[j + 1];
						numList[j + 1] = temp;
					}
					count++;
				}
			}
		}
	}
}