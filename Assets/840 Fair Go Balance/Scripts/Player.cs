using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 touchDirection;
    private const float force = 4.0f;

    private Rigidbody2D Rigidbody { get; set; }

    private Camera Camera { get; set; }

    private void Awake()
    {
        Camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            touchDirection = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            touchDirection.Normalize();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(-touchDirection * force);
    }
}
