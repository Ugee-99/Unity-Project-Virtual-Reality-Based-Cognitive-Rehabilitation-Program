/// <summary>
/// PanelDestroyOnHover.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - Motion Panel�� Answer Panel�� ��/�� �ݶ��̴��� XRGrabInteractable.cs�� Hover Entered�� Hover Exited�� �� �Լ��� �����Ͽ� �÷��� ������ �����մϴ�.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDestroyOnHover : MonoBehaviour
{
    public void OnHoverEntered_LEFT()
    {
        Debug.Log($"{gameObject.name} - OnHoverEntered LEFT");
        GameManager.instance.isSensorLeft = true;
    }

    public void OnHoverExited_LEFT()
    {
        Debug.Log($"{gameObject.name} - OnHoverExited LEFT");
        GameManager.instance.isSensorLeft = false;
    }

    public void OnHoverEntered_RIGHT()
    {
        Debug.Log($"{gameObject.name} - OnHoverEntered RIGHT");
        GameManager.instance.isSensorRight = true;
    }

    public void OnHoverExited_RIGHT()
    {
        Debug.Log($"{gameObject.name} - OnHoverExited RIGHT");
        GameManager.instance.isSensorRight = false;
    }
}