using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_ScoreManager : SingletonMonoBehaviour<ColorBall_ScoreManager>
{
    private int redScore = 0;
    private int blueScore = 0;

    public void CalcScore()
    {
        redScore = 0;
        blueScore = 0;
        for (int i = 0; i < ColorBall_StatusManager.Instance.GetGrid().x; i++)
        {
            for (int j = 0; j < ColorBall_StatusManager.Instance.GetGrid().y; j++)
            {
                if (ColorBall_StatusManager.Instance.GetGridType(i, j) == ColorBall_StatusManager.GridType.RedTile)
                {
                    redScore++;
                }
                else if (ColorBall_StatusManager.Instance.GetGridType(i, j) == ColorBall_StatusManager.GridType.BlueTile)
                {
                    blueScore++;
                }
            }
        }
        ColorBall_ScoreView view = this.gameObject.GetComponent<ColorBall_ScoreView>();
        view.SetScore(redScore, blueScore);
    }
}
