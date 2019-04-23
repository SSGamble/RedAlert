using UnityEngine;
using UnityEditor;

/// <summary>
/// 场景状态接口，供给实际状态类继承
/// </summary>
public class ISceneState
{
    private string mSceneName; // 场景名
    public string SceneName { get{ return mSceneName; } }
    protected SceneStateController mStateController; // 场景状态控制器的引用

    // 构造方法
    public ISceneState(SceneStateController stateController,string sceneName)
    {
        mStateController = stateController;
        mSceneName = sceneName;
    }

    // 3 个虚方法，供给子类扩展
    public virtual void StateStart() { } // 每次进入这个状态时调用
    public virtual void StateEnd() { } // 每次离开这个状态时调用
    public virtual void StateUpdate() { } // 状态更新时调用
}