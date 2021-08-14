using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "Weapon Data", order = 51)]
public class Weapon : ScriptableObject
{


    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _damage;
    [SerializeField] private int _ammo;
    [SerializeField] private Sprite _sprite;

}
