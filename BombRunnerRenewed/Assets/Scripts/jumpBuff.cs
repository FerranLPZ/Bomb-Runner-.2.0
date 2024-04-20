using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "JumpBuff")]
public class jumpBuff : poweUp
{
    public float amount;
    public float duration = 4f;
    public override void Apply(GameObject target)
    {
        PlayerControll playerControl = target.GetComponent<PlayerControll>();
        if (playerControl != null)
        {
            playerControl.ApplyJumpBuff(amount, duration);
        }

    }

}
