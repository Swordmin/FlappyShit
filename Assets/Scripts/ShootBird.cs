using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBird : MonoBehaviour
{

    [SerializeField] private Weapon _weaponData;

    public void Shoot() 
    {
        
    }

    public void SetWeapon(Weapon weaponData) 
    {
        _weaponData = weaponData;
    }

}
