using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{

    int life = 3;
    bool stab = false;

    [SerializeField] private GameObject DeathCanvas;
    [SerializeField] private GameObject HudCanvas;
    public AudioClip[] stings;
    public AudioSource stingSource;

    float timer = 0;
    float timeToWait = 1.0f;
    bool time = false;
    bool checkingTime = false;
    bool timerDone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stab = GetComponent<Gameplay>().GetStab();
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
            time = false;
        }
        if (life == 0)
        {
            DeathCanvas.SetActive(true);
            HudCanvas.SetActive(false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IA" && stab == false && time == false)
        {
            life -= 1;
            time = true;
            checkingTime = true;
            stingSource.clip = stings[0];
            stingSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            life -= 3;
            time = true;
            checkingTime = true;
            stingSource.clip = stings[0];
            stingSource.Play();
        }
    }

    public int GetLife()
    {
        return life;
    }
}
