using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("asdasdasd");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
       
    }
}
