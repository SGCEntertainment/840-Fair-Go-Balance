using UnityEngine;

public class Player : MonoBehaviour
{
    private float nextTime;
    private const float rate = 0.1f;

    private Vector2 touchDirection;

    private Camera Camera { get; set; }
    private Rigidbody2D Rigidbody { get; set; }

    private void Awake()
    {
        Camera = Camera.main;
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = new Vector2(0, 1.25f);
    }

    private void Update()
    {
        if(Time.time > nextTime)
        {
            nextTime = Time.time + rate;
            touchDirection = new Vector2(Random.Range(-1.0f, 1.0f), 0);
        }
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(touchDirection);
    }
}
