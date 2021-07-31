using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public bool isMuted;

    // Start is called before the first frame update
    void Start()
    {
        FadeScreen.instance.FadeFromBlack();

        AudioListener.pause = isMuted;
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
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

    public void SceneToLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void MuteUnmute()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
    }
}
