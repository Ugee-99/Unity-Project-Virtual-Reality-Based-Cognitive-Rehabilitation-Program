/// <summary>
/// ResultElements.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Studio)
/// This software is released under the GPL-2.0 license
/// 
/// ���� ������ �� ������Ʈ�� TMP_Text ������Ʈ�� ���� ���� ����� Ű ������ ����
/// </summary>

using TMPro;
using UnityEngine;

public class ResultElements : MonoBehaviour
{
    private void Start()
    {
        /*Title*/ gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textKeys[0].text;
        /*Level*/ gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textKeys[1].text;
        /*Score*/ gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textKeys[2].text;
        /* Kcal*/ gameObject.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textKeys[3].text;
    }
}