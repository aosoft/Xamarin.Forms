using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	internal class WinFormsPlatformServices : IPlatformServices
	{
		public bool IsInvokeRequired => throw new NotImplementedException();

		public string RuntimePlatform => throw new NotImplementedException();

		public void BeginInvokeOnMainThread(Action action)
		{
			throw new NotImplementedException();
		}

		public Ticker CreateTicker()
		{
			return new WinFormsTicker();
		}

		public Assembly[] GetAssemblies()
		{
			throw new NotImplementedException();
		}

		public string GetMD5Hash(string input)
		{
			throw new NotImplementedException();
		}

		public double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
		{
			throw new NotImplementedException();
		}

		public Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public IIsolatedStorageFile GetUserStoreForApplication()
		{
			throw new NotImplementedException();
		}

		public void OpenUriAction(Uri uri)
		{
			throw new NotImplementedException();
		}

		public void StartTimer(TimeSpan interval, Func<bool> callback)
		{
			throw new NotImplementedException();
		}
	}
}
