using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }




    //use for initialize
    public override void Init()
    {
        base.Init();

        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();

        // SETS ENEMY ATTACK DISTANCE
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        // Debug.Log("Distance: " + distance + " for: "+ transform.name) ;
        if (distance > 2.5f)
        {
            isHit = false;
            anim.SetBool("InCombat", false);
        }
        if (distance < 2.3f)
        {
            anim.SetBool("InCombat", true);

        }



    }


    public void Damage()
    {

        if (isDead == true)
            return;
        Debug.Log("MossGiant::Damage()");

        Health--;
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            //GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            //diamond.GetComponent<Diamond>().gems = base.gems;
        }

    }

}

