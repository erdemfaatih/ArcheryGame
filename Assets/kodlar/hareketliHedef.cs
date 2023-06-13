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
        rb.velocity=Vector3.left*forceSpeed; //öne doðru hareket yaptýrdým

        if(timer){
            if(forceSpeed >0){
                forceSpeed = -speed; // bir þeye dokunduðu zaman tersi yönde hareket edicek
                timer =false;
            }else if(forceSpeed<0){
                forceSpeed =speed;
                timer =false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){ //herhangi objeye dokunduðunda yeri deðiþecek

        if(collision.gameObject.tag=="Untagged"){
            timer = true;
        }
        
    }
}
