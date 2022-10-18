/// <summary>
/// PanelEndLineDestroy.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
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
            ComboManager.instance.Clear();
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (TutorialManager.instance.isTutorial) TutorialManager.instance.tutoPanelDestroyCount++;
            // SFX(Fail)
            GameManager.instance.sFX[2]?.Invoke();
        }

        if (c.gameObject.tag == "BLOCK")
        {
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (TutorialManager.instance.isTutorial) TutorialManager.instance.tutoPanelDestroyCount++;
        }

        if (c.gameObject.tag == "MOTION")
        {
            // Combo Reset
            ComboManager.instance.Clear();
            // Delete Collision Obj
            Destroy(c.gameObject);
            // Tuto Destory Count++
            if (TutorialManager.instance.isTutorial) TutorialManager.instance.tutoPanelDestroyCount++;
            // SFX(Fail)
            GameManager.instance.sFX[2]?.Invoke();
        }
    }
}