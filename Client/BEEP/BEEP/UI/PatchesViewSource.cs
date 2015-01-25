
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Common.Data;
using System.Linq;
using System.Collections.Generic;

namespace Mobile.UI
{
	public class PatchesViewControllerSource : UITableViewSource
	{
		List<PatchData> Data;

		public PatchesViewControllerSource ()
		{
			Data = DataStore.Instance.GetAllOfType<PatchData>().ToList();
		
		}

		public override int NumberOfSections(UITableView tableView)
		{
			// TODO: return the actual number of sections
			return 1;
		}

		public override int RowsInSection(UITableView tableview, int section)
		{
			// TODO: return the actual number of items in the section
			return Data.Count;
		}

		public override string TitleForHeader(UITableView tableView, int section)
		{
			return "Header";
		}

		public override string TitleForFooter(UITableView tableView, int section)
		{
			return "Footer";
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (PatchesViewControllerCell.Key) as PatchesViewControllerCell;
			if (cell == null)
				cell = new PatchesViewControllerCell (Data[indexPath.Row]);
			
			// TODO: populate the cell with the appropriate data based on the indexPath
			cell.DetailTextLabel.Text = "DetailsTextLabel";
			
			return cell;
		}
	}
}

