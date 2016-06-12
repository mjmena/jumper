using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
    public GameObject person;
    public float radius; 

	void Update () {
        
        transform.LookAt(person.transform.position);
	}
}
