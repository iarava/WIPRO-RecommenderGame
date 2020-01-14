using System;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    public event Action MoveLeft = delegate { };
    public event Action MoveRight = delegate { };
    public event Action MoveUp = delegate { };
    public event Action MoveDown = delegate { };

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

    }
}