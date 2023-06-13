using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    
    public static nextLevel instance;
    int sceneIndex,levelPassed;
    
    void Start()
    {
        sceneIndex=SceneManager.GetActiveScene().buildIndex;
        levelPassed=PlayerPrefs.GetInt("LevelPassed");
    }

    public void nextLevelCheck(){
        if(sceneIndex==7){
            loadMainMenu();
        }else{
            if(levelPassed < sceneIndex){
                levelPassed =sceneIndex;
                PlayerPrefs.SetInt("LevelPassed",levelPassed);
            }
            loadNextLevel();
        }
    }
    void loadNextLevel(){
        SceneManager.LoadScene(sceneIndex+1);
    }
    void loadMainMenu(){
        SceneManager.LoadScene("Levels");
    }
}
