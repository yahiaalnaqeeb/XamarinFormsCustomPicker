using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsCustomPicker.iOS.Renderers;
using XamarinFormsCustomPicker.Renderers;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace XamarinFormsCustomPicker.iOS.Renderers
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            var customPicker = e.NewElement as CustomPicker;
            if (Control == null)
            {
                SetNativeControl(new UITextField
                {
                    RightViewMode = UITextFieldViewMode.Always,
                    ClearButtonMode = UITextFieldViewMode.WhileEditing,
                });
                SetUIButton(customPicker.DoneButtonText);
            }
            else
            {
                SetUIButton(customPicker.DoneButtonText);

            }
        }

        public void SetUIButton(string doneButtonText)
        {
            UIToolbar toolbar = new UIToolbar();
            toolbar.BarStyle = UIBarStyle.Default;
            toolbar.Translucent = true;
            toolbar.SizeToFit();
            UIBarButtonItem doneButton = new UIBarButtonItem(String.IsNullOrEmpty(doneButtonText) ? "Accept" : doneButtonText, UIBarButtonItemStyle.Done, (s, ev) =>
            {
                Control.ResignFirstResponder();

            });
            UIBarButtonItem flexible = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolbar.SetItems(new UIBarButtonItem[] { doneButton,flexible }, true);
            Control.InputAccessoryView = toolbar;
        }
    }
}
