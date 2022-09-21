/// <summary>
/// ScoreManager.cs
/// Copyright (c) 2022 VR-Based Cognitive Rehabilitation Program (Eternal Light)
/// This software is released under the GPL-2.0 license
/// 
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text textScore;
    public Text textKcal;

    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (GameManager.instance.isStart)
        {
            SetScore();
            SetKcal();
        }
    }

    public IEnumerator Increase()
    {
        yield return null;

        ComboManager.instance.IncreaseCombo();

        if (0 <= ComboManager.instance.combo && ComboManager.instance.combo < 5)
        {
            GameManager.instance.score += 1000;
            SetScore();
        }
        else if /*x2*/ (5 <= ComboManager.instance.combo && ComboManager.instance.combo < 10)
        {
            GameManager.instance.score += 2000;
            SetScore();
        }
        else if /*x4*/ (10 <= ComboManager.instance.combo && ComboManager.instance.combo < 15)
        {
            GameManager.instance.score += 4000;
            SetScore();
        }
        else if /*x8*/ (15 <= ComboManager.instance.combo)
        {
            GameManager.instance.score += 8000;
            SetScore();
        }

        GameManager.instance.kcal += Random.Range(0.1f, 0.2f);
        SetKcal();

        yield break;
    }

    public void SetScore()
    {
        textScore.text = GameManager.instance.score.ToString();
    }

    public void SetKcal()
    {
        textKcal.text  = GameManager.instance.kcal.ToString("F2");
    }
}