using UnityEngine;

public class ColorBall_GameManager : SingletonMonoBehaviour<ColorBall_GameManager>
{
    public bool IsRedTurn { get; private set; }

    private void Start()
    {
        IsRedTurn = Random.value > 0.5f;
        ColorBall_StatusManager.Instance.SetInitStatus();
        ColorBall_BaseWallManager.Instance.CreateBaseWall();
        ColorBall_TileManager.Instance.CreateBaseTile();
        ColorBall_WallManager.Instance.SetWall();
        ColorBall_BallManager.Instance.CreateBalls();
        ColorBall_ScoreManager.Instance.CalcScore();
    }

    public void ChangeTurn()
    {
        IsRedTurn = !IsRedTurn;
        ColorBall_BaseWallManager.Instance.ChangeBaseWallColor();
    }
}
