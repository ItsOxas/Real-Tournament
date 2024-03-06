using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUi : MonoBehaviour
{
    public TMP_Text healthText;
    public Health health;

    public TMP_Text ammoText;
    public Weapon ammo;

    private void Update()
    {
        healthText.text = health.health.ToString();
        ammoText.text = ammo.ammo.ToString();
    }
}
