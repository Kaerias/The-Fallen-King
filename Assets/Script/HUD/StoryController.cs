using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{

    public TextMeshProUGUI Story;
    public GameObject Next;
    public GameObject Parent;
    public GameObject Heart;
    public GameObject Box;

    private bool _isWritting;
    private List<string> _story;
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Gameplay>().enabled = false;
        Box.SetActive(false);
        Heart.SetActive(false);

        TextAsset txt = (TextAsset)Resources.Load("Story/Story", typeof(TextAsset));
        _speed = 0.2f;
        _story = new List<string>(txt.text.Split('\n'));
        StartCoroutine(display(_story[0]));
        _story.RemoveAt(0);
        Next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _speed = 0.03f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _speed = 0.2f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!_isWritting && _story.Count != 0)
            {
                Story.SetText("");
                StartCoroutine(display(_story[0]));
                _story.RemoveAt(0);
            }
            else if (!_isWritting)
            {
                Box.SetActive(true);
                Heart.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Gameplay>().enabled = true;
                Destroy(Parent);
            }
        }
    }

    private IEnumerator display(string text)
    {
        Next.SetActive(false);
        _isWritting = true;
        while (text.Length != 0)
        {
            Story.text += text[0];
            text = text.Substring(1);
            yield return new WaitForSecondsRealtime(_speed);
        }
        _isWritting = false;
        Next.SetActive(true);
    }
}
