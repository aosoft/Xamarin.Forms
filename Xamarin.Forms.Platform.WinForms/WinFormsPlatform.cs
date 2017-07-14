using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.WinForms
{
	public class WinFormsPlatform : BindableObject, IPlatform, INavigation, IDisposable
	{
        #region Constructor / Dispose

        public void Dispose()
        {
        }

		#endregion

		#region IPlatform

		public SizeRequest GetNativeSize(VisualElement view, double widthConstraint, double heightConstraint)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region INavigation

		public IReadOnlyList<Page> ModalStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

		public IReadOnlyList<Page> NavigationStack
        {
            get
            {
                throw new NotImplementedException();
            }
        }

		public void InsertPageBefore(Page page, Page before)
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopModalAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Page> PopModalAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PopToRootAsync()
		{
			throw new NotImplementedException();
		}

		public Task PopToRootAsync(bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PushAsync(Page page)
		{
			throw new NotImplementedException();
		}

		public Task PushAsync(Page page, bool animated)
		{
			throw new NotImplementedException();
		}

		public Task PushModalAsync(Page page)
		{
			throw new NotImplementedException();
		}

		public Task PushModalAsync(Page page, bool animated)
		{
			throw new NotImplementedException();
		}

		public void RemovePage(Page page)
		{
			throw new NotImplementedException();
		}

		#endregion


	}
}
