using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROSBridge;
using SimpleJSON;

namespace RoboyWalk
{
    public class RosCommandSubscriber : ROSBridgeSubscriber
    {

        public new static string GetMessageTopic()
        {
            return "/roboy_cmd";
        }

        public new static string GetMessageType()
        {
            return RoboyCommandMsg.GetMessageType();
        }

        public new static ROSBridgeMsg ParseMessage(JSONNode msg)
        {
            return new RoboyCommandMsg(msg);
        }

        public static new void CallBack(ROSBridgeMsg msg)
        {
            RoboyCommandMsg rbm = (RoboyCommandMsg)msg;
            GroundsManager.Instance.SwitchGround(rbm.GetContent());
            GroundsManager.Instance.ResetScene();
        }
    }
}

