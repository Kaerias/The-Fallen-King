using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevel : MonoBehaviour
{

    [SerializeField] Text loadText = null;

    static int sceneload = 1;
    int score = -1;

    float timer = 0;
    float timeToWait = 5.0f;
    bool checkingTime = false;
    bool timerDone;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScene")
            checkingTime = true;
        timeToWait = Random.Range(3.0f, 4.0f);
        if (loadText != null)
        {
            if (sceneload == 1)
                loadText.text = "Menu";
            else
                loadText.text = "Level-" + (sceneload - 2);
        }
    }

    public void Update()
    {
        if (checkingTime)
        {
            timer += Time.deltaTime;
            if (timer >= timeToWait)
            {
                timerDone = true;
                checkingTime = false;
                timer = 0;
            }
        }

        if (timerDone)
        {
            timerDone = false;
            StartCoroutine(LoadAsync(sceneload));
        }
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);
        yield return null;
    }

    public void SetSceneAndScore(int scene, int score)
    {
        sceneload = scene;
        if (sceneload != 1 && sceneload != 0)
            GetComponent<File>().WriteFile(-1, score);
        if (sceneload == 1)
            GetComponent<File>().WriteFile(-1, score);
    }

    public void SetScene(int scene)
    {
        sceneload = scene;
    }

}
