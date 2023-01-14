using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CarManager : MonoBehaviour
{
    public GameObject[] cars; // array to store the car prefabs
    // 0 to 3 down road cars; 4 to 7 up road cars;
    public GameObject player; // reference to the player object

    public static LinkedList<GameObject> carPool = new LinkedList<GameObject>();// linked list to store the instantiated cars

    void Start()
    {
        // start spawning cars
        StartCoroutine(SpawnCar());
    }

    void Update()
    {
        // sort the layer of cars based on player's y position
        sortingLayerManager(carPool, player);
    }
    IEnumerator SpawnCar()
    {
        while (true) // infinite loop
        {
            // wait for a random amount of time between 2 and 10 seconds
            float spawnTime = Random.Range(3, 8);
            yield return new WaitForSeconds(spawnTime);

            // choose a random car from the array
            int carIndex = Random.Range(0, cars.Length);
            GameObject chosenCar = cars[carIndex];

            // chanege color of the car randomly
            chosenCar.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);

            if (carIndex < 4)
            {
                // down road cars
                // set the position of the car
                transform.position = new Vector3(-30, -3.5f, 0);
            }
            else
            {
                // up road cars
                // set the position of the car
                transform.position = new Vector3(30, -1.5f, 0);
            }
            // instantiate the chosen car
            GameObject car = Instantiate(chosenCar, transform.position, chosenCar.transform.rotation);

            // add the instantiated car to the car pool
            carPool.AddLast(car);
        }
    }

    /*
        void sortingLayerManager(LinkedList<GameObject> cars, GameObject player)
        {
            // loop through all cars
            for (int i = 0; i < cars.Count; i++)
            {
                // check if player is between the up and down road cars
                if (player.transform.position.y < -1.5f && player.transform.position.y > -3.5f)
                {
                    // set the down road cars' sorting order bigger than player
                    if (i < 4)
                    {
                        cars[i].GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
                    }
                    // set the up road cars' sorting order smaller than player
                    else
                    {
                        cars[i].GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
                    }
                }
                // check if player is above all cars
                else if (player.transform.position.y > -1.5f)
                {
                    // set the all cars' sorting order
                    cars[i].GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 1;
                }
                // check if player is below all cars
                else if (player.transform.position.y < -3.5f)
                {
                    // set the all cars' sorting order
                    cars[i].GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 1;
                }
            }
        }
    */

    void sortingLayerManager(LinkedList<GameObject> cars, GameObject player)
    {
        // loop through all cars
        LinkedListNode<GameObject> node = cars.First;
        while (node != null)
        {
            GameObject car = node.Value;

            // check if player is between the up and down road cars
            if (player.transform.position.y < -1.5f && player.transform.position.y > -3.5f)
            {
                // set the down road cars' sorting order bigger than player
                if (car.name[3] == 'D')
                {
                    car.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 3;
                }
                // set the up road cars' sorting order smaller than player
                else
                {
                    car.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 3;
                }
            }
            // check if player is above all cars
            else if (player.transform.position.y > -1.5f)
            {
                // set the all cars' sorting order
                car.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder + 3;
            }
            // check if player is below all cars
            else if (player.transform.position.y < -3.5f)
            {
                // set the all cars' sorting order
                car.GetComponent<SpriteRenderer>().sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder - 3;
            }
            node = node.Next;
        }

    }
}
