using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Player
{
public class PlayerDetectItem : MonoBehaviour
{
        //[Tooltip("What layers is being used for items.")]
        //public LayerMask layerToDetect;
        //[Tooltip("what transform will the ray be fired from?")]
        //public Transform rayTransformPivot;
        //[Tooltip("the editor input button that will be used for picking items")]
        //public string buttonPickUp;

        //private Transform itemAvailableForPickup;
        //private RaycastHit hit;
        //private float detectRange = 3;
        //private float DetectRadius = 0.7f;
        //private bool itemInRange;

        //private float labelWidth = 200;
        //private float labelHeight = 50;

        //void OnEnable()
        //{

        //}

        //void OnDisable()
        //{

        //}

        //// Use this for initialization
        //void Start()
        //{

        //}

        //// Update is called once per frame
        //void Update()
        //{
        //    CastRayForDetectingItems();
        //    CheckForItemPickupAttempt();
        //}

        //void SetInitialReferences()
        //{

        //}

        //void CastRayForDetectingItems()
        //{
        //    if (Physics.SphereCast(rayTransformPivot.position, DetectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect))
        //    {
        //        itemAvailableForPickup = hit.transform;
        //        itemInRange = true;
        //    }
        //    else
        //    {
        //        itemInRange = false;
        //    }
        //}

        //void CheckForItemPickupAttempt()
        //{
        //    if (Input.GetButtonDown(buttonPickUp) && Time.timeScale > 0 && itemInRange 
        //        //&& itemAvailableForPickup.root.tag != GameManager_References._playerTag
        //        )
        //    {
        //        Debug.Log("Pickup attempted");
        //        //itemAvailableForPickup.GetComponent<item_Master> ().CallEventPickupAction (ray.TransformPivot);
        //    }
        //}

        //void OnGUI()
        //{
        //    if (itemInRange && itemAvailableForPickup != null)
        //    {
        //        GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, Screen.height / 2, labelWidth, labelHeight), itemAvailableForPickup.name);

        //    }
        //}
    }
}