using SkiaForms;
using SkiaSharp;

namespace Microcharts.GTK.Sample.Controls
{
	public class ChartView : SkiaView
	{
		private Chart _chart;
		private InvalidatedWeakEventHandler<ChartView> _handler;

		public ChartView()
		{
			OnPaintSurface += OnPaintCanvas;
		}

		public Chart Chart
		{
			get => _chart;
			set
			{
				if (_chart != value)
				{
					if (_chart != null)
					{
						_handler.Dispose();
						_handler = null;
					}

					_chart = value;
					Invalidate();

					if (_chart != null)
					{
						_handler = _chart.ObserveInvalidate(this, (view) => view.Invalidate());
					}
				}
			}
		}

		private void OnPaintCanvas(SKSurface sender, SKImageInfo e)
		{
			if (_chart != null)
			{
				_chart.Draw(sender.Canvas, e.Width, e.Height);
			}
			else
			{
				sender.Canvas.Clear(SKColors.Transparent);
			}
		}
	}
}