/// <summary>
/// PanelEndLineDestroy.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Stutio)
/// This software is released under the GPL-2.0 license
/// 
/// - �÷��̾� �ڷ� ������ ��Ʈ���� �������ݴϴ�.
/// - GameManager.cs�� SFX[] ����Ƽ �̺�Ʈ�� Ʈ���� ���� �� �������� ��µ˴ϴ�.
/// - ComboManager�� Clear()�� ȣ���Ͽ� �޺��� �����մϴ�.
/// </summary>

using UnityEngine;

public class PanelEndLineDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "QUIZ")
        {
            // Combo Reset
            Singleton<ComboManager>.Instance.Clear();
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (Singleton<TutorialManager>.Instance.isTutorial)
                Singleton<TutorialManager>.Instance.tutoPanelDestroyCount++;
            // SFX(Fail)
            Singleton<GameManager>.Instance.sFX[2].Play();
        }

        if (c.gameObject.tag == "BLOCK")
        {
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (Singleton<TutorialManager>.Instance.isTutorial)
                Singleton<TutorialManager>.Instance.tutoPanelDestroyCount++;
        }

        if (c.gameObject.tag == "MOTION")
        {
            // Combo Reset
            Singleton<ComboManager>.Instance.Clear();
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (Singleton<TutorialManager>.Instance.isTutorial)
                Singleton<TutorialManager>.Instance.tutoPanelDestroyCount++;
            // SFX(Fail)
            Singleton<GameManager>.Instance.sFX[2].Play();
        }
    }
}