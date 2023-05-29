using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Débris : MonoBehaviour
{
    public Player player;
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (dist <= 1.9f)
        {
            if (Input.GetKeyDown(KeyCode.F) && player.Money >= 1000)
            {
                player.Money -= 1000;
                Destroy(gameObject);
            }
        }
    }
}
