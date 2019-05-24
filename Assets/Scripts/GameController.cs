using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour, ITargetListener
{
    [SerializeField]
    private GameObject wonCanvas;
    [SerializeField]
    private GameObject gameUi;
    [SerializeField]
    private float timeBetweenRestart;

    private int numberOfTargets = 0;

    private void Start()
    {
        numberOfTargets = 0;
        foreach (Transform target in transform)
        {
            numberOfTargets++;
        }
    }

    private void FinalizeGame()
    {
        wonCanvas.SetActive(true);
        gameUi.SetActive(false);
        Invoke("RestartGame", timeBetweenRestart);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void OnTargetDestoyed()
    {
        numberOfTargets--;
        if (numberOfTargets <= 0) FinalizeGame();
    }


}
