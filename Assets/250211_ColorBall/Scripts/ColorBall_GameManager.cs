using UnityEngine;

public class ColorBall_GameManager : SingletonMonoBehaviour<ColorBall_GameManager>
{
    [SerializeField] private int gridWidth = 11;
    [SerializeField] private int gridHeight = 11;
    public bool IsRedTurn { get; private set; }

    private void Start()
    {
        IsRedTurn = Random.value > 0.5f;
        ColorBall_BaseWallManager.Instance.CreateBaseWall(gridWidth, gridHeight);
        ColorBall_TileManager.Instance.CreateBaseTile(gridWidth, gridHeight);
        ColorBall_BallManager.Instance.CreateBalls(gridWidth, gridHeight);
    }

    public void ChangeTurn()
    {
        IsRedTurn = !IsRedTurn;
        ColorBall_BaseWallManager.Instance.ChangeBaseWallColor();
    }

    public Vector2 GetGrid()
    {
        return new Vector2(gridWidth, gridHeight);
    }
}
