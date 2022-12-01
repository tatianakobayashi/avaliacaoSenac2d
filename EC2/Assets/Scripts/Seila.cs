using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seila : MonoBehaviour
{
    public GameObject player;
    public GameObject villain;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Vector3.MoveTowards(player.transform.position, villain.transform.position, velocity * Time.deltaTime);
    }
}
