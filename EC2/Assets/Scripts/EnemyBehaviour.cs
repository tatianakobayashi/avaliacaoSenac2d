using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int velocity;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ChangeColor();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void ChangeColor()
    {
        // Mudando a cor
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    void FollowPlayer()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, player.transform.position, velocity * Time.deltaTime); ;
    }
}
