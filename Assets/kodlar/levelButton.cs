using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelButton : MonoBehaviour
{
    
    public int LevelIndex;
    
    public void loadLevel(){
        SceneManager.LoadScene(LevelIndex);
    }
}
