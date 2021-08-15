using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarLine;

    public void Start()
    {
        PlayerInput.Player.GetComponent<Health>().OnHealthChange.AddListener((health, maxHealth) => // Refactoring
        {
            SetHealthbar(health, maxHealth);
        });
    }

    public void SetHealthbar(float value, float maxValue) 
    {
        float currenValue = value / maxValue;
        _healthbarLine.fillAmount = currenValue;
    }

}
