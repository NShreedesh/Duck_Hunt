using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts
{
    public class GunController : MonoBehaviour
    {
        [Header("Scripts")]
        [SerializeField]
        private InputController inputController;
        [SerializeField]
        private CameraController cameraController;

        [Header("Shoot Values")]
        [SerializeField]
        private LayerMask shootHitLayerMask;

        [Header("Audio")]
        [SerializeField]
        private AudioClip shootAudioClip;

        private void OnEnable()
        {
            inputController.ShootInputAction.performed += OnShoot;
        }

        private void OnShoot(InputAction.CallbackContext obj)
        {
            RaycastHit2D hit = Physics2D.Raycast(cameraController.GetWorldMousePosition(), Vector3.zero, 100, shootHitLayerMask);
            SoundManager.Instance.PlaySFX(shootAudioClip);

            if (hit.transform == null) return;
        }

        private void OnDisable()
        {
            inputController.ShootInputAction.performed -= OnShoot;
        }
    }

}