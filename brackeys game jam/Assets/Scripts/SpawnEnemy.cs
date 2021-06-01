using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform SpawnTrigger;
    public float distanceforTrigger;
    public List<Transform> Points = new List<Transform>();
    
    pool MyPool;
    public float TimeBetweenspawn=8f;
    float TimeFromPreviousspawn =0;

    private void Awake()
    {
        MyPool = FindObjectOfType<pool>();
    }
    private void Start()
    {
        TimeFromPreviousspawn = TimeBetweenspawn;
    }

    int spawnpoiiNo = 0;
    private void Update()
    {
        TimeFromPreviousspawn += Time.deltaTime;
        if(TimeBetweenspawn<TimeFromPreviousspawn)
        {

            for (int i = 0; i < Points.Count; i++)
            {
                int canSpawn = Random.Range(0, 3);
                if (canSpawn == 0)
                {
                    spawnpoiiNo = i;
                    StartCoroutine("spawnitnow");
                }
            }
            TimeFromPreviousspawn = 0;

        }
        
    }

    
  IEnumerator spawnitnow()
    {
        
        GameObject spwnObj;
        spwnObj = MyPool.swordEnemyObjpool.Dequeue();
        
        spwnObj.transform.position = Points[spawnpoiiNo].position;
        spwnObj.transform.localEulerAngles = Vector3.zero;
        spwnObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
    }
    


}
