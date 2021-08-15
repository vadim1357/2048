using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLastScore : MonoBehaviour
{
    [SerializeField] private GameField gameField;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text countTurnText;

    public void ShowRecord()
    {
        scoreText.text = GameSession.Instance.Score.ToString();
        countTurnText.text = GameSession.Instance.CountTurn.ToString();
    }
   
}
