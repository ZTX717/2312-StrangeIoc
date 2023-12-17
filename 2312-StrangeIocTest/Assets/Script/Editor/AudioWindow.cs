using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AudioWindow : EditorWindow
{
    [MenuItem("扩展/音频")]
    static void CreateWindow()
    {
        AudioWindow window = EditorWindow.GetWindow<AudioWindow>("扩展-音频");
        window.Show();
    }

    string AudioName;
    string AudioPath;
    private Dictionary<string, string> audioDic = new Dictionary<string, string>();
    private void Awake()
    {
        LoadAudioList();
    }
    private void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("名字");
        GUILayout.Label("路径");
        GUILayout.Label("删除");
        GUILayout.EndHorizontal();
        foreach (string key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key, out value);
            GUILayout.BeginHorizontal();
            GUILayout.Label(key);
            GUILayout.Label(value);
            if (GUILayout.Button("删除"))
            {
                audioDic.Remove(key);
                SaveAudioList();
                GUILayout.EndHorizontal();
                return;
            }
            GUILayout.EndHorizontal();
        }
        AudioName = EditorGUILayout.TextField("名字", AudioName);
        AudioPath = EditorGUILayout.TextField("路径", AudioPath);
        if (GUILayout.Button("添加音效"))
        {
            object o = Resources.Load(AudioPath);
            if (o == null)
            {
                Debug.LogWarning("音效不存在");
                AudioPath = "";
            }
            else if(AudioName == null)
            {
                Debug.LogWarning("请输入名字");
            }
            else if (audioDic.ContainsKey(AudioName))
            {
                Debug.LogWarning("已经存在相同名称");
            }
            else
            {
                audioDic.Add(AudioName, AudioPath);
                SaveAudioList();
            }
        }
    }

    private void SaveAudioList()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var key in audioDic.Keys)
        {
            string value;
            audioDic.TryGetValue(key, out value);
            sb.Append(key + "," + value + "\n");
        }
        File.WriteAllText(AudioManager.audioText, sb.ToString());
        //File.AppendAllText(savePath, sb.ToString());
    }
    private void LoadAudioList()
    {
        audioDic = new Dictionary<string, string>();
        if (File.Exists(AudioManager.audioText) == false) return;
        string[] list = File.ReadAllLines(AudioManager.audioText);
        foreach (string l in list)
        {
            if (string.IsNullOrEmpty(l))
                continue;
            string[] keyvale = l.Split(",");
            audioDic.Add(keyvale[0], keyvale[1]);
        }
    }
}
