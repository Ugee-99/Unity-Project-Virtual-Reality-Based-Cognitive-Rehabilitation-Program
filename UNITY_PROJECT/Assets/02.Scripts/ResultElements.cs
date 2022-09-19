/// <summary>
/// ResultElements.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultElements : MonoBehaviour
{
    private void Start()
    {
        /*Ÿ��Ʋ*/
        gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = GameManager.instance._TextTitle.text;
        /*���̵�*/
        gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = GameManager.instance._TextLevel.text;
        /*���ھ�*/
        gameObject.transform.GetChild(2).gameObject.GetComponent<Text>().text = GameManager.instance._TextScore.text;
        /*Į�θ�*/
        gameObject.transform.GetChild(3).gameObject.GetComponent<Text>().text = GameManager.instance._TextKcal.text;
    }
}