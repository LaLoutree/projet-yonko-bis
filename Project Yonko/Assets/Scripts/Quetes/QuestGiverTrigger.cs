using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverTrigger : QuestGiver
{
    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "Player" && Input.GetKey(KeyCode.F))
        {
            AddNewQuest();
        }
    }
}
