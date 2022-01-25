using UnityEngine;
using Photon.Pun;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireball;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;


    PhotonView view;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(!view.IsMine)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Q) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        //fireballs[FindFireball()].transform.position = firePoint.position;
        //fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        var projectile = PhotonNetwork.Instantiate(fireball.name, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    //private int FindFireball()
    //{
    //    for (int i = 0; i < fireballs.Length; i++)
    //    {
    //        if (!fireballs[i].activeInHierarchy)
    //            return i;
    //    }
    //    return 0;
    //}
}