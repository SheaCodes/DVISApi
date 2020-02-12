using System;

namespace DVISApi.TSTypes
{
	public abstract class TSPointWeb
	{
		public          DateTime TimeStamp   { get; set; }
		public abstract object   ValueObject { get; }

		protected TSPointWeb(DateTime dt)
		{
			TimeStamp = dt;
		}
	}
}