using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    //public bool isMuted;
    public GameObject menu, reset;

    // Start is called before the first frame update
    void Start()
    {
        FadeScreen.instance.FadeFromBlack();

        //AudioListener.pause = isMuted;
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

    public void ResetLevel()
    {
        menu.SetActive(false);
        reset.SetActive(true);
    }

    public void ResetTheLevel(int choice)
    {
        if (choice == 1)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
        else if (choice == 0)
        {
            menu.SetActive(true);
            reset.SetActive(false);
        }
    }

    public void SceneToLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    /*public void MuteUnmute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }*/
}
