using UnityEditor;
using UnityEngine;

public class LockableObject : MonoBehaviour
{
    // Flag to indicate whether the object is locked or not
    public bool isLocked = false;
}

[CustomEditor(typeof(LockableObject))]
public class LockableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LockableObject obj = (LockableObject)target;

        // Display a toggle to lock/unlock the object
        obj.isLocked = EditorGUILayout.Toggle("Lock", obj.isLocked);

        // If the object is locked, disable editing
        if (obj.isLocked)
        {
            EditorGUI.BeginDisabledGroup(true);
        }

        // Draw the default inspector GUI
        base.OnInspectorGUI();

        // If the object was locked, re-enable editing
        if (obj.isLocked)
        {
            EditorGUI.EndDisabledGroup();
        }
    }
}