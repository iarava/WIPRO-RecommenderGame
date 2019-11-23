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
        if(rb.position.x > -6.0f)
            isMoveLeft = true;    
    }

    private void OnMoveRight()
    {
        if (rb.position.x < 6.0f)
            isMoveRight = true;
    }

    private void OnMoveUp()
    {
        if (rb.position.y < 3.0f)
            isMoveUp = true;
    }

    private void OnMoveDown()
    {
        if (rb.position.y > -2.0f)
            isMoveDown = true;
    }

    private void FixedUpdate()
    {
        Vector3 pos = Vector3.zero;

        if (isMoveLeft)
            pos += Vector3.left * Time.fixedDeltaTime * speed;

        if (isMoveRight)
            pos += Vector3.right * Time.fixedDeltaTime * speed;

        if (isMoveUp)
            pos += Vector3.up * Time.fixedDeltaTime * speed;

        if (isMoveDown)
            pos += Vector3.down * Time.fixedDeltaTime * speed;

        if(isMoveLeft || isMoveRight || isMoveUp || isMoveDown)
        {
            rb.MovePosition(transform.position + pos);
            isMoveLeft = false;
            isMoveRight = false;
            isMoveUp = false;
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
