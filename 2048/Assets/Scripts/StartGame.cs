using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
  [SerializeField] private  Button startGameButton;
    private void BeginPlay()
    {
        SceneManager.LoadScene(1);
    }
    private void Awake()
    {
        startGameButton.onClick.AddListener(BeginPlay);

        
    }

}
