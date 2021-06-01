
using UnityEngine;

public class LauncherEnemy : MonoBehaviour
{
    
    public GameObject LTarget;
    pool deathPool;
    public float LdamageTaken=3;
    public float LMaxHealth = 10;
    public float LtotalHelath = 10;
    public float MaxdistanceFromTarget = 15f;
    
    public Transform Leftpoint, rightPoint;
    
    
    
    private void Awake()
    {
        deathPool = FindObjectOfType<pool>();
    }
    private void OnEnable()
    {
        LtotalHelath = LMaxHealth;
        
    }
    private void Update()
    {
        
        

        timefromPreviosShoot += Time.deltaTime;
       



        float DistanceFromTarget = transform.position.x - LTarget.transform.position.x;
        //Debug.Log(DistanceFromTarget);
        float distanceFromTargety = Mathf.Abs(transform.position.y - LTarget.transform.position.y);

        if(distanceFromTargety <2f)
        {
            startAttacking();
            


            
        }
        

    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        
        if(col.gameObject.tag == "bullet")
        {
            //take damage;
            launcgerenemydangae(LdamageTaken);


        }
        
    }
    void launcgerenemydangae(float damage)
    {
        LtotalHelath -= damage;
        FindObjectOfType<AudioManager>().PlayMe("enemyHit");
        if (LtotalHelath < 0)
        {
            desthOfLauncher();
        }

    }

    public void desthOfLauncher()
    {
        gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().PlayMe("enemyDie");

        //play a effect
        //enque the game object;
        deathPool.LauncherenemyObjPool.Enqueue(gameObject);

    }


    float  timeBetweensghoot=3f,timefromPreviosShoot;
    
    void startAttacking()
    {
        //Debug.Log("STRTaTTACKING");
        
        if(timefromPreviosShoot>timeBetweensghoot)
            {
                //Debug.Log("start1");
               
                if (deathPool.LauncherEnmyBulletPool == null)
                    deathPool.GrowLauncherEnemyBulletPool();

                GameObject newBigBullet = deathPool.LauncherEnmyBulletPool.Dequeue();
                
                newBigBullet.transform.position = Leftpoint.position;
            if (transform.localEulerAngles.y == 0)
            {
                newBigBullet.transform.localEulerAngles = Vector3.zero;
               // newBigBullet.GetComponent<BigBullet>().BigBulletFireSpeed = -5f;
            }
            else if (transform.localEulerAngles.y == 180)
            {
                newBigBullet.transform.localEulerAngles =new  Vector3(0f,180f,0f);
                //newBigBullet.GetComponent<BigBullet>().BigBulletFireSpeed = -5f;
            }
            newBigBullet.SetActive(true);
               
                timefromPreviosShoot = 0f;

            }
       

    }
}
