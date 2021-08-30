using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public static GameSession Instance;
    [SerializeField] private GameField gameField;
    private int countTurn;
    public int CountTurn => countTurn;
    
    public GameField GameField => gameField;
    [SerializeField] private int score;
    public int Score => score;
    
    
    void Start()
    {
        Instance = this;
        gameField.OnNextTurn += AddTurn;
    }
    public void AddScore(int score)
    {
        this.score += score;
    } 
    public void AddTurn()
    {
        countTurn++;
    }

   
}
