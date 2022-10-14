/// <summary>
/// ResultElements.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// </summary>

using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultElements : MonoBehaviour
{
    private void Start()
    {
        /*Ÿ��Ʋ*/
        gameObject.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textTitle.text;
        /*���̵�*/
        gameObject.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textLevel.text;
        /*���ھ�*/
        gameObject.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textScore.text;
        /*Į�θ�*/
        gameObject.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = GameManager.instance.textKcal.text;
    }
}