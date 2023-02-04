using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Max health of the object
    [SerializeField] float maxHealth;

    private float currHealth;

    private void Start() {
        currHealth = maxHealth;
    }

    public void Damage(float damageAm) {
        currHealth -= damageAm;
        if (currHealth <= 0) {
            this.Die();
        }
    }

    private void Die() {
        Destroy(gameObject);
    }
}
