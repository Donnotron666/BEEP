
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Common.Data;

namespace Mobile.UI
{
	public class PatchesViewControllerCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("PatchesViewControllerCell");

		public PatchesViewControllerCell (PatchData data) : base (UITableViewCellStyle.Value1, Key)
		{
			TextLabel.Text = data.PatchName;
		}
	}
}

