using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_WallManager : SingletonMonoBehaviour<ColorBall_WallManager>
{
    [SerializeField] private GameObject wallPrefab;

    public void SetWall()
    {
        int gridWidth = (int)ColorBall_StatusManager.Instance.GetGrid().x;
        int gridHeight = (int)ColorBall_StatusManager.Instance.GetGrid().y;
        for (int width = 1; width < gridWidth - 1; width++)
        {
            for (int height = 1; height < gridHeight - 1; height++)
            {
                if (width == 1 && height == 1) continue;
                if (width == gridWidth - 2 && height == gridHeight - 2) continue;

                if (UnityEngine.Random.value > 0.8f)
                {
                    GameObject wall = Instantiate(wallPrefab, new Vector3(width - (gridWidth / 2.0f) + 0.5f, 1, height - (gridHeight / 2.0f) + 0.5f), Quaternion.identity);
                }
            }
        }
    }
}
