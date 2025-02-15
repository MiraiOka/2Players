using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_StatusManager : SingletonMonoBehaviour<ColorBall_StatusManager>
{
    public enum GridType
    {
        Wall,
        RedTile,
        BlueTime,
        NormalTile,
    }

    public enum BallType
    {
        Red,
        Blue,
        None
    }

    [SerializeField] private int gridWidth = 11;
    [SerializeField] private int gridHeight = 11;

    [SerializeField] private GridType[,] gridStatus;
    [SerializeField] private BallType[,] ballStatus;

    public void SetInitStatus()
    {
        gridStatus = new GridType[gridWidth, gridHeight];
        ballStatus = new BallType[gridWidth, gridHeight];
        for (int i = 0; i < gridStatus.GetLength(0); i++)
        {
            for (int j = 0; j < gridStatus.GetLength(1); j++)
            {
                gridStatus[i, j] = GridType.NormalTile;
                ballStatus[i, j] = BallType.None;
            }
        }
    }

    public void SetGridType(int x, int y, GridType type)
    {
        gridStatus[x, y] = type;
    }

    public GridType GetGridType(int x, int y)
    {
        return gridStatus[x, y];
    }

    public void SetBallStatus(int x, int y, bool isRed)
    {
        if (isRed)
        {
            ballStatus[x, y] = BallType.Red;
        }
        else
        {
            ballStatus[x, y] = BallType.Blue;
        }
    }

    public void SetBallStatusNone(int x, int y)
    {
        ballStatus[x, y] = BallType.None;
    }

    public Vector2 GetGrid()
    {
        return new Vector2(gridWidth, gridHeight);
    }

    public BallType[,] GetBallStatus()
    {
        return ballStatus;
    }

    public BallType GetBallStatus(int x, int y)
    {
        return ballStatus[x, y];
    }
}
