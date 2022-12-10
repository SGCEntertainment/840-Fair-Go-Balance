using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _camera;

    private void Awake() => _camera = Camera.main;
    private void Start() => transform.position = new Vector2(0, 1.25f);
}
