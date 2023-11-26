using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target; 

    public TextMeshProUGUI upgradeCostText;

    public void SetTarget(Node target)
    {
        this.target = target;
        int turretLevel = target.turretBlueprint.GetTurretLevel();
        int upgradeCost = target.turretBlueprint.upgradePrefabs[turretLevel].upgradeCost;

        transform.position = target.GetBuildPosition();
        upgradeCostText.text = "<b>UPGRADE</b>\n$" + upgradeCost;

        ui.SetActive(!ui.activeSelf);
    }

    public void Hide()
    {
        if(ui.activeSelf) ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        ui.SetActive(false);
        //BuildManager.instance.SetSelectedNode(null);
    }

}
