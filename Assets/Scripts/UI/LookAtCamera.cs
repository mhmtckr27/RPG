using System;
using UnityEngine;

namespace RPG.UI
{
    public class LookAtCamera : MonoBehaviour
    {
        private void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}