using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] audioObj = GameObject.FindGameObjectsWithTag("Audio");
        if (audioObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            Destroy(this.gameObject);
        }
    }
}
