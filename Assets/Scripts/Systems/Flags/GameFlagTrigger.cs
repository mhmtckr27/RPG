using System;
using UnityEngine;

namespace RPG
{
    public class GameFlagTrigger : MonoBehaviour
    {
        [SerializeField] private GameFlag flag;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
                return;

            flag.Set(true);
        }
    }
}