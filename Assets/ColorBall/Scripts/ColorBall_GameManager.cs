using UnityEngine;

public class ColorBall_GameManager : SingletonMonoBehaviour<ColorBall_GameManager>
{
    public bool IsRedTurn { get; private set; }

    private void Start()
    {
        IsRedTurn = Random.value > 0.5f;
        ColorBall_WallController.Instance.SetBaseWallColor(IsRedTurn);
    }

    public void ChangeTurn()
    {
        IsRedTurn = !IsRedTurn;
        ColorBall_WallController.Instance.SetBaseWallColor(IsRedTurn);
    }
}
