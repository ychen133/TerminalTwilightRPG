/* NAME:            ShopItem.cs
 * AUTHOR:          Kevin Huang
 * DESCRIPTION:     Class for shop items.
 * REQUIREMENTS:    Values must be filled out in Unity Inspector.
 * 					Usually used within an array.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem 
{
	public ItemBase Item;
	public int Price;

}
