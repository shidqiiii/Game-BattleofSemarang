using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedMenu : MonoBehaviour
{
    public static FailedMenu instance;
    public GameObject failedScreen;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SuccessfulUnsuccessful()
    {
        failedScreen.SetActive(true);
    }

    public void SceneToLoad(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
