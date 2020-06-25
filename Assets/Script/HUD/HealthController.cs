using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    int life = 0;
    public Image NoHP;
    Image[] hearts;

    void Start()
    {
        hearts = GetComponentsInChildren<Image>();
    }

    void Update()
    {
        life = GameObject.FindGameObjectWithTag("Player").GetComponent<Life>().GetLife();

        switch (life)
        {
            case 2: hearts[2].sprite = NoHP.sprite; break;
            case 1: hearts[1].sprite = NoHP.sprite; break;
            case 0: hearts[0].sprite = NoHP.sprite; break;
            default: break;
        }
    }
}
