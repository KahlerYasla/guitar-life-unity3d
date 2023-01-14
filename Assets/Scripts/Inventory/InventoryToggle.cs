using UnityEngine;

public class InventoryToggle : MonoBehaviour
{
    void Update()
    {
        // if player moves, close inventory
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            gameObject.SetActive(false);
        }
    }

    // if Inventory Button on UI pressed with cursor, open inventory
    public void OpenInventory()
    {
        // if inventory is already open, close it
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            return;
        }

        gameObject.SetActive(true);

    }
}
