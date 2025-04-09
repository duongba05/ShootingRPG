using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public float projectileRange = 10f;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            gameObject.SetActive(false);    
        }
    }
    private void OnEnable()
    {
        if(Vector3.Distance(transform.position,startPosition) > projectileRange)
        {
            gameObject.SetActive(false);
        }
    }
    public void UpdateProjectileRange(float projectileRange)
    {
        this.projectileRange = projectileRange;
    }
}
