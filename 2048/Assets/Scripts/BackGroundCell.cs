using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCell : MonoBehaviour
{
    [SerializeField] public  CellPlay CellPlayPrefab { get; private set; }
    public bool checkMove;

    public bool IsFree 
    {
        get 
        {
            return CellPlayPrefab == null; 
        }
    }
    private void Update()
    {
        
        if (!IsFree && !CellPlayPrefab.IsMoving())
        {
            Vector3 curPosition = transform.position;
            curPosition.z -= 0.1f;
            CellPlayPrefab.transform.localPosition = curPosition;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if(IsFree &&  collision.gameObject.tag == "CellPlay")
        {
            CellPlayPrefab = collision.gameObject.GetComponent<CellPlay>();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (!IsFree && collision.gameObject == CellPlayPrefab.gameObject)
        {
            CellPlayPrefab = null;
            checkMove = true;
        }
    }


    public void AttachCellPlay(CellPlay cell)
    {
        CellPlayPrefab = cell;
    }
}
