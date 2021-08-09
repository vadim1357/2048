using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Text counTurnText;
    [SerializeField] private Text timeText;
    [SerializeField] private GameField gamefield;
    private int countTurn;
    private int minutes;
    private int seconds;
    private void Awake()
    {
        
        gamefield.OnNextTurn += UpdateCountTurn;
        StartCoroutine(Timer());
        
    }
   
    private void UpdateCountTurn()
    {
        countTurn++;
        counTurnText.text = countTurn.ToString();
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
            timeText.text = minutes.ToString() + " " + seconds.ToString();
        }


    }

}
