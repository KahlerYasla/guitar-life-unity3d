using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger0 : MonoBehaviour
{
    public GameObject[] playerSlots;

    [SerializeField] private SO_Inventory inventoryObj;

    public void Start()
    {
        for (int i = 0; i < playerSlots.Length; i++)
        {
            try
            {
                playerSlots[i].GetComponent<Image>().sprite = inventoryObj.spritesOfSlots[i];
            }
            catch (System.Exception)
            {
                return;
            }

        }

    }
    // Controls All Scene Changes
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Door"))
        {
            switch (other.gameObject.name)
            {
                case "BarDoor":
                    SceneManager.LoadScene(1);
                    break;
                case "MarketDoor":
                    SceneManager.LoadScene(2);
                    break;
                case "HouseDoor":
                    SceneManager.LoadScene(3);
                    break;
                case "DoorIn":
                    SceneManager.LoadScene(0);
                    break;
            }
            CarManager.carPool.Clear();
        }

        // write playerSlots to invetoryObj
        for (int i = 0; i < playerSlots.Length; i++)
        {
            try
            {
                inventoryObj.spritesOfSlots[i] = playerSlots[i].GetComponent<Image>().sprite;
            }
            catch (System.Exception)
            {
                return;
            }

        }
    }

}