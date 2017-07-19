/* NAME:            Inventory.cs
 * AUTHOR:          Shinlynn Kuo, Yu-Che Cheng (Jeffrey), Hamza Awad, Emmilio Segovia
 * DESCRIPTION:     This manages items stored in a lists based on item type, limit by number, 
 *                  display quantity/sprite of items.
 * REQUIREMENTS:    None
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory> {

    // CONSTANTS
    private const int POCKETCAPACITY = 60;

    [Header("To Display Lists in Menu")]
    public GameObject MenuItemImagePrefab;
    public GameObject MenuItemQuantityPrefab;
    public GameObject DragImage; //found as last child of MenuCanvas
    [Space(10)]

    /// Dictionaries of all categories or "pockets" in bag for each item in inventory
    /// The value is the quantity of that item. 
    /// Each dict represents one "pocket" of the inventory bag.
    private Dictionary<string, int> Consumables = new Dictionary<string, int>();
    private Dictionary<string, int> Weapons = new Dictionary<string, int>();
    private Dictionary<string, int> Gear = new Dictionary<string, int>();
    private Dictionary<string, int> Materials = new Dictionary<string, int>();
    private Dictionary<string, int> Keys = new Dictionary<string, int>();

    /// <summary>
    /// Maximum number of items for each category. 
    /// So the total capacity = PocketCapacity * NumberofItemTypes (currently 5 types)
    /// It preferrable to set it to a multiple of the items-per-row of the main menu (currently 6)
    /// </summary>
    private int _PocketCapacity = POCKETCAPACITY;
    public int PocketCapacity {
        get
        {
            return _PocketCapacity;
        }
        set
        {
            if (value < 0)
                _PocketCapacity = 0;
            else if (value > POCKETCAPACITY)
                _PocketCapacity = POCKETCAPACITY;
            else
                _PocketCapacity = value;
        }
    }
    
    /// <summary>
    /// This is the method called by Interactables, when looting, purchasing, etc
    /// to add an item to the inventory. 
    /// </summary>
    public int AddItem(string item_name, int quantity)
    {
        if (ResourceManager.Instance.GetItem(item_name)) { //if item exists
            ItemBase item_base = ResourceManager.Instance.GetItem(item_name);
            ItemTypes item_type = item_base.Type;
            Dictionary<string, int> update_dict;
            GameObject update_grid;
            switch (item_type) {
                case ItemTypes.Consumable:
                    update_dict = Consumables;
                    update_grid = UIManager.Instance.GoodiesGrid;
                    break;
                case ItemTypes.Weapon:
                    update_dict = Weapons;
                    update_grid = UIManager.Instance.WeaponsGrid;
                    break;
                case ItemTypes.Gear:
                    update_dict = Gear;
                    update_grid = UIManager.Instance.GearGrid;
                    break;
                case ItemTypes.Material:
                    update_dict = Materials;
                    update_grid = UIManager.Instance.MaterialsGrid;
                    break;
                default:
                    update_dict = Keys;
                    update_grid = UIManager.Instance.KeysGrid;
                    break;
            }
            // Error Lists
            //error 1: can't add another unique item
            if (!update_dict.ContainsKey(item_name) && update_dict.Count >= _PocketCapacity)
            {
                Debug.LogWarning("Cannot add "+ item_name + " because the " + update_dict.ToString()
                    + "inventory pocket has a capacity of "+_PocketCapacity + " and there are already " + update_dict.Count + " DIFFERENT items (not counting individual quantities)");
                return 1;
            }
            //error 2: contained, but max amount of that particular item is reached
            if (update_dict.ContainsKey(item_name) && (update_dict[item_name] + quantity)
                > item_base.MaxAmount)
            {
                Debug.LogWarning("Cannot add " + quantity + " " + item_name + " because the max amount of " + item_name + " is "
                    + item_base.MaxAmount + " and there are already " + update_dict[item_name]);
                return 2;
            }
			//error 3: not contained, but max amount  of that particular item is reached
			if (quantity > item_base.MaxAmount) {
				Debug.LogWarning ("Cannot add " + quantity + " " + item_name + " because the max amount of " + item_name + " is "
				+ item_base.MaxAmount);
				return 3;
			}
            // else s
            if (!update_dict.ContainsKey(item_name)) {
                update_dict.Add(item_name, quantity);
            }
            else {
                update_dict[item_name] += quantity;
            }
            UpdateItemGrids(update_dict, update_grid);
            return 0;
        }
        else
            Debug.LogError(item_name+" was not added to inventory.");
        return -1;
    }

    /// <summary>
    /// Remove item from player inventory
    /// </summary>
    public void RemoveItem(string item_name, int quantity)
    {
        ItemBase item_base = ResourceManager.Instance.GetItem(item_name);
        ItemTypes item_type = item_base.Type;
        Dictionary<string, int> update_dict;
        GameObject update_grid;
        switch (item_type) { //get proper references based on item type
            case ItemTypes.Consumable:
                update_dict = Consumables;
                update_grid = UIManager.Instance.GoodiesGrid;
                break;
            case ItemTypes.Weapon:
                update_dict = Weapons;
                update_grid = UIManager.Instance.WeaponsGrid;
                break;
            case ItemTypes.Gear:
                update_dict = Gear;
                update_grid = UIManager.Instance.GearGrid;
                break;
            case ItemTypes.Material:
                update_dict = Materials;
                update_grid = UIManager.Instance.MaterialsGrid;
                break;
            default:
                update_dict = Keys;
                update_grid = UIManager.Instance.KeysGrid;
                break;
        }
        if (update_dict.ContainsKey(item_name)) {
            if ((update_dict[item_name] - quantity) <= 0) { //if less than 0, set to 0
                update_dict[item_name] = 0;
            }
            else {
                update_dict[item_name] -= quantity; //otherwise subtract quantity
            }
            if (update_dict[item_name] <= 0) { //if there are not more of this item in inventory
                update_dict.Remove(item_name);
                UIManager.Instance.ItemSelectGlow.SetActive(false);
            }
            UpdateItemGrids(update_dict, update_grid);
        }
        else
            Debug.LogError(item_name+" could not be removed");
    }

	public int MaxPossibleAdded(string item_name, int quantity) {
		ItemBase item_base = ResourceManager.Instance.GetItem (item_name);
		if (item_base != null) {
			ItemTypes item_type = item_base.Type;
			Dictionary<string, int> update_dict;
			switch (item_type) {
				case ItemTypes.Consumable:
					update_dict = Consumables;
					break;
				case ItemTypes.Weapon:
					update_dict = Weapons;
					break;
				case ItemTypes.Gear:
					update_dict = Gear;
					break;
				case ItemTypes.Material:
					update_dict = Materials;
					break;
				default:
					update_dict = Keys;
					break;
			}

			if (update_dict.ContainsKey (item_name)) 
			{
				return Mathf.Clamp (quantity, 0, item_base.MaxAmount - update_dict [item_name]);
			} 
			else if (update_dict.Count >= _PocketCapacity)
			{
				return 0;
			}
			else {
				return Mathf.Clamp (quantity, 0, item_base.MaxAmount);
			}

		} else {
			return 0;
		}
	}

    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Updates the items shown on each grid in the main menu.
    /// </summary>
    private void UpdateItemGrids(Dictionary<string, int> pocket, GameObject grid)
    {
        //get and disable last items' images
        Image[] last_children = grid.transform.GetComponentsInChildren<Image>();
        List<Image> images = new List<Image>();
        foreach (Image img in last_children) {
            images.Add(img);
            img.enabled = false;
            img.GetComponentInChildren<Text>().enabled = false;
        }
        //add more images for more items is needed
        GameObject new_image;
        GameObject new_text;
        while (grid.transform.childCount < pocket.Count) {
            new_image = GameObject.Instantiate(MenuItemImagePrefab);
            new_text = GameObject.Instantiate(MenuItemQuantityPrefab);
            new_image.transform.SetParent(grid.transform);
            new_text.transform.SetParent(new_image.transform);
            images.Add(new_image.GetComponent<Image>());
        }
        //put data from each item in inventory onto each image in the menu
        ItemBase current_item; //this iterates through the items in inventory
        Text current_text;
        int j = 0;
        foreach (string key in pocket.Keys) {
            current_item = ResourceManager.Instance.GetItem(key);
            images[j].gameObject.GetComponent<SetItemClickable>().MyItem = current_item;
            images[j].sprite = current_item.Sprite;
            current_text = images[j].transform.GetComponentInChildren<Text>();
            current_text.text = pocket[key].ToString();
            images[j].enabled = true;
            current_text.enabled = true;
            j++;
        }
    }
}
