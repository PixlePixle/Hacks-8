using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{

    [SerializeField] float damageAm;

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision);
        HealthScript healthHandler = collision.transform.GetComponent<HealthScript>();
        healthHandler.Damage(damageAm);
    }
}
