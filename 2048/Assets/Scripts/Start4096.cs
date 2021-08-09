using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start4096 : MonoBehaviour
{
  [SerializeField] private  Button startGame4096Button;
    
    private void BeginPlay()
    {

        Transition.Instance.Change(2);
    }
    private void Awake()
    {
        startGame4096Button.onClick.AddListener(BeginPlay);

        
    }

}
