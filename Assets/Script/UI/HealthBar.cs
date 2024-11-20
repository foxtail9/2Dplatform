using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider; 
    public Gradient gradient; 
    public Image fill; 

    // ü�� �ʱ�ȭ
    public void SetMaxHealth(int maxHealth)
    {
        healthSlider.maxValue = maxHealth; 
        healthSlider.value = maxHealth; 
        fill.color = gradient.Evaluate(1f); 
    }

    // ü�� ������Ʈ
    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue); 
    }
}
