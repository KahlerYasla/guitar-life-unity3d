using UnityEngine;
using System.Collections;

public class DiscoMaker : MonoBehaviour
{
    SpriteRenderer render0;

    void Start()
    {
        render0 = GetComponent<SpriteRenderer>();

        // wait for 0.1 seconds
        InvokeRepeating("ColorChanger", 0.1f, 0.5f);
    }

    void ColorChanger()
    {
        // generate a random value between 0 and 1
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        // set the color of the sprite renderer
        render0.color = new Color(r, g, b);
    }
}