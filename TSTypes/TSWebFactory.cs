using System;

namespace DVISApi.TSTypes
{
	public static class TSWebFactory
	{
		public static TSPointWeb Create(TSTypeWeb type, object val, DateTime dt)
		{
			switch (type)
			{
				case TSTypeWeb.Number:
					return new TSNumberWeb((double)val, dt);
				case TSTypeWeb.Flag:
					return new TSFlagWeb((bool)val, dt);
				case TSTypeWeb.Label:
					return new TSLabelWeb((string)val, dt);
				default:
					throw new ArgumentOutOfRangeException("type", type, null);
			}
		}
	}
}