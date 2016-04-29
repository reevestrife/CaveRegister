using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace CaveRegister.Helpers
{
	public static class ImageHelper
	{

		public static void MergeImages() { 
		
			Image playbutton;
			try
			{
				playbutton = Image.FromFile(HttpContext.Current.Request.MapPath("~/KmlImages/cave.png"));
			}
			catch (Exception ex)
			{
				return;
			}

			//Image frame;
			//try
			//{
			//	frame = Image.FromFile(""/*somekindofpath*/);
			//}
			//catch (Exception ex)
			//{
			//	return;
			//}


			SolidBrush blueBrush = new SolidBrush(Color.SeaGreen);
			SolidBrush redBrush = new SolidBrush(Color.Yellow);
			SolidBrush trans = new SolidBrush(Color.Transparent);
			Pen pen = new Pen(redBrush);
			Pen transPen = new Pen(trans,10);
			pen.Width = 8;
	

			// Create rectangle.
			Rectangle background = new Rectangle((64 / 2) - (60 / 2), (64 / 2) - (60 / 2), 60, 60);
			Rectangle rectForCircle = new Rectangle((64 / 2) - (58 / 2), (64 / 2) - (58 / 2), 58, 58);
			

			// Fill rectangle to screen.
			

			//using (frame)
			//{
				using (var bitmap = new Bitmap(64, 64))
				{
    				using (var canvas = Graphics.FromImage(bitmap))
    				{
						canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
						canvas.PageUnit = GraphicsUnit.Pixel;
    					canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
						canvas.FillEllipse(blueBrush, background);
    					//canvas.DrawImage(frame, new Rectangle(0, 0, 64, 64), new Rectangle(0, 0, frame.Width, frame.Height), GraphicsUnit.Pixel);
						
						canvas.DrawEllipse(pen, rectForCircle);
						canvas.DrawImage(playbutton, 0, 0, (float)64, (float)64);
    					canvas.Save();
    				}
    				try
    				{
						bitmap.Save(HttpContext.Current.Request.MapPath("~/KmlImages/caveMerge.png"), ImageFormat.Png);
    				}
    				catch (Exception ex) { }
				}
			//}

		}
	}
}