using Febucci.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public RectTransform xrTutoCanvas;
    public Button btnTutoNext;
    public TextAnimatorPlayer textAnimatorPlayer;

    public int tutorialDialogNum;
    public string[] textBox = {
        "<speed=0.5><rainb f=0.2>�ȳ��ϼ���.</rainb> �ݰ����ϴ�." +
            "\n���ݺ��� �÷��� ����� �ȳ��ص帮�ڽ��ϴ�.",
        "<speed=0.5>�Ʒ��� Original �׸��� �������ּ���.",
        "<speed=0.5>�뷡<rainb f=0.2>[Cat Life]</rainb>�� �������ּ���.",
        "<speed=0.5>���̵� <rainb f=0.2>[����]</rainb>�� �������ּ���.",
        "<speed=0.5><rainb f=0.2>�÷���</rainb> ��ư�� ���� ������ �����մϴ�.",
        "<speed=0.5><size=7>�������� �����߽��ϴ�." +
            "\n\n�������� ȹ���� <bounce a=0.3 f=0.3>����</bounce>�� <bounce a=0.3 f=0.3>�Ҹ�� Į�θ�</bounce>�� ǥ�õ˴ϴ�." +
            "\n���� �Ǵ� ��� �����ϸ� ������ �޺��� �����ϴ�." +
            "\n���ۿ� �����ϸ� �Ҹ��� �����ϴ�." +
            "\n\n�������� <bounce a=0.3 f=0.3>�ڽ��� ������ Ȯ��</bounce>�� �� �ֽ��ϴ�." +
            "\n\n�ϴܿ��� <bounce a=0.3 f=0.3>�뷡�� ����</bounce>�� �� �� �ֽ��ϴ�.",
        "<speed=0.5>��� ��� �г��� �ذ��غ�����.",
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

    public bool isTutoLobby;
    public bool isTutoStart;

    public static TutorialManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        tutorialDialogNum = 0;
        UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
        //textAnimatorPlayer.textAnimator.onEvent += OnEvent;
    }

    public GameObject[] tutoPanels;
    public int tutoPanelSpawnCount;
    public float tutoMoveSpeed = 2.0f;

    public float tutoSecPerBeat = 3.5f;
    public float tutoPanelTimer; // BPM ��� Ÿ�̸�

    private void FixedUpdate()
    {
        if (tutorialDialogNum == 0)
        {

        }
        else if (tutorialDialogNum == 1)
        {
            GameManager.instance.uiLobby.SetActive(true);
            GameManager.instance.option.SetActive(false);
            GameManager.instance.result.SetActive(false);
            GameManager.instance.btnCustom.interactable = false;
            btnTutoNext.interactable = false;
        }
        else if (tutorialDialogNum == 2)
        {
            GameManager.instance.btnCustom.interactable = false;
        }
        else if (tutorialDialogNum == 3)
        {
            return;
        }
        else if (tutorialDialogNum == 4)
        {
            GameManager.instance.btnEasy.interactable = false;
            GameManager.instance.btnNormal.interactable = false;
            GameManager.instance.btnHard.interactable = false;
            GameManager.instance.contentOriginal.transform.GetChild(0).GetComponent<Button>().interactable = false;
        }
        else if (tutorialDialogNum == 5)
        {
            btnTutoNext.interactable = true;
        }
        else if (tutorialDialogNum == 6)
        {
            MotionPanelSpawn();
        }
        else if (tutorialDialogNum == 7)
        {
            MotionPanelSpawn();
        }
        else if (tutorialDialogNum == 8)
        {
            MotionPanelSpawn();
        }
        else if (tutorialDialogNum == 9)
        {
            MotionPanelSpawn();
        }
    }

    public void ShowText()
    {
        // Opening
        if (tutorialDialogNum == 0)
        {
            xrTutoCanvas.transform.position = new Vector3(0, 2f, 1);
            xrTutoCanvas.sizeDelta = new Vector2(200, 50);
            xrTutoCanvas.transform.rotation = Quaternion.Euler(10, 0, 0);

            textAnimatorPlayer.ShowText(textBox[0]);
            tutorialDialogNum++;
        }
        // Select Music Theme
        else if (tutorialDialogNum == 1)
        {
            xrTutoCanvas.transform.position = new Vector3(0, 2.65f, 1);
            xrTutoCanvas.sizeDelta = new Vector2(150, 20);
            xrTutoCanvas.transform.rotation = Quaternion.Euler(0, 0, 0);

            textAnimatorPlayer.ShowText(textBox[1]);
            tutorialDialogNum++;
        }
        // Select to Music in Music List
        else if (tutorialDialogNum == 2)
        {
            textAnimatorPlayer.ShowText(textBox[2]);
            tutorialDialogNum++;
        }
        // Select to Level
        else if (tutorialDialogNum == 3)
        {
            textAnimatorPlayer.ShowText(textBox[3]);
            tutorialDialogNum++;
        }
        // Play
        else if (tutorialDialogNum == 4)
        {
            textAnimatorPlayer.ShowText(textBox[4]);
            tutorialDialogNum++;
        }
        // �ΰ��� ��� ����
        else if (tutorialDialogNum == 5)
        {
            xrTutoCanvas.transform.position = new Vector3(0, 2.25f, 1);
            xrTutoCanvas.sizeDelta = new Vector2(200, 110);
            xrTutoCanvas.transform.rotation = Quaternion.Euler(0, 0, 0);

            textAnimatorPlayer.ShowText(textBox[5]);
            tutorialDialogNum++;
        }
        // Motion Panel(x3)
        else if (tutorialDialogNum == 6)
        {
            textAnimatorPlayer.ShowText(textBox[6]);
            tutorialDialogNum++;

            StartCoroutine(TimeStart());
        }
        // Obstacle Panel
        else if (tutorialDialogNum == 7)
        {
            textAnimatorPlayer.ShowText(textBox[7]);
            tutorialDialogNum++;

            StartCoroutine(TimeStart());
        }
        // Motion Quiz Panel
        else if (tutorialDialogNum == 8)
        {
            textAnimatorPlayer.ShowText(textBox[8]);
            tutorialDialogNum++;

            StartCoroutine(TimeStart());
        }
        // Quiz Answer Panel
        else if (tutorialDialogNum == 9)
        {
            textAnimatorPlayer.ShowText(textBox[9]);
            tutorialDialogNum++;

            StartCoroutine(TimeStart());
        }
    }

    // [OnClick] �κ� ---> Ʃ�丮�� ��ư
    public void BtnTuto()
    {
        isTutoLobby = true;
    }

    // [Onclick] �������� ��ư Ŭ��
    public void TutorialListRenewal()
    {
        if (isTutoLobby)
        {
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

    // [OnClick] �ΰ��� ����
    public void BtnTutoPlay()
    {
        if (isTutoLobby)
        {
            GameManager.instance.isHandChange = false;
        }
    }

    public IEnumerator TimeStart()
    {
        yield return null;
        Time.timeScale = 1;
        GameManager.instance.musicPlayed.UnPause();
        GameManager.instance.isHandChange = true;
        GameManager.instance.ControllerModeChange();
    }

    public IEnumerator TimeStop()
    {
        yield return null;
        Time.timeScale = 0;
        GameManager.instance.musicPlayed.Pause();
        GameManager.instance.isHandChange = false;
        GameManager.instance.ControllerModeChange();
    }

    public void MotionPanelSpawn()
    {
        if (6 <= tutorialDialogNum && tutorialDialogNum >= 9)
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

    //void OnEvent(string text)
    //{
    //    switch (text)
    //    {
    //        case "bg":
    //            break;
    //    }
    //}
}