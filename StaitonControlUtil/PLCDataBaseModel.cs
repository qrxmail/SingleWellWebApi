using System.Runtime.InteropServices;

namespace Cosmos.Model
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_DeviceBase
	{
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_Button
	{
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_AI
	{
		public float value;
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_Heater
	{
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_Valve
	{
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_Motor
	{
		public ushort member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_AIConfig
	{
		public float Offset;
		public float CalibrateFactor;
		public float AlarmLowLow;
		public float AlarmLow;
		public float AlarmHiHi;
		public float AlarmHi;
		public float EngineeringMin;
		public float EngineeringMax;
	}
}
