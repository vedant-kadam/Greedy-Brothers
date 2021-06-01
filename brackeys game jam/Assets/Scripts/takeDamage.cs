using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
  public  float plainDamage, BigBulletDaamge;
    gameManager gm1;
    private void Awake()
    {
        gm1 = FindObjectOfType<gameManager>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" )
        {
            if (gameObject.tag == "blastPlayer" )
            GetComponentInParent<Player>().Recivedamage(plainDamage);
             else if (gameObject.tag == "tankShield")
            {
                FindObjectOfType<AudioManager>().PlayMe("shieldHit");
                GetComponentInParent<Player>().ReciveShieldDamage(plainDamage);
            }else if (gameObject.tag == "tankBack" )
            {
                GetComponentInParent<Player>().ReciveBackDge(plainDamage);
            }
        }
        else if ( collision.gameObject.tag == "BigBullet")
        {
            if (gameObject.tag == "blastPlayer")
                GetComponentInParent<Player>().Recivedamage(BigBulletDaamge);
            else if (gameObject.tag == "tankShield")
            {
                FindObjectOfType<AudioManager>().PlayMe("shieldHit");
                GetComponentInParent<Player>().ReciveShieldDamage(BigBulletDaamge-1);
            }
            else if (gameObject.tag == "tankBack")
            {
                GetComponentInParent<Player>().ReciveBackDge(BigBulletDaamge);
            }
        }
        if(collision.gameObject.tag =="Gold")
        {
            gm1.targetAquireq();
            collision.gameObject.SetActive(false);
        }
    }

   
}
