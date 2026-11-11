using UnityEngine;

public class PlatformConnect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other!= null && other.gameObject!= null)
        {
            other.transform.parent = transform.parent;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject != null)
        {
            other.transform.parent = null;
        }
    }

}
