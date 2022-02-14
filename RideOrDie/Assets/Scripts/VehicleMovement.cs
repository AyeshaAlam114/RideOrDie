using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour
{
    public float vSpeed;
    public float slowSpeed=0;

    void Update()
    {
        if (slowSpeed!=0)
            transform.Translate(Vector3.forward * Time.deltaTime * slowSpeed);                             //Move the vehicle forward/backward around vertical axis
        else
            transform.Translate(Vector3.forward * Time.deltaTime * vSpeed);                                //Move the vehicle forward/backward around vertical axis
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && this.tag != "ride")
    //    {
    //        this.tag = "ride";
    //        //if (PlayerController.downPressed)
    //        //    PlayerRideSetting(this.gameObject);
    //    }
    //}

}
