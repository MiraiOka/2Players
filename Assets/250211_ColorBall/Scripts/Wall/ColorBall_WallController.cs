using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_WallController : SingletonMonoBehaviour<ColorBall_WallController>
{
    [SerializeField] private GameObject baseWall;
    [SerializeField] private GameObject wallPrefab;

    private void Start()
    {
        SetWall();
    }

    public void SetBaseWallColor(bool isRed)
    {
        if (isRed)
        {
            Renderer[] baseWallsRenderer = baseWall.GetComponentsInChildren<Renderer>();
            foreach (Renderer wall in baseWallsRenderer)
            {
                wall.material.color = Color.red;
            }
        }
        else
        {
            Renderer[] baseWallsRenderer = baseWall.GetComponentsInChildren<Renderer>();
            foreach (Renderer wall in baseWallsRenderer)
            {
                wall.material.color = Color.blue;
            }
        }
    }

    private void SetWall()
    {
        // ランダムに壁を生成する
        for (int i = -5; i < 6; i++)
        {
            for (int j = -5; j < 6; j++)
            {
                if (i == -5 && j == -5) continue;
                if (i == 5 && j == 5) continue;

                if (Random.value > 0.8f)
                {
                    GameObject wall = Instantiate(wallPrefab, new Vector3(i, 1, j), Quaternion.identity);
                }
            }
        }

    }
}
