using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum TargetType {Single = 1, All = 2};
//public enum ValidTargets {Party = 1, Enemy = 2};
public enum TargetType {EnemySingle = 1, EnemyAll = 2, PartySingle = 3, PartyAll = 4};
public enum ScalingStat {None = 0, Strength = 1, Agillity = 2, Intelligence = 3, Defense = 4, Dexterity = 5, Luck = 6};
//public enum Status {None = 0, Poisoned = 1, Burned = 2. Frozen = 3, Stunned = 4, };

[CreateAssetMenu(fileName = "Skill")]
[System.Serializable]
public class SkillBase : ScriptableObject {

	/// <summary>
	/// Name of skill
	/// </summary>
	[SerializeField]
	private string _SkillName;// = "<Use 'Title Case'>";
	public string SkillName {
		get {
			return _SkillName;
		}
	}

	/// <summary>
	/// MP Cost of skill
	/// </summary>
	[SerializeField]
	private int _MPCost;// = "<Use 'Title Case'>";
	public int MPCost {
		get
		{
			return _MPCost;
		}
	}

	/// <summary>
	/// Min Multiplier value
	/// </summary>
	[SerializeField]
	private float _Min_Multiplier;
	public float Min_Multiplier {
		get{
			return _Min_Multiplier;
		}
	}

	/// <summary>
	/// Max Multiplier value
	/// </summary>
	[SerializeField]
	private float _Max_Multiplier;
	public float Max_Multiplier {
		get{
			return _Max_Multiplier;
		}
	}

	/// <summary>
	/// Base value
	/// </summary>
	[SerializeField]
	private int _Base;
	public int Base {
		get
		{
			return _Base;
		}
	}

	/// <summary>
	/// Target type of the skill
	/// </summary>
	[SerializeField]
	private TargetType _targettype;
	public TargetType targettype {
		get {
			return _targettype;
		}
	}

	/// <summary>
	/// Skill Text
	/// </summary>
	[SerializeField]
    [TextArea]
	private string _SkillDescText;
	public string SkillDescText {
		get {
			return _SkillDescText;
		}
	}

	/// <summary>
	/// The stat the skill's damage/effectiveness scales with
	/// </summary>
	[SerializeField]
	private ScalingStat _Scale;
	public ScalingStat Scale {
		get {
			return _Scale;
		}
	}

    [SerializeField]
    private BaseStatusEffect _SkillEffect; // = new List<BaseStatusEffect>();
    public BaseStatusEffect SkillEffect
    {
        get { return _SkillEffect; }
        set { _SkillEffect = value; }
    }

    //[SerializeField]
    //effect prefab here
    //BattleManager instantiate Effect prefab
}
   
//StatusEffects: Debuffs(passive) and Effects(active)
//public abstract class StatusEffect : MonoBehaviour
//{

//    [SerializeField]
//    private string _Name;
//    public string Name
//    {
//        get
//        {
//            return _Name;
//        }
//    }

//    [SerializeField]
//    private int _Duration;
//    public int Duration
//    {
//        get
//        {
//            return _Duration;
//        }
//        set
//        {
//            _Duration = value;
//        }
//    }

//    public virtual void PerTurn()
//    {
//        if(Duration > 0)
//            Duration--;
//    }
//}

//public class Buff : StatusEffect
//{
//    //how much is the stat value changed
//    [SerializeField]
//    private int _ChangeValue;
//    public int ChangeValue
//    {
//        get
//        {
//            return _ChangeValue;
//        }
//    }

//    //which Stat is affected
//    [SerializeField]
//    private ScalingStat _AffectedStat;
//    public ScalingStat AffectedStat
//    {
//        get
//        {
//            return _AffectedStat;
//        }
//    }
//}

//public class Effect : StatusEffect
//{
//    //the damage overtime, if any
//    [SerializeField]
//    private int _Damage;
//    public int Damage
//    {
//        get
//        {
//            return _Damage;
//        }
//    }

//    public override void PerTurn()
//    {
//        if (Duration > 0)
//            Duration--;
//    }
//}
