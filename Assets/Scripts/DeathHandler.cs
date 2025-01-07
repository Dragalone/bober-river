using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void OnTriggerEnter(Collider other)
    {
        Score.score = int.Parse(scoreText.text);
        SceneManager.LoadScene("EnterUserName"); 
    }
}
