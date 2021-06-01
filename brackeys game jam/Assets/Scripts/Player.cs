using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    InfoHolder IFP;
    PlayerSwitch PS;
    PlayerMovement Pm;
    pool BP;
    public Transform SHootPosRight, ShootPosLeft;
    public float SpeedOfBullet;
    public GameObject MyShield1, Myshild2;
    public SpriteRenderer S1, S2;
    
    public float BackHealthh, ShieldHealth, LauncherHealth;
    [HideInInspector]
   public  float TbackHealth, TshieldHealth, ALauncgerHealth;


    gameManager Gm;
    private void Awake()
    {
        IFP = FindObjectOfType<InfoHolder>();
        PS = FindObjectOfType<PlayerSwitch>();
        BP = FindObjectOfType<pool>();
        Pm = GetComponent<PlayerMovement>();
        Gm = FindObjectOfType<gameManager>();
    }
    private void Start()
    {
        Time.timeScale = 1f;
        TbackHealth = BackHealthh;
        TshieldHealth = ShieldHealth;
        ALauncgerHealth = LauncherHealth;
        
    }
    public Color c1, c2;
    private void Update()
    {
      // Debug.Log(shootCount );
        checkForDeath();
        //checking attcak Position
        if(PS.attcakPosition ==0)
        {
         //   if(IFP.firstPosi.position == IFP.BlasterPlayer.transform.position)
            ///attcak FronLeft;
            attcakkLeft();
            if (TshieldHealth > 0)
            {
                MyShield1.SetActive(true);
                Myshild2.SetActive(false);
            }
            
        }
        else
        {
            //attackFrom From Right
            attcakRight();
            Myshild2.SetActive(true);
            MyShield1.SetActive(false);
        }
        shootTiome += Time.deltaTime;
        RelodeTime += Time.deltaTime;
        int lerpc = -1;
        if(TshieldHealth<ShieldHealth)
        {
            lerpc = -1;
        }
        else
        {
            lerpc = 1;
        }

        S1.color = Color.Lerp(c1, c2, lerpc*TshieldHealth*Time.deltaTime/10f);
        S2.color = Color.Lerp(c1, c2, lerpc * TshieldHealth * Time.deltaTime/10f);



    }

    void attcakRight()
    {
        if(IFP.firstPosi.position == IFP.BlasterPlayer.transform.position)
        {
            //do shooting
            if(Input.GetMouseButton(0)&& (shootTiome > TimeDelayBetweenEachShot))
            {
                
                
                if(shootCount>0)
                {
                    shootCount--;
                    shoot(1);
                    shootTiome = 0f;
                }
                
            }
            //rechage Myshiels
            shieldRestore();
            
            
        }
        else
        {
            //rechage My bullet
            Bullestore();
            LaucheRes();
            //do defending
        }
    }

    public float TimeDelayBetweenEachShot;
    float shootTiome;
   public int shootCount = 10;
    void attcakkLeft()
    {
        if(IFP.Secondpos.position == IFP.BlasterPlayer.transform.position)
        {
            //do shooting
            if(Input.GetMouseButton(0) && (shootTiome > TimeDelayBetweenEachShot))
            {
                
                if (shootCount > 0)
                {
                    shootCount--;
                    shootTiome = 0f;
                    shoot(0);
                }
                
            }

            //recharge shield
            shieldRestore();
        }else
        {
            Bullestore();
            LaucheRes();
            //rechage blaster
        }
    }


    void shoot(int dire)
    {

        if (BP.bullets == null) BP.GrowBulletPool();
        GameObject newBullet = BP.bullets.Dequeue();
        
        if (dire ==0)
        {
            newBullet.transform.position = ShootPosLeft.position;
             newBullet.GetComponent<Bullet>().FireSpeed = -SpeedOfBullet;

        }
        else
        {
            newBullet.transform.position = SHootPosRight.position;
            newBullet.GetComponent<Bullet>().FireSpeed = SpeedOfBullet;
        }

        FindObjectOfType<AudioManager>().PlayMe("pShoot");
        newBullet.SetActive(true);
        

    }

    public void Recivedamage(float damagetaKen)
    {
        ///reduce the heaklyh
      //  Debug.Log("I took Damage from playerTouch");
        ALauncgerHealth -= damagetaKen;
        // Debug.Log("lAUNCHER  " + ALauncgerHealth);
        FindObjectOfType<AudioManager>().PlayMe("pHit");



    }
    public void ReciveShieldDamage(float dameShirld)
    {
       // FindObjectOfType<AudioManager>().PlayMe("pHit");
        TshieldHealth -= dameShirld;
       // Debug.Log("sHIELD  " + TshieldHealth);
    }

    public void ReciveBackDge(float BakcDmgRec)
    {
        FindObjectOfType<AudioManager>().PlayMe("pHit");
        TbackHealth -= BakcDmgRec;
       // Debug.Log("back   " + TbackHealth);

    }
    void checkForDeath()
    {
        if(ALauncgerHealth<0 || TbackHealth<0)
        {
            FindObjectOfType<AudioManager>().PlayMe("playerDie");
            gameObject.SetActive(false);
            Gm.playerDeathRituals();



            
        }
        if(TshieldHealth<0)
        {
            FindObjectOfType<AudioManager>().PlayMe("playerDie");
            Pm.canShowShield = false;
            // MyShield1.GetComponent<PolygonCollider2D>().enabled = false;
            // Myshild2.GetComponent<PolygonCollider2D>().enabled = false;
            MyShield1.SetActive(false);
            Myshild2.SetActive(false);

        }
        else
        {
            //  MyShield1.GetComponent<PolygonCollider2D>().enabled = true;
            //  Myshild2.GetComponent<PolygonCollider2D>().enabled = true;
            
        }
    }


    float MaxresTime = 0.4f, ResTime = 0;
    void shieldRestore()
    {
       
       if(TshieldHealth<ShieldHealth)
        {
            ResTime += Time.deltaTime;
            if(ResTime>MaxresTime)
            {
                TshieldHealth += 0.5f;
                ResTime = 0f;
            }
           
        }
    }

    float MaxRelodeTime = 1.5f, RelodeTime = 0;
    void Bullestore()
    {
        //Debug.Log("bullet res");
        if(RelodeTime>MaxRelodeTime)
        {
            if(shootCount<10)
            {
                shootCount+=1;
                RelodeTime = 0;
            }
        }
    }
    float MaxresTimeL = 0.4f, ResTimeL = 0;
    void LaucheRes()
    {

        if (ALauncgerHealth < LauncherHealth)
        {
            ResTimeL += Time.deltaTime;
            if (ResTimeL > MaxresTimeL)
            {
                ALauncgerHealth += 0.25f;
                ResTimeL = 0f;
            }

        }
    }
    



}
