using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieController : MonoBehaviour
{
    public float speed;
    private Transform player;
    public int health;
    public GameObject deathEffect;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            TakeDamage(collision.GetComponent<Projectile>().damage);
        }
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>()?.TakeDamage(2);
        }
    }
    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
