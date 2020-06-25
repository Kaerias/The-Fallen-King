using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    int score;
    public AudioClip[] stings;
    public AudioSource stingSource;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LootBox")
        {
            Destroy(collision.gameObject);
            if (stings.Length > 0)
            {
                stingSource.clip = stings[0];
                stingSource.Play();
            }
            score += 1;
        }
    }

    public int  GetScore()
    {
        return score;
    }

}
