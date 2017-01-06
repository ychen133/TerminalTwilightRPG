/* NAME:            Stats.cs
 * AUTHOR:          Shinlynn Kuo, Yu-Che Cheng (Jeffrey), Hamza Awad, Emmilio Segovia
 * DESCRIPTION: 	This is the Stats script. It holds stats relevant to combat
 * 					such as HP, MP, AttackDamage, etc. 
 * REQUIREMENTS:    None
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	public string Name;
	public bool Playable;
	public int Level;
	public int MaxHP;
	public int HP;
	public int MaxMP;
	public int MP;
	public int AttackDamage;
	public int Agility;

	public Stats()
	{
		Name = "Player";
		Playable = true;
		Level = 1;
		MaxHP = 100;
		HP = 100;
		MaxMP = 100;
		MP = 100;
		AttackDamage = 10;
		Agility = 10;
	}

	public Stats(string name, bool play ,int level, int max_hp, int max_mp, int atk_dmg, int agl)
	{
		Name = name;
		Playable = play;
		Level = level;
		MaxHP = max_hp;
		HP = max_hp;
		MaxMP = max_mp;
		MP = max_mp;
		AttackDamage = atk_dmg;
		Agility = agl;
	}
		
	///<summary>
	///Attack: Subtracts attack damage from target's HP
	///<summary>
	public void Attack(Stats target)
	{
		target.HP -= AttackDamage;
		if (target.HP < 0)
			target.HP = 0;
	}
}
