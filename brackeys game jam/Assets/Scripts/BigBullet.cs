using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBullet : MonoBehaviour
{
    public float BigBulletFireSpeed;
    float justEnableTime;
    pool BOP;
    public List<string> tagList = new List<string>();
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

        transform.Translate(Vector3.right * Time.deltaTime * BigBulletFireSpeed);
    }
    private void OnEnable()
    {
        justEnableTime = 5f;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(tagList.Contains(coll.gameObject.tag))
        {
            EnquiingBullet();
        }
        
    }

    void EnquiingBullet()
    {
        gameObject.SetActive(false);
        BOP.LauncherEnmyBulletPool.Enqueue(gameObject);
    }
}
