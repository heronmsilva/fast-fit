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

    public static string Records
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Recordes";
                case Texts.English:
                default:
                    return "Records";
            }
        }
    }

    public static string TopScore
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Melhor Pontuação";
                case Texts.English:
                default:
                    return "Top Score";
            }
        }
    }

    public static string LongestRun
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Corrida Mais Longa";
                case Texts.English:
                default:
                    return "Longest Run";
            }
        }
    }

    public static string TopFitsInARun
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Quantidade de Acertos";
                case Texts.English:
                default:
                    return "Top Fits in a Run";
            }
        }
    }

    public static string TopStreak
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Melhor Sequência";
                case Texts.English:
                default:
                    return "Top Streak";
            }
        }
    }

    public static string Runs
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Corridas";
                case Texts.English:
                default:
                    return "Runs";
            }
        }
    }
}
