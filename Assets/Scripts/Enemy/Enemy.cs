using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

   // public GameObject diamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
   // [SerializeField]
   // protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isDead = false;

    protected bool isHit = false;

    protected Player player;




    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death") && anim.GetBool("InCombat") == false || isDead == true)
        {
            return;
        }


        if (isDead == false)
        {
            Movement();
        }


    }

    // public Transform target;
    // private void Chase()
    // {
    //    Vector3 targetDirection = target.position - transform.position;
    //    transform.position += targetDirection * speed * Time.deltaTime;
    // }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isDead == false)
        {

            //Chase();

            Debug.Log("Collided!");
            anim.Play("Attack");
            //speed = 0;
        }
        else
        {
            return;
        }

    }



    public virtual void Movement()
    {


 
        if (currentTarget == pointA.position)
        {
            //sprite.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            //sprite.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }


        if (transform.position == pointA.position)
        {


            currentTarget = pointB.position;
            //anim.SetTrigger("Idle");


        }

        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            //anim.SetTrigger("Idle");

        }

        if (anim.GetBool("InCombat") == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }


        if (isHit == true)
        {
            // speed = 0;
        }


        Vector3 direction = player.transform.localPosition - transform.localPosition;


        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            //face right
            //sprite.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
            currentTarget = pointB.position;

        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            //face left
           // sprite.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
            currentTarget = pointA.position;
        }


        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {

            //anim.SetBool("InCombat", true);
            //transform.position += transform.forward * Time.deltaTime * speed;
            //currentTarget = storePos;
          // currentTarget = transform.position;
        }

    }

}
