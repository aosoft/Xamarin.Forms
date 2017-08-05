﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.ControlGallery.WinForms
{
	public class App : Application
	{
		public App()
		{
			var layout = new StackLayout();
			layout.VerticalOptions = LayoutOptions.Center;
			layout.Children.Add(new Label
			{
				HorizontalTextAlignment = TextAlignment.Center,
				Text = "Welcome to Xamarin Forms!"
			});

			MainPage = new ContentPage
			{
				Content = layout
			};
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
