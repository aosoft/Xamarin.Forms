using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class VisualElementRenderer<TElement, TNativeElement> :
		Form, IVisualElementRenderer, IDisposable, IEffectControlProvider
		where TElement : VisualElement
	{

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		#region IVisualElementRenderer

		public Control ContainerElement => this;

		public VisualElement Element
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

		public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			throw new NotImplementedException();
		}

		public Control GetNativeElement()
		{
			throw new NotImplementedException();
		}

		public void SetElement(VisualElement element)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IEffectControlProvider

		public void RegisterEffect(Effect effect)
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}
