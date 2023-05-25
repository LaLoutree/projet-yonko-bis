using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Projectile;
    public int Force = 10000;
    public AudioClip SoundTir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
            {
                GameObject Bullet = Instantiate(Projectile, transform.position + new Vector3(0, -2, 0), Quaternion.identity) as GameObject;
                Bullet.GetComponent<Rigidbody>().velocity = transform.forward * Force;
            }
    }
}
