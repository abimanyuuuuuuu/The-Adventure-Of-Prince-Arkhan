using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pemain : MonoBehaviour
{
    public float speed, jump;
    Rigidbody2D body;
    SpriteRenderer sprite;
    Animator animator;
    public bool istanah, isdinding;
    public GameObject soal, gameover, finish;
    public AudioSource jump_audio, soal_audio, walk_audio, fall_audio, finish_audio;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow) && !isdinding){           
            if(soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){                 
            body.velocity = new Vector2(speed, body.velocity.y);
            sprite.flipX = false;
            }
            
        }

        if(Input.GetKey(KeyCode.LeftArrow) && !isdinding){  
            if(soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){
            body.velocity = new Vector2(-speed, body.velocity.y);
            sprite.flipX = true;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)){
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && istanah){  
            if(soalaktif() == -1 && !gameover.activeSelf && !finish.activeSelf){     
            body.velocity = new Vector2(body.velocity.x,jump);
            if(Time.timeScale == 1){
            jump_audio.Play();
            }
            } 
        }

        if(transform.localPosition.y <-17){
            body.gravityScale = 0;
            body.velocity = Vector2.zero;
        }

        updateanimation();

    }

    int soalaktif(){
        return soal.GetComponent<soalmanager>().nomor();       
    }

    void updateanimation(){
        if(body.velocity.x>speed/2f || body.velocity.x<-speed/2f){
            animator.SetInteger("state",1);
            if(!walk_audio.isPlaying && istanah){
                if(Time.timeScale == 1){
                walk_audio.Play();
                } 
            }
        }else{
            animator.SetInteger("state",0);
            walk_audio.Stop();
        }
        if(body.velocity.y>0.1f){
            animator.SetInteger("state",2);
            walk_audio.Stop();        
        }
        if(body.velocity.y<-0.1f){
            animator.SetInteger("state",3);
            walk_audio.Stop();     
        }
    }
    void OnTriggerEnter2D(Collider2D obj){
        if(obj.name == "Mati"){
            transform.Find("Main Camera").parent = null;
            fall_audio.Play();
            gameover.SetActive(true);
        }
        if(obj.tag == "Pos"){
            soal_audio.Play();
            soal.transform.GetChild(obj.transform.GetSiblingIndex()).gameObject.SetActive(true);
            obj.GetComponent<SpriteRenderer>().enabled = false;
            obj.GetComponent<BoxCollider2D>().enabled = false;
            obj.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(obj.name == "Finish"){       
        if(soal.GetComponent<soalmanager>().soalterjawab == 5){
        finish.SetActive(true);
        finish_audio.Play();

        }

        }
    }
}
