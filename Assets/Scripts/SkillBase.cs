using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum TargetType {Single = 1, All = 2};
//public enum ValidTargets {Party = 1, Enemy = 2};
public enum TargetType {EnemySingle = 1, EnemyAll = 2, PartySingle = 3, PartyAll = 4};
public enum ScalingStat {None = 0, Strength = 1, Agillity = 2, Intelligence = 3, Defense = 4, Dexterity = 5, Luck = 6};

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

			
}
