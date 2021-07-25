using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public static DialogController instance;

    [TextArea(3, 10)]
    public string[] sentences;
    public float textSpeed;
    public Text text;

    private int index;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(text.text == sentences[index])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                text.text = sentences[index];
            }
        }
    }

    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public IEnumerator TypeLine()
    {
        foreach (char c in sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            index = 0;
            text.text = string.Empty;
            gameObject.SetActive(false);
            PlayerController.instance.stopInput = false;
        }
    }
}
