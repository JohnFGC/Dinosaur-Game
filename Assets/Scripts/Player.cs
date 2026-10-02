using UnityEngine;

public class Player : MonoBehaviour {

    private CharacterController character;
    private Vector3 dir;

    public float gravity = 9.81f * 2f;
    public float jump = 8.5f;

    private void Awake(){
        //Initialize
        character = GetComponent<CharacterController>();
    }

    private void OnEnable(){
        //Happens once on start up
        
        dir = Vector3.zero;
        //Neutralize direction when game starts
    }

    private void Update(){
        //Update is called once per frame
        //Enables player to jump

        dir += Vector3.down * gravity * Time.deltaTime;
        //Gravity pulls player down

        if (character.isGrounded){
            dir = Vector3.down;

            if (Input.GetButton("Jump")){
                //Can only jump if grounded
                dir = Vector3.up * jump;
            }
        }

        character.Move(dir * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")) {
            //Causes Game Over on contact with enemy
            GameManager.instance.GameOver();
        }
    }
}
