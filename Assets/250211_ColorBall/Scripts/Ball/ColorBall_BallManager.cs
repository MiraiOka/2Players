using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_BallManager : SingletonMonoBehaviour<ColorBall_BallManager>
{
    [SerializeField] private GameObject spherePrefab;

    public void CreateBalls(int gridWidth, int gridHeight)
    {
        GameObject redBall = Instantiate(spherePrefab, new Vector3(-(gridWidth / 2.0f) + 1.5f, 1, -(gridHeight / 2.0f) + 1.5f), Quaternion.identity);
        redBall.transform.SetParent(transform);
        redBall.GetComponent<Renderer>().material.color = Color.red;

        GameObject blueBall = Instantiate(spherePrefab, new Vector3((gridWidth / 2.0f) - 1.5f, 1, (gridHeight / 2.0f) - 1.5f), Quaternion.identity);
        blueBall.transform.SetParent(transform);
        blueBall.GetComponent<Renderer>().material.color = Color.blue;
    }
}
