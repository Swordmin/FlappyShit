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
    [SerializeField] private float _amplitude, _speed;
    [SerializeField] private AnimationCurve _offsetSpeed;
    [SerializeField] private AnimationCurve _offsetAmplitude;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _shoot = GetComponent<ShootBird>();
        _sprite = GetComponent<SpriteRenderer>();
        Initialization();
        _amplitude = CurveRandomAmplitude(_offsetAmplitude);
        _speed = CurveRandomSpeed(_offsetSpeed);
        Move();
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
        _offsetSpeed = _birdData.GetSpeedCurve();
        _offsetAmplitude = _birdData.GetAmplitudeCurve();

    }

    private void Move() 
    {
        var position = transform.position;
        position.y = transform.position.y + Mathf.Cos(Time.time * _speed) * _amplitude/100;
        transform.position = position;

    }

    private float CurveRandomAmplitude(AnimationCurve _curve)
    {
        return _curve.Evaluate(Random.value);
    }    
    private float CurveRandomSpeed(AnimationCurve _curve)
    {
        return _curve.Evaluate(Random.value);
    } 

}
