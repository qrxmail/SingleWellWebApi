using Cosmos.Model;
using System.Runtime.InteropServices;


namespace OilTankHMI.Model
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_AIBusDevice
	{
		public short SPSet;
		public short SP;
		public short alarm;
		public short member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_Tank
	{
		public ST_AIBusDevice oilGauge;
		public ST_AIBusDevice heater02Gauge;
		public ST_AIBusDevice heater01Gauge;
		public ST_AI oilTemp;
		public ST_AI heater02Temp;
		public ST_AI heater01Temp;
		public ST_AI level;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_System
	{
		public float taskDuration;
		public float levelAfterWork;
		public float levelBeginWork;
		public short ackTaskComplete;
		public short alarm;
		public short mode;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct ST_SystemSetting
	{
		public float pumpFlowRate;
		public float levelStopPump;
		public float levelReadyForWork;
		public short heater02SPOffSet;
		public short heater01SPOffSet;
		public short maxDurationPerTask;
		public short member;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class ST_PLCData
	{
		public ST_System system;
		public ST_Valve outValve;
		public ST_Valve loopValve;
		public ST_Button stopOilInjection;
		public ST_Button eStopButton;
		public ST_Heater heater02;
		public ST_Heater heater01;
		public ST_Motor pump;
		public ST_Tank tank;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public class ST_PLCConfig
	{
		public ST_SystemSetting Setting;
		public ST_AIConfig TankTemperature;
		public ST_AIConfig Heater02Temperature;
		public ST_AIConfig Heater01Temperature;
		public ST_AIConfig TankLevel;
	}
}