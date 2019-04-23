using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// 主菜单状态
/// </summary>
public class MainMenuState : ISceneState
{
    public MainMenuState(SceneStateController controller) : base(controller, "02-MainMenuScene")
    {

    }

    public override void StateStart()
    {
        // 添加按钮的监听事件
        GameObject.Find("BtnStart").GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    /// <summary>
    /// 按钮的点击事件
    /// </summary>
    private void OnStartButtonClick()
    {
        mStateController.SetState(new BattleState(mStateController));
    }
}