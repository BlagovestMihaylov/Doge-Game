using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource BonkSound = new AudioSource();

    private bool play = false;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "ThrowableDurvo(Clone)") play=true;
        if (coll.gameObject.name == "Durvo(Clone)") play=true;
        // Destroy(wood);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (play == true)
        {
            BonkSound.Play(0);
            play=false;
        }
    }
}
