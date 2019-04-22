using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// 开始状态
/// </summary>
public class StartState : ISceneState
{
    private Image mImgLogo;
    private float mSmoothingSpeed = 2f;
    private float mWaitTime = 2f;

    public StartState(SceneStateController controller) : base(controller, "01-StartGameScene")
    {

    }

    public override void SceneStart()
    {
        // 给 Logo 一个默认黑色
        mImgLogo = GameObject.Find("Logo").GetComponent<Image>();
        mImgLogo.color = Color.black;
    }

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
}