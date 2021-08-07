using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField] Rigidbody2D transition;
    private Vector3 velocity = Vector3.up * 100;
    private int curPosition = 0;
    private Vector3 finishPosition = new Vector3(0, 5000, 0);
    private Vector3 startPosition = new Vector3(0, -3000, 0);
    private void Awake()
    {
       
    }
    private void Update()
    {
       if(transition.transform.localPosition == finishPosition)
        {
            transition.velocity = Vector3.zero;
        }
       
    }
    public void Change()
    {
        transition.transform.position += velocity * Time.deltaTime;
    }
}
