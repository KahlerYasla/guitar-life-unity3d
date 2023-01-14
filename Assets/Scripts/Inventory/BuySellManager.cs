using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BuySellManager : MonoBehaviour
{
    public GameObject[] marketSlots, playerSlots;

    private int playerMoney;
    public TMP_Text playerMoneyText;

    struct Items0
    {
        public string name;
        public int price;

        public string spriteName;
    }
    private LinkedList<Items0> allItemsList = new LinkedList<Items0>();

    private void Start()
    {
        // add all items to list
        for (int i = 0; i < marketSlots.Length; i++)
        {
            try
            {
                Items0 item = new Items0();
                item.name = marketSlots[i].name;
                item.spriteName = marketSlots[i].GetComponent<Image>().sprite.name;
                item.price = 100;
                allItemsList.AddLast(item);
            }
            catch (System.Exception)
            {
                continue;
            }

        }
    }

    public void clickOnItem(string slotIndex)
    {
        // if player is in trading mode
        if (MarketSpeech.tradingMode)
        {
            // get player money
            playerMoney = int.Parse(playerMoneyText.text);

            // if player is in market inventory
            if (slotIndex[0] == 'm')
            {
                // buy item
                buyItem(int.Parse(slotIndex[1].ToString()));
            }
            // if player is in player inventory
            else if (slotIndex[0] == 'p')
            {
                // sell item
                sellItem(int.Parse(slotIndex[1].ToString()));
            }
        }
        else
        {
            // if player is not in trading mode
            // equip item
            //equipItem(int.Parse(slotIndex[1].ToString()));
        }
    }

    public void buyItem(int marketSlotIndex)
    {
        // get indexed market slot from linked list
        LinkedListNode<Items0> marketSlot = allItemsList.First;
        for (int i = 0; i < marketSlotIndex; i++)
        {
            marketSlot = marketSlot.Next;
        }

        // if player has enough money
        if (playerMoney >= marketSlot.Value.price)
        {
            // remove money from player
            playerMoney -= marketSlot.Value.price;
            playerMoneyText.text = playerMoney.ToString();

            // add item to player inventory
            for (int i = 0; i < playerSlots.Length; i++)
            {
                if (playerSlots[i].GetComponent<Image>().sprite == null)
                {
                    // add item to player inventory
                    playerSlots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + marketSlot.Value.spriteName);
                    break;
                }
            }

            // remove item from market inventory
            marketSlots[marketSlotIndex].GetComponent<Image>().sprite = null;
        }
    }

    public void sellItem(int playerSlotIndex)
    {
        // get indexed player slot from linked list
        LinkedListNode<Items0> playerSlot = allItemsList.First;
        for (int i = 0; i < playerSlotIndex; i++)
        {
            playerSlot = playerSlot.Next;
        }

        // add money to player
        playerMoney += playerSlot.Value.price;
        playerMoneyText.text = playerMoney.ToString();

        // remove item from player inventory
        playerSlots[playerSlotIndex].GetComponent<Image>().sprite = null;

        // add item to market inventory
        for (int i = 0; i < marketSlots.Length; i++)
        {
            if (marketSlots[i].GetComponent<Image>().sprite == null)
            {
                // add item to market inventory
                marketSlots[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + playerSlot.Value.spriteName);
                break;
            }
        }
    }

    public void equipItem(int playerSlotIndex)
    {
        // get indexed player slot from linked list
        LinkedListNode<Items0> playerSlot = allItemsList.First;
        for (int i = 0; i < playerSlotIndex; i++)
        {
            playerSlot = playerSlot.Next;
        }

        // equip item
        //BuySellManager.selectBodyPart();

    }
}
