using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Start2048 : MonoBehaviour

{
    [SerializeField] private  Button startGame2048Button;
    
    private void Awake()
    {
        startGame2048Button.onClick.AddListener(()=> { Transition.Instance.Change(1); });
    }
   
}
