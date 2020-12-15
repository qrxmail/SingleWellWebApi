namespace Cosmos.Model
{
	public class PLCConstants
	{
		public const ushort POS_DEVICE_STATE =				1 << 8;
		public const ushort POS_DEVICE_START =				1 << 9;
		public const ushort POS_DEVICE_START_CONDITION =	1 << 10;
		public const ushort POS_DEVICE_STOP =				1 << 11;
		public const ushort POS_DEVICE_STOP_CONDITION =		1 << 12;
		public const ushort POS_DEVICE_FAULT =				1 << 13;
		public const ushort POS_DEVICE_FEEDBACK =			1 << 14;
		public const ushort POS_DEVICE_LOCALREMOTE =		1 << 15;
		public const ushort POS_DEVICE_MODE =				1 << 0;

		public const ushort POS_VALVE_OPENED =				1 << 14;
		public const ushort POS_VALVE_CLOSED =				1 << 15;
		public const ushort POS_VALVE_OPEN_FAIL =			1 << 0;
		public const ushort POS_VALVE_CLOSE_FAIL =			1 << 1;

		public const ushort POS_VALVE_STATE_CLOSE =			1 << 2;

		public const ushort POS_COMM_ERROR =				1 << 8;

		public const ushort POS_EMERGENCY_STOP =			1 << 0;

		public const ushort POS_AI_ALARM_HI =				1 << 8;
		public const ushort POS_AI_ALARM_HIHI =				1 << 9;
		public const ushort POS_AI_ALARM_LOW =				1 << 10;
		public const ushort POS_AI_ALARM_LOWLOW =			1 << 11;

		public const ushort POS_SETTING_ENABLE_STOP_PUMP_BY_LEVEL = 1 << 8;
	}
}
