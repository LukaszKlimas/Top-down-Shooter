using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private int x1;
    [SerializeField] private int x2;
    [SerializeField] private int y1;
    [SerializeField] private int y2;

    private Vector3 startPosition;
    private float speed=2;
    private float rotationSpeed=90f;
    private float currentRotation;
    private bool direction =true;
    private int directionINT=0;
    private bool turnAround=false;
    [Header("Don't touch")]
    [SerializeField] private int difficulty_1to5=1;
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
     moveBot(difficulty_1to5);
}
public void Shoot(){
    Vector2 dir =  (Vector2)_shootPoints.TransformPoint(Vector3.zero)-(Vector2)transform.position;
    Debug.Log(transform.position +" "+dir);
    var bullet = Instantiate(_bullet, _shootPoints.position, Quaternion.identity);
    bullet.Initialize(dir);
}
public void move1(){
   if (!turnAround){//jeśli się nie obraca to idź
   if (direction){
            if (startPosition.x-x1<transform.position.x){//idź w lewo aż osiągnież punkt odbicia
                transform.position+=Vector3.left*Time.deltaTime*speed;
            }else {
                turnAround=true;
            }
        }else{
            if (startPosition.x+x2>transform.position.x){
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
            if (startPosition.y + y1 > transform.position.y)
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
            if (startPosition.y - y2 < transform.position.y)
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
public void move3(){
    if (!turnAround){//jeśli się nie obraca to idź
        if(directionINT==0){//kierunek w górę
                if (startPosition.y + y1 > transform.position.y)
            {
                transform.position += Vector3.up * Time.deltaTime * speed;
            }
            else
            {
                turnAround = true;
            }
        }
        if(directionINT==1){//kierunek w lewo
            if (startPosition.x-x1<transform.position.x){//idź w lewo aż osiągnież punkt odbicia
                transform.position+=Vector3.left*Time.deltaTime*speed;
            }else {
                turnAround=true;
            }
        }
        if(directionINT==2){//kierunek w dół
            if (startPosition.y - y2 < transform.position.y)
            {
                transform.position += Vector3.down * Time.deltaTime * speed;
            }
            else
            {
                turnAround = true;
            }
        }
         if(directionINT==3){//kierunek w prawo
            if (startPosition.x+x2>transform.position.x){
                transform.position+=Vector3.right*Time.deltaTime*speed;
            }else {
                turnAround=true;
            }
         }
    }else{ //obraca się
        if(directionINT==0){//kierunek w górę
            if(currentRotation!=90){
            // Oblicz nowy kąt obrotu
            currentRotation += rotationSpeed * Time.deltaTime;

            // Ogranicz kąt obrotu do zakresu [-90, 90] stopni
            currentRotation = Mathf.Clamp(currentRotation, -90f, 90f);

            // Ustaw nowy kąt obrotu wokół osi Z
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            //Debug.Log(currentRotation);
        }else{     
            directionINT++;
            turnAround=false;
        }}
        if(directionINT==1){//kierunek w lewo
            if(currentRotation!=180){
            // Oblicz nowy kąt obrotu
            currentRotation += rotationSpeed * Time.deltaTime;

            // Ogranicz kąt obrotu do zakresu [-180, 90] stopni
            currentRotation = Mathf.Clamp(currentRotation, 0f, 180f);

            // Ustaw nowy kąt obrotu wokół osi Z
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            //Debug.Log(currentRotation);
        }else{     
            directionINT++;
            turnAround=false;
        }}
        if(directionINT==2){//kierunek w dół
            if(currentRotation!=270){
            //transform.rotation=Quaternion.Euler(0,0,-90);
            // Oblicz nowy kąt obrotu
            currentRotation += rotationSpeed * Time.deltaTime;

            // Ogranicz kąt obrotu do zakresu [-270, 90] stopni
            currentRotation = Mathf.Clamp(currentRotation, -270f, 270f);

            // Ustaw nowy kąt obrotu wokół osi Z
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            //Debug.Log(currentRotation);
        }else{     
            directionINT++;
            turnAround=false;
        }}
        if(directionINT==3){//kierunek w prawo
            if(currentRotation!=360){
            //transform.rotation=Quaternion.Euler(0,0,-90);
            // Oblicz nowy kąt obrotu
            currentRotation += rotationSpeed * Time.deltaTime;

            // Ogranicz kąt obrotu do zakresu [-360, 90] stopni
            currentRotation = Mathf.Clamp(currentRotation, 0, 360f);

            // Ustaw nowy kąt obrotu wokół osi Z
            transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            //Debug.Log(currentRotation);
        }else{     
            directionINT=0;
            turnAround=false;
            currentRotation=0;
        }}
        }
    }
   public void moveBot(int difficulty_1to5){
    /*
    Bot1. chodzi tylko w lewo i w prawo
    Bot2. chodzi tylko w góre i w dół
    */

    switch (difficulty_1to5)
    {
        case 1:
        move1();
        break;
        case 2:
        move2();
        break;
        case 3:
        move3();
        break;        
        default:
        Debug.Log("error dificulty");
        break;
    }
   }
}
