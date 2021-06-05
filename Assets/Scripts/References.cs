using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    public class References : MonoBehaviour
    {
        public string PlayerTag;
        public static string _PlayerTag;

        public string EnemyTag;
        public static string _EnemyTag;

        public GameObject Player;

        // Start is called before the first frame update
        private void OnEnable()
        {
            if (PlayerTag == string.Empty)
            {
                Debug.LogError("PlayerTag not found! by References class, gameobject: " + this.gameObject.name);
            }
            else
            {
                _PlayerTag = PlayerTag;
                Player = GameObject.FindGameObjectWithTag(_PlayerTag);
            }
        }
    }
}
