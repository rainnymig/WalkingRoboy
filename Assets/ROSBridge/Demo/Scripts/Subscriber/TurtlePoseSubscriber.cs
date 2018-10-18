using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

namespace ROSBridge.Demo
{
    public class TurtlePoseSubscriber : ROSBridgeSubscriber
    {
        public new static string GetMessageTopic()
        {
            return "/turtle1/pose";
        }

        public new static string GetMessageType()
        {
            return PoseMsg.GetMessageType();
        }

        public new static ROSBridgeMsg ParseMessage(JSONNode msg)
        {
            return new PoseMsg(msg);
        }

        public static new void CallBack(ROSBridgeMsg msg)
        {
            DemoManager.Instance.ReceivePoseMessage((PoseMsg)msg);
        }
    }
}
