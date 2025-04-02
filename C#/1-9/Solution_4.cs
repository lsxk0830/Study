namespace EverydayLeetCode
{
# region 解决思路
    /*
     * 
     */
#endregion
    /// <summary>
    /// 寻找两个正序数组的中位数
    /// https://leetcode.cn/problems/median-of-two-sorted-arrays/description/
    /// </summary>
    internal class Solution_4 : IExcute
    {
        public void Excute()
        {
            int[] nums1 = new int[] { 1, 3 };
            int[] nums2 = new int[] { 2 };
            double d = FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"中位数：{d}");
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int len = nums1.Length + nums2.Length;
            bool isEven = len % 2 == 0;
            int resultLen = len / 2 + 1;
            int[] sortedArray = new int[resultLen];
            // p:nums1的指针, q:nums2的指针
            int p = 0, q = 0, idx = 0;
            while (idx < sortedArray.Length)
            {
                if (p < nums1.Length && q < nums2.Length)
                {
                    sortedArray[idx] = nums1[p] <= nums2[q] ? nums1[p++] : nums2[q++];
                }
                else if (q >= nums2.Length)
                {
                    sortedArray[idx] = nums1[p++];
                }
                else
                {
                    sortedArray[idx] = nums2[q++];
                }
                idx++;
            }
            return isEven ?
                ((double)(sortedArray[resultLen - 1] + sortedArray[resultLen - 2]) / 2)
                : sortedArray[resultLen - 1];
        }
    }
}