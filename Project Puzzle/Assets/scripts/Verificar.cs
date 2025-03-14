using UnityEngine;
using UnityEngine.UI;  // Para exibir a mensagem de vitória
using TMPro;
public class Verificar : MonoBehaviour
{
    public TextMeshProUGUI mensagemDeVitoria; // Para exibir a mensagem de vitória
    public int totalDeBolas = 3;   // Quantidade total de bolas vermelhas (RedBall) que precisam estar no pote

    // Função para verificar se todas as bolas estão no pote
    public void VerificarVitoria()
    {
        GameObject pote = GameObject.FindGameObjectWithTag("CupRed");  // Encontrar o pote pela tag
        if (pote == null)
        {
            Debug.LogError("Pote CupRed não encontrado!");
            return;
        }

        // Conta quantas bolas com a tag RedBall estão dentro do pote
        int bolasNoPote = 0;
        foreach (Transform objeto in pote.transform)  // Verifica todos os objetos dentro do pote
        {
            if (objeto.CompareTag("BallRed"))  // Se o objeto tiver a tag RedBall
            {
                bolasNoPote++;
            }
        }

        // Verifica se o número de bolas dentro do pote é igual ao número total esperado
        if (bolasNoPote == totalDeBolas)
        {
            mensagemDeVitoria.text = "Você venceu!";  // Exibe a mensagem de vitória
        }
        else
        {
            mensagemDeVitoria.text = "Ainda não venceu...";  // Se ainda não venceu
        }
    }
}
