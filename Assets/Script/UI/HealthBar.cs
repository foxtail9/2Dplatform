using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; 
    public Gradient gradient; 
    public Image fill; 

    // 체력 초기화
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth; 
        healthSlider.value = maxHealth; 
        fill.color = gradient.Evaluate(1f); 
    }

    // 체력 업데이트
    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue); 
    }
}
