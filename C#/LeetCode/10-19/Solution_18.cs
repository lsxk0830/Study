namespace LeetCode
{
    #region 解决思路
    /*
     * 
     */
    #endregion

    /// <summary>
    /// 四数之和
    /// https://leetcode.cn/problems/4sum/description/
    /// </summary>
    internal class Solution_18 : IExcute
    {
        public void Excute()
        {
            int[] nums = { 1, 0, -1, 0, -2, 2 };
            int target = 0;
            IList<IList<int>> result = FourSum(nums, target);
            foreach (IList<int> list in result)
            {
                Console.WriteLine($"四数之和：{string.Join(",", list)}");
            }
        }

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            return null;
        }
    }
}