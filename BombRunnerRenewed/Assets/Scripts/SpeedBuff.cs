using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SpeedBuff")]
public class SpeedBuff : poweUp
{
    public float amount;
    public float duration;

    public override void Apply(GameObject target)
    {
        PlayerControll playerControl = target.GetComponent<PlayerControll>();
        if (playerControl != null)
        {
            playerControl.ApplySpeedBuff(amount, duration);
        }
    }
}
