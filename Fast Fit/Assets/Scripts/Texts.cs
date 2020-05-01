using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Texts
{
    public static string Language = "en";

    public const string English = "en";
    public const string Portuguese = "pt";

    public static string TapTopPlay
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Toque para Jogar";
                case Texts.English:
                default:
                    return "Tap to Play";
            }
        }
    }
}
