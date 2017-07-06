using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopManager : Singleton<ShopManager> {

	public ShopManager () {}	//prevents constructor from being used

	[Header("Main Shop Reference")]
	public ShopInventory MyShop;	//reference to the ShopInventory ScritableObject

	[Header("UI References")]
	public GameObject ShopCanvas;	//reference to shop canvas
	public GameObject BGBlur;		//reference to background blur
	public GameObject MenuTransform;//reference to menu transform for animation
	public Transform ListArea;		//reference to Scroll View Content containing shop items
	public GameObject ButtonPrefab;	//reference to prefab for shop entries
	public Image Details;			//reference to details panel main image
	public Text ItemName;			//reference to details panel item name
	public Text Description;		//reference to details panel description text
	public GameObject BuyItemPopUp;	//reference to buy quantity popup
	public BuyItemPopup PopupScript;//reference to buy quantity popup's script
	public GameObject BuyButton;	//reference to buy item button


	[HideInInspector]
	private bool PopupOpen;
	private ShopItem si;
	public ShopItem SelectedItem {
		
		get 
		{ 
			return si; 
		}

		set 
		{
			if (value == null) 
			{
				Details.sprite = null;
				ItemName.text = "";
				Description.text = "";
				BuyButton.SetActive (false);
			}
			else 
			{
				Details.sprite = value.Item.Sprite;
				ItemName.text = value.Item.name;
				Description.text = value.Item.Description;
				BuyButton.SetActive (true);
			}
			si = value;
		}
	}



	void OnEnable () 
	{
		Refresh ();
	}
		
	void OnDisable () 
	{
		Clean ();
	}

	void Awake () 
	{
		PopupScript = BuyItemPopUp.GetComponent<BuyItemPopup> ();
		PopupOpen = false;
	}


	void Update () 
	{
		// If the popup is open and the player clicked outside the popup, then close the popup.
		if (Input.GetMouseButton (0) && !PopupScript.MouseOver && PopupOpen) {
			ClosePopUp ();
		}
	}

	/// <summary>
	/// Populates ListView with shop entries
	/// </summary>
	void Refresh () 
	{
		Clean ();

		foreach (ShopItem entry in MyShop.ShopItems) 
		{
			GameObject NewButton = Instantiate (ButtonPrefab, ListArea);
			NewButton.transform.GetComponent<ShopButton> ().Init (entry);	//sets up button using ShopItem data
		}
	}

	/// <summary>
	/// Deletes shop entries to save memory
	/// </summary>
	void Clean () 
	{
		for (int i = ListArea.childCount - 1; i >= 0; i--) 
		{
			Destroy (ListArea.GetChild (i).gameObject);
		}
	}

	/// <summary>
	/// Opens the shop menu.
	/// </summary>
	public void OpenShopMenu () 
	{
		GameManager.Instance.SetState (GameStates.ShopState);
		PopupOpen = false;
		BGBlur.SetActive (true);
		SelectedItem = null;
		MenuTransform.GetComponent<Animator> ().SetTrigger ("Open");
		Refresh ();

	}

	/// <summary>
	/// Closes the shop menu.
	/// </summary>
	public void CloseShopMenu () 
	{
		Clean ();
		GameManager.Instance.SetState (GameStates.IdleState);
		BGBlur.SetActive (false);
		SelectedItem = null;
		MenuTransform.GetComponent<Animator> ().SetTrigger ("Close");

	}

	/// <summary>
	/// Sets the selected item.
	/// </summary>
	/// <param name="it">The item to be selected.</param>
	public void SetSelectedItem (ShopItem it) 
	{
		SelectedItem = it;
	}

	/// <summary>
	/// Opens the popup.
	/// </summary>
	public void OpenPopUp () 
	{
		if (!PopupOpen) 
		{
			PopupOpen = true;
			BuyButton.GetComponent<Button> ().enabled = false;
			BuyItemPopUp.GetComponent<Animator> ().SetTrigger ("Open");

			// Reset all button states to unhighlighted
			foreach (Button b in BuyItemPopUp.GetComponentsInChildren<Button>()) 
			{
				b.enabled = false;
				b.enabled = true;
			}
		}
	}

	/// <summary>
	/// Closes the popup.
	/// </summary>
	public void ClosePopUp () 
	{
		if (PopupOpen) 
		{
			PopupOpen = false;
			BuyButton.GetComponent<Button> ().enabled = true;
			BuyItemPopUp.GetComponent<Animator> ().SetTrigger ("Close");
		}

	}
}
