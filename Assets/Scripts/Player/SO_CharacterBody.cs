using UnityEngine;

[CreateAssetMenu(fileName = "New Character Body", menuName = "Character Body")]
public class SO_CharacterBody : ScriptableObject
{
    // Character Body Parts
    public BodyPart[] characterBodyParts;
}

[System.Serializable]
public class BodyPart
{
    public string bodyPartName;
    public SO_BodyPart bodyPart;
}
