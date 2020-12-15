namespace Cosmos.Misc
{
	public class MiscUtility
	{
		public static bool GetBool(ushort value, int mask)
		{
			if ((value & mask) != 0)
				return true;
			else
				return false;
		}

		public static int GetDiscreteValue(ushort value, int mask)
		{
			if ((value & mask) > 0)
				return 1;
			else
				return 0;
		}

		public bool ByteToBool(byte b)
		{
			if (b > 0)
				return true;
			else
				return false;
		}
	}
}
