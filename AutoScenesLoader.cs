using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[InitializeOnLoad]
public class AutoScenesLoader
{
    private static string[] scenes = { "Systems", "UI" };
    private static string scenePath = "Assets/Scenes";
    static AutoScenesLoader()
    {
        EditorSceneManager.newSceneCreated += LoadScenesToNewScene;
        EditorSceneManager.sceneOpened += LoadSceneToOpenScene;
    }

    private static void LoadSceneToOpenScene(Scene scene, OpenSceneMode mode)
    {
        LoadScenes();
    }

    private static void LoadScenesToNewScene(Scene scene, NewSceneSetup setup, NewSceneMode mode)
    {
        LoadScenes();
    }

    private static List<string> GetLoadedScenes()
    {
        List<string> loadedScenes = new List<string>();
        for (int i = 0; i < SceneManager.loadedSceneCount; i++)
        {
            loadedScenes.Add(SceneManager.GetSceneAt(i).name);
        }
        return loadedScenes;
    }

    private static void LoadScenes()
    {
        List<string> loadedscenes = GetLoadedScenes();
        foreach (string name in scenes)
        {
            if (!loadedscenes.Contains(name))
            {
                AddScene(name);
            }
        }
    }

    private static void AddScene(string name)
    {
        string path = $"{scenePath}/{name}.unity";
        EditorSceneManager.OpenScene(path, OpenSceneMode.Additive);
    }
}

