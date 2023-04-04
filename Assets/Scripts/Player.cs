using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 imputMovment;
    [SerializeField] private float Speed=5f;
    [SerializeField] private float RotateSpeed=16f;
    private Vector2 mousePosition;
    private Camera mainCamera;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mainCamera=Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        mousePosition=mainCamera.ScreenToWorldPoint(Input.mousePosition);

        imputMovment = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
    }
    private void FixedUpdate(){
        rb2D.MovePosition(rb2D.position + imputMovment * Speed*Time.fixedDeltaTime);
        Vector2 PlayerToMouse=mousePosition - (Vector2)transform.position;
        Quaternion newRotate =Quaternion.FromToRotation(Vector3.up, PlayerToMouse);
        newRotate=Quaternion.Slerp(transform.rotation,newRotate, RotateSpeed*Time.fixedDeltaTime);
        rb2D.MoveRotation(newRotate);
    }
}
