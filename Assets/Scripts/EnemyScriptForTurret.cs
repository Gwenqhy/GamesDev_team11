using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptForTurret : MonoBehaviour
{
    public void Destroyed()
    {
        Destroy(gameObject);
    }
}
