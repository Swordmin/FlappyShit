using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpBird))]
[RequireComponent(typeof(ShootBird))]
public class PlayerInput : MonoBehaviour
{

    [SerializeField] private Bird _birdData;
    [SerializeField] private JumpBird _jump;
    [SerializeField] private ShootBird _shoot;

    [SerializeField] private KeyCode _jumpInput;

    private void Awake()
    {
        _jump = GetComponent<JumpBird>();
        _shoot = GetComponent<ShootBird>();
        Initialization();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(_jumpInput) || Input.GetMouseButtonDown(0))
            Jump();
    }

    private void Initialization() 
    {

        _jump.SetForce(_birdData.GetJumpForce());
        _shoot.SetWeapon(_birdData.GetWeapon());
        
    }

    public void Jump() 
    {
        _jump.Jump();
    }

}
