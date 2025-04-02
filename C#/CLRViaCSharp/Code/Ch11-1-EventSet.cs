using System;
using System.Collections.Generic;
using System.Threading;

/// <summary>
/// 为了在使用EventSet时提供更多的类型安全性和代码可维护性
/// </summary>
public sealed class EventKey : Object
{
}

/// <summary>
/// 设置事件，字典<EventKey，Delegate>
/// </summary>
public sealed class EventSet
{
    private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

    /// <summary>
    /// 如果不存在EventKey->Delegate映射，则添加该映射，或将委托与现有EventKey组合
    /// </summary>
    public void Add(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        Delegate d;
        m_events.TryGetValue(eventKey, out d);
        m_events[eventKey] = Delegate.Combine(d, handler);
        Monitor.Exit(m_events);
    }

    /// <summary>
    /// 从EventKey（如果存在）中删除委托，并删除映射最后一个委托的EventKey->delegate
    /// </summary>
    public void Remove(EventKey eventKey, Delegate handler)
    {
        Monitor.Enter(m_events);
        // 调用TryGetValue以确保在尝试从不在集合中的EventKey中删除委托时不会引发异常
        Delegate d;
        if (m_events.TryGetValue(eventKey, out d))
        {
            d = Delegate.Remove(d, handler);

            // 如果委托仍然存在，设置新的头或者删除EventKey
            if (d != null) m_events[eventKey] = d;
            else m_events.Remove(eventKey);
        }
        Monitor.Exit(m_events);
    }

    /// <summary>
    /// 为指示的EventKey引发事件
    /// </summary>
    public void Raise(EventKey eventKey, Object sender, EventArgs e)
    {
        // 如果EventKey不在集合中，不抛出异常
        Delegate d;
        Monitor.Enter(m_events);
        m_events.TryGetValue(eventKey, out d);
        Monitor.Exit(m_events);

        if (d != null)
        {
            // 因为字典可以包含几种不同的委托类型,不可能在编译时构造对委托的类型安全调用. 所以我调用 System.Delegate 类型抯 DynamicInvoke 方法, 
            // 将其作为对象数组的参数传递给回调方法抯。 在内部，DynamicVoke将检查调用回调方法的参数的类型安全性，并调用该方法。
            // 如果存在类型不匹配，则DynamicVoke将引发异常。
            d.DynamicInvoke(new Object[] { sender, e });
        }
    }
}