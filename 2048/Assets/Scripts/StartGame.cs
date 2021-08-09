using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour

{
    [SerializeField] private  Button startGame2048Button;
    [SerializeField] private int sceneIndex;
    
    private void Awake()
    {
        startGame2048Button.onClick.AddListener(()=> { Transition.Instance.Change(sceneIndex); });
    }
   
}
