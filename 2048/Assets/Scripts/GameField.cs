using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameField : MonoBehaviour
{
    public static GameField Instance;
    [SerializeField] private BackGroundCell cellPrefab;
    [SerializeField] private CellPlay cellPlayPrefab;
    [SerializeField] private int height;
    [SerializeField] private int winIndex;
    [SerializeField] private int width;
    [SerializeField] private int countStartCell;
    private List<List<BackGroundCell>> field = new List<List<BackGroundCell>>();
    [SerializeField] private GameObject borderPrefab;
    private bool inProgress;
    public System.Action OnNextTurn;
    public System.Action OnGameOver;
    public System.Action OnWinGame;
    [SerializeField] private bool startScene;
    private bool GO;


    private void Start()
    {

        CreateField(height, width);
        for (int i = 0; i < countStartCell; i++)
        {
            GenerateRandomCell();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GO = true;
        }
        if (inProgress && FinishTurn())
        {
            if (CheckMove() || Merge.checkMerge)
            {
                NextTurn();
                Merge.checkMerge = false;

            }
           
        }
    }
    public void NextTurn()
    {
        
        GenerateRandomCell();
        if (CheckIndexAtGameOver() || GO)
        {
            if (startScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (OnGameOver != null)
            {
                OnGameOver();
            }

        }
        if (CheckWin())
        {
            if (startScene)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            if (OnWinGame != null)
            {
                OnWinGame();
            }
        }
        ResetCheckMove();
        if (OnNextTurn != null)
        {
            OnNextTurn();
        }
    }

    public void CreateField(int height, int width)
    {
        for (int x = 0; x < width; x++)
        {
            field.Add(new List<BackGroundCell>());
            for (int y = 0; y < height; y++)
            {

                BackGroundCell newCell = Instantiate(cellPrefab);
                newCell.transform.position = new Vector3(-((width - 1) * 0.5f) + x, (-(height - 1) * 0.5f) + y, 0);
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

        for (int i = 0; i < field.Count; i++)
        {

            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j].IsFree)
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void SwipeLeft()
    {
        if (CheckWin() || CheckIndexAtGameOver())
        {
            return;
        }
        if (inProgress)
        {
            return;
        }
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeLeft();
                    inProgress = true;
                }
            }
        }
    }
    public void SwipeRight()
    {
        if (CheckWin() || CheckIndexAtGameOver())
        {
            return;
        }
        if (inProgress)
        {
            return;
        }
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeRight();
                    inProgress = true;
                }
            }
        }
    }
    public void SwipeUp()
    {
        if (CheckWin() || CheckIndexAtGameOver())
        {
            return;
        }
        if (inProgress)
        {
            return;
        }
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeUp();
                    inProgress = true;
                }
            }
        }
    }
    public void SwipeDown()
    {
        if(CheckWin() || CheckIndexAtGameOver())
        {
            return;
        }
        if (inProgress)
        {
            return;
        }
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (!backGroundCell.IsFree)
                {
                    backGroundCell.CellPlayPrefab.SwipeDown();
                    inProgress = true;
                }
            }
        }
    }
    private void SpawnBorder(int hight, int width)
    {
        var leftBorder = Instantiate(borderPrefab);
        Vector3 leftPos = new Vector3(-(width / 2f) - 0.5f, 0, 0);
        leftBorder.transform.position = leftPos;
        Vector3 leftScale = new Vector3(1, hight, 1);
        leftBorder.transform.localScale = leftScale;

        var rightBorder = Instantiate(borderPrefab);
        Vector3 rightPos = new Vector3(width / 2f + 0.5f, 0, 0);
        rightBorder.transform.position = rightPos;
        Vector3 rightScale = new Vector3(1, hight, 1);
        rightBorder.transform.localScale = rightScale;

        var upBorder = Instantiate(borderPrefab);
        Vector3 upPos = new Vector3(0, hight / 2f + 0.25f, 0);
        upBorder.transform.position = upPos;
        Vector3 upScale = new Vector3(width + 2f, 0.5f, 1);
        upBorder.transform.localScale = upScale;

        var downBorder = Instantiate(borderPrefab);
        Vector3 downPos = new Vector3(0, -(hight / 2f + 0.25f), 0);
        downBorder.transform.position = downPos;
        Vector3 downScale = new Vector3(width + 2f, 0.5f, 1);
        downBorder.transform.localScale = downScale;
    }
    private bool FinishTurn()
    {
        foreach (var line in field)
        {
            foreach (var cell in line)
            {
                if (cell.IsFree)
                {
                    continue;
                }
                if (cell.CellPlayPrefab.IsMoving())
                {
                    return false;
                }
            }
        }
        inProgress = false;
        return true;
    }
    private bool CheckMove()
    {
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                if (backGroundCell.checkMove)
                {
                    backGroundCell.checkMove = false;


                    return true;

                }
            }
        }
        return false;
    }

    private void ResetCheckMove()
    {
        foreach (var lineX in field)
        {
            foreach (var backGroundCell in lineX)
            {
                backGroundCell.checkMove = false;
            }
        }
    }

    public void RepeatLastSwipe()
    {
        throw new System.NotImplementedException();
    }

    public bool CheckIndexAtGameOver()
    {
        for (int i = 0; i < field.Count; i++)
        {
            for (int j = 0; j < field[i].Count; j++)
            {
                if (field[i][j].CellPlayPrefab != null)
                {
                    if (j + 1 < field[i].Count)
                    {
                        if (field[i][j + 1].CellPlayPrefab == null)
                        {
                            return false;
                        }
                        else if (field[i][j].CellPlayPrefab.index == field[i][j + 1].CellPlayPrefab.index)
                        {
                            return false;
                        }
                    }
                    if (j - 1 >= 0)
                    {
                        if (field[i][j - 1].CellPlayPrefab == null)
                        {
                            return false;
                        }
                        else if (field[i][j].CellPlayPrefab.index == field[i][j - 1].CellPlayPrefab.index)
                        {
                            return false;
                        }
                    }
                    if (i + 1 < field.Count)
                    {
                        if (field[i + 1][j].CellPlayPrefab == null)
                        {
                            return false;
                        }
                        else if (field[i][j].CellPlayPrefab.index == field[i + 1][j].CellPlayPrefab.index)
                        {
                            return false;
                        }
                    }
                    if (i - 1 >= 0)
                    {
                        if (field[i - 1][j].CellPlayPrefab == null)
                        {
                            return false;
                        }
                        else if (field[i][j].CellPlayPrefab.index == field[i - 1][j].CellPlayPrefab.index)
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return true;
    }

    public bool CheckWin()
    {
        foreach(List<BackGroundCell> lineX in field)
        {
            foreach(BackGroundCell cell in lineX)
            {
                if(cell.CellPlayPrefab != null)
                {
                    if (cell.CellPlayPrefab.index == winIndex)
                    {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
}

