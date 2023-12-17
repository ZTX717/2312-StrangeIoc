using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager
{

    //此处无法设置常量
    //Application.dataPath = 本地项目位置
    public static string audioText = Application.dataPath + "/Resources/audioList.txt";
    
    private string audioName = "audioList";

    public bool isMute = false;
    private Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();

    //public AudioManager()
    //{
    //    LoadAudioClip();
    //}

    public void Init()
    {
        LoadAudioClip();
    }

    private void LoadAudioClip()
    {
        audioClipDic = new Dictionary<string, AudioClip>();
        //使用这个方法加载数据，不能有后缀(.txt)
        TextAsset ta = Resources.Load<TextAsset>(audioName);
        string[] lines = ta.text.Split('\n');
        foreach (string line in lines)
        {
            if (string.IsNullOrEmpty(line)) continue;
            string[] keyvalue = line.Split(',');
            string key = keyvalue[0];
            AudioClip value = Resources.Load<AudioClip>(keyvalue[1]);
            audioClipDic.Add(key, value);
        }
    }

    public void Play(string name)
    {
        if (isMute) return;
        AudioClip ac;
        audioClipDic.TryGetValue(name, out ac);
        if (ac != null)
        {
            AudioSource.PlayClipAtPoint(ac, Vector3.zero,1);
        }
    }
}
