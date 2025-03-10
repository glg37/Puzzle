using UnityEngine;

[RequireComponent(typeof(PointEffector2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Magnet : MonoBehaviour
{
    PointEffector2D magnet;
    Rigidbody2D rb;
    float force;
    // Start is called before the first frame update
    void Start()
    {
        magnet = GetComponent<PointEffector2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        magnet.enabled = false;
        force = magnet.forceMagnitude;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
        magnet.enabled = Input.GetButton("Fire1");
        if (Input.GetButton("Fire1"))
        {
            magnet.forceMagnitude = force;
        }
        
    }
}
