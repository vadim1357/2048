using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] GameField gameField;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(RandomGeneratorMovies());
    }
    

    IEnumerator RandomGeneratorMovies()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            int randomNumber = Random.RandomRange(0, 3);
            switch (randomNumber)
            {
                case 0:
                    gameField.SwipeLeft();
                    break;
                case 1:
                    gameField.SwipeRight();
                    break;
                case 2:
                    gameField.SwipeUp();
                    break;
                case 3:
                    gameField.SwipeDown();
                    break;

            }

            yield return new WaitForSeconds(1f);
        }
        
    }
}
