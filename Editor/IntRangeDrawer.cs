using UnityEditor;

using UnityEngine;

namespace Editor.Drawers
{
    [CustomPropertyDrawer(typeof(IntRange))]
    public class IntRangeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty minProp = property.FindPropertyRelative(nameof(IntRange.MinLimit));
            SerializedProperty maxProp = property.FindPropertyRelative(nameof(IntRange.MaxLimit));
            int minLimit = minProp.intValue;
            int maxLimit = maxProp.intValue;

            Rect labelRect = position;
            labelRect.width = EditorGUIUtility.labelWidth;

            Rect displayArea = position;
            displayArea.width -= labelRect.width;
            displayArea.x += labelRect.width;

            float textAreaWidth = 0.2f;
            Rect minLimitRect = displayArea;
            minLimitRect.width *= textAreaWidth;

            Rect sliderRect = displayArea;
            sliderRect.x += minLimitRect.width;
            sliderRect.width -= minLimitRect.width * 2;

            Rect maxLimitRect = minLimitRect;
            maxLimitRect.x += minLimitRect.width + sliderRect.width;

            //EditorGUI.DrawRect(displayArea, Color.red);
            //EditorGUI.DrawRect(minLimitRect, Color.blue);
            //EditorGUI.DrawRect(maxLimitRect, Color.cyan);

            object[] attrs = fieldInfo.GetCustomAttributes(false);
            foreach (object attr in attrs)
            {
                if (attr is IntRangeMinMax minMaxLimits)
                {
                    if (minMaxLimits.MinLimit.HasValue)
                    {
                        minLimit = minMaxLimits.MinLimit.Value;
                    }

                    if (minMaxLimits.MaxLimit.HasValue)
                    {
                        maxLimit = minMaxLimits.MaxLimit.Value;
                    }
                }
            }

            SerializedProperty lowerProp = property.FindPropertyRelative(nameof(IntRange.LowerValue));
            SerializedProperty upperProp = property.FindPropertyRelative(nameof(IntRange.UpperValue));
            float lowerVal = lowerProp.intValue;
            float upperVal = upperProp.intValue;

            //EditorGUI.MinMaxSlider(position, label, ref lowerValue, ref upperValue, minLimit, maxLimit);
            EditorGUI.MinMaxSlider(sliderRect, ref lowerVal, ref upperVal, minLimit, maxLimit);

            int lowerValue = (int)lowerVal;
            int upperValue = (int)upperVal;

            EditorGUI.LabelField(labelRect, label);

            lowerValue = EditorGUI.IntField(minLimitRect, lowerValue);
            upperValue = EditorGUI.IntField(maxLimitRect, upperValue);

            lowerProp.intValue = Mathf.Max(minLimit, lowerValue);
            upperProp.intValue = Mathf.Min(maxLimit, upperValue);
        }
    }
}