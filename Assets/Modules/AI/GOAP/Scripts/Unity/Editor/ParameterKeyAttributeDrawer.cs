#if UNITY_EDITOR
using System;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities;
using Sirenix.Utilities.Editor;
using UnityEditor;
using UnityEngine;

namespace AI.GOAP.UnityEditor
{
    public sealed class ParameterKeyAttributeDrawer : OdinAttributeDrawer<ParameterKeyAttribute, string>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            var rect = EditorGUILayout.GetControlRect();
            GUIHelper.PushLabelWidth(GUIHelper.BetterLabelWidth);
            var nameRect = rect.AlignLeft(rect.width * 0.9f);

            var name = this.ValueEntry.SmartValue;
            var names = ParameterKeysConfig.GetKeys();

            if (string.IsNullOrEmpty(name))
            {
                var currentIndex = 0;
                currentIndex = EditorGUI.Popup(nameRect, currentIndex, names);
                this.ValueEntry.SmartValue = names[currentIndex];
            }
            else if (Array.Exists(names, it => it == name))
            {
                var currentIndex = Array.IndexOf(names, name);
                currentIndex = EditorGUI.Popup(nameRect, currentIndex, names);
                this.ValueEntry.SmartValue = names[currentIndex];
            }
            else
            {
                this.ValueEntry.SmartValue = EditorGUI.TextField(nameRect, name);
            }
            
            GUIHelper.PopLabelWidth();
        }
    }
}
#endif