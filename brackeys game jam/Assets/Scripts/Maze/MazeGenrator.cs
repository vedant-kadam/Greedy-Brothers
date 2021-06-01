using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenrator : MonoBehaviour
{
    public float mazeHeight,mazeWidth;//height and width of a whole maze
    public Transform parentGameObj;
    public int floorOffset;
    public Transform spawnPoint;
    public GameObject Block;

    

    private void Start()
    {
        StartGeneration();
    }

   

    void StartGeneration()
    {
        Vector3 spawnPos = spawnPoint.position;

        for (int k =0;k<(mazeHeight/floorOffset);k++)
        {

            
            
            //every blick is away from another block by 2 units

            //spawn block for kth row
        
            for (int i = 0; i < (mazeWidth / 2); i++)
            {
                int p = Random.Range(1, 8);

                if (p <= 3)//i will start spawnning at that spawn point 
                {

                    int q = Random.Range(4, 10);
                   if(q>5)
                    {
                       if( Random.Range(0,2) ==1)
                        {
                            q = Random.Range(4, 11);
                        }
                             
                       
                    }


                    for (int j = 0; j < q; j++)
                    {
                        if (spawnPos.x > (mazeWidth / 2 + 1)) break;
                        Instantiate(Block, spawnPos, Quaternion.identity, parentGameObj);
                        spawnPos += new Vector3(2f, 0f, 0f);
                        i = i + 1;

                    }

                    spawnPos += new Vector3(4f, 0f, 0f);


                }
                else
                {
                    spawnPos += new Vector3(4f, 0f, 0f);
                    i++;
                }










            }

            spawnPos = new Vector3(spawnPoint.position.x, floorOffset+spawnPos.y, 0f);


            //incremnt by floor height


        }

        
    }

    
}
