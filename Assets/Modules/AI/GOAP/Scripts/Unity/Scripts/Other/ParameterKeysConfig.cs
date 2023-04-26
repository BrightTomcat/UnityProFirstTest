#if UNITY_EDITOR
using UnityEngine;

namespace AI.GOAP.UnityEditor
{
    [CreateAssetMenu(
        fileName = "ParameterKeyConfig",
        menuName = "AI/GOAP/ParameterKeyConfig"
    )]
    public sealed class ParameterKeysConfig : ScriptableObject
    {
        [SerializeField]
        private string[] names;

        private static ParameterKeysConfig instance;

        public static string[] GetKeys()
        {
            if (instance == null)
            {
                instance = Resources.Load<ParameterKeysConfig>("ParametersConfig");
            }

            return instance.names;
        }
    }
}
#endif