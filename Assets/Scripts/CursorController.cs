using UnityEngine;

namespace Scripts
{
    public class CursorController : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField]
        private CameraController cameraController;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
        }

        private void Update()
        {
            transform.position = cameraController.GetWorldMousePosition();
        }
    }
}
