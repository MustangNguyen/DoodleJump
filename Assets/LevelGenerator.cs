using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //public int numberOfPlatforms=2000;
    public GameObject platformBoost;
    public GameObject platformNormal;
    public GameObject platformUnstable;
    public GameObject platformTinyBoost;
    public GameObject platformRocket;
    public GameObject platformMonster1;
    public float levelWidth = 7f;
    public float minY = 1.2f;
    public float maxY = 3.5f;
    public float LevelAjust = 0.003f;
    public Transform cam;
    float h = 0.01f;

    Vector3 spawnPosition = new Vector3(0, -6, 0);



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        while (spawnPosition.y < (cam.position.y + 20f))
        {
            spawnPosition.y += Random.Range(minY, maxY);
            gameObject.transform.position = spawnPosition;
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            //Create platform randomly
            if (cam.position.y < 300f)
            {
                float r = Random.value;
                if (r <= 0.03f)
                {
                    Instantiate(platformBoost, spawnPosition, Quaternion.identity);
                }
                else if (0.03 < r && r <= 0.15)
                {
                    Instantiate(platformUnstable, spawnPosition, Quaternion.identity);
                }
                else if (0.15 < r && r <= 0.25)
                {
                    Instantiate(platformTinyBoost, spawnPosition, Quaternion.identity);
                }
                else if (0.25 < r && r <= 0.26)
                {
                    Instantiate(platformRocket, spawnPosition, Quaternion.identity);
                }
                else if (0.26 < r && r <= 0.28)
                {
                    Instantiate(platformMonster1, spawnPosition, Quaternion.identity);
                }
                else
                {
                    Instantiate(platformNormal, spawnPosition, Quaternion.identity);
                }
            }
            //Reach a particular high
            else if (cam.position.y >= 300)
            {
                float notmove = Random.value;
                if (notmove >= h)
                {
                    float r = Random.value;
                    if (r <= 0.03f)
                    {
                        Instantiate(platformBoost, spawnPosition, Quaternion.identity);
                        h += LevelAjust;
                    }
                    else if (0.03 < r && r <= 0.15)
                    {
                        Instantiate(platformUnstable, spawnPosition, Quaternion.identity);
                        h += LevelAjust;
                    }
                    else if (0.15 < r && r <= 0.25)
                    {
                        Instantiate(platformTinyBoost, spawnPosition, Quaternion.identity);
                        h += LevelAjust;
                    }
                    else if (0.25 < r && r <= 0.26)
                    {
                        Instantiate(platformRocket, spawnPosition, Quaternion.identity);
                    }
                    else if (0.25 < r && r <= 0.26)
                    {
                        Instantiate(platformRocket, spawnPosition, Quaternion.identity);
                    }
                    else if (0.27 < r && r <= 0.30)
                    {
                        Instantiate(platformMonster1, spawnPosition, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(platformNormal, spawnPosition, Quaternion.identity);
                        h += LevelAjust;
                    }
                }
                else
                {
                    float r = Random.value;
                    if (r <= 0.03f)
                    {
                        platformBoost.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformBoost, spawnPosition, Quaternion.identity);
                        platformBoost.GetComponent<Platform_Propertile>().move = false;
                        h += LevelAjust;
                    }
                    else if (0.03 < r && r <= 0.15)
                    {
                        platformUnstable.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformUnstable, spawnPosition, Quaternion.identity);
                        platformUnstable.GetComponent<Platform_Propertile>().move = false;
                        h += LevelAjust;

                    }
                    else if (0.15 < r && r <= 0.25)
                    {
                        platformTinyBoost.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformTinyBoost, spawnPosition, Quaternion.identity);
                        platformTinyBoost.GetComponent<Platform_Propertile>().move = false;
                        h += LevelAjust;
                    }
                    else if (0.27 < r && r <= 0.30)
                    {
                        platformMonster1.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformMonster1, spawnPosition, Quaternion.identity);
                        platformMonster1.GetComponent<Platform_Propertile>().move = false;
                    }
                    else
                    {
                        platformNormal.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformNormal, spawnPosition, Quaternion.identity);
                        platformNormal.GetComponent<Platform_Propertile>().move = false;
                        h += LevelAjust;
                    }
                }              
            }
            //Debug.Log(h);
            //Make game become harder when going higher
            //Debug.Log(cam.position.y);
            //Debug.Log(spawnPosition.y);
            if (maxY < 3)
            {
                maxY += 0.005f;
            }
            if (minY < maxY)
            {
                minY += 0.005f;
            }

        }
    }
}