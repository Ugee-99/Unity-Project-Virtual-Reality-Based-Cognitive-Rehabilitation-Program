/// <summary>
/// MotionPanelCheck.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - PanelCheck ���� ������Ʈ�� PanelCheck()�� ���� Enable ���� �� ���ھ�� Į�θ��� �ø���, PanelCheck()�� PanelCheck ���ӿ�����Ʈ�� Enable ���ִ� ���ǿ��� Ż���մϴ�.
/// - _SFX ����Ƽ �̺�Ʈ�� Ʈ���� ���� �� ȿ���� ����� �ҽ��� �÷����ϴ� �Լ��� �����մϴ�.
/// </summary>

using UnityEngine;
using UnityEngine.Events;

public class MotionPanelCheck : MonoBehaviour
{
    public UnityEvent _SFX;

    private void OnEnable()
    {
        _SFX?.Invoke();
        StartCoroutine(ScoreManager.instance.Increase());
        Destroy(PanelManager.instance.panelSpawnPoint.transform.GetChild(0).gameObject);
    }
}