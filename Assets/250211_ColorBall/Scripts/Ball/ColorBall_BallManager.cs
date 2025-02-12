using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_BallManager : SingletonMonoBehaviour<ColorBall_BallManager>
{
    [SerializeField] private GameObject spherePrefab;
    GameObject redBall;
    GameObject blueBall;

    public void CreateBalls()
    {
        int gridWidth = (int)ColorBall_GridStatusManager.Instance.GetGrid().x;
        int gridHeight = (int)ColorBall_GridStatusManager.Instance.GetGrid().y;

        redBall = Instantiate(spherePrefab, new Vector3(-(gridWidth / 2.0f) + 1.5f, 1, -(gridHeight / 2.0f) + 1.5f), Quaternion.identity);
        redBall.transform.SetParent(transform);
        redBall.GetComponent<Renderer>().material.color = Color.red;

        blueBall = Instantiate(spherePrefab, new Vector3((gridWidth / 2.0f) - 1.5f, 1, (gridHeight / 2.0f) - 1.5f), Quaternion.identity);
        blueBall.transform.SetParent(transform);
        blueBall.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void MoveBall(bool isRed, Vector3 direction)
    {
        if (isRed)
        {
            redBall.transform.position += direction;
        }
        else
        {
            blueBall.transform.position += direction;
        }
    }
}
