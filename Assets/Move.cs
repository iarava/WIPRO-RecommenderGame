using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private MoveController moveController;

    [SerializeField]
    private float speed = 5f;

    private bool isMoveLeft;
    private bool isMoveRight;
    private bool isMoveUp;
    private bool isMoveDown;

    private Rigidbody2D rb;

    void Start()
    {
        moveController = GetComponent<MoveController>();
        moveController.MoveLeft += OnMoveLeft;
        moveController.MoveRight += OnMoveRight;
        moveController.MoveUp += OnMoveUp;
        moveController.MoveDown += OnMoveDown;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMoveLeft()
    {
        isMoveLeft = true;
    }

    private void OnMoveRight()
    {
        isMoveRight = true;
    }

    private void OnMoveUp()
    {
        isMoveUp = true;
    }

    private void OnMoveDown()
    {
        isMoveDown = true;
    }

    private void FixedUpdate()
    {
        if (isMoveLeft)
        {
            rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime * speed);
            isMoveLeft = false;
        }

        if (isMoveRight)
        {
            rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime * speed);
            isMoveRight = false;
        }

        if (isMoveUp)
        {
            rb.MovePosition(transform.position + Vector3.up * Time.fixedDeltaTime * speed);
            isMoveUp = false;
        }

        if (isMoveDown)
        {
            rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime * speed);
            isMoveDown = false;
        }
    }


    private void OnDestroy()
    {
        moveController.MoveLeft -= OnMoveLeft;
        moveController.MoveRight -= OnMoveRight;
        moveController.MoveUp -= OnMoveLeft;
        moveController.MoveDown -= OnMoveRight;
    }
}
