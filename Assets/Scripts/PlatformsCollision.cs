using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformsCollision : MonoBehaviour
{

    [SerializeField] private string playerTag = "Player";
  
    [SerializeField] private Transform platform;

   private int speed = 10;

    CharacterController characterController;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals(playerTag))
        {
            characterController = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag))
        {
            characterController.Move(new Vector3(0, 0, speed * Time.deltaTime * -1));
        }
    }

}
