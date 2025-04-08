using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform weapon;
    public float offset;

    public Transform shotpoint;
    public float timeBetweenShots;
    float nextShotTime;


    void Start()
    {
        
    }

    void Update()
    {
        //Movement
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        transform.position += playerInput.normalized *speed*Time.deltaTime;
        // weapon rotaiton
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle + offset);
        //shooting
        if (Input.GetMouseButton(0))
        {
            Shooting();
        }
    }
    void Shooting()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + timeBetweenShots;
            GameObject bullet = ObjectPooling.Instance.GetPooledObject();
            bullet.transform.position = shotpoint.position;
            bullet.transform.rotation = shotpoint.rotation;
            bullet.SetActive(true);
        }
    }
}
