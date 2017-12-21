using System;
using System.Collections.Generic;
using System.Text;

namespace SharedApp
{
	public class App : Xamarin.Forms.Application
	{
		public App()
		{
			MainPage = new Page1();
		}

		protected override void OnStart()
		{
			base.OnStart();
		}

		protected override void OnSleep()
		{
			base.OnSleep();
		}

		protected override void OnResume()
		{
			base.OnResume();
		}
	}
}
