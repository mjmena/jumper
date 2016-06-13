using UnityEngine;

public class DamageOverTime : MonoBehaviour {
    public float damage_per_second;

    public void OnTriggerStay(Collider c)
    {
        c.GetComponent<PlayerCharacter>().TakeDamage(damage_per_second * Time.deltaTime);
    }

}
