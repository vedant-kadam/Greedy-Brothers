using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public Transform First, Second, attack, tank, TF, TB, T1, T2;


    public int attcakPosition=1;
   // public SpriteRenderer TankImage, AttackImage;
    

    private void Start()
    {
        
    }
    private void Update()
    {
        PositionChanger();
        DamageAreachanger();
        
    }
    /// <summary>
    /// /chnages the position of both the players
    /// </summary>
    void PositionChanger()
    {
       if(Input.GetKeyDown(KeyCode.Q))
        {
            if (tank.position == First.position)
            {
                tank.position = Second.position;
                attack.position = First.position;
            }
            else if(tank.position == Second.position)
            {
                tank.position = First.position;
                attack.position = Second.position;
            }
            
              
        }
    }

    float XInput;

    /// <summary>
    /// chnages the position of the collider and flips the sprits
    /// </summary>
    void DamageAreachanger()
    {
        XInput = Input.GetAxis("Horizontal");
        if(XInput>0)
        {
            attcakPosition = 1;
            TF.position = T1.position;
            TB.position = T2.position;
           // TankImage.flipX = false;
           // AttackImage.flipX = false;

        }else if(XInput<0)
        {
            attcakPosition = 0;
            TF.position = T2.position;
            TB.position = T1.position;
           // TankImage.flipX = true ;
           // AttackImage.flipX = true;

        }
    }

    
}
