using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

	[HideInInspector]
	public ShopItem Entry;

	/// <summary>
	/// Sets up item name and price display
	/// </summary>
	public void Init (ShopItem it) {
		Entry = it;
		this.transform.GetChild (0).GetComponent<Image> ().sprite 	= Entry.Item.Sprite;	//sets icon of shop entry
		this.transform.GetChild (1).GetComponent<Text> ().text 		= Entry.Item.name;		//sets name of shop entry
		this.transform.GetChild (2).GetComponent<Text> ().text 		= Entry.Price + "";		//sets price of shop entry
	}

	/// <summary>
	/// Raises the click event.
	/// </summary>
	public void SetOnClick () {
		ShopManager.Instance.SetSelectedItem (Entry);
	}

}
