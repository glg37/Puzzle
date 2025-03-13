using UnityEngine;
using UnityEngine.SceneManagement;  // Para carregar a pr�xima cena

public class SlingShot : MonoBehaviour
{
    public Transform pote;  // O pote para onde a bolinha ser� lan�ada
    public GameObject bolinhaPrefab;  // Prefab da bolinha para criar novas bolinhas
    public float for�aLan�amento = 10f;  // A for�a do lan�amento
    private Vector2 posi��oInicial;  // Posi��o inicial da bolinha
    private bool est�Arrastando = false;  // Se a bolinha est� sendo arrastada
    private Rigidbody2D rb;  // Refer�ncia ao Rigidbody2D da bolinha
    private Camera cam;  // Refer�ncia � c�mera para convers�o de coordenadas de tela para mundo

    private int bolinhasLan�adas = 0;  // Contador de bolinhas lan�adas

    void Start()
    {
        // Inicializa o Rigidbody2D e a c�mera
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        posi��oInicial = transform.position;  // Salva a posi��o inicial da bolinha
    }

    void Update()
    {
        if (est�Arrastando)
        {
            // Se estiver arrastando, calcula a posi��o do mouse ou toque no mundo
            Vector2 posicaoMouse = cam.ScreenToWorldPoint(Input.mousePosition);
            // Restringe a bolinha ao limite de onde ela pode ser arrastada
            transform.position = Vector2.ClampMagnitude(posicaoMouse - posi��oInicial, 2f) + posi��oInicial;
        }

        if (Input.GetMouseButtonDown(0))  // Quando o bot�o esquerdo do mouse for pressionado
        {
            // Verifica se o clique est� em cima da bolinha
            if (Vector2.Distance(cam.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1f)
            {
                est�Arrastando = true;
                rb.isKinematic = true;  // Desabilita a f�sica enquanto arrasta
            }
        }

        if (Input.GetMouseButtonUp(0))  // Quando o bot�o esquerdo do mouse for solto
        {
            if (est�Arrastando)
            {
                est�Arrastando = false;
                rb.isKinematic = false;  // Habilita a f�sica
                Lan�arBolinha();
            }
        }
    }

    void Lan�arBolinha()
    {
        // Calcula a dire��o do lan�amento
        Vector2 dire��o = posi��oInicial - (Vector2)transform.position;
        // Aplica a for�a no Rigidbody2D
        rb.AddForce(dire��o * for�aLan�amento, ForceMode2D.Impulse);
        bolinhasLan�adas++;  // Incrementa o contador de bolinhas lan�adas
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // Verifica se a bolinha caiu dentro do pote
        if (colisao.CompareTag("Cup"))
        {
            // Cria uma nova bolinha quando a anterior cair no pote
            CriarNovaBolinha();
        }

        // Se o jogador lan�ou 3 bolinhas, carrega a pr�xima cena
        if (bolinhasLan�adas >= 3)
        {
            MudarDeCena();
        }
    }

    void CriarNovaBolinha()
    {
        // Instancia a nova bolinha no mesmo lugar da bolinha anterior
        Instantiate(bolinhaPrefab, posi��oInicial, Quaternion.identity);
    }

    void MudarDeCena()
    {
        // Carrega a pr�xima cena (a cena seguinte no �ndice)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDrawGizmos()
    {
        // Desenha uma linha para visualizar a dire��o de lan�amento (para debugging)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, posi��oInicial);
    }
}
