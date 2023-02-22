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
    public float levelWidth = 7f;
    public float minY = 1.2f;
    public float maxY = 3.5f;
    public float LevelAjust = 0.003f;
    public Transform cam;
    float h = 0.01f;

    Vector3 spawnPosition = new Vector3(0, -6, 0);

    // Start is called before the first frame update
    //void Start()
    //{
    //    Vector3 spawnPosition = new Vector3();
    //    for (int i = 0; i < numberOfPlatforms; i++)
    //    {
    //        spawnPosition.y += Random.Range(minY, maxY);
    //        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
    //        //Create platform randomly
    //        int r = Random.Range(1, 100);
    //        if (r == 1 || r == 2 || r == 3 || r == 4 || r == 5 || r == 6 || r == 7 || r == 8 || r == 9 || r == 10)
    //        {
    //            Instantiate(platformBoost, spawnPosition, Quaternion.identity);
    //        }
    //        else if (r == 11 || r == 12 || r == 13 || r == 14 || r == 15)
    //        {
    //            Instantiate(platformUnstable, spawnPosition, Quaternion.identity);
    //        }
    //        else
    //        {
    //            Instantiate(platformNormal, spawnPosition, Quaternion.identity);
    //        }
    //        //Make game become harder when going higher
    //        if (maxY < 3)
    //        {
    //            maxY += 0.005f;
    //        }
    //        if (minY < maxY)
    //        {
    //            minY += 0.005f;
    //        }
    //    }

    //}


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
                    else if (0.25 < r && r <= 0.26)
                    {
                        platformRocket.GetComponent<Platform_Propertile>().move = true;
                        Instantiate(platformRocket, spawnPosition, Quaternion.identity);
                        platformRocket.GetComponent<Platform_Propertile>().move = false;
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