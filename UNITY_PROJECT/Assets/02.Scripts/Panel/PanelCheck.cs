/// <summary>
/// MotionPanelCheck.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - panelLastIndex�� �����Ͽ� ���� �г��� ���� ������ �����մϴ�.
/// - _SFX ����Ƽ �̺�Ʈ�� Ʈ���� ���� �� ȿ���� ����� �ҽ��� �÷����ϴ� �Լ��� �����մϴ�.
/// </summary>

using UnityEngine;
using UnityEngine.Events;

public class PanelCheck : MonoBehaviour
{
    public UnityEvent _SFX;
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "MOTION")
        {
            _SFX?.Invoke();
            PanelManager.instance.panelLastIndex--;
            Destroy(c.gameObject);
        }
    }
}