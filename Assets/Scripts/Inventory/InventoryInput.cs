using UnityEngine;

public class InventoryInput : MonoBehaviour
{
	[SerializeField] GameObject inventoryGameObject;
	[SerializeField] KeyCode[] toggleIventoryKeys;

	private void Update() {
		
		for(int i=0; i < toggleIventoryKeys.Length; i++)
		{
			if(Input.GetKeyDown(toggleIventoryKeys[i]))
			{
				inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
				break;
			}
		}
	}
}