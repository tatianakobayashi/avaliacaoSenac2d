using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int life = 10;
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

    void ShootBullet()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        }
    }

    public void GetHit()
    {
        life--;
    }
}
