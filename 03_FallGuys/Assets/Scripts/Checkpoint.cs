using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Renderer meshRenderer = null;


    private void OnTriggerEnter(Collider other)
    {
        CheckpointManager.Instance.SetCheckpoint(this);
        GetComponent<Collider>().enabled = false;
        Vector3 pos = transform.position;
        pos.y -= 0.5f;
        transform.position = pos;
        meshRenderer.material.color = Color.red;

    }
}
