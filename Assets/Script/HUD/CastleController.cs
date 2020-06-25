using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject Middle;

    private int _state;
    private bool _build;

    void Start()
    {
        _state = 2;
        /*Left.SetActive(false);
        Right.SetActive(false);
        Middle.SetActive(false);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (_build)
        {

            switch (_state)
            {
                case 0:
                    Left.SetActive(true);
                    break;
                case 1:
                    Right.SetActive(true);
                    break;
                case 2:
                    Middle.SetActive(true);
                    break;
                default:
                    break;
            }
            _build = false;
        }
    }

    public void BuildCastle()
    {
        _build = true;
        _state += 1;
    }
}
