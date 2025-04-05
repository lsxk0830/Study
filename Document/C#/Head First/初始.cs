public abstract class Duck
{
    public void quack()
    public void swim()
    public abstract void display()
    // 鸭子的其他方法
}

public class MallardDuck : Duck
{
    public override void display()
    {
        // 外观是绿头
    }
}
public class RedhearDuck : Duck
{
    public override void display()
    {
        // 外观是红头
    }
}