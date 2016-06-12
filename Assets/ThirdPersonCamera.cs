using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public PlayerCharacter person;
    public float radius;
    public float height;
    public float max_degrees_per_second;
    public float max_units_per_second; 
   

    void LateUpdate()
    {

        Vector3 next_camera_position = Vector3.zero;
        if (person.IsMoving())
        {
            Quaternion next_camera_rotation = Quaternion.RotateTowards(GetCardinalRotation(), person.transform.rotation, max_degrees_per_second * Time.fixedDeltaTime);
            next_camera_position = (person.transform.position + next_camera_rotation * Vector3.forward * -radius);
        }
        else
        {
            next_camera_position = (person.transform.position + GetCardinalRotation() * Vector3.forward * -radius);
        }

        next_camera_position = Vector3.MoveTowards(transform.position, next_camera_position + Vector3.up * height, max_units_per_second * Time.fixedDeltaTime);

        transform.position = next_camera_position; 
        transform.LookAt(person.transform.position);
    }

    public Quaternion GetCardinalRotation()
    {
        return Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

}
