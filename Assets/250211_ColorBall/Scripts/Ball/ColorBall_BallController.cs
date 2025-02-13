using UnityEngine;

public class ColorBall_BallController : MonoBehaviour
{
    [SerializeField] private bool isRed = true;
    [SerializeField] private float speed = 10.0f;
    private bool isMoving = false;
    private bool isRight = false;
    private bool isLeft = false;
    private bool isUp = false;
    private bool isDown = false;
    [SerializeField] private Vector2 currentGrid;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Material targetMaterial = other.gameObject.GetComponent<Renderer>().material;
            if (isRed)
            {
                targetMaterial.color = Color.red;
            }
            else
            {
                targetMaterial.color = Color.blue;
            }
        }
        else
        {
            isMoving = false;
            isRight = false;
            isLeft = false;
            isUp = false;
            isDown = false;
            ColorBall_GameManager.Instance.ChangeTurn();
        }
    }

    public void SetIsRed(bool b)
    {
        isRed = b;
    }

    public void MoveBall(Vector2 direction)
    {
        SetCurrentPosition();
        Debug.Log(currentPositionX + ", " + currentPositionY);
    }

    private int currentPositionX = -1;
    private int currentPositionY = -1;

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

    private void Update()
    {
        if (!isMoving && isRed == ColorBall_GameManager.Instance.IsRedTurn)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isMoving = true;
                isRight = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isMoving = true;
                isLeft = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isMoving = true;
                isUp = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                isMoving = true;
                isDown = true;
            }
        }
        if (isRight)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * speed);
        }

        if (isLeft)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Time.deltaTime * speed);
        }

        if (isUp)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), Time.deltaTime * speed);
        }

        if (isDown)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Time.deltaTime * speed);
        }
    }
}
