using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeAnim : MonoBehaviour
{

    [SerializeField] Image CartonSan = null;

    Animator anim = null;
    float timer = 0;
    float timeToWait = 1.0f;
    bool checkingTime = false;
    bool timerDone = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = CartonSan.GetComponent<Animator>();
    }

    void Update()
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
            anim.SetBool("touch", false);
        }
    }

    public void TouchCartonSan()
    {
        anim.SetBool("touch", true);
        checkingTime = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
