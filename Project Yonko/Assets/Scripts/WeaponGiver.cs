using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGiver : MonoBehaviour
{
    [SerializeField] private Joueur player;

    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (dist <= 1.9f)
        {
            if (Input.GetKey(KeyCode.F) && player.Money >= 500)
            {
                player.Money -= 500;
            }
        }
    }
}
