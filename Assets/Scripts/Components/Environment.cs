using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Components
{
    public class Environment : MonoBehaviour
    {
        [SerializeField] private bool isAbleToRotate;
        [SerializeField] private Transform centerPivot;
        private const int RotationStep = 90;
        private void OnEnable()
        {
            if (isAbleToRotate == true)
            {
                if (centerPivot == null)
                {
                    throw new Exception("Center Pivot in " + this.gameObject.name + " is null");
                }
                centerPivot.rotation =  Quaternion.Euler(new Vector3(0, Random.Range(0, 3) * RotationStep, 0));
            }
        }
    }
}