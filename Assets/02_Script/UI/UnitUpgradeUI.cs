using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnitUpgradeUI : MonoBehaviour
{

    [SerializeField] private TMP_Text lvText, attackText, defText, hpText, contText;

    private UnitDataController dataController;

    public void SetController(UnitDataController controller)
    {

        dataController = controller;
        dataController.OnValueChanged += HandleValueChanged;
        HandleValueChanged();

    }

    private void HandleValueChanged()
    {

        lvText.text = $"���� : {dataController.lv}";
        attackText.text = $"���ݷ� : {dataController.attackPower + dataController.extraAttack}";
        defText.text = $"���� : {dataController.defenceValue + dataController.extraDef}";
        hpText.text = $"ü�� : {dataController.maxHP + dataController.extraHP}";
        contText.text = $"��� {dataController.lvUpCost}";

    }

    public void DoUpgrade()
    {



    }

}
