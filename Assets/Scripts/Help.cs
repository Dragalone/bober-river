using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
