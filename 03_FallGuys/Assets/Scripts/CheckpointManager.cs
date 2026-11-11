using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint lastSavedCheckpoint = null;
    static CheckpointManager instance = null;

    public static CheckpointManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint (Checkpoint chekpoint)
    {  lastSavedCheckpoint = chekpoint; }


    public bool TryGetRespawnLocation(out Vector3 pos)
    {
        pos = Vector3.zero;
        if(lastSavedCheckpoint != null)
        {
            pos = lastSavedCheckpoint.transform.position;
            return true;
        }
        return false;
    }
}
