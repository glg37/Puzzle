using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneChanger : MonoBehaviour
{
    
    public void ChangeScene()
    {
        SceneManager.LoadScene("puzzle 1");
       
    }
    public void ChangeScene2()
    {
        SceneManager.LoadScene("puzzle 2");
    }
    public void ChangeScene3()
    {
        SceneManager.LoadScene("puzzle 3");
    }
}
