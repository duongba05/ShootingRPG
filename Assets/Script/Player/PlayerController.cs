using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashSpeed;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    [SerializeField] private TrailRenderer myTrailRenderer;

    public Transform weapon;
    public Transform shotpoint;
    public float timeBetweenShots;
    float nextShotTime;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weaponRenderer;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime = -Mathf.Infinity;
    private Vector3 dashDirection;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isDashing)
        {
            Movement();
        }
        else
        {
            Dash();
        }

        if (Input.GetMouseButton(0))
        {
            ShootBullet();
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown)
        {
            StartDash();
        }
    }

    void Movement()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += playerInput.normalized * speed * Time.deltaTime;

        animator.SetBool("isMoving", playerInput.magnitude > 0.1f);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - weapon.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle);

        bool isMouseLeft = mousePos.x < transform.position.x;
        spriteRenderer.flipX = isMouseLeft;
        weaponRenderer.flipY = isMouseLeft;
    }

    void ShootBullet()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + timeBetweenShots;
            GameObject bullet = ObjectPooling.Instance.GetPooledObject();

            if (bullet != null)
            {
                bullet.transform.position = shotpoint.position;
                bullet.transform.rotation = shotpoint.rotation;
                bullet.SetActive(true);
            }
        }
    }

    void StartDash()
    {
        Vector3 inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        if (inputDir == Vector3.zero) inputDir = transform.right;

        dashDirection = inputDir.normalized;
        isDashing = true;
        dashTimeLeft = dashDuration;
        lastDashTime = Time.time;
        myTrailRenderer.emitting = true;

    }
    void Dash()
    {
        if (dashTimeLeft > 0)
        {
            transform.position += dashDirection * dashSpeed * Time.deltaTime;
            dashTimeLeft -= Time.deltaTime;
        }
        else
        {
            isDashing = false;
            myTrailRenderer.emitting = false;
        }
    }
}