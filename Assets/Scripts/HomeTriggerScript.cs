using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTriggerScript : MonoBehaviour
{
    [SerializeField] bool destination = false;
    [SerializeField] Transform otherHome;
    [SerializeField] Transform upgradeManager;
    [SerializeField] GameObject musicManager;

    public bool GetDestination()
    {
        return destination;
    }

    public void SetDestination(bool newValue)
    {
        destination = newValue;
    }

    public void SwapDestinations()
    {
        destination = false;
        otherHome.GetComponent<HomeTriggerScript>().SetDestination(true);
        for (int i = 0; i < upgradeManager.childCount; i++)
        {
            upgradeManager.GetChild(i).gameObject.SetActive(true);
        }
        musicManager.GetComponent<MusicManager>().SwapHomes();
        //Debug.Log("Destination Reached, swap");
    }
}
