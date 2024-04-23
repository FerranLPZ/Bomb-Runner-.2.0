using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HealthBuff")]
public class HealthBuff : poweUp
{
    public float amount;

    public override void Apply(GameObject target)
    {
        PlayerControll playerControl = target.GetComponent<PlayerControll>();
        if (playerControl != null)
        {
            playerControl.ApplyHealthBuff(amount);
        }
    }
}

