using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class SpinningPlatform : MonoBehaviour
{

    [SerializeField] private float rotationSpeed = 1.0f;

    private float currentRotation = 0.0f;


    //update is called once per frame

    void Update()
    {
        currentRotation += rotationSpeed * Time.deltaTime;
       transform.rotation = Quaternion.Euler(0.0f, currentRotation , 0.0f);

    }


    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1.0f);
    }
}
