using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShootBird))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Health))]
public class EnemyAI : MonoBehaviour
{

    [SerializeField] private Bird _birdData;
    [SerializeField] private Health _health;
    [SerializeField] private ShootBird _shoot;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private AnimationCurve _moveCurve;
    private float _currentTimeMove, _totalTime;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _shoot = GetComponent<ShootBird>();
        _sprite = GetComponent<SpriteRenderer>();
        Initialization();
        _totalTime = _moveCurve.keys[_moveCurve.keys.Length - 1].time;
    }

    private void Update()
    {
        Move();
    }

    private void Initialization()
    {

        _shoot.SetWeapon(_birdData.GetWeapon());
        _sprite.sprite = _birdData.GetSprite();
        _health.SetHealth(_birdData.GetHealth());
        _moveCurve = _birdData.GetMoveCurve();

    }

    private void Move() 
    {
        var position = transform.position;
        position.y =  _moveCurve.Evaluate(_currentTimeMove);
        transform.position = position;
        _currentTimeMove += Time.deltaTime;

        if (_currentTimeMove > _totalTime)
            _currentTimeMove = 0;

    }

}
