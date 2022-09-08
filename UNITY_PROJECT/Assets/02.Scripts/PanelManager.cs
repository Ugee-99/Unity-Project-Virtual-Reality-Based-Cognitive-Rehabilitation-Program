using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class PanelManager : MonoBehaviour
{
    public GameObject checkCollider;

    [Header("[패널 프리팹]")]
    public Transform panelSpawnPoint; // 패널 생성 좌표
    public GameObject[] block;        // 패널 프리팹 배열
    public GameObject[] quiz;         // 패널 프리팹 배열
    public GameObject[] motion;       // 패널 프리팹 배열

    [Header("[UI Canvas 프리팹]")]
    public GameObject quizImageAnswer;
    public GameObject quizImageQuestion;
    public GameObject quizTextAnswer;
    public GameObject quizTextQuestion;

    [Header("[Music BPM]")]
    public float timer;                 // BPM 계산 타이머
    public float beat;                  // BPM

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

    private void FixedUpdate()
    {
        if (GameManager.instance.isStart)
        {
            PanelInstance();
            Check();
        }
    }

    public void PanelInstance()
    {
        if (GameManager.instance.isSensor == false)
        {
            Instantiate(motion[Random.Range(1, 2)], panelSpawnPoint);
        }
    }

    void Check()
    {
        if (GameManager.instance.isSensorLeft && GameManager.instance.isSensorRight)
            checkCollider.SetActive(true);
        else if (GameManager.instance.isSensorLeft == false || GameManager.instance.isSensorRight == false)
            checkCollider.SetActive(false);
    }

    // 패널 프리팹의 Canvas를 바꿔준다. (텍스트, 이미지)
    void QuizThemeChange() 
    {

    }

    // 텍스트 테마
    void TxtTheme()
    {

    }   

    // 이미지 테마
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