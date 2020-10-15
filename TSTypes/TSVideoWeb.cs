using System;
using System.Drawing;

namespace DVISApi.TSTypes
{
	public class TSVideoWeb : TSPointWeb
	{
		public Bitmap Value { get; set; }

		public TSVideoWeb(Bitmap bmp, DateTime dt) : base(dt)
		{
			Value = bmp;
		}

		public override object ValueObject
		{
			get { return Value; }
		}
	}
}