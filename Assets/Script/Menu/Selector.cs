using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Selector : MonoBehaviour
{
    [SerializeField] GameObject panelOptions = null;
    [SerializeField] GameObject panelExit = null;
    [SerializeField] GameObject panelContinue = null;

    bool OptionsActive = false;
    bool ExitActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<File>().ReadFile();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            GetComponent<File>().WriteFile(1, 23);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (OptionsActive)
                ButtonOptions();
            else if (ExitActive)
                ActionPanelExit();
        }   
    }

    public void ButtonContinue()
    {
        if (!OptionsActive && !ExitActive)
        {
            int data = GetComponent<File>().GetScene();
            if (data != 0 && data != 1)
                GetComponent<SelecLevel>().LaunchScene(data, -1);
            else
                panelContinue.SetActive(true);
        }
    }

    public void ButtonNewGame()
    {
        GetComponent<SelecLevel>().LaunchScene(2, 0);
    }
    public void ButtonOptions()
    {
        if (!ExitActive)
        {
            if (!OptionsActive)
            {
                panelOptions.SetActive(true);
            }
            else
                panelOptions.SetActive(false);
            OptionsActive = !OptionsActive;
        }

    }

    public void ActionPanelExit()
    {
        if (!OptionsActive)
        {
            if (!ExitActive)
                panelExit.SetActive(true);
            else
                panelExit.SetActive(false);
            ExitActive = !ExitActive;
        }
    }

    public void ButtonExit()
    {
        ExitActive = false;
        Application.Quit();
    }
}
