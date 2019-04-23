using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// 开始状态
///     根据需求重写 3 个虚函数，处理该状态要做的事
/// </summary>
public class StartState : ISceneState
{
    private Image mImgLogo;
    private float mSmoothingSpeed = 2f;
    private float mWaitTime = 1f;

    public StartState(SceneStateController controller) : base(controller, "01-StartGameScene")
    {

    }

    /// <summary>
    /// Start:刚进入状态时
    /// </summary>
    public override void StateStart()
    {
        // 给 Logo 一个默认黑色
        mImgLogo = GameObject.Find("Logo").GetComponent<Image>();
        mImgLogo.color = Color.black;
    }

    /// <summary>
    /// Update：开始状态要做的事情
    ///     1. Logo 渐变显示
    ///     2. 2s 后跳转到下一个场景
    /// </summary>
    public override void StateUpdate()
    {
        // Logo 渐变成白色
        mImgLogo.color = Color.Lerp(mImgLogo.color, Color.white, mSmoothingSpeed * Time.deltaTime);
        // 2s 后，转换状态，跳转到 MainMenuScene
        mWaitTime -= Time.deltaTime;
        if (mWaitTime < 0)
        {
            mStateController.SetState(new MainMenuState(mStateController));
        }
    }

    /// <summary>
    /// End: 离开该状态要做的事情
    /// </summary>
    public override void StateEnd()
    {
        Debug.Log("离开「开始状态」");
    }
}