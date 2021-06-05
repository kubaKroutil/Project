using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
    public class PlayerHurtCanvas : MonoBehaviour
    {
        public GameObject canvas;
        private PlayerController playerController;
        [SerializeField]
        private float SecToHide = 2f;
        private void OnEnable()
        {
            Initialization();
            playerController.PlayerHealthDecreaseEvent += TurnOnHurtEffect;
        }
        private void OnDisable()
        {
            playerController.PlayerHealthDecreaseEvent -= TurnOnHurtEffect;
        }
        private void TurnOnHurtEffect(int _Dummy)
        {
            StopAllCoroutines();
            canvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
        IEnumerator ResetHurtCanvas()
        {
            yield return new WaitForSeconds(SecToHide);
            canvas.SetActive(false);
        }

        private void Initialization()
        {
            this.playerController = this.transform.root.GetComponent<PlayerController>();
        }
    }
}