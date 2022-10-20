# Installation

1) Download the following [EmguCV's cuda libarries](https://sourceforge.net/projects/emgucv/files/emgucv/4.4.0/libemgucv-windesktop_x64-cuda-4.4.0.4099.zip.selfextract.exe/download) and extract it. After extracting, copy the "libs" folder included in the extracted flder and paste it inside References/EmguCV (replace the existing libs folder).

2) Add the shared Emgu.CV.Runtime.Windows. This can be done by clicking on "file" in the tabbar, "add" and after that "Existing Project". Add References/EmguCV/Emgu.CV.Runtime/Windows/Emgu.CV.Runtime/Windows.shproj.

3) After this, activate the shared project references called Emgu.CV.Runtime.Windows. You can find this in the Shared projects references. Lastly add the references Emgu.CV.Bitmap.dll and Emgu.CV.Platform.NetStandard.dll in the References/EmguCV/libs map.

## License
[MIT](https://choosealicense.com/licenses/mit/)
