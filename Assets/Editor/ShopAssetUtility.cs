using UnityEngine;
using UnityEditor;

public class ShopAssetUtility{

	[MenuItem("Assets/Create/Shop")]
	public static void CreateShop()
	{
		ScriptableObjectUtility.CreateAsset<ShopInventory> ();
	}
}
