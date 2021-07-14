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
    [SerializeField] private GameObject borderPrefab;
    
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
        SpawnBorder(height, width);
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
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeLeft();
                }
            }
        }
    }
    public void SwipeRight()
    {
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeRight();
                }
            }
        }
    }
    public void SwipeUp()
    {
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeUp();
                }
            }
        }
    }
    public void SwipeDown()
    {
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeDown();
                }
            }
        }
    }
    private void SpawnBorder(int hight, int width)
    {
        var leftBorder = Instantiate(borderPrefab);
        Vector3 leftPos = new Vector3(-(width/2f)-0.5f,0,0);
        leftBorder.transform.position = leftPos;
        Vector3 leftScale = new Vector3(1, hight, 1);
        leftBorder.transform.localScale = leftScale;

        var rightBorder = Instantiate(borderPrefab);
        Vector3 rightPos = new Vector3(width / 2f + 0.5f, 0, 0);
        rightBorder.transform.position = rightPos;
        Vector3 rightScale = new Vector3(1, hight, 1);
        rightBorder.transform.localScale = rightScale;

        var upBorder = Instantiate(borderPrefab);
        Vector3 upPos = new Vector3(0, hight / 2f + 0.5f, 0);
        upBorder.transform.position = upPos;
        Vector3 upScale = new Vector3(width+2f, 1, 1);
        upBorder.transform.localScale = upScale;

        var downBorder = Instantiate(borderPrefab);
        Vector3 downPos = new Vector3(0, -(hight / 2f + 0.5f), 0);
        downBorder.transform.position = downPos;
        Vector3 downScale = new Vector3(width+2f, 1, 1);
        downBorder.transform.localScale = downScale;


    }
}
