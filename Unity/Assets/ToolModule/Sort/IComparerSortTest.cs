using System.Collections.Generic;
using UnityEngine;

namespace SortTest
{
    public class UserInfo
    {
        public string UserId;
        public string UserName;
        public int State;
    }

    public class IComparerSortTest : MonoBehaviour
    {
        List<UserInfo> users = new List<UserInfo>()
        {
         new UserInfo(){UserId ="001",UserName = "AA",State = 1},
         new UserInfo(){UserId ="002",UserName = "BB",State = 3},
         new UserInfo(){UserId ="003",UserName = "CC",State = 2},
         new UserInfo(){UserId ="004",UserName = "DD",State = 3},
         new UserInfo(){UserId ="005",UserName = "EE",State = 1},
         new UserInfo(){UserId ="006",UserName = "FF",State = 2},
         new UserInfo(){UserId ="007",UserName = "GG",State = 4},
         new UserInfo(){UserId ="008",UserName = "HH",State = 2},
         new UserInfo(){UserId ="009",UserName = "II",State = 3},
         new UserInfo(){UserId ="000",UserName = "JJ",State = 1},
        };

        void Start()
        {
            users.Sort(new UserSortUtility());

            foreach (var item in users)
            {
                Debug.Log($"状态值：{item.State},用户名：{item.UserName}");
            }
        }
    }

    public class UserSortUtility : IComparer<UserInfo>
    {
        // 区别于 CompareTo() 单参数，此处为双元素
        public int Compare(UserInfo UserA, UserInfo UserB)
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