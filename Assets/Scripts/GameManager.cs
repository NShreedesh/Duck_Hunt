using Scripts.Enums;
using UnityEngine;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [field: Header("Game Settings")]
        [field: SerializeField]
        public GameState GameState { get; private set; }

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(Instance);
        }

        public void SetGameState(GameState state)
        {
            GameState = state;
        }
    }
}
