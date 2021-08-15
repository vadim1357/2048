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
    
    
    private int minutes;
    private int seconds;
    
    private void Awake()
    {
        
        gamefield.OnNextTurn += UpdateCountTurn;
        gamefield.OnNextTurn += UpdateScore;
        StartCoroutine(Timer());
        
    }
   
    private void UpdateCountTurn()
    {
        
        counTurnText.text =GameSession.Instance.CountTurn.ToString();
    }
    private void UpdateScore()
    {
        scoreText.text = GameSession.Instance.Score.ToString();
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
    public void StopTimer()
    {
        StopAllCoroutines();
    }
    

}
