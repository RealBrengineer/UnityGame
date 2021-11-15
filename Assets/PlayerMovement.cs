using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
	
	#region Public Variable
    public Rigidbody PlayerController;
    public CapsuleCollider Character;
    public float acceleration = 5000f;
    public float maxSpeed = 10f;
    public float decelerationFactor = 5f;
    public float jumpStrength = 10f;
    public float gravity = 3000f;
	#endregion
	
	#region Unity Methods
    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        float jump = Input.GetAxisRaw("Jump");
        
        PlayerController.AddForce(Vector3.down * gravity * Time.deltaTime);

        Vector3 move = transform.right * x + transform.forward * z;

        PlayerController.AddForce(move * acceleration * Time.deltaTime);
        
        PlayerController.velocity = Vector3.ClampMagnitude(PlayerController.velocity - decelerationFactor * Time.deltaTime * PlayerController.velocity, maxSpeed);

        bool isGrounded = Physics.BoxCast(Character.center, Character.bounds.extents + new Vector3(0f,0.1f,0f), Vector3.down, Quaternion.Euler(0f, 0f, 0f), 1f, 3);

        if(isGrounded && jump > 0 == true) {
            PlayerController.velocity += Vector3.up * jumpStrength;
        }
    }
	#endregion
}