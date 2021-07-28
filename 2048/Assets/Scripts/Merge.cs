using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private CellPlay cell;


    private void OnCollisionEnter(Collision collision)
    {
        CellPlay anotherPlayCell = collision.gameObject.GetComponent<CellPlay>();
        if (anotherPlayCell != null)
        {
            if (anotherPlayCell.PowerOfTwo == cell.PowerOfTwo)
            {
                if (IsIMergeSource(anotherPlayCell))
                {
                    MergeTo(anotherPlayCell);
                }
            }
        }
        
    }

    
    private void MergeTo(CellPlay cell)
    {
        cell.NextIndex();
        Destroy(this.gameObject);
    }
    private bool IsIMergeSource(CellPlay anotherCell)
    {
        if (anotherCell.Velocity.x > 0 && anotherCell.transform.position.x > this.transform.position.x)
        {
            return true;
        }
        if (anotherCell.Velocity.x < 0 && anotherCell.transform.position.x < this.transform.position.x)
        {
            return true;
        }
        if (anotherCell.Velocity.y > 0 && anotherCell.transform.position.y > this.transform.position.y)
        {
            return true;
        }
        if (anotherCell.Velocity.y < 0 && anotherCell.transform.position.y < this.transform.position.y)
        {
            return true;
        }

        return false;
    }
    
   
}
