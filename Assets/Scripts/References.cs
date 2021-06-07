using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.General
{
    public class References : MonoBehaviour
    {
        [SerializeField]
        private string playerTag = "Player";
        public static string PlayerTag;
        
        [SerializeField]
        private string itemTag = "Item";
        public static string ItemTag;
        public static GameObject Player;

        // Start is called before the first frame update
        private void Awake()
        {
            if (playerTag == string.Empty)
            {
                Debug.LogError("PlayerTag not found! by References class, gameobject: " + this.gameObject.name);
            }
            else
            {
                PlayerTag = this.playerTag;
                Player = GameObject.FindGameObjectWithTag(PlayerTag);
            }
            ItemTag = this.itemTag;
        }
        /// <summary>
        /// Compare given tran
        /// </summary>
        /// <param name="transformToCompare"></param>
        /// <returns></returns>
        public static bool CompareToPlayerTag(Transform transformToCompare)
        {
            return transformToCompare.CompareTag(References.PlayerTag);
        }
    }
}
