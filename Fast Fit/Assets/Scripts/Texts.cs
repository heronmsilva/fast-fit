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

    public static string TopStreak
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Sequência";
                case Texts.English:
                default:
                    return "Streak";
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

    public static string Controls
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Controles";
                case Texts.English:
                default:
                    return "Controls";
            }
        }
    }

    public static string MoveInfo
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Toque na tela, segure e arraste para mover a peça";
                case Texts.English:
                default:
                    return "Tap the screen, hold and move to move the piece";
            }
        }
    }

    public static string FastForwardInfo
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Toque duas vezes na tela para Avançar";
                case Texts.English:
                default:
                    return "Double tap the screen to Fast Forward";
            }
        }
    }

    public static string RotateLeft
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Gira para Esquerda";
                case Texts.English:
                default:
                    return "Rotate Left";
            }
        }
    }

    public static string RotateRight
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Gira para Direita";
                case Texts.English:
                default:
                    return "Rotate Right";
            }
        }
    }

    public static string FlipHorizontally
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Vira Horizontalmente";
                case Texts.English:
                default:
                    return "Flip Horizontally";
            }
        }
    }

    public static string FlipVertically
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Vira Verticalmente";
                case Texts.English:
                default:
                    return "Flip Vertically";
            }
        }
    }

    public static string Settings
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Configurações";
                case Texts.English:
                default:
                    return "Settings";
            }
        }
    }

    public static string Graphics
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Gráficos";
                case Texts.English:
                default:
                    return "Graphics";
            }
        }
    }

    public static string Music
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Música";
                case Texts.English:
                default:
                    return "Music";
            }
        }
    }

    public static string SoundEffects
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Efeitos Sonoros";
                case Texts.English:
                default:
                    return "Sound Effects";
            }
        }
    }

    public static string GamePaused
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Jogo Pausado";
                case Texts.English:
                default:
                    return "Game Paused";
            }
        }
    }

    public static string Resume
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Despausar";
                case Texts.English:
                default:
                    return "Resume";
            }
        }
    }

    public static string Finish
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Finalizar";
                case Texts.English:
                default:
                    return "Finish";
            }
        }
    }

    public static string Continue
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Continuar";
                case Texts.English:
                default:
                    return "Continue";
            }
        }
    }

    public static string WatchAd
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Assitir";
                case Texts.English:
                default:
                    return "Watch Ad";
            }
        }
    }

    public static string Time
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Tempo";
                case Texts.English:
                default:
                    return "Time";
            }
        }
    }

    public static string Score
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Pontuação";
                case Texts.English:
                default:
                    return "Score";
            }
        }
    }

    public static string Fits
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Acertos";
                case Texts.English:
                default:
                    return "Fits";
            }
        }
    }

    public static string NewRecord
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Novo Recorde";
                case Texts.English:
                default:
                    return "New Record";
            }
        }
    }

    public static string Record
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Recorde";
                case Texts.English:
                default:
                    return "Record";
            }
        }
    }

    public static string TryAgain
    {
        get 
        {
            switch (Texts.Language)
            {
                case Texts.Portuguese:
                    return "Tentar Novamente";
                case Texts.English:
                default:
                    return "Try Again";
            }
        }
    }
}
