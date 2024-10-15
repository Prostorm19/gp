using Microsoft.DirectX.Direct3D;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Microsoft.DirectX;

namespace test1
{
    public partial class Form1 : Form
    {
        Microsoft.DirectX.Direct3D.Device device;
        public Form1()
        {
            InitializeComponent();
            InitDevice();
        }
        private void InitDevice()
        {
            PresentParameters pp = new PresentParameters();
            pp.Windowed = true;
            pp.SwapEffect = SwapEffect.Discard;
            device = new Device(0, DeviceType.Hardware, this,
            CreateFlags.HardwareVertexProcessing, pp);
        }
        private void Render()
        {
            CustomVertex.TransformedColored[] vertexes = new
            CustomVertex.TransformedColored[3];
            vertexes[0].Position = new Vector4(240, 110, 0, 1.0f);//first point
            vertexes[0].Color = System.Drawing.Color.FromArgb(0, 255, 0).ToArgb();
            vertexes[1].Position = new Vector4(380, 420, 0, 1.0f);//second point
            vertexes[1].Color = System.Drawing.Color.FromArgb(0, 0, 255).ToArgb();
            vertexes[2].Position = new Vector4(110, 420, 0, 1.0f);//third point
            vertexes[2].Color = System.Drawing.Color.FromArgb(255, 0, 0).ToArgb();
            device.Clear(ClearFlags.Target, Color.CornflowerBlue, 1.0f, 0);
            device.BeginScene();
            device.VertexFormat = TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.TriangleList, 1, vertexes);
            device.EndScene();
            device.Present();
        }
        private void Form1_Load(object sender, EventArgs e) { }

        public struct TransformedColored
        {
            public Vector4 Position;
            public int Color;

            public static readonly VertexFormats Format = VertexFormats.Transformed | VertexFormats.Diffuse;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
    }
}
