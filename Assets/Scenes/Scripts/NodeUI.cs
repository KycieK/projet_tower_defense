using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;
    private Node target; 

    public TextMeshProUGUI upgradeCost;

    public void SetTarget(Node target)
    {
        this.target = target;

        transform.position = target.GetBuildPosition();

        upgradeCost.text = "<b>UPGRADE</b>\n$" + target.turretBlueprint.upgradeCost;

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
