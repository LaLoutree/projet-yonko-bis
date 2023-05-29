using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponData primaryWeapon;
    public Renderer ren1;

    public WeaponData secondaryWeapon;
    public bool w1;

    public bool w2;
    // Start is called before the first frame update
    void Start()
    {
        primaryWeapon.GetComponent<Renderer>().enabled = true;
        secondaryWeapon.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            primaryWeapon.GetComponent<Renderer>().enabled = true;
            secondaryWeapon.GetComponent<Renderer>().enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            primaryWeapon.GetComponent<Renderer>().enabled = false;
            secondaryWeapon.GetComponent<Renderer>().enabled = true;
        }
    }
}
