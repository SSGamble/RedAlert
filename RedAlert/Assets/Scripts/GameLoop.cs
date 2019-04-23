using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController controller = null;

    private void Awake()
    {
        // public static void DontDestroyOnLoad(Object target); 加载新场景时，不会自动销毁对象目标。
        DontDestroyOnLoad(this.gameObject);
    }

    void Start () {
        // 状态控制器对象
        controller = new SceneStateController();
        // 设置默认(当前)状态为开始状态，设置默认状态的时候是不需要加载场景的
        controller.SetState(new StartState(controller),false);
    }
	
	void Update () {
        if (controller != null)
            controller.StateUpdate();
	}
}
