using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : CharacterStats, IComparable {

    public BaseClass playerClass;

    public int experience;

	public int spendPoints;

    [SerializeField] Inventory inventory;
	[SerializeField] EquipmentPanel equipmentPanel;
	[SerializeField] ItemTooltip itemTooltip;
	[SerializeField] Image draggableItem;
	private ItemSlot draggedSlot;



	private void OnValidate() 
	{		
		if(itemTooltip == null)
			itemTooltip = FindObjectOfType<ItemTooltip>();		
	}


	public void receiveExperience(int experience) {
		this.experience += experience;
	}

    public BaseClass PlayerClass
    {
        get{ return playerClass;}
        set{ playerClass = value;}
    }

    public int Experience
    {
        get{ return experience;}
        set{ experience = value;}
    }

	public int SpendPoints
    {
        get{ return spendPoints;}
        set{ spendPoints = value;}
    }

	private void Awake() 
	{

	//Inventoy & Equipment events
		//Righ click
		inventory.OnRightClickEvent += Equip;
		equipmentPanel.OnRightClickEvent += Unequip;
		//Pointer Enter
		inventory.OnPointerEnterEvent += ShowTooltip;
		equipmentPanel.OnPointerEnterEvent += ShowTooltip;
		//Pointer exit
		inventory.OnPointerExitEvent += HideTooltip;
		equipmentPanel.OnPointerExitEvent += HideTooltip;
		//Begin Drag
		inventory.OnBeginDragEvent += BeginDrag;
		equipmentPanel.OnBeginDragEvent += BeginDrag;
		//En Drag
		inventory.OnEndDragEvent += EndDrag;
		equipmentPanel.OnEndDragEvent += EndDrag;
		//Drag
		inventory.OnDragEvent += Drag;
		equipmentPanel.OnDragEvent += Drag;	
		//Drop	
		inventory.OnDropEvent += Drop;
		equipmentPanel.OnDropEvent += Drop;


		
	}

	private void Equip(ItemSlot itemSlot)
	{
		EquippableItem equippableItem = itemSlot.Item as EquippableItem;
		if(equippableItem != null)
		{
			Equip(equippableItem);
		}

	}

	private void Unequip(ItemSlot itemSlot)
	{
		EquippableItem equippableItem = itemSlot.Item as EquippableItem;
		if(equippableItem != null)
		{
			Unequip(equippableItem);
		}

	}

	private void ShowTooltip(ItemSlot itemSlot)
	{
		EquippableItem equippableItem = itemSlot.Item as EquippableItem;
		if(equippableItem != null)
		{
		itemTooltip.ShowTooltip(equippableItem);
		}
	}

	private void HideTooltip(ItemSlot itemSlot)
	{
		itemTooltip.HideTooltip();
		
	}


	private void EquipFromIventory(Item item)
	{
		if(item is EquippableItem)
		{
			Equip((EquippableItem)item);
		}
	}	

	public void Equip(EquippableItem item)
	{
		if(inventory.RemoveItem(item))
		{
			EquippableItem previousItem;
			if(equipmentPanel.AddItem(item, out previousItem))
			{
				if(previousItem != null)
				{
					inventory.AddItem(previousItem);
					previousItem.Unequip(this);					
				}
				else
				{
					inventory.AddItem(item);
				}
			}
		}
	}

	private void UnequipFromEquipPanel(Item item)
	{
		if(item is EquippableItem)
		{
			Unequip((EquippableItem)item);
		}
	}

	public void Unequip(EquippableItem item)
	{
		if(!inventory.IsFull() && equipmentPanel.RemoveItem(item))
		{
			item.Unequip(this);
			inventory.AddItem(item);            
		}
	}	

	private void BeginDrag(ItemSlot itemSlot)
	{
		if(itemSlot != null)
		{
			draggedSlot = itemSlot;
			draggableItem.sprite = itemSlot.Item.Icon;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.enabled = true;
		}
	}

	private void EndDrag(ItemSlot itemSlot)
	{
		draggedSlot = null;
		draggableItem.enabled = false;
	}

	private void Drag(ItemSlot itemSlot)
	{
		if(!draggableItem.enabled)
		{
			draggableItem.transform.position = Input.mousePosition;
		}
	}
	private void Drop(ItemSlot dropItemSlot)
	{
		if(draggedSlot == null)return;		

		if(dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
		{
			EquippableItem dragItem = draggedSlot.Item as EquippableItem;
			EquippableItem dropItem = dropItemSlot.Item as EquippableItem;

			if(draggedSlot is EquipmentSlot)
			{
				if(dragItem != null) dragItem.Unequip(this);
				if(dropItem != null) dropItem.Equip(this);
			}
			if(dropItemSlot is EquipmentSlot)
				if(dragItem != null) dragItem.Equip(this);
				if(dropItem != null) dropItem.Unequip(this);
		}

		Item draggedItem = draggedSlot.Item;
		draggedSlot.Item = dropItemSlot.Item;
		dropItemSlot.Item = draggedItem;
	}

	

	


}
