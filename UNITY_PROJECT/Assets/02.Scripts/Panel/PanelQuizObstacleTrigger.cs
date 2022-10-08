/// <summary>
/// PanelQuizObstacleTrigger.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// - �ڵ� ��Ʈ�ѷ� ������Ʈ�� ����� ��ũ��Ʈ
/// - ������ ���� ���⿡ ���� ����/���� ó��(SFX, +-Score, Combo)
/// - ��ֹ� ���� Ʈ���� ������ ���� ������ �϶� / �޺� ����
/// </summary>

using UnityEngine;
using UnityEngine.Events;

public class PanelQuizObstacleTrigger : MonoBehaviour
{
    public UnityEvent _SFX_Quiz_Currect;
    public UnityEvent _SFX_Quiz_Fail;

    private void OnTriggerEnter(Collider c)
    {
        if (PanelManager.instance.isCurLeft)
        {
            if (c.gameObject.tag == "QUIZ LEFT")
            {
                _SFX_Quiz_Currect?.Invoke();
                GameManager.instance.score += 10000;
                ScoreManager.instance.SetScore();
                ComboManager.instance.IncreaseCombo();
                PanelManager.instance.isCurLeft = false;
                Destroy(c.gameObject.transform.parent.gameObject);
                if (TutorialManager.instance.isTutorial)
                    TutorialManager.instance.tutoPanelDestroyCount++;
            }
            else if (c.gameObject.tag == "QUIZ RIGHT")
            {
                _SFX_Quiz_Fail?.Invoke();
                if (GameManager.instance.score > 0)
                {
                    GameManager.instance.score -= 10000;
                    ScoreManager.instance.SetScore();
                }
                PanelManager.instance.isCurLeft = false;
                ComboManager.instance.Clear();
            }
        }
        if (PanelManager.instance.isCurRight)
        {
            if (c.gameObject.tag == "QUIZ LEFT")
            {
                _SFX_Quiz_Fail?.Invoke();
                if (GameManager.instance.score > 0)
                {
                    GameManager.instance.score -= 10000;
                    ScoreManager.instance.SetScore();
                }
                PanelManager.instance.isCurRight = false;
                ComboManager.instance.Clear();
            }
            else if (c.gameObject.tag == "QUIZ RIGHT")
            {
                _SFX_Quiz_Currect?.Invoke();
                GameManager.instance.score += 10000;
                ScoreManager.instance.SetScore();
                ComboManager.instance.IncreaseCombo();
                PanelManager.instance.isCurRight = false;
                Destroy(c.gameObject.transform.parent.gameObject);
                if (TutorialManager.instance.isTutorial)
                    TutorialManager.instance.tutoPanelDestroyCount++;
            }
        }
    }

    private void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "BLOCK")
        {
            if (GameManager.instance.score > 0)
            {
                GameManager.instance.score -= 100;
                ScoreManager.instance.SetScore();
            }
            ComboManager.instance.Clear();
        }
    }
}