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
        else
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
        InventoryItem item = other.GetComponent<InventoryItem>();
        Debug.Log("Encountered something...");
        
        if (item != null)
        {
            nearbyItem = item;

            Debug.Log("Encountered " + item.DisplayName);
            
            inventoryHud.OpenPickupMessage($"Press 'f' to pick up {item.DisplayName}.");
        }
    }

    public void OnTriggerExit(Collider other)
    {

        InventoryItem item = other.GetComponent<InventoryItem>();
        
        if (item != null)
        {
            nearbyItem = null;

            Debug.Log("Leaving " + item.DisplayName);
            
            inventoryHud.ClosePickupMessage();
        }
    }
}
