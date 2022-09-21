/// <summary>
/// QuizPanelsQ.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// 'Canvas Quiz' GameObject에 적용되는 스크립트입니다.
/// Easy / Normal : 왼쪽-색 / 오른쪽-글귀
/// Hard : 각각 좌/우 랜덤 위치에서 색과 글귀가 출제
/// </summary>

using UnityEngine;
using UnityEngine.UI;

public class QuizPanelQ : MonoBehaviour
{
    public Text leftLetter;
    public Text rightLetter;

    private void OnEnable()
    {
        if (GameManager.instance.isStart && GameManager.instance.musicPlayed.isPlaying && (!GameManager.instance.btnEasy.interactable || !GameManager.instance.btnNormal.interactable))
        {
            GameObject leftColorBall = Instantiate(PanelManager.instance.ballList[Random.Range(0, 7)], gameObject.transform.GetChild(0));
            PanelManager.instance.curColor = leftColorBall.name;

            rightLetter.text = PanelManager.instance._LetterList[Random.Range(0, 49)];
            PanelManager.instance.curLetter = rightLetter.text;

            PanelManager.instance.isQuiz = true;
        }
        else if (GameManager.instance.isStart && GameManager.instance.musicPlayed.isPlaying && !GameManager.instance.btnHard.interactable)
        {
            // Hard 전용 랜덤 변수 (0 == Color is Left | 1 == Color is Right)
            int randomDir = Random.Range(0, 2);
            switch (randomDir)
            {
                case 0:
                    GameObject leftColorBall = Instantiate(PanelManager.instance.ballList[Random.Range(0, 7)], gameObject.transform.GetChild(0));
                    PanelManager.instance.curColor = leftColorBall.name;

                    rightLetter.text = PanelManager.instance._LetterList[Random.Range(0, 49)];
                    PanelManager.instance.curLetter = rightLetter.text;

                    PanelManager.instance.isQuiz = true;
                    break;
                case 1:
                    GameObject rightColorBall = Instantiate(PanelManager.instance.ballList[Random.Range(0, 7)], gameObject.transform.GetChild(1));
                    PanelManager.instance.curColor = rightColorBall.name;

                    leftLetter.text = PanelManager.instance._LetterList[Random.Range(0, 49)];
                    PanelManager.instance.curLetter = leftLetter.text;

                    PanelManager.instance.isQuiz = true;
                    break;
            }
        }
    }
}