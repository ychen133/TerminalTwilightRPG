using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StunStatusEffect : BaseStatusEffect{

    public StunStatusEffect()
    {
        StatusEffectName = "Stun";
        StatusEffectDescription = "Stuns the enemy.";
        StatusEffectDuration = 2;
        StatusEffectID = 2;
        StatusEffectApplyPercentage = 0.75;
    }
}
