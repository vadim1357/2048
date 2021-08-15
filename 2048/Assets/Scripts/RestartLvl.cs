using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLvl : MonoBehaviour
{
    public Button restartLvl;

   
    private void Awake()
    {
       
        restartLvl.onClick.AddListener(() => { Transition.Instance.Change(SceneManager.GetActiveScene().buildIndex); });

    }
}
