using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField]float Destroydelay=3f;
   
    void Start()
    {
        Destroy(gameObject,Destroydelay);
    }

    
}
