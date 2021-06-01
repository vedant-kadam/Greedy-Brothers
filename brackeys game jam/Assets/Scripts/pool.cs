using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{

    public GameObject BulletPrefab,SwordEnemyPrefab,LauncherEnemyPrefab,EnmyBulletPrefab;

    public Queue<GameObject> bullets = new Queue<GameObject>();
    public Queue<GameObject> swordEnemyObjpool = new Queue<GameObject>();
    public Queue<GameObject> LauncherenemyObjPool = new Queue<GameObject>();
    public Queue<GameObject> LauncherEnmyBulletPool = new Queue<GameObject>();


    int BullletPoolSize = 15;
    int SwordEnemyPoolsize = 20;
    int LauncherEnemyPoolSize = 20;
    int LauncherEnmyBulletPoolSize = 15;

    private void Awake()
    {
        GrowBulletPool();
        GrowSwordEnemyPool();
        GrowLauncherEnemyPool();
        GrowLauncherEnemyBulletPool();
    }


    private void Update()
    {
        if (swordEnemyObjpool.Count < 6)
            GrowSwordEnemyPool();
        if (LauncherenemyObjPool.Count < 6)
            GrowLauncherEnemyPool();
        if (LauncherEnmyBulletPool.Count < 5)
            GrowLauncherEnemyBulletPool();
       

    }
    public void GrowBulletPool()
    {
        for(int i=0;i<BullletPoolSize;i++)
        {
            GameObject BulletPre = Instantiate(BulletPrefab);
            BulletPre.SetActive(false);
            bullets.Enqueue(BulletPre);
        }
    }
    public  void GrowSwordEnemyPool()
    {
        for (int i = 0; i < SwordEnemyPoolsize; i++)
        {
            GameObject SwordEnemyPre = Instantiate(SwordEnemyPrefab);
            SwordEnemyPre.SetActive(false);
            swordEnemyObjpool.Enqueue(SwordEnemyPre);
        }

    }

    public void GrowLauncherEnemyPool()
    {
        for (int i = 0; i < LauncherEnemyPoolSize; i++)
        {
            GameObject LauncherEenemyPre = Instantiate(LauncherEnemyPrefab);
            LauncherEenemyPre.SetActive(false);
            LauncherenemyObjPool.Enqueue(LauncherEenemyPre);
        }

    }
    public void GrowLauncherEnemyBulletPool()
    {
        for (int i = 0; i < LauncherEnmyBulletPoolSize; i++)
        {
            GameObject enmyBulletPre = Instantiate(EnmyBulletPrefab);
            enmyBulletPre.SetActive(false);
            LauncherEnmyBulletPool.Enqueue(enmyBulletPre);
        }
    }
}
