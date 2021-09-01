using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum InputType
{
    Jump,
    Joystick
}

[RequireComponent(typeof(JumpBird))]
[RequireComponent(typeof(ShootBird))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]
public class PlayerInput : MonoBehaviour
{

    public static PlayerInput Player;

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Bird _birdData;
    [SerializeField] private Health _health;
    [SerializeField] private JumpBird _jump;
    [SerializeField] private ShootBird _shoot;
    [SerializeField] private SpriteRenderer _sprite;

    [Space(20)]
    [SerializeField] private float _freezeTime;
    [SerializeField] private float _colldownJump;

    [Space(20)]
    [SerializeField] private InputType _inputType;
    [SerializeField] private KeyCode _jumpInput;
    [SerializeField] private KeyCode _timeFreezeInput;

    private void Awake()
    {
        Player = this;
        _health = GetComponent<Health>();
        _jump = GetComponent<JumpBird>();
        _shoot = GetComponent<ShootBird>();
        _sprite = GetComponent<SpriteRenderer>();
        Initialization();
        StartCoroutine(JumpTimer());

    }

    private void Update()
    {

        #region Jump
        if (Input.GetKeyDown(_jumpInput) || Input.GetMouseButtonDown(0))
            Jump(Vector2.up);

        if (Input.GetKeyDown(_timeFreezeInput))
            Time.timeScale = _freezeTime;
        if (Input.GetKeyUp(_timeFreezeInput))
            Time.timeScale = 1;
        #endregion

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (_joystick.Vertical > 0)
        {



        }

    }

    private void Initialization()
    {

        _jump.SetForce(_birdData.GetJumpForce());
        _shoot.SetWeapon(_birdData.GetWeapon());
        _sprite.sprite = _birdData.GetSprite();
        _health.SetHealth(_birdData.GetHealth());

    }

    public void Jump(Vector2 direction)
    {
        _jump.Jump(direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.TryGetComponent(out Coin coin))
            {
                ResourceViewer.ResourceView.Coin += coin.Count;
            }
        }
        catch(Exception ex) { Debug.Log(ex); }
    }

    IEnumerator JumpTimer()
    {
        while (true)
        {
            if (_inputType == InputType.Joystick) // Refactoring this bullshit
            {
                if (_joystick.Vertical > 0)
                {
                    yield return new WaitForSeconds(_colldownJump);
                    Jump(new Vector2(_joystick.Horizontal / 5, _joystick.Vertical / 2));
                }
            }
            yield return new WaitForSeconds(_colldownJump);
        }
    }

}