using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int healthCurrent;
    private int manaCurrent;
    public int maxHealth;   
    public int maxMana; 

    public Slider healthSlider;
    public Slider manaSlider;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        healthCurrent = maxHealth;
        manaCurrent = maxMana;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = healthCurrent;

        healthSlider.maxValue = maxMana;
        manaSlider.value = manaCurrent;
    }

    private void Update()
    {
        healthSlider.value = healthCurrent;
        manaSlider.value = manaCurrent;
    }

    public void TakeDamage(int amount)
    {
        healthCurrent -= amount;
        if(healthCurrent <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 2f);
    }
    public void Heal(int amount)
    {
        healthCurrent += amount;    
        healthCurrent = Mathf.Clamp(healthCurrent, 0, maxHealth);

    }
    public int GetCurrentHealth()
    {
        return healthCurrent;
    }
    public void TakeMana(int amount)
    {
        manaCurrent -= amount;
        manaCurrent = Mathf.Clamp(manaCurrent, 0, maxMana);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage(collision.GetComponent<ZombieController>().damage);
        }
    }
}
