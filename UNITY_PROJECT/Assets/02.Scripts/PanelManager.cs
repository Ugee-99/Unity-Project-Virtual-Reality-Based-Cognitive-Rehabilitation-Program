using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [Header("[�г� ������]")]
    public Transform panelSpawnPoint; // �г� ���� ��ǥ
    public GameObject[] block;        // �г� ������ �迭
    public GameObject[] quiz;         // �г� ������ �迭
    public GameObject[] motion;       // �г� ������ �迭

    [Header("[UI Canvas ������]")]
    public GameObject quizImageAnswer;
    public GameObject quizImageQuestion;
    public GameObject quizTextAnswer;
    public GameObject quizTextQuestion;

    [Header("[Music BPM]")]
    public float timer;                 // BPM ��� Ÿ�̸�
    public float beat;                  // BPM


    GameObject[] motionPanels;


    enum Motion
    {
        M0,
        M1,
        M2,
        M3,
        M4,
        M5,
        M6,
        M7,
        M8,
        M9,
        M10,
        M11
    }

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isStart)
        {
            PanelInstance();
        }
    }

    public void PanelInstance()
    {
        if (timer > beat)
        {
            //Instantiate(Panels[Random.Range(0, 16)], panelSpawnPoint);

            timer -= beat; // Timer = Timer - Beat
        }

        timer += Time.deltaTime; // Timer
    }

    // �г� �������� Canvas�� �ٲ��ش�. (�ؽ�Ʈ, �̹���)
    void QuizThemeChange() 
    {

    }

    // �ؽ�Ʈ �׸�
    void TxtTheme()
    {

    }

    // �̹��� �׸�
    void ImageTheme()
    {

    }

    // 
    void Quiz()
    {
        //switch (panelList)
        //{
        //    case 0: // Not

        //        break;
        //    case MotionPanel.M0:

        //        break;
        //    case MotionPanel.M1:

        //        break;
        //    case MotionPanel.M2:

        //        break;
        //    case MotionPanel.M3:

        //        break;
        //    case MotionPanel.M4:

        //        break;
        //    case MotionPanel.M5:

        //        break;
        //    case MotionPanel.M6:

        //        break;
        //}
    }
}
