using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour
{

    public Texture2D cursorArrow;

    void Start()
    {
        Cursor.visible = false;
        Cursor.SetCursor(cursorArrow, Vector3.zero, CursorMode.ForceSoftware);
        Cursor.visible = true;
    }

}
