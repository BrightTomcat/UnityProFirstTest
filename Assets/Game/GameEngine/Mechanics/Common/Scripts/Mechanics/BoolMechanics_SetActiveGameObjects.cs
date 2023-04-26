using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class BoolMechanics_SetActiveGameObjects : BoolMechanics
    {
        [Space, SerializeField]
        public GameObject[] gameObjects;

        protected override void SetValue(bool isEnable)
        {
            for (int i = 0, count = this.gameObjects.Length; i < count; i++)
            {
                var gameObject = this.gameObjects[i];
                gameObject.SetActive(isEnable);
            }
        }
    }
}