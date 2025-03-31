using UnityEngine;

namespace Unity3D.Demo.Sort
{
	/// <summary>
	/// 【场景分析】
	/// 如果有100个数的数组，仅前面10个无序，后面90个都已排好序且都大于前面10个数字，
	/// 那么在第一趟遍历后，最后发生交换的位置必定小于10，且这个位置之后的数据必定已经有序了。
	/// 【改进思路】
	/// 记录某次遍历时最后发生数据交换的位置pos，这个位置之后的数据显然已经有序了。
	/// 因此通过记录最后发生数据交换的位置就可以确定下次循环的范围了。
	/// 由于pos位置之后的记录均已交换到位,故在进行下一趟排序时只要扫描到pos位置即可。
	/// </summary>
	public class 冒泡排序_记录交换位置 : MonoBehaviour
	{
		private int[] numList = { 23, 5, 7, 1, 9, 15, 18, 3, 4, 6, 11, 12, 13, 14, 16, 17, 19, 20 }; // 示例数组
		private int count = 0;

		void Start()
		{
			Sort();

			string sortStr = "";
			for (int i = 0; i < numList.Length; i++)
			{
				sortStr += numList[i] + "、";
			}
			Debug.Log($"改进B次数:{count}。{sortStr}");
		}

		void Sort()
		{
			int lastExchangeIndex = numList.Length - 1; // 初始化最后交换的位置为数组末尾

			while (lastExchangeIndex > 0)
			{
				int newLastExchangeIndex = 0; // 每次循环开始前，重置最后交换的位置

				for (int i = 0; i < lastExchangeIndex; i++)
				{
					if (numList[i] > numList[i + 1])
					{
						// 交换元素
						int temp = numList[i];
						numList[i] = numList[i + 1];
						numList[i + 1] = temp;

						// 更新最后交换的位置
						newLastExchangeIndex = i;
					}
					count++;
				}

				// 更新扫描范围
				lastExchangeIndex = newLastExchangeIndex;
			}
		}
	}
}