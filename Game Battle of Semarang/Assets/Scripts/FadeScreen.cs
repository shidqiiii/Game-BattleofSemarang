using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen instance;

    public Image imagefadeScreen;
    public float fadeSpeed;
    private bool shouldFadeToBlack, shouldFadeFromBlack;

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

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void Fade()
    {
        if (shouldFadeToBlack)
        {
            imagefadeScreen.color = new Color(imagefadeScreen.color.r, imagefadeScreen.color.g, imagefadeScreen.color.b, Mathf.MoveTowards(imagefadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (imagefadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromBlack)
        {
            imagefadeScreen.color = new Color(imagefadeScreen.color.r, imagefadeScreen.color.g, imagefadeScreen.color.b, Mathf.MoveTowards(imagefadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (imagefadeScreen.color.a == 0f)
            {
                shouldFadeFromBlack = false;
            }
        }
    }
}
