using UnityEngine;
using UnityEngine.UI;

public class InventoryHud : MonoBehaviour
{
    // Start is called before the first frame update

    public Text PickupMessage;
    
    void Start()
    {
        this.PickupMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPickupMessage(string msg)
    {
        Debug.Log("Enabling message.");
        this.PickupMessage.text = msg;
        this.PickupMessage.gameObject.SetActive(true);
    }

    public void ClosePickupMessage()
    {
        Debug.Log("Disabling message.");
        this.PickupMessage.gameObject.SetActive(false);
    }
}
