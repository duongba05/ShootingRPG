using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private int currenHealth;
    public int maxHealth;

    public Slider healthSlider;
    public GameObject deadEffect;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        currenHealth = maxHealth;
        healthSlider.value = currenHealth;
        healthSlider.maxValue = maxHealth;
    }
    private void Update()
    {
        animator = GetComponent<Animator>();
        healthSlider.value = currenHealth;  
    }
    public void TakeDamage(int amount)
    {
        currenHealth -= amount;
        if(currenHealth <= 0)
        {
            Die();
            ScoreManager.Instance.AddKill(1);    
        }
    }
    void Die()
    {
        animator.SetTrigger("Dead");
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            TakeDamage(collision.GetComponent<Projectile>().damage);
            animator.SetTrigger("Hit");
        }
    }
}
