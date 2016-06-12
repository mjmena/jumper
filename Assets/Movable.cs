using UnityEngine;
using System.Collections;

public class Movable : MonoBehaviour {
    private CharacterController player;
    public float run_speed;
    public float jump_speed;
    private Vector3 velocity;

    public float gravity;
    public Vector3 terminal_velocity;

    void Awake()
    {
        player = GetComponent<CharacterController>();
        velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        direction = transform.TransformDirection(direction);

        if (!direction.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }




        Vector3 new_velocity = direction * run_speed;


        if (player.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                new_velocity.y = jump_speed;
            }
        }
        else
        {
            new_velocity.y = velocity.y - gravity;
        }

        player.Move(new_velocity * Time.fixedDeltaTime);
        velocity = new_velocity;
    }
}
