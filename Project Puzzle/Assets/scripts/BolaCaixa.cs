using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaCaixa : MonoBehaviour
{
    
    public string nomeDaCena = "puzzle 3";

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Caixa"))
        {

            SceneManager.LoadScene(nomeDaCena);
        }

    }
}
