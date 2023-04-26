#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AI.GOAP.UnityEditor
{
    [CustomEditor(typeof(UnityGoalPlanner))]
    public sealed class GoalPlannerEditor : Editor
    {
        private UnityGoalPlanner planner;

        private void Awake()
        {
            this.planner = (UnityGoalPlanner) this.target;
        }

        public override void OnInspectorGUI()
        {
            if (EditorApplication.isPlaying)
            {
                this.DrawPlaymode();
            }
            else
            {
                base.OnInspectorGUI();
            }

            EditorGUILayout.Space(8.0f);
            if (GUILayout.Button("Debug Plan"))
            {
                this.DebugPlan();
            }
        }

        private void DrawPlaymode()
        {
            GUI.enabled = false;
            this.DrawGoals();
            this.DrawActions();
            GUI.enabled = true;
        }

        private void DrawGoals()
        {
            EditorGUILayout.Space(4.0f);
            EditorGUILayout.LabelField("Active Goals");
            var goals = this.planner.Editor_GetGoals()
                .OrderByDescending(it => it.IsValid() ? it.EvaluatePriority() : -1);

            foreach (var goal in goals)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(goal, typeof(UnityGoal), false);
                var isValid = goal.IsValid();
                if (isValid)
                {
                    EditorGUILayout.TextField("Priority: " + goal.EvaluatePriority());
                }
                else
                {
                    EditorGUILayout.TextField("Inactive");
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DrawActions()
        {
            EditorGUILayout.Space(4.0f);
            EditorGUILayout.LabelField("Active Actions");
            var actions = this.planner.Editor_GetActions()
                .OrderByDescending(it => it.IsValid() ? it.EvaluateCost() : -1);

            foreach (var action in actions)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(action, typeof(UnityAction), false);
                var isValid = action.IsValid();
                if (isValid)
                {
                    EditorGUILayout.TextField("Cost: " + action.EvaluateCost());
                }
                else
                {
                    EditorGUILayout.TextField("Inactive");
                }

                EditorGUILayout.EndHorizontal();
            }
        }

        private void DebugPlan()
        {
            if (this.planner.MakePlan(out var plan))
            {
                Debug.Log($"<color=#B1EEF1>Success {plan}</color>");
            }
            else
            {
                Debug.Log("<color=#B1EEF1>Fail</color>");
            }
        }
    }
}
#endif