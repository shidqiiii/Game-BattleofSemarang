using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelReached", 1);
        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Back();
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
