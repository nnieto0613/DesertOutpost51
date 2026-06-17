using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;
    public float pickupRange = 3f;
    public GameObject pickupPrompt;

    private PickupItem heldItem;

    void Update()
    {
        UpdatePickupPrompt();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem == null)
            {
                TryPickUpItem();
            }
            else
            {
                DropItem();
            }
        }
    }

    void UpdatePickupPrompt()
    {
        if (pickupPrompt == null)
        {
            return;
        }

        bool nearItem = false;

        PickupItem[] items = FindObjectsOfType<PickupItem>();

        foreach (PickupItem item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            if (distance <= pickupRange)
            {
                nearItem = true;
                break;
            }
        }

        pickupPrompt.SetActive(nearItem && heldItem == null);
    }

    void TryPickUpItem()
    {
        PickupItem[] items = FindObjectsOfType<PickupItem>();

        foreach (PickupItem item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);

            if (distance <= pickupRange)
            {
                PickUpItem(item);
                return;
            }
        }

        Debug.Log("No item close enough to pick up.");
    }

    void PickUpItem(PickupItem item)
    {
        heldItem = item;

        heldItem.transform.SetParent(holdPoint);
        heldItem.transform.localPosition = Vector3.zero;
        heldItem.transform.localRotation = Quaternion.identity;

        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Collider col = heldItem.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        Debug.Log("Picked up " + heldItem.itemName);
    }

    public void DropItem()
    {
        heldItem.transform.SetParent(null);
        heldItem.transform.position = transform.position + transform.forward * 2f + Vector3.up;

        Rigidbody rb = heldItem.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Collider col = heldItem.GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = true;
        }

        heldItem = null;

        Debug.Log("Dropped item");
    }

    public bool HasHeldItem(string itemName)
    {
        return heldItem != null && heldItem.itemName == itemName;
    }

    public void RemoveHeldItem()
    {
        if (heldItem != null)
        {
            Destroy(heldItem.gameObject);
            heldItem = null;
        }
    }
}