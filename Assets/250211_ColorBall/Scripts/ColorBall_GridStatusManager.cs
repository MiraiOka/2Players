using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_GridStatusManager : SingletonMonoBehaviour<ColorBall_GridStatusManager>
{
    public enum GridType
    {
        Wall,
        RedTile,
        BlueTime,
        NormalTile,
    }

    [SerializeField] private int gridWidth = 11;
    [SerializeField] private int gridHeight = 11;

    [SerializeField] private GridType[,] gridStatus = new GridType[11, 11];

    public void SetGridType(int x, int y, GridType type)
    {
        gridStatus[x, y] = type;
    }

    public Vector2 GetGrid()
    {
        return new Vector2(gridWidth, gridHeight);
    }
}
