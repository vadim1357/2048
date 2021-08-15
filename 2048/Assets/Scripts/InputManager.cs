using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] GameField gameField;

    void Start()
    {

    }


    void Update()
    {
        ProcessInputKeyboard();
        ProcessInputTouch();
    }
    private void ProcessInputKeyboard()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            gameField.SwipeLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameField.SwipeRight();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameField.SwipeUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameField.SwipeDown();
        }


    }

    private void ProcessInputTouch()
    {

        if (SwipeInput.Left())
        {
            gameField.SwipeLeft();
        }
        else if (SwipeInput.Right())
        {
            gameField.SwipeRight();
        }
        else if (SwipeInput.Up())
        {
            gameField.SwipeUp();
        }
        else if (SwipeInput.Down())
        {
            gameField.SwipeDown();
        }


    }
}
