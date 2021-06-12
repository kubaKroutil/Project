using UnityEngine;

namespace Project.Core
{
    public class References : MonoBehaviour
    {
        #region TAGS
        [SerializeField]
        private string playerTag = "Player";
        public static string PlayerTag;
        [SerializeField]
        private string itemTag = "Item";
        public static string ItemTag;
        #endregion
        #region INSTANCES
        [SerializeField]
        private GameObject player;
        public static GameObject Player;
        #endregion
        private void Awake()
        {
            SetReferences();
        }
        private void SetReferences()
        {
            PlayerTag = playerTag;
            ItemTag = itemTag;
            Player = player;
        }
    }
}
