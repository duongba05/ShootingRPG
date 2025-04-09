using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private float dashTimeLeft;
    private float lastDashTime = -Mathf.Infinity;
    private Vector3 dashDirection;

    [Header("Weapon")]
    public float timeBetweenShots = 0.2f;
    private float nextShotTime;

    private Transform weapon;           // Trục xoay súng
    private Transform weaponHolder;     // Vị trí gắn súng
    private IWeapon currentWeapon;
    private GameObject currentWeaponGO; // Object hiện tại của súng

    [Header("References")]
    [SerializeField] private TrailRenderer myTrailRenderer;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer weaponRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Tìm vũ khí và holder nếu chưa được gán
        weapon = transform.Find("Weapon");
        weaponHolder = weapon?.Find("WeaponHold");

        weaponRenderer = weapon?.GetComponent<SpriteRenderer>();

        // Nếu có sẵn vũ khí trong holder thì gán luôn
        if (weaponHolder != null && weaponHolder.childCount > 0)
        {
            Transform defaultGun = weaponHolder.GetChild(0);
            currentWeaponGO = defaultGun.gameObject;
            IWeapon defaultWeapon = currentWeaponGO.GetComponent<IWeapon>();
            if (defaultWeapon != null)
            {
                SetWeapon(defaultWeapon);
            }
        }
    }

    void Update()
    {
        if (!isDashing)
            HandleMovement();
        else
            Dash();

        if (Input.GetMouseButton(0))
            Shoot();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown)
            StartDash();
    }

    void HandleMovement()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        transform.position += input.normalized * speed * Time.deltaTime;

        animator.SetBool("isMoving", input.magnitude > 0.1f);

        if (weapon == null) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - weapon.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, angle);

        bool isMouseLeft = mousePos.x < transform.position.x;
        spriteRenderer.flipX = isMouseLeft;
        if (weaponRenderer != null)
            weaponRenderer.flipY = isMouseLeft;
    }

    void Shoot()
    {
        if (currentWeapon != null && Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + timeBetweenShots;
            currentWeapon.Attack();
        }
    }

    void StartDash()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        if (input == Vector3.zero)
            input = transform.right;

        dashDirection = input.normalized;
        isDashing = true;
        dashTimeLeft = dashDuration;
        lastDashTime = Time.time;

        if (myTrailRenderer != null)
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
            if (myTrailRenderer != null)
                myTrailRenderer.emitting = false;
        }
    }

    public void SetWeapon(IWeapon newWeapon)
    {
        currentWeapon = newWeapon;
    }

    public Transform GetWeaponHolder()
    {
        return weaponHolder;
    }

    public GameObject GetCurrentWeaponGO()
    {
        return currentWeaponGO;
    }

    public void SetCurrentWeaponGO(GameObject weaponGO)
    {
        currentWeaponGO = weaponGO;
    }
    public IWeapon GetCurrentWeapon()
    {
        return currentWeapon;
    }
}
