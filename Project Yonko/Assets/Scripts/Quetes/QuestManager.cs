using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static GameObject Zombie;
    public static GameObject TeadyBear;
    public Quest quest1 = new Quest("Kill 10 Zombies", Zombie, 10, 750);
    public Quest quest2 = new Quest("Find 3 TeddyBear", TeadyBear, 3, 1500);
}
