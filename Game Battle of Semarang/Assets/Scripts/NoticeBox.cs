using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeBox : MonoBehaviour
{
    public GameObject dialog;

    public bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && trigger)
        {
            showDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trigger = true;

        }
    }

    public void showDialog()
    {
        dialog.SetActive(true);
        DialogController.instance.text.text = string.Empty;
        DialogController.instance.StartDialog();
    }

}
