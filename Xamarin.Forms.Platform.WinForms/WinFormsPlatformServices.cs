using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	internal class WinFormsPlatformServices : IPlatformServices
	{
		private System.Windows.Forms.Form _mainForm;
		static private readonly MD5CryptoServiceProvider _md5 = new MD5CryptoServiceProvider();

		protected WinFormsPlatformServices(System.Windows.Forms.Form mainForm)
		{
			if (mainForm == null)
			{
				throw new ArgumentNullException(nameof(mainForm));
			}
			_mainForm = mainForm;
		}

		public bool IsInvokeRequired => throw new NotImplementedException();

		public string RuntimePlatform => throw new NotImplementedException();

		public void BeginInvokeOnMainThread(Action action)
		{
			_mainForm.BeginInvoke(action);
		}

		public Ticker CreateTicker()
		{
			return new WinFormsTicker();
		}

		public Assembly[] GetAssemblies()
		{
			return AppDomain.CurrentDomain.GetAssemblies();
		}

		public string GetMD5Hash(string input)
		{
			var bytes = _md5.ComputeHash(Encoding.UTF8.GetBytes(input));
			var sb = new StringBuilder();
			foreach (var c in bytes)
			{
				sb.AppendFormat("{0:X2}", c);
			}
			return sb.ToString();
		}

		public double GetNamedSize(NamedSize size, Type targetElementType, bool useOldSizes)
		{
			//	とりあえず適当
			return 22.0;
		}

		public async Task<Stream> GetStreamAsync(Uri uri, CancellationToken cancellationToken)
		{
			using (var client = new HttpClient())
			{
				HttpResponseMessage streamResponse = await client.GetAsync(uri.AbsoluteUri).ConfigureAwait(false);

				if (!streamResponse.IsSuccessStatusCode)
				{
					Log.Warning("HTTP Request", $"Could not retrieve {uri}, status code {streamResponse.StatusCode}");
					return null;
				}

				return await streamResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
			}
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
