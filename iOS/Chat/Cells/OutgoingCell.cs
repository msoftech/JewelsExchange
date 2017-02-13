﻿using System;

using UIKit;
using Foundation;

namespace JewelsExchange.iOS
{
	[Register ("OutgoingCell")]
	public class OutgoingCell : BubbleCell
	{
		static readonly UIImage normalBubbleImage;
		static readonly UIImage highlightedBubbleImage;

		public static readonly NSString CellId = new NSString ("Outgoing");

		static OutgoingCell ()
		{
			UIImage mask = UIImage.FromBundle ("BubbleOutgoing");

			var cap = new UIEdgeInsets {
				Top = 17f,
				Left = 21f,
				Bottom = 17f,
				Right = 26f
			};

			var normalColor = UIColor.FromRGB (43, 119, 250);
			var highlightedColor = UIColor.FromRGB (32, 96, 200);

			normalBubbleImage = CreateColoredImage (normalColor, mask).CreateResizableImage (cap);
			highlightedBubbleImage = CreateColoredImage (highlightedColor, mask).CreateResizableImage (cap);
		}

		public OutgoingCell (IntPtr handle)
			: base (handle)
		{
			Initialize ();
		}

		public OutgoingCell ()
		{
			Initialize ();
		}

		[Export ("initWithStyle:reuseIdentifier:")]
		public OutgoingCell (UITableViewCellStyle style, string reuseIdentifier)
			: base (style, reuseIdentifier)
		{
			Initialize ();
		}

		void Initialize ()
		{
			BubbleHighlightedImage = highlightedBubbleImage;
			BubbleImage = normalBubbleImage;

			ContentView.AddConstraints (NSLayoutConstraint.FromVisualFormat ("H:[bubble]|",
				0, 
				"bubble", BubbleImageView));
			ContentView.AddConstraints (NSLayoutConstraint.FromVisualFormat ("V:|-2-[bubble]-2-|",
				0,
				"bubble", BubbleImageView
			));
			BubbleImageView.AddConstraints (NSLayoutConstraint.FromVisualFormat ("H:[bubble(>=48)]",
				0,
				"bubble", BubbleImageView
			));

			var vSpaceTop = NSLayoutConstraint.Create (MessageLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Top, 1, 10);
			ContentView.AddConstraint (vSpaceTop);

			var vSpaceBottom = NSLayoutConstraint.Create (MessageLabel, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Bottom, 1, -10);
			ContentView.AddConstraint (vSpaceBottom);

			var msgTrailing = NSLayoutConstraint.Create (MessageLabel, NSLayoutAttribute.Trailing, NSLayoutRelation.LessThanOrEqual, BubbleImageView, NSLayoutAttribute.Trailing, 1, -16);
			ContentView.AddConstraint (msgTrailing);

			var msgCenter = NSLayoutConstraint.Create (MessageLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.CenterX, 1, -3);
			ContentView.AddConstraint (msgCenter);



			//var vSpaceBottom0 = NSLayoutConstraint.Create(AudioDownloadButton, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Bottom, 1, -10);
			//ContentView.AddConstraint(vSpaceBottom0);

			//var msgCenter0 = NSLayoutConstraint.Create(AudioDownloadButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.CenterX, 1, -10);
			//ContentView.AddConstraint(msgCenter0);



			var vSpaceBottom1 = NSLayoutConstraint.Create(AudioPlayButton, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Bottom, 1, -10);
			ContentView.AddConstraint(vSpaceBottom1);

			var msgCenter1 = NSLayoutConstraint.Create(AudioPlayButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.CenterX, 1, -3);//
			ContentView.AddConstraint(msgCenter1);


			//var vSpaceBottom2 = NSLayoutConstraint.Create(AudioStopButton, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Bottom, 1, -10);
			//ContentView.AddConstraint(vSpaceBottom2);

			//var msgCenter2 = NSLayoutConstraint.Create(AudioStopButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.CenterX, 1, -80);
			//ContentView.AddConstraint(msgCenter2);

		var vSpaceBottomi = NSLayoutConstraint.Create(ImageAttachment, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.Bottom, 1, -10);
			ContentView.AddConstraint(vSpaceBottomi);


			var msgCenteri = NSLayoutConstraint.Create(ImageAttachment, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, BubbleImageView, NSLayoutAttribute.CenterX, 1, -3);
			ContentView.AddConstraint(msgCenteri);

			MessageLabel.TextColor = UIColor.White;
		}
	}
}