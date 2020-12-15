using Cosmos.Misc;
using Cosmos.Model;
using OilTankHMI.Model;

namespace controlCenterWebApi.Model
{
	public class StationModel
	{
		const string CLOSED = "closed";
		const string OPENED = "opened";
		const string UNKNOW = "unknown";

		public string loopValveStatus;
		public string outValveStatus;
		public string heater01Status;
		public string heater02Status;
		public string loadPumpStatus;
		public bool heater01LocalRemote;
		public bool heater02LocalRemote;
		public bool loadPumpLocalRemote;
		public bool heater01ManualAuto;
		public bool heater02ManualAuto;
		public string oilTempPV;
		public string oilTempSP;
		public string heater01TempPV;
		public string heater01TempSP;
		public string heater02TempPV;
		public string heater02TempSP;
		public string levelPV;

		public StationModel(ST_PLCData plcModel)
		{
			loopValveStatus = GetValveStatus(plcModel.loopValve);
			outValveStatus = GetValveStatus(plcModel.outValve);
			heater01Status = GetHeaterStatus(plcModel.heater01);
			heater02Status = GetHeaterStatus(plcModel.heater02);
			loadPumpStatus = GetPumpStatus(plcModel.pump);
			heater01LocalRemote = GetHeaterLocalRemote(plcModel.heater01);
			heater01ManualAuto = GetHeaterManualAuto(plcModel.heater01);
			heater02LocalRemote = GetHeaterLocalRemote(plcModel.heater02);
			heater02ManualAuto = GetHeaterManualAuto(plcModel.heater02);
			loadPumpLocalRemote = GetPumpLocalRemote(plcModel.pump);
			oilTempPV = plcModel.tank.oilTemp.value.ToString("F2");
			oilTempSP = plcModel.tank.oilGauge.SP.ToString("F2");
			heater01TempPV = plcModel.tank.heater01Temp.value.ToString("F2");
			heater01TempSP = plcModel.tank.heater01Gauge.SP.ToString("F2");
			heater02TempPV = plcModel.tank.heater02Temp.value.ToString("F2");
			heater02TempSP = plcModel.tank.heater02Gauge.SP.ToString("F2");
			levelPV = plcModel.tank.level.value.ToString("F2");
		}

		string GetValveStatus(ST_Valve valve)
		{
			string result = UNKNOW;
			if (MiscUtility.GetBool(valve.member, PLCConstants.POS_VALVE_OPENED))
			{
				result = OPENED;
			} else if (MiscUtility.GetBool(valve.member, PLCConstants.POS_VALVE_CLOSED))
			{
				result = CLOSED;
			} else
			{
				result = UNKNOW;
			}

			return result;
		}

		string GetPumpStatus(ST_Motor motor)
		{
			string result = UNKNOW;
			if (MiscUtility.GetBool(motor.member, PLCConstants.POS_DEVICE_FEEDBACK))
			{
				result = OPENED;
			}else
			{
				result = CLOSED;
			}

			return result;
		}

		string GetHeaterStatus(ST_Heater heater)
		{
			string result = UNKNOW;
			if (MiscUtility.GetBool(heater.member, PLCConstants.POS_DEVICE_FEEDBACK))
			{
				result = OPENED;
			}
			else
			{
				result = CLOSED;
			}

			return result;
		}

		bool GetHeaterLocalRemote(ST_Heater heater)
		{
			return MiscUtility.GetBool(heater.member, PLCConstants.POS_DEVICE_LOCALREMOTE);
		}

		bool GetHeaterManualAuto(ST_Heater heater)
		{
			return MiscUtility.GetBool(heater.member, PLCConstants.POS_DEVICE_MODE);
		}

		bool GetPumpLocalRemote(ST_Motor motor)
		{
			return MiscUtility.GetBool(motor.member, PLCConstants.POS_DEVICE_LOCALREMOTE);
		}
	}

	public class StationControlModel
	{
		public string target;
		public string action;
	}
}
