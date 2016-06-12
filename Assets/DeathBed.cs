using UnityEngine;
using System.Collections;

public class DeathBed : MonoBehaviour {

    public void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
    }
}
