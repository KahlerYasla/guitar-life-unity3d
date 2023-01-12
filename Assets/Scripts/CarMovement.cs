using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    bool isDown = true;
    void Start()
    {
        if(gameObject.name[3] == 'U')
        {
            isDown = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * 2);
        }

        if (transform.position.x < -30 || transform.position.x > 30)
        {
            CarManager.carPool.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
