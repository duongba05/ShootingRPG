using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;
    public float projectileRange = 10f;
    private Vector3 startPosition;

    private void OnEnable()
    {
        startPosition = transform.position;
        StartCoroutine(CheckRange());
    }

    private void OnDisable()
    {
        StopAllCoroutines(); // Dừng coroutine khi object bị tắt để tránh lỗi hoặc lãng phí tài nguyên
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator CheckRange()
    {
        while (true)
        {
            if (Vector3.Distance(startPosition, transform.position) >= projectileRange)
            {
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }

    public void UpdateProjectileRange(float newRange)
    {
        this.projectileRange = newRange;
    }
}
