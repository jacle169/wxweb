using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;

namespace PhotoCapture
{
    public partial class Capturer : UserControl
    {
        VideoBrush DisplayCanvasBrush;
        CaptureSource _CaptureSource;

        public Capturer()
        {
            InitializeComponent();
            DisplayCanvasBrush = new VideoBrush();
            rectangle1.Fill = DisplayCanvasBrush;

            bt_action.Click += new RoutedEventHandler(bt_action_Click);
            bt_capture.Click += new RoutedEventHandler(bt_capture_Click);
        }

        WriteableBitmap writeableBitmap;
        IsolatedStorageFile isf;
        BitmapImage image;
        MemoryStream stream;

        public IsolatedStorageFileStream GetImage()
        {
            if (isf == null)
            {
                return null;
            }
            string name = "capture.jpg";
            if (isf.FileExists(name))
            {
                return new IsolatedStorageFileStream(name, FileMode.Open, isf);
            }
            return null;
        }

        void bt_capture_Click(object sender, RoutedEventArgs e)
        {
            if (this._CaptureSource != null && this._CaptureSource.State == CaptureState.Started)
            {
                writeableBitmap = new WriteableBitmap(rectangle1, null);
                isf = IsolatedStorageFile.GetUserStoreForApplication();
                string name = "capture.jpg";
                if (isf.FileExists(name))
                {
                    isf.DeleteFile(name);
                }
                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(name, FileMode.Create, isf))
                {
                    stream = new MemoryStream();
                    writeableBitmap.EncodeJpeg(stream, 60);
                    stream.CopyTo(isfs);
                }

                using (IsolatedStorageFileStream isfs = new IsolatedStorageFileStream(name, FileMode.Open, isf))
                {
                    image = new BitmapImage();
                    image.SetSource(isfs);
                    img_display.Source = image;
                }
            }
        }

        public void stop()
        {
            if (this._CaptureSource != null && this._CaptureSource.VideoCaptureDevice != null)
            {
                this._CaptureSource.Stop();
            }
        }

        void bt_action_Click(object sender, RoutedEventArgs e)
        {
            if (this._CaptureSource == null)
            {
                this._CaptureSource = new System.Windows.Media.CaptureSource();
                this._CaptureSource.VideoCaptureDevice = CaptureDeviceConfiguration.GetDefaultVideoCaptureDevice();
            }
            if (CaptureDeviceConfiguration.AllowedDeviceAccess || CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                if (this._CaptureSource.VideoCaptureDevice != null)
                {
                    try
                    {
                        this._CaptureSource.Start();
                        DisplayCanvasBrush.SetSource(_CaptureSource);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
