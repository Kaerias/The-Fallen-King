using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelecLevel : MonoBehaviour
{
    public void Level1()
    {
        LaunchScene(2, -1);
    }

    public void Level2()
    {
        LaunchScene(3, -1);
    }

    public void LaunchScene(int scene, int score)
    {
        GetComponent<LoadingLevel>().SetScene(scene);
        SceneManager.LoadScene(0);
    }

    public void LaunchScene(int scene, bool completed,int score)
    {
        /*if (completed)
            GetComponent<LoadingLevel>().SetSceneAndScore(SceneManager.GetActiveScene().buildIndex + 1, score);
        else
            GetComponent<LoadingLevel>().SetSceneAndScore(SceneManager.GetActiveScene().buildIndex, score);
        */
        GetComponent<LoadingLevel>().SetScene(scene);
        SceneManager.LoadScene(0);
    }

}
