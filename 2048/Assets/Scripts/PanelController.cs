using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameField gameField;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWin;
    [SerializeField] private ShowLastScore SLSW;
    [SerializeField] private ShowLastScore SLSO;
    [SerializeField] private HUD hud;

    public void ShowPanelGameOver()
    {
        SLSO.ShowRecord();
        hud.OffFirstScene();
        gameOver.SetActive(true);

    }
    public void ShowPanelGameWin()
    {
        SLSW.ShowRecord();
        hud.OffFirstScene();
        gameWin.SetActive(true);

    }
    private void Start()
    {
        gameField.OnGameOver += ShowPanelGameOver;
        gameField.OnWinGame += ShowPanelGameWin;
    }
}
