using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAttachment : MonoBehaviour
{
    public bool isWithPlayer=false;
    public GameObject trafficParent;
    public GameManager refGM;
    GameObject player;
    public static bool isDetected;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        refGM = GameObject.Find("GameManager").GetComponent<GameManager>();
        trafficParent = GameObject.FindGameObjectWithTag("trafficParent");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("vehicle") && this.tag=="ride")
            refGM.TrafficCrash();
        if (collision.gameObject.CompareTag("Player") && this.tag == "ride")
            this.transform.parent = player.gameObject.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("playerRange") && this.tag != "ride")
        {
            if(player.transform.GetChild(5).GetComponent<RangePositionFixer>().vehiclesInRange.Count>0)
            player.GetComponent<PlayerController>().ridedVehicle = player.transform.GetChild(5).GetComponent<RangePositionFixer>().vehiclesInRange[0];
            player.transform.GetChild(5).GetComponent<RangePositionFixer>().vehiclesInRange.Add(this.gameObject);
            player.transform.parent = this.transform;
            player.transform.position = new Vector3(0,
                                                    3,
                                                    0);
            //if (PlayerController.downPressed)
                PlayerRideSetting(this.gameObject);
        }
    }

    void PlayerRideSetting(GameObject carToRide)
    {
        
        carToRide.tag = "ride";
        player.transform.GetChild(5).GetComponent<RangePositionFixer>().vehiclesInRange.Remove(this.gameObject);

        this.GetComponent<VehicleMovement>().enabled = false;
        // this.GetComponent<VehicleMovement>().slowSpeed = 5;

        //Vector3 targetPosition = new Vector3(this.transform.position.x, this.transform.position.y + 3, this.transform.position.z / 2);
        //// Move our position a step closer to the target.
        //float step = this.GetComponent<VehicleMovement>().slowSpeed * Time.deltaTime; // calculate distance to move
        //player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, 1f);

       
        //player.transform.position = new Vector3(player.GetComponent<PlayerController>().ridedVehicle.transform.position.x,
        //                                       player.GetComponent<PlayerController>().ridedVehicle.transform.position.y + 3,
        //                                       player.GetComponent<PlayerController>().ridedVehicle.transform.position.z / 2);
        refGM.PerfectlyLand();
        Check();
    }
    void Check()
    {
        isWithPlayer = true;
        //this.transform.parent = player.gameObject.transform;
       // this.GetComponent<VehicleMovement>().enabled = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            isWithPlayer = false;
           // this.gameObject.tag = "vehicle";
           // player.GetComponent<PlayerController>().ridedVehicle = null;

            this.GetComponent<VehicleMovement>().enabled = true;
            //this.GetComponent<VehicleMovement>().vSpeed = 0;
            this.GetComponent<VehicleMovement>().slowSpeed = 0.01f;
            if (!isWithPlayer)
            {
                Vector3 previousPosition = this.transform.position;
                this.transform.parent = trafficParent.gameObject.transform;
                this.transform.position = previousPosition;
            }
           

            Invoke(nameof(LaterOnExit), 5f);
        }
           
    }

    void LaterOnExit()
    {
        this.gameObject.tag = "vehicle";
        ResetSpeed();
    }

    void ResetSpeed()
    {
        this.GetComponent<VehicleMovement>().slowSpeed = 0;
    }
}
