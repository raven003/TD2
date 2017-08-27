using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standartTurret;
    public TurretBlueprint missleLauncher;

    BuildManager buildmanager;
    void Start()
    {
        buildmanager = BuildManager.instance;
    }

    public void SelectStandartTurret ()
    {
        Debug.Log("standart Turret Selected");
        buildmanager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissleLauncher ()
    {
        Debug.Log("another");
        buildmanager.SelectTurretToBuild(missleLauncher);
    }
}
