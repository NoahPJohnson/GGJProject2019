using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUDScript : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider ammoSlider;
    [SerializeField] GameObject upgradeSlot1;
    [SerializeField] GameObject upgradeSlot2;
    [SerializeField] GameObject upgradeSlot3;
    GameObject[] upgradeSlots = new GameObject[3];
    [SerializeField] Transform playerReference;
    int upgradeStack = 0;

    // Use this for initialization
    void Start ()
    {
        playerReference = GameObject.FindGameObjectWithTag("Player").transform;
        upgradeSlots[0] = upgradeSlot1;
        upgradeSlots[1] = upgradeSlot2;
        upgradeSlots[2] = upgradeSlot3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        healthSlider.value = playerReference.GetComponent<PlayerDamageScript>().GetCurrentHP();
        ammoSlider.maxValue = playerReference.GetComponent<PlayerMovement>().GetWeapon().GetComponent<WeaponScript>().GetWeaponInterface().GetMaxAmmo();
        ammoSlider.value = playerReference.GetComponent<PlayerMovement>().GetWeapon().GetComponent<WeaponScript>().GetWeaponInterface().GetAmmo();
    }

    public void StackUpgrades(int index)
    {
        upgradeSlots[upgradeStack].transform.GetChild(0).gameObject.SetActive(false);
        upgradeSlots[upgradeStack].transform.GetChild(index+1).gameObject.SetActive(true);
        upgradeStack++;
    }

    public void ClearUpgrades()
    {
        upgradeStack = 0;
        for (int i = 0; i < 3; i++)
        {
            upgradeSlots[i].transform.GetChild(0).gameObject.SetActive(true);
            for (int j = 1; j < 4; j++)
            {
                upgradeSlots[i].transform.GetChild(j).gameObject.SetActive(false);
            }
        }
    }
}
