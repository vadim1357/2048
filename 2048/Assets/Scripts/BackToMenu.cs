using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public Button backToMenu;
    
    private void Awake()
    {
        backToMenu.onClick.AddListener(() => { Transition.Instance.Change(0); });


    }
}
