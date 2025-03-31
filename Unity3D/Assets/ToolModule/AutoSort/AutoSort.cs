using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    /// <summary>
    /// IComparable<T> 用于在类内部定义对象的默认比较行为,适用于对象的内部排序逻辑
    /// IComparer<T> 用于提供外部的比较逻辑, 使得可以在不修改对象本身的情况下, 对对象进行不同的排序和比较。
    /// </summary>
    public class AutoSort : MonoBehaviour
    {
        List<Comparer_UserInfo> users = new List<Comparer_UserInfo>()
        {
        new Comparer_UserInfo(){UserId ="001",UserName = "AA",State = 1},
        new Comparer_UserInfo(){UserId ="002",UserName = "BB",State = 3},
        new Comparer_UserInfo(){UserId ="003",UserName = "CC",State = 2},
        new Comparer_UserInfo(){UserId ="004",UserName = "DD",State = 3},
        new Comparer_UserInfo(){UserId ="005",UserName = "EE",State = 1},
        new Comparer_UserInfo(){UserId ="006",UserName = "FF",State = 2},
        new Comparer_UserInfo(){UserId ="007",UserName = "GG",State = 4},
        new Comparer_UserInfo(){UserId ="008",UserName = "HH",State = 2},
        new Comparer_UserInfo(){UserId ="009",UserName = "II",State = 3},
        new Comparer_UserInfo(){UserId ="000",UserName = "JJ",State = 1},
        };
        List<Comparable_Student> stuList = new List<Comparable_Student>
        {
            new Comparable_Student() { Socre = 98, UserName = "Bob" },
            new Comparable_Student() { Socre = 56, UserName = "Alice" },
            new Comparable_Student() { Socre = 100, UserName = "Jerry" }
        };

        private void Start()
        {
            #region IComparable

            Debug.LogError("IComparable排序前:");
            foreach (Comparable_Student mystu in stuList)
            {
                Debug.Log($"状态值：{mystu.Socre},用户名：{mystu.UserName}");
            }

            stuList.Sort();
            Debug.LogError("IComparable排序后:");

            foreach (Comparable_Student mystu in stuList)
            {
                Debug.Log($"状态值：{mystu.Socre},用户名：{mystu.UserName}");
            }

            #endregion
            Debug.LogWarning("---------------------");
            #region IComparer

            Debug.LogError("IComparer排序前:");
            foreach (var item in users)
            {
                Debug.Log($"状态值：{item.State},用户名：{item.UserName}");
            }

            users.Sort(new UserSortUtility());
            Debug.LogError("IComparer排序后:");

            foreach (var item in users)
            {
                Debug.Log($"状态值：{item.State},用户名：{item.UserName}");
            }

            #endregion
        }
    }
}