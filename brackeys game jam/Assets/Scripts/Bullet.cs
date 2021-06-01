using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float FireSpeed;
    float justEnableTime;
    pool BOP;
    private void Awake()
    {
        BOP = FindObjectOfType<pool>();
    }

    // Update is called once per frame
    void Update()
    {
        justEnableTime -= Time.deltaTime;
        if (justEnableTime < 0)

            EnquiingBullet();
       
        transform.Translate(Vector3.right * Time.deltaTime * FireSpeed);
    }
    private void OnEnable()
    {
       justEnableTime = 10f;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        
   
        if(   coll.gameObject.tag == "walls" || coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Platforms" )
        {

            EnquiingBullet();
           // gameObject.SetActive(false);

        }
    }

    void EnquiingBullet()
    {
        gameObject.SetActive(false);
        BOP.bullets.Enqueue(gameObject);
    }
}
