using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathEffect;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            other.transform.parent.gameObject.SetActive(false);
            //other.GetComponent<PlayerController>().TakeDamage();

            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
        }
    }
}
