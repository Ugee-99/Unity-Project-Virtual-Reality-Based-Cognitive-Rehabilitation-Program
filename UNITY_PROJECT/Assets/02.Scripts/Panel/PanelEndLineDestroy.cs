/// <summary>
/// PanelEndLineDestroy.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - �÷��̾� �ڷ� ������ ��Ʈ���� �������ݴϴ�.
/// - _SFX ����Ƽ �̺�Ʈ�� Ʈ���� ���� �� ȿ���� ����� �ҽ��� �÷����ϴ� �Լ��� �����մϴ�.
/// - ComboManager�� Clear()�� ȣ���Ͽ� �޺��� �����մϴ�.
/// </summary>

using UnityEngine;
using UnityEngine.Events;

public class PanelEndLineDestroy : MonoBehaviour
{
    public UnityEvent _SFX;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "QUIZ")
        {
            _SFX?.Invoke();
            ComboManager.instance.Clear();
            Destroy(c.gameObject);
        }

        if (c.gameObject.tag == "BLOCK")
        {
            Destroy(c.gameObject);
        }

        if (c.gameObject.tag == "MOTION")
        {
            _SFX?.Invoke();
            ComboManager.instance.Clear();
            Destroy(c.gameObject);
        }
    }
}