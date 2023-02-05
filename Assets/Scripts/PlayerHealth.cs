using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : HealthScript
{
    public override void Die() {
        SceneManager.LoadScene("deathscene");
    }
}
