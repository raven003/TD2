using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {
    [Header("Attributes")]
    public Color hovercolor;
    public Color notEnoughMoneyColor;
    public Vector3 offset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    public Vector3 GetBuildPosition()
        {
        return transform.position + offset;
        }
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
	}
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
             return;
        

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't build there! ToDo : Display");
            return;
        }


        buildManager.BuildTurretOn(this);

        //build a turret
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
            rend.material.color = hovercolor;
        else
            rend.material.color = notEnoughMoneyColor;

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
 


}
