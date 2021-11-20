using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	
	#region Public Variable
    public Rigidbody PlayerController;
    public float accelerationFactor = 5000f;
    public float airAccelerationFactor = 0.05f;
    public float maxSpeed = 10f;
    public float decelerationFactor = 5f;
    public Transform groundCheckObject;
    public float groundDistance = 0.01f;
    public LayerMask groundMask;
    public float jumpStrength = 10f;
    bool jumpReady = true;
    bool isGrounded;
    public float jumpCooldown = 0.25f;
    public float gravity = 3000f;
    Vector3 moveDirection;
	#endregion
	
	#region Unity Methods
    void Update() {
        inputs();
    }

    void FixedUpdate() {
        bool isGrounded = Physics.CheckBox(groundCheckObject.position, new Vector3(0.25f, groundDistance, 0.25f), Quaternion.Euler(0f, 0f, 0f), groundMask);
        PlayerController.AddForce(Vector3.down * gravity * Time.fixedDeltaTime);
        movement();
        jump();
    }

    void inputs() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = transform.right * x + transform.forward * z * Time.deltaTime;
    }

    void movement(){
        if(isGrounded) {
            PlayerController.velocity = -decelerationFactor * PlayerController.velocity * Time.fixedDeltaTime;
        }

        if(isGrounded) {
            PlayerController.AddForce(moveDirection * accelerationFactor, ForceMode.Acceleration);
        }else if(!isGrounded) {
            PlayerController.AddForce(airAccelerationFactor * moveDirection * accelerationFactor, ForceMode.Acceleration);
        }
    }

    void jump() {
        if(isGrounded && jumpReady && Input.GetKeyDown("space")) {
            jumpReady = false;
            PlayerController.velocity.Set(PlayerController.velocity.x, 0f, PlayerController.velocity.z);
            PlayerController.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            Invoke("resetJump", jumpCooldown);
        }
    }

    void resetJump() {
            jumpReady = true;
    }
	#endregion
}