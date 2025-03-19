using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaCaixa : MonoBehaviour
{
    
    public string nomeDaCena = "puzzle 3";

    private void OnCollisionEnter(Collision colisao)
    {
        
        if (colisao.gameObject.CompareTag("Caixa"))
        {
           
            SceneManager.LoadScene(nomeDaCena);
        }
    }
}
