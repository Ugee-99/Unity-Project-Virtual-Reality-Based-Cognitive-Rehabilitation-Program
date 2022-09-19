/// <summary>
/// PanelEndLineDestroy.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - �÷��̾� �ڷ� ������ ��Ʈ���� �������ݴϴ�.
/// - panelLastIndex�� �����Ͽ� ���� �г��� ���� ������ �����մϴ�.
/// - _SFX ����Ƽ �̺�Ʈ�� Ʈ���� ���� �� ȿ���� ����� �ҽ��� �÷����ϴ� �Լ��� �����մϴ�.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class PanelEndLineDestroy : MonoBehaviour
{
    public UnityEvent _SFX;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "QUIZ")
        {
            Destroy(c.gameObject);
            GameManager.instance.panelLastIndex--;
            _SFX?.Invoke();
            ComboManager.instance.Clear();
        }

        if (c.gameObject.tag == "BLOCK")
        {
            Destroy(c.gameObject);
            GameManager.instance.panelLastIndex--;
        }

        if (c.gameObject.tag == "MOTION")
        {
            Destroy(c.gameObject);
            GameManager.instance.panelLastIndex--;
            _SFX?.Invoke();
            ComboManager.instance.Clear();
        }
    }
}