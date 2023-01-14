using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger0 : MonoBehaviour
{
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

    }

}