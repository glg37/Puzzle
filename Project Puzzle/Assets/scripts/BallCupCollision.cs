using UnityEngine;
using UnityEngine.SceneManagement;

public class BallCupCollision : MonoBehaviour
{
    public string nomeCena; 
    private int bolinhasTocando = 0; 

    
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Ball"))
        {
            bolinhasTocando++; 
            Debug.Log("Bolinha entrou no copo!  " + bolinhasTocando);

          
            if (bolinhasTocando == 1)
            {
                Debug.Log("Copo tem 1 bolinha! Trocar de cena...");
                SceneManager.LoadScene(nomeCena); 
            }
        }
    }
}
