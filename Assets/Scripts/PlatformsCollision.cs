using UnityEngine;

public class PlatformsCollision : MonoBehaviour
{

    [SerializeField] private string playerTag = "Player";
    [SerializeField] private Transform platform;

    [SerializeField] private int speed = 6;

    CharacterController characterController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag.Equals(playerTag))
        {
            Debug.Log("Enter");
            characterController = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag))
        {
            Debug.Log("Stay");
            characterController.Move(new Vector3(0, 0, speed * Time.deltaTime * -1));
        }
    }
/*    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag))
        {
            Debug.Log("Exit");
            other.gameObject.transform.parent = null;
        }
    }*/

    /*    void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Enter");
            if (collision.gameObject.tag.Equals(playerTag))
            {
                collision.gameObject.transform.parent = platform;
            }
        }*/

/*    void OnCollisionExit(Collision collision)
    {

        Debug.Log("Exit");
        if (collision.gameObject.tag.Equals(playerTag))
        {
            collision.gameObject.transform.parent = null;
        }
    }*/

}
