
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f,jumpDelay;
    public float JumpForce=1f;
    Rigidbody2D rb;
    float Xinput;
    public SpriteRenderer attack1, tank1;
    public GameObject RightShild, RightLauncher, LeftShield, LeftLauncher;
    bool canJump=true;
    float timeSinceLastJump;
    public bool canShowShield = true;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Xinput = Input.GetAxis("Horizontal");


        transform.Translate(Vector2.right * Xinput * Time.deltaTime * speed);



        PlayerJump();


        SpriteFlipper();


        WeaponPositionChange();
    }

    void WeaponPositionChange()
    {
        if(attack1.flipX || tank1.flipX)
        {
            //left side on
            LeftLauncher.SetActive(true);
            RightLauncher.SetActive(false);
            if(canShowShield)
            {
                LeftShield.SetActive(true);
                RightShild.SetActive(false);
            }
            

        }else
        {

            //right side on
            LeftLauncher.SetActive(false);
            RightLauncher.SetActive(true);
            if(canShowShield)
            {
                LeftShield.SetActive(false);
                RightShild.SetActive(true);
            }
           
        }

    }
    void SpriteFlipper()
    {
        if (Xinput < 0)
        {

            attack1.flipX = true;
            tank1.flipX = true;
        }
        else if (Xinput > 0)
        {
            attack1.flipX = false;
            tank1.flipX = false;
        }
    }





    /// <summary>
    /// player Jump
    /// </summary>
    void PlayerJump()
    {
        timeSinceLastJump += Time.deltaTime;
        if(timeSinceLastJump>jumpDelay)
        {
            canJump = true;
        }
        if (Input.GetButton("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f && canJump)
        {
            FindObjectOfType<AudioManager>().PlayMe("Jump");
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            canJump = false;
            timeSinceLastJump = 0;
        }

    }
}
