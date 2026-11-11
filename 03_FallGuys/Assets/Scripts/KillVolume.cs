using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            PlayerController pc = other.gameObject.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.RespawnPlayer();
            }
        }
    }
}
