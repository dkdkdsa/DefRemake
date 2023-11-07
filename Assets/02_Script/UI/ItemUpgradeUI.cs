using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemUpgradeUI : MonoBehaviour
{

    [SerializeField] private ItemSlot slot;
    [SerializeField] private TMP_Text lvText, attackText, defText, hpText, costText, nameText;

    private PlayerInventory inventory;
    private PlayerData playerData;

    private void Awake()
    {

        inventory = FindObjectOfType<PlayerInventory>();
        playerData = FindObjectOfType<PlayerData>();
        slot.OnSlotClickEvent += HandleSlotClick;
        SettingText();
        slot.SettingItem(null);

    }

    private void HandleSlotClick(ItemData? item)
    {

        if(item != null)
        {

            slot.SettingItem(null);
            inventory.AddItem(item.Value);
            SettingText();

        }

    }

    private void SettingText()
    {

        var item = slot.GetItem();

        if(item != null)
        {

            nameText.text = item.Value.itemName;
            attackText.text = $"���ݷ� : {item.Value.attack}";
            defText.text = $"���� : {item.Value.defense}";
            lvText.text = $"���� : {item.Value.lv}";
            hpText.text = $"ü�� : {item.Value.hp}";
            costText.text = $"��� : {item.Value.upgradeCost}";

        }
        else
        {

            nameText.text = string.Empty;
            attackText.text = string.Empty;
            defText.text = string.Empty;
            hpText.text = string.Empty;
            costText.text = string.Empty;
            lvText.text = string.Empty;
        }

    }

    public void DoUpgrade()
    {

        var item = slot.GetItem();

        if(item != null )
        {

            var curItem = item.Value;
            if(playerData.Money >= curItem.upgradeCost)
            {

                playerData.Money -= curItem.upgradeCost;
                curItem.DoUpgrade();
                slot.SettingItem(curItem);
                SettingText();

            }


        }

    }
    
    public bool SetSlot(ItemData item)
    {

        if(slot.GetItem() == null)
        {

            slot.SettingItem(item);
            SettingText();
            return true;

        }

        return false;

    }

}