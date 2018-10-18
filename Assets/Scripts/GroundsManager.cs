using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridge;

namespace RoboyWalk
{
    public class GroundsManager : Singleton<GroundsManager>
    {
        public KeyCode GrassKey;
        public KeyCode IceKey;
        public KeyCode MetalKey;
        public KeyCode RubberKey;
        public KeyCode WoodKey;
        public KeyCode ResetKey;

        public CameraController CamController;

        [SerializeField]
        private List<GameObject> m_GroundUnitPrefabs;
        [SerializeField]
        private GameObject m_RoboyPrefab;

        private Dictionary<string, GameObject> m_GroundUnitDict;
        private GameObject m_CurrentGroundUnit;

        private GameObject m_Roboy;

        private const string GRASS = "grass";
        private const string ICE = "ice";
        private const string METAL = "metal";
        private const string RUBBER = "rubber";
        private const string WOOD = "wood";

        private void Awake()
        {
            m_GroundUnitDict = new Dictionary<string, GameObject>();
            m_GroundUnitDict.Add(GRASS, m_GroundUnitPrefabs[0]);
            m_GroundUnitDict.Add(ICE, m_GroundUnitPrefabs[1]);
            m_GroundUnitDict.Add(METAL, m_GroundUnitPrefabs[2]);
            m_GroundUnitDict.Add(RUBBER, m_GroundUnitPrefabs[3]);
            m_GroundUnitDict.Add(WOOD, m_GroundUnitPrefabs[4]);

            m_CurrentGroundUnit = m_GroundUnitDict[RUBBER];
            UIManager.Instance.ShowInfo("Rubber");
        }

        private void Start()
        {
            ResetScene();
        }

        private void Update()
        {
            if (Input.GetKeyDown(GrassKey))
            {
                SwitchGround(GRASS);
                ResetScene();
                UIManager.Instance.ShowInfo("Grass");
            }
            if (Input.GetKeyDown(IceKey))
            {
                SwitchGround(ICE);
                ResetScene();
                UIManager.Instance.ShowInfo("Ice");
            }
            if (Input.GetKeyDown(MetalKey))
            {
                SwitchGround(METAL);
                ResetScene();
                UIManager.Instance.ShowInfo("Metal");
            }
            if (Input.GetKeyDown(RubberKey))
            {
                SwitchGround(RUBBER);
                ResetScene();
                UIManager.Instance.ShowInfo("Rubber");
            }
            if (Input.GetKeyDown(WoodKey))
            {
                SwitchGround(WOOD);
                ResetScene();
                UIManager.Instance.ShowInfo("Wood");
            }
            if (Input.GetKeyDown(ResetKey))
            {
                ResetScene();
            }
        }

        public GameObject MakeNewGround()
        {
            return Instantiate(m_CurrentGroundUnit, transform);
        }
        
        public void SwitchGround(string groundName)
        {
            m_CurrentGroundUnit = m_GroundUnitDict[groundName];
        }

        public void ResetScene()
        {
            //  destroy all existing GroundUnits and random objects
            GameObject[] groundUnits = GameObject.FindGameObjectsWithTag("GroundUnit");
            foreach (GameObject g in groundUnits)
            {
                Destroy(g);
            }

            GameObject[] randomObjs = GameObject.FindGameObjectsWithTag("RandomObject");
            foreach (GameObject ranObj in randomObjs)
            {
                Destroy(ranObj);
            }

            //  create a new GroundUnit and Roboy at the origin
            GameObject ground = Instantiate(m_CurrentGroundUnit, transform);
            ground.transform.position = new Vector3(0f, 0f, 0f);

            if (m_Roboy != null)
            {
                Destroy(m_Roboy);
            }
            CamController.ClearRoboy();
            m_Roboy = Instantiate(m_RoboyPrefab);
            m_Roboy.transform.position = new Vector3(0f, 0.255f, 0f);
            m_Roboy.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        protected GroundsManager() { }

    }
}