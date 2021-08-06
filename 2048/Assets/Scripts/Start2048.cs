using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start2048 : MonoBehaviour
{
  [SerializeField] private  Button startGame2048Button;
    private void BeginPlay()
    {
        SceneManager.LoadScene(1);
    }
    private void Awake()
    {
        startGame2048Button.onClick.AddListener(BeginPlay);

        
    }

}
