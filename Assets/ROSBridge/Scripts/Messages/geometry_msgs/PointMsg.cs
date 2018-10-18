using System.Collections;
using System.Text;
using SimpleJSON;

namespace ROSBridge {
	public class PointMsg : ROSBridgeMsg {
		private double _x;
		private double _y;
		private double _z;
			
		public PointMsg(JSONNode msg) {
			_x = double.Parse(msg["x"]);
			_y = double.Parse(msg["y"]);
			_z = double.Parse(msg["z"]);
		}
			
		public PointMsg(double x, double y, double z) {
			_x = x;
			_y = y;
			_z = z;
		}
			
		public static string GetMessageType() {
			return "geometry_msgs/Point";
		}
			
		public double GetX() {
			return _x;
		}
			
		public double GetY() {
			return _y;
		}
			
		public double GetZ() {
			return _z;
		}
			
		public override string ToString() {
			return "Vector3 [x=" + _x + ",  y="+ _y + ",  z=" + _z + "]";
		}
			
		public override string ToYAMLString() {
			return "{\"x\" : " + _x + ", \"y\" : " + _y + ", \"z\" : " + _z + "}";
		}
	}
}