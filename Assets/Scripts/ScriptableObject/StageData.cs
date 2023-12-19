using UnityEngine;

public abstract class StageData : ScriptableObject
{
    public int StageNum;
    public GameObject MapObject;
    public AudioClip BackgroundMusic;
    public Material Skybox;
    public Color FogColor;
    public float FogDensity;
}