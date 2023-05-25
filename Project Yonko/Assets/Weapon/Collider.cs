using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    void WhenCollider(Collision col)
    {
        if(col.gameObject.tag == "zombie")
        {
            Destroy(col.gameObject);
        }   
    }
}
