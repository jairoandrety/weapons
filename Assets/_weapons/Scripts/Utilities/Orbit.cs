using UnityEngine;

public class Orbit: MonoBehaviour
{
    private Rigidbody rigidbody;
    private Collider collider;

    private float speed = 0;
    private float radius = 0;
    private float radiusSpeed = 0;

    private Vector3 direction = Vector3.zero;
    private Transform center;

    public float Speed { get => speed; set => speed = value; }
    public float Radius { get => radius; set => radius = value; }
    public float RadiusSpeed { get => radiusSpeed; set => radiusSpeed = value; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    public void Setup(Transform center, float speed, float radius, float radiusSpeed)
    {
        this.center = center;

        Speed = speed * 3;
        Radius = radius;
        RadiusSpeed = radiusSpeed;

        direction = new Vector3(Random.value, Random.value, Random.value);
        rigidbody.useGravity = false;
        collider.enabled = false;        
    }

    public bool isMoving = false;

    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        Move();
    }

    public void Move()
    {
        transform.RotateAround(center.position, direction, Speed * Time.deltaTime);
        Vector3 desirePos = (transform.position - center.position).normalized * radius + center.position;
        transform.position = Vector3.MoveTowards(transform.position, desirePos, radiusSpeed * Time.deltaTime);
    }

    public void AddForce(Transform center, float speed)
    {
        rigidbody.isKinematic = false;
        Speed = speed;
        this.center = center;
        direction = center.transform.position - transform.position;

        rigidbody.AddForce(direction * (Speed / 2), ForceMode.Impulse);
    }

    public void EndForce()
    {
        isMoving = false;
        if (rigidbody)
        {
            rigidbody.useGravity = true;
            collider.enabled = true;

            rigidbody.velocity = Vector3.zero;
        }
    }

    public void Release()
    {
        isMoving = false;
        if (rigidbody)
        {
            rigidbody.useGravity = true;
            collider.enabled = true;
        }        
    }
}