using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IComparableSortTest : MonoBehaviour
{
    void Start()
    {
        List<Student> stuList = new List<Student>();
        stuList.Add(new Student() { Socre = 98, UserName = "Bob" });
        stuList.Add(new Student() { Socre = 56, UserName = "Alice" });
        stuList.Add(new Student() { Socre = 100, UserName = "Jerry" });

        Debug.Log("排序前：");
        foreach (Student mystu in stuList)
        {
            Debug.Log($"状态值：{mystu.Socre},用户名：{mystu.UserName}");
        }
        stuList.Sort();
        Debug.Log("\n排序后:");
        foreach (Student mystu in stuList)
        {
            Debug.Log($"状态值：{mystu.Socre},用户名：{mystu.UserName}");
        }
    }
}

public class Student : IComparable
{
    public string UserId;
    public string UserName;
    public int Socre;

    public int CompareTo(object obj)//实现接口
    {
        Student stu = (Student)obj;
        return this.Socre - stu.Socre;
    }
}