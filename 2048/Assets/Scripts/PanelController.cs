using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameField gameField;
    [SerializeField] private GameObject gameOver;

    [SerializeField] private HUD hud;

    public void ShowPanelGameOver()
    {
        gameOver.SetActive(true);
        hud.StopTimer();
        
    }
    private void Start()
    {
        gameField.OnGameOver += ShowPanelGameOver;
    }
}
