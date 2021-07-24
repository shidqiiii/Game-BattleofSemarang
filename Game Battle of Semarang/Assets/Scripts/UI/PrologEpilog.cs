using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrologEpilog : MonoBehaviour
{
    public GameObject[] story;
    int index;
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        FadeScreen.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen.instance.Fade();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextStory();
        }
    }

    public void NextStory()
    {
        if (index < story.Length - 1)
        {
            index++;
            story[index].SetActive(true);
            story[index - 1].SetActive(false);
        }
        else
        {
            FadeScreen.instance.FadeToBlack();
            SceneManager.LoadScene(level);
        }
    }
}