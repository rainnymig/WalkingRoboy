using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridge;

namespace RoboyWalk
{
    public class GroundsManager : Singleton<GroundsManager>
    {
        public KeyCode CarpetKey;
        public KeyCode StoneKey;
        public KeyCode MetalKey;
        public KeyCode RubberKey;
        public KeyCode WoodKey;
        public KeyCode CorkKey;
        public KeyCode FeltKey;
        public KeyCode ResetKey;

        public CameraController CamController;

        [SerializeField]
        private List<GameObject> m_GroundUnitPrefabs;
        [SerializeField]
        private GameObject m_RoboyPrefab;

        private Dictionary<string, GameObject> m_GroundUnitDict;
        private GameObject m_CurrentGroundUnit;

        private GameObject m_Roboy;

        private const string CARPET = "carpet";
        private const string STONE = "stone";
        private const string METAL = "metal";
        private const string RUBBER = "rubber";
        private const string WOOD = "wood";
        private const string CORK = "cork";
        private const string FELT = "felt";

        private void Awake()
        {
            m_GroundUnitDict = new Dictionary<string, GameObject>();
            m_GroundUnitDict.Add(CARPET, m_GroundUnitPrefabs[0]);
            m_GroundUnitDict.Add(STONE, m_GroundUnitPrefabs[1]);
            m_GroundUnitDict.Add(METAL, m_GroundUnitPrefabs[2]);
            m_GroundUnitDict.Add(RUBBER, m_GroundUnitPrefabs[3]);
            m_GroundUnitDict.Add(WOOD, m_GroundUnitPrefabs[4]);
            m_GroundUnitDict.Add(CORK, m_GroundUnitPrefabs[5]);
            m_GroundUnitDict.Add(FELT, m_GroundUnitPrefabs[6]);

            m_CurrentGroundUnit = m_GroundUnitDict[RUBBER];
            UIManager.Instance.ShowInfo(RUBBER);
        }

        private void Start()
        {
            ResetScene();
        }

        private void Update()
        {
            if (Input.GetKeyDown(CarpetKey))
            {
                ChangeGround(CARPET);
            }
            if (Input.GetKeyDown(StoneKey))
            {
                ChangeGround(STONE);
            }
            if (Input.GetKeyDown(MetalKey))
            {
                ChangeGround(METAL);
            }
            if (Input.GetKeyDown(RubberKey))
            {
                ChangeGround(RUBBER);
            }
            if (Input.GetKeyDown(WoodKey))
            {
                ChangeGround(WOOD);
            }
            if (Input.GetKeyDown(CorkKey))
            {
                ChangeGround(CORK);
            }
            if (Input.GetKeyDown(FeltKey))
            {
                ChangeGround(FELT);
            }
            if (Input.GetKeyDown(ResetKey))
            {
                ResetScene();
            }
        }

        public void ChangeGround(string groundName)
        {
            if (m_GroundUnitDict.ContainsKey(groundName))
            {
                SwitchGround(groundName);
                ResetScene();
                UIManager.Instance.ShowInfo(groundName);
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