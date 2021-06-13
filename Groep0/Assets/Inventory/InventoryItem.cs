
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public RawImage inventoryImage;
    
    public string DisplayName;

    public void PickupItem()
    {
        inventoryImage.color = Color.white;
        this.transform.gameObject.SetActive(false);
    }
}
