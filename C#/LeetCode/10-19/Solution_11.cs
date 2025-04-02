namespace LeetCode
{
    #region 解决思路
    /*
     * 左右指针
     */
    #endregion

    /// <summary>
    /// 盛最多水的容器
    /// https://leetcode.cn/problems/container-with-most-water/description/
    /// </summary>
    internal class Solution_11: IExcute
    {
        public void Excute()
        {
            int[] height = [1, 8, 6, 2, 5, 4, 8, 3, 7];
            int y = MaxArea(height);
            Console.WriteLine($"盛最多水的容器：{y}");
        }

        public int MaxArea(int[] height)
        {
            int l = 0, r = height.Length - 1;
            int ans = 0;
            while (l < r)
            {
                int area = Math.Min(height[l], height[r]) * (r - l);
                ans = Math.Max(ans, area);
                if (height[l] <= height[r])
                    ++l;
                else
                    --r;
            }
            return ans;
        }
    }
}