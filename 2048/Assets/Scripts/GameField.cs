using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField]  private BackGroundCell cellPrefab;
    [SerializeField] private CellPlay cellPlayPrefab;
    [SerializeField] private int height;
    [SerializeField] private int width;
    [SerializeField] private int countStartCell;
    private List<List<BackGroundCell>> field = new List<List<BackGroundCell>>();
    
    private void Start()
    {
        
        CreateField(height, width);
        for(int i = 0; i< countStartCell; i++)
        {
            GenerateRandomCell();
        }
    }

    public void CreateField(int height, int width)
    {
        for(int x = 0; x < width; x++)
        {
            field.Add(new List<BackGroundCell>());
            for(int y = 0; y< height; y++)
            {
                
                BackGroundCell newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(-((width-1)*0.5f)+x, (-(height-1)*0.5f)+y, 0);
                field[x].Add(newCell);
            }
        }
    }
    public bool GenerateRandomCell()
    {
        if (CheckGameOver())
        {
            return false;
        }
        BackGroundCell randomCell = field[Random.Range(0, width)][Random.Range(0, height)];
        Vector3 randomPosition = randomCell.transform.position;
        
        while (!randomCell.IsFree)
        {
            randomCell = field[Random.Range(0, width)][Random.Range(0, height)];
            randomPosition = randomCell.transform.position;
        }
        if (randomCell.IsFree)
        {
            randomPosition.z -= 0.1f;
            CellPlay newCell = Instantiate(cellPlayPrefab);
            newCell.transform.position = randomPosition;
            randomCell.AttachCellPlay(newCell);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public bool CheckGameOver()
    {
        foreach(var lineX in field)
        {
            foreach(var backGroundCell in lineX)
            {
                if (backGroundCell.IsFree)
                {
                    return false;
                }
            }
        }
        
        return true;
    }
    public void SwipeLeft()
    {

    }
}
