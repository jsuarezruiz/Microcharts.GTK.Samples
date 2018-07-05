using System;
using Xamarin.Forms.Platform.GTK;

namespace Microcharts.GTK.Sample.GTK
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			SkiaForms.Gtk2.Init.Include();
			Gtk.Application.Init();
			Xamarin.Forms.Forms.Init();
			var app = new App();
			var window = new FormsWindow();
			window.LoadApplication(app);
			window.SetApplicationTitle("Microcharts Xamarin.Forms.Platform.GTK");
			window.Show();
			Gtk.Application.Run();
		}
	}
}