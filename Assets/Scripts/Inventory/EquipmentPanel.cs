using System;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
	{
	[SerializeField] Transform equipmentSlotsParent;
	[SerializeField] EquipmentSlot[] equipmentSlots;
	public event Action<ItemSlot> OnRightClickEvent;
	public event Action<ItemSlot> OnPointerExitEvent;
	public event Action<ItemSlot> OnPointerEnterEvent;
	public event Action<ItemSlot> OnDragEvent;
	public event Action<ItemSlot> OnBeginDragEvent;
	public event Action<ItemSlot> OnDropEvent;
	public event Action<ItemSlot> OnEndDragEvent;


	private void Start()
	{
		for(int i=0; i < equipmentSlots.Length; i++)
		{
				equipmentSlots[i].OnRightClickEvent +=  slot => OnRightClickEvent(slot);
				equipmentSlots[i].OnPointerExitEvent += OnPointerExitEvent;
				equipmentSlots[i].OnPointerEnterEvent += OnPointerEnterEvent;
				equipmentSlots[i].OnDragEvent += OnDragEvent;	
				equipmentSlots[i].OnBeginDragEvent += OnBeginDragEvent;
				equipmentSlots[i].OnEndDragEvent += OnEndDragEvent;
				equipmentSlots[i].OnDropEvent += OnDropEvent;

		}
	}

	private void OnValidate()
	{
		equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
	}

	public bool AddItem(EquippableItem item, out EquippableItem previousItem)
	{
			for (int i = 0; i < equipmentSlots.Length; i++)
			{
				if (equipmentSlots[i].EquipmentType == item.EquipmentType)
				{
					previousItem = (EquippableItem)equipmentSlots[i].Item;
					equipmentSlots[i].Item = item;
					//equipmentSlots[i].Amount = 1;
					return true;
				}
			}
			previousItem = null;
			return false;
	}

	public bool RemoveItem(EquippableItem item)
	{
		for (int i = 0; i < equipmentSlots.Length; i++)
		{
			if (equipmentSlots[i].Item == item)
			{
				equipmentSlots[i].Item = null;
				//equipmentSlots[i].Amount = 0;
				return true;
			}
		}
		return false;
	}
}

