using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;


public class PlayerStats : CharacterStats, IComparable {

    public BaseClass playerClass;

    public int experience;

	public int spendPoints;

	[Header("Public")]
	public Inventory Inventory;
	public EquipmentPanel EquipmentPanel;

	[Header("Serialize Field")]
	[SerializeField] ItemTooltip itemTooltip;
	[SerializeField] Image draggableItem;



	private BaseItemSlot dragItemSlot;

	private void OnValidate()
	{
		if (itemTooltip == null)
			itemTooltip = FindObjectOfType<ItemTooltip>();
	}

	private void Awake()
	{

		// Setup Events:
		// Right Click
		Inventory.OnRightClickEvent += InventoryRightClick;
		EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;
		// Pointer Enter
		Inventory.OnPointerEnterEvent += ShowTooltip;
		EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
		// Pointer Exit
		Inventory.OnPointerExitEvent += HideTooltip;
		EquipmentPanel.OnPointerExitEvent += HideTooltip;
		// Begin Drag
		Inventory.OnBeginDragEvent += BeginDrag;
		EquipmentPanel.OnBeginDragEvent += BeginDrag;
		// End Drag
		Inventory.OnEndDragEvent += EndDrag;
		EquipmentPanel.OnEndDragEvent += EndDrag;
		// Drag
		Inventory.OnDragEvent += Drag;
		EquipmentPanel.OnDragEvent += Drag;
		// Drop
		Inventory.OnDropEvent += Drop;
		EquipmentPanel.OnDropEvent += Drop;
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

	private void InventoryRightClick(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item is EquippableItem)
		{
			Equip((EquippableItem)itemSlot.Item);
		}
		else if (itemSlot.Item is UsableItem)
		{
			UsableItem usableItem = (UsableItem)itemSlot.Item;
			usableItem.Use(this);

			if (usableItem.IsConsumable)
			{
				itemSlot.Amount--;
				usableItem.Destroy();
			}
		}
	}

	private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item is EquippableItem)
		{
			Unequip((EquippableItem)itemSlot.Item);
		}
	}

	private void ShowTooltip(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			itemTooltip.ShowTooltip(itemSlot.Item);
		}
	}

	private void HideTooltip(BaseItemSlot itemSlot)
	{
		if (itemTooltip.gameObject.activeSelf)
		{
			itemTooltip.HideTooltip();
		}
	}

	private void BeginDrag(BaseItemSlot itemSlot)
	{
		if (itemSlot.Item != null)
		{
			dragItemSlot = itemSlot;
			draggableItem.sprite = itemSlot.Item.Icon;
			draggableItem.transform.position = Input.mousePosition;
			draggableItem.gameObject.SetActive(true);
		}
	}

	private void Drag(BaseItemSlot itemSlot)
	{
		draggableItem.transform.position = Input.mousePosition;
	}

	private void EndDrag(BaseItemSlot itemSlot)
	{
		dragItemSlot = null;
		draggableItem.gameObject.SetActive(false);
	}

	private void Drop(BaseItemSlot dropItemSlot)
	{
		if (dragItemSlot == null) return;

		if (dropItemSlot.CanAddStack(dragItemSlot.Item))
		{
			AddStacks(dropItemSlot);
		}
		else if (dropItemSlot.CanReceiveItem(dragItemSlot.Item) && dragItemSlot.CanReceiveItem(dropItemSlot.Item))
		{
			SwapItems(dropItemSlot);
		}
	}

	private void AddStacks(BaseItemSlot dropItemSlot)
	{
		int numAddableStacks = dropItemSlot.Item.MaximumStacks - dropItemSlot.Amount;
		int stacksToAdd = Mathf.Min(numAddableStacks, dragItemSlot.Amount);

		dropItemSlot.Amount += stacksToAdd;
		dragItemSlot.Amount -= stacksToAdd;
	}

	private void SwapItems(BaseItemSlot dropItemSlot)
	{
		EquippableItem dragEquipItem = dragItemSlot.Item as EquippableItem;
		EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

		if (dropItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Equip(this);
			if (dropEquipItem != null) dropEquipItem.Unequip(this);
		}
		if (dragItemSlot is EquipmentSlot)
		{
			if (dragEquipItem != null) dragEquipItem.Unequip(this);
			if (dropEquipItem != null) dropEquipItem.Equip(this);
		}


		Item draggedItem = dragItemSlot.Item;
		int draggedItemAmount = dragItemSlot.Amount;

		dragItemSlot.Item = dropItemSlot.Item;
		dragItemSlot.Amount = dropItemSlot.Amount;

		dropItemSlot.Item = draggedItem;
		dropItemSlot.Amount = draggedItemAmount;
	}

	public void Equip(EquippableItem item)
	{
		if (Inventory.RemoveItem(item))
		{
			EquippableItem previousItem;
			if (EquipmentPanel.AddItem(item, out previousItem))
			{
				if (previousItem != null)
				{
					Inventory.AddItem(previousItem);
					previousItem.Unequip(this);

				}
				item.Equip(this);

			}
			else
			{
				Inventory.AddItem(item);
			}
		}
	}
	public void Unequip(EquippableItem item)
	{
		if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
		{
			item.Unequip(this);
			Inventory.AddItem(item);
		}
	}

	private ItemContainer openItemContainer;

	private void TransferToItemContainer(BaseItemSlot itemSlot)
	{
		Item item = itemSlot.Item;
		if (item != null && openItemContainer.CanAddItem(item))
		{
			Inventory.RemoveItem(item);
			openItemContainer.AddItem(item);
		}
	}

	private void TransferToInventory(BaseItemSlot itemSlot)
	{
		Item item = itemSlot.Item;
		if (item != null && Inventory.CanAddItem(item))
		{
			openItemContainer.RemoveItem(item);
			Inventory.AddItem(item);
		}
	}

	public void OpenItemContainer(ItemContainer itemContainer)
	{
		openItemContainer = itemContainer;

		Inventory.OnRightClickEvent -= InventoryRightClick;
		Inventory.OnRightClickEvent += TransferToItemContainer;

		itemContainer.OnRightClickEvent += TransferToInventory;

		itemContainer.OnPointerEnterEvent += ShowTooltip;
		itemContainer.OnPointerExitEvent += HideTooltip;
		itemContainer.OnBeginDragEvent += BeginDrag;
		itemContainer.OnEndDragEvent += EndDrag;
		itemContainer.OnDragEvent += Drag;
		itemContainer.OnDropEvent += Drop;
	}
	
	public void CloseItemContainer(ItemContainer itemContainer)
	{
		openItemContainer = null;

		Inventory.OnRightClickEvent += InventoryRightClick;
		Inventory.OnRightClickEvent -= TransferToItemContainer;

		itemContainer.OnRightClickEvent -= TransferToInventory;

		itemContainer.OnPointerEnterEvent -= ShowTooltip;
		itemContainer.OnPointerExitEvent -= HideTooltip;
		itemContainer.OnBeginDragEvent -= BeginDrag;
		itemContainer.OnEndDragEvent -= EndDrag;
		itemContainer.OnDragEvent -= Drag;
		itemContainer.OnDropEvent -= Drop;
	}

}
