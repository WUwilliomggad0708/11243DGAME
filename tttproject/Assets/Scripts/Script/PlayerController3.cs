using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{
    public Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityMod = 0;
    //是否貼和地板
    public bool isOnGround = true; 
    public bool gameOver = false;
    public Animator playerAnim;//玩家動畫控制
    public ParticleSystem playerExplodation;
    void Start()
    {
        //獲得剛體的控制權
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity = Physics.gravity * gravityMod;
        //調適重力
        playerAnim = GetComponent<Animator>();

    }

    void Update()
    {
        //改為可二段跳方式(極限二段跳)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true  && ! gameOver )// twiceJump < 2)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isOnGround = false; //切換1：false
           // twiceJump++; //twiceJump = twiceJump + 1;
            //print("跳的次數: " + twiceJump);
            playerAnim.SetTrigger("Jump_trig");
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; //切換2：true
            //twiceJump = 0;
            //playerAnim.SetFloat("Speed_f",1);
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            print("GGGGame Over!!!");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerExplodation.Play();
        }
        
        
    }

}
