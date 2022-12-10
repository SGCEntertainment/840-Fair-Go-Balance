using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
}
