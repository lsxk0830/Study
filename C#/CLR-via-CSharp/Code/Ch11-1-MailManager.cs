//#define CompilerImplementedEventMethods
using System;
using System.Threading;

public static class Events
{
    public static void Main()
    {
        MailManager.Go();
        TypeWithLotsOfEventsTest();
    }

    private static void TypeWithLotsOfEventsTest()
    {
        // 这里的代码测试事件
        TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

        // 添加一个回调
        twle.Foo += HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("回调在上面被调用了1次" + Environment.NewLine);

        // 添加另一个回调
        twle.Foo += HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("回调在上面被调用了2次" + Environment.NewLine);

        // 移除回调
        twle.Foo -= HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("回调在上面调用了1次" + Environment.NewLine);

        // 移除另一个回调
        twle.Foo -= HandleFooEvent;
        twle.SimulateFoo();
        Console.WriteLine("回调在上面被调用了0次" + Environment.NewLine);

        Console.WriteLine("按<Enter>终止此应用程序");
        Console.ReadLine();
    }

    private static void HandleFooEvent(object sender, FooEventArgs e)
    {
        Console.WriteLine("这里处理Foo事件...");
    }
}

///////////////////////////////////////////////////////////////////////////////

/// <summary>
/// Step #1:定义一个类型来容纳所有应该发送给事件通知接收者的附加信息
/// </summary>
internal sealed class NewMailEventArgs : EventArgs
{
    private readonly String m_from, m_to, m_subject;

    public NewMailEventArgs(String from, String to, String subject)
    {
        m_from = from; m_to = to; m_subject = subject;
    }

    /// <summary>
    /// 发件人
    /// </summary>
    public String From { get { return m_from; } }
    /// <summary>
    /// 收件人
    /// </summary>
    public String To { get { return m_to; } }
    /// <summary>
    /// 主题
    /// </summary>
    public String Subject { get { return m_subject; } }
}

internal class MailManager
{
    public static void Go()
    {
        MailManager mm = new MailManager(); // 构造一个 MailManager 对象

        Fax fax = new Fax(mm);              // 构造一个 Fax 对象，将 MailManager 对象传递给它

        Pager pager = new Pager(mm);        // 构造一个Pager对象，将 MailManager 对象传递给它

        mm.SimulateNewMail("Jeffrey", "Kristin", "I Love You!"); //模拟传入邮件消息

        fax.Unregister(mm); // 强制 Fax 对象在 MailManager 中注销自身

        mm.SimulateNewMail("Jeffrey", "Mom & Dad", "Happy Birthday."); //强制Fax对象在MailManager中注销自身
    }

#if CompilerImplementedEventMethods
   // Step #2: 定义事件成员
	public event EventHandler<NewMailEventArgs> NewMail; // 定义事件成员
#else
    // MailManager类用一行代码定义了事件成员本身
    private EventHandler<NewMailEventArgs> m_NewMail;// 添加私有字段，该字段指向委托链表的头部

    // 向类中定义事件成员
    public event EventHandler<NewMailEventArgs> NewMail
    {
        add // 显式地实现 'Add' 方法
        {
            m_NewMail += value; // 在没有线程安全性的情况下，将处理程序（作为“值”传递）添加到委托链表中
        }

        remove // 显式地实现 'remove' 方法
        {
            m_NewMail -= value;// 在没有线程安全性的情况下，从委托链表中删除处理程序（作为“值”传递）
        }
    }

#endif

    /// <summary>
    /// Step #3: 定义负责引发事件的方法来通知已登记的对象
    /// 如果类是密封的，该方法设置为私有且非虚
    /// 触发事件
    /// </summary>
    protected virtual void OnNewMail(NewMailEventArgs e)
    {
        // 出于线程安全的考虑，现在将对委托字段的引用复制到一个临时变量中
        //e.Raise(this, ref m_NewMail);

#if CompilerImplementedEventMethods
		EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);
#else
        EventHandler<NewMailEventArgs> temp = Volatile.Read(ref m_NewMail);
#endif

        // 任何方法登记了对事件的关注，就通知它们
        temp?.Invoke(this, e);
    }

    /// <summary>
    /// Step #4: 定义方法将输入转化为期望事件
    /// </summary>
    /// <param name="from">发件人</param>
    /// <param name="to">收件人</param>
    /// <param name="subject">主题</param>
    public void SimulateNewMail(String from, String to, String subject)
    {

        // 构造一个对象来容纳想传给通知接收者的信息
        NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

        // 调用虚方法通知事件已经发生
        // 如果没有类型重写该方法，我们的对象将通知事件的所有登记对象
        OnNewMail(e);
    }
}

public static class EventArgExtensions
{
    public static void Raise<TEventArgs>(this TEventArgs e, Object sender, ref EventHandler<TEventArgs> eventDelegate)
    {
        EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);  // 为了线程安全，现在将对委托字段的引用复制到临时字段中

        if (temp != null) temp(sender, e); //如果有任何方法注册了我们的事件，就通知他们
    }
}

internal sealed class Fax // 传真
{
    public Fax(MailManager mm) // 将 MailManager 对象传给构造器
    {
        // 构造 EventHandler<NewMailEventArgs> 委托的一个实例，使它引用我们的 FaxMsg 回调方法
        // 向 MailManager 的 NewMail 事件登记我们的回调方法
        mm.NewMail += FaxMsg;
    }

    private void FaxMsg(Object sender, NewMailEventArgs e)
    {
        // 'sender' 表示 MailManager 对象，便于将信息传回给它
        // 'e' 表示 MailManager 想传给我们的附加事件信息

        // 这里的代码正常情况下应该传真电子邮件消息，但这个测试性的实现只是在控制台上显示邮件
        Console.WriteLine("Faxing mail message:");
        Console.WriteLine("   From={0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
    }

    public void Unregister(MailManager mm) // 执行这个方法，Fax 对象将向 NewMail 事件注销自己对它的关注
    {
        mm.NewMail -= FaxMsg; // 向 MailManage 的 NewMail 事件注销自己对这个的关注
    }
}

///////////////////////////////////////////////////////////////////////////////

internal sealed class Pager // 寻呼机
{
    public Pager(MailManager mm) // 将 MailManager 对象传给构造器
    {
        // 构造 EventHandler<NewMailEventArgs> 委托的一个实例，使它引用我们的 SendMsgToPager 回调方法
        // 向 MailManager 的 NewMail 事件登记我们的回调方法
        mm.NewMail += SendMsgToPager;
    }

    private void SendMsgToPager(Object sender, NewMailEventArgs e) // 新邮件到达时，MailManager将调用这个方法
    {
        // 'sender' 表示 MailManager 对象，便于将信息传回给它
        // 'e' 表示 MailManager 想传给我们的附加事件信息

        // 这里的代码正常情况下应该传真电子邮件消息，但这个测试性的实现只是在控制台上显示邮件
        Console.WriteLine("Sending mail message to pager:");
        Console.WriteLine("   From={0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
    }

    public void Unregister(MailManager mm)
    {
        mm.NewMail -= SendMsgToPager; // 向 MailManage 的 NewMail 事件注销自己对这个的关注
    }
}

//////////////////////////////// End of File //////////////////////////////////
