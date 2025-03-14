using UnityEngine;
using UnityEngine.SceneManagement;  

public class SlingShot : MonoBehaviour
{
    public Transform pote;
    public GameObject bolinhaPrefab;
    public float forçaLançamento = 10f;
    private Vector2 posiçãoInicial;
    private bool estáArrastando = false;
    private Rigidbody2D rb;
    private Camera cam;

    private int bolinhasLançadas = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        posiçãoInicial = transform.position;
    }

    void Update()
    {
        if (estáArrastando)
        {
            Vector2 posicaoMouse = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.ClampMagnitude(posicaoMouse - posiçãoInicial, 2f) + posiçãoInicial;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Vector2.Distance(cam.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1f)
            {
                estáArrastando = true;
                rb.isKinematic = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (estáArrastando)
            {
                estáArrastando = false;
                rb.isKinematic = false;
                LançarBolinha();
            }
        }
    }

    void LançarBolinha()
    {
        Vector2 direção = posiçãoInicial - (Vector2)transform.position;
        rb.AddForce(direção * forçaLançamento, ForceMode2D.Impulse);
        bolinhasLançadas++;
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
      
        if (colisao.CompareTag("Cup"))
        {
            Debug.Log("Bolinha entrou no copo!");
            CriarNovaBolinha();
        }

        if (bolinhasLançadas >= 3)
        {
            MudarDeCena();
        }
    }

    void CriarNovaBolinha()
    {
        
        Debug.Log("Criando uma nova bolinha");

      
        Instantiate(bolinhaPrefab, posiçãoInicial + new Vector2(1f, 0f), Quaternion.identity);
    }

    void MudarDeCena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, posiçãoInicial);
    }
}
