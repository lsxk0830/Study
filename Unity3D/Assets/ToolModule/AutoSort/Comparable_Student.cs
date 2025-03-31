using System;

namespace Unity3D.Demo.AutoSort
{
    public class Comparable_Student : IComparable
    {
        public string UserId;
        public string UserName;
        public int Socre;

        public int CompareTo(object obj)//实现接口
        {
            Comparable_Student stu = (Comparable_Student)obj;
            return this.Socre - stu.Socre;
        }
    }
}