using UnityEngine;

public abstract class TankMovement : MonoBehaviour
{
    private const int Speed = 3;

    protected void MoveHorizontal(float movementHorizontal)
    {
        Quaternion rotation;
        
        if (movementHorizontal < 0)
        {
            rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.left * (Speed * Time.deltaTime);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * (Speed * Time.deltaTime);
        }
        transform.rotation = rotation;
    }
    
    protected void MoveVertical(float movementVertical)
    {
        Quaternion rotation;
        
        if (movementVertical < 0)
        {
            rotation = Quaternion.Euler(0, 0, 270);
            transform.position += Vector3.down * (Speed * Time.deltaTime);
        }
        else
        {
            rotation = Quaternion.Euler(0, 0, 90);
            transform.position += Vector3.up * (Speed * Time.deltaTime);
        }
        transform.rotation = rotation;
    }
}