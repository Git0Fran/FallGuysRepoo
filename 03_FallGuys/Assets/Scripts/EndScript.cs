using UnityEngine;

public class EndScript : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.EndGame();
    }
}
