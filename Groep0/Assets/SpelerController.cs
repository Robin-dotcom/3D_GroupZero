using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

 

public class SpelerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool ground;

 

    public InventoryHud inventoryHud;

 

    public InventoryItem nearbyItem;
    public DoorController nearbyDoor;

 

    public Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

 

    private void Update()
    {
        if (nearbyItem != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Picking up " + nearbyItem.DisplayName);
            
            inventoryHud.ClosePickupMessage();

 

            inventory.AddItem(nearbyItem);
            
            nearbyItem.PickupItem();

            nearbyItem = null;
        }

        if (nearbyDoor != null && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Opening door.");
            
            inventoryHud.ClosePickupMessage();
            
            nearbyDoor.BreakdownDoor();

            nearbyDoor = null;
        }
    }

 

    private void FixedUpdate()
    {
        Grounded();
        Jump();
        Move();
    }

 

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.ground)
        {
            this.rb.AddForce(Vector3.up * 4, ForceMode.Impulse);
        }
    }

 

    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, 0.05f, layerMask))
        {
            this.ground = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.ground = false;
        }

 

        this.anim.SetBool("jump", !this.ground);
    }
    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

 

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;

 

        movement.Normalize();

 

        this.transform.position += movement * 0.04f;

 

        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }

 

    public void OnTriggerEnter(Collider other)
    {
        InventoryItem inventoryItem = other.GetComponent<InventoryItem>();
        DoorController doorController = other.GetComponent<DoorController>();

        Debug.Log("Encountered something...");
        
        if (inventoryItem != null)
        {
            nearbyItem = inventoryItem;
            
            Debug.Log("Encountered " + inventoryItem.DisplayName);
            
            inventoryHud.OpenPickupMessage($"Press 'f' to pick up {inventoryItem.DisplayName}.");
        }
        
        else if (doorController != null)
        {
            if (inventory.HasItem("Crowbar"))
            {
                nearbyDoor = doorController;
                
                inventoryHud.OpenPickupMessage($"Press 'f' to break down door with crowbar.");
            }
            else
            {
                inventoryHud.OpenPickupMessage($"I should find something to break this door down...");
            }
        }
    }

 

    public void OnTriggerExit(Collider other)
    {

 

        InventoryItem item = other.GetComponent<InventoryItem>();
        DoorController doorController = other.GetComponent<DoorController>();

        if (item != null)
        {
            nearbyItem = null;

 

            Debug.Log("Leaving " + item.DisplayName);
            
            inventoryHud.ClosePickupMessage();
        }

        if (doorController != null)
        {
            nearbyDoor = null;
            
            inventoryHud.ClosePickupMessage();
        }
    }
}
 