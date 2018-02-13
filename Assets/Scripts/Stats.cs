/* NAME:            Stats.cs
 * AUTHOR:          Shinlynn Kuo, Yu-Che Cheng (Jeffrey), Hamza Awad, Emmilio Segovia
 * DESCRIPTION: 	This is the Stats script. It holds stats relevant to combat
 * 					such as HP, MP, AttackDamage, etc. 
 * REQUIREMENTS:    None
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
	//Bar Stats
    public string Name;
    public bool Playable;
    public int Level;
    public int MaxHP;
    
	[SerializeField]
	private int _HP;
	public int HP
	{
		get { return _HP; }
		set {
			_HP = value;
			if (_HP <= 0) {
				_HP = 0;
				Dead = true;
			} else {
				Dead = false;
			}
			if (_HP > MaxHP)
				_HP = MaxHP;
		}
	}

	public int MaxMP;
    public int MP;
	public int EXP;
	public int EXPNeeded;
	//Innate Stats
    public int Strength;
    public int Agility;
    public int Intelligence;
    public int Defense;
    public int Dexterity;
    public int Luck;
    public bool defending = false;
    
    public Sprite SmallSprite;
    public Sprite BigSprite;

	//Skills list
	public List<SkillBase> Skills;

	[SerializeField]
	private bool _Dead;
	public bool Dead
	{
		get {return _Dead; }
		set {
			_Dead = value;

		}
//		set {
//			//_Dead = value;
//			print("checking if "+HP+"is dead...");
//			if (this.HP <= 0) {
//				print ("yes, he's dead");
//				_Dead = true;
//			} else {
//				print("no, not dead);
//				_Dead = false;
//			}
//		}
	}

    public Stats()
    {
        Name = "Player";
        Playable = true;
        Level = 1;
        MaxHP = 100;
        HP = 100;
        MaxMP = 100;
        MP = 100;
		Strength = 10;
        Agility = 10;
        Intelligence = 10;
        Defense = 10;
        Dexterity = 10;
        Luck = 10;
    }

    public Stats(string name, bool play, int level, int max_hp, int max_mp, int str, int agl, int intl, int def, int dex, int lck)
    {
        Name = name;
        Playable = play;
        Level = level;
        MaxHP = max_hp;
        HP = max_hp;
        MaxMP = max_mp;
        MP = max_mp;
		Strength = str;
        Agility = agl;
        Intelligence = intl;
        Defense = def;
        Dexterity = dex;
        Luck = lck;
    }

    ///<summary>
    ///Attack: Subtracts attack damage from target's HP
    ///<summary>
    public int Attack()
    {
		if (HP <= 0)
			return 0;
        //calculate special damage here
		return Random.Range(Strength / 2, Strength);  //varies the damage
		//int atkDmg = Random.Range(Strength / 2, Strength);  //varies the damage
        //return target.TakeDamage(atkDmg);
    }

    ///<summary>
    ///Designate an amount of damage to be taken by the stat. Returns the damage dealt after calculation
    ///<summary>
    public int TakeDamage(int dmg)
    {
        if (defending) {
            dmg -= Defense;    //small flat damage reduction
            if (dmg < 0)
                dmg = 0;
            dmg = dmg / 2;
        }
        HP -= dmg;
//        if (HP < 0)
//        {
//            HP = 0;
//        }
//        else if (HP > MaxHP)
//        {
//            HP = MaxHP;
//        }
        return dmg;
    }

	///<summary>
	///Handle healing calculation
	///<summary>
	public int Heal(int num)
	{
		HP += num;
		if (HP > MaxHP)
			HP = MaxHP;
		return num;
	}

	///<summary>
	///Calculates output number whenever a Stats class uses a Skill
	///<summary>
	public int UseSkill(SkillBase skill)
	{
		MP -= skill.MPCost;
		int output = skill.Base;
		switch (skill.Scale) {
			case ScalingStat.None:
			{
				//no scale
				break;
			}
			case ScalingStat.Strength:
			{
				//Strength scale
				//output += (int)(Strength * skill.Max_Multiplier);
				output += (int)Random.Range(Strength * skill.Min_Multiplier, Strength * skill.Max_Multiplier);
				break;
			}
			case ScalingStat.Agillity:
			{
				//Agility scale
				output += (int)Random.Range(Agility * skill.Min_Multiplier, Agility * skill.Max_Multiplier);
				break;
			}
			case ScalingStat.Intelligence:
			{
				//Intelligence scale
				output += (int)Random.Range(Intelligence * skill.Min_Multiplier, Intelligence * skill.Max_Multiplier);
				break;
			}
			case ScalingStat.Defense:
			{
				//Defense scale
				output += (int)Random.Range(Defense * skill.Min_Multiplier, Defense * skill.Max_Multiplier);
				break;
			}
			case ScalingStat.Dexterity:
			{
				//Dexterity scale
				output += (int)Random.Range(Dexterity * skill.Min_Multiplier, Dexterity * skill.Max_Multiplier);
				break;
			}
			case ScalingStat.Luck:
			{
				//Luck scale
				output += (int)Random.Range(Luck * skill.Min_Multiplier, Luck * skill.Max_Multiplier);
				break;
			}
		}
		return output;
	}
}
