using Gameplay.Archer.Aim;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay.Archer.Root
{
    public class ArrowPool : IInitializable, ILateDisposable
    {
        public static ArrowPool Instance { get; private set; }

        private Transform parent; 
        private Arrow prefab;

        private List<Arrow> arrows;
        private int startCount;

        public ArrowPool(Transform parent, Arrow prefab, int startCount)
        {
            this.parent = parent;
            this.prefab = prefab;
            this.startCount = startCount;

            arrows = new List<Arrow>(startCount);
        }

        public void Initialize()
        {
            for (int i = 0; i < startCount; i++)
            {
                var arrow = Object.Instantiate(prefab, parent);
                arrow.gameObject.SetActive(false);
                arrows.Add(arrow);
            }

            Instance = this;
        }

        public void LateDispose()
        {
            Instance = null;
        }

        public Arrow Create()
        {
            Arrow arrow;

            if (arrows.Count > 0)
            {
                arrow = arrows[0];
                arrows.RemoveAt(0);
                arrow.gameObject.SetActive(true);
            }
            else
            {
                arrow = GameObject.Instantiate(prefab, parent);
            }

            return arrow;
        }

        public void ReturnToPool(Arrow arrow)
        {
            arrow.gameObject.SetActive(false);
            arrows.Add(arrow);
        }
    }
}