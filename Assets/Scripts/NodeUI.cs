using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target; 
    public BuildManager buildManager;

    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI sellCostText;

    public void SetTarget(Node target)
    {
        this.target = target;
        int turretLevel = target.GetTurretLevel();

        //Cas de la derniere upgrade disponible dans la liste
        if(ExcedsSizeOfList(target.turretBlueprint.upgradePrefabs, turretLevel))
        {
            transform.position = target.GetBuildPosition();
            upgradeCostText.text = "<b>MAX</b>";
            sellCostText.text = "<b>SELL</b>\n$" + target.GetSellCost();
            ui.SetActive(!ui.activeSelf);
            return;
        }


        //Cas d'un upgrade non finale de la liste
        int upgradeCost = target.turretBlueprint.upgradePrefabs[turretLevel].upgradeCost;
        int sellCost = target.GetSellCost();

        transform.position = target.GetBuildPosition();
        upgradeCostText.text = "<b>UPGRADE</b>\n$" + upgradeCost;
        sellCostText.text = "<b>SELL</b>\n$" + sellCost;

        ui.SetActive(!ui.activeSelf);
    }

    public void Hide()
    {
        if(ui.activeSelf) ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        Hide();
    }

    public void Sell()
    {
        target.SellTurret();
        ui.SetActive(false);
        Hide();
    }

    public bool ExcedsSizeOfList(List<UpgradeList> list, int indexTest)
    {
        if(list.Count <= indexTest) return true;
        else return false;
    }

    

}
