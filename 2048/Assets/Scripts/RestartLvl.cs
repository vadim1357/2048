using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLvl : MonoBehaviour
{
    [SerializeField] private Button restartLvl;

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void Awake()
    {
        restartLvl.onClick.AddListener(Restart);
    }
}
