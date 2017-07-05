using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	internal class WinFormsDeviceInfo : DeviceInfo
	{
		public override Size PixelScreenSize => throw new NotImplementedException();

		public override Size ScaledScreenSize => throw new NotImplementedException();

		public override double ScalingFactor => throw new NotImplementedException();
	}
}
