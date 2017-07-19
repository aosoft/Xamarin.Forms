using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xamarin.Forms.Platform.WinForms
{
	public class VisualElementRenderer<TElement, TNativeElement> :
		Form, IVisualElementRenderer, IDisposable, IEffectControlProvider
		where TElement : VisualElement
		where TNativeElement : Control
	{

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
		}

		public TNativeElement Control { get; private set; }

		public TElement Element { get; private set; }



		protected virtual void OnElementChanged(ElementChangedEventArgs<TElement> e)
		{
			var args = new VisualElementChangedEventArgs(e.OldElement, e.NewElement);
			ElementChanged?.Invoke(this, args);
		}

		protected virtual void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
				UpdateEnabled();
			else if (e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
				UpdateBackgroundColor();
			/*
			else if (e.PropertyName == AutomationProperties.HelpTextProperty.PropertyName)
				SetAutomationPropertiesHelpText();
			else if (e.PropertyName == AutomationProperties.NameProperty.PropertyName)
				SetAutomationPropertiesName();
			else if (e.PropertyName == AutomationProperties.IsInAccessibleTreeProperty.PropertyName)
				SetAutomationPropertiesAccessibilityView();
			else if (e.PropertyName == AutomationProperties.LabeledByProperty.PropertyName)
				SetAutomationPropertiesLabeledBy();
			*/
		}

		protected virtual void UpdateBackgroundColor()
		{
			Color backgroundColor = Element.BackgroundColor;
			var control = Control as Control;
			if (control != null)
			{
				if (!backgroundColor.IsDefault)
				{
					control.BackColor = backgroundColor.ToWindowsColor();
				}
				else
				{
					control.BackColor = System.Drawing.SystemColors.Window;
				}
			}
			else
			{
				if (!backgroundColor.IsDefault)
				{
					BackColor = backgroundColor.ToWindowsColor();
				}
				else
				{
					BackColor = System.Drawing.SystemColors.Window;
				}
			}
		}

		protected virtual void UpdateNativeControl()
		{
			UpdateEnabled();
			/*
			SetAutomationPropertiesHelpText();
			SetAutomationPropertiesName();
			SetAutomationPropertiesAccessibilityView();
			SetAutomationPropertiesLabeledBy();
			*/
		}

		internal virtual void OnElementFocusChangeRequested(object sender, VisualElement.FocusRequestArgs args)
		{
			var control = Control as Control;
			if (control == null)
				return;

			/*
			if (args.Focus)
				args.Result = control.Focus(FocusState.Programmatic);
			else
			{
				UnfocusControl(control);
				args.Result = true;
			}
			*/
		}


		void UpdateEnabled()
		{
			var control = Control as Control;
			if (control != null)
				control.Enabled = Element.IsEnabled;
			/*else
				IsHitTestVisible = Element.IsEnabled && !Element.InputTransparent;*/
		}

		void UpdateTracker()
		{
			/*
			if (_tracker == null)
				return;

			_tracker.PreventGestureBubbling = PreventGestureBubbling;
			_tracker.Control = Control;
			_tracker.Element = Element;
			_tracker.Container = ContainerElement;
			*/
		}


		#region IVisualElementRenderer

		public Control ContainerElement => this;

		VisualElement IVisualElementRenderer.Element => Element;

		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;

		public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			throw new NotImplementedException();
		}

		public Control GetNativeElement()
		{
			return Control;
		}

		public void SetElement(VisualElement element)
		{
			TElement oldElement = Element;
			Element = (TElement)element;

			if (oldElement != null)
			{
				oldElement.PropertyChanged -= OnElementPropertyChanged;
				oldElement.FocusChangeRequested -= OnElementFocusChangeRequested;
			}

			if (element != null)
			{
				Element.PropertyChanged += OnElementPropertyChanged;
				Element.FocusChangeRequested += OnElementFocusChangeRequested;

				/*if (AutoPackage && Packager == null)
					Packager = new VisualElementPackager(this);

				if (AutoTrack && Tracker == null)
				{
					Tracker = new VisualElementTracker<TElement, TNativeElement>();
				}

				// Disabled until reason for crashes with unhandled exceptions is discovered
				// Without this some layouts may end up with improper sizes, however their children
				// will position correctly
				//Loaded += (sender, args) => {
				if (Packager != null)
					Packager.Load();
				//};*/
			}

			OnElementChanged(new ElementChangedEventArgs<TElement>(oldElement, Element));

			var controller = (IElementController)oldElement;
			if (controller != null && controller.EffectControlProvider == this)
			{
				controller.EffectControlProvider = null;
			}

			controller = element;
			if (controller != null)
				controller.EffectControlProvider = this;
		}

		#endregion

		#region IEffectControlProvider

		void IEffectControlProvider.RegisterEffect(Effect effect)
		{
			throw new NotImplementedException();
		}

		#endregion

	}
}
