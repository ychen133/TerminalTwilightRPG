using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopMenuButton : MonoBehaviour, IPointerClickHandler
{
	public bool IsEnabled = true;

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (IsEnabled) {
			//only works if in IdleState
			if (GameManager.Instance.IsState(GameStates.IdleState)) {
				//toggle active status
				ShopManager.Instance.ShopCanvas.SetActive (true);
				ShopManager.Instance.OpenShopMenu ();
			}
			else if (GameManager.Instance.IsState(GameStates.ShopState)) {
				ShopManager.Instance.CloseShopMenu();
			}
		}
	}

}
