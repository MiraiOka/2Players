using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_BaseWallManager : SingletonMonoBehaviour<ColorBall_BaseWallManager>
{
    [SerializeField] private GameObject baseWallPrefab;

    public void CreateBaseWall()
    {
        int gridWidth = (int)ColorBall_GridStatusManager.Instance.GetGrid().x;
        int gridHeight = (int)ColorBall_GridStatusManager.Instance.GetGrid().y;
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                if (i == 0 || i == gridWidth - 1 || j == 0 || j == gridHeight - 1)
                {
                    GameObject baseWall = Instantiate(baseWallPrefab, new Vector3(i - (gridWidth / 2.0f) + 0.5f, 1, j - (gridHeight / 2.0f) + 0.5f), Quaternion.identity);
                    baseWall.transform.SetParent(transform);
                    ColorBall_BaseWallView view = baseWall.AddComponent<ColorBall_BaseWallView>();
                    view.SetBaseWallColor();
                    ColorBall_GridStatusManager.Instance.SetGridType(i, j, ColorBall_GridStatusManager.GridType.Wall);
                    continue;
                }
            }
        }
    }

    public void ChangeBaseWallColor()
    {
        foreach (Transform child in transform)
        {
            ColorBall_BaseWallView view = child.GetComponent<ColorBall_BaseWallView>();
            view.SetBaseWallColor();
        }
    }
}