using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemInputField : MonoBehaviour {

	InputField MyInputField;

	public void Reset()
	{
		if (MyInputField == null) {
			MyInputField = GetComponent<InputField> ();
		}
		MyInputField.text = "1";
	}
}
