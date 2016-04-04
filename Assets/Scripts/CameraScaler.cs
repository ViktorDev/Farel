using UnityEngine;
using System.Collections;

public class CameraScaler : MonoBehaviour {

    public float orthographicSize;
    public float aspect = 0.625f;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                Camera.main.nearClipPlane, Camera.main.farClipPlane);
    }
}
