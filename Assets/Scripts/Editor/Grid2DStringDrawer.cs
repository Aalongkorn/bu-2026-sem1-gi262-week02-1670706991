using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Grid2DString))]
public class Grid2DStringDrawer : PropertyDrawer
{
    private const float LineHeight = 18f;
    private const float Spacing = 2f;
    private const float CellWidth = 32f;
    private const float CellHeight = 20f;
    private const float LabelIndent = 4f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty rowsProp = property.FindPropertyRelative("rows");
        SerializedProperty colsProp = property.FindPropertyRelative("cols");
        SerializedProperty dataProp = property.FindPropertyRelative("data");

        int rows = rowsProp.intValue;
        int cols = colsProp.intValue;

        float y = position.y;

        EditorGUI.LabelField(new Rect(position.x, y, position.width, LineHeight), label, EditorStyles.boldLabel);
        y += LineHeight + Spacing;

        EditorGUI.indentLevel++;
        float halfWidth = (position.width - LabelIndent) / 2f;
        Rect rowsRect = new Rect(position.x, y, halfWidth - 4f, LineHeight);
        Rect colsRect = new Rect(position.x + halfWidth + 4f, y, halfWidth - 4f, LineHeight);

        EditorGUI.BeginChangeCheck();
        int newRows = EditorGUI.IntField(rowsRect, "Rows", rows);
        int newCols = EditorGUI.IntField(colsRect, "Cols", cols);
        if (EditorGUI.EndChangeCheck())
        {
            newRows = Mathf.Max(1, newRows);
            newCols = Mathf.Max(1, newCols);
            if (newRows != rows || newCols != cols)
            {
                Grid2DString grid = GetTargetObject(property);
                grid.Resize(newRows, newCols);
                property.serializedObject.Update();
                rowsProp.intValue = grid.rows;
                colsProp.intValue = grid.cols;
                ResizeDataProperty(dataProp, grid.data);
                rows = grid.rows;
                cols = grid.cols;
            }
        }
        EditorGUI.indentLevel--;

        y += LineHeight + Spacing;

        if (dataProp.arraySize != rows * cols)
        {
            ResizeDataProperty(dataProp, new string[rows * cols]);
        }

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Rect cellRect = new Rect(
                    position.x + LabelIndent + c * (CellWidth + Spacing),
                    y + r * (CellHeight + Spacing),
                    CellWidth,
                    CellHeight);
                SerializedProperty elementProp = dataProp.GetArrayElementAtIndex(r * cols + c);
                elementProp.stringValue = EditorGUI.TextField(cellRect, elementProp.stringValue);
            }
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty rowsProp = property.FindPropertyRelative("rows");
        int rows = Mathf.Max(1, rowsProp.intValue);

        float height = (LineHeight + Spacing) * 2f;
        height += rows * (CellHeight + Spacing);
        return height;
    }

    private static void ResizeDataProperty(SerializedProperty dataProp, string[] values)
    {
        dataProp.arraySize = values.Length;
        for (int i = 0; i < values.Length; i++)
            dataProp.GetArrayElementAtIndex(i).stringValue = values[i] ?? "";
    }

    private static Grid2DString GetTargetObject(SerializedProperty property)
    {
        object obj = property.serializedObject.targetObject;
        string path = property.propertyPath.Replace(".Array.data[", "[");
        string[] elements = path.Split('.');
        foreach (string element in elements)
        {
            if (element.Contains("["))
            {
                string elementName = element.Substring(0, element.IndexOf("["));
                int index = System.Convert.ToInt32(element.Substring(element.IndexOf("[")).Replace("[", "").Replace("]", ""));
                obj = GetValue(obj, elementName, index);
            }
            else
            {
                obj = GetValue(obj, element);
            }
        }
        return obj as Grid2DString;
    }

    private static object GetValue(object source, string name)
    {
        if (source == null) return null;
        var type = source.GetType();
        var field = type.GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
        if (field == null)
        {
            var property = type.GetProperty(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            if (property == null) return null;
            return property.GetValue(source, null);
        }
        return field.GetValue(source);
    }

    private static object GetValue(object source, string name, int index)
    {
        var enumerable = GetValue(source, name) as System.Collections.IEnumerable;
        if (enumerable == null) return null;
        var enumerator = enumerable.GetEnumerator();
        for (int i = 0; i <= index; i++)
        {
            if (!enumerator.MoveNext()) return null;
        }
        return enumerator.Current;
    }
}
