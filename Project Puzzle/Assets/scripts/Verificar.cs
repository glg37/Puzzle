using UnityEngine;
using UnityEngine.UI;  // Para exibir a mensagem de vit�ria
using TMPro;
public class Verificar : MonoBehaviour
{
    public TextMeshProUGUI mensagemDeVitoria; // Para exibir a mensagem de vit�ria
    public int totalDeBolas = 3;   // Quantidade total de bolas vermelhas (RedBall) que precisam estar no pote

    // Fun��o para verificar se todas as bolas est�o no pote
    public void VerificarVitoria()
    {
        GameObject pote = GameObject.FindGameObjectWithTag("CupRed");  // Encontrar o pote pela tag
        if (pote == null)
        {
            Debug.LogError("Pote CupRed n�o encontrado!");
            return;
        }

        // Conta quantas bolas com a tag RedBall est�o dentro do pote
        int bolasNoPote = 0;
        foreach (Transform objeto in pote.transform)  // Verifica todos os objetos dentro do pote
        {
            if (objeto.CompareTag("BallRed"))  // Se o objeto tiver a tag RedBall
            {
                bolasNoPote++;
            }
        }

        // Verifica se o n�mero de bolas dentro do pote � igual ao n�mero total esperado
        if (bolasNoPote == totalDeBolas)
        {
            mensagemDeVitoria.text = "Voc� venceu!";  // Exibe a mensagem de vit�ria
        }
        else
        {
            mensagemDeVitoria.text = "Ainda n�o venceu...";  // Se ainda n�o venceu
        }
    }
}
