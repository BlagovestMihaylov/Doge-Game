using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWood : MonoBehaviour
{
    public GameObject Boromir;
    public GameObject Player;
    public GameObject wood;

    public float xAngle, yAngle, zAngle = 1F;
    public float maxVelocity;
    private Rigidbody2D rigidBody;
    public float speed = 1f;

    public Vector3 movePosition;

    private float BoromirX;
    private float PlayerX;
    private float PlayerY;
    private float nextX;
    private float dist;
    private float baseY;
    private float height;
    private float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Boromir = GameObject.FindGameObjectWithTag("Boss");
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerX = Player.transform.position.x;
        PlayerY = Player.transform.position.y;
        maxVelocity = 5f;
        lifeTime = 5f;
        rigidBody = wood.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destroy(wood);
            }
        }

        float speed = Vector3.Magnitude(rigidBody.velocity);  // test current object speed
        if (speed > maxVelocity)
        {
            float brakeSpeed = speed - maxVelocity;  // calculate the speed decrease

            Vector3 normalisedVelocity = rigidBody.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value

            rigidBody.AddForce(-brakeVelocity);  // apply opposing brake force
        }
        wood.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);

        BoromirX = Boromir.transform.position.x;

        dist = PlayerX - BoromirX;
        nextX = Mathf.MoveTowards(wood.transform.position.x, PlayerX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(Boromir.transform.position.y, PlayerY, (nextX - BoromirX) / dist);
        height = 10 * (nextX - BoromirX) * (nextX - PlayerX) / (-0.25f * dist * dist);

        movePosition = new Vector3(nextX, baseY + height, wood.transform.position.z);

        //wood.transform.rotation = LookAtTarget(movePosition - wood.transform.position);
        wood.transform.position = movePosition;

        if (movePosition.x == PlayerX - 5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log("OnCollisionEnter2D");
        // Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "Player")
        {
            Debug.Log("Wood hit Player!!!!");
        }
        if (coll.gameObject.name == "Tilemap")
        {
            // Debug.Log("Wood hit ground");
        }
        if (coll.gameObject.name != "ThrowableDurvo(Clone)" && coll.gameObject.name != "Boromir")
            Destroy(wood);
    }
    public static Quaternion LookAtTarget(Vector2 r)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(r.y, r.x) * Mathf.Rad2Deg);
    }
}