using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarCena : MonoBehaviour
{
    public string nomeCena;

    private int bolinhasTocando = 0;

    private static int[] potesContagem = new int[4]; 

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.CompareTag("Ball"))
        {
            bolinhasTocando++;

            int poteIndex = GetPoteIndex();

            if (potesContagem[poteIndex] < 4)
            {
                potesContagem[poteIndex]++;
                Debug.Log("Pote " + poteIndex + " agora tem " + potesContagem[poteIndex] + " bolinhas.");
            }

            if (potesContagem[0] == 3 && potesContagem[1] == 3 && potesContagem[2] == 3)
            {
                Debug.Log("Todos os potes têm 3 bolinhas! Trocar de cena...");
                SceneManager.LoadScene("puzzle 2");
            }
        }
    }


    private int GetPoteIndex()
    {
        if (gameObject.CompareTag("CupBlue"))
        {
            return 0;
        }
        else if (gameObject.CompareTag("CupRed"))
        {
            return 1;
        }
        else if (gameObject.CompareTag("CupYellow"))
        {
            return 2;
        }
        else if (gameObject.CompareTag("CupGreen"))
        {
            return 3;
        }
        return -1;
    }
}