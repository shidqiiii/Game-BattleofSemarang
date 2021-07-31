using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShootBullet();
    }

    public void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(LevelManager.instance.extraBulletCollected > 0)
            {
                AudioManager.instance.PlaySFX(3);
                Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                LevelManager.instance.extraBulletCollected--;
            }
            else
            {
                LevelManager.instance.extraBulletCollected = 0;
            }
            UIController.instance.UpdateExtraBullet();
        }
    }
}
