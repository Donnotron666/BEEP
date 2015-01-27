
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Mobile.UI
{
	public partial class RootViewController : UITableViewController
	{
		public string[] tableItems = {"Connected Instruments(0)", "My Banks", "My Instruments", "Community Patches", "Settings"};

		public RootViewController () : base ("RootViewController", null)
		{
		}


		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell ("TableCell");
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell (UITableViewCellStyle.Default, "TableCell");
			cell.TextLabel.Text = tableItems[indexPath.Row];
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow (indexPath, true); // normal iOS behaviour is to remove the blue highlight
			this.NavigationController.PushViewController (new PatchesViewControllerController(), true);
		}

		public override int RowsInSection(UITableView tableview, int section)
		{
			return tableItems.Length;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
		}
	}
}

