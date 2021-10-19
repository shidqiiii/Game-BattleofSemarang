using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Fungsi Untuk Destroy Animasi Enemy Death
public class DestroyOvertime : MonoBehaviour
{
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
