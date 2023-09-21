using System.Collections;
using UnityEngine;

namespace Scripts
{
    public class BirdSpawner : MonoBehaviour
    {
        [Header("Bird")]
        [SerializeField]
        private BirdController birdControllerPrefab;

        [Header("Bird Spawn Position Values")]
        [SerializeField]
        private float xMinSpawnPosition = -1f;
        [SerializeField]
        private float xMaxSpawnPosition = 1f;
        [SerializeField]
        private float ySpawnPosition = -0.5f;

        [Header("Bird Spawn Delay Values")]
        [SerializeField]
        private float timeToWaitforRandomSpawn = 1f;
        private WaitForSeconds _waitForRandomSpawnTime;

        private void Start()
        {
            _waitForRandomSpawnTime = new WaitForSeconds(timeToWaitforRandomSpawn);
            BirdController.OnBirdShot += RandomSpawn;
        }

        private void RandomSpawn()
        {
            StartCoroutine(RandomSpawnCoroutine());
        }

        private IEnumerator RandomSpawnCoroutine()
        {
            yield return _waitForRandomSpawnTime;
            float xPosition = Random.Range(xMinSpawnPosition, xMaxSpawnPosition);
            Spawn(new Vector2(xPosition, ySpawnPosition));
        }

        public void Spawn(Vector2 spawnPosition)
        {
            if (GameManager.Instance.NumberOfBirdsSpawned > 2) return;

            GameManager.Instance.IncrementNumberOfBirdSpawned();
            BirdController birdController = Instantiate(birdControllerPrefab, spawnPosition, Quaternion.identity);
            birdController.transform.parent = transform;
        }

        private void OnDisable()
        {
            BirdController.OnBirdShot -= RandomSpawn;
            StopAllCoroutines();
        }
    }
}
