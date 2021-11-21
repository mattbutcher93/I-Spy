using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum Axis
    {
        y,
        x,
        z
    }
    public float speed = 1f;
    public Axis axis = Axis.y;

    private void Update()
    {
        transform.Rotate(VectorAxis(axis), speed * Time.deltaTime, Space.Self);
    }

    private Vector3 VectorAxis(Axis requiredAxis)
    {
        switch (requiredAxis)
        {
            case Axis.x:
                return Vector3.right;
            case Axis.y:
                return Vector3.up;
            case Axis.z:
                return Vector3.forward;
            default:
                return Vector3.up;
        }
    }
}
