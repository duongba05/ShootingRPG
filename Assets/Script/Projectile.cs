using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    void Start()
    {
        
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
        StartCoroutine(DisableAfterTime(5f));
    }

    private IEnumerator DisableAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
