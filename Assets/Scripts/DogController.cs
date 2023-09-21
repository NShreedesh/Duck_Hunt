using Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class DogController : MonoBehaviour
    {
        [Header("Dog")]
        [SerializeField]
        private float dogIntroAnimationLength = 2.30f;
        private WaitForSeconds _waitForDogIntroAnimationCompletion;

        private void Awake()
        {
            _waitForDogIntroAnimationCompletion = new WaitForSeconds(dogIntroAnimationLength);
        }

        private void Start()
        {
            StartCoroutine(DogAnimationIntroCompletion());
        }

        private IEnumerator DogAnimationIntroCompletion()
        {
            yield return _waitForDogIntroAnimationCompletion;
            GameManager.Instance.SetGameState(GameState.Play);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
