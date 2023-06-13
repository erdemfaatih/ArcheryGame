using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioSource audioGameOverSource;




    bool bolumGecti = false;


    float zaman = 60f;
    public Text zamanTxt;
    bool oyunBitti=false;
    

    public GameObject ok;

    float firlatma_hizi=3000.0f;
    float reset_firlatma_degeri=3000.0f;

    Transform kamera;

    public Image atis_hizi_bari;

    int puan=0;
    public Text puan_txt;

    int kalan_ok= 6;
    public Text kalan_ok_txt;
    int bolum_gecme_puani = 20;

    string bolumGecme="Tebrikler Geçtiniz";
    string bolumKaybetme ="Kaybettiniz";
    public Text bolumGecme_txt;


    
    void Start()
    {
        kamera = GameObject.Find("Main Camera").transform;
        
        
        // Sahne isimlerine göre kalan_ok deðerini ayarla
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            kalan_ok = 5;
            bolum_gecme_puani = 10;
            zaman = 30f;                 
            
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            kalan_ok = 6;
            bolum_gecme_puani = 10;
            zaman = 30f; 
            
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            kalan_ok = 8;
            bolum_gecme_puani = 10;
            zaman = 30f; 
          
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            kalan_ok = 5;
            bolum_gecme_puani = 10;
            zaman = 30f; 
          
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            kalan_ok = 4;
            bolum_gecme_puani = 10;
            zaman = 30f; 
          
        }
        else if (SceneManager.GetActiveScene().name == "Level6")
        {
            kalan_ok = 5;
            bolum_gecme_puani = 10;
            zaman = 30f; 
          
        }

        kalan_ok_txt.text = kalan_ok.ToString();
    }

    public void puan_arttir(int deger){
        puan += deger;
        puan_txt.text = puan.ToString();
    }



    
    void Update()
    {

        if(oyunBitti){
            return;
        }
        zaman -= Time.deltaTime;
        zamanTxt.text = "Time : " + Mathf.Max(0, (int)zaman);
        if (zaman <= 0)
        {
            zaman = 0;
            OyunuBitir();
        }



        if(Input.GetMouseButtonDown(0)){

            if(kalan_ok > 0){
              

                GameObject yeni_ok = Instantiate(ok,kamera.position,kamera.rotation);

                firlatma_hizi *= atis_hizi_bari.fillAmount;

                yeni_ok.GetComponent<Rigidbody>().AddForce(yeni_ok.transform.forward * firlatma_hizi);

                firlatma_hizi=reset_firlatma_degeri;

                oku_azalt();
            }    

            
        }
    }
    void OyunuBitir()
    {
        oyunBitti = true;

        // Oyunu bitirme iþlemleri
        if (puan >= bolum_gecme_puani)
        {
            bolumGecme_txt.text = bolumGecme.ToString();
            audioSource.Play();
            if (!bolumGecti) // Eðer bölüm henüz geçilmediyse
            {
                bolumGecti = true;
                audioGameOverSource.Play();
                Invoke("SonrakiBolum", 2.0f); // 2 saniye sonra bir sonraki bölüme geç
                
            }
        }
        else
        {
            bolumGecme_txt.text = bolumKaybetme.ToString();
            audioGameOverSource.Play();
            Invoke("MainMenu", 2.0f);
        }
    }
    void SonrakiBolum()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Bir sonraki aktif sahne
    }

  
    public void MainMenu (){
        SceneManager.LoadScene(1); //baþlangýc sayfasýna git
    }


    void oku_azalt(){
          

        kalan_ok--;

        kalan_ok_txt.text = kalan_ok.ToString();
        if(kalan_ok==0 ){
            if(puan>=bolum_gecme_puani){
                if(SceneManager.GetActiveScene().name == "Level6"){
                    bolumGecme_txt.text = bolumGecme.ToString();
                    audioSource.Play();
                    Invoke("MainMenu", 2.0f);
                }else{
                    bolumGecme_txt.text = bolumGecme.ToString();
                    audioSource.Play();
                    OyunuBitir();
                    //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //bir sonraki aktif sahne 
                }
                
                

            }else{
                bolumGecme_txt.text = bolumKaybetme.ToString();
                audioGameOverSource.Play();
                Invoke("MainMenu", 2.0f);
            }
        }
    }
}
