using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareketliHedef : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float forceSpeed;

    public bool timer;
    
    void Start()
    {
        forceSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity=Vector3.left*forceSpeed; //�ne do�ru hareket yapt�rd�m

        if(timer){
            if(forceSpeed >0){
                forceSpeed = -speed; // bir �eye dokundu�u zaman tersi y�nde hareket edicek
                timer =false;
            }else if(forceSpeed<0){
                forceSpeed =speed;
                timer =false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){ //herhangi objeye dokundu�unda yeri de�i�ecek

        if(collision.gameObject.tag=="Untagged"){
            timer = true;
        }
        
    }
}
