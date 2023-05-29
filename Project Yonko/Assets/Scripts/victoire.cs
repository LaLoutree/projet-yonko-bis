using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoire : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRayon;
    [SerializeField] private GameObject menuVictoire;
   
    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(player.position, transform.position) < detectionRayon)
        {
            menuVictoire.SetActive(true);
            return;
        } 
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, detectionRayon);
       
    }
}
