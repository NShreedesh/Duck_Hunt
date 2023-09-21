using Scripts.Enums;
using System.Collections;
using UnityEditor.Overlays;
using UnityEngine;

namespace Scripts
{
    public class DogController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField]
        private Animator anim;

        [Header("Scripts")]
        [SerializeField]
        private BirdSpawner birdSpawnner;

        [Header("Dog")]
        [SerializeField]
        private float dogIntroAnimationLength = 2.30f;
        [SerializeField]
        private Vector2 firstBirdSpawnPosition;
        private WaitForSeconds _waitForDogIntroAnimationCompletion;

        private void Awake()
        {
            _waitForDogIntroAnimationCompletion = new WaitForSeconds(dogIntroAnimationLength);
        }

        private void Start()
        {
            StartCoroutine(DogAnimationIntroCompletion());

            BirdController.OnBirdDeadAction += PlayDogCaughtOneDuckAnimation;
        }

        private IEnumerator DogAnimationIntroCompletion()
        {
            yield return _waitForDogIntroAnimationCompletion;
            GameManager.Instance.SetGameState(GameState.Play);
            birdSpawnner.Spawn(firstBirdSpawnPosition);
        }

        private void PlayDogCaughtOneDuckAnimation(float dogXPosition)
        {
            GameManager.Instance.SetGameState(GameState.Pause);
            transform.position = new Vector2(dogXPosition, transform.position.y);
            anim.Play(DogConstants.OneDuckCaught);
            GameManager.Instance.SetGameState(GameState.Play);
        }

        private void OnDisable()
        {
            BirdController.OnBirdDeadAction -= PlayDogCaughtOneDuckAnimation;
            StopAllCoroutines();
        }
    }
}
