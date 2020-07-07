// TODO:
// ================================
//  - S
// ================================
//  - Properly handle parent/child relationships between (transforms of) Selectors and their associated GameObjects

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public GameObject mainCameraGo;
    public MainCamera mainCamera;
    public GameObject keyboardInputGo;
    public KeyboardInput keyboardInput;
    public GameObject mouseInputGo;
    public MouseInput mouseInput;
    public GameObject timerGo;
    public Timer timer;
    public GameObject playerCharacterGo;
    public PlayerCharacter playerCharacter;
    public GameObject npcPrefabGo;
    public NonPlayerCharacter npcPrefab;
    public List<NonPlayerCharacter> npcs;

    public GameObject selectorPrefabGo;
    public Selector selectorPrefab;
    public List<Selector> selectors;


    public GameObject sandboxPrefabGo;
    public SandboxClass sandboxPrefab;
    public List<SandboxClass> sandboxes;

    public void PrefabTestBench()
    {
        sandboxPrefab.Construct();
        sandboxPrefab.AddSelector();
    }

    public void DeselectAll()
    {
        int numSelectors = selectors.Count;
        for (int i = 0; i < numSelectors; i++)
        {
            selectors[i].Deselect();
        }
    }
    
    // To be called at the beginning of Start()
    //  - Creates (or defines) the specific non-prefab GameObjects needed for the game
    //  - Adds an instance of the designated script for each
    public void InitializeGameObjects()
    {
        // Sets the name for the Wrapper
        gameObject.name = Instructions.wrapperGoName;
        // Creates, and sets properties for, non-Wrapper GameObjects
        mainCameraGo = GameObject.Find(Instructions.mainCameraGoName);
        mainCamera = mainCameraGo.AddComponent<MainCamera>();
        keyboardInputGo = new GameObject(Instructions.keyboardInputGoName);
        keyboardInput = keyboardInputGo.AddComponent<KeyboardInput>();
        mouseInputGo = new GameObject(Instructions.mouseInputGoName);
        mouseInput = mouseInputGo.AddComponent<MouseInput>();
        timerGo = new GameObject(Instructions.timerGoName);
        timer = timerGo.AddComponent<Timer>();
        playerCharacterGo = new GameObject(Instructions.playerCharacterGoName);
        playerCharacter = playerCharacterGo.AddComponent<PlayerCharacter>();
        npcPrefabGo = new GameObject(Instructions.npcPrefabGoName);
        npcPrefab = npcPrefabGo.AddComponent<NonPlayerCharacter>();


        selectorPrefabGo = new GameObject(Instructions.selectorPrefabGoName);
        selectorPrefab = selectorPrefabGo.AddComponent<Selector>();
        selectors = new List<Selector>();


        sandboxPrefabGo = new GameObject(Instructions.sandboxGoName);
        sandboxPrefab = sandboxPrefabGo.AddComponent<SandboxClass>();
        sandboxes = new List<SandboxClass>();

    }

    // Start is called before the first frame update
    void Start()
    {
        InitializeGameObjects();

        PrefabTestBench();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
