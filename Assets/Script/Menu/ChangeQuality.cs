using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeQuality : MonoBehaviour
{

    int qualityLvl = 0;

    [SerializeField] Button[] button = null;

    void Start()
    {
        qualityLvl = QualitySettings.GetQualityLevel();
    }

    public void HightLvl()
    {
        Reset(0);
        QualitySettings.SetQualityLevel(3);
        button[0].GetComponent<Image>().color = button[3].GetComponent<Image>().color;
    }

    public void MediumLvl()
    {
        Reset(1);
        QualitySettings.SetQualityLevel(2);
        button[1].GetComponent<Image>().color = button[3].GetComponent<Image>().color;
    }
    public void LowLvl()
    {
        Reset(2);
        QualitySettings.SetQualityLevel(1);
        button[2].GetComponent<Image>().color = button[3].GetComponent<Image>().color;
    }

    private void Reset(int id)
    {
        for(int i = 0; i < (button.Length - 1); i++)
        {
            if (i != id)
              button[i].GetComponent<Image>().color = Color.white;
        }
    }

}
