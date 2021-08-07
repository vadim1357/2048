using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start8192 : MonoBehaviour
{
  [SerializeField] private  Button startGame8192Button;
    [SerializeField] private Transition transition;
    private void BeginPlay()
    {
        SceneManager.LoadScene(3);
        transition.Change();
    }
    private void Awake()
    {
        startGame8192Button.onClick.AddListener(BeginPlay);

        
    }

}
