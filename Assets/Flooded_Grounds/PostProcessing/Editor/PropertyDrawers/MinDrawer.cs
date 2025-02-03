using UnityEngine;
using UnityEditor;

namespace UnityEditor.PostProcessing
{
    [CustomPropertyDrawer(typeof(MinAttribute))]
    sealed class MinDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Use UnityEngine.MinAttribute if available in your version
            var minAttribute = (MinAttribute)attribute;

            if (property.propertyType == SerializedPropertyType.Integer)
            {
                int v = EditorGUI.IntField(position, label, property.intValue);
                property.intValue = (int)Mathf.Max(v, minAttribute.min);
            }
            else if (property.propertyType == SerializedPropertyType.Float)
            {
                float v = EditorGUI.FloatField(position, label, property.floatValue);
                property.floatValue = Mathf.Max(v, minAttribute.min);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use Min with float or int.");
            }
        }
    }
}
