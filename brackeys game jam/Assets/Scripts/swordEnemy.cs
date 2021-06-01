using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class swordEnemy : MonoBehaviour
{
    float enemySpeed = 3f;
     GameObject swordTarget;
    pool deathPool;
    public float damageTaken=5;
    public float MaxHealth = 10;
    public float totalHelath = 10;
    // Animator SwordAnimator;
    InfoHolder PlayerIntell;
    float awketimesword = 15f;
    Rigidbody2D Rbs;
    
    
    private void Awake()
    {
        deathPool = FindObjectOfType<pool>();
        PlayerIntell = FindObjectOfType<InfoHolder>();
    }
    private void OnEnable()
    {
        totalHelath = MaxHealth;
        Rbs = GetComponent<Rigidbody2D>();
        awketimesword = Random.Range(10f,20f);
    }
    private void Start()
    {
        //rbd = transform.GetComponent<Rigidbody2D>();
        // SwordAnimator = GetComponent<Animator>();
        swordTarget = PlayerIntell.mainPlayer;
       

    }
    private void Update()
    {
        float DistanceFromTarget = transform.position.x - swordTarget.transform.position.x;
        //Debug.Log(DistanceFromTarget);
        float distanceFromTargety = Mathf.Abs(transform.position.y - swordTarget.transform.position.y);
        awketimesword -= Time.deltaTime;
        if(awketimesword<0)
        {if (distanceFromTargety > 5f && Random.Range(0, 10) < 5)
                desthOfsword();
            else if (Random.Range(0, 10) < 5)
                desthOfsword();
        }
        if((transform.position.y - swordTarget.transform.position.y)<-10f)
        {
            Rbs.gravityScale = 0f;
        }
        else
        {
            Rbs.gravityScale = 1f;
        }
        if (swordTarget.transform.position == transform.position) desthOfsword();
        transform.Translate(-Vector3.right * Time.deltaTime * enemySpeed);



        

        if(distanceFromTargety <2f)
        {
            //startAttacking();
            if(DistanceFromTarget<0)
            {
                if (transform.localEulerAngles.y == 0)
                    transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }else 
            {
                if(transform.localEulerAngles.y==180)
                {
                    transform.localEulerAngles = Vector3.zero;
                }
            }
        }
        
        

    }
    bool justhit = false;
    public float forceMagnitude=1f;
    private void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag =="tankShield" )
        {
            if(!justhit)
            {
                SwordEnemyTAkeDamage(5f);
                enemySpeed = 0f;
                if (transform.localEulerAngles.y == 0)
                    Rbs.AddForce(Vector2.right * 100f, ForceMode2D.Impulse);
                else
                    Rbs.AddForce(Vector2.right * -100f, ForceMode2D.Impulse);




            }
            




        }
        else
        {
            justhit = true;
            enemySpeed = 2.5f;
           
        }

        if(col.gameObject.tag == "bullet")
        {
            //take damage;
            SwordEnemyTAkeDamage(damageTaken);


        }
        if(col.gameObject.tag == "walls")
        {
            if (transform.localEulerAngles.y == 180) transform.localEulerAngles = Vector3.zero;
            else
            {
                transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            }
        }
    }
    void SwordEnemyTAkeDamage(float damage)
    {
        totalHelath -= damage;
      //  FindObjectOfType<AudioManager>().PlayMe("enemyHit");
        if (totalHelath < 0)
        {
            desthOfsword();
        }

    }

    public void desthOfsword()
    {
        gameObject.SetActive(false);
        //FindObjectOfType<AudioManager>().PlayMe("enemyDie");
        //play a effect
        //enque the game object;
        deathPool.swordEnemyObjpool.Enqueue(gameObject);

    }
   

   
    
    
}
