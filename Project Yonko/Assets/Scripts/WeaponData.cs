using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weapon", menuName = "My Game/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string name;
    public float damage;
    public float range;
    public GameObject graphics;
    public Renderer ren;
}
