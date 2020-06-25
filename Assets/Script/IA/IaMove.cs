using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaMove : MonoBehaviour
{
    new Animator animation = null;
    GameObject Player = null;
    float speed = 0.5f;
    int life = 1;
    int old = 0;
    float timer = 0;
    float timeToWait = 1.1f;
    bool timerDone = false;
    bool checkingTime = true;
    Color oldColor = new Color();
    Color color = new Color();
    bool colorIsChanged = false;
    public AudioClip[] stings;
    public AudioSource stingSource;


    void Start()
    {
        animation = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        color = GetComponent<SpriteRenderer>().color;
        oldColor = Color.white;
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
            }
        }
        if (timerDone)
        {
            timerDone = false;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 oldPos = transform.position;
        if (distance > 0.2f)
        {
            if (distance < 5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
                if (!colorIsChanged)
                {
                    GetComponent<SpriteRenderer>().color = oldColor;
                    colorIsChanged = true;
                }
            } else
            {
                if (colorIsChanged)
                {
                    GetComponent<SpriteRenderer>().color = color;
                    colorIsChanged = false;
                }
            }
            if (oldPos.x < transform.position.x)
            {
                old = 1;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                old = 1;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (life <= 0) {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            animation.SetFloat("x", old);
            animation.SetBool("dead", true);
 
            Timer();
        }   
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void SetLife(int life)
    {
        this.life -= life;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            stingSource.clip = stings[0];
            stingSource.Play();
            life--;
        }
    }
}
