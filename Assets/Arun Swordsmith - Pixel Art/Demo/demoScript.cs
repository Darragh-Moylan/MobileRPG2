using UnityEngine;
using System.Collections;

public class demoScript : MonoBehaviour {

    [SerializeField] float      speed = 1.0f;
    [SerializeField] bool       attackAnticipation = true;
    [SerializeField] bool       noBlood = false;

    private float               inputX;
    private Animator            animator;
    private Rigidbody2D         body2d;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        body2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        // -- Handle input and movement --
        inputX = Input.GetAxis("Horizontal");

        // Swap direction of sprite depending on walk direction
        if (inputX > 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // Move
        body2d.velocity = new Vector2(inputX * speed, body2d.velocity.y);

        // -- Handle Animations --
        //Death
        if (Input.GetKeyDown("k"))
        {
            animator.SetBool("noBlood", noBlood);
            animator.SetTrigger("Death");
        }
            
        //Hurt
        else if (Input.GetKeyDown("h"))
            animator.SetTrigger("Hit");

        //Attack
        else if(Input.GetMouseButtonDown(0))
        {
            animator.SetBool("hasAttackAnticipation", attackAnticipation);
            animator.SetTrigger("Attack");
        }

        //Walk
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            animator.SetInteger("AnimState", 1);
        //Idle
        else
            animator.SetInteger("AnimState", 0);
    }
}
