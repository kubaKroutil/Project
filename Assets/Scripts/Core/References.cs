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
        #region BUTTONS
        [SerializeField]
        private string toggleInventoryButton;
        public static string ToggleInventoryButton;
        [SerializeField]
        private string toggleMenuButton;
        public static string ToggleMenuButton;
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
            ToggleInventoryButton = toggleInventoryButton;
            ToggleMenuButton = toggleMenuButton;
        }
        /// <summary>
        /// Compare given transform to player tag
        /// </summary>
        /// <param name="transformToCompare"></param>
        /// <returns></returns>
        public static bool CompareToPlayerTag(Transform transformToCompare)
        {
            return transformToCompare.CompareTag(References.PlayerTag);
        }
    }
}
