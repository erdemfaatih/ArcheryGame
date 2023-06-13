using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class okumuz : MonoBehaviour
{
    Rigidbody rigi;
    BoxCollider box;

    yonetici yonet; //puaný arttýrmak için

    



    void Start()
    {
        rigi=GetComponent<Rigidbody>();
        box=GetComponent<BoxCollider>();
        yonet=GameObject.Find("yonetici").GetComponent<yonetici>();
    }

    
    void Update()
    {
        transform.LookAt(transform.position+GetComponent<Rigidbody>().velocity); //Eðimli gitmesi kodu
        RaycastHit temas;

        if(Physics.Raycast(transform.position,transform.forward,out temas,3.0f)){ //sanal ýþýk

            string isim = temas.collider.gameObject.name;
            
            if(isim =="sari"){
                yonet.puan_arttir(12);
            }else if(isim =="kirmizi"){
                yonet.puan_arttir(10);
            }else if(isim =="mavi"){
                yonet.puan_arttir(8);
            }else if(isim =="siyah"){
                yonet.puan_arttir(6);
            }
            
            sil();
        }
    }

    void sil(){ //üst üste gelmemesi için
        Destroy(rigi);
        Destroy(box);
        Destroy(this);
    }
}
