using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyItemButton : MonoBehaviour, IPointerClickHandler
{
	public bool IsEnabled = true;

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (IsEnabled && ShopManager.Instance.SelectedItem != null) {
			ShopManager.Instance.OpenPopUp ();
		}
	}
}
