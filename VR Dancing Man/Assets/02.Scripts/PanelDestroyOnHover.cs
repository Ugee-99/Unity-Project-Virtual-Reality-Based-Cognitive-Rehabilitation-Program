/// <summary>
/// PanelDestroyOnHover.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Stutio)
/// This software is released under the GPL-2.0 license
/// 
/// - Motion Panel�� Answer Panel�� ��/�� �ݶ��̴��� XRGrabInteractable.cs�� Hover Entered�� Hover Exited�� �� �Լ��� �����Ͽ� �÷��� ������ �����մϴ�.
/// </summary>

using UnityEngine;

public class PanelDestroyOnHover : MonoBehaviour
{
    public void OnHoverEntered_LEFT()
    {
        //Debug.Log($"{gameObject.name} - OnHoverEntered LEFT");
        Singleton<GameManager>.Instance.isSensorLeft = true;
    }

    public void OnHoverExited_LEFT()
    {
        //Debug.Log($"{gameObject.name} - OnHoverExited LEFT");
        Singleton<GameManager>.Instance.isSensorLeft = false;
    }

    public void OnHoverEntered_RIGHT()
    {
        //Debug.Log($"{gameObject.name} - OnHoverEntered RIGHT");
        Singleton<GameManager>.Instance.isSensorRight = true;
    }

    public void OnHoverExited_RIGHT()
    {
        //Debug.Log($"{gameObject.name} - OnHoverExited RIGHT");
        Singleton<GameManager>.Instance.isSensorRight = false;
    }
}