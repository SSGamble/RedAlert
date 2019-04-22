using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 状态模式
///     在状态模式中，类的行为是基于它的状态改变的。
///     在状态模式中，我们创建表示各种状态的对象和一个行为随着状态对象改变而改变的 context 对象。
///     
/// 此处模拟状态转换，白天工作，晚上睡觉
/// </summary>
public class DM01State : MonoBehaviour
{
    void Start()
    {
        Context context = new Context();

        context.SetState(new ConcreteStateB(context));

        context.Handle(5); // B.Handle 睡觉
        context.Handle(11); // B.Handle 睡觉 -> A
        context.Handle(15); // A.Handle 工作
        context.Handle(24); // A.Handle 工作 -> B
    }
}

/// <summary>
/// 状态接口
/// </summary>
public interface IState
{
    void Handle(int hour);
}

/// <summary>
/// 使用 Context 来查看当状态 State 改变时的行为变化。
/// </summary>
public class Context
{
    private IState mState;

    // 定义 Context 的初始状态
    public void SetState(IState state)
    {
        mState = state;
    }

    public void Handle(int hour)
    {
        mState.Handle(hour);
    }
}

/// <summary>
/// 实现状态接口的实体类，状态 A
/// </summary>
public class ConcreteStateA : IState
{
    private Context mContext;

    public ConcreteStateA(Context context)
    {
        mContext = context;
    }

    public void Handle(int hour)
    {
        Debug.Log("ConcreateStateA.Handle " + hour + "工作");
        if (hour > 23 || hour < 6)
        {
            Debug.Log("A -> B");
            mContext.SetState(new ConcreteStateB(mContext)); // 设置下一状态 B
        }
    }
}

/// <summary>
/// 实现状态接口的实体类，状态 B
/// </summary>
public class ConcreteStateB : IState
{
    private Context mContext;

    public ConcreteStateB(Context context)
    {
        mContext = context;
    }

    public void Handle(int hour)
    {
        Debug.Log("ConcreateStateB.Handle " + hour + "睡觉");
        if (hour >= 6 && hour <= 23) // 6-23 点，工作
        {
            Debug.Log("B -> A");
            mContext.SetState(new ConcreteStateA(mContext));  // 设置下一状态 A
        }
    }
}
