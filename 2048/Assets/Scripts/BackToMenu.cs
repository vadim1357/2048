using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] private Button backToMenu;
    private void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
        backToMenu.onClick.AddListener(BackMenu);


    }
}
