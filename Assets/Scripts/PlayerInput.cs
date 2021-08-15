using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpBird))]
[RequireComponent(typeof(ShootBird))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]
public class PlayerInput : MonoBehaviour
{

    public static PlayerInput Player;

    [SerializeField] private Bird _birdData;
    [SerializeField] private JumpBird _jump;
    [SerializeField] private ShootBird _shoot;
    [SerializeField] private SpriteRenderer _sprite;

    [Space(20)]
    [SerializeField] private float _freezeTime;

    [Space(20)]
    [SerializeField] private KeyCode _jumpInput;
    [SerializeField] private KeyCode _timeFreezeInput;

    private void Awake()
    {
        Player = this;
        _jump = GetComponent<JumpBird>();
        _shoot = GetComponent<ShootBird>();
        _sprite = GetComponent<SpriteRenderer>();
        Initialization();

    }

    private void Update()
    {

        if (Input.GetKeyDown(_jumpInput) || Input.GetMouseButtonDown(0))
            Jump();

        if (Input.GetKeyDown(_timeFreezeInput))
            Time.timeScale = _freezeTime;
        if (Input.GetKeyUp(_timeFreezeInput))
            Time.timeScale = 1;

        if(Input.GetKeyDown(KeyCode.Z))
        {
            ResourceViewer.AddCoin(2);
        }

    }

    private void Initialization() 
    {

        _jump.SetForce(_birdData.GetJumpForce());
        _shoot.SetWeapon(_birdData.GetWeapon());
        _sprite.sprite = _birdData.GetSprite();
        
        
    }

    public void Jump() 
    {
        _jump.Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Coin coin)) 
        {
            ResourceViewer.AddCoin(coin.GetCount());
        }
    }

}
