using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthChangeEvent : UnityEvent<float, float> { }

public class Health : MonoBehaviour
{

    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    [SerializeField] private HealthBar _healthBar;

    public HealthChangeEvent OnHealthChange = new HealthChangeEvent();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            TakeDamage(10);
        if (Input.GetKeyDown(KeyCode.G))
            Heal(5);
    }

    private void OnEnable()
    {
        Instantiate(_healthBar, transform.position, Quaternion.identity, transform);
    }
    public void TakeDamage(float damage) 
    {
        if(damage < 0)
        {
            throw new ArgumentException();
        }
        _health -= damage;
        OnHealthChange?.Invoke(_health, _maxHealth);
        
        if(_health <= 0)
        {
            Die();
        }

    }

    public void Heal(float heal) 
    {
        if (heal < 0)
        {
            throw new ArgumentException();
        }
        _health += heal;
        if (_health > _maxHealth)
            _health = _maxHealth;
        OnHealthChange?.Invoke(_health, _maxHealth);
    }

    private void Die()
    {
        //TODO
    }

}
