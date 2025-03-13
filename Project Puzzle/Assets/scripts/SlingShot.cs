using UnityEngine;
using UnityEngine.SceneManagement;  // Para carregar a próxima cena

public class SlingShot : MonoBehaviour
{
    public Transform pote;  // O pote para onde a bolinha será lançada
    public GameObject bolinhaPrefab;  // Prefab da bolinha para criar novas bolinhas
    public float forçaLançamento = 10f;  // A força do lançamento
    private Vector2 posiçãoInicial;  // Posição inicial da bolinha
    private bool estáArrastando = false;  // Se a bolinha está sendo arrastada
    private Rigidbody2D rb;  // Referência ao Rigidbody2D da bolinha
    private Camera cam;  // Referência à câmera para conversão de coordenadas de tela para mundo

    private int bolinhasLançadas = 0;  // Contador de bolinhas lançadas

    void Start()
    {
        // Inicializa o Rigidbody2D e a câmera
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        posiçãoInicial = transform.position;  // Salva a posição inicial da bolinha
    }

    void Update()
    {
        if (estáArrastando)
        {
            // Se estiver arrastando, calcula a posição do mouse ou toque no mundo
            Vector2 posicaoMouse = cam.ScreenToWorldPoint(Input.mousePosition);
            // Restringe a bolinha ao limite de onde ela pode ser arrastada
            transform.position = Vector2.ClampMagnitude(posicaoMouse - posiçãoInicial, 2f) + posiçãoInicial;
        }

        if (Input.GetMouseButtonDown(0))  // Quando o botão esquerdo do mouse for pressionado
        {
            // Verifica se o clique está em cima da bolinha
            if (Vector2.Distance(cam.ScreenToWorldPoint(Input.mousePosition), transform.position) < 1f)
            {
                estáArrastando = true;
                rb.isKinematic = true;  // Desabilita a física enquanto arrasta
            }
        }

        if (Input.GetMouseButtonUp(0))  // Quando o botão esquerdo do mouse for solto
        {
            if (estáArrastando)
            {
                estáArrastando = false;
                rb.isKinematic = false;  // Habilita a física
                LançarBolinha();
            }
        }
    }

    void LançarBolinha()
    {
        // Calcula a direção do lançamento
        Vector2 direção = posiçãoInicial - (Vector2)transform.position;
        // Aplica a força no Rigidbody2D
        rb.AddForce(direção * forçaLançamento, ForceMode2D.Impulse);
        bolinhasLançadas++;  // Incrementa o contador de bolinhas lançadas
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        // Verifica se a bolinha caiu dentro do pote
        if (colisao.CompareTag("Cup"))
        {
            // Cria uma nova bolinha quando a anterior cair no pote
            CriarNovaBolinha();
        }

        // Se o jogador lançou 3 bolinhas, carrega a próxima cena
        if (bolinhasLançadas >= 3)
        {
            MudarDeCena();
        }
    }

    void CriarNovaBolinha()
    {
        // Instancia a nova bolinha no mesmo lugar da bolinha anterior
        Instantiate(bolinhaPrefab, posiçãoInicial, Quaternion.identity);
    }

    void MudarDeCena()
    {
        // Carrega a próxima cena (a cena seguinte no índice)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnDrawGizmos()
    {
        // Desenha uma linha para visualizar a direção de lançamento (para debugging)
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, posiçãoInicial);
    }
}
