using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    int score = 0;
    Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<LootBox>().GetScore();
        if (scoreText != null)
            scoreText.text = score.ToString();
    }
}
