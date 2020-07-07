// TERMS AND DEFINITIONS
//   "wr" as a variable name stands for "Wrapper" and serves to give each GameObject's designated script a reference to the Wrapper class instance
//   "wrGo" as a variable name means "Wrapper GameObject", allows the other GameObjects to Get() various Components for the game
//   "Go(s)" at the end of a variable name means "GameObject(s)"
//   "Goi(s)" at the end of a variable name means "GameObject Instance(s)" and implies instantiation of a Prefab
//    - The original Prefab GameObject from which these instances are created is NOT included in a "Gois" array
//    - A list of Type <Class> where Class is one of the designated GameObject-specific scripts will usually contain INSTANTIATED prefabs.
//   "res" at the beginning of a variable name implies that it refers to something in the "Resources" folder
//   "sr" as a variable name refers to the SpriteRenderer component of an associated GameObject
//   "bc" as a variable name refers to the BoxCollider2D component of an associated GameObject

using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

// Instructions is a ScriptableSingleton so that it can be used as a common reference across Monobehaviours
// Member variables and functions must be STATIC for this reason
public class Instructions : ScriptableSingleton<Instructions>
{
    // F O R     W R A P P E R
    // GAMEOBJECT NAMES
    public static string mainCameraGoName = "MainCameraGO";
    public static string wrapperGoName = "WrapperGO";
    public static string keyboardInputGoName = "KeyboardInputGO";
    public static string mouseInputGoName = "MouseInputGO";
    public static string timerGoName = "TimerGO";
    public static string playerCharacterGoName = "PlayerCharacterGO";
    public static string npcPrefabGoName = "NPCPrefabGO";

    public static string selectorPrefabGoName = "SelectorPrefabGO";

    public static string sandboxPrefabGoName = "SandboxPrefabGO";

    public static string entityPrefabGoName = "EntityPrefabGO";

    // SPRITE FILE NAMES
    // Circles
    public static string resCircle16 = "Sprites/Shapes/circle-16";
    public static string resCircle32 = "Sprites/Shapes/circle-32";
    public static string resCircle48 = "Sprites/Shapes/circle-48";
    public static string resCircle64 = "Sprites/Shapes/circle-64";
    public static string resCircle96 = "Sprites/Shapes/circle-96";
    public static string resCircle128 = "Sprites/Shapes/circle-128";
    public static string resCircle192 = "Sprites/Shapes/circle-192";
    public static string resCircle256 = "Sprites/Shapes/circle-256";
    public static string resCircle384 = "Sprites/Shapes/circle-384";
    public static string resCircle512 = "Sprites/Shapes/circle-512";
    public static string resCircle768 = "Sprites/Shapes/circle-768";
    public static string resCircle1024 = "Sprites/Shapes/circle-1024";
    // Squares
    public static string resSquare16 = "Sprites/Shapes/rectangle-16-16";
    public static string resSquare32 = "Sprites/Shapes/rectangle-32-32";
    public static string resSquare48 = "Sprites/Shapes/rectangle-48-48";
    public static string resSquare64 = "Sprites/Shapes/rectangle-64-64";
    public static string resSquare96 = "Sprites/Shapes/rectangle-96-96";
    public static string resSquare128 = "Sprites/Shapes/rectangle-128-128";
    public static string resSquare192 = "Sprites/Shapes/rectangle-192-192";
    public static string resSquare256 = "Sprites/Shapes/rectangle-256-256";
    public static string resSquare384 = "Sprites/Shapes/rectangle-384-384";
    public static string resSquare512 = "Sprites/Shapes/rectangle-512-512";
    public static string resSquare768 = "Sprites/Shapes/rectangle-768-768";
    public static string resSquare1024 = "Sprites/Shapes/rectangle-1024-1024";
    // Square Borders
    public static string resBorder8Square128 = "Sprites/Borders/border-8-rectangle-128-128";

    // COLOR DEFINITIONS
    public static float defaultColorAlpha = 1f;
    public static Color colorRed = new Color(1f, 0f, 0f, defaultColorAlpha);
    public static Color colorGreen = new Color(0f, 1f, 0f, defaultColorAlpha);
    public static Color colorBlue = new Color(0f, 0f, 1f, defaultColorAlpha);
    public static Color colorCyan = new Color(0f, 1f, 1f, defaultColorAlpha);
    public static Color colorMagenta = new Color(1f, 0f, 1f, defaultColorAlpha);
    public static Color colorYellow = new Color(1f, 1f, 0f, defaultColorAlpha);
    public static Color colorBlack = new Color(0f, 0f, 0f, defaultColorAlpha);
    public static Color colorWhite = new Color(1f, 1f, 1f, defaultColorAlpha);
    public static Color[] colors = {colorBlue, colorCyan};

    // SORTING ORDERS
    // NOTE: "True default" Sorting Order value is 0
    public static int defaultSelectorSortingOrder = 10; // Should be higher than the SO of any selectable entity
    public static int defaultEntitySortingOrder = 1;

    // Maximum Instance Counts
    //  - Provide size Definitions for arrays designated to hold INSTANTIATED Prefabs ("goi-arrays") and their designated class script instances
    public static int maxNumNPCs = 10;
    public static int maxNumSelectors = 25;


    // Game Physical Properties
    public static int gridDimX = 20;
    public static int gridDimY = 20;


    // F O R     K E Y B O A R D     I N P U T
    public static KeyCode keyCameraZoomOut = KeyCode.Q;
    public static KeyCode keyCameraZoomIn = KeyCode.E;

    // F O R     C A M E R A
    public static float defaultCameraPositionZ = -10f;
    public static float defaultCameraMovementSpeed = 15f;
    public static float defaultCameraZoomOutRatio = 1.01f;
    public static float defaultCameraZoomInRatio = 0.99f;

    


    public Instructions()
    {

    }

    // "True Modulus" function for integer inputs
    public static int Mod(int a, int b)
    {
        return (b + (a % b)) % b;
    }

    // "True Modulus" function for floating point inputs

    public static float Mod(float a, float b)
    {
        return (b + (a % b)) % b;
    }

}
