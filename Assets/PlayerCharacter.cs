using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    private CharacterController player;
    public float run_speed;
    public float jump_speed;
    private Vector3 direction;
    private Vector3 velocity; 
    public float gravity;
    public Vector3 terminal_velocity;

    private static float current_health = 3;
    public float max_health; 

    private bool hasJumped = false;

    void Awake()
    {
        player = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (!direction.Equals(Vector3.zero))
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        velocity = new Vector3(direction.x * run_speed, velocity.y, direction.z * run_speed);

        velocity.y = velocity.y - gravity * Time.fixedDeltaTime;
        if(velocity.y < terminal_velocity.y)
        {
            velocity.y = terminal_velocity.y;
        }
        player.Move(velocity * Time.fixedDeltaTime);

        if (player.isGrounded)
        {
            hasJumped = false; 
        }
    }

    public void SetDirection(Vector3 direction)
    {
        this.direction= direction;
    }

    public void Jump()
    {
        if (!hasJumped)
        {
            velocity.y = jump_speed;
            hasJumped = true; 
        }
    }

    public bool IsMoving()
    {
        return direction != Vector3.zero;
    }

    public void TakeDamage(float damage)
    {
        current_health -= damage;
        if(current_health < 0)
        {
            Debug.Log("died");
            current_health = max_health; 
        }
    }

    public float CurrentHealth
    {
        get { return current_health; }
    }

    public float MaxHealth
    {
        get { return max_health; }
    }
}
