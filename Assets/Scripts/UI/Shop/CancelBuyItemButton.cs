using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CancelBuyItemButton : MonoBehaviour, IPointerClickHandler
{
	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		ShopManager.Instance.ClosePopUp();
	}
}