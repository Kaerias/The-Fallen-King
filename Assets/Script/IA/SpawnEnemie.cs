using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemie : MonoBehaviour
{
    float timer = 0;
    float timeToWait = 3.0f;
    bool time = false;
    bool checkingTime = false;
    bool timerDone;

    [SerializeField] GameObject IA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToWait)
        {
            timerDone = true;
            checkingTime = false;
            timer = 0;
        }

        if (timerDone)
        {
            timerDone = false;
            Instantiate(IA);
        }
    }
}
