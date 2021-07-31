using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    int levelIsUnlocked;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        FadeScreen.instance.FadeFromBlack();

        levelIsUnlocked = PlayerPrefs.GetInt("levelIsUnlocked", 1);
        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelIsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Back();
        FadeScreen.instance.Fade();
    }

    public void Back()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void LevelToLoad (string level)
    {
        SceneManager.LoadScene(level);
    }
         
}
