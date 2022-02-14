using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    float horizontalInput;
    float forwardInput;
    Rigidbody playerRB;
    Animator playerAnim;
    public float gravityModifier;
    public float jumpForce;
    public GameManager refGM;
    public static bool downPressed = false;
    public GameObject ridedVehicle;

 
    void Start()
    {
        refGM = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerAnim = gameObject.GetComponent<Animator>();
        playerRB = gameObject.GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim.SetBool("Crouch_b", true);
    }


    void Update()
    {

        //if (ridedVehicle != null && ridedVehicle.transform.parent!=this.gameObject)
        //{
        //    Vector3 targetPosition = new Vector3(ridedVehicle.transform.position.x, ridedVehicle.transform.position.y + 3, ridedVehicle.transform.position.z / 2);
        //    // Move our position a step closer to the target.
        //   // float step = this.GetComponent<VehicleMovement>().slowSpeed * Time.deltaTime; // calculate distance to move
        //    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 1f);
        //}
       



        horizontalInput = Input.GetAxis("Horizontal");

        //for rotate turns around horizontal axis
         transform.Rotate(Vector3.up*Time.deltaTime*turnSpeed*horizontalInput);

        if (this.transform.childCount > 6)
        {
            downPressed = false;
            forwardInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

            if (Input.GetKeyUp(KeyCode.UpArrow) && this.transform.GetChild(6).GetComponent<DetectAttachment>().isWithPlayer && !GameManager.gameOver)
            {
                playerRB.AddForce((Vector3.forward * 300) + (Vector3.up * jumpForce), ForceMode.Impulse);
                this.transform.GetChild(5).gameObject.SetActive(true);
                playerAnim.SetTrigger("Jump_trig");
                this.transform.GetChild(6).GetComponent<DetectAttachment>().isWithPlayer = false;
            }
            else
                this.transform.GetChild(5).gameObject.SetActive(false);

        }
        else if (this.transform.childCount==6)
        {
            if (Input.GetAxis("Vertical") > 0f)
                downPressed = true;          
            else
                this.transform.GetChild(5).gameObject.SetActive(true);
        }
  }
    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("road"))
        {
            GameManager.gameOver = true;
            refGM.GameOver();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 2);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EndTrigger"))
            refGM.GameEnd();
    }
}
