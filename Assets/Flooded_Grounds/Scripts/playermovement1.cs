using UnityEngine;

public class playermovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform firePoint; // Gun barrel position
    public GameObject bulletPrefab; // Bullet prefab
    public float bulletSpeed = 20f; // Speed of the bullet

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Movement and jumping logic
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Shooting Logic
        if (Input.GetButtonDown("Fire1")) // Left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a bullet at the fire point position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add velocity to the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2f);
    }
}
