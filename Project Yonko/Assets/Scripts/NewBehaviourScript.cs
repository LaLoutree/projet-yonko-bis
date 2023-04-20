using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool Isopen = false;
    [SerializeField] private GameObject parametreMenu;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Isopen = !Isopen;
            parametreMenu.SetActive(Isopen);
        }
    }
}
