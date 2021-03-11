using Microsoft.Maui.Platform.iOS;
using UIKit;

namespace Microsoft.Maui
{
	public static class LabelExtensions
	{
		public static void UpdateText(this UILabel nativeLabel, ILabel label)
		{
			nativeLabel.Text = label.Text;

			nativeLabel.UpdateCharacterSpacing(label);
		}

		public static void UpdateTextColor(this UILabel nativeLabel, ILabel label)
		{
			var textColor = label.TextColor;

			if (textColor.IsDefault)
			{
				// Default value of color documented to be black in iOS docs
				nativeLabel.TextColor = textColor.ToNative(ColorExtensions.LabelColor);
			}
			else
			{
				nativeLabel.TextColor = textColor.ToNative(textColor);
			}
		}

		public static void UpdateCharacterSpacing(this UILabel nativeLabel, ILabel label)
		{
			if (string.IsNullOrEmpty(label.Text))
				return;

			var textAttr = nativeLabel.AttributedText?.WithCharacterSpacing(label.CharacterSpacing);

			if (textAttr != null)
				nativeLabel.AttributedText = textAttr;
		}

		public static void UpdateFont(this UILabel nativeLabel, ILabel label, IFontManager fontManager)
		{
			var uiFont = fontManager.GetFont(label.Font);
			nativeLabel.Font = uiFont;

			nativeLabel.UpdateCharacterSpacing(label);
		}

		public static void UpdatePadding(this MauiLabel nativeLabel, ILabel label)
		{
			nativeLabel.TextInsets = new UIEdgeInsets(
				(float)label.Padding.Top,
				(float)label.Padding.Left,
				(float)label.Padding.Bottom,
				(float)label.Padding.Right);
		}
	}
}