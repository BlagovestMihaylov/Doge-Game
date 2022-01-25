using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Explosive")
        {
            return;
        }
        StartCoroutine(Hit());
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        hit = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX; 
        }

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator Hit()
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
        while (anim.GetCurrentAnimatorClipInfo(0).Length != 0)
        { 
            yield return null;
        }
        Destroy(gameObject);
    }

    private void Deactivate()
    {
        Destroy(gameObject);
    }
}