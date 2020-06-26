using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour
{

    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 2.5f;

    private float minX, maxX;

    private float lastCloudPositionY;

    private int controllX;

    [SerializeField]
    private GameObject[] collectables;

    private GameObject player;

    void Awake()
    {
        controllX = 0;
        SetMinAndMaxX();
        CreateClouds();
        player = GameObject.Find("Player");

        for (int i = 0; i < collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }

    }

    void Start()
    {
        PositionThePlayer();
    }

    void CreateClouds()
    {
        Shuffle(clouds);

        float positionY = 0;

        for (int i = 0; i < clouds.Length; i++)
        {

            Vector3 temp = clouds[i].transform.position;

            temp.y = positionY;

            if (controllX == 0)
            {

                temp.x = Random.Range(0, maxX);
                controllX = 1;

            }
            else if (controllX == 1)
            {

                temp.x = Random.Range(0, minX);
                controllX = 2;

            }
            else if (controllX == 2)
            {

                temp.x = Random.Range(1.0f, maxX);
                controllX = 3;

            }
            else if (controllX == 3)
            {

                temp.x = Random.Range(-1.0f, minX);
                controllX = 0;
            }

            lastCloudPositionY = positionY;

            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;

        }

    }

    void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject temp = array[i];
            int random = Random.Range(i, array.Length);
            array[i] = array[random];
            array[random] = temp;
        }
    }

    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = -bounds.x + 2f;
        maxX = bounds.x - 1f;
    }

    void PositionThePlayer()
    {

        // getting back clouds
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("Deadly");

        // getting clouds in game
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < darkClouds.Length; i++)
        {

            if (darkClouds[i].transform.position.y == 0)
            {

                Vector3 t = darkClouds[i].transform.position;

                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x,
                                                               cloudsInGame[0].transform.position.y,
                                                               cloudsInGame[0].transform.position.z);

                cloudsInGame[0].transform.position = t;

            }

        }

        Vector3 temp = cloudsInGame[0].transform.position;

        for (int i = 1; i < cloudsInGame.Length; i++)
        {

            if (temp.y < cloudsInGame[i].transform.position.y)
                temp = cloudsInGame[i].transform.position;

        }


        // positioning the player above the cloud
        player.transform.position = new Vector3(temp.x, temp.y + 0.8f, temp.z);


    }

    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Deadly" || target.tag == "Cloud")
        {

            if (target.transform.position.y == lastCloudPositionY)
            {

                Vector3 temp = target.transform.position;
                Shuffle(clouds);
                Shuffle(collectables);

                for (int i = 0; i < clouds.Length; i++)
                {

                    if (!clouds[i].activeInHierarchy)
                    {

                        if (controllX == 0)
                        {

                            temp.x = Random.Range(0, maxX);
                            controllX = 1;

                        }
                        else if (controllX == 1)
                        {

                            temp.x = Random.Range(0, minX);
                            controllX = 2;

                        }
                        else if (controllX == 2)
                        {

                            temp.x = Random.Range(1.0f, maxX);
                            controllX = 3;

                        }
                        else if (controllX == 3)
                        {

                            temp.x = Random.Range(-1.0f, minX);
                            controllX = 0;
                        }

                        temp.y -= distanceBetweenClouds;

                        lastCloudPositionY = temp.y;


                        clouds[i].transform.position = temp;
                        clouds[i].SetActive(true);

                        int random = Random.Range(0, collectables.Length);

                        if (clouds[i].tag != "Deadly")
                        {

                            if (!collectables[random].activeInHierarchy)
                            {

                                if (collectables[random].tag == "Life")
                                {

                                    if (PlayerScore.lifeCount < 2)
                                    {
                                        collectables[random].SetActive(true);
                                        collectables[random].transform.position = new Vector3(clouds[i].transform.position.x,
                                                                                              clouds[i].transform.position.y + 0.6f,
                                                                                              clouds[i].transform.position.z);
                                    }

                                } // if tag == life
                                else
                                {

                                    collectables[random].SetActive(true);
                                    collectables[random].transform.position = new Vector3(clouds[i].transform.position.x,
                                                                                          clouds[i].transform.position.y + 0.5f,
                                                                                          clouds[i].transform.position.z);
                                } // else

                            } // if collectable is not active

                        } // if clouds.tag != Deadly

                    } // if clouds is not activate

                } // loop through clouds

            } // if target transform position == lastCloudPosition

        } // if target tag == deadly or cloud	

    } // On Trigger enter 2D

} // CloudSpawner

