using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_BallManager : SingletonMonoBehaviour<ColorBall_BallManager>
{
    [SerializeField] private GameObject spherePrefab;
    private GameObject redBall;
    private GameObject blueBall;
    private ColorBall_BallController redBallController;
    private ColorBall_BallController blueBallController;

    public void CreateBalls()
    {
        int gridWidth = (int)ColorBall_StatusManager.Instance.GetGrid().x;
        int gridHeight = (int)ColorBall_StatusManager.Instance.GetGrid().y;

        redBall = Instantiate(spherePrefab, new Vector3(-(gridWidth / 2.0f) + 1.5f, 1, -(gridHeight / 2.0f) + 1.5f), Quaternion.identity);
        redBall.transform.SetParent(transform);
        redBall.GetComponent<Renderer>().material.color = Color.red;
        ColorBall_StatusManager.Instance.SetBallStatus(1, 1, ColorBall_StatusManager.BallType.Red);
        redBallController = redBall.AddComponent<ColorBall_BallController>();


        blueBall = Instantiate(spherePrefab, new Vector3((gridWidth / 2.0f) - 1.5f, 1, (gridHeight / 2.0f) - 1.5f), Quaternion.identity);
        blueBall.transform.SetParent(transform);
        blueBall.GetComponent<Renderer>().material.color = Color.blue;
        ColorBall_StatusManager.Instance.SetBallStatus(gridWidth - 2, gridHeight - 2, ColorBall_StatusManager.BallType.Blue);
        blueBallController = blueBall.AddComponent<ColorBall_BallController>();
    }

    public void MoveBall(bool isRed, Vector2 direction)
    {
        if (isRed)
        {
            redBallController.MoveBall(direction);
        }
        else
        {
            blueBallController.MoveBall(direction);
        }
    }
}
