﻿using From2Dto3D.Model;
namespace From2Dto3D.View
{
	public class WPFViewer : Viewer
    {
		public WPFViewer(MainModel mainModel) : base(mainModel)
		{

		}

		internal override event EventHandler<EventArgs>? ViewChanged;
	}
}
