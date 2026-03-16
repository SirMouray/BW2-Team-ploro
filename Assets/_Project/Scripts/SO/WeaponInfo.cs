using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName ="Weapon/Weapon info")]
public class WeaponInfo : ScriptableObject
{
    public float _rateOfFire;
    public int _damage;
    public float _range;
}
