using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public static Transition Instance { get; private set; } = null;

    [SerializeField] Animator animator;
    private bool animationReady;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.transform.parent.gameObject);
        }
        else
        {
            Destroy(this.transform.parent.gameObject);
        }
        
    }
    public void SetAnimationReady()
    {
        animationReady = true;
    }
    public void Change(int sceneIndex)
    {
        HUD.score = 0;
        StartCoroutine(LoadYourAsyncScene(sceneIndex));
        animator.SetBool("start",true);
    }

    IEnumerator LoadYourAsyncScene(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone && !animationReady)
        {
            yield return null;
        }
        asyncLoad.allowSceneActivation = true;
        animationReady = false;
        animator.SetBool("start", false);

    }
}
