using UnityEngine;

public class ColorBall_BallController : MonoBehaviour
{
    [SerializeField] private bool isRed = true;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Vector2 currentGrid;
    private int currentPositionX = -1;
    private int currentPositionY = -1;

    public void SetIsRed(bool b)
    {
        isRed = b;
    }

    public void MoveBall(Vector2 direction)
    {
        SetCurrentPosition();

        for (int i = 1; i < ColorBall_StatusManager.Instance.GetGrid().x; i++)
        {
            ColorBall_StatusManager.Instance.SetBallStatusNone(currentPositionX, currentPositionY);
            int nextX = currentPositionX + Mathf.RoundToInt(direction.x) * i;
            int nextY = currentPositionY + Mathf.RoundToInt(direction.y) * i;
            ColorBall_StatusManager.GridType nextGridType = ColorBall_StatusManager.Instance.GetGridType(nextX, nextY);
            ColorBall_StatusManager.BallType nextBallType = ColorBall_StatusManager.Instance.GetBallStatus(nextX, nextY);
            if (nextGridType != ColorBall_StatusManager.GridType.Wall && nextBallType == ColorBall_StatusManager.BallType.None)
            {
                ColorBall_StatusManager.Instance.SetBallStatusNone(nextX, nextY);
                this.gameObject.transform.position += new Vector3(direction.x, 0, direction.y);
                ColorBall_StatusManager.Instance.SetGridType(nextX, nextY, isRed);
                ColorBall_TileManager.Instance.UpdateView(nextX, nextY);
            }
            else
            {
                currentPositionX = nextX - Mathf.RoundToInt(direction.x);
                currentPositionY = nextY - Mathf.RoundToInt(direction.y);
                ColorBall_StatusManager.Instance.SetBallStatus(currentPositionX, currentPositionY, isRed);
                // Debug.Log(currentPositionX + "," + currentPositionY);
                return;
            }
        }
    }

    private void SetCurrentPosition()
    {
        ColorBall_StatusManager.BallType[,] ballStatus = ColorBall_StatusManager.Instance.GetBallStatus();
        for (int i = 0; i < ballStatus.GetLength(0); i++)
        {
            for (int j = 0; j < ballStatus.GetLength(1); j++)
            {
                if (isRed && ballStatus[i, j] == ColorBall_StatusManager.BallType.Red)
                {
                    currentPositionX = i;
                    currentPositionY = j;
                    return;
                }

                if (!isRed && ballStatus[i, j] == ColorBall_StatusManager.BallType.Blue)
                {
                    currentPositionX = i;
                    currentPositionY = j;
                    return;
                }
            }
        }
    }
}