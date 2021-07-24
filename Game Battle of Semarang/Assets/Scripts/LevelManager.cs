using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public float waitToRespawn;

    public int extraBulletCollected;
    public string levelToLoad;

    public int levelToUnlock;

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

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    public IEnumerator RespawnCo()
    {
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn - 1f/ FadeScreen.instance.fadeSpeed);
        FadeScreen.instance.FadeToBlack();
        yield return new WaitForSeconds(waitToRespawn - (1f / FadeScreen.instance.fadeSpeed) + .2f);
        FadeScreen.instance.FadeFromBlack();

        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.DealDamage();
        UIController.instance.UpdateHealthDisplay();
    }

    public void EndLevel()
    {
        StartCoroutine(EndLevelCo());
    }

    public IEnumerator EndLevelCo()
    {
        PlayerController.instance.stopInput = true;
        CameraController.instance.stopFollow = true;
        UIController.instance.stageCompleteText.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        FadeScreen.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / FadeScreen.instance.fadeSpeed) + 3f);

        PlayerPrefs.SetInt("LevelReached", levelToUnlock);

        SceneManager.LoadScene(levelToLoad);
    }
}
