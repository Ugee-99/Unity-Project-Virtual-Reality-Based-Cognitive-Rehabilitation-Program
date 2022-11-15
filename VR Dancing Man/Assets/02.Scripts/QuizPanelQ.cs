/// <summary>
/// QuizPanelsQ.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Stutio)
/// This software is released under the GPL-2.0 license
/// 
/// 'Canvas Quiz' GameObject�� ����Ǵ� ��ũ��Ʈ�Դϴ�.
/// Easy / Normal : ����-�� / ������-�۱�
/// Hard : ���� ��/�� ���� ��ġ���� ���� �۱Ͱ� ����
/// </summary>

using TMPro;
using UnityEngine;

public class QuizPanelQ : MonoBehaviour
{
    public TMP_Text leftLetter;
    public TMP_Text rightLetter;

    private void OnEnable()
    {
        if (!Singleton<TutorialManager>.Instance.isTutorial)
        {
            if (Singleton<GameManager>.Instance.isStart && Singleton<GameManager>.Instance.music[2].isPlaying && (!Singleton<GameManager>.Instance.btnLevels[0].interactable || !Singleton<GameManager>.Instance.btnLevels[1].interactable))
            {
                GameObject leftColorBall = Instantiate(Singleton<PanelManager>.Instance.colorBalls[Random.Range(0, 7)], gameObject.transform.GetChild(0));
                Singleton<PanelManager>.Instance.curColor = leftColorBall.name;

                rightLetter.text = Singleton<PanelManager>.Instance._LetterList[Random.Range(0, 49)];
                Singleton<PanelManager>.Instance.curLetter = rightLetter.text;

                Singleton<PanelManager>.Instance.isQuiz = true;
            }
            else if (Singleton<GameManager>.Instance.isStart && Singleton<GameManager>.Instance.music[2].isPlaying && !Singleton<GameManager>.Instance.btnLevels[2].interactable)
            {
                // Hard ���� ���� ���� (0 == Color is Left | 1 == Color is Right)
                int randomDir = Random.Range(0, 2);
                switch (randomDir)
                {
                    case 0:
                        GameObject leftColorBall = Instantiate(Singleton<PanelManager>.Instance.colorBalls[Random.Range(0, 7)], gameObject.transform.GetChild(0));
                        Singleton<PanelManager>.Instance.curColor = leftColorBall.name;

                        rightLetter.text = Singleton<PanelManager>.Instance._LetterList[Random.Range(0, 49)];
                        Singleton<PanelManager>.Instance.curLetter = rightLetter.text;

                        Singleton<PanelManager>.Instance.isQuiz = true;
                        break;
                    case 1:
                        GameObject rightColorBall = Instantiate(Singleton<PanelManager>.Instance.colorBalls[Random.Range(0, 7)], gameObject.transform.GetChild(1));
                        Singleton<PanelManager>.Instance.curColor = rightColorBall.name;

                        leftLetter.text = Singleton<PanelManager>.Instance._LetterList[Random.Range(0, 49)];
                        Singleton<PanelManager>.Instance.curLetter = leftLetter.text;

                        Singleton<PanelManager>.Instance.isQuiz = true;
                        break;
                }
            }
        }
        else if (Singleton<TutorialManager>.Instance.isTutorial)
        {
            GameObject leftColorBall = Instantiate(Singleton<PanelManager>.Instance.colorBalls[Random.Range(0, 7)], gameObject.transform.GetChild(0));
            Singleton<PanelManager>.Instance.curColor = leftColorBall.name;

            rightLetter.text = Singleton<PanelManager>.Instance._LetterList[Random.Range(0, 49)];
            Singleton<PanelManager>.Instance.curLetter = rightLetter.text;

            Singleton<PanelManager>.Instance.isQuiz = true;
        }
    }
}