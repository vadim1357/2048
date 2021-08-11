using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text counTurnText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameField gamefield;
    private int countTurn;
    private int minutes;
    private int seconds;
    public static int score;
    private void Awake()
    {
        
        gamefield.OnNextTurn += UpdateCountTurn;
        gamefield.OnNextTurn += UpdateScore;
        StartCoroutine(Timer());
        
    }
   
    private void UpdateCountTurn()
    {
        countTurn++;
        counTurnText.text =countTurn.ToString();
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }
            seconds++;
            if(minutes > 0)
            {
                timeText.text = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                timeText.text = seconds.ToString();
            }
            
        }


    }
    

}