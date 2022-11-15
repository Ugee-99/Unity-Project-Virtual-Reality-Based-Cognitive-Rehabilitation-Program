/// <summary>
/// PanelQuizObstacleTrigger.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (V-Light Stutio)
/// This software is released under the GPL-2.0 license
/// 
/// - �ڵ� ��Ʈ�ѷ� ������Ʈ�� ����� ��ũ��Ʈ
/// - ������ ���� ���⿡ ���� ����/���� ó��(SFX, +-Score, Combo)
/// - ��ֹ� ���� Ʈ���� ������ ���� ������ �϶� / �޺� ����
/// </summary>

using UnityEngine;

public class PanelQuizObstacleTrigger : MonoBehaviour
{
    void Currect(Collider c)
    {
        // SFX(Currect)
        Singleton<GameManager>.Instance.sFX[1].Play();
        ScoreManaged.SetScore(Singleton<GameManager>.Instance.score += 10000);
        Singleton<ComboManager>.Instance.IncreaseCombo();
        Singleton<PanelManager>.Instance.isCurLeft = false;
        Destroy(c.gameObject.transform.parent.gameObject);
        if (Singleton<TutorialManager>.Instance.isTutorial)
        {
            Singleton<TutorialManager>.Instance.tutoPanelDestroyCount++;
        }
    }

    void Fail()
    {
        // SFX(Fail)
        Singleton<GameManager>.Instance.sFX[2].Play();
        if (Singleton<GameManager>.Instance.score > 0)
        {
            ScoreManaged.SetScore(Singleton<GameManager>.Instance.score -= 10000);
            if (Singleton<GameManager>.Instance.score < 0)
            {
                ScoreManaged.SetScore(Singleton<GameManager>.Instance.score = 0);
            }
        }
        Singleton<PanelManager>.Instance.isCurLeft = false;
        Singleton<ComboManager>.Instance.Clear();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (Singleton<GameManager>.Instance.isStart)
        {
            if (Singleton<PanelManager>.Instance.isCurLeft)
            {
                if (c.gameObject.tag == "QUIZ LEFT")  Currect(c);
                if (c.gameObject.tag == "QUIZ RIGHT") Fail();
            }
            if (Singleton<PanelManager>.Instance.isCurRight)
            {
                if (c.gameObject.tag == "QUIZ LEFT")  Fail();
                if (c.gameObject.tag == "QUIZ RIGHT") Currect(c);
            }
        }
    }

    private void OnTriggerStay(Collider c)
    {
        if (Singleton<GameManager>.Instance.isStart)
        {
            if (c.gameObject.tag == "BLOCK")
            {
                if (Singleton<GameManager>.Instance.score > 0)
                {
                    ScoreManaged.SetScore(Singleton<GameManager>.Instance.score -= 100);
                }
                Singleton<ComboManager>.Instance.Clear();
            }
        }
    }
}