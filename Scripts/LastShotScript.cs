using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LastShotScript : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
    }
    void Update()
    {
        if (Weapon.bulletAmount == 2)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        }
        if (Weapon.bulletAmount != 2)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
}
