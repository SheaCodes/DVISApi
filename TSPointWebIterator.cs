using System;
using System.Collections.Generic;
using System.Linq;
using DVISApi.TSTypes;

namespace DVISApi
{
	public class TSPointWebIterator
	{
		private readonly List<TSPointWeb> _points;
		private int _cur;

		public TSPointWebIterator(List<TSPointWeb> points)
		{
			Count = points.Count;

			_points = points;
			_cur    = 0;
		}

		public int Count { get; private set; }

		public TSPointWeb Get(DateTime dt)
		{
			return GetFast(dt);
		}

		public TSPointWeb GetSlow(DateTime dt)
		{
			if (_points.Count == 0)
				return null;

			// You want the following conditions for the returned point p at index i:
			// 1. p.Timestamp < dt (the signal has the value p.ValueObject at dt)
			// 2. there is no index j > i for which 1. is true

			for (int i = 0; i < _points.Count; i++)
			{
				if (_points[i].TimeStamp == dt)
				{
					return _points[i];
				}
				else if (_points[i].TimeStamp > dt)
				{
					if (i == 0)
						return null;
					return _points[i-1];
				}
			}

			return _points.LastOrDefault();
		}

		public TSPointWeb GetFast(DateTime dt)
		{
			if (_points.Count == 0)
				return null;

			// You want the following conditions for the returned point p at index i:
			// 1. p.Timestamp < dt (the signal has the value p.ValueObject at dt)
			// 2. there is no index j > i for which 1. is true

			while(true)
			{
				if (_cur == _points.Count)
					break;
				if (_points[_cur].TimeStamp == dt)
				{
					return _points[_cur];
				}
				else if (_points[_cur].TimeStamp > dt)
				{
					if (_cur == 0)
						return null;
					return _points[_cur - 1];
				}

				_cur++;
			}

			return _points.LastOrDefault();
		}


		public TSPointWeb this[int i]
		{
			get { return _points[i]; }
		}
	}
}