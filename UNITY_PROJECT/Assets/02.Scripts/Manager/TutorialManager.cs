/// <summary>
/// TutorialManager.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - Ʃ�丮�� ������ ����ϴ� ��ũ��Ʈ�Դϴ�.
/// - TextAnimatorPlayer Ŭ������ ���� Text Animation ������ ����մϴ�.
/// - TutorialStart() �������̽����� �� �Լ����� yield return new WaitWhile(() => tutorialStep < ?)�� ���ൿ�� ����˴ϴ�.
/// - Tuple���(Vector3, Vector2, Quaternion)���� ���� ���� �޴� XR_TutoCanvasSize() �޼ҵ带 ���� ĵ���� ������� ��ġ, ȸ�� ���� ���� �߽��ϴ�.
/// </summary>

using Febucci.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//public class TutorialManagerTest : MonoBehaviour
//{
//    [Header("[UI]")]
//    public RectTransform xrTutoCanvas;
//    public Button btnTutoNext;
//    public TextAnimatorPlayer textAnimatorPlayer;

//    [Header("[Message]")]
//    public int tutorialDialogNum;
//    public string[] textBox = {
//        "<speed=0.5><rainb f=0.2>�ȳ��ϼ���.</rainb> �ݰ����ϴ�." +
//            "\n���ݺ��� �÷��� ����� �ȳ��ص帮�ڽ��ϴ�.",
//        "<speed=0.5>�Ʒ��� <rainb f=0.2>[��������]</rainb> �׸��� �������ּ���.",
//        "<speed=0.5>�뷡<rainb f=0.2>[Cat Life]</rainb>�� �������ּ���.",
//        "<speed=0.5>���̵� <rainb f=0.2>[����]</rainb>�� �������ּ���.",
//        "<speed=0.5><rainb f=0.2>[�÷���]</rainb> ��ư�� ���� ������ �����մϴ�.",
//        "<speed=0.5><size=7>�������� �����߽��ϴ�." +
//            "\n\n�������� ȹ���� <bounce a=0.3 f=0.3>����</bounce>�� <bounce a=0.3 f=0.3>�Ҹ�� Į�θ�</bounce>�� ǥ�õ˴ϴ�." +
//            "\n���� �Ǵ� ��� �����ϸ� ������ �޺��� �����ϴ�." +
//            "\n���ۿ� �����ϸ� �Ҹ��� �����ϴ�." +
//            "\n\n���� �ϴܿ��� <bounce a=0.3 f=0.3>�ڽ��� ������ Ȯ��</bounce>�� �� �ֽ��ϴ�." +
//            "\n\n�ٴڿ��� <bounce a=0.3 f=0.3>�뷡�� ����</bounce>�� �� �� �ֽ��ϴ�.",
//        "<speed=0.5>��� �г��� �ذ��غ�����.",
//        "<speed=0.5>��ֹ� �г��� ���Խ��ϴ�." +
//            "\n���� �̵��Ͽ� �����ּ���." +
//            "\n�ǰ� �� �޺��� ������ �ҽ��ϴ�.",
//        "<speed=0.5>���� �г��� ���Խ��ϴ�." +
//            "\n��/��� ����� �۱͸� ���� �޽��ϴ�.\n������ �ذ��ϸ鼭 �ܿ��ּ���.",
//        "<speed=0.5>������ ���ߴ� �г��Դϴ�." +
//            "\n�ܿ��� ����� �۱Ͱ� ��ġ�ϴ� ������ �����ϼ���.",
//        "<speed=0.5>�뷡�� �ϼ��ϰ� �Ǹ� ���â�� ǥ�õ˴ϴ�." +
//            "\n�뷡 ����/���̵�/����/�Ҹ�� Į�θ��� �� �� �ֽ��ϴ�." +
//            "\n�������� ���ư��ô�.",
//        "<speed=0.5>���� Ű ������ �κ��� ���ʿ� �ֽ��ϴ�." +
//            "\nƩ�丮���� ��ġ�ڽ��ϴ�." };

//    [Header("[Panel]")]
//    public GameObject[] tutoPanels;
//    public int tutoPanelSpawnCount;
//    public float tutoMoveSpeed = 2.0f;

//    [Header("[Music]")]
//    public float tutoSecPerBeat = 3.5f;
//    public float tutoPanelTimer; // BPM ��� Ÿ�̸�

//    [Header("[�÷��� ����]")]
//    public bool isTutorial;
//    public bool isTutoIngame;
//    public bool isMotionClear;
//    public bool isObstacleClear;
//    public bool isMotionQuizClear;
//    public bool isQuizClear;

//    public static TutorialManager instance;
//    private void Awake()
//    {
//        if (instance == null)
//            instance = this;
//        else
//            Destroy(gameObject);

//        // Reset
//        tutorialDialogNum = 0;
//        isTutoIngame = false;
//        isMotionClear = false;
//        isObstacleClear = false;
//        isMotionQuizClear = false;
//        isQuizClear = false;

//        UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
//        //textAnimatorPlayer.textAnimator.onEvent += OnEvent;
//    }

//    private void FixedUpdate()
//    {
//        if (isTutoIngame)
//        {
//            PanelSpawn();
//        }

//        if (tutorialDialogNum == 0)
//            return;
//        // Opening
//        else if (tutorialDialogNum == 1)
//        {
//            return;
//        }
//        // Select Music Theme(Original)
//        else if (isTutorial && tutorialDialogNum == 2)
//        {
//            GameManager.instance.uiLobby.SetActive(true);
//            GameManager.instance.option.SetActive(false);
//            GameManager.instance.result.SetActive(false);
//            GameManager.instance.btnCustom.interactable = false;
//            btnTutoNext.interactable = false;
//        }
//        // Select to Music in Music List(Cat Life)
//        else if (isTutorial && tutorialDialogNum == 3)
//        {
//            GameManager.instance.btnCustom.interactable = false;
//        }
//        // Select to Level(Easy)
//        else if (isTutorial && tutorialDialogNum == 4)
//        {
//            GameManager.instance.btnEasy.interactable = true;
//            GameManager.instance.btnNormal.interactable = false;
//            GameManager.instance.btnHard.interactable = false;
//            GameManager.instance.contentOriginal.transform.GetChild(0).GetComponent<Button>().interactable = false;
//        }
//        // Play
//        else if (isTutorial && tutorialDialogNum == 5)
//        {
//            GameManager.instance.btnEasy.interactable = false;
//            GameManager.instance.btnNormal.interactable = false;
//            GameManager.instance.btnHard.interactable = false;
//        }
//        // �ΰ��� ��� ����
//        else if (isTutorial && tutorialDialogNum == 6)
//        {
//            btnTutoNext.interactable = true;
//        }
//        // Motion Panel(x3)
//        else if (isTutorial && tutorialDialogNum == 7)
//        {

//        }
//        // Obstacle Panel �ȳ�
//        else if (isTutorial && tutorialDialogNum == 8 && isMotionClear)
//        {
//            StartCoroutine(TimeStop());
//            ShowText();
//        }
//        // Motion Quiz Panel
//        else if (isTutorial && tutorialDialogNum == 9)
//        {
//        }
//        // Quiz Answer Panel
//        else if (isTutorial && tutorialDialogNum == 10)
//        {
//        }
//    }

//    public (Vector3, Vector2, Quaternion) XR_TutoCanvasSize()
//    {
//        if (tutorialDialogNum == 0) return (new Vector3(0f, 2f, 1f), new Vector2(200f, 50f), Quaternion.Euler(10f, 0f, 0f));
//        else if (tutorialDialogNum == 1) return (new Vector3(0f, 2.65f, 1f), new Vector2(150f, 20f), Quaternion.Euler(0f, 0f, 0f));
//        else if (tutorialDialogNum == 5) return (new Vector3(0f, 2.25f, 1f), new Vector2(200f, 110f), Quaternion.Euler(0f, 0f, 0f));
//        else return (new Vector3(0f, 0f, 0f), new Vector2(0f, 0f), Quaternion.identity);
//    }

//    public void TutorialDialogNum()
//    {
//        tutorialDialogNum++;
//    }

//    public void ShowText()
//    {
//        // Opening
//        if (tutorialDialogNum == 0)
//        {
//            (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // Select Music Theme(Original)
//        else if (tutorialDialogNum == 1)
//        {
//            (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // Select to Music in Music List(Cat Life)
//        else if (tutorialDialogNum == 2)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // Select to Level(Easy)
//        else if (tutorialDialogNum == 3)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // Play
//        else if (tutorialDialogNum == 4)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // �ΰ��� ��� ����
//        else if (tutorialDialogNum == 5)
//        {
//            (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            StartCoroutine(TimeStop());
//            isTutoIngame = true;

//            tutorialDialogNum++;
//        }
//        // Motion Panel(x3) �ȳ�
//        else if (tutorialDialogNum == 6 && isTutoIngame)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // ��� �г� Ʃ�丮�� ����
//        // tutorialDialogNum == 7���� �г�3�� �����Ѵ�. ---> tutorialDialogNum == 8 && isMotionClear �̸� �ڷ�ƾ �ð� ��ž, ShowText()
//        else if (tutorialDialogNum == 7 && isTutoIngame)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            StartCoroutine(TimeStart());

//            tutorialDialogNum++;
//        }

//        // Obstacle Panel �ȳ�
//        // Motion Quiz Panel
//        // isObstacleClear
//        else if (tutorialDialogNum == 8 && isTutoIngame)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//        // Quiz Answer Panel
//        else if (tutorialDialogNum == 9 && isTutoIngame)
//        {
//            textAnimatorPlayer.ShowText(textBox[tutorialDialogNum]);

//            tutorialDialogNum++;
//        }
//    }

//    // [OnClick] �κ� ---> Ʃ�丮�� ��ư
//    public void BtnTuto()
//    {
//        isTutorial = true;
//    }

//    // [Onclick] �������� ��ư Ŭ��
//    public void TutorialListRenewal()
//    {
//        if (isTutorial)
//        {
//            object tutorialMusic = Resources.Load<AudioClip>("Original Music/Cat life");
//            GameObject tutorialMusicElementPrefab = tutorialMusic as GameObject;
//            tutorialMusicElementPrefab = Instantiate(GameManager.instance.musicElement, GameManager.instance.contentOriginal.transform.position, GameManager.instance.contentOriginal.transform.rotation);
//            tutorialMusicElementPrefab.name = "Tutorial Music Element";
//            tutorialMusicElementPrefab.transform.parent = GameManager.instance.contentOriginal.transform;
//            tutorialMusicElementPrefab.transform.localScale = Vector3.one;

//            // AudioSource.clip �� Resources-Custom Musics.AudioClip
//            tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip = (AudioClip)tutorialMusic;
//            // (float)MusicLength to (string)PlayTime
//            tutorialMusicElementPrefab.transform.GetChild(2).gameObject.GetComponent<Text>().text = GameManager.instance.TimeFormatter(tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip.length, false);
//            // textTitle.text �� customMusicElements.AudioSource.text
//            tutorialMusicElementPrefab.transform.GetChild(1).gameObject.GetComponent<Text>().text = tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip.name;
//        }
//    }

//    // [OnClick] �ΰ��� ����
//    public void BtnTutoPlay()
//    {
//        if (isTutorial)
//        {
//            GameManager.instance.isHandChange = false;
//        }
//    }

//    public IEnumerator TimeStart()
//    {
//        yield return null;
//        Time.timeScale = 1;
//        GameManager.instance.musicPlayed.UnPause();
//        GameManager.instance.isHandChange = true;
//        GameManager.instance.ControllerModeChange();
//    }

//    public IEnumerator TimeStop()
//    {
//        yield return null;
//        Time.timeScale = 0;
//        GameManager.instance.musicPlayed.Pause();
//        GameManager.instance.isHandChange = false;
//        GameManager.instance.ControllerModeChange();
//    }

//    public void PanelSpawn()
//    {
//        PanelManager.instance.PanelCheck();
//        tutoPanelTimer += Time.deltaTime;
//        if (tutoPanelTimer > tutoSecPerBeat)
//        {
//            tutoPanelTimer -= tutoSecPerBeat;

//            if (tutoPanelSpawnCount == 0)
//            {
//                GameObject _motion = Instantiate(tutoPanels[0], PanelManager.instance.panelSpawnPoint);
//                _motion.name = "MOTION";
//                tutoPanelSpawnCount++;
//            }
//            else if (tutoPanelSpawnCount == 1)
//            {
//                GameObject _motion = Instantiate(tutoPanels[1], PanelManager.instance.panelSpawnPoint);
//                _motion.name = "MOTION";
//                tutoPanelSpawnCount++;
//            }
//            else if (tutoPanelSpawnCount == 2)
//            {
//                GameObject _motion = Instantiate(tutoPanels[2], PanelManager.instance.panelSpawnPoint);
//                _motion.name = "MOTION";
//                tutoPanelSpawnCount++;
//            }
//            else if (tutoPanelSpawnCount == 3)
//            {
//                GameObject _block = Instantiate(tutoPanels[3], PanelManager.instance.panelSpawnPoint);
//                _block.name = "BLOCK";
//                tutoPanelSpawnCount++;
//            }
//            else if (tutoPanelSpawnCount == 4)
//            {
//                GameObject _motion = Instantiate(tutoPanels[4], PanelManager.instance.panelSpawnPoint);
//                _motion.name = "MOTION";
//                _motion.transform.GetChild(4).gameObject.SetActive(true);
//                tutoPanelSpawnCount++;
//            }
//            else if (tutoPanelSpawnCount == 5)
//            {
//                Debug.Log("���� �г� ����");
//                GameObject _quiz = Instantiate(tutoPanels[5], PanelManager.instance.panelSpawnPoint);
//                _quiz.name = "QUIZ";
//                tutoPanelSpawnCount++;
//            }
//        }
//    }

//    //void OnEvent(string text)
//    //{
//    //    switch (text)
//    //    {
//    //        case "bg":
//    //            break;
//    //    }
//    //}
//}

public class TutorialManager : MonoBehaviour
{
    [Header("[UI]")]
    public RectTransform xrTutoCanvas;
    public Button btnTutoNext;
    public TextAnimatorPlayer textAnimatorPlayer;

    [Header("[Message]")]
    public int tutorialStep;
    public string[] textBox = {
        "<speed=0.5><rainb f=0.2>�ȳ��ϼ���.</rainb> �ݰ����ϴ�." +
            "\n���ݺ��� �÷��� ����� �ȳ��ص帮�ڽ��ϴ�.",
        "<speed=0.5>�Ʒ��� <rainb f=0.2>[��������]</rainb> �׸��� �������ּ���.",
        "<speed=0.5>�뷡<rainb f=0.2>[Cat Life]</rainb>�� �������ּ���.",
        "<speed=0.5>���̵� <rainb f=0.2>[����]</rainb>�� �������ּ���.",
        "<speed=0.5><rainb f=0.2>[�÷���]</rainb> ��ư�� ���� ������ �����մϴ�.",
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

    public static TutorialManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        // Reset
        tutorialStep = 0;
        isMotionClear = false;
        isObstacleClear = false;
        isMotionQuizClear = false;
        isQuizClear = false;

        UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
        //textAnimatorPlayer.textAnimator.onEvent += OnEvent;
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

    public (Vector3, Vector2, Quaternion) XR_TutoCanvasSize()
    {
        if      (tutorialStep == 0)
            return (new Vector3(0f, 2f, 1f), new Vector2(200f, 50f), Quaternion.Euler(10f, 0f, 0f));
        else if (tutorialStep == 1)
            return (new Vector3(0f, 2.65f, 1f), new Vector2(150f, 20f), Quaternion.Euler(0f, 0f, 0f));
        else if (tutorialStep == 5)
            return (new Vector3(0f, 2.25f, 1f), new Vector2(200f, 110f), Quaternion.Euler(0f, 0f, 0f));
        else if (tutorialStep == 14)
            return (new Vector3(0f, 2.9f, 0.9f), new Vector2(220f, 70f), Quaternion.Euler(-15f, 0f, 0f));
        else if (tutorialStep == 15)
            return (new Vector3(0f, 2.7f, 1f), new Vector2(180f, 40f), Quaternion.Euler(-10f, 0f, 0f));
        else
            return (new Vector3(0f, 0f, 0f), new Vector2(0f, 0f), Quaternion.identity);
    }

    // Ʃ�丮�� ���� �ȳ�
    void Step1()
    {
        GameManager.instance.uiTutorial.SetActive(true);
        GameManager.instance.uiLobby.SetActive(false);

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
        textAnimatorPlayer.ShowText(textBox[0]);
    }

    // Theme(Original) ����
    void Step2()
    {
        // Tutorial Button OFF
        btnTutoNext.interactable = false;
        // UI Lobby ON
        GameManager.instance.uiLobby.SetActive(true);
        // UI Option(Lobby Left UI) OFF
        GameManager.instance.option.SetActive(false);
        // UI Result(Lobby Right UI) OFF
        GameManager.instance.result.SetActive(false);
        // Original Theme Select ON
        GameManager.instance.btnOriginal.interactable = true;
        // Custom Theme Select OFF
        GameManager.instance.btnCustom.interactable = false;
        // Easy OFF
        GameManager.instance.btnEasy.interactable = false;
        // Normal OFF
        GameManager.instance.btnNormal.interactable = false;
        // Hard OFF
        GameManager.instance.btnHard.interactable = false;
        // Play OFF
        GameManager.instance.btnPlay.interactable = false;

        foreach (Transform item in GameManager.instance.contentOriginal.transform) Destroy(item.gameObject);

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
        textAnimatorPlayer.ShowText(textBox[1]);
    }

    // Music(Cat Life) ����
    void Step3()
    {
        // Custom Theme Select OFF
        GameManager.instance.btnCustom.interactable = false;

        textAnimatorPlayer.ShowText(textBox[2]);
    }

    // Level(Easy) ����
    void Step4()
    {
        // Easy ON
        GameManager.instance.btnEasy.interactable   = true;
        // Normal OFF
        GameManager.instance.btnNormal.interactable = false;
        // Hard OFF
        GameManager.instance.btnHard.interactable   = false;
        // Music Element OFF
        GameManager.instance.contentOriginal.transform.GetChild(0).GetComponent<Button>().interactable = false;

        textAnimatorPlayer.ShowText(textBox[3]);
    }

    // Play ��ư �ȳ�
    void Step5()
    {
        // Easy OFF
        GameManager.instance.btnEasy.interactable = false;
        // Normal OFF
        GameManager.instance.btnNormal.interactable = false;
        // Hard OFF
        GameManager.instance.btnHard.interactable = false;

        textAnimatorPlayer.ShowText(textBox[4]);
    }

    // �ΰ��� ��� ����
    void Step6() 
    {
        // Tutorial Button ON
        btnTutoNext.interactable = true;

        // TimeStop, HandChange
        StartCoroutine(TimeStop());

        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
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
        GameManager.instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ��ֹ� �г� �ȳ�
    void Step9()
    {
        // ��� �г� Ŭ����
        isMotionClear = true;
        // UI Tutorial ON
        GameManager.instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());

        textAnimatorPlayer.ShowText(textBox[7]);
    }

    // ��ֹ� �г� ����
    void Step10()
    {
        // UI Tutorial OFF
        GameManager.instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ��� ���� �г� �ȳ�
    void Step11() 
    {
        // ��ֹ� �г� Ŭ����
        isObstacleClear = true;
        // UI Tutorial ON
        GameManager.instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[8]);
    }

    // ��� ���� �г� ����
    void Step12() 
    {
        // UI Tutorial OFF
        GameManager.instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ���� �г� �ȳ�
    void Step13() 
    {
        // ��� ���� �г� Ŭ����
        isMotionQuizClear = true;
        // UI Tutorial ON
        GameManager.instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[9]);
    }

    // ���� �г� ����
    void Step14() 
    {
        // UI Tutorial OFF
        GameManager.instance.uiTutorial.SetActive(false);
        // TimeStart, HandChange
        StartCoroutine(TimeStart());
    }

    // ���â ���
    void Step15() 
    {
        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();
        // ���� �г� Ŭ����
        isQuizClear = true;
        // Tutorial Button OFF
        btnTutoNext.interactable = false;
        // UI Tutorial ON
        GameManager.instance.uiTutorial.SetActive(true);
        // TimeStop, HandChange
        StartCoroutine(TimeStop());
        textAnimatorPlayer.ShowText(textBox[10]);

        GameManager.instance.InGameEnd();
        foreach (Transform item in GameManager.instance.contentOriginal.transform) Destroy(item.gameObject);
    }

    // �ɼ� �ȳ� �� ����
    void Step16()
    {
        (xrTutoCanvas.transform.position, xrTutoCanvas.sizeDelta, xrTutoCanvas.transform.rotation) = XR_TutoCanvasSize();

        // Tutorial Button ON
        btnTutoNext.interactable = true;
        textAnimatorPlayer.ShowText(textBox[11]);
    }

    // �ʱ�ȭ �� �κ�
    void Step17()
    {
        Time.timeScale = 1;
        // UI Tutorial OFF
        GameManager.instance.uiTutorial.SetActive(false);
        // UI Option(Lobby Left UI) ON
        GameManager.instance.option.SetActive(true);
        // UI Result(Lobby Right UI) ON
        GameManager.instance.result.SetActive(true);
        // Original Theme Select ON
        GameManager.instance.btnOriginal.interactable = true;
        // Custom Theme Select ON
        GameManager.instance.btnCustom.interactable = true;

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
        if (isTutorial)
            tutorialStep++;
    }

    // [OnClick] �κ� ---> Ʃ�丮�� ��ư
    public void BtnTuto()
    {
        isTutorial = true;
        GameManager.instance.musicBackGround.UnPause();
        GameManager.instance.musicSelected.Stop();
        StartCoroutine(TutorialStart());
    }

    // [Onclick] �������� ��ư Ŭ��
    public void TutorialListRenewal()
    {
        if (isTutorial)
        {
            foreach (Transform item in GameManager.instance.contentOriginal.transform) Destroy(item.gameObject);

            object tutorialMusic = Resources.Load<AudioClip>("Original Music/Cat life");
            GameObject tutorialMusicElementPrefab = tutorialMusic as GameObject;
            tutorialMusicElementPrefab = Instantiate(GameManager.instance.musicElement, GameManager.instance.contentOriginal.transform.position, GameManager.instance.contentOriginal.transform.rotation);
            tutorialMusicElementPrefab.name = "Tutorial Music Element";
            tutorialMusicElementPrefab.transform.parent = GameManager.instance.contentOriginal.transform;
            tutorialMusicElementPrefab.transform.localScale = Vector3.one;

            // AudioSource.clip �� Resources-Custom Musics.AudioClip
            tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip = (AudioClip)tutorialMusic;
            // (float)MusicLength to (string)PlayTime
            tutorialMusicElementPrefab.transform.GetChild(2).gameObject.GetComponent<Text>().text = GameManager.instance.TimeFormatter(tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip.length, false);
            // textTitle.text �� customMusicElements.AudioSource.text
            tutorialMusicElementPrefab.transform.GetChild(1).gameObject.GetComponent<Text>().text = tutorialMusicElementPrefab.transform.GetChild(3).gameObject.GetComponent<AudioSource>().clip.name;
        }
    }

    public IEnumerator TimeStart()
    {
        Time.timeScale = 1;
        GameManager.instance.musicPlayed.UnPause();
        GameManager.instance.isHandChange = true;
        GameManager.instance.ControllerModeChange();
        yield return null;
    }

    public IEnumerator TimeStop()
    {
        Time.timeScale = 0;
        GameManager.instance.musicPlayed.Pause();
        GameManager.instance.isHandChange = false;
        GameManager.instance.ControllerModeChange();
        yield return null;
    }

    public void PanelSpawn()
    {
        PanelManager.instance.PanelCheck();
        tutoPanelTimer += Time.deltaTime;
        if (tutoPanelTimer > tutoSecPerBeat)
        {
            tutoPanelTimer -= tutoSecPerBeat;

            if (tutoPanelSpawnCount == 0)
            {
                GameObject _motion = Instantiate(tutoPanels[0], PanelManager.instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 1)
            {
                GameObject _motion = Instantiate(tutoPanels[1], PanelManager.instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 2)
            {
                GameObject _motion = Instantiate(tutoPanels[2], PanelManager.instance.panelSpawnPoint);
                _motion.name = "MOTION";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 3)
            {
                GameObject _block = Instantiate(tutoPanels[3], PanelManager.instance.panelSpawnPoint);
                _block.name = "BLOCK";
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 4)
            {
                GameObject _motion = Instantiate(tutoPanels[4], PanelManager.instance.panelSpawnPoint);
                _motion.name = "MOTION";
                _motion.transform.GetChild(4).gameObject.SetActive(true);
                tutoPanelSpawnCount++;
            }
            else if (tutoPanelSpawnCount == 5)
            {
                Debug.Log("���� �г� ����");
                GameObject _quiz = Instantiate(tutoPanels[5], PanelManager.instance.panelSpawnPoint);
                _quiz.name = "QUIZ";
                tutoPanelSpawnCount++;
            }
        }
    }
}