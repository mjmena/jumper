using UnityEngine;

public class InputManager : MonoBehaviour {
    public PlayerCharacter player;
    public ThirdPersonCamera cam;
	
	void Update () {
        Vector3 input_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input_direction.Normalize();

        if (Input.GetButtonDown("Jump"))
        {
            player.Jump();
        }

        player.SetDirection(cam.GetCardinalRotation() * input_direction);
    }
}
