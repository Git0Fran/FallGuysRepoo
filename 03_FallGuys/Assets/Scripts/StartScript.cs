using UnityEngine;

public class StartScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.StartGame();
    }
}
