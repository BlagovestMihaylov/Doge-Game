using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWood : MonoBehaviour
{
    // Start is called before the first frame update

    public float maxVelocity;
    public AudioSource BonkSound;
    private float lifeTime;
    public GameObject wood;
    private Rigidbody2D rigidBody;
    public float xAngle, yAngle, zAngle;
    void Start()
    {
        lifeTime = 10f;
        maxVelocity = 20f;
        rigidBody = wood.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            Debug.Log("Wood hit Player!!!!");
            Destruction(wood);
        }
        if (coll.gameObject.name == "Tilemap")
        {
            Destruction(wood);
        }
    }
    void Update()
    {
        float speed = Vector3.Magnitude(rigidBody.velocity);  // test current object speed
        if (speed > maxVelocity)
        {
            float brakeSpeed = speed - maxVelocity;  // calculate the speed decrease

            Vector3 normalisedVelocity = rigidBody.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value

            rigidBody.AddForce(-brakeVelocity);  // apply opposing brake force
        }
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                Destruction(wood);
            }
        }
        wood.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }

    void Destruction(GameObject wood)
    {
        Destroy(wood);
    }
}
