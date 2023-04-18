using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string Name;
    public GameObject Obj;
    public Player Player;
    public int ActualQuantity;
    public int QuantityToHave;
    public int Reward;

    public Quest(string name, GameObject target, int quantity, int reward)
    {
        Name = name;
        Obj = target;
        QuantityToHave = quantity;
        Reward = reward;
        ActualQuantity = 0;
    }

    public bool IsComplete()
    {
        return Player.quest.ActualQuantity >= Player.quest.QuantityToHave;
    }

    public void RewardPlayer()
    {
        Player.haveQuest = false;
        Player.Money += Player.quest.Reward;
    }
    

}
