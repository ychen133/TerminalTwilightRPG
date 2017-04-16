using UnityEditor;
using UnityEngine;

// IngredientDrawer
[CustomPropertyDrawer(typeof(ShopItem))]
public class ShopDrawer : PropertyDrawer
{
	// Draw the property inside the given rect
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		// Using BeginProperty / EndProperty on the parent property means that
		// prefab override logic works on the entire property.
		EditorGUI.BeginProperty(position, label, property);

		// Draw label
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		// Backup default indents. Set new indents to 0.
		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		// Calculate rects
		Rect itemRect = new Rect(position.x, position.y, (int)(position.width * 2.0/3.0), position.height);
		Rect priceRect = new Rect(position.x + itemRect.width + 5, position.y, (int)(position.width * 1.0/3.0 - 5), position.height);

		// Draw fields - passs GUIContent.none to each so they are drawn without labels
		EditorGUI.PropertyField(itemRect, property.FindPropertyRelative("Item"), GUIContent.none);
		EditorGUI.PropertyField(priceRect, property.FindPropertyRelative("Price"), GUIContent.none);

		// Restore default indents
		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}