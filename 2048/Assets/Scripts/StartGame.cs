using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour

{
    [SerializeField] private  Button startGameButton;
    [SerializeField] private int sceneIndex;
    
    private void Awake()
    {
        startGameButton.onClick.AddListener(()=> { Transition.Instance.Change(sceneIndex); });
    }
   
}
