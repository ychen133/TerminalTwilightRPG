using UnityEngine;
using UnityEditor;

public class ItemAssetUtility
{
    [MenuItem("Assets/Create/Game Item")]
    public static void CreateItem()
    {
        ScriptableObjectUtility.CreateAsset<ItemBase>();
    }

	[MenuItem("Assets/Create/Game Skill")]
	public static void CreateSkill()
	{
		ScriptableObjectUtility.CreateAsset<SkillBase>();
	}
}