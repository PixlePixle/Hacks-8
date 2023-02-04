using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthScript
{
    public override void Die() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
