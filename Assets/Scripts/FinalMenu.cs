using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalMenu : MonoBehaviour
{
   
    [SerializeField] TextMeshProUGUI ScoreText;
    
   void Start()
    {
ScoreBoard scoreBoard=FindObjectOfType<ScoreBoard>();
       int Scores= scoreBoard.Score;
       
    
      
       
          
    ScoreText.text=Scores.ToString("0000"); 
    }
     
}
