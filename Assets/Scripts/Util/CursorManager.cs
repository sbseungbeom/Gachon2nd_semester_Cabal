using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance { get; private set; }

    private Dictionary<string, CursorInfo> _sceneDependCursors = new();

    [SerializeField] private CursorInfo _defaultCursor;
    [SerializeField] private CursorInfo[] _cursors;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach(var cursorInfo in _cursors)
        {
            foreach(var key in cursorInfo.AvaliableScenes)
            {
                _sceneDependCursors[key] = cursorInfo;
            }
        }
    }

    private void Update()
    {
        if (!_sceneDependCursors.TryGetValue(
            SceneManager.GetActiveScene().name, 
            out CursorInfo cursor))
        {
            cursor = _defaultCursor;
        }

        SetCursor(Input.GetMouseButton(0) ? cursor.ClickedCursor : cursor.Cursor, cursor.Hotspot);
    }

    public void SetCursor(Texture2D cursor, Vector2 hotspot)
    {
        Cursor.SetCursor(cursor, hotspot, CursorMode.ForceSoftware);
    }
}

[Serializable]
public class CursorInfo
{
    public string[] AvaliableScenes;
    public Texture2D Cursor;
    public Texture2D ClickedCursor;
    public Vector2 Hotspot;
}
