using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROSBridge.Demo
{
    /// <summary>
    /// Demonstration of how we can use a publisher and subscriber to control an object through ROS.
    /// </summary>
    public class DemoManager : Singleton<DemoManager>
    {
        [Tooltip("Transform component of the tortoise which will be moved via user input")]
        [SerializeField]
        private Transform Tortoise;

        /// <summary>
        /// The coordinate system in the turtlesim starts at the top left corner and is 11 units tall. Therefore the postion (5.544, 5.544) is the default position.
        /// So we need to subtract this Offset in Unity to show the same position.
        /// </summary>
        private float m_PositionOffset = 5.544f;

        // Update is called once per frame
        void Update()
        {
            // get input from user
            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            SendVelocity(inputV, inputH);
        }

        /// <summary>
        /// Publish velocity to turtlesim through the ROSBridge
        /// </summary>
        /// <param name="linearInput"></param>
        /// <param name="angularInput"></param>
        public void SendVelocity(float linearInput, float angularInput)
        {
            Vector3Msg linearVelocity = new Vector3Msg(linearInput, 0f, 0f);
            Vector3Msg angularVelocity = new Vector3Msg(0f, 0f, -angularInput);
            TwistMsg msg = new TwistMsg(linearVelocity, angularVelocity);
            ROSBridge.Instance.Publish(TurtleVelocityPublisher.GetMessageTopic(), msg);
        }

        /// <summary>
        /// Adjusts the position of the tortoise according to the pose from the turtlesim node.
        /// </summary>
        /// <param name="msg"></param>
        public void ReceivePoseMessage(PoseMsg msg)
        {
            Tortoise.transform.position = new Vector3(msg.GetX() - m_PositionOffset, msg.GetY() - m_PositionOffset, Tortoise.transform.position.z);
            // the orientation comes in radians and with a 90 degree offset
            Tortoise.transform.eulerAngles = new Vector3(0f, 0f, msg.GetTheta() * Mathf.Rad2Deg - 90f);
        }
    }
}
