using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHud : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject PickupMessage;
    
    void Start()
    {
        this.PickupMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPickupMessage(string msg)
    {
        Debug.Log("Enabling message.");
        this.PickupMessage.SetActive(true);
    }

    public void ClosePickupMessage()
    {
        Debug.Log("Disabling message.");
        this.PickupMessage.SetActive(false);
    }
}
