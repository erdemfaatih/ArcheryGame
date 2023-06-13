using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahneler aras� ge�i� i�in

public class MainMenu : MonoBehaviour
{
  
	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //bir sonraki aktif sahne 
	}
	public void EndGame(){
		Debug.Log("��k�� Yap�ld�.");
		Application.Quit();
	}
	
}
