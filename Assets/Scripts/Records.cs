using UnityEngine;
using UnityEngine.SceneManagement;

public class Records : MonoBehaviour
{
    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene("Menu");
    }
}
