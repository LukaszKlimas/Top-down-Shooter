using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed=5;
    [SerializeField] private int _dmg=2;
    private Vector2 _diretion;

     public void Initialize(Vector2 diretion){
        _diretion=diretion;
     }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=(Vector3)_diretion*Time.deltaTime*_moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if( collision.TryGetComponent(out ObjToDestroy obj)){
            obj.TakeDamage(_dmg);
        }

        // Destroy the bullet object
        Destroy(gameObject);
    }
}
