using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameModel 
{
    public static bool IsPlay { get; set; }



    public static void Play()
    {
        IsPlay = false;
    }
    public static void Sotp()
    {
        IsPlay = true;
    }
}
