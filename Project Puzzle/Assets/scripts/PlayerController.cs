using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;    
    public float buoyancyForce = 10f; 
    public float downwardForce = 10f;  
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        ApplyBuoyancy();
    }

    
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); 

        
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);  
    }

    
    void ApplyBuoyancy()
    {
        if (rb.velocity.y < 0) 
        {
            rb.AddForce(Vector2.up * buoyancyForce); 
        }
    }

   
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S))  
        {
            rb.velocity = new Vector2(rb.velocity.x, -downwardForce);  
        }
    }

}
