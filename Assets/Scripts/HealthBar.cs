using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Image _healthbarLine;
    private Health _health;

    public void Start()
    {
        _health.OnHealthChange.AddListener((health, maxHealth) => // Refactoring this bullshit
        {
            SetHealthbar(health, maxHealth);
        });
    }

    public void SetHealthbar(float value, float maxValue) 
    {
        float currenValue = value / maxValue;
        _healthbarLine.fillAmount = currenValue;
    }

    public void SetHealth(Health health) 
    {
        _health = health;
    }

}
