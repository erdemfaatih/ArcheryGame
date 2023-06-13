using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //sahneler arasý geçiþ için

public class MainMenu : MonoBehaviour
{
  
	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1); //bir sonraki aktif sahne 
	}
	public void EndGame(){
		Debug.Log("Çýkýþ Yapýldý.");
		Application.Quit();
	}
	
}
