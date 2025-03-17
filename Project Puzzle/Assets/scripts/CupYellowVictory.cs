using System.Collections.Generic;
using UnityEngine;
using TMPro; // Para utilizar o TextMeshPro


public class CupYellowVictory : MonoBehaviour
{
    public string ballTag = "BallYellow"; // Tag das bolas
    public string cupTag = "CupYellow"; // Tag do copo
    public TextMeshProUGUI victoryText; // Texto de vitória a ser exibido

    private List<GameObject> ballsInCup = new List<GameObject>(); // Lista de bolas dentro do copo

    void Start()
    {
        victoryText.gameObject.SetActive(false); // Inicialmente, o texto de vitória não aparece
    }

    // Usando OnTriggerEnter2D para colisões com triggers
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsBall(collider.gameObject)) // Verifica se o objeto é uma bola
        {
            AddBallToCup(collider.gameObject);
            Debug.Log("Bola entrou no copo: " + collider.gameObject.name); // Depuração
        }
    }

    // Usando OnTriggerExit2D para quando a bola sair do copo
    void OnTriggerExit2D(Collider2D collider)
    {
        if (IsBall(collider.gameObject)) // Verifica se o objeto é uma bola
        {
            RemoveBallFromCup(collider.gameObject);
            Debug.Log("Bola saiu do copo: " + collider.gameObject.name); // Depuração
        }
    }

    void Update()
    {
        // Verifica se todas as bolas estão dentro do copo
        CheckAllBallsInCup();
    }

    private bool IsBall(GameObject other)
    {
        return other.CompareTag(ballTag); // Verifica se o objeto é uma bola
    }

    private void AddBallToCup(GameObject ball)
    {
        if (!ballsInCup.Contains(ball)) // Verifica se a bola não está na lista
        {
            ballsInCup.Add(ball);
            Debug.Log("Bola adicionada ao copo: " + ball.name); // Depuração
        }
    }

    private void RemoveBallFromCup(GameObject ball)
    {
        if (ballsInCup.Contains(ball)) // Verifica se a bola está na lista antes de remover
        {
            ballsInCup.Remove(ball);
            Debug.Log("Bola removida do copo: " + ball.name); // Depuração
        }
    }

    private void CheckAllBallsInCup()
    {
        GameObject[] allBalls = GameObject.FindGameObjectsWithTag(ballTag); // Pega todas as bolas no jogo
        Debug.Log("Número total de bolas na cena: " + allBalls.Length); // Depuração

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
        return ballsInCup.Count == allBalls.Length; // Verifica se todas as bolas estão no copo
    }

    private void ShowVictoryMessage()
    {
        victoryText.gameObject.SetActive(true); // Exibe o texto de vitória
        victoryText.text = "Vitória! Todas as bolas estão no copo!";
        Debug.Log("Mensagem de vitória exibida!"); // Depuração

        // Chama a coroutine para esconder a mensagem após 3 segundos
       
    }

    private void HideVictoryMessage()
    {
        victoryText.gameObject.SetActive(false); // Esconde o texto de vitória
        Debug.Log("Mensagem de vitória escondida!"); // Depuração
    }

    // Coroutine para esconder a mensagem após o tempo de espera
   
}
