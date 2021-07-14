using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCell : MonoBehaviour
{
    [SerializeField] public  CellPlay CellPlayPrefab { get; private set; }

    public bool IsFree 
    {
        get 
        {
            return CellPlayPrefab == null; 
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "CellPlay")
        {
            CellPlayPrefab = collision.gameObject.GetComponent<CellPlay>();
        }
    }
    public void AttachCellPlay(CellPlay cell)
    {
        CellPlayPrefab = cell;
    }
}
