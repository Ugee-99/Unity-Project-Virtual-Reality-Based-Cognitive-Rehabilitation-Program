/// <summary>
/// QuizPanelsQ.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// 'Canvas Quiz' GameObject�� ����Ǵ� ��ũ��Ʈ�Դϴ�.
/// Easy / Normal : ����-�� / ������-�۱�
/// Hard : ���� ��/�� ���� ��ġ���� ���� �۱Ͱ� ����
/// 
/// Canvas Quiz A.cs(�ӽ�)
/// �÷��� �� �� ���Ƶ� ��
/// </summary>

using UnityEngine;
using UnityEngine.UI;

public class QuizPanelQ : MonoBehaviour
{
    // Color Balls(size : 7)
    public GameObject[] leftcolorBallArray;
    public GameObject[] rightcolorBallArray;

    // Letters(size : 49)
    public string[] leftLetterArray = 
        { "����", "��ȭ", "�뼭", "����", "ħ��", "����", "��ȭ", "����", "����", "����", 
        "ģ��", "����", "Ȱ��", "����", "����", "���", "��", "����", "���", "���", 
        "���", "����", "�ں�", "�ε巯��", "�ູ", "����", "����", "����", "�ڽŰ�", "����", 
        "�ູ", "��ȥ", "��ø��", "�ǰ�", "�游", "�ϰ���", "����", "����", "����", "ǳ��", 
        "����", "����", "�ɷ�", "����ġ", "�Ҹ�", "ħ��", "����", "���", "�һ�" };
    public string[] rightLetterArray =
        { "����", "��ȭ", "�뼭", "����", "ħ��", "����", "��ȭ", "����", "����", "����",
        "ģ��", "����", "Ȱ��", "����", "����", "���", "��", "����", "���", "���",
        "���", "����", "�ں�", "�ε巯��", "�ູ", "����", "����", "����", "�ڽŰ�", "����",
        "�ູ", "��ȥ", "��ø��", "�ǰ�", "�游", "�ϰ���", "����", "����", "����", "ǳ��",
        "����", "����", "�ɷ�", "����ġ", "�Ҹ�", "ħ��", "����", "���", "�һ�" };

    public Text leftLetter;
    public Text rightLetter;

    private void OnEnable()
    {
        if (GameManager.instance.isStart && GameManager.instance.musicPlayed.isPlaying && (!GameManager.instance.btnEasy.interactable || !GameManager.instance.btnNormal.interactable))
        {
            leftcolorBallArray[Random.Range(0, 7)].SetActive(true);
            rightLetter.text = leftLetterArray[Random.Range(0, 49)];
            PanelManager.instance.isQuiz = true;
        }
        else if (GameManager.instance.isStart && GameManager.instance.musicPlayed.isPlaying && !GameManager.instance.btnHard.interactable)
        {
            // Hard ���� ���� ���� (0 == Color is Left | 1 == Color is Right)
            int randomDir = Random.Range(0, 2);
            switch (randomDir)
            {
                case 0:
                    leftcolorBallArray[Random.Range(0, 7)].SetActive(true);
                    rightLetter.text = leftLetterArray[Random.Range(0, 49)];
                    PanelManager.instance.isQuiz = true;
                    break;
                case 1:
                    rightcolorBallArray[Random.Range(0, 7)].SetActive(true);
                    leftLetter.text = leftLetterArray[Random.Range(0, 49)];
                    PanelManager.instance.isQuiz = true;
                    break;
            }
        }
    }
}