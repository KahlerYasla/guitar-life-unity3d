using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyPartsSelector : MonoBehaviour
{

    // Full Character Body
    [SerializeField] private SO_CharacterBody characterBody;
    // Body Part Selections
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    private void Start()
    {
        // Get All Current Body Parts
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            GetCurrentBodyParts(i);
        }
    }

    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex < bodyPartSelections[partIndex].bodyPartOptions.Length - 1)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = bodyPartSelections[partIndex].bodyPartOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    // This is the method that will be called from the inventory system
    public void selectBodyPart(Image image)
    {
        if (MarketSpeech.tradingMode)
        {
            return;
        }

        Sprite sprite0 = image.sprite;

        // Get the index of the body part from string
        // example of sprite0.name = 3frame_character_hair_11
        // if hair -> index = 1; if body -> index = 0; if legs -> index = 3; if torso -> index = 2

        string[] parts = sprite0.name.Split('_');
        int partIndex = 0;

        print(parts[2]);
        if (parts.Length < 4)
        {
            return;
        }

        switch (parts[2])
        {
            case "hair":
                partIndex = 1;
                print("hair");
                break;
            case "body":
                partIndex = 0;
                print("body");
                break;
            case "legs":
                partIndex = 3;
                print("legs");
                break;
            case "torso":
                partIndex = 2;
                print("torso");
                break;
            default:
                return;
        }

        // dictionary for bodyPartCurrentIndex for checking parts[3] value
        // 10 -> 1
        // 22 -> 0

        Dictionary<string, int> dict = new Dictionary<string, int>();

        dict.Add("10", 0); dict.Add("22", 1);
        dict.Add("11", 0); dict.Add("12", 1);
        dict.Add("13", 1); dict.Add("1", 0);

        if (ValidateIndexValue(partIndex))
        {
            bodyPartSelections[partIndex].bodyPartCurrentIndex = dict[parts[3]];

            UpdateCurrentPart(partIndex);

            CarManager.carPool.Clear();
            // restart the secene
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
        }
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        // Get Current Body Part Name
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartName;
        // Get Current Body Part Animation ID
        bodyPartSelections[partIndex].bodyPartCurrentIndex = characterBody.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID;
    }

    private void UpdateCurrentPart(int partIndex)
    {
        // Update Selection Name Text
        bodyPartSelections[partIndex].bodyPartNameTextComponent.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].bodyPartName;
        // Update Character Body Part
        characterBody.characterBodyParts[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public SO_BodyPart[] bodyPartOptions;
    public Text bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}
