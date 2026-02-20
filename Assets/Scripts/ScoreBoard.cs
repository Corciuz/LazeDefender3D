using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreBoard : MonoBehaviour
{
   public int Score=0;
   
   [SerializeField] TextMeshProUGUI ScoreText;
     void Awake()
    {
        int numGameSession=FindObjectsOfType<ScoreBoard>().Length;
       
   
        if(numGameSession>1){
            
            Destroy(gameObject);
            
        }else{
            
            DontDestroyOnLoad(gameObject);
        
        }
    }
    void Start(){
        
        ScoreText.text="Start";
    }

    public void IncreseScore(int AmountToIncrese){
    Score+=AmountToIncrese;
   ScoreText.text=Score.ToString("0000000");
    }
     void Update(){
 int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex=currentSceneIndex+1;
        if(nextSceneIndex==SceneManager.sceneCountInBuildSettings){
            Destroy(gameObject);
            
        }
    }
    
}
