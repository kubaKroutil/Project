using System.Collections;
using UnityEngine;

namespace Project.Player
{
public class PlayerHealthEffects : MonoBehaviour
{
        [SerializeField]
        private GameObject canvasHurt;
        [SerializeField]
        private GameObject canvasHeal;
        [SerializeField]
        private float secToHide = 2f;
        private PlayerController playerController;
        private void OnEnable()
        {
            Initialization();
            playerController.PlayerHealthDecreaseEvent += TurnOnHurtCanvas;
            playerController.PlayerHealthIncreaseEvent += TurnOnHealCanvas;
        }
        private void OnDisable()
        {
            playerController.PlayerHealthDecreaseEvent -= TurnOnHurtCanvas;
            playerController.PlayerHealthIncreaseEvent -= TurnOnHealCanvas;
        }
        private void TurnOnHurtCanvas(float dummy)
        {
            StopAllCoroutines();
            canvasHurt.SetActive(true);
            StartCoroutine(ResetGameObject(canvasHurt));
        }
        private void TurnOnHealCanvas(float dummy)
        {
            StopAllCoroutines();
            canvasHeal.SetActive(true);
            StartCoroutine(ResetGameObject(canvasHeal));
        }
        IEnumerator ResetGameObject(GameObject gameObject)
        {
            yield return new WaitForSeconds(secToHide);
            gameObject.SetActive(false);
        }

        private void Initialization()
        {
            playerController = transform.root.GetComponent<PlayerController>();
        }
    }
}