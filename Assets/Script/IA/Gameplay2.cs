using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay2 : MonoBehaviour
{
    Vector3 move;
    Animator animation = null;
    float facing = 0;
    [SerializeField] private int speed = 5;
    [SerializeField] private BoxCollider2D box;
    float timer = 0;
    float timeToWait = 1.0f;
    bool checkingTime = false;
    bool timerDone;
    bool stab = false;

    void Start()
    {
        animation = GetComponent<Animator>();
    }

    void Update()
    {
        move = Vector3.zero;
        if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(1, 0, 0);
            facing = 1;
            animation.SetFloat("x", 1);
            animation.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            move = new Vector3(-1, 0, 0);
            facing = -1;
            animation.SetFloat("x", -1);
            animation.SetBool("walking", true);
        }
        else
        {
            animation.SetFloat("x", facing);
            animation.SetBool("walking", false);
        }
        gameObject.transform.position += move * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
            box.enabled = true;
            checkingTime = true;
            stab = true;
        }
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
            stab = false;
            box.enabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "IA" && stab == true)
        {
            collision.gameObject.GetComponent<IaMove>().SetLife(1);
            timerDone = false;
            stab = false;
            box.enabled = false;
        }
    }

    public bool GetStab()
    {
        return stab;
    }
}
