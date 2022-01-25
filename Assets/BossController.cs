using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField]

    public GameObject Boromir;
    public AudioSource BoromirSound = new AudioSource();
    public int HornChange;
    public GameObject[] spawnees;
    [SerializeField] [Range(-2000f, 0f)] private float left;
    [SerializeField] [Range(0f, 2000f)] private float right;

    [SerializeField] [Range(27, 40f)] private float top;
    [SerializeField] [Range(15f, 20f)] private float bottom;
    [SerializeField] [Range(1f, 11f)] private float spawnDelay;
    private int randomInt;

    private float HornCooldown;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        HornCooldown = 15f;
    }

    void WoodAttack()
    {
        for (int i = 0; i < 10; i++)
        {
            this.randomInt = Random.Range(0, spawnees.Length);
            var pos = new Vector3(Random.Range(left, right), Random.Range(top, top * 2), -5);
            // ExecuteAfterTime(spawnDelay);
            Instantiate(spawnees[0], pos, Quaternion.identity);
        }
    }

    void throwWoodAttack()
    {
        //Debug.Log("Throw");
        this.randomInt = Random.Range(0, spawnees.Length);
        Vector3 offset = new Vector3(-3, 3, -5);
        var pos = Boromir.transform.position + offset;
        // ExecuteAfterTime(spawnDelay);
        Instantiate(spawnees[1], pos, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        float random = Random.Range(0, 100000);
        //Debug.Log(random);
        HornCooldown -= Time.deltaTime;
        if (HornCooldown < 0)
        {
            //Debug.Log("Horn");
            anim.SetTrigger("Horn");
            if (!BoromirSound.isPlaying)
            {
                BoromirSound.Play();
                WoodAttack();
            }
            HornCooldown = 15;
        }
        if (random < HornChange * 10 && HornCooldown > 1)
        {
            throwWoodAttack();
        }

    }
}
