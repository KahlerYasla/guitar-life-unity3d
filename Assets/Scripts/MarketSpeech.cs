using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketSpeech : MonoBehaviour
{
    public GameObject[] marketInventory, buttonsAndSpeechBubble;

    public static bool tradingMode = false;

    public void update()
    {
        // if player moves set false
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            foreach (GameObject i in marketInventory)
            {
                i.SetActive(false);
            }
        }
    }

    // if colliding with seller then display speech bubble if leave then hide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            setStateOfButtonsAndSpeechBubble(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            setStateOfButtonsAndSpeechBubble(false);
        }
    }

    public void setStateOfButtonsAndSpeechBubble(bool state)
    {
        foreach (GameObject i in buttonsAndSpeechBubble)
        {
            i.SetActive(state);
        }
    }

    public void setStateOfMarketInventory(bool state)
    {
        foreach (GameObject i in marketInventory)
        {
            tradingMode = state;
            i.SetActive(state);
        }
    }

    public void closeOnlyMarketPlane()
    {   
        tradingMode = false;
        marketInventory[1].SetActive(false);
    }
}
