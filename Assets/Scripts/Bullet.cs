using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private int _dmg = 2;
    private Vector2 _direction;

    public void Initialize(Vector2 direction)
    {
        _direction = direction.normalized; // normalize the direction vector
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Multiply the normalized direction vector by the move speed
        transform.position += (Vector3)_direction * Time.deltaTime * _moveSpeed;
        // Calculate the angle between the direction and the x-axis, and add a 90 degree offset
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg + 90f;
        // Set the rotation of the bullet's transform to this angle around the z-axis
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ObjToDestroy obj))
        {
            obj.TakeDamage(_dmg);
        }
        // Destroy the bullet object
        Destroy(gameObject);
    }
}
