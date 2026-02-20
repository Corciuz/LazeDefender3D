using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField]GameObject DeathFX;
   [SerializeField]GameObject HitVFX;
   GameObject parent;
   [SerializeField]int ScorePerHit=15;
   [SerializeField]int HitPoint=2;
   ScoreBoard ScoreBoard;
  void Awake()
    {
        ScoreBoard = FindObjectOfType<ScoreBoard>();
        parent=GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        
        if(HitPoint<1){
        KillEnemy();
        }
        

    }
    

    private void KillEnemy()
    {
        GameObject VFX = Instantiate(DeathFX, transform.position, Quaternion.identity);
        VFX.transform.parent = parent.transform;
        Destroy(gameObject);
        ScoreBoard.IncreseScore(ScorePerHit);
    }

    void ProcessHit()
    {
        GameObject FX = Instantiate(HitVFX, transform.position, Quaternion.identity);
        FX.transform.parent = parent.transform;
        HitPoint--;
        
    }
}
