using UnityEngine;
using UnityEditor;

/// <summary>
/// 战斗状态
/// </summary>
public class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base(controller, "03-BattleScene")
    {

    }
}