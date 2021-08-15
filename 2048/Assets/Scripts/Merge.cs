using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    [SerializeField] private CellPlay cell;
    public static bool checkMerge;
    
    private void OnCollisionEnter(Collision collision)
    {
        CellPlay anotherPlayCell = collision.gameObject.GetComponent<CellPlay>();
        if (anotherPlayCell != null)
        {
            if (anotherPlayCell.PowerOfTwo == cell.PowerOfTwo)
            {
                if (IsIMergeSource(anotherPlayCell))
                {

                    checkMerge = true;
                    MergeTo(anotherPlayCell);


                    
                }
            }
        }
        
    }

    
    private void MergeTo(CellPlay cell)
    {
        
        cell.NextIndex();
        GameSession.Instance.AddScore(CountScoreCurCell(cell.index));
        
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

    private int CountScoreCurCell(int index)
    {
        int score = 1;
        for(int i = 0; i <= index; i++)
        {
            score *= 2;
        }
        return score;
    }
    
   
}
