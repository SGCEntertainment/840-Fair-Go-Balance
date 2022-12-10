using UnityEngine;

public class Player : MonoBehaviour
{
    private float nextTime;
    private const float rate = 0.1f;

    private Vector2 touchDirection;
    private const float force = 4.0f;

    private float mouseX;
    private Rigidbody2D target;

    [SerializeField] Rigidbody2D lRigidbody;
    [SerializeField] Rigidbody2D rRigidbody;

    private Camera Camera { get; set; }

    private void Awake()
    {
        Camera = Camera.main;
    }

    private void Start()
    {
        transform.position = new Vector2(0, 1.25f);
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
            mouseX = Input.mousePosition.x;
            target = mouseX > Screen.width / 2 ? rRigidbody : lRigidbody;
        }
    }

    private void FixedUpdate()
    {
        if(!target)
        {
            return;
        }

        target.AddForce(-target.transform.up * force);
    }
}
