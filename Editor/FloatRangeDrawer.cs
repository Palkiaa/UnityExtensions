using UnityEditor;

using UnityEngine;

namespace Editor.Drawers
{
    [CustomPropertyDrawer(typeof(FloatRange))]
    public class FloatRangeDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty minProp = property.FindPropertyRelative(nameof(FloatRange.MinLimit));
            SerializedProperty maxProp = property.FindPropertyRelative(nameof(FloatRange.MaxLimit));
            float minLimit = minProp.floatValue;
            float maxLimit = maxProp.floatValue;

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
                if (attr is FloatRangeMinMax minMaxLimits)
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

            SerializedProperty lowerProp = property.FindPropertyRelative(nameof(FloatRange.LowerValue));
            SerializedProperty upperProp = property.FindPropertyRelative(nameof(FloatRange.UpperValue));
            float lowerValue = lowerProp.floatValue;
            float upperValue = upperProp.floatValue;

            //EditorGUI.MinMaxSlider(position, label, ref lowerValue, ref upperValue, minLimit, maxLimit);
            EditorGUI.MinMaxSlider(sliderRect, ref lowerValue, ref upperValue, minLimit, maxLimit);

            EditorGUI.LabelField(labelRect, label);

            lowerValue = EditorGUI.FloatField(minLimitRect, lowerValue);
            upperValue = EditorGUI.FloatField(maxLimitRect, upperValue);

            lowerProp.floatValue = Mathf.Max(minLimit, lowerValue);
            upperProp.floatValue = Mathf.Min(maxLimit, upperValue);
        }
    }
}