using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEditorInternal;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class CustomeWindow : EditorWindow
{
    //este codigo esta basado en https://www.youtube.com/watch?v=491TSNwXTIg&list=LL&index=1&t=1s
    static CustomeWindow window;
    [MenuItem("Window/Easy game feel")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<CustomeWindow>("Easy game feel");
        window = (CustomeWindow)GetWindow(typeof(CustomeWindow));
        window.maxSize = new Vector2(180, 90);
        window.minSize = new Vector2(170, 80);
    }

    private void OnGUI()
    {
        GUILayout.Label("Elements");
        if (GUILayout.Button("Real time control"))
        {
            RealTimeControl.ShowWindow();
        }
        if (GUILayout.Button("Simulated space"))
        {
            SimulatedSpace.ShowWindow();
        }
        if (GUILayout.Button("Polish"))
        {
            Polish.ShowWindow();
        }
    }
}
public class RealTimeControl : EditorWindow
{
    static RealTimeControl window;
    public static void ShowWindow()
    {
        window = (RealTimeControl)GetWindow(typeof(RealTimeControl));
        window.titleContent.text = "Real time control";
        window.minSize = new Vector2(170, 183);
        window.maxSize = new Vector2(180, 193);
    }
    private void OnGUI()
    {
        GUILayout.Label("Elements");
        if (GUILayout.Button("Top down controller"))
        {
            TopDown.ShowWindow();
        }
        if (GUILayout.Button("UFO destroyer controller"))
        {
            UFODestroyer.ShowWindow();
        }
        if (GUILayout.Button("Platformer controller"))
        {
            Platformer.ShowWindow();
        }
        if (GUILayout.Button("Runer controller"))
        {
            Runer.ShowWindow();
        }
        if (GUILayout.Button("Camera controller"))
        {
            CameraControllerSpawner.ShowWindow();
        }
        if (GUILayout.Button("Camera position locker"))
        {
            CameraPositionLockerSpawner.ShowWindow();
        }
        if (GUILayout.Button("Cursor following"))
        {
            CursorFollowingSpawner.ShowWindow();
        }
        if (GUILayout.Button("Paralyze"))
        {
            ParalyzeSpawner.ShowWindow();
        }
    }
}
public class SimulatedSpace : EditorWindow
{
    static SimulatedSpace window;
    public static void ShowWindow()
    {
        window = (SimulatedSpace)GetWindow(typeof(SimulatedSpace));
        window.titleContent.text = "Simulated space";
        window.minSize = new Vector2(210, 290);
        window.maxSize = new Vector2(220, 300);
    }
    private void OnGUI()
    {
        GUILayout.Label("Elements");
        if (GUILayout.Button("Weapon"))
        {
            WeaponSpawner.ShowWindow();
        }
        if (GUILayout.Button("Melee weapon"))
        {
            MeleeWeaponSpawner.ShowWindow();
        }
        if (GUILayout.Button("Projectile"))
        {
            ProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Bouncie projectile"))
        {
            BouncieProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Penetrating projectile"))
        {
            PenetratingProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Push projectile"))
        {
            PushProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Explosive projectile"))
        {
            ExplosiveProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Laser projectile"))
        {
            LaserProjectileSpawner.ShowWindow();
        }
        if (GUILayout.Button("Laser projectile with line renderer"))
        {
            LaserProjectileLineRendererSpawner.ShowWindow();
        }
        if (GUILayout.Button("Explosive object"))
        {
            ExplosiveObjectSpawner.ShowWindow();
        }
        if (GUILayout.Button("Destroyable object"))
        {
            DestroyableObjectSpawner.ShowWindow();
        }
        if (GUILayout.Button("Pushable object"))
        {
            PushableObjectSpawner.ShowWindow();
        }
        if (GUILayout.Button("Magnetic object"))
        {
            MagneticObjectSpawner.ShowWindow();
        }
    }
}
public class Polish : EditorWindow
{
    static Polish window;
    public static void ShowWindow()
    {
        window = (Polish)GetWindow(typeof(Polish));
        window.titleContent.text = "Polish";
        window.minSize = new Vector2(230, 143);
        window.maxSize = new Vector2(240, 153);
    }
    private void OnGUI()
    {
        GUILayout.Label("Elements");
        if (GUILayout.Button("Hit stop"))
        {
            HitStopSpawner.ShowWindow();
        }
        if (GUILayout.Button("Screen shake"))
        {
            ScreenShakeSpawner.ShowWindow();
        }
        if (GUILayout.Button("Scale time"))
        {
            ScaleTimeSpawner.ShowWindow();
        }
        if (GUILayout.Button("Screen change according to hp"))
        {
            ScreenChangeAcordingToHPSpawner.ShowWindow();
        }
        if (GUILayout.Button("Vibrate object"))
        {
            VibrateObjectSpawner.ShowWindow();
        }
        if (GUILayout.Button("Sound player according to surface"))
        {
            SoundAcordingToSurfaceSpawner.ShowWindow();
        }
    }
}
public class TopDown : EditorWindow
{
    //Este codigo esta vasado en https://www.youtube.com/watch?v=-OwtRs0rm14&list=PL4CCSwmU04MiCnps1DRmwIEEH7gP9X3qq&index=7
    static TopDown window;
    string objectName;
    float speed;
    float dashSpeed;
    float dashTime;
    bool activateDash;
    bool usesForceMovement;
    string dashButton;
    Object sprite;
    Object physicsMaterial;

    public static void ShowWindow()
    {
        window = (TopDown)GetWindow(typeof(TopDown));
        window.titleContent.text = "Top down controller";
        window.minSize = new Vector2(260, 223);
        window.maxSize = new Vector2(270, 233);
    }
    private void OnGUI()
    {
        objectName = "Top down controller";
        sprite = Resources.Load<Sprite>("Sprites/Player/PlayerShip");
        speed = 3;
        dashSpeed = 6;
        dashTime = 0.2f;
        activateDash = true;
        dashButton = "Fire3";
        physicsMaterial = Resources.Load<PhysicsMaterial2D>("Physics material/Easy Game Feel Physics Material 2D");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        dashSpeed = EditorGUILayout.FloatField("Dash speed", dashSpeed);
        dashTime = EditorGUILayout.FloatField("Dash time", dashTime);
        activateDash = EditorGUILayout.Toggle("Activate dash", activateDash);
        usesForceMovement = EditorGUILayout.Toggle("Uses force movement", usesForceMovement);
        dashButton = EditorGUILayout.TextField("Dash button", dashButton);
        if (GUILayout.Button("Create"))
        {
            SpawnTopDown();
        }
    }
    private void SpawnTopDown()
    {
        GameObject topDownObject = new GameObject();
        topDownObject.gameObject.name = objectName;
        topDownObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            topDownObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        topDownObject.AddComponent<Rigidbody2D>();
        topDownObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        topDownObject.AddComponent<BoxCollider2D>();
        topDownObject.GetComponent<BoxCollider2D>().sharedMaterial = (PhysicsMaterial2D)physicsMaterial;
        topDownObject.AddComponent<TopDownController>();
        topDownObject.GetComponent<TopDownController>().Speed = speed;
        topDownObject.GetComponent<TopDownController>().DashSpeed = dashSpeed;
        topDownObject.GetComponent<TopDownController>().DashTime = dashTime;
        topDownObject.GetComponent<TopDownController>().ActivateDash = activateDash;
        topDownObject.GetComponent<TopDownController>().UsesForceMovement = usesForceMovement;
        topDownObject.GetComponent<TopDownController>().DashButton = dashButton;
        topDownObject.GetComponent<TopDownController>().Rb = topDownObject.GetComponent<Rigidbody2D>();
    }
}
public class UFODestroyer : EditorWindow
{
    static UFODestroyer window;
    string objectName;
    float speed;
    bool usesForceMovement;
    Object sprite;
    Object physicsMaterial;

    public static void ShowWindow()
    {
        window = (UFODestroyer)GetWindow(typeof(UFODestroyer));
        window.titleContent.text = "UFO destroyer controller";
        window.minSize = new Vector2(260, 143);
        window.maxSize = new Vector2(270, 153);
    }
    private void OnGUI()
    {
        objectName = "UFO destroyer controller";
        sprite = Resources.Load<Sprite>("Sprites/Player/PlayerShip");
        speed = 3;
        physicsMaterial = Resources.Load<PhysicsMaterial2D>("Physics material/Easy Game Feel Physics Material 2D");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        usesForceMovement = EditorGUILayout.Toggle("Uses force movement", usesForceMovement);
        if (GUILayout.Button("Create"))
        {
            SpawnUFODestroyer();
        }
    }
    private void SpawnUFODestroyer()
    {
        GameObject UFODestroyerObject = new GameObject();
        UFODestroyerObject.gameObject.name = objectName;
        UFODestroyerObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            UFODestroyerObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        UFODestroyerObject.AddComponent<Rigidbody2D>();
        UFODestroyerObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        UFODestroyerObject.AddComponent<BoxCollider2D>();
        UFODestroyerObject.GetComponent<BoxCollider2D>().sharedMaterial = (PhysicsMaterial2D)physicsMaterial;
        UFODestroyerObject.AddComponent<UFODestroyerController>();
        UFODestroyerObject.GetComponent<UFODestroyerController>().Speed = speed;
        UFODestroyerObject.GetComponent<UFODestroyerController>().UsesForceMovement = usesForceMovement;
        UFODestroyerObject.GetComponent<UFODestroyerController>().Rb = UFODestroyerObject.GetComponent<Rigidbody2D>();
    }
}
public class Platformer : EditorWindow
{
    static Platformer window;
    string objectName;
    float speed;
    float dashSpeed;
    float dashTime;
    float jumpHight;
    int jumps;
    float checkRadius;
    bool activateDash;
    bool usesForceMovement;
    string jumpButton;
    string dashButton;
    Object sprite;
    LayerMask floor;
    Object physicsMaterial;

    public static void ShowWindow()
    {
        window = (Platformer)GetWindow(typeof(Platformer));
        window.titleContent.text = "Platformer controller";
        window.minSize = new Vector2(260, 325);
        window.maxSize = new Vector2(270, 335);
    }
    private void OnGUI()
    {
        objectName = "Platformer controller";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        speed = 3;
        dashSpeed = 6;
        dashTime = 0.2f;
        jumpHight = 5;
        jumps = 1;
        checkRadius = 0.2f;
        activateDash = true;
        jumpButton = "Jump";
        dashButton = "Fire3";
        floor = LayerMask.NameToLayer("Water");
        physicsMaterial = Resources.Load<PhysicsMaterial2D>("Physics material/Easy Game Feel Physics Material 2D");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        dashSpeed = EditorGUILayout.FloatField("Dash speed", dashSpeed);
        dashTime = EditorGUILayout.FloatField("Start dash time", dashTime);
        jumpHight = EditorGUILayout.FloatField("Jump hight", jumpHight);
        jumps = EditorGUILayout.IntField("Extra jumps", jumps); ;
        checkRadius = EditorGUILayout.FloatField("Check radius", checkRadius); 
        activateDash = EditorGUILayout.Toggle("Activate dash", activateDash);
        usesForceMovement = EditorGUILayout.Toggle("Uses force movement", usesForceMovement);
        jumpButton = EditorGUILayout.TextField("Jump button", jumpButton);
        dashButton = EditorGUILayout.TextField("Dash button", dashButton);
        floor = EditorGUILayout.LayerField("Collision layer", floor);
        if (GUILayout.Button("Create"))
        {
            SpawnPlataformer();
        }
    }
    private void SpawnPlataformer()
    {
        GameObject plataformerObject = new GameObject();
        GameObject feetObject = new GameObject();
        feetObject.transform.SetParent(plataformerObject.transform);
        plataformerObject.gameObject.name = objectName;
        plataformerObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            plataformerObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        plataformerObject.AddComponent<Rigidbody2D>();
        plataformerObject.AddComponent<BoxCollider2D>();
        plataformerObject.GetComponent<BoxCollider2D>().sharedMaterial = (PhysicsMaterial2D)physicsMaterial;
        plataformerObject.AddComponent<SideViewPlatformerController>();
        plataformerObject.GetComponent<SideViewPlatformerController>().Speed = speed;
        plataformerObject.GetComponent<SideViewPlatformerController>().DashSpeed = dashSpeed;
        plataformerObject.GetComponent<SideViewPlatformerController>().DashTime = dashTime;
        plataformerObject.GetComponent<SideViewPlatformerController>().JumpHight = jumpHight;
        plataformerObject.GetComponent<SideViewPlatformerController>().ExtraJumps = jumps;
        plataformerObject.GetComponent<SideViewPlatformerController>().CheckRadius = checkRadius;
        plataformerObject.GetComponent<SideViewPlatformerController>().ActivateDash = activateDash;
        plataformerObject.GetComponent<SideViewPlatformerController>().UsesForceMovement = usesForceMovement;
        plataformerObject.GetComponent<SideViewPlatformerController>().JumpButton = jumpButton;
        plataformerObject.GetComponent<SideViewPlatformerController>().DashButton = dashButton;
        plataformerObject.GetComponent<SideViewPlatformerController>().FeetPos = feetObject.transform;
        plataformerObject.GetComponent<SideViewPlatformerController>().Rb = plataformerObject.GetComponent<Rigidbody2D>();
        plataformerObject.GetComponent<SideViewPlatformerController>().Floor = 1 << floor;
    }
}
public class Runer : EditorWindow
{
    static Runer window;
    string objectName;
    float speed;
    float jumpHight;
    int startExtraJumps;
    float duckingSpeed;
    float impulsionForce;
    float checkRadius;
    string jumpButton;
    string duckButton;
    Object sprite;
    LayerMask floor;
    Object physicsMaterial;

    public static void ShowWindow()
    {
        window = (Runer)GetWindow(typeof(Runer));
        window.titleContent.text = "Runer controller";
        window.minSize = new Vector2(260, 285);
        window.maxSize = new Vector2(270, 295);
    }
    private void OnGUI()
    {
        objectName = "Runer controller";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        speed = 3;
        jumpHight = 5;
        startExtraJumps = 1;
        duckingSpeed = 3;
        impulsionForce = 1;
        checkRadius = 0.2f;
        jumpButton = "Jump";
        duckButton = "Fire3";
        floor = LayerMask.NameToLayer("Water");
        physicsMaterial = Resources.Load<PhysicsMaterial2D>("Physics material/Easy Game Feel Physics Material 2D");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        jumpHight = EditorGUILayout.FloatField("Jump hight", jumpHight);
        duckingSpeed = EditorGUILayout.FloatField("Ducking speed", duckingSpeed);
        impulsionForce = EditorGUILayout.FloatField("Impulsion force", impulsionForce);
        startExtraJumps = EditorGUILayout.IntField("Extra jumps", startExtraJumps);
        checkRadius = EditorGUILayout.FloatField("Check radius", checkRadius);
        jumpButton = EditorGUILayout.TextField("Jump button", jumpButton);
        duckButton = EditorGUILayout.TextField("Duck button", duckButton);
        floor = EditorGUILayout.LayerField("Collision layer", floor);
        if (GUILayout.Button("Create"))
        {
            SpawnRuner();
        }
    }
    private void SpawnRuner()
    {
        GameObject runerObject = new GameObject();
        GameObject feetObject = new GameObject();
        feetObject.transform.SetParent(runerObject.transform);
        runerObject.gameObject.name = objectName;
        runerObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            runerObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        runerObject.AddComponent<Rigidbody2D>();
        runerObject.AddComponent<BoxCollider2D>();
        runerObject.GetComponent<BoxCollider2D>().sharedMaterial = (PhysicsMaterial2D)physicsMaterial;
        runerObject.AddComponent<SideViewRunerController>();
        runerObject.GetComponent<SideViewRunerController>().Speed = speed;
        runerObject.GetComponent<SideViewRunerController>().JumpHight = jumpHight;
        runerObject.GetComponent<SideViewRunerController>().DuckingSpeed = duckingSpeed;
        runerObject.GetComponent<SideViewRunerController>().ImpulsionForce = impulsionForce;
        runerObject.GetComponent<SideViewRunerController>().ExtraJumps = startExtraJumps;
        runerObject.GetComponent<SideViewRunerController>().CheckRadius = checkRadius;
        runerObject.GetComponent<SideViewRunerController>().JumpButton = jumpButton;
        runerObject.GetComponent<SideViewRunerController>().DuckButton = duckButton;
        runerObject.GetComponent<SideViewRunerController>().FeetPos = feetObject.transform;
        runerObject.GetComponent<SideViewRunerController>().Rb = runerObject.GetComponent<Rigidbody2D>();
        runerObject.GetComponent<SideViewRunerController>().Floor = 1 << floor;
    }
}
public class CameraControllerSpawner : EditorWindow
{
    static CameraControllerSpawner window;
    string objectName;
    float maxSpeed;
    float maxForce;
    float maxDistance;
    float seekingBehaviourDistance;
    float arrivingBehaviourDistance;
    float stopMovingDistance;
    string cameraControllerButton;
    Object referenceObject;
    Object referenceCamera;
    public static void ShowWindow()
    {
        window = (CameraControllerSpawner)GetWindow(typeof(CameraControllerSpawner));
        window.titleContent.text = "Camera controller";
        window.minSize = new Vector2(280, 217);
        window.maxSize = new Vector2(290, 227);
    }
    private void OnGUI()
    {
        objectName = "Camera controller";
        maxSpeed = 0.07f;
        maxForce = 0.06f;
        maxDistance = 1;
        seekingBehaviourDistance = 0.1f;
        arrivingBehaviourDistance = 0.1f;
        stopMovingDistance = 0.1f;
        cameraControllerButton = "Fire3";
        referenceCamera = Camera.main;

        objectName = EditorGUILayout.TextField("Name", objectName);
        maxForce = EditorGUILayout.FloatField("Max force", maxForce);
        maxSpeed = EditorGUILayout.FloatField("Max speed", maxSpeed);
        maxDistance = EditorGUILayout.FloatField("Max distance", maxDistance);
        seekingBehaviourDistance = EditorGUILayout.FloatField("Seeking behaviour distance", seekingBehaviourDistance);
        arrivingBehaviourDistance = EditorGUILayout.FloatField("Arriving behaviour distance", arrivingBehaviourDistance);
        stopMovingDistance = EditorGUILayout.FloatField("Stop moving distance", stopMovingDistance);
        cameraControllerButton = EditorGUILayout.TextField("Camera controller button", cameraControllerButton);
        referenceObject = EditorGUILayout.ObjectField("Reference object", referenceObject, typeof(GameObject), true);
        referenceCamera = EditorGUILayout.ObjectField("Reference camera", referenceCamera, typeof(Camera), true);
        if (GUILayout.Button("Create"))
        {
            SpawnCameraController();
        }
    }
    private void SpawnCameraController()
    {
        GameObject cameraControlerObject = new GameObject();
        cameraControlerObject.name = objectName;
        cameraControlerObject.transform.position = new Vector3(cameraControlerObject.transform.position.x, cameraControlerObject.transform.position.y, -10);
        cameraControlerObject.AddComponent<Camera>();
        cameraControlerObject.GetComponent<Camera>().orthographic = true;
        cameraControlerObject.AddComponent<CameraController>();
        cameraControlerObject.GetComponent<CameraController>().ReferenceCamera = (Camera)referenceCamera;
        if (referenceCamera)
        {
            cameraControlerObject.GetComponent<CameraController>().ReferenceCamera.targetDisplay = 1;
        }
        cameraControlerObject.GetComponent<CameraController>().SeekingBehaviourDistance = seekingBehaviourDistance;
        cameraControlerObject.GetComponent<CameraController>().ArrivingBehaviourDistance = arrivingBehaviourDistance;
        cameraControlerObject.GetComponent<CameraController>().StopMovingDistance = stopMovingDistance;
        cameraControlerObject.GetComponent<CameraController>().CameraControllerbutton = cameraControllerButton;
        cameraControlerObject.GetComponent<CameraController>().ReferenceObject = (GameObject)referenceObject;
        cameraControlerObject.GetComponent<CameraController>().MaxDistance = maxDistance;
        cameraControlerObject.GetComponent<CameraController>().MaxSpeed = maxSpeed;
        cameraControlerObject.GetComponent<CameraController>().MaxForce = maxForce;
    }
}
public class CameraPositionLockerSpawner : EditorWindow
{
    static CameraPositionLockerSpawner window;
    string objectName;
    float maxSpeed;
    float maxForce;
    Vector3 startingPosition;

    GameObject tmp;
    ListsForCustomWindow gameObjetList;

    SerializedObject _objectSO = null;
    ReorderableList _listRE = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280;
    private static Rect _listRect = new Rect(new Vector2(0, 103), _windowsMinSize);

    public static void ShowWindow()
    {
        window = (CameraPositionLockerSpawner)GetWindow(typeof(CameraPositionLockerSpawner));
        window.titleContent.text = "Camera position locker";
        window.minSize = new Vector2(280, 190);
        window.maxSize = new Vector2(290, 600);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            gameObjetList = tmp.GetComponent<ListsForCustomWindow>();
        }

        if (gameObjetList)
        {
            _objectSO = new SerializedObject(gameObjetList);

            _listRE = new ReorderableList(_objectSO, _objectSO.FindProperty("gameObjectList"), true,
                true, true, true);

            _listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Object list");
            _listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Camera position locker";
        maxSpeed = 0.07f;
        maxForce = 0.06f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        maxSpeed = EditorGUILayout.FloatField("Max speed", maxSpeed);
        maxForce = EditorGUILayout.FloatField("Max force", maxForce);
        startingPosition = EditorGUILayout.Vector3Field("Starting position", startingPosition);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE.DoList(_listRect);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }

        GUILayout.Space(_listRE.GetHeight() + 2f);

        if (GUILayout.Button("Create"))
        {
            SpawnCameraLocker();
        }
    }
    private void SpawnCameraLocker()
    {
        GameObject cameraPosotionLockerObject = new GameObject();
        cameraPosotionLockerObject.name = objectName;
        cameraPosotionLockerObject.transform.position = new Vector3(cameraPosotionLockerObject.transform.position.x, cameraPosotionLockerObject.transform.position.y, -10);
        cameraPosotionLockerObject.AddComponent<Camera>();
        cameraPosotionLockerObject.AddComponent<CameraPositionLocker>();
        cameraPosotionLockerObject.GetComponent<CameraPositionLocker>().MaxSpeed = maxSpeed;
        cameraPosotionLockerObject.GetComponent<CameraPositionLocker>().MaxForce = maxForce;
        cameraPosotionLockerObject.GetComponent<CameraPositionLocker>().ObjectList = gameObjetList.GetGameObjectList();
        cameraPosotionLockerObject.GetComponent<CameraPositionLocker>().StartingPosition = startingPosition;
    }
}
public class CursorFollowingSpawner : EditorWindow
{
    static CursorFollowingSpawner window;
    string objectName;
    Object sprite;
    Object referenceCamera;
    public static void ShowWindow()
    {
        window = (CursorFollowingSpawner)GetWindow(typeof(CursorFollowingSpawner));
        window.titleContent.text = "Cursor folowing";
        window.minSize = new Vector2(250, 125);
        window.maxSize = new Vector2(260, 135);
    }
    private void OnGUI()
    {
        objectName = "Runer controller";
        sprite = Resources.Load<Sprite>("Sprites/Player/PlayerShip");
        referenceCamera = Camera.main;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        referenceCamera = EditorGUILayout.ObjectField("Reference camera", referenceCamera, typeof(Camera), true);
        if (GUILayout.Button("Create"))
        {
            SpawnObjectCursorFollowing();
        }
    }
    private void SpawnObjectCursorFollowing()
    {
        GameObject cursorFollowing = new GameObject();
        cursorFollowing.name = objectName;
        cursorFollowing.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            cursorFollowing.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        cursorFollowing.AddComponent<CursorFollowing>();
        cursorFollowing.GetComponent<CursorFollowing>().ReferenceCamera = (Camera)referenceCamera;
    }
}
public class ParalyzeSpawner : EditorWindow
{
    static ParalyzeSpawner window;
    string objectName;
    Object sprite;
    float paralyseTimeLength;
    float maxTimeBetwinParalysing;
    string paralyzerTag;

    GameObject tmp;
    ListsForCustomWindow stringList;

    SerializedObject _objectSO = null;
    ReorderableList _listRE = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280;
    private static Rect _listRect = new Rect(new Vector2(0, 128), _windowsMinSize);

    public static void ShowWindow()
    {
        window = (ParalyzeSpawner)GetWindow(typeof(ParalyzeSpawner));
        window.titleContent.text = "Paralyze";
        window.minSize = new Vector2(283, 215);
        window.maxSize = new Vector2(293, 225);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            stringList = tmp.GetComponent<ListsForCustomWindow>();
            stringList.SetStringList("Player");
        }

        if (stringList)
        {
            _objectSO = new SerializedObject(stringList);

            _listRE = new ReorderableList(_objectSO, _objectSO.FindProperty("listString"), true,
                true, true, true);

            _listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Paralyzer tags");
            _listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Paralyze";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        paralyseTimeLength = 2;
        maxTimeBetwinParalysing = 3;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        paralyseTimeLength = EditorGUILayout.FloatField("Paralyze time length", paralyseTimeLength);
        maxTimeBetwinParalysing = EditorGUILayout.FloatField("Max time betwin paralysing", maxTimeBetwinParalysing);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE.DoList(_listRect);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }

        GUILayout.Space(_listRE.GetHeight());

        if (GUILayout.Button("Create"))
        {
            SpawnParalyze();
        }
    }
    private void SpawnParalyze()
    {
        GameObject paralyzeObject = new GameObject();
        paralyzeObject.name = objectName;
        paralyzeObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            paralyzeObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        paralyzeObject.AddComponent<Rigidbody2D>();
        paralyzeObject.AddComponent<BoxCollider2D>();
        paralyzeObject.AddComponent<Paralyze>();
        paralyzeObject.GetComponent<Paralyze>().ParalyseTimeLength = paralyseTimeLength;
        paralyzeObject.GetComponent<Paralyze>().MaxTimeBetweenParalyzing = maxTimeBetwinParalysing;
        paralyzeObject.GetComponent<Paralyze>().Rb = paralyzeObject.GetComponent<Rigidbody2D>();
        paralyzeObject.GetComponent<Paralyze>().ParalyzerTags = stringList.GetStringList();
    }
}

public class WeaponSpawner : EditorWindow
{
    static WeaponSpawner window;
    string objectName;
    Object sprite;
    bool isForPlayer;
    string fireButton;
    string reloadButton;
    int ammoCapacity;
    int reserveAmmoCapacity;
    int maxAmmoCapacity;
    int proyectilesPerShoot;
    int gunBarrels;
    float angleBetweenProyectiles;
    float reloadTime;
    float fireRate;
    Object shootSound;
    Object reloadSound;
    Object projectile;
    bool reloads;
    bool shootsLaser;

    public static void ShowWindow()
    {
        window = (WeaponSpawner)GetWindow(typeof(WeaponSpawner));
        window.titleContent.text = "Weapon";
        window.minSize = new Vector2(283, 425);
        window.maxSize = new Vector2(293, 435);
    }

    private void OnGUI()
    {
        objectName = "Weapon";
        sprite = Resources.Load<Sprite>("Sprites/Weapons/rifle");
        isForPlayer = true;
        shootsLaser = false;
        fireButton = "Fire1";
        reloadButton = "Fire2";
        ammoCapacity = 5;
        reserveAmmoCapacity = 25;
        maxAmmoCapacity = 35;
        fireRate = 0.7f;
        reloads = true;
        reloadTime = 3;
        proyectilesPerShoot = 1;
        gunBarrels = 1;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        isForPlayer = EditorGUILayout.Toggle("Is for player", isForPlayer);
        shootsLaser = EditorGUILayout.Toggle("Shoots Laser", shootsLaser);
        fireButton = EditorGUILayout.TextField("Fire button", fireButton);
        reloadButton = EditorGUILayout.TextField("Reload button", reloadButton);
        ammoCapacity = EditorGUILayout.IntField("Ammo capacity", ammoCapacity);
        reserveAmmoCapacity = EditorGUILayout.IntField("Reserve ammo capacity", reserveAmmoCapacity);
        maxAmmoCapacity = EditorGUILayout.IntField("Max ammo capacity", maxAmmoCapacity);
        fireRate = EditorGUILayout.FloatField("Fire rate", fireRate);
        reloads = EditorGUILayout.Toggle("Reloads", reloads);
        reloadTime = EditorGUILayout.FloatField("Reload Time", reloadTime);
        proyectilesPerShoot = EditorGUILayout.IntField("Projectiles per shoot", proyectilesPerShoot);
        angleBetweenProyectiles = EditorGUILayout.FloatField("Angle between projectiles", angleBetweenProyectiles);
        shootSound = EditorGUILayout.ObjectField("Shoot sound", shootSound, typeof(AudioClip), true);
        reloadSound = EditorGUILayout.ObjectField("Reload sound", reloadSound, typeof(AudioClip), true);
        projectile = EditorGUILayout.ObjectField("projectile", projectile, typeof(GameObject), true);
        gunBarrels = EditorGUILayout.IntField("Gun barrels", gunBarrels);
        if (GUILayout.Button("Create"))
        {
            SpawnWeapone();
        }
    }
    private void SpawnWeapone()
    {
        GameObject weaponeObject = new GameObject();
        weaponeObject.gameObject.name = objectName;
        weaponeObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            weaponeObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        weaponeObject.AddComponent<AudioSource>();
        weaponeObject.AddComponent<Weapon>();
        weaponeObject.GetComponent<Weapon>().IsForPlayer = isForPlayer;
        weaponeObject.GetComponent<Weapon>().ShootsLaser = shootsLaser;
        weaponeObject.GetComponent<Weapon>().FireButton = fireButton;
        weaponeObject.GetComponent<Weapon>().ReloadButton = reloadButton;
        weaponeObject.GetComponent<Weapon>().AmmoCapacity = ammoCapacity;
        weaponeObject.GetComponent<Weapon>().ReserveAmmoCapacity = reserveAmmoCapacity;
        weaponeObject.GetComponent<Weapon>().MaxAmmoCapacity = maxAmmoCapacity;
        weaponeObject.GetComponent<Weapon>().ProjectilesPerShoot = proyectilesPerShoot;
        weaponeObject.GetComponent<Weapon>().FireRate = fireRate;
        weaponeObject.GetComponent<Weapon>().ReloadTime = reloadTime;
        weaponeObject.GetComponent<Weapon>().AngleBetweenProjectiles = angleBetweenProyectiles;
        weaponeObject.GetComponent<Weapon>().AudioSource = weaponeObject.GetComponent<AudioSource>();
        weaponeObject.GetComponent<Weapon>().Reloads = reloads;
        if (shootSound)
        {
            weaponeObject.GetComponent<Weapon>().ShootSound = (AudioClip)shootSound;
        }
        if (reloadSound)
        {
            weaponeObject.GetComponent<Weapon>().ReloadSound = (AudioClip)reloadSound;
        }
        if (projectile)
        {
            weaponeObject.GetComponent<Weapon>().Projectile = (GameObject)projectile;
        }
        for(int i = 0; i < gunBarrels; i++)
        {
            GameObject gunbarrel = new GameObject();
            gunbarrel.name = objectName + " gun barrel " + (i+1);
            gunbarrel.transform.SetParent(weaponeObject.transform);
            weaponeObject.GetComponent<Weapon>().GunBarrels.Add(gunbarrel);
        }
    }
}
public class MeleeWeaponSpawner : EditorWindow
{
    static MeleeWeaponSpawner window;
    string objectName;
    Object sprite;
    bool isForPlayer;
    float damage;
    string attackButton;
    float swingSpeed;
    float returnSpeed;
    float swingAngle;
    float attackRate;
    Object attackSound;

    public static void ShowWindow()
    {
        window = (MeleeWeaponSpawner)GetWindow(typeof(MeleeWeaponSpawner));
        window.titleContent.text = "Melee weapon";
        window.minSize = new Vector2(283, 265);
        window.maxSize = new Vector2(293, 275);
    }

    private void OnGUI()
    {
        objectName = "Melee weapon";
        sprite = Resources.Load<Sprite>("Sprites/Weapons/Sword");
        isForPlayer = true;
        damage = 5;
        attackButton = "Fire3";
        swingSpeed = 10;
        returnSpeed = 20;
        swingAngle = -60;
        attackRate = 1;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        isForPlayer = EditorGUILayout.Toggle("Is for player", isForPlayer);
        damage = EditorGUILayout.FloatField("Damage", damage);
        attackButton = EditorGUILayout.TextField("Attack button", attackButton);
        swingSpeed = EditorGUILayout.FloatField("Swing speed", swingSpeed);
        returnSpeed = EditorGUILayout.FloatField("Return speed", returnSpeed);
        swingAngle = EditorGUILayout.FloatField("Swing angle", swingAngle);
        attackRate = EditorGUILayout.FloatField("Attack rate", attackRate);
        attackSound = EditorGUILayout.ObjectField("Attack sound", attackSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnMeleeWeapone();
        }
    }
    private void SpawnMeleeWeapone()
    {
        GameObject meleeWeaponeObject = new GameObject();
        meleeWeaponeObject.gameObject.name = objectName;
        meleeWeaponeObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            meleeWeaponeObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        meleeWeaponeObject.AddComponent<BoxCollider2D>();
        meleeWeaponeObject.AddComponent<AudioSource>();
        meleeWeaponeObject.AddComponent<MeleeWeapon>();
        meleeWeaponeObject.GetComponent<MeleeWeapon>().IsForPlayer = isForPlayer;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().Damage = damage;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().AttackButton = attackButton;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().SwingSpeed = swingSpeed;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().ReturnSpeed = returnSpeed;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().SwingAngle = swingAngle;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().AttackRate = attackRate;
        meleeWeaponeObject.GetComponent<MeleeWeapon>().AudioSource = meleeWeaponeObject.GetComponent<AudioSource>();
        if (attackSound)
        {
            meleeWeaponeObject.GetComponent<MeleeWeapon>().AttackSound = (AudioClip)attackSound;
        }
    }
}
public class ProjectileSpawner : EditorWindow
{
    //Esta parte del codigao esta basada en: https://medium.com/nerd-for-tech/how-to-create-a-list-in-a-custom-editor-window-in-unity-e6856e78adfc
    static ProjectileSpawner window;
    string objectName;
    Object sprite;
    float speed;
    float maxDistance;
    float damage;
    Object hitSound;

    GameObject tmp;
    ListsForCustomWindow stringList;

    SerializedObject _objectSO = null;
    ReorderableList _listRE = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280f;
    private static Rect _listRect = new Rect(new Vector2(0,168), _windowsMinSize);
    public static void ShowWindow()
    {
        window = (ProjectileSpawner)GetWindow(typeof(ProjectileSpawner));
        window.titleContent.text = "Projectile";
        window.minSize = new Vector2(283, 255);
        window.maxSize = new Vector2(293, 275);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            stringList = tmp.GetComponent<ListsForCustomWindow>();
            stringList.SetStringList("Player");
        }

        if (stringList)
        {
            _objectSO = new SerializedObject(stringList);

            _listRE = new ReorderableList(_objectSO, _objectSO.FindProperty("listString"), true,
                true, true, true);

            _listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Dont destroy on collision");
            _listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/Bullet 2");
        speed = 6;
        maxDistance = 3;
        damage = 5;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        maxDistance = EditorGUILayout.FloatField("Max distance", maxDistance);
        damage = EditorGUILayout.FloatField("Damage", damage);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE.DoList(_listRect);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }
        
        GUILayout.Space(_listRE.GetHeight() + 1f);

        if (GUILayout.Button("Create"))
        {
            SpawnProjectile();
        }
    }
    private void SpawnProjectile()
    {
        GameObject projectileObject = new GameObject();
        projectileObject.gameObject.name = objectName;
        projectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            projectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        projectileObject.AddComponent<Rigidbody2D>();
        projectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        projectileObject.AddComponent<CircleCollider2D>();
        projectileObject.AddComponent<AudioSource>();
        projectileObject.AddComponent<Projectile>();
        projectileObject.GetComponent<Projectile>().Speed = speed;
        projectileObject.GetComponent<Projectile>().MaxDistance = maxDistance;
        projectileObject.GetComponent<Projectile>().Damage = damage;
        projectileObject.GetComponent<Projectile>().Rb = projectileObject.GetComponent<Rigidbody2D>();
        projectileObject.GetComponent<Projectile>().AudioSource = projectileObject.GetComponent<AudioSource>();

        if (hitSound)
        {
            projectileObject.GetComponent<Projectile>().HitSound = (AudioClip)hitSound;
        }
        projectileObject.GetComponent<Projectile>().DontDestroyOnCollision = stringList.GetStringList();
    }
}
public class BouncieProjectileSpawner : EditorWindow
{
    static BouncieProjectileSpawner window;
    string objectName;
    Object sprite;
    float speed;
    float maxDistance;
    float damage;
    Object hitSound;
    int bounces;
    Object physicsMaterial;

    public static void ShowWindow()
    {
        window = (BouncieProjectileSpawner)GetWindow(typeof(BouncieProjectileSpawner));
        window.titleContent.text = "Bouncie projectile";
        window.minSize = new Vector2(293, 205);
        window.maxSize = new Vector2(303, 213);
    }
    private void OnGUI()
    {
        objectName = "Bouncie projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/BounceBullet");
        speed = 6;
        maxDistance = 3;
        damage = 5;
        bounces = 4;
        physicsMaterial = Resources.Load<PhysicsMaterial2D>("Physics material/Easy Game Feel Bouncie Physics Material 2D");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        maxDistance = EditorGUILayout.FloatField("Max distance", maxDistance);
        damage = EditorGUILayout.FloatField("Damage", damage);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);
        bounces = EditorGUILayout.IntField("Bounces", bounces);
        if (GUILayout.Button("Create"))
        {
            SpawnBouncieProjectile();
        }
    }
    private void SpawnBouncieProjectile()
    {
        GameObject bouncieProjectileObject = new GameObject();
        bouncieProjectileObject.gameObject.name = objectName;
        bouncieProjectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            bouncieProjectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        bouncieProjectileObject.AddComponent<Rigidbody2D>();
        bouncieProjectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        bouncieProjectileObject.AddComponent<CircleCollider2D>();
        bouncieProjectileObject.GetComponent<CircleCollider2D>().sharedMaterial = (PhysicsMaterial2D)physicsMaterial;
        bouncieProjectileObject.AddComponent<AudioSource>();
        bouncieProjectileObject.AddComponent<BouncieProjectile>();
        bouncieProjectileObject.GetComponent<BouncieProjectile>().Speed = speed;
        bouncieProjectileObject.GetComponent<BouncieProjectile>().MaxDistance = maxDistance;
        bouncieProjectileObject.GetComponent<BouncieProjectile>().Damage = damage;
        bouncieProjectileObject.GetComponent<BouncieProjectile>().Bounces = bounces;
        bouncieProjectileObject.GetComponent<BouncieProjectile>().Rb = bouncieProjectileObject.GetComponent<Rigidbody2D>();
        bouncieProjectileObject.GetComponent<BouncieProjectile>().AudioSource = bouncieProjectileObject.GetComponent<AudioSource>();
        if (hitSound)
        {
            bouncieProjectileObject.GetComponent<BouncieProjectile>().HitSound = (AudioClip)hitSound;
        }
    }
}
public class PenetratingProjectileSpawner : EditorWindow
{
    static PenetratingProjectileSpawner window;
    string objectName;
    Object sprite;
    float speed;
    float maxDistance;
    float damage;
    Object hitSound;

    GameObject tmp;
    ListsForCustomWindow stringList;

    SerializedObject _objectSO = null;
    ReorderableList _listRE = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280;
    private static Rect _listRect = new Rect(new Vector2(0, 168), _windowsMinSize);

    public static void ShowWindow()
    {
        window = (PenetratingProjectileSpawner)GetWindow(typeof(PenetratingProjectileSpawner));
        window.titleContent.text = "Penetrating projectile";
        window.minSize = new Vector2(283, 255);
        window.maxSize = new Vector2(303, 600);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            stringList = tmp.GetComponent<ListsForCustomWindow>();
            stringList.SetStringList("Water");
        }

        if (stringList)
        {
            _objectSO = new SerializedObject(stringList);

            _listRE = new ReorderableList(_objectSO, _objectSO.FindProperty("listString"), true,
                true, true, true);

            _listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Paralyzer tags");
            _listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Penetrating projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/Bullet 2");
        speed = 6;
        maxDistance = 3;
        damage = 5;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        maxDistance = EditorGUILayout.FloatField("Max distance", maxDistance);
        damage = EditorGUILayout.FloatField("Damage", damage);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE.DoList(_listRect);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }

        GUILayout.Space(_listRE.GetHeight());

        if (GUILayout.Button("Create"))
        {
            SpawnPenetratingProjectile();
        }
    }
    private void SpawnPenetratingProjectile()
    {
        GameObject penetratingProjectileObject = new GameObject();
        penetratingProjectileObject.gameObject.name = objectName;
        penetratingProjectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            penetratingProjectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        penetratingProjectileObject.AddComponent<Rigidbody2D>();
        penetratingProjectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        penetratingProjectileObject.AddComponent<CircleCollider2D>();
        penetratingProjectileObject.GetComponent<CircleCollider2D>().isTrigger = true;
        penetratingProjectileObject.AddComponent<AudioSource>();
        penetratingProjectileObject.AddComponent<PenetratingProjectile>();
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().Speed = speed;
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().MaxDistance = maxDistance;
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().Damage = damage;
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().Rb = penetratingProjectileObject.GetComponent<Rigidbody2D>();
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().AudioSource = penetratingProjectileObject.GetComponent<AudioSource>();
        penetratingProjectileObject.GetComponent<PenetratingProjectile>().CantPenetrateLayerList = stringList.GetStringList();
        if (hitSound)
        {
            penetratingProjectileObject.GetComponent<PenetratingProjectile>().HitSound = (AudioClip)hitSound;
        }
    }
}

public class PushProjectileSpawner : EditorWindow
{
    static PushProjectileSpawner window;
    string objectName;
    Object sprite;
    float speed;
    float pushForce;
    float maxDistance;
    float damage;
    Object hitSound;
    public static void ShowWindow()
    {
        window = (PushProjectileSpawner)GetWindow(typeof(PushProjectileSpawner));
        window.titleContent.text = "Push projectile";
        window.minSize = new Vector2(300, 205);
        window.maxSize = new Vector2(310, 215);
    }
    private void OnGUI()
    {
        objectName = "Push projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/PushBullet");
        speed = 6;
        pushForce = 5;
        maxDistance = 3;
        damage = 5;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        speed = EditorGUILayout.FloatField("Speed", speed);
        pushForce = EditorGUILayout.FloatField("Push force", pushForce);
        maxDistance = EditorGUILayout.FloatField("Max distance", maxDistance);
        damage = EditorGUILayout.FloatField("Damage", damage);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnPushProjectile();
        }
    }
    private void SpawnPushProjectile()
    {
        GameObject pushProjectileObject = new GameObject();
        pushProjectileObject.gameObject.name = objectName;
        pushProjectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            pushProjectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        pushProjectileObject.AddComponent<Rigidbody2D>();
        pushProjectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        pushProjectileObject.AddComponent<CircleCollider2D>();
        pushProjectileObject.GetComponent<CircleCollider2D>().isTrigger = true;
        pushProjectileObject.AddComponent<AudioSource>();
        pushProjectileObject.AddComponent<PushProjectile>();
        pushProjectileObject.GetComponent<PushProjectile>().Speed = speed;
        pushProjectileObject.GetComponent<PushProjectile>().PushForce = pushForce;
        pushProjectileObject.GetComponent<PushProjectile>().MaxDistance = maxDistance;
        pushProjectileObject.GetComponent<PushProjectile>().Damage = damage;
        pushProjectileObject.GetComponent<PushProjectile>().Rb = pushProjectileObject.GetComponent<Rigidbody2D>();
        pushProjectileObject.GetComponent<PushProjectile>().AudioSource = pushProjectileObject.GetComponent<AudioSource>();
        if (hitSound)
        {
            pushProjectileObject.GetComponent<PushProjectile>().HitSound = (AudioClip)hitSound;
        }
    }
}
public class ExplosiveProjectileSpawner : EditorWindow
{
    static ExplosiveProjectileSpawner window;
    string objectName;
    Object sprite;
    float damage;
    float speed;
    float maxExplosionSize;
    Vector3 explosionGrowtScale;
    float explosionDelay;
    Object explosionSprite;
    Object explosionSound;
    public static void ShowWindow()
    {
        window = (ExplosiveProjectileSpawner)GetWindow(typeof(ExplosiveProjectileSpawner));
        window.titleContent.text = "Explosive projectile";
        window.minSize = new Vector2(300, 310);
        window.maxSize = new Vector2(310, 320);
    }
    private void OnGUI()
    {
        objectName = "Explosive projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/Explosive"); 
        speed = 6;
        damage = 5;
        maxExplosionSize = 4;
        explosionGrowtScale = new Vector3(0.1f, 0.1f, 0.1f);
        explosionDelay = 3;
        explosionSprite = Resources.Load<Sprite>("Sprites/Projectile/Explosion2");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        damage = EditorGUILayout.FloatField("Damage", damage);
        speed = EditorGUILayout.FloatField("speed", speed);
        maxExplosionSize = EditorGUILayout.FloatField("Max explosion size", maxExplosionSize);
        explosionGrowtScale = EditorGUILayout.Vector3Field("Explosion growt scale", explosionGrowtScale);
        explosionDelay = EditorGUILayout.FloatField("Explosion dilay", explosionDelay);
        explosionSprite = EditorGUILayout.ObjectField("Explosion sprite", explosionSprite, typeof(Sprite), true);
        explosionSound = EditorGUILayout.ObjectField("Explosion sound", explosionSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnExplosiveProjectile();
        }
    }
    private void SpawnExplosiveProjectile()
    {
        GameObject explosiveProjectileObject = new GameObject();
        explosiveProjectileObject.gameObject.name = objectName;
        explosiveProjectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            explosiveProjectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        explosiveProjectileObject.AddComponent<Rigidbody2D>();
        explosiveProjectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        explosiveProjectileObject.AddComponent<AudioSource>();
        explosiveProjectileObject.AddComponent<ExplosiveProjectile>();
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().Rb = explosiveProjectileObject.GetComponent<Rigidbody2D>();
        CircleCollider2D tmpCollider = explosiveProjectileObject.AddComponent<CircleCollider2D>();
        tmpCollider.isTrigger = true;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().AudioSource = explosiveProjectileObject.GetComponent<AudioSource>();
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().Damage = damage;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().Speed = speed;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().MaxExplosionSize = maxExplosionSize;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().ExplosionGrowtScale = explosionGrowtScale;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().ExplosionDelay = explosionDelay;
        explosiveProjectileObject.GetComponent<ExplosiveProjectile>().ExplosionSprite = (Sprite)explosionSprite;
        if (explosionSound)
        {
            explosiveProjectileObject.GetComponent<ExplosiveProjectile>().HitSound = (AudioClip)explosionSound;
        }
    }
}
public class LaserProjectileSpawner : EditorWindow
{
    static LaserProjectileSpawner window;
    string objectName;
    Object sprite;
    float damage;
    bool isFromPlayer;
    float positionScale;
    float timeScale;
    Object hitSound;
    public static void ShowWindow()
    {
        window = (LaserProjectileSpawner)GetWindow(typeof(LaserProjectileSpawner));
        window.titleContent.text = "Laser projectile";
        window.minSize = new Vector2(300, 206);
        window.maxSize = new Vector2(310, 216);
    }
    private void OnGUI()
    {
        objectName = "Laser projectile";
        sprite = Resources.Load<Sprite>("Sprites/Projectile/Laser1");
        damage = 5;
        isFromPlayer = true;
        positionScale = 0.03f;
        timeScale = 0.0001f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        damage = EditorGUILayout.FloatField("Damage", damage);
        isFromPlayer = EditorGUILayout.Toggle("Is from player", isFromPlayer);
        positionScale = EditorGUILayout.FloatField("Position scale", positionScale);
        timeScale = EditorGUILayout.FloatField("Time scale", timeScale);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnLazerProjectile();
        }
    }
    private void SpawnLazerProjectile()
    {
        GameObject laserProjectileObject = new GameObject();
        GameObject spriteMaskObject = new GameObject();
        spriteMaskObject.name = "Sprite Mask";
        spriteMaskObject.AddComponent<SpriteMask>();
        spriteMaskObject.transform.SetParent(laserProjectileObject.transform);
        laserProjectileObject.gameObject.name = objectName;
        laserProjectileObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            laserProjectileObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        laserProjectileObject.AddComponent<Rigidbody2D>();
        laserProjectileObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        laserProjectileObject.AddComponent<BoxCollider2D>();
        laserProjectileObject.GetComponent<BoxCollider2D>().isTrigger = true;
        laserProjectileObject.AddComponent<AudioSource>();
        laserProjectileObject.AddComponent<LaserProjectile>();
        laserProjectileObject.GetComponent<LaserProjectile>().LaserBoxCollider = laserProjectileObject.GetComponent<BoxCollider2D>();
        laserProjectileObject.GetComponent<LaserProjectile>().LaserSpriteMask = spriteMaskObject.GetComponent<SpriteMask>();
        laserProjectileObject.GetComponent<LaserProjectile>().Damage = damage;
        laserProjectileObject.GetComponent<LaserProjectile>().IsFromPlayer = isFromPlayer;
        laserProjectileObject.GetComponent<LaserProjectile>().PositionScale = positionScale;
        laserProjectileObject.GetComponent<LaserProjectile>().TimeScale = timeScale;
        laserProjectileObject.GetComponent<LaserProjectile>().AudioSource = laserProjectileObject.GetComponent<AudioSource>();
        if (hitSound)
        {
            laserProjectileObject.GetComponent<LaserProjectile>().HitSound = (AudioClip)hitSound;
        }
    }
}
public class LaserProjectileLineRendererSpawner : EditorWindow
{
    static LaserProjectileLineRendererSpawner window;
    string objectName;
    Object material;
    float maxRange;
    float damage;
    bool isFromPlayer;
    Object hitSound;
    public static void ShowWindow()
    {
        window = (LaserProjectileLineRendererSpawner)GetWindow(typeof(LaserProjectileLineRendererSpawner));
        window.titleContent.text = "Laser projectile with line renderer";
        window.minSize = new Vector2(300, 139);
        window.maxSize = new Vector2(310, 149);
    }
    private void OnGUI()
    {
        objectName = "Laser projectile with line renderer";
        damage = 5;
        isFromPlayer = true;
        material = Resources.Load<Material>("Material/LaserLineRendererMaterial");
        maxRange = 4;

        objectName = EditorGUILayout.TextField("Name", objectName);
        material = EditorGUILayout.ObjectField("Material", material, typeof(Material), true);
        maxRange = EditorGUILayout.FloatField("Max range", maxRange);
        damage = EditorGUILayout.FloatField("Damage", damage);
        isFromPlayer = EditorGUILayout.Toggle("Is from player", isFromPlayer);
        hitSound = EditorGUILayout.ObjectField("Hit sound", hitSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnLazerProjectileLineRenderer();
        }
    }
    private void SpawnLazerProjectileLineRenderer()
    {
        GameObject laserProjectileObject = new GameObject();
        GameObject hitObject = new GameObject();
        hitObject.name = objectName + " hit object";
        hitObject.transform.SetParent(laserProjectileObject.transform);
        hitObject.AddComponent<CircleCollider2D>();
        hitObject.AddComponent<ProjectileFather>();
        hitObject.AddComponent<Rigidbody2D>();
        hitObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        hitObject.GetComponent<ProjectileFather>().Damage = damage;
        hitObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        hitObject.GetComponent<CircleCollider2D>().isTrigger = true;
        hitObject.GetComponent<CircleCollider2D>().radius = 0.5f;
        hitObject.transform.position += new Vector3(0, 0, -10);
        laserProjectileObject.gameObject.name = objectName;
        laserProjectileObject.AddComponent<LineRenderer>();
        if (material != null)
        {
            laserProjectileObject.GetComponent<LineRenderer>().material = (Material)material;
        }
        laserProjectileObject.AddComponent<AudioSource>();
        laserProjectileObject.AddComponent<LaserProjectileLineRenderer>();
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().MaxRange = maxRange;
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().Damage = damage;
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().IsFromPlayer = isFromPlayer;
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().HitObject = hitObject;
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().LaserLineRenderer = laserProjectileObject.GetComponent<LineRenderer>();
        laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().AudioSource = laserProjectileObject.GetComponent<AudioSource>();
        if (hitSound)
        {
            laserProjectileObject.GetComponent<LaserProjectileLineRenderer>().HitSound = (AudioClip)hitSound;
        }
    }
}
public class DestroyableObjectSpawner : EditorWindow
{
    static DestroyableObjectSpawner window;
    string objectName;
    Object sprite;
    float hitPoints;
    float delay;
    bool spawnsElement;
    bool leavesBrokenPieces;
    string collisionTag;
    public static void ShowWindow()
    {
        window = (DestroyableObjectSpawner)GetWindow(typeof(DestroyableObjectSpawner));
        window.titleContent.text = "Destroyable object";
        window.minSize = new Vector2(300, 204);
        window.maxSize = new Vector2(310, 214);
    }
    private void OnGUI()
    {
        objectName = "Destroyable object";
        sprite = Resources.Load<Sprite>("Sprites/Objects/Barrel");
        hitPoints = 4;
        delay = 3;
        collisionTag = "Player";

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        hitPoints = EditorGUILayout.FloatField("Hit points", hitPoints);
        delay = EditorGUILayout.FloatField("Delay", delay);
        spawnsElement = EditorGUILayout.Toggle("Spawns elements", spawnsElement);
        leavesBrokenPieces = EditorGUILayout.Toggle("Leaves broken pieces", leavesBrokenPieces);
        collisionTag = EditorGUILayout.TextField("Collision tag", collisionTag);
        if (GUILayout.Button("Create"))
        {
            SpawnDestroyableBox();
        }
    }
    private void SpawnDestroyableBox()
    {
        GameObject destroyableBoxObject = new GameObject();
        destroyableBoxObject.gameObject.name = objectName;
        destroyableBoxObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            destroyableBoxObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        destroyableBoxObject.AddComponent<Rigidbody2D>();
        destroyableBoxObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        destroyableBoxObject.AddComponent<BoxCollider2D>();
        destroyableBoxObject.AddComponent<DestroyableObject>();
        destroyableBoxObject.GetComponent<DestroyableObject>().HitPoints = hitPoints;
        destroyableBoxObject.GetComponent<DestroyableObject>().Delay = delay;
        destroyableBoxObject.GetComponent<DestroyableObject>().SpawnsElements = spawnsElement;
        destroyableBoxObject.GetComponent<DestroyableObject>().LeavesBrokenPieces = leavesBrokenPieces;
        destroyableBoxObject.GetComponent<DestroyableObject>().CollisionTag = collisionTag;
    }
}
public class ExplosiveObjectSpawner : EditorWindow
{
    static ExplosiveObjectSpawner window;
    string objectName;
    Object sprite;
    float damage;
    float maxExplosionSize;
    Vector3 explosionGrowtScale;
    float explosionDelay;
    string collisionTag;
    Object explosionSprite;
    Object explosionSound;
    public static void ShowWindow()
    {
        window = (ExplosiveObjectSpawner)GetWindow(typeof(ExplosiveObjectSpawner));
        window.titleContent.text = "Explosive object";
        window.minSize = new Vector2(300, 310);
        window.maxSize = new Vector2(310, 320);
    }
    private void OnGUI()
    {
        objectName = "Explosive object";
        sprite = Resources.Load<Sprite>("Sprites/Objects/Explosive barrel");
        damage = 5;
        maxExplosionSize = 4;   
        explosionGrowtScale = new Vector3(0.1f, 0.1f, 0.1f);
        explosionDelay = 3;
        collisionTag = "Player";
        explosionSprite = Resources.Load<Sprite>("Sprites/Projectile/Explosion2");

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        explosionSprite = EditorGUILayout.ObjectField("Explosion sprite", explosionSprite, typeof(Sprite), true);
        damage = EditorGUILayout.FloatField("Damage", damage);
        maxExplosionSize = EditorGUILayout.FloatField("Max explosion Size", maxExplosionSize);
        explosionGrowtScale = EditorGUILayout.Vector3Field("Explosion growt scale", explosionGrowtScale);
        explosionDelay = EditorGUILayout.FloatField("Explosion dilay", explosionDelay);
        collisionTag = EditorGUILayout.TextField("Collision tag", collisionTag);
        explosionSound = EditorGUILayout.ObjectField("Explosion sound", explosionSound, typeof(AudioClip), true);
        if (GUILayout.Button("Create"))
        {
            SpawnExplosiveObject();
        }
    }
    private void SpawnExplosiveObject()
    {
        GameObject explosiveObject = new GameObject();
        explosiveObject.gameObject.name = objectName;
        explosiveObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            explosiveObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        explosiveObject.AddComponent<AudioSource>();
        explosiveObject.AddComponent<Rigidbody2D>();
        explosiveObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        explosiveObject.AddComponent<BoxCollider2D>();
        explosiveObject.AddComponent<CircleCollider2D>();
        explosiveObject.AddComponent<ExplosiveObject>();
        explosiveObject.GetComponent<CircleCollider2D>().isTrigger = true;
        explosiveObject.GetComponent<ExplosiveObject>().AudioSource = explosiveObject.GetComponent<AudioSource>();
        explosiveObject.GetComponent<ExplosiveObject>().Damage = damage;
        explosiveObject.GetComponent<ExplosiveObject>().MaxExplosionSize = maxExplosionSize;
        explosiveObject.GetComponent<ExplosiveObject>().ExplosionGrowtScale = explosionGrowtScale;
        explosiveObject.GetComponent<ExplosiveObject>().ExplosionDelay = explosionDelay;
        explosiveObject.GetComponent<ExplosiveObject>().CollisionTag = collisionTag;
        explosiveObject.GetComponent<ExplosiveObject>().ExplosionSprite = (Sprite)explosionSprite;
        explosiveObject.GetComponent<ExplosiveObject>().BoxCollider = explosiveObject.GetComponent<BoxCollider2D>();
        explosiveObject.GetComponent<ExplosiveObject>().ExplosionSound = (AudioClip)explosionSound;
    }
}
public class PushableObjectSpawner : EditorWindow
{
    static PushableObjectSpawner window;
    string objectName;
    Object sprite;
    float force;
    float objectWide;
    string pushButton;
    Object player;
    public static void ShowWindow()
    {
        window = (PushableObjectSpawner)GetWindow(typeof(PushableObjectSpawner));
        window.titleContent.text = "Pushable object";
        window.minSize = new Vector2(300, 185);
        window.maxSize = new Vector2(310, 195);
    }
    private void OnGUI()
    {
        objectName = "Pushable object";
        sprite = Resources.Load<Sprite>("Sprites/Objects/Barrel");
        force = 5;
        objectWide = 0.25f;
        pushButton = "Submit";

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        force = EditorGUILayout.FloatField("Force", force);
        objectWide = EditorGUILayout.FloatField("Object wide", objectWide);
        pushButton = EditorGUILayout.TextField("Push button", pushButton);
        player = EditorGUILayout.ObjectField("Player", player, typeof(GameObject), true);
        if (GUILayout.Button("Create"))
        {
            SpawnPushableObject();
        }
    }
    private void SpawnPushableObject()
    {
        GameObject pushableObject = new GameObject();
        pushableObject.gameObject.name = objectName;
        pushableObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            pushableObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        pushableObject.AddComponent<Rigidbody2D>();
        pushableObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        pushableObject.AddComponent<BoxCollider2D>();
        pushableObject.AddComponent<PushableObject>();
        pushableObject.GetComponent<PushableObject>().Rb = pushableObject.GetComponent<Rigidbody2D>();
        pushableObject.GetComponent<PushableObject>().Force = force;
        pushableObject.GetComponent<PushableObject>().ObjectWide = objectWide;
        pushableObject.GetComponent<PushableObject>().PushButton = pushButton;
        pushableObject.GetComponent<PushableObject>().Player = (GameObject)player;
    }
}
public class MagneticObjectSpawner : EditorWindow
{
    static MagneticObjectSpawner window;
    string objectName;
    Object sprite;
    float maxSpeed;
    float maxForce;
    float minDistance;
    float distanceToChangeState;
    float delay;
    bool active;
    Object objectiveObject;
    public static void ShowWindow()
    {
        window = (MagneticObjectSpawner)GetWindow(typeof(MagneticObjectSpawner));
        window.titleContent.text = "Magnetic object";
        window.minSize = new Vector2(300, 245);
        window.maxSize = new Vector2(310, 255);
    }
    private void OnGUI()
    {
        objectName = "Magnetic object";
        sprite = Resources.Load<Sprite>("Sprites/Objects/Gem");
        maxSpeed = 0.07f;
        maxForce = 0.06f;
        minDistance = 1;
        distanceToChangeState = 0.1f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        maxSpeed = EditorGUILayout.FloatField("Max speed", maxSpeed);
        maxForce = EditorGUILayout.FloatField("Max force", maxForce);
        minDistance = EditorGUILayout.FloatField("Min distance to activate", minDistance);
        distanceToChangeState = EditorGUILayout.FloatField("Distance to change steering behaviour", distanceToChangeState);
        delay = EditorGUILayout.FloatField("Delay", delay);
        active = EditorGUILayout.Toggle("Active", active);
        objectiveObject = EditorGUILayout.ObjectField("Objective object", objectiveObject, typeof(GameObject), true);
        if (GUILayout.Button("Create"))
        {
            SpawnMagneticObject();
        }
    }
    private void SpawnMagneticObject()
    {
        GameObject pushableObject = new GameObject();
        pushableObject.gameObject.name = objectName;
        pushableObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            pushableObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        pushableObject.AddComponent<Rigidbody2D>();
        pushableObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        pushableObject.AddComponent<BoxCollider2D>();
        pushableObject.AddComponent<MagneticObject>();
        pushableObject.GetComponent<MagneticObject>().MaxSpeed = maxSpeed;
        pushableObject.GetComponent<MagneticObject>().MaxForce = maxForce;
        pushableObject.GetComponent<MagneticObject>().MinDistance = minDistance;
        pushableObject.GetComponent<MagneticObject>().DistanceToChangeState = distanceToChangeState;
        pushableObject.GetComponent<MagneticObject>().Delay = delay;
        pushableObject.GetComponent<MagneticObject>().Active = active;
        pushableObject.GetComponent<MagneticObject>().ObjectiveObject = (GameObject)objectiveObject;
    }
}
public class HitStopSpawner : EditorWindow
{
    static HitStopSpawner window;
    string objectName;
    Object sprite;
    float stopLength;
    bool active;
    public static void ShowWindow()
    {
        window = (HitStopSpawner)GetWindow(typeof(HitStopSpawner));
        window.titleContent.text = "Hit stop";
        window.minSize = new Vector2(300, 145);
        window.maxSize = new Vector2(310, 155);
    }
    private void OnGUI()
    {
        objectName = "Hit stop";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        stopLength = 0.5f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        stopLength = EditorGUILayout.FloatField("Stop length", stopLength);
        active = EditorGUILayout.Toggle("Active", active);
        if (GUILayout.Button("Create"))
        {
            SpawnHitStop();
        }
    }
    private void SpawnHitStop()
    {
        GameObject hitStopObject = new GameObject();
        hitStopObject.gameObject.name = objectName;
        hitStopObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            hitStopObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        hitStopObject.AddComponent<HitStop>();
        hitStopObject.GetComponent<HitStop>().StopLength = stopLength;
        hitStopObject.GetComponent<HitStop>().Active = active;
    }
}
public class ScreenShakeSpawner : EditorWindow
{
    static ScreenShakeSpawner window;
    string objectName;
    Object sprite;
    float force;
    float shakeTime;
    float shakeMovementRange;
    bool active;
    public static void ShowWindow()
    {
        window = (ScreenShakeSpawner)GetWindow(typeof(ScreenShakeSpawner));
        window.titleContent.text = "Screen shake";
        window.minSize = new Vector2(300, 185);
        window.maxSize = new Vector2(310, 195);
    }
    private void OnGUI()
    {
        objectName = "Screen shake";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        force = 0.05f;
        shakeTime = 0.5f;
        shakeMovementRange = 1;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        force = EditorGUILayout.FloatField("Force", force);
        shakeTime = EditorGUILayout.FloatField("Shake time", shakeTime);
        shakeMovementRange = EditorGUILayout.FloatField("Shake movement range", shakeMovementRange);
        active = EditorGUILayout.Toggle("Active", active);
        if (GUILayout.Button("Create"))
        {
            SpawnScreenShake();
        }
    }
    private void SpawnScreenShake()
    {
        GameObject hitStopObject = new GameObject();
        hitStopObject.gameObject.name = objectName;
        hitStopObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            hitStopObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        hitStopObject.AddComponent<ScreenShake>();
        hitStopObject.GetComponent<ScreenShake>().Force = force;
        hitStopObject.GetComponent<ScreenShake>().ShakeTime = shakeTime;
        hitStopObject.GetComponent<ScreenShake>().ShakeMovementRange = shakeMovementRange;
        hitStopObject.GetComponent<ScreenShake>().Active = active;
    }
}
public class ScaleTimeSpawner : EditorWindow
{
    static ScaleTimeSpawner window;
    string objectName;
    Object sprite;
    float scaleTimeLength;
    float scaleTimeTo;
    bool active;
    public static void ShowWindow()
    {
        window = (ScaleTimeSpawner)GetWindow(typeof(ScaleTimeSpawner));
        window.titleContent.text = "Scale time";
        window.minSize = new Vector2(300, 165);
        window.maxSize = new Vector2(310, 175);
    }
    private void OnGUI()
    {
        objectName = "Scale time";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        scaleTimeLength = 0.6f;
        scaleTimeTo = 0.5f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        scaleTimeLength = EditorGUILayout.FloatField("Scale time length", scaleTimeLength);
        scaleTimeTo = EditorGUILayout.FloatField("Scale time to", scaleTimeTo);
        active = EditorGUILayout.Toggle("Active", active);
        if (GUILayout.Button("Create"))
        {
            SpawnScaleTime();
        }
    }
    private void SpawnScaleTime()
    {
        GameObject scaleTimeObject = new GameObject();
        scaleTimeObject.gameObject.name = objectName;
        scaleTimeObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            scaleTimeObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        scaleTimeObject.AddComponent<ScaleTime>();
        scaleTimeObject.GetComponent<ScaleTime>().ScaleTimeLength = scaleTimeLength;
        scaleTimeObject.GetComponent<ScaleTime>().ScaleTimeTo = scaleTimeTo;
        scaleTimeObject.GetComponent<ScaleTime>().Active = active;
    }
}
public class ScreenChangeAcordingToHPSpawner : EditorWindow
{
    static ScreenChangeAcordingToHPSpawner window;
    string objectName;

    GameObject tmp;
    ListsForCustomWindow lists;

    SerializedObject _objectSO = null;
    ReorderableList _listRE1 = null;
    ReorderableList _listRE2 = null;
    ReorderableList _listRE3 = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280f;

    private static Rect _listRect1 = new Rect(new Vector2(0, 23), _windowsMinSize);
    private static Rect _listRect2 = new Rect(new Vector2(283, 23), _windowsMinSize);
    private static Rect _listRect3 = new Rect(new Vector2(566, 23), _windowsMinSize);

    public static void ShowWindow()
    {
        window = (ScreenChangeAcordingToHPSpawner)GetWindow(typeof(ScreenChangeAcordingToHPSpawner));
        window.titleContent.text = "Screen change acording to HP";
        window.minSize = new Vector2(850, 160);
        window.maxSize = new Vector2(860, 195);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            lists = tmp.GetComponent<ListsForCustomWindow>();
            lists.SetFloatList(50, 25, 10);
        }

        if (lists)
        {
            _objectSO = new SerializedObject(lists);

            _listRE1 = new ReorderableList(_objectSO, _objectSO.FindProperty("listFloat"), true,
                true, true, true);
            _listRE2 = new ReorderableList(_objectSO, _objectSO.FindProperty("gameObjectList"), true,
                true, true, true);
            _listRE3 = new ReorderableList(_objectSO, _objectSO.FindProperty("audioClipList"), true,
                true, true, true);

            _listRE1.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Hp values");
            _listRE2.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "State image list");
            _listRE3.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "State sound list");

            _listRE1.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE1.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
            _listRE2.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE2.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
            _listRE3.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE3.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Screen change acording to HP";
        objectName = EditorGUILayout.TextField("Name", objectName);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE1.DoList(_listRect1);
            _listRE2.DoList(_listRect2);
            _listRE3.DoList(_listRect3);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }

        float[] tmpList = { _listRE1.GetHeight(), _listRE2.GetHeight(), _listRE3.GetHeight() };
        float highestValue = tmpList[0]; 
        for (int i = 0; i < 3; i++){
            if (tmpList[i] > highestValue)
            {
                highestValue = tmpList[i];
            }
        }

        GUILayout.Space(highestValue + 3);

        if (GUILayout.Button("Create"))
        {
            SpawnScreenChangeAcordingToHP();
        }
    }
    private void SpawnScreenChangeAcordingToHP()
    {
        GameObject scaleTimeObject = new GameObject();
        scaleTimeObject.gameObject.name = objectName;
        scaleTimeObject.AddComponent<Canvas>();
        scaleTimeObject.AddComponent<CanvasScaler>();
        scaleTimeObject.AddComponent<GraphicRaycaster>();
        scaleTimeObject.AddComponent<AudioSource>();
        scaleTimeObject.AddComponent<ScreenChangeAcordingToHP>();
        scaleTimeObject.GetComponent<ScreenChangeAcordingToHP>().AudioSource = scaleTimeObject.GetComponent<AudioSource>();
        scaleTimeObject.GetComponent<ScreenChangeAcordingToHP>().HpValues = lists.GetFloatList();
        scaleTimeObject.GetComponent<ScreenChangeAcordingToHP>().StateImageList = lists.GetGameObjectList();
        scaleTimeObject.GetComponent<ScreenChangeAcordingToHP>().StateSoundList = lists.GetAudioClipList();
    }
}
public class VibrateObjectSpawner : EditorWindow
{
    static VibrateObjectSpawner window;
    string objectName;
    Object sprite;
    float force;
    float shakeTime;
    float shakeMovementRange;
    bool active;
    public static void ShowWindow()
    {
        window = (VibrateObjectSpawner)GetWindow(typeof(VibrateObjectSpawner));
        window.titleContent.text = "Vibrate object";
        window.minSize = new Vector2(300, 185);
        window.maxSize = new Vector2(310, 195);
    }
    private void OnGUI()
    {
        objectName = "Vibrate object";
        sprite = Resources.Load<Sprite>("Sprites/Player/player");
        force = 0.03f;  
        shakeTime = 0.5f;
        shakeMovementRange = 0.03f;

        objectName = EditorGUILayout.TextField("Name", objectName);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        force = EditorGUILayout.FloatField("Force", force);
        shakeTime = EditorGUILayout.FloatField("Shake time", shakeTime);
        shakeMovementRange = EditorGUILayout.FloatField("Shake movement range", shakeMovementRange);
        active = EditorGUILayout.Toggle("Active", active);
        if (GUILayout.Button("Create"))
        {
            SpawnVibrateObject();
        }
    }
    private void SpawnVibrateObject()
    {
        GameObject vibrateObjectObject = new GameObject();
        vibrateObjectObject.gameObject.name = objectName;
        vibrateObjectObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            vibrateObjectObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        vibrateObjectObject.AddComponent<VibrateObject>();
        vibrateObjectObject.GetComponent<VibrateObject>().Force = force;
        vibrateObjectObject.GetComponent<VibrateObject>().ShakeTime = shakeTime;
        vibrateObjectObject.GetComponent<VibrateObject>().ShakeMovementRange = shakeMovementRange;
        vibrateObjectObject.GetComponent<VibrateObject>().Active = active;
    }
}
public class SoundAcordingToSurfaceSpawner : EditorWindow
{
    static SoundAcordingToSurfaceSpawner window;
    string objectName;
    float extraAudioLength;
    Object sprite;
    Object collisionSound;
    Object exitCollisionSound;

    GameObject tmp;
    ListsForCustomWindow stringList;

    SerializedObject _objectSO = null;
    ReorderableList _listRE = null;

    private static Vector2 _windowsMinSize = Vector2.one * 280f;

    private static Rect _listRect = new Rect(new Vector2(0, 148), _windowsMinSize);

    public static void ShowWindow()
    {
        window = (SoundAcordingToSurfaceSpawner)GetWindow(typeof(SoundAcordingToSurfaceSpawner));
        window.titleContent.text = "Sound player acording to surface";
        window.minSize = new Vector2(283, 235);
        window.maxSize = new Vector2(310, 250);
    }

    private void OnEnable()
    {
        CreateList();
    }

    private void CreateList()
    {
        if (tmp == null)
        {
            tmp = new GameObject();
            tmp.AddComponent<ListsForCustomWindow>();

            stringList = tmp.GetComponent<ListsForCustomWindow>();
            stringList.SetStringList("Player");
        }

        if (stringList)
        {
            _objectSO = new SerializedObject(stringList);

            _listRE = new ReorderableList(_objectSO, _objectSO.FindProperty("listString"), true,
                true, true, true);

            _listRE.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Can play audio tags");

            _listRE.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                rect.y += 2f;
                rect.height = EditorGUIUtility.singleLineHeight;
                GUIContent objectLabel = new GUIContent($"GameObject {index}");
                EditorGUI.PropertyField(rect, _listRE.serializedProperty.GetArrayElementAtIndex(index), objectLabel);
            };
        }
    }

    private void OnDestroy()
    {
        DestroyImmediate(tmp);
    }

    private void OnGUI()
    {
        objectName = "Sound acording to surface";
        extraAudioLength = 0.6f;
        sprite = Resources.Load<Sprite>("Sprites/Objects/Barrel");

        objectName = EditorGUILayout.TextField("Name", objectName);
        extraAudioLength = EditorGUILayout.FloatField("Extra audio length", extraAudioLength);
        sprite = EditorGUILayout.ObjectField("Sprite", sprite, typeof(Sprite), true);
        collisionSound = EditorGUILayout.ObjectField("Collision sound", collisionSound, typeof(AudioClip), true);
        exitCollisionSound = EditorGUILayout.ObjectField("Exit collision sound", exitCollisionSound, typeof(AudioClip), true);

        if (_objectSO != null && tmp != null)
        {
            _objectSO.Update();
            _listRE.DoList(_listRect);
            _objectSO.ApplyModifiedProperties();
        }
        else
        {
            CreateList();
        }

        GUILayout.Space(_listRE.GetHeight());

        if (GUILayout.Button("Create"))
        {
            SpawnSoundAcordingToSurface();
        }
    }
    private void SpawnSoundAcordingToSurface()
    {
        GameObject soundAcordingToSurfaceObject = new GameObject();
        soundAcordingToSurfaceObject.gameObject.name = objectName;
        soundAcordingToSurfaceObject.AddComponent<SpriteRenderer>();
        if (sprite != null)
        {
            soundAcordingToSurfaceObject.GetComponent<SpriteRenderer>().sprite = (Sprite)sprite;
        }
        soundAcordingToSurfaceObject.AddComponent<AudioSource>();
        soundAcordingToSurfaceObject.AddComponent<BoxCollider2D>();
        soundAcordingToSurfaceObject.AddComponent<SoundAcordingToSurface>();
        soundAcordingToSurfaceObject.GetComponent<SoundAcordingToSurface>().CanPlayAudioTags = stringList.GetStringList();
        soundAcordingToSurfaceObject.GetComponent<SoundAcordingToSurface>().ExtraAudioLength = extraAudioLength;
        soundAcordingToSurfaceObject.GetComponent<SoundAcordingToSurface>().AudioSource = soundAcordingToSurfaceObject.GetComponent<AudioSource>();
        if (collisionSound != null)
        {
            soundAcordingToSurfaceObject.GetComponent<SoundAcordingToSurface>().CollisionSound = (AudioClip)collisionSound;
        }
        if (exitCollisionSound != null)
        {
            soundAcordingToSurfaceObject.GetComponent<SoundAcordingToSurface>().ExitCollisionSound = (AudioClip)exitCollisionSound;
        }
    }
}