using UnityEngine;

public class PlatformDestroyer : MonoBehaviour

{
    [SerializeField] private string playerTag = "Player";
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(playerTag))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
