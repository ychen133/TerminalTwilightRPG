using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AcceptBuyItemButton : MonoBehaviour, IPointerClickHandler {

	private int BuyQuantity = 1;

	public void UpdateBuyQuantity(string quantity)
	{
		BuyQuantity = int.Parse(quantity);
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (ShopManager.Instance.SelectedItem != null) {
			string Name = ShopManager.Instance.SelectedItem.Item.name;
			int ActualQuantity = Inventory.Instance.MaxPossibleAdded (Name, BuyQuantity);
			Debug.Log(ActualQuantity);
			Inventory.Instance.AddItem (Name, ActualQuantity);
		} else {
			Debug.LogError ("No item selected!");
		}
		ShopManager.Instance.ClosePopUp ();
	}

}
