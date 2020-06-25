using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float pos;
    private GameObject player;
    private GameObject background;
    public string name;
    private bool b = false;
    
    private void Start()
    {
        background = Resources.Load<GameObject>(name);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (/*(transform.position.x < -(transform.position.x + (pos * 2))) || */(player.transform.position.x > (transform.position.x + (pos / 5))) && !b)
        {
            RepositionBackground();
            b = true;
        }
    }

    private void RepositionBackground()
    {
        GameObject tmp = GameObject.Instantiate(background);
        tmp.transform.position = new Vector2(transform.position.x + (pos * 2), transform.position.y);
    }
}
