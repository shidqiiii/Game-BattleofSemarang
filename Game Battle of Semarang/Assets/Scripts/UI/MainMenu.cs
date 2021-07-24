using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu,exit;

    // Start is called before the first frame update
    void Start()
    {
        exit.SetActive(false);
        FadeScreen.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen.instance.Fade();
    }

    public void SceneToLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        menu.SetActive(false);
        exit.SetActive(true);       
    }

    public void YesNoQuitGame(int choice)
    {
        if(choice == 1)
        {
            Application.Quit();
            Debug.Log("Quit");
        }
        else if(choice == 0)
        {
            menu.SetActive(true);
            exit.SetActive(false);
        }
    }
}
