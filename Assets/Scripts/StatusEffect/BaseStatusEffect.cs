using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Status")]
[System.Serializable]
public class BaseStatusEffect : ScriptableObject{

    [SerializeField]
    private string _StatusEffectName;
    public string StatusEffectName
    {
        get { return _StatusEffectName; }
        set { _StatusEffectName = value; }
    }

    [SerializeField]
    [TextArea]
    private string _StatusEffectDescription;
    public string StatusEffectDescription
    {
        get { return _StatusEffectDescription; }
        set { _StatusEffectDescription = value; }
    }

    [SerializeField]
    private int _StatusEffectDuration;
    public int StatusEffectDuration
    {
        get { return _StatusEffectDuration; }
        set { _StatusEffectDuration = value; }
    }

    [SerializeField]
    private double _StatusEffectApplyPercentage;
    public double StatusEffectApplyPercentage
    {
        get { return _StatusEffectApplyPercentage; }
        set { _StatusEffectApplyPercentage = value; }
    }

    [SerializeField]
    private int _StatusEffectID;
    public int StatusEffectID
    {
        get { return _StatusEffectID; }
        set { _StatusEffectID = value; }
    }
}
