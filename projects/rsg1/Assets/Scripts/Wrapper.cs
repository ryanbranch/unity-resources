﻿// TODO:
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

    public GameObject entityPrefabGo;
    public Entity entityPrefab;
    public List<Entity> entities;

    [SerializeField]
    public Color[] testArr1 = { Instructions.colorBlue, Instructions.colorCyan };


    // Start is called before the first frame update
    void Start()
    {
        InitializeGameObjects();

        CenterCameraOnPlayer();

        PrefabTestBench();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CenterCameraOnPlayer()
    {
        mainCamera.MoveToPos(playerCharacterGo.transform.position.x, playerCharacterGo.transform.position.y);
    }

    public void PrefabTestBench()
    {
        sandboxPrefab.Construct();
        sandboxPrefab.AddSelector();

        entities.Add(Instantiate(entityPrefab).GetComponent<Entity>());
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
        // MainCamera
        mainCameraGo = GameObject.Find(Instructions.mainCameraGoName);
        mainCamera = mainCameraGo.AddComponent<MainCamera>();
        mainCamera.Construct();
        // KeyboardInput
        keyboardInputGo = new GameObject(Instructions.keyboardInputGoName);
        keyboardInput = keyboardInputGo.AddComponent<KeyboardInput>();
        // MouseInput
        mouseInputGo = new GameObject(Instructions.mouseInputGoName);
        mouseInput = mouseInputGo.AddComponent<MouseInput>();
        // Timer
        timerGo = new GameObject(Instructions.timerGoName);
        timer = timerGo.AddComponent<Timer>();
        // PlayableCharacter
        playerCharacterGo = new GameObject(Instructions.playerCharacterGoName);
        playerCharacter = playerCharacterGo.AddComponent<PlayerCharacter>();
        // NonPlayableCharacter
        npcPrefabGo = new GameObject(Instructions.npcPrefabGoName);
        npcPrefab = npcPrefabGo.AddComponent<NonPlayerCharacter>();

        // Selector
        selectorPrefabGo = new GameObject(Instructions.selectorPrefabGoName);
        selectorPrefab = selectorPrefabGo.AddComponent<Selector>();
        selectors = new List<Selector>();

        // SandboxClass
        sandboxPrefabGo = new GameObject(Instructions.sandboxPrefabGoName);
        sandboxPrefab = sandboxPrefabGo.AddComponent<SandboxClass>();
        sandboxes = new List<SandboxClass>();

        // Entity
        entityPrefabGo = new GameObject(Instructions.entityPrefabGoName);
        entityPrefab = entityPrefabGo.AddComponent<Entity>();
        entities = new List<Entity>();
    }

}
