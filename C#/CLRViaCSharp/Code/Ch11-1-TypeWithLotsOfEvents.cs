/******************************************************************************
Module:  TypeWithLotsOfEvents.cs
Notices: Copyright (c) 2013 Jeffrey Richter
******************************************************************************/

using System;

///////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 定义此事件的EventArgs派生类型
/// </summary>
public class FooEventArgs : EventArgs { }

/// <summary>
/// 定义此事件的EventArgs派生类型
/// </summary>
public class BarEventArgs : EventArgs { }

///////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 有很多事件的类型
/// </summary>
internal class TypeWithLotsOfEvents
{

    // 定义引用集合的专用实例字段
    // 集合管理一组事件/委托对
    // 注意：事件集类型不是FCL的一部分，它是我自己的类型
    private readonly EventSet m_eventSet = new EventSet();

    // protected 属性允许派生类型访问集合
    protected EventSet EventSet
    {
        get
        {
            return m_eventSet;
        }
    }

    #region 支持Foo事件的代码（对其他事件重复此模式）
    // 定义Foo事件所需的成员
    // 2a. 构造一个静态只读对象来标识此事件
    protected static readonly EventKey s_fooEventKey = new EventKey();

    /// <summary>
    /// 2d. 定义事件 从集合中添加/删除委托的访问器方法
    /// </summary>
    public event EventHandler<FooEventArgs> Foo
    {
        add
        {
            m_eventSet.Add(s_fooEventKey, value);
        }
        remove
        {
            m_eventSet.Remove(s_fooEventKey, value);
        }
    }

    /// <summary>
    /// 2e. 为此事件定义受保护的虚 OnFoo 方法,触发事件
    /// </summary>
    protected virtual void OnFoo(FooEventArgs e)
    {
        m_eventSet.Raise(s_fooEventKey, this, e);
    }

    /// <summary>
    /// 2f. 定义将输入转换为此事件的方法
    /// </summary>
    public void SimulateFoo()
    {
        OnFoo(new FooEventArgs());
    }
    #endregion

    #region 支持Bar事件的代码
    // 3. 定义Bar事件所需的成员
    // 3a.构造一个静态只读对象来标识此事件.
    // 每个对象都有自己的哈希代码用于查找此
    // 事件抯 委托对象中的链接列表抯 收集.
    protected static readonly EventKey s_barEventKey = new EventKey();

    // 3d. 定义事件抯 从集合中添加/删除委托的访问器方法。
    public event EventHandler<BarEventArgs> Bar
    {
        add
        {
            m_eventSet.Add(s_barEventKey, value);
        }
        remove
        {
            m_eventSet.Remove(s_barEventKey, value);
        }
    }

    // 3e. 为此事件定义受保护的虚拟On方法.
    protected virtual void OnBar(BarEventArgs e)
    {
        m_eventSet.Raise(s_barEventKey, this, e);
    }

    // 3f. 定义将输入转换为此事件的方法。
    public void SimulateBar()
    {
        OnBar(new BarEventArgs());
    }
    #endregion
}

//////////////////////////////// End of File //////////////////////////////////
