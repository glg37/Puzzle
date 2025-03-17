using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para utilizar o TextMeshPro


public class CupYellowVictory : MonoBehaviour
{
    public string ballTag = "BallYellow"; // Tag das bolas
    public string cupTag = "CupYellow"; // Tag do copo
    public TextMeshProUGUI victoryText; // Texto de vit�ria a ser exibido

    private List<GameObject> ballsInCup = new List<GameObject>(); // Lista de bolas dentro do copo

    void Start()
    {
        victoryText.gameObject.SetActive(false); // Inicialmente, o texto de vit�ria n�o aparece
    }

    // Usando OnTriggerEnter2D para colis�es com triggers
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsBall(collider.gameObject)) // Verifica se o objeto � uma bola
        {
            AddBallToCup(collider.gameObject);
            Debug.Log("Bola entrou no copo: " + collider.gameObject.name); // Depura��o
        }
    }

    // Usando OnTriggerExit2D para quando a bola sair do copo
    void OnTriggerExit2D(Collider2D collider)
    {
        if (IsBall(collider.gameObject)) // Verifica se o objeto � uma bola
        {
            RemoveBallFromCup(collider.gameObject);
            Debug.Log("Bola saiu do copo: " + collider.gameObject.name); // Depura��o
        }
    }

    void Update()
    {
        // Verifica se todas as bolas est�o dentro do copo
        CheckAllBallsInCup();
    }

    private bool IsBall(GameObject other)
    {
        return other.CompareTag(ballTag); // Verifica se o objeto � uma bola
    }

    private void AddBallToCup(GameObject ball)
    {
        if (!ballsInCup.Contains(ball)) // Verifica se a bola n�o est� na lista
        {
            ballsInCup.Add(ball);
            Debug.Log("Bola adicionada ao copo: " + ball.name); // Depura��o
        }
    }

    private void RemoveBallFromCup(GameObject ball)
    {
        if (ballsInCup.Contains(ball)) // Verifica se a bola est� na lista antes de remover
        {
            ballsInCup.Remove(ball);
            Debug.Log("Bola removida do copo: " + ball.name); // Depura��o
        }
    }

    private void CheckAllBallsInCup()
    {
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag(ballTag); // Pega todas as bolas no jogo
        Debug.Log("N�mero total de bolas na cena: " + allBalls.Length); // Depura��o

        if (AllBallsInCup(allBalls))
        {
            ShowVictoryMessage();
        }
        else
        {
            HideVictoryMessage();
        }
    }

    private bool AllBallsInCup(GameObject[] allBalls)
    {
        return ballsInCup.Count == allBalls.Length; // Verifica se todas as bolas est�o no copo
    }

    private void ShowVictoryMessage()
    {
        victoryText.gameObject.SetActive(true); // Exibe o texto de vit�ria
        victoryText.text = "Vit�ria! Todas as bolas est�o no copo!";
        Debug.Log("Mensagem de vit�ria exibida!"); // Depura��o

        // Chama a coroutine para esconder a mensagem ap�s 3 segundos
       
    }

    private void HideVictoryMessage()
    {
        victoryText.gameObject.SetActive(false); // Esconde o texto de vit�ria
        Debug.Log("Mensagem de vit�ria escondida!"); // Depura��o
    }

    // Coroutine para esconder a mensagem ap�s o tempo de espera
   
}
