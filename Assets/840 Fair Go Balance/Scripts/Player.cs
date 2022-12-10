using UnityEngine;

public class Player : MonoBehaviour
{
    private float nextTime;
    private const float rate = 0.1f;

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
        //if (Time.time > nextTime)
        //{
        //    nextTime = Time.time + rate;
        //    touchDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0);
        //}

        if (Input.GetMouseButton(0))
        {
            touchDirection = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            touchDirection.Normalize();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(touchDirection * force);
    }
}
