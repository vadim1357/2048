using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start8192 : MonoBehaviour
{
  [SerializeField] private  Button startGame8192Button;
    private void BeginPlay()
    {
        SceneManager.LoadScene(3);
    }
    private void Awake()
    {
        startGame8192Button.onClick.AddListener(BeginPlay);

        
    }

}
