using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement; // 场景管理

/// <summary>
/// 场景状态控制器
/// </summary>
public class SceneStateController
{
    private ISceneState mSceneState;
    private AsyncOperation mAO; // 异步加载场景
    private bool mIsRunStartState = false; // 是否运行过 StartState 方法

    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="state">状态</param>
    /// <param name="isLoadScene">是否需要加载场景</param>
    public void SetState(ISceneState state,bool isLoadScene = true)
    {
        // 如果当前状态不为空，就让当前状态做一下清理工作
        if (mSceneState != null)
        {
            mSceneState.StateEnd();
        }
        // 设置当前状态
        mSceneState = state;
        // 加载指定状态
        if (isLoadScene) // 是否需要加载场景
        {
            // 异步加载场景
            mAO = SceneManager.LoadSceneAsync(mSceneState.SceneName);
            mIsRunStartState = false;
        }
        else
        {
            mSceneState.StateStart(); // 设置开始状态
            isLoadScene = true;
        }
    }

    /// <summary>
    /// 状态更新
    /// </summary>
    public void StateUpdate()
    {
        // 正在切换场景
        if (mAO != null && !mAO.isDone) return;

        // 场景是否加载完成
        if (mAO != null && mAO.isDone && !mIsRunStartState)
        {
            // 设置开始状态
            mSceneState.StateStart();
            mIsRunStartState = true;
        }
        // 设置状态更新
        if (mSceneState != null)
        {
            mSceneState.StateUpdate();
        }
    }
}