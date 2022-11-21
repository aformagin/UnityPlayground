using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{

    Rigidbody player_rbody;
    float jump = 9.81f * 20;

    public float maxSpeed = 2f;//Replace with your max speed
    private bool isMoving_forward;
    private bool isMoving_backward;
    private bool isJumping; //Used in fix update to send jump
    private int jump_counter; //Keeps track of the number of jumps remaining

    //Custom directional vectors

    private Vector3 forward, backwards;

    //GameObject references
    public GameObject ground; //Reference to the ground/plane the player stands on


    // Start is called before the first frame update
    void Start()
    {
        player_rbody = GetComponent<Rigidbody>();
        isJumping = false;
        isMoving_forward = false;
        isMoving_backward = false;
        jump_counter = 0;

        //Instantiate new vectors for directions
        //Let Forward be in the positive Z direction
        forward = new Vector3(0,0,1);
        backwards = new Vector3(0,0,-1);
    }

    void onMove(InputValue input)
    {
        
        Vector2 inVec = input.Get<Vector2>();
        print(inVec);
        player_rbody.AddForce(inVec * 5);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
            if(jump_counter <= 1)
                isJumping = true; //Set isJumping to true so the player jumps

        if(Input.GetKey("w"))
            isMoving_forward = true;
        
        if(Input.GetKeyUp("w"))
            isMoving_forward = false;
        
        if(Input.GetKey("s"))
            isMoving_backward = true;
        
        if(Input.GetKeyUp("s"))
            isMoving_backward = false;

        if(Input.GetKey("d"))
            rotate_player('r');

        if(Input.GetKey("a"))
            rotate_player('l');
    }

    void FixedUpdate(){
        // print("SPEED: " + player_rbody.velocity.magnitude);
    
        // player_rbody.velocity = Vector3.ClampMagnitude(player_rbody.velocity, maxSpeed);

        if (isJumping){
            player_rbody.AddForce(transform.up * jump);
            
            isJumping = false; //Setting isJumping to false
            jump_counter = jump_counter + 1;
            print("Jump Counter: " + jump_counter);
        }

        if(isMoving_forward)
            player_rbody.AddForce(transform.forward * 5);
        else
            player_rbody.AddForce(new Vector3(0,0,0));
        
        if (isMoving_backward)
            player_rbody.AddForce(-transform.forward * 25);
        else
            player_rbody.AddForce(new Vector3(0,0,0));
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject == ground)
            jump_counter = 0;
    }

    void OnCollisionExit(Collision collision){
        if(collision.gameObject == ground){
            print("Player Left Ground :D");
        }
    }

    void rotate_player(char direction){

        switch(direction){
            case 'l':
                this.transform.Rotate(new Vector3(0,-1,0));
                break;
            case 'r':
                this.transform.Rotate(new Vector3(0,1,0));
                break;
        }
        
    }
}
