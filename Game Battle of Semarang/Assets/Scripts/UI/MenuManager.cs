using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        FadeScreen.instance.FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        FadeScreen.instance.Fade();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneToLoad();
        }
    }

    public void SceneToLoad()
    {
        SceneManager.LoadScene(scene);
    }
}
