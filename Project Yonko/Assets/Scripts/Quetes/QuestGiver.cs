using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class QuestGiver : QuestManager
{
    public Player Player;
    public Quest[] Quests = new Quest[2];
    public Random Random;

    private void Start()
    {
        Quests[0] = quest1;
        Quests[1] = quest2;
    }

    public void AddNewQuest()
    {
        if (Player.questAvailable)
        {
            Quest newQuest = Quests[Random.Next(Quests.Length-1)]; Player.quest = newQuest;
            Player.haveQuest = true;
            Player.questAvailable = false;
        }
    }

}
