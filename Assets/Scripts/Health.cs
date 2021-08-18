using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthChangeEvent : UnityEvent<float, float> { }

public class Health : MonoBehaviour
{

    [Min(0)]
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;

    [SerializeField] private HealthBar _healthBar;

    public HealthChangeEvent OnHealthChange = new HealthChangeEvent(); //


    private void OnEnable()
    {
        Vector2 offset = new Vector2(transform.position.x, transform.position.y + 1.5f);
        HealthBar healthbar = Instantiate(_healthBar, offset, Quaternion.identity, transform);
        healthbar.SetHealth(this);
    }

    public void SetHealth(float value) 
    {
        if(value < 0 )
        {
            throw new ArgumentException();
        }
        _health = value;
    }

    public void TakeDamage(float damage) 
    {
        if(damage < 0)
        {
            throw new ArgumentException("Ибо нефиг лечить через урон. Че, думаешь самый умный если решил написать значение с минусом? Типа вылечить и все дела. Алло, я для чего метод Heal написал.");
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
