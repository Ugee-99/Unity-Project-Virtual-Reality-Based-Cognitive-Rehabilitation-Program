/// <summary>
/// TutorialManager.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Stutio)
/// This software is released under the GPL-2.0 license
/// 
/// - Ʃ�丮�� ������ ����ϴ� ��ũ��Ʈ�Դϴ�.
/// - TextAnimatorPlayer Ŭ������ ���� Text Animation ������ ����մϴ�.
/// - TutorialStart() �������̽����� �� �Լ����� yield return new WaitWhile(() => tutorialStep < ?)�� ���ൿ�� ����˴ϴ�.
/// - Tuple���(Vector3, Vector2, Quaternion)���� ���� ���� �޴� XR_TutoCanvasSize() �޼ҵ带 ���� ĵ���� ������� ��ġ, ȸ�� ���� ���� �߽��ϴ�.
/// </summary>

using Febucci.UI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : Singleton<TutorialManager>
{
    [Header("[UI]")]
    [SerializeField] RectTransform xrTutoCanvas;
    [SerializeField] Button btnTutoNext;
    [SerializeField] TextAnimatorPlayer textAnimatorPlayer;
    [SerializeField] TMP_Text textTutoOriginal;
    [SerializeField] TMP_Text textTutoEasy;
    [SerializeField] TMP_Text textTutoPlay;

    [Header("[Message]")]
    public int tutorialStep;
    public string[] textBox = {
        "<speed=0.5><rainb f=0.2>�ȳ��ϼ���.</rainb> �ݰ����ϴ�." +
            "\n���ݺ��� �÷��� ����� �ȳ��ص帮�ڽ��ϴ�.",
        "<speed=0.5>����� <rainb f=0.2>[Original]</rainb> �׸��� �������ּ���.",
        "<speed=0.5>�뷡<rainb f=0.2>[Cat Life]</rainb>�� �������ּ���.",
        "<speed=0.5>���̵� <rainb f=0.2>[Easy]</rainb>�� �������ּ���.",
        "<speed=0.5><rainb f=0.2>[Play]</rainb> ��ư�� ���� ������ �����մϴ�.",
        "<speed=0.5><size=7>�������� �����߽��ϴ�." +
            "\n\n�������� ȹ���� <bounce a=0.3 f=0.3>����</bounce>�� <bounce a=0.3 f=0.3>�Ҹ�� Į�θ�</bounce>�� ǥ�õ˴ϴ�." +
            "\n���� �Ǵ� ��� �����ϸ� ������ �޺��� �����ϴ�." +
            "\n���ۿ� �����ϸ� �Ҹ��� �����ϴ�." +
            "\n\n���� �ϴܿ��� <bounce a=0.3 f=0.3>�ڽ��� ������ Ȯ��</bounce>�� �� �ֽ��ϴ�." +
            "\n\n�ٴڿ��� <bounce a=0.3 f=0.3>�뷡�� ����</bounce>�� �� �� �ֽ��ϴ�.",
        "<speed=0.5>��� �г��� �ذ��غ�����.",
        "<speed=0.5>��ֹ� �г��� ���Խ��ϴ�." +
            "\n���� �̵��Ͽ� �����ּ���." +
            "\n�ǰ� �� �޺��� ������ �ҽ��ϴ�.",
        "<speed=0.5>���� �г��� ���Խ��ϴ�." +
            "\n��/��� ����� �۱͸� ���� �޽��ϴ�.\n������ �ذ��ϸ鼭 �ܿ��ּ���.",
        "<speed=0.5>������ ���ߴ� �г��Դϴ�." +
            "\n�ܿ��� ����� �۱Ͱ� ��ġ�ϴ� ������ �����ϼ���.",
        "<speed=0.5>�뷡�� �ϼ��ϰ� �Ǹ� ���â�� ǥ�õ˴ϴ�." +
            "\n�뷡 ����/���̵�/����/�Ҹ�� Į�θ��� �� �� �ֽ��ϴ�." +
            "\n�������� ���ư��ô�.",
        "<speed=0.5>���� Ű ������ �κ��� ���ʿ� �ֽ��ϴ�." +
            "\nƩ�丮���� ��ġ�ڽ��ϴ�." };

    [Header("[Panel]")]
    public GameObject[] tutoPanels;
    public int tutoPanelSpawnCount;
    public int tutoPanelDestroyCount;
    public float tutoMoveSpeed = 2.0f;

    [Header("[Music]")]
    public float tutoSecPerBeat = 3.5f;
    public float tutoPanelTimer; // BPM ��� Ÿ�̸�

    [Header("[�÷��� ����]")]
    public bool isTutorial;
    public bool isMotionClear;
    public bool isObstacleClear;
    public bool isMotionQuizClear;
    public bool isQuizClear;

    private void Awake()
    {
        // Reset
        tutorialStep = 0;
        isMotionClear = false;
        isObstacleClear = false;
        isMotionQuizClear = false;
        isQuizClear = false;
    }

    private void FixedUpdate()
    {
        // ��� �г� ���� ���� ��
        if (tutorialStep == 7 && !isMotionClear)
        {
            PanelSpawn();
            if (tutoPanelDestroyCount == 3)
                tutorialStep++;
        }
        // ��ֹ� �г� �������� ��
        else if (tutorialStep == 9 && !isObstacleClear)
        {
            PanelSpawn();
            if (tutoPanelDestroyCount == 4)
                tutorialStep++;
        }
        // ��� ���� �г� �������� ��
        else if (tutorialStep == 11 && !isMotionQuizClear)
        {
            PanelSpawn();
            if (tutoPanelDestroyCount == 5)
                tutorialStep++;
        }
        // ���� �г� �������� ��
        else if (tutorialStep == 13 && !isQuizClear)
        {
            PanelSpawn();
            if (tutoPanelDestroyCount == 6)
                tutorialStep++;
        }
    }

    public IEnumerator TutorialStart()
    {
        Step1();
        yield return new WaitWhile(() => tutorialStep < 1);

        Step2();
        yield return new WaitWhile(() => tutorialStep < 2);

        Step3();
        yield return new WaitWhile(() => tutorialStep < 3);

        Step4();
        yield return new WaitWhile(() => tutorialStep < 4);

        Step5();
        yield return new WaitWhile(() => tutorialStep < 5);

        Step6();
        yield return new WaitWhile(() => tutorialStep < 6);

        Step7();
        yield return new WaitWhile(() => tutorialStep < 7);

        Step8();
        yield return new WaitWhile(() => tutorialStep < 8);

        Step9();
        yield return new WaitWhile(() => tutorialStep < 9);

        Step10();
        yield return new WaitWhile(() => tutorialStep < 10);

        Step11();
        yield return new WaitWhile(() => tutorialStep < 11);

        Step12();
        yield return new WaitWhile(() => tutorialStep < 12);

        Step13();
        yield return new WaitWhile(() => tutorialStep < 13);

        Step14();
        yield return new WaitWhile(() => tutorialStep < 14);

        Step15();
        yield return new WaitWhile(() => tutorialStep < 15);

        Step16();
        yield return new WaitWhile(() => tutorialStep < 16);

        Step17();
        yield return new WaitWhile(() => tutorialStep < 17);
    }

    (Vector3, Vector2, Quaternion) XR_TutoCanvasSize(int tutorialStep)
    {
        if      (tutorialStep == 0) return (new Vector3(0f, 2f, 1f), new Vector2(200f, 50f), Quaternion.Euler(10f, 0f, 0f));
        else if (tutorialStep == 1) return (new Vector3(0f, 1.3f, 0.85f), new Vector2(180f, 20f), Quaternion.Euler(50f, 0f, 0f));
        else if (tutorialStep == 5) return (new Vector3(0f, 2.25f, 1f), new Vector2(200f, 110f), Quaternion.Euler(0f, 0f, 0f));
        else if (tutorialStep == 14) return (new Vector3(0f, 2.9f, 0.9f), new Vector2(250f, 70f), Quaternion.Euler(-15f, 0f, 0f));
        else if (tutorialStep == 15) return (new Vector3(0f, 1.3f, 0.85f), new Vector2(180f, 40f), Quaternion.Euler(50f, 0f, 0f));
        else return (new Vector3(0f, 0f, 0f), new Vector2(0f, 0f), Quaternion.identity);
    }

    // Ʃ�丮�� ���� �ȳ�
    void Step1()
    {
        Singleton<GameManager>.Instance.uiTutorial.SetActive(true);
        Singleton<GameManager>.Instance.uiLobby.SetActive(false);

        foreach (Transform item in Singleton<GameManager>.Instance.contentOriginal.transform)
            Destroy(item.gameObject);
        foreach (Transform item in Singleton<GameManager>.Instance.contentCustom.transform)  
            Destroy(item.gameObject);

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize(tutorialStep);
        textAnimatorPlayer.ShowText(textBox[0]);
    }

    // Theme(Original) ����
    void Step2()
    {
        // Tutorial Button OFF
        btnTutoNext.interactable = false;
        // UI Lobby ON
        Singleton<GameManager>.Instance.uiLobby.SetActive(true);
        // UI Option(Lobby Left UI) OFF
        Singleton<GameManager>.Instance.uiLobbyOption.SetActive(false);
        // UI Result(Lobby Right UI) OFF
        Singleton<GameManager>.Instance.uiLobbyResult.SetActive(false);
        // Original Theme Select ON
        Singleton<GameManager>.Instance.btnMusicTheme[0].interactable = true;
        // Custom Theme Select OFF
        Singleton<GameManager>.Instance.btnMusicTheme[1].interactable = false;
        // Levels OFF
        for (int i = 0; i < Singleton<GameManager>.Instance.btnLevels.Length; i++)
            Singleton<GameManager>.Instance.btnLevels[i].interactable = false;
        // Play OFF
        Singleton<GameManager>.Instance.btnPlay.interactable = false;
        // Tutorial(Btn) OFF
        Singleton<GameManager>.Instance.bgTutorial.SetActive(false);
        // InfoTitle Reset
        Singleton<GameManager>.Instance.infoTitle.text = "�� Not Search";
        // �ȳ� ���� ����
        textTutoOriginal.text = "<bounce a=0.5 f=0.5>Original</bounce>";

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize(tutorialStep);

        textAnimatorPlayer.ShowText(textBox[1]);
    }

    // Music(Cat Life) ����
    void Step3()
    {
        // Custom Theme Select OFF
        Singleton<GameManager>.Instance.btnMusicTheme[1].interactable = false;
        // �ȳ� ���� ���� OFF
        textTutoOriginal.text = "Original";

        textAnimatorPlayer.ShowText(textBox[2]);
    }

    // Level(Easy) ����
    void Step4()
    {
        // Easy ON
        Singleton<GameManager>.Instance.btnLevels[0].interactable = true;
        // Normal OFF
        Singleton<GameManager>.Instance.btnLevels[1].interactable = false;
        // Hard OFF
        Singleton<GameManager>.Instance.btnLevels[2].interactable = false;
        // Music Element OFF
        Singleton<GameManager>.Instance.contentOriginal.transform.GetChild(0).GetComponent<Button>().interactable = false;
        // �ȳ� ���� ���� OFF
        Singleton<GameManager>.Instance.contentOriginal.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = "Cat Life";
        // �ȳ� ���� ���� ON
        textTutoEasy.text = "<bounce a=0.5 f=0.5>Easy</bounce>";

        textAnimatorPlayer.ShowText(textBox[3]);
    }

    // Play ��ư �ȳ�
    void Step5()
    {
        // Levels OFF
        for (int i = 0; i < Singleton<GameManager>.Instance.btnLevels.Length; i++) Singleton<GameManager>.Instance.btnLevels[i].interactable = false;
        // �ȳ� ���� ���� OFF
        textTutoEasy.text = "Easy";
        // �ȳ� ���� ���� ON
        textTutoPlay.text = "<bounce a=0.5 f=0.5>Play</bounce>";

        textAnimatorPlayer.ShowText(textBox[4]);
    }

    // �ΰ��� ��� ����
    void Step6() 
    {
        // �ȳ� ���� ���� OFF
        textTutoPlay.text = "Play";

        // Tutorial Button ON
        btnTutoNext.interactable = true;

        // TimeStop, HandChange
        StartCoroutine(TimeStop());

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize(tutorialStep);
        textAnimatorPlayer.ShowText(textBox[5]);
    }

    // ��� �г� �ȳ�
    void Step7()
    {
        textAnimatorPlayer.ShowText(textBox[6]);
    }

    // ��� �г� ����
    void Step8()
    {
        // UI Tutorial OFF
        Singleton<GameManager>.Instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ��ֹ� �г� �ȳ�
    void Step9()
    {
        // ��� �г� Ŭ����
        isMotionClear = true;
        // UI Tutorial ON
        Singleton<GameManager>.Instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());

        textAnimatorPlayer.ShowText(textBox[7]);
    }

    // ��ֹ� �г� ����
    void Step10()
    {
        // UI Tutorial OFF
        Singleton<GameManager>.Instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ��� ���� �г� �ȳ�
    void Step11() 
    {
        // ��ֹ� �г� Ŭ����
        isObstacleClear = true;
        // UI Tutorial ON
        Singleton<GameManager>.Instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[8]);
    }

    // ��� ���� �г� ����
    void Step12() 
    {
        // UI Tutorial OFF
        Singleton<GameManager>.Instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ���� �г� �ȳ�
    void Step13() 
    {
        // ��� ���� �г� Ŭ����
        isMotionQuizClear = true;
        // UI Tutorial ON
        Singleton<GameManager>.Instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[9]);
    }

    // ���� �г� ����
    void Step14() 
    {
        // UI Tutorial OFF
        Singleton<GameManager>.Instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ���â ���
    void Step15() 
    {
        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize(tutorialStep);
        // ���� �г� Ŭ����
        isQuizClear = true;
        // Tutorial Button OFF
        btnTutoNext.interactable = false;
        // UI Tutorial ON
        Singleton<GameManager>.Instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[10]);

        Singleton<GameManager>.Instance.InGameEnd();
        foreach (Transform item in Singleton<GameManager>.Instance.contentOriginal.transform)
            Destroy(item.gameObject);
    }

    // �ɼ� �ȳ� �� ����
    void Step16()
    {
        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize(tutorialStep);

        // Tutorial Button ON
        btnTutoNext.interactable = true;
        textAnimatorPlayer.ShowText(textBox[11]);
    }

    // �ʱ�ȭ �� �κ�
    void Step17()
    {
        Time.timeScale = 1;
        // UI Tutorial OFF
        Singleton<GameManager>.Instance.uiTutorial.SetActive(false);
        // UI Option(Lobby Left UI) ON
        Singleton<GameManager>.Instance.uiLobbyOption.SetActive(true);
        // UI Result(Lobby Right UI) ON
        Singleton<GameManager>.Instance.uiLobbyResult.SetActive(true);
        // Original Theme Select ON
        Singleton<GameManager>.Instance.btnMusicTheme[0].interactable = true;
        // Custom Theme Select ON
        Singleton<GameManager>.Instance.btnMusicTheme[1].interactable = true;
        // Tutorial(Btn) ON
        Singleton<GameManager>.Instance.bgTutorial.SetActive(true);

        tutorialStep = 0;
        tutoPanelSpawnCount = 0;
        tutoPanelDestroyCount = 0;
        tutoPanelTimer = 0;
        isMotionClear = false;
        isObstacleClear = false;
        isMotionQuizClear = false;
        isQuizClear = false;

        isTutorial = false;
        StopCoroutine(TutorialStart());
    }

    // [OnClick] tutorialStep++
    public void TutorialStep()
    {
        if (isTutorial) tutorialStep++;
    }

    // [OnClick] �κ� ---> Ʃ�丮�� ��ư
    public void BtnTuto()
    {
        isTutorial = true;
        Singleton<GameManager>.Instance.music[0].UnPause();
        Singleton<GameManager>.Instance.music[1].Stop();
        StartCoroutine(TutorialStart());
    }

    public IEnumerator TimeStart()
    {
        Time.timeScale = 1;
        Singleton<GameManager>.Instance.music[2].UnPause();
        Singleton<GameManager>.Instance.RayControllerMode(false);
        yield return null;
    }

    public IEnumerator TimeStop()
    {
        Time.timeScale = 0;
        Singleton<GameManager>.Instance.music[2].Pause();
        Singleton<GameManager>.Instance.RayControllerMode(true);
        yield return null;
    }

    public void PanelSpawn()
    {
        Singleton<PanelManager>.Instance.PanelCheck();
        tutoPanelTimer += Time.deltaTime;
        if (tutoPanelTimer > tutoSecPerBeat)
        {
            tutoPanelTimer -= tutoSecPerBeat;

            if (tutoPanelSpawnCount == 0)
            {
                GameObject _motion = Instantiate(tutoPanels[0], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 1)
            {
                GameObject _motion = Instantiate(tutoPanels[1], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 2)
            {
                GameObject _motion = Instantiate(tutoPanels[2], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 3)
            {
                GameObject _block = Instantiate(tutoPanels[3], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _block.name = "BLOCK";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 4)
            {
                GameObject _motion = Instantiate(tutoPanels[4], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _motion.name = "MOTION";
                _motion.transform.GetChild(4).gameObject.SetActive(true);
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 5)
            {
                GameObject _quiz = Instantiate(tutoPanels[5], Singleton<PanelManager>.Instance.panelSpawnPoint);
                _quiz.name = "QUIZ";
                tutoPanelSpawnCount++;
            }
        }
    }
}