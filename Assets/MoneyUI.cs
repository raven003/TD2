﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    public Text MoneyText;

	
	// Update is called once per frame
	void Update () {
        MoneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
