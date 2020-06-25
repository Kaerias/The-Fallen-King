using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    float timer = 0;
    bool stab = false;
    float timeToWait = 0;
    bool timerDone = false;
    static float facing = 1;
    bool checkingTime = false;
    Vector3 move = Vector3.zero;
    new Animator animation = null;
    [SerializeField] private int speed = 5;
    [SerializeField] private GameObject boxR;
    [SerializeField] private GameObject boxL;
    [SerializeField] private GameObject boxR2;
    [SerializeField] private GameObject boxL2;
    public AudioClip[] stings;
    public AudioSource stingSource;
    private SpriteRenderer sprite;

    void Start()
    {
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void PlayerInput()
    {
        move = Vector3.zero;
        if (Input.GetKey(KeyCode.Space))
        {
            move += new Vector3(0, 1.5f, 0);
            animation.SetBool("walking", false);
            animation.SetBool("attacking", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move += new Vector3(1, 0, 0);
            swapRotation(false);
            facing = 0;
            animation.SetBool("walking", true);
            animation.SetBool("attacking", false);
        }
        else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            move += new Vector3(-1, 0, 0);
            swapRotation(true);
            facing = -1;
            animation.SetBool("walking", true);
            animation.SetBool("attacking", false);
        }
        else
        {
            animation.SetBool("walking", false);
            animation.SetBool("attacking", false);
        }
        gameObject.transform.position += move * speed * Time.deltaTime;
    }

    void Timer()
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
            stab = false;
            boxL2.SetActive(false);
            boxR2.SetActive(false);
            boxR2.GetComponent<BoxCollider2D>().enabled = false;
            boxL2.GetComponent<BoxCollider2D>().enabled = false;
            boxL.SetActive(false);
            boxR.SetActive(false);
            boxR.GetComponent<BoxCollider2D>().enabled = false;
            boxL.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            stingSource.clip = stings[0];
            stingSource.Play();
            timeToWait = 1.5f;
            animation.SetBool("walking", false);
            animation.SetTrigger("attacking");
            checkingTime = true;
            if (facing == -1)
            {
                boxL2.SetActive(true);
                boxL2.GetComponent<BoxCollider2D>().enabled = true;
                boxL.SetActive(true);
                boxL.GetComponent<BoxCollider2D>().enabled = true;
            }
            else
            {
                boxR2.SetActive(true);
                boxR2.GetComponent<BoxCollider2D>().enabled = true;
                boxR.SetActive(true);
                boxR.GetComponent<BoxCollider2D>().enabled = true;
            }
            stab = true;
        }
        Timer();
        if (!checkingTime)
            PlayerInput();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "IA" && stab == true)
        {
            collision.gameObject.GetComponent<IaMove>().SetLife(1);
            stingSource.clip = stings[0];
            stingSource.Play();
            timerDone = false;
            stab = false;
            boxL.SetActive(false);
            boxL.GetComponent<BoxCollider2D>().enabled = false;
            boxR.SetActive(false);
            boxR.GetComponent<BoxCollider2D>().enabled = false;
            boxL2.SetActive(false);
            boxR2.SetActive(false);
            boxR2.GetComponent<BoxCollider2D>().enabled = false;
            boxL2.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    public bool GetStab()
    {
        return stab;
    }

    private void swapRotation(bool b)
    {
        sprite.flipX = b;
    }
}
