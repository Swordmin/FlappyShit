using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BirdData", menuName = "Bird Data", order = 51)]
public class Bird : ScriptableObject
{

    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _health;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Weapon _weapon;

    public string GetName() => _name;
    public string GetDescription() => _description;
    public float GetJumpForce() => _jumpForce;
    public float GetHealth() => _health;
    public Sprite GetSprite() => _sprite;
    public Weapon GetWeapon() => _weapon;

}
