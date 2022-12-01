using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject villain;
    public int velocity;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI lifeText;
    public string playerName;
    public List<GameObject> spawnPoints;

    int lifePlayer = 10;
    int enemySpawnControl = 0;

    bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = true;
        playerText.text = playerName;
        UpdateLifeText();

        ChangeColor();

        InvokeRepeating("SpawnEnemies", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        DamagePlayer();
        //SpawnEnemies();
    }

    void UpdateLifeText()
    {
        lifeText.text = player.GetComponent<PlayerController>().life.ToString();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(new Vector3(1, 0, 0) * velocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(new Vector3(-1, 0, 0) * velocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(new Vector3(0, 1, 0) * velocity * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(new Vector3(0, -1, 0) * velocity * Time.deltaTime);
        }

        if(player.transform.position.x >= 46f || player.transform.position.x <= -46f)
        {
            player.transform.position = new Vector3(-player.transform.position.x, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.y >= 22f || player.transform.position.y <= -22f)
        {
            player.transform.position = new Vector3(player.transform.position.x, -player.transform.position.y, player.transform.position.z);
        }
    }

    void ChangeColor()
    {
        player.GetComponent<MeshRenderer>().material.color = Color.blue;
    }


    void DamagePlayer()
    {
        float distance = Vector3.Distance(player.transform.position, villain.transform.position);
        //Debug.Log($"Distância entre player e vilão: {distance}");
        if(distance < 1 && player.GetComponent<PlayerController>().life > 0)
        {
            //Debug.Log("Tomou dano");
            lifePlayer--;
            player.GetComponent<PlayerController>().GetHit();
            UpdateLifeText();
        }
    }

    void SpawnEnemies()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
            GameObject go = Instantiate(villain, spawnPoint.transform.position, Quaternion.identity);
            go.GetComponent<EnemyBehaviour>().player = player;
        }
        /*
        if (spawn)
        {
            foreach (GameObject spawnPoint in spawnPoints)
            {
                Instantiate(villain, spawnPoint.transform.position, Quaternion.identity);
                enemySpawnControl++;
            }
            if (enemySpawnControl >= 10) spawn = false;
        }
        */
    }
}
