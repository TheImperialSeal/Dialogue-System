using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float horizontal;
    float vertical;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //basic movement controls
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
