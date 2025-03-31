using System.Collections.Generic;

namespace Unity3D.Demo.AutoSort
{
    public class UserSortUtility : IComparer<Comparer_UserInfo>
    {
        // 区别于 CompareTo() 单参数，此处为双元素
        public int Compare(Comparer_UserInfo UserA, Comparer_UserInfo UserB)
        {
            if (UserA.State != UserB.State)
            {
                return UserA.State.CompareTo(UserB.State);
            }
            else if (UserA.UserName != UserB.UserName)
            {
                return UserA.UserName.CompareTo(UserB.UserName);
            }
            else if (UserA.UserId != UserB.UserId)
            {
                return UserA.UserId.CompareTo(UserB.UserId);
            }
            else return 0;
        }
    }
}