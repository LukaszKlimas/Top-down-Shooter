using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public int difficulty_1to5=1;
    private Vector3 startPosition;
    private float speed=2;
    private float rotationSpeed=90f;
    private float currentRotation;
    private bool direction =true;
    private bool turnAround=false;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoints;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1.0f, 1.0f);
        startPosition = transform.position;
        if (difficulty_1to5==1)transform.rotation = Quaternion.Euler(0, 0, 90);
        currentRotation=transform.rotation.z;
    }

    // Update is called once per frame
 void Update()
{
    if (difficulty_1to5==1)move();
    else move2();
}
public void Shoot(){
    Vector2 dir =  (Vector2)_shootPoints.TransformPoint(Vector3.zero)-(Vector2)transform.position;
    Debug.Log(transform.position +" "+dir);
    var bullet = Instantiate(_bullet, _shootPoints.position, Quaternion.identity);
    bullet.Initialize(dir);
}
public void move(){
   if (!turnAround){//jeśli się nie obraca to idź
   if (direction){
            if (startPosition.x-2<transform.position.x){//idź w lewo aż osiągnież punkt odbicia
                transform.position+=Vector3.left*Time.deltaTime*speed;
            }else {
                turnAround=true;
            }
        }else{
            if (startPosition.x+2>transform.position.x){
                transform.position+=Vector3.right*Time.deltaTime*speed;
            }else {
                turnAround=true;
            }
        }
    }else{ //obraca się
    if (direction){ //jest w lewo
        if(currentRotation!=-90){
        //transform.rotation=Quaternion.Euler(0,0,-90);
        // Oblicz nowy kąt obrotu
        currentRotation -= rotationSpeed * Time.deltaTime;

        // Ogranicz kąt obrotu do zakresu [-90, 90] stopni
        currentRotation = Mathf.Clamp(currentRotation, -90f, 90f);

        // Ustaw nowy kąt obrotu wokół osi Z
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
        //Debug.Log(currentRotation);
        }else{
            turnAround=false;
            direction=!direction;
        }
    }else{ //jest w prawo
        if(currentRotation!=90){
        // Oblicz nowy kąt obrotu
        currentRotation += rotationSpeed * Time.deltaTime;

        // Ogranicz kąt obrotu do zakresu [-90, 90] stopni
        currentRotation = Mathf.Clamp(currentRotation, -90f, 90f);

        // Ustaw nowy kąt obrotu wokół osi Z
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
        //Debug.Log(currentRotation);
        }else{
            turnAround=false;
            direction=!direction;
        }
    }
    }
}
public void move2()
{
    if (!turnAround)
    {
        if (direction)
        {
            if (startPosition.y + 2 > transform.position.y)
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
            else
            {
                turnAround = true;
            }
        }
        else
        {
            if (startPosition.y - 2 < transform.position.y)
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
            else
            {
                turnAround = true;
            }
        }
    }
    else
    {
        if (direction)
        {
            if (currentRotation !=180)
            {
                currentRotation += rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, 0, 180f);
                transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
                //Debug.Log(1+" "+currentRotation);
            }
            else
            {
                turnAround = false;
                direction = !direction;
            }
        }
        else
        {
            if (currentRotation != 0)
            {
                currentRotation -= rotationSpeed * Time.deltaTime;
                currentRotation = Mathf.Clamp(currentRotation, 0, 180f);
                transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
                //Debug.Log(2+" "+currentRotation);
            }
            else
            {
                turnAround = false;
                direction = !direction;
            }
        }
    }
}

   public void moveqedqdeqwd(int difficulty_1to5){
    /*1. chodzi tylko 2 w lewo i 2 wprawo
    2. chodzi tylko 2 w góre i 2 wdół
    */

    switch (difficulty_1to5)
    {
        case 1://1. chodzi tylko 2 w lewo i 2 wprawo
        break;
        default:
        Debug.Log("error dificulty");
        break;
    }
   }
}
