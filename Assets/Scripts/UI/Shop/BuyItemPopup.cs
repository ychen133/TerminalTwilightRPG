using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyItemPopup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[HideInInspector]
	public bool MouseOver = true;

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		MouseOver = true;
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		MouseOver = false;
	}

}
