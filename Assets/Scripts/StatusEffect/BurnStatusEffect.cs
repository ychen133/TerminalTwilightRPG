using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BurnStatusEffect : BaseStatusEffect{
    
	public BurnStatusEffect()
    {
        StatusEffectName = "Burn";
        StatusEffectDescription = "Burns the enemy.";
        StatusEffectDuration = 3;
        StatusEffectID = 1;
        StatusEffectApplyPercentage = 0.75;
    }
}
