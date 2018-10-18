using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ROSBridge.Demo
{
    public class TurtleVelocityPublisher : ROSBridgePublisher
    {
        public new static string GetMessageTopic()
        {
            return "/turtle1/cmd_vel";
        }

        public new static string GetMessageType()
        {
            return TwistMsg.GetMessageType();
        }

        public static string ToYAMLString(TwistMsg msg)
        {
            return msg.ToYAMLString();
        }
    }
}