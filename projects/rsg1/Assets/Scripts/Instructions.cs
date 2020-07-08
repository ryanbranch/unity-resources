// TODO:
// ================================
//  - S: Look into ScriptableSingleton alternatives which would allow the use of FOR LOOPS
//       for defining the values of more "advanced" Instructions member variables
//         e.g. "Translucent" and "Light" colors
// ================================
//  - A: Placeholder
//  - B: Stop using "Bc"-based naming convention when not all colliders are Boxes
//      1. More significantly, figure out a way to use a generic "Collider" with Type checks



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

// G L O B A L     E N U M S
public enum SelectorShape { Circular, Rectangular }

// Instructions is a ScriptableSingleton so that it can be used as a common reference across Monobehaviours
// Member variables and functions must be STATIC for this reason
public class Instructions : ScriptableSingleton<Instructions>
{
    // F O R     W R A P P E R
    // GAMEOBJECT NAMES
    public static string instanceSuffix = "(Clone)";
    public static string mainCameraGoName = "MainCameraGO";
    public static string wrapperGoName = "WrapperGO";
    public static string keyboardInputGoName = "KeyboardInputGO";
    public static string mouseInputGoName = "MouseInputGO";
    public static string timerGoName = "TimerGO";
    public static string playerCharacterGoName = "PlayerCharacterGO";
    public static string npcPrefabGoName = "NPCPrefabGO";
    public static string selectorPrefabGoName = "SelectorPrefabGO";
    public static string entityPrefabGoName = "EntityPrefabGO";
    public static string particlePrefabGoName = "ParticlePrefabGO";

    public static string sandboxPrefabGoName = "SandboxPrefabGO";

    // GAME META PROPERTIES
    // Instance Counts
    public static int maxNumNPCs = 10;
    public static int maxNumSelectors = 25;
    // Physical Space
    public static int gridDimX = 20;
    public static int gridDimY = 20;

    // F O R     K E Y B O A R D     I N P U T
    public static KeyCode keyZoomOutCamera = KeyCode.Q;
    public static KeyCode keyZoomInCamera = KeyCode.E;

    // F O R     C A M E R A
    public static float defaultPositionZCamera = -10f;
    public static float defaultMovementSpeedCamera = 15f;
    public static float defaultZoomOutRatioCamera = 1.01f;
    public static float defaultZoomInRatioCamera = 0.99f;

    // F O R     P A R T I C L E
    public static int defaultDiameterParticle = 48;
    public static SelectorShape defaultSelShapeParticle = SelectorShape.Circular;



    // ||=====================================||
    // || ***********     ******************* ||
    // || S P R I T E     M A N A G E M E N T ||
    // || ***********     ******************* ||
    // ||=====================================||
    //    - Should be located at the end of the Instructions header,
    //      so that other relevant game defaults have already been defined

    // F I L E P A T H S
    //   (Must be fully defined BEFORE the Sprite Definition Dictionaries)
    // CIRCLES
    public static string imgCircle8 = "Sprites/Shapes/circle-8";
    public static string imgCircle16 = "Sprites/Shapes/circle-16";
    public static string imgCircle24 = "Sprites/Shapes/circle-24";
    public static string imgCircle32 = "Sprites/Shapes/circle-32";
    public static string imgCircle48 = "Sprites/Shapes/circle-48";
    public static string imgCircle64 = "Sprites/Shapes/circle-64";
    public static string imgCircle96 = "Sprites/Shapes/circle-96";
    public static string imgCircle128 = "Sprites/Shapes/circle-128";
    public static string imgCircle192 = "Sprites/Shapes/circle-192";
    public static string imgCircle256 = "Sprites/Shapes/circle-256";
    public static string imgCircle384 = "Sprites/Shapes/circle-384";
    public static string imgCircle512 = "Sprites/Shapes/circle-512";
    public static string imgCircle768 = "Sprites/Shapes/circle-768";
    public static string imgCircle1024 = "Sprites/Shapes/circle-1024";
    // SQUARES
    public static string imgSquare8 = "Sprites/Shapes/rectangle-8-8";
    public static string imgSquare16 = "Sprites/Shapes/rectangle-16-16";
    public static string imgSquare24 = "Sprites/Shapes/rectangle-24-24";
    public static string imgSquare32 = "Sprites/Shapes/rectangle-32-32";
    public static string imgSquare48 = "Sprites/Shapes/rectangle-48-48";
    public static string imgSquare64 = "Sprites/Shapes/rectangle-64-64";
    public static string imgSquare96 = "Sprites/Shapes/rectangle-96-96";
    public static string imgSquare128 = "Sprites/Shapes/rectangle-128-128";
    public static string imgSquare192 = "Sprites/Shapes/rectangle-192-192";
    public static string imgSquare256 = "Sprites/Shapes/rectangle-256-256";
    public static string imgSquare384 = "Sprites/Shapes/rectangle-384-384";
    public static string imgSquare512 = "Sprites/Shapes/rectangle-512-512";
    public static string imgSquare768 = "Sprites/Shapes/rectangle-768-768";
    public static string imgSquare1024 = "Sprites/Shapes/rectangle-1024-1024";
    // RECTANGLES
    //   X Dimension 8
    public static string imgRectangle8by8 = "Sprites/Shapes/rectangle-8-8";
    public static string imgRectangle8by16 = "Sprites/Shapes/rectangle-8-16";
    public static string imgRectangle8by24 = "Sprites/Shapes/rectangle-8-24";
    public static string imgRectangle8by32 = "Sprites/Shapes/rectangle-8-32";
    public static string imgRectangle8by48 = "Sprites/Shapes/rectangle-8-48";
    public static string imgRectangle8by64 = "Sprites/Shapes/rectangle-8-64";
    public static string imgRectangle8by96 = "Sprites/Shapes/rectangle-8-96";
    public static string imgRectangle8by128 = "Sprites/Shapes/rectangle-8-128";
    public static string imgRectangle8by192 = "Sprites/Shapes/rectangle-8-192";
    public static string imgRectangle8by256 = "Sprites/Shapes/rectangle-8-256";
    public static string imgRectangle8by384 = "Sprites/Shapes/rectangle-8-384";
    public static string imgRectangle8by512 = "Sprites/Shapes/rectangle-8-512";
    public static string imgRectangle8by768 = "Sprites/Shapes/rectangle-8-768";
    public static string imgRectangle8by1024 = "Sprites/Shapes/rectangle-8-1024";
    // CIRCULAR BORDERS
    //   Thickness 4
    public static string imgBorder4Circle16 = "Sprites/Borders/border-4-circle-16";
    //   Thickness 8
    public static string imgBorder8Circle24 = "Sprites/Borders/border-8-circle-24";
    public static string imgBorder8Circle32 = "Sprites/Borders/border-8-circle-32";
    public static string imgBorder8Circle48 = "Sprites/Borders/border-8-circle-48";
    public static string imgBorder8Circle64 = "Sprites/Borders/border-8-circle-64";
    public static string imgBorder8Circle96 = "Sprites/Borders/border-8-circle-96";
    public static string imgBorder8Circle128 = "Sprites/Borders/border-8-circle-128";
    public static string imgBorder8Circle192 = "Sprites/Borders/border-8-circle-192";
    public static string imgBorder8Circle256 = "Sprites/Borders/border-8-circle-256";
    public static string imgBorder8Circle384 = "Sprites/Borders/border-8-circle-384";
    public static string imgBorder8Circle512 = "Sprites/Borders/border-8-circle-512";
    public static string imgBorder8Circle768 = "Sprites/Borders/border-8-circle-768";
    public static string imgBorder8Circle1024 = "Sprites/Borders/border-8-circle-1024";
    // SQUARE BORDERS
    //   Thickness 1
    public static string imgBorder1Square3 = "Sprites/Borders/border-1-rectangle-3-3";
    public static string imgBorder1Square16 = "Sprites/Borders/border-1-rectangle-16-16";
    public static string imgBorder1Square128 = "Sprites/Borders/border-1-rectangle-128-128";
    //   Thickness 2
    public static string imgBorder2Square16 = "Sprites/Borders/border-2-rectangle-16-16";
    public static string imgBorder2Square128 = "Sprites/Borders/border-2-rectangle-128-128";
    //   Thickness 3
    public static string imgBorder3Square16 = "Sprites/Borders/border-3-rectangle-16-16";
    public static string imgBorder3Square128 = "Sprites/Borders/border-3-rectangle-128-128";
    //   Thickness 4
    public static string imgBorder4Square16 = "Sprites/Borders/border-4-rectangle-16-16";
    public static string imgBorder4Square128 = "Sprites/Borders/border-4-rectangle-128-128";
    //   Thickness 5
    public static string imgBorder5Square128 = "Sprites/Borders/border-5-rectangle-128-128";
    //   Thickness 6
    public static string imgBorder6Square128 = "Sprites/Borders/border-6-rectangle-128-128";
    //   Thickness 7
    public static string imgBorder7Square128 = "Sprites/Borders/border-7-rectangle-128-128";
    //   Thickness 8
    public static string imgBorder8Square24 = "Sprites/Borders/border-8-rectangle-24-24";
    public static string imgBorder8Square32 = "Sprites/Borders/border-8-rectangle-32-32";
    public static string imgBorder8Square48 = "Sprites/Borders/border-8-rectangle-48-48";
    public static string imgBorder8Square64 = "Sprites/Borders/border-8-rectangle-64-64";
    public static string imgBorder8Square96 = "Sprites/Borders/border-8-rectangle-96-96";
    public static string imgBorder8Square128 = "Sprites/Borders/border-8-rectangle-128-128";
    public static string imgBorder8Square192 = "Sprites/Borders/border-8-rectangle-192-192";
    public static string imgBorder8Square256 = "Sprites/Borders/border-8-rectangle-256-256";
    public static string imgBorder8Square384 = "Sprites/Borders/border-8-rectangle-384-384";
    public static string imgBorder8Square512 = "Sprites/Borders/border-8-rectangle-512-512";
    public static string imgBorder8Square768 = "Sprites/Borders/border-8-rectangle-768-768";
    public static string imgBorder8Square1024 = "Sprites/Borders/border-8-rectangle-1024-1024";

    // S P R I T E     D E F I N I T I O N     D I C T I O N A R I E S
    //   AND OTHER LOOKUP DATA STRUCTURES
    //   (Must be defined AFTER all filepaths, must be fully defined BEFORE the Sprite Abstraction Values)
    // IMAGE SIZE STANDARDS
    public static int[] imgCircleSizeStandards = { 8, 16, 24, 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024 };
    public static int[] imgSquareSizeStandards = { 8, 16, 24, 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024 };
    public static Dictionary<int, int[]> imgBorderCircleSizeStandards = new Dictionary<int, int[]>
    {
        { 8, (new int[]{ 24, 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024}) }
    };
    public static Dictionary<int, int[]> imgBorderSquareSizeStandards = new Dictionary<int, int[]>
    {
        { 8, (new int[]{ 24, 32, 48, 64, 96, 128, 192, 256, 384, 512, 768, 1024}) }
    };
    // SPRITE DEFINITION DICTIONARIES
    // Circles
    public static Dictionary<int, string> imgsCircles = new Dictionary<int, string>
    {
        { 8, imgCircle8 },
        { 16, imgCircle16 },
        { 24, imgCircle24 },
        { 32, imgCircle32 },
        { 48, imgCircle48 },
        { 64, imgCircle64 },
        { 96, imgCircle96 },
        { 128, imgCircle128 },
        { 192, imgCircle192 },
        { 256, imgCircle256 },
        { 384, imgCircle384 },
        { 512, imgCircle512 },
        { 768, imgCircle768 },
        { 1024, imgCircle1024 }
    };
    // Squares
    public static Dictionary<int, string> imgsSquares = new Dictionary<int, string>
    {
        { 8, imgSquare8 },
        { 16, imgSquare16 },
        { 24, imgSquare24 },
        { 32, imgSquare32 },
        { 48, imgSquare48 },
        { 64, imgSquare64 },
        { 96, imgSquare96 },
        { 128, imgSquare128 },
        { 192, imgSquare192 },
        { 256, imgSquare256 },
        { 384, imgSquare384 },
        { 512, imgSquare512 },
        { 768, imgSquare768 },
        { 1024, imgSquare1024 }
    };
    // Rectangles (X Dimension 8)
    public static Dictionary<int, string> imgsRectangles8by = new Dictionary<int, string>
    {
        { 8, imgRectangle8by8 },
        { 16, imgRectangle8by16 },
        { 24, imgRectangle8by24 },
        { 32, imgRectangle8by32 },
        { 48, imgRectangle8by48 },
        { 64, imgRectangle8by64 },
        { 96, imgRectangle8by96 },
        { 128, imgRectangle8by128 },
        { 192, imgRectangle8by192 },
        { 256, imgRectangle8by256 },
        { 384, imgRectangle8by384 },
        { 512, imgRectangle8by512 },
        { 768, imgRectangle8by768 },
        { 1024, imgRectangle8by1024 }
    };
    // Circular Borders (Thickness 8)
    public static Dictionary<int, string> imgsBorder8Circles = new Dictionary<int, string>
    {
        { 24, imgBorder8Circle24 },
        { 32, imgBorder8Circle32 },
        { 48, imgBorder8Circle48 },
        { 64, imgBorder8Circle64 },
        { 96, imgBorder8Circle96 },
        { 128, imgBorder8Circle128 },
        { 192, imgBorder8Circle192 },
        { 256, imgBorder8Circle256 },
        { 384, imgBorder8Circle384 },
        { 512, imgBorder8Circle512 },
        { 768, imgBorder8Circle768 },
        { 1024, imgBorder8Circle1024 }
    };
    // Square Borders (Thickness 8)
    public static Dictionary<int, string> imgsBorder8Squares = new Dictionary<int, string>
    {
        { 24, imgBorder8Square24 },
        { 32, imgBorder8Square32 },
        { 48, imgBorder8Square48 },
        { 64, imgBorder8Square64 },
        { 96, imgBorder8Square96 },
        { 128, imgBorder8Square128 },
        { 192, imgBorder8Square192 },
        { 256, imgBorder8Square256 },
        { 384, imgBorder8Square384 },
        { 512, imgBorder8Square512 },
        { 768, imgBorder8Square768 },
        { 1024, imgBorder8Square1024 }
    };
    // SPRITE DEFINITION DICTIONARY LOOKUP DICTIONARIES
    // Rectangles
    public static Dictionary<int, Dictionary<int, string>> imgsRectangles = new Dictionary<int, Dictionary<int, string>>
    {
        { 8, imgsRectangles8by }
    };
    // Circular Borders
    public static Dictionary<int, Dictionary<int, string>> imgsBorderCircles = new Dictionary<int, Dictionary<int, string>>
    {
        { 8, imgsBorder8Circles }
    };
    // Square Borders
    public static Dictionary<int, Dictionary<int, string>> imgsBorderSquares = new Dictionary<int, Dictionary<int, string>>
    {
        { 8, imgsBorder8Squares }
    };


    // S P R I T E     A B S T R A C T I O N     V A L U E S
    // GENERAL
    public static string defaultImgSquare = imgsSquares[128];
    public static string defaultImgCircle = imgsCircles[128];
    public static string defaultImgBorderSquare = imgsBorderSquares[8][128];
    public static string defaultImgBorderCircle = imgsBorderCircles[8][48];
    // CLASS-SPECIFIC
    // Entities
    public static string defaultImgEntity = imgsCircles[96];
    // Particles
    public static string defaultImgParticle = imgsCircles[48];
    // Selectors
    public static string defaultImgSelectorCircle = defaultImgBorderCircle;
    public static string defaultImgSelectorSquare = defaultImgBorderSquare;
    public static string defaultImgSelector = defaultImgSelectorSquare;

    // C O L O R I N G
    // COLOR DEFINITION METAPARAMETERS
    public static float maxRedValColor = 1f;
    public static float maxGreenValColor = 1f;
    public static float maxBlueValColor = 1f;
    public static float lightOtherValColor = 0.5f;
    public static float maxAlphaValColor = 1f;
    public static float translucentAlphaValColor = 0.5f;
    // GENERAL COLOR VALUE DEFINITIONS
    // |R|G|B|C|M|Y|K|W|
    public static Color colorRed = new Color(maxRedValColor, 0f, 0f, maxAlphaValColor);
    public static Color colorGreen = new Color(0f, maxGreenValColor, 0f, maxAlphaValColor);
    public static Color colorBlue = new Color(0f, 0f, maxBlueValColor, maxAlphaValColor);
    public static Color colorCyan = new Color(0f, maxGreenValColor, maxBlueValColor, maxAlphaValColor);
    public static Color colorMagenta = new Color(maxRedValColor, 0f, maxBlueValColor, maxAlphaValColor);
    public static Color colorYellow = new Color(maxRedValColor, maxGreenValColor, 0f, maxAlphaValColor);
    public static Color colorBlack = new Color(0f, 0f, 0f, maxAlphaValColor);
    public static Color colorWhite = new Color(maxRedValColor, maxGreenValColor, maxBlueValColor, maxAlphaValColor);
    // "Light" |R|G|B|C|M|Y|
    public static Color colorLightRed = new Color(maxRedValColor, lightOtherValColor, lightOtherValColor, maxAlphaValColor);
    public static Color colorLightGreen = new Color(lightOtherValColor, maxGreenValColor, lightOtherValColor, maxAlphaValColor);
    public static Color colorLightBlue = new Color(lightOtherValColor, lightOtherValColor, maxBlueValColor, maxAlphaValColor);
    public static Color colorLightCyan = new Color(lightOtherValColor, maxGreenValColor, maxBlueValColor, maxAlphaValColor);
    public static Color colorLightMagenta = new Color(maxRedValColor, lightOtherValColor, maxBlueValColor, maxAlphaValColor);
    public static Color colorLightYellow = new Color(maxRedValColor, maxGreenValColor, lightOtherValColor, maxAlphaValColor);
    // COLOR SCHEME DEFINITIONS
    public static Dictionary<string, Dictionary<string, Color>> colors = new Dictionary<string, Dictionary<string, Color>> 
    {
        { "text",  new Dictionary<string, Color> { { "default", colorBlack }, { "header", colorBlack }, { "body", colorBlack } } },
        { "entity",  new Dictionary<string, Color> { { "default", colorRed }, { "selected", colorYellow }, { "frozen", colorBlack } } },
        { "particle",  new Dictionary<string, Color> { { "default", colorMagenta }, { "selected", colorWhite }, { "frozen", colorCyan } } }
    };

    // S P R I T E R E N D E R E R     S O R T I N G     O R D E R S
    // NOTE: "True default" Sorting Order value is 0
    public static int defaultSortingOrderSelector = 10; // Should be higher than the Sorting Order of any selectable entity
    public static int defaultSortingOrderEntity = 1;
    public static int defaultSortingOrderParticle = 2;

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
