// TODO:
// ================================
//  - S: Placeholder
// ================================
//  - A: Placeholder
//  - B: Stop using "Bc"-based naming convention when not all colliders are Boxes
//      1. More significantly, figure out a way to use a generic "Collider" with Type checks

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

    public List<Entity> entities;
    public GameObject particlePrefabGo;
    public Particle particlePrefab;
    public List<Particle> particles;

    // REFERENCE: How to instantiate an array by naming all contents
    [SerializeField]
    public Color[] testArr1 = { Instructions.colorBlue, Instructions.colorCyan };

    public ISelectable primarySelection;


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

        particles.Add(Instantiate(particlePrefab).GetComponent<Particle>());
        particles[0].Construct(32);
        particles[0].AddSelector();

        particlePrefab.Construct(96);
        particlePrefab.AddSelector();

        particles[0].MoveToPos(-2f, 2f);
        particlePrefab.MoveToPos(3f, 4f);
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
        entities = new List<Entity>();
        // Particle
        particlePrefabGo = new GameObject(Instructions.particlePrefabGoName);
        particlePrefab = particlePrefabGo.AddComponent<Particle>();
        particles = new List<Particle>();
    }

}
