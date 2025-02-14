using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_TileManager : SingletonMonoBehaviour<ColorBall_TileManager>
{
    [SerializeField] private GameObject cubePrefab;

    public void CreateBaseTile()
    {
        int gridWidth = (int)ColorBall_StatusManager.Instance.GetGrid().x;
        int gridHeight = (int)ColorBall_StatusManager.Instance.GetGrid().y;

        for (int i = 1; i < gridWidth - 1; i++)
        {
            for (int j = 1; j < gridHeight - 1; j++)
            {
                GameObject tile = Instantiate(cubePrefab, new Vector3(i - (gridWidth / 2.0f) + 0.5f, 0, j - (gridHeight / 2.0f) + 0.5f), Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.tag = "Target";
                ColorBall_StatusManager.Instance.SetGridType(i, j, ColorBall_StatusManager.GridType.NormalTile);
            }
        }
    }

}
