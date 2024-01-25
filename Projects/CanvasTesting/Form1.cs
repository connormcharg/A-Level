using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanvasTesting
{
    public partial class frmMain : Form
    {
        uint[] _Pixels {  get; set; }
        Bitmap _Bitmap { get; set; }
        GCHandle _Handle { get; set; }
        IntPtr _Addr {  get; set; }
        bool _IsRefreshing { get; set; }
        Random _rng { get; set; }
        int _Frames { get; set; }
        int _Seconds { get; set; }

        public frmMain()
        {
            InitializeComponent();

            int imageWidth = pbxFrame.Width;
            int imageHeight = pbxFrame.Height;

            PixelFormat fmt = PixelFormat.Format32bppRgb;
            int pixelFormatSize = Image.GetPixelFormatSize(fmt);
            int stride = imageWidth * pixelFormatSize;
            int padding = 32 - (stride % 32);

            if (padding < 32)
            {
                stride += padding;
            }

            _rng = new Random();

            _Pixels = new uint[(stride / 32) * imageHeight + 1];
            _Handle = GCHandle.Alloc(_Pixels, GCHandleType.Pinned);
            _Addr = Marshal.UnsafeAddrOfPinnedArrayElement(_Pixels, 0);
            _Bitmap = new Bitmap(imageWidth, imageHeight, stride / 8, fmt, _Addr);
            pbxFrame.Image = _Bitmap;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Addr = IntPtr.Zero;

            if (_Handle.IsAllocated)
            {
                _Handle.Free();
            }

            _Bitmap.Dispose();
            _Bitmap = null;
            _Pixels = null;
        }

        private void tmrTick_Tick(object sender, EventArgs e)
        {
            if (!_IsRefreshing)
            {
                _IsRefreshing = true;
                _Pixels[1280] = ((uint)(0xFFFF0000));
                for (int i = 1281; i < _Pixels.Length; i++)
                {
                    int col = _rng.Next(0, 256);
                    _Pixels[i] = ((uint)(col | (col << 8) | (col << 16) | (0xff000000)));
                    //_Pixels[i] = ((uint)(_rng.Next(0, 256) | (_rng.Next(0, 256) << 8) | (_rng.Next(0, 256) << 16) | (0xff000000)));
                    //_Pixels[i] = ((uint)(0xFFDD00FF));
                }
                pbxFrame.Refresh();
                _Frames += 1;
                _IsRefreshing = false;
            }
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (tmrTick.Enabled)
            {
                tmrTick.Stop();
                tmrElapsed.Stop();
            }
            else
            {
                tmrTick.Start();
                tmrElapsed.Start();
            }
        }

        private void tmrElapsed_Tick(object sender, EventArgs e)
        {
            _Seconds += 1;
            int fps;
            if (_Seconds == 0) { fps = 0; }
            else { fps = (int)(_Frames / _Seconds); }
            tbxHz.Text = $"{fps.ToString()} fps";
            //tbxHz.Text = $"{_Seconds.ToString()} seconds";
        }
    }
}
