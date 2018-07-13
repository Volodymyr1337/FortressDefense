using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WinLoseModalWindow : MonoBehaviour
{
    [SerializeField] private Image titleLabel;
    [SerializeField] private Image starsImg;

    [SerializeField] private Sprite winTitle;
    [SerializeField] private Sprite loseTitle;
    [SerializeField] private Sprite[] stars;

    [SerializeField] private Text scoreLabel;

    [SerializeField] private Slider scoreBar;
    public static event Action OnOkBtnPressed;
    private LevelModel levelModel;

    public void InitializeWindow(bool won, LevelModel levelModel)
    {
        if (won)
            titleLabel.sprite = winTitle;
        else
            titleLabel.sprite = loseTitle;

        this.levelModel = levelModel;

        int starCount = Mathf.CeilToInt(stars.Length * levelModel.CurrentScore / (float)levelModel.MaxScore) - 1;
        if (starCount < 0) starCount = 0;
        if (starCount >= stars.Length) starCount = stars.Length - 1;
        if (won)
            starsImg.sprite = stars[starCount];
        else
            starsImg.sprite = stars[0];

        scoreBar.maxValue = levelModel.MaxScore;
        scoreBar.value = levelModel.CurrentScore;

        scoreLabel.text = levelModel.CurrentScore.ToString();
    }

    public void OkButton()
    {
        CloseWindow();
    }

    public void CloseWindow()
    {
        OnOkBtnPressed?.Invoke();
        Destroy(this.gameObject);
    }
}
