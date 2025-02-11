using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_BaseWallView : MonoBehaviour
{
    public void SetBaseWallColor()
    {
        bool isRed = ColorBall_GameManager.Instance.IsRedTurn;
        if (isRed)
        {
            Renderer baseWallRenderer = this.gameObject.GetComponent<Renderer>();
            baseWallRenderer.material.color = Color.red;
        }
        else
        {
            Renderer baseWallRenderer = this.gameObject.GetComponent<Renderer>();
            baseWallRenderer.material.color = Color.blue;
        }
    }
}
