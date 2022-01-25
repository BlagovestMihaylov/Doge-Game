using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFall : MonoBehaviour
{
    public GameObject[] spawnees;
    [SerializeField] [Range(-2000f, 0f)] private float left;
    [SerializeField] [Range(0f, 2000f)] private float right;

    [SerializeField] [Range(27, 40f)] private float top;
    [SerializeField] [Range(15f, 20f)] private float bottom;
    [SerializeField] [Range(1f, 11f)] private float spawnDelay;

    int randomNumber;
    private GameObject temp;
    int randomInt;

    // private void Start()
    // {
    //     StartCoroutine(ExecuteAfterTime(spawnDelay));
    // }
    // IEnumerator ExecuteAfterTime(float time)
    // {
    //     yield return new WaitForSeconds(time);

    //    // SpawnRandom();
    // }
    [SerializeField] [Range(0, 50)] private int difficulty;
    private void Update()
    {
        randomNumber = Random.Range(0, 10000);
        if (randomNumber < difficulty)
        {
            //ExecuteAfterTime(spawnDelay);
            SpawnRandom();
        }
        //SpawnRandom();

    }

    // private void FixedUpdate()
    // {

    //         ExecuteAfterTime(spawnDelay);

    // }
    void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        var pos = new Vector3(Random.Range(left, right), Random.Range(top, bottom), -5);
        // ExecuteAfterTime(spawnDelay);
        temp = (GameObject)Instantiate(spawnees[randomInt], pos, Quaternion.identity);
        Destroy(temp, 10);

    }
}
