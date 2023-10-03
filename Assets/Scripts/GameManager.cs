using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spawnPoints;
    public GameObject alien;
    public int maxAliensOnScreen;
    public int totalAliens;
    public float minSpawnTime;
    public float maxSpawnTime;
    public int aliensPerSpawn;

    private int aliensOnScreen = 0;
    private float generatedSpawnTime = 0;
    private float currentSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //adds the amount of time between the last frame and this one to the currentSpawnTime
        currentSpawnTime += Time.deltaTime;

        //condition to generate new aliens
        if (currentSpawnTime > generatedSpawnTime)
        {
            //reset he timer after spawn
            currentSpawnTime = 0;

            //spawn timer randomizer
            generatedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            //endures numbber of aliens is within limits
            if (aliensPerSpawn > 0 && aliensOnScreen < totalAliens)
            {
                //creates a list to keep track where aliens have spawned alredy 
                List<int> previousSpawnLocations = new List<int>();

                //limits number of aliens to number of spans
                if (aliensPerSpawn > spawnPoints.Length)
                {
                    aliensPerSpawn = spawnPoints.Length - 1;
                }

                //limits how many aliens can be created based on the maximun number of aliens
                aliensPerSpawn = (aliensPerSpawn > totalAliens) ? aliensPerSpawn - totalAliens : aliensPerSpawn;

                //loop for every spawened alien
                for (int i = 0; i < aliensPerSpawn; i++)
                {
                    if (aliensOnScreen < maxAliensOnScreen)
                    {
                        // add to the number of aliens in the screen
                        aliensOnScreen += 1;

                        // 1 creates the value as -1 so it is not valid index
                        int spawnPoint = -1;
                        // 2 while spawn point does not have a valid index
                        while (spawnPoint == -1)
                        {
                            // 3 create a random number for the spawn location
                            int randomNumber = Random.Range(0, spawnPoints.Length - 1);
                            // 4 checks if the spawn point was used or not
                            if (!previousSpawnLocations.Contains(randomNumber))
                            {
                                //add random index to the list
                                previousSpawnLocations.Add(randomNumber);
                                //change in value will break the while loop
                                spawnPoint = randomNumber;
                            }
                        }

                        //label in the arena o spawn the next alien
                        GameObject spawnLocation = spawnPoints[spawnPoint];

                        //creates a new instance of the alien
                        GameObject newAlien = Instantiate(alien) as GameObject;

                        //set the alien position to be the same as the label where it was created
                        newAlien.transform.position = spawnLocation.transform.position;

                        //get the script from alien
                        Alien alienScript = newAlien.GetComponent<Alien>();
                        //set the target in the script to be the player position
                        alienScript.target = player.transform;

                        //rotates the alien to face the player
                        Vector3 targetRotation = new Vector3(player.transform.position.x, newAlien.transform.position.y, player.transform.position.z);
                        newAlien.transform.LookAt(targetRotation);
                    }
                }
            }
        }
    }
}
