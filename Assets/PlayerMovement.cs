using UnityEngine;

	
public class PlayerMovement : MonoBehaviour
{
	
	#region Public Variable
    public Rigidbody PlayerController;
    public float speed = 3000f;
    public float maxSpeed = 0f;
    public float gravity = 1500f;
	#endregion
	
	#region Unity Methods

    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        PlayerController.AddForce(Vector3.down * gravity * Time.deltaTime);

        Vector3 move = transform.right * x + transform.forward * z;

        PlayerController.AddForce(move * speed * Time.deltaTime);
        
        PlayerController.velocity -= 0.01f * PlayerController.velocity;
    }
	
	#endregion
}
