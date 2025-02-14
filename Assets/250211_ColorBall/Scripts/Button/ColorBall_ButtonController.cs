using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall_ButtonController : MonoBehaviour
{
    public void OnRedLeftButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(true, new Vector2(-1, 0));
    }

    public void OnRedRightButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(true, new Vector2(1, 0));
    }

    public void OnRedDownButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(true, new Vector2(0, -1));
    }

    public void OnRedUpButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(true, new Vector2(0, 1));
    }

    public void OnBlueLeftButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(false, new Vector2(1, 0));
    }

    public void OnBlueRightButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(false, new Vector2(-1, 0));
    }

    public void OnBlueDownButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(false, new Vector2(0, 1));
    }

    public void OnBlueUpButtonClicked()
    {
        ColorBall_BallManager.Instance.MoveBall(false, new Vector2(0, -1));
    }
}
