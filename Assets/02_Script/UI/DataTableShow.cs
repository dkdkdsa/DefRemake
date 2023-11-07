using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataTableShow : MonoBehaviour
{

    [SerializeField] private TMP_Text attackText, defText, hpText, nameText;
    [SerializeField] private Image spriteSlot;

    public static DataTableShow Instance;

    private void Awake()
    {

        Instance = this;

    }

    public void SetText(ItemData item)
    {

        attackText.text = $"���ݷ� : {item.attack}";
        defText.text = $"���� : {item.defense}";
        nameText.text = $"�̸� : {item.itemName}";
        spriteSlot.sprite = item.itemSprite;
        hpText.text = $"ü�� : {item.hp}";

    }

}

