using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 imputMovment;
    [SerializeField] private float Speed=5f;
    [SerializeField] private float RotateSpeed=16f;
    private Vector2 mousePosition;
    private Camera mainCamera;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoints;
    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mainCamera=Camera.main;
        

    }

    // Update is called once per frame
    private void Update()
    {   //vektor pozycji myszki
        mousePosition=mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Tworzenie wektora z kilkniętych strzałek
        imputMovment = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        // Strzał na lewym klawiszu
        if(Input.GetMouseButtonDown(0)){
        Vector2 PlayerToMouse=mousePosition - (Vector2)transform.position;
        var bullet = Instantiate(_bullet, _shootPoints.position, Quaternion.identity);
        bullet.Initialize(PlayerToMouse);
        }
    }
    private void FixedUpdate(){
        //aktulizacja poruszania się Move the player rigidbody
        rb2D.MovePosition(rb2D.position + imputMovment * Speed*Time.fixedDeltaTime);
        // Calculate the vector from the player to the mouse position
        Vector2 PlayerToMouse=mousePosition - (Vector2)transform.position;
        //płynna rotacja Smoothly rotate the player towards the mouse position
        Quaternion newRotate =Quaternion.FromToRotation(Vector3.up, PlayerToMouse);
        newRotate=Quaternion.Slerp(transform.rotation,newRotate, RotateSpeed*Time.fixedDeltaTime);
        rb2D.MoveRotation(newRotate);
        
        // Set the camera position to the player position
        mainCamera.transform.position = transform.position;
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
    }
    //kolizje
    private void OnCollisionEnter2D(Collision2D collision){
        //kolizja z Exit
    if (collision.gameObject.CompareTag("Exit"))
    {
        int x= SceneManager.GetActiveScene().buildIndex +1;
         if (SceneManager.GetSceneByBuildIndex(x) != null)
        {
            // Scene with build index x exists
            SceneManager.LoadScene(x);

        }
        else
        {
            // Scene with build index x does not exist
        }
        
    }
}
   
}
