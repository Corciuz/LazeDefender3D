using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Setting")]
   [SerializeField]float controlSpeed =30f;
   [SerializeField]float xRange=10f;
   [SerializeField]float yRange=7f;
   [Header("Screen position base tuning")]
   [SerializeField] float positionPitchFactor=-2f;
   [SerializeField] float positionYawFactor=2f;
   [Header("Player inpit base tunning")]
   [SerializeField]float ControlPitchFactor=-15f;
   [SerializeField]float ControlYawFactor=-15f;
   [Header("Laser Gun Array")]
   [SerializeField]GameObject [] Lasers;
   
   float yThrow;
   float xThrow;
    void Update()
    {
       
       
ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
        
        
        
    }
    void ProcessFiring(){
       
        if(Input.GetButton("Fire1")){
ActivatedLaser(true);
        }else{
           ActivatedLaser(false); 
        }
    }
    void ActivatedLaser(bool IsFiring){
        foreach (GameObject laser in Lasers)
        {
           var emission=laser.GetComponent<ParticleSystem>().emission;
            emission.enabled=IsFiring;
        }
    }
    
    void ProcessRotation(){
        float YPitchDueToPos=transform.localPosition.y*positionPitchFactor;
        float YPitchDueToControl=yThrow*ControlPitchFactor;

        float XPitchDueToPos=transform.localPosition.x*positionYawFactor;
        float XPitchDueToControl=xThrow*ControlYawFactor;

        float pitch=YPitchDueToPos+YPitchDueToControl;
        float yaw=XPitchDueToPos;
        float roll=XPitchDueToControl;
        transform.localRotation=Quaternion.Euler(pitch,yaw,roll);
    }


    void ProcessTranslation()
    {
         xThrow = Input.GetAxis("Horizontal");
         yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float RawxPos = transform.localPosition.x + xOffset;
        float ClampedXpos = Mathf.Clamp(RawxPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float RawyPos = transform.localPosition.y + yOffset;
        float ClampedYpos = Mathf.Clamp(RawyPos, -yRange, yRange);


        transform.localPosition = new Vector3(ClampedXpos, ClampedYpos, transform.localPosition.z);
    }
}
