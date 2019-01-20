using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Camera cam;
    public Color BlackColour = Color.black;
    public Color GreenColour = Color.green;
    public Color RedColour = Color.red;
    public bool win = false;
    void GoBall() {
        float rand = Random.Range(0, 2);
        if (rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        }
        else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    } 

    void ResetBall() {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    
    void RestartGame() {
        ResetBall();
        Invoke("GoBall", 1);
        
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.collider.CompareTag("Player")) {
            Vector2 vel; 
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y /2) + (coll.collider.attachedRigidbody.velocity.y / 3);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (win == true ) {
            cam = GetComponent<Camera>();
            cam.backgroundColor = Color.Lerp(BlackColour, GreenColour, 2.0f);
            cam.backgroundColor = Color.Lerp(GreenColour, BlackColour, 2.0f);
            win = false;
        }
    }
}
