using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class SwipeInput : MonoBehaviour

{
    private SwipeType lastSwipe  = SwipeType.NoSwipe;
    enum SwipeType 
    {
        Left = 1,
        Right = 2,
        Up = 3,
        Down = 4,
        NoSwipe = 5
    };
    private Vector2 beginPositionTouch;
    private static SwipeInput Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        lastSwipe = SwipeType.NoSwipe;

        if (TouchCount() > 0)
        {
            
            var currentTouch = GetTouch();
            Debug.Log(currentTouch.phase);
            if (currentTouch.phase == TouchPhase.Began)
            {
                beginPositionTouch = currentTouch.position;
            }
            if (currentTouch.phase == TouchPhase.Canceled || currentTouch.phase == TouchPhase.Ended)
            {
                Vector2 canceledTouch = currentTouch.position;
                var dx = beginPositionTouch.x - canceledTouch.x;
                var dy = beginPositionTouch.y - canceledTouch.y;
                if (Mathf.Abs(dx) >= Mathf.Abs(dy))
                {
                    if (dx < 0)
                    {
                        lastSwipe = SwipeType.Right;
                    }
                    if (dx > 0)
                    {
                        lastSwipe = SwipeType.Left;
                    }
                }
                else
                {
                    if (dy < 0)
                    {
                        lastSwipe = SwipeType.Up;
                    }
                    if (dy > 0)
                    {
                        lastSwipe = SwipeType.Down;
                    }
                }
            }
            
        }
        
    }
    public static bool Left()
    {
        return Instance.lastSwipe == SwipeType.Left;
    }
    public static bool Right()
    {
        return Instance.lastSwipe == SwipeType.Right;
    }
    public static bool Up()
    {
        return Instance.lastSwipe == SwipeType.Up;
    }
    public static bool Down()
    {
        return Instance.lastSwipe == SwipeType.Down;
    }

    private int TouchCount()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
        {
            return 1;
        }
        else 
        {
            return 0;
        }
#else
        return Input.touchCount;
#endif
    }
    private Touch GetTouch()
    {
#if UNITY_EDITOR
        var touch = new Touch();
        touch.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            touch.phase = TouchPhase.Began;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            touch.phase = TouchPhase.Ended;
        }
        else if (Input.GetMouseButton(0))
        {
            touch.phase = TouchPhase.Moved;
        }
        return touch;
#else
        return Input.GetTouch(0);
#endif
    }
}
