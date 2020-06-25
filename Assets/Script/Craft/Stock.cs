using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stock : MonoBehaviour
{
    [SerializeField]
    private int stock = 9;
    [SerializeField]
    private TextMeshProUGUI stockText = null;
    [SerializeField]
    private Sprite itemImage = null;
    [SerializeField]
    private Sprite[] craftImages = new Sprite[3];
    [SerializeField]
    private List<Button> craftCase = new List<Button>(9);
    [SerializeField]
    private Image imageResult = null;
    [SerializeField]
    private Sprite defaultImage = null;

    private int[] table = {
        0, 0, 0,
        0, 0, 0,
        0, 0, 0
    };
    private int[] craft_0 = {
        1, 1, 0,
        1, 1, 0,
        1, 1, 0
    };
    private int[] craft_1 = {
        0, 1, 1,
        0, 1, 1,
        0, 1, 1
    };
    private int[] craft_2 = {
        1, 1, 1,
        1, 1, 1,
        1, 0, 1
    };


    private void OnValidate()
    {
        if (craftCase.Count != 9)
        {
            Debug.LogError("The craft Case list size need 9 elements");
        }
        if (craftImages.Length != 3)
        {
            Debug.LogError("The craft Images size need 3 elements");
        }
    }

    void Start()
    {
    }

    void Update()
    {
        stockText.text = "x " + stock;
    }

    private void ResetCraft()
    {
        Color color;

        for (int i = 0; i < 9; i++)
        {
            color = craftCase[i].image.color;
            color.a = 0;
            craftCase[i].image.sprite = null;
            craftCase[i].image.color = color;
        }
    }

    public void AddItem(int pos)
    {
        Color color = craftCase[pos].image.color;

        if (craftCase[pos].image.sprite != itemImage)
        {
            if (stock > 0)
            {
                color.a = 255;
                stock -= 1;
                craftCase[pos].image.sprite = itemImage;
                craftCase[pos].image.color = color;
                table[pos] = 1;
            }
        }
        else
        {
            color.a = 0;
            stock += 1;
            craftCase[pos].image.sprite = null;
            craftCase[pos].image.color = color;
            table[pos] = 0;
        }
        CheckCraft();
    }

    public void Craft()
    {
        if (table.SequenceEqual(craft_0) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.FindGameObjectWithTag("End").GetComponent<SelecLevel>().LaunchScene(SceneManager.GetActiveScene().buildIndex + 1, 0);
            ResetCraft();
        }
        else if (table.SequenceEqual(craft_1) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject.FindGameObjectWithTag("End").GetComponent<SelecLevel>().LaunchScene(SceneManager.GetActiveScene().buildIndex + 1, 0);
            ResetCraft();
        }
        else if (table.SequenceEqual(craft_2) && SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject.FindGameObjectWithTag("End").GetComponent<SelecLevel>().LaunchScene(SceneManager.GetActiveScene().buildIndex + 1, 0);
            ResetCraft();
        }
        else
        {
            Debug.Log("Failed");
        }
    }

    private void CheckCraft()
    {
        if (table.SequenceEqual(craft_0) && SceneManager.GetActiveScene().buildIndex == 2)
        {
            imageResult.sprite = craftImages[0];
        }
        else if (table.SequenceEqual(craft_1) && SceneManager.GetActiveScene().buildIndex == 3)
        {
            imageResult.sprite = craftImages[1];
        }
        else if (table.SequenceEqual(craft_2) && SceneManager.GetActiveScene().buildIndex == 4)
        {
            imageResult.sprite = craftImages[2];
        } else
        {
            imageResult.sprite = defaultImage;
        }
    }
}
