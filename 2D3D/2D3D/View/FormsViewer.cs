using From2Dto3D.Model;

namespace From2Dto3D.View
{
	public class FormsViewer : Viewer
	{
		public override event EventHandler<PathArg> SourcePath;
		public string CurrentPath => mainModel.MeshPath;
		public FormsViewer(MainModel mainModel) : base(mainModel)
		{

		}
		public void SendPath(string path)
		{
			if(path != "")
			{
				PathArg pathArg = new(path);
				SourcePath.Invoke(this, pathArg);
			}
		}

		internal override event EventHandler<EventArgs>? ViewChanged;
	}
}