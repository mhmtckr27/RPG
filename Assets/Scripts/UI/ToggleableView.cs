using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class ToggleableView : MonoBehaviour
    {
        private static HashSet<ToggleableView> _visibleViews = new();

        public static bool IsVisible() => _visibleViews.Count > 0;

        protected virtual void Awake()
        {
            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _visibleViews.Add(this);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _visibleViews.Remove(this);
        }
    }
}