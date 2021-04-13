using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float DefaultForce;
    float startHeight;
    float inputArrow;
    public float SpeedFactor;
    public Renderer rendererPlayer;
    
    public TrailRenderer trail;

    

    void Start()
    {
        startHeight = transform.position.y;
        gameObject.tag = "Green";
    }



    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == gameObject.tag)
        {

        }
        else if(other.gameObject.tag == "MainRoad")
        {

        }
        else
        {
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                                 GameManager.Instance.finishLine.transform.position,
                                                 DefaultForce);

   

        inputArrow = Input.GetAxis("Horizontal");
        if(inputArrow != 0)
        {
            transform.position = new Vector3 (transform.position.x + (inputArrow/SpeedFactor),
                                              transform.position.y,
                                              transform.position.z);
                  
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(DefaultForce < 0.07)
                DefaultForce += 0.01f;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(DefaultForce >= 0.03)
                DefaultForce -= 0.01f;
        }


        if(Input.GetKeyDown(KeyCode.Q))
        {
            rendererPlayer.material.color = Color.black;
            gameObject.tag = "Black";     
            trail.startColor  = Color.black;
            trail.endColor  = Color.black;
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            rendererPlayer.material.color = Color.green;
            gameObject.tag = "Green"; 
            trail.startColor  = Color.green;
            trail.endColor  = Color.green;
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            rendererPlayer.material.color = Color.red;
            gameObject.tag = "Red"; 
            trail.startColor  = Color.red;
            trail.endColor  = Color.red;
        }

        if(transform.position.y != 0.5f)
        {
            transform.position = new Vector3(transform.position.x,
                                              0.5f,
                                              transform.position.z);
        }
    }
}
