using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]float loadLevel=1f;
    [SerializeField]ParticleSystem CrushVFX;
    
    void OnTriggerEnter(Collider other) {
       Crash();
       
    }
    void Crash(){
        CrushVFX.Play();
 GetComponent<PlayerControls>().enabled=false;
       Invoke("ReloadLevel",loadLevel);
      GameObject x=GameObject.Find("PlayerCollider");
      Destroy(x);
      
      
    }
    void ReloadLevel(){
        
        SceneManager.LoadScene(2);
    }
    IEnumerator EndLevel(){
        yield return new WaitForSecondsRealtime(56);
        SceneManager.LoadScene(2);
    }
     void Start() {
        StartCoroutine(EndLevel());
    }
    
}
