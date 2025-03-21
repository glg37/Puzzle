using UnityEngine;
using UnityEngine.SceneManagement;  

public class SlingShot : MonoBehaviour
{
    public Transform pote;
    public GameObject bolinhaPrefab;
    public float for�aLan�amento = 10f;
    private Vector2 posi��oInicial;
    private bool est�Arrastando = false;
    private Rigidbody2D rb;
    private Camera cam;

    private int bolinhasLan�adas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        posi��oInicial = transform.position;
    }

    void Update()
    {
        if (est�Arrastando)
        {
            Vector2 posicaoMouse = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.ClampMagnitude(posicaoMouse - posi��oInicial, 2f) + posi��oInicial;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector2.Distance(cam.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1f)
            {
                est�Arrastando = true;
                rb.isKinematic = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (est�Arrastando)
            {
                est�Arrastando = false;
                rb.isKinematic = false;
                Lan�arBolinha();
            }
        }
    }

    void Lan�arBolinha()
    {
        Vector2 dire��o = posi��oInicial - (Vector2)transform.position;
        rb.AddForce(dire��o * for�aLan�amento, ForceMode2D.Impulse);
        bolinhasLan�adas++;
    }

    

   
    
}
