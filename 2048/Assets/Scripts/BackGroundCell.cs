using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCell : MonoBehaviour
{
    [SerializeField] private CellPlay cellPlayPrefab;

    public bool IsFree 
    {
        get 
        {
            return cellPlayPrefab == null; 
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "CellPlay")
        {
            cellPlayPrefab = collision.gameObject.GetComponent<CellPlay>();
        }
    }
    public void AttachCellPlay(CellPlay cell)
    {
        cellPlayPrefab = cell;
    }
}
