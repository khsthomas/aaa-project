using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AAA.Base.Image;
using AAA.Algorithm.Data;
using AAA.Algorithm.Cluster.SOM;
using AAA.ResultSet;

namespace AAA.ImageMatching
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                picGoldenImage.Image = Image.FromFile(Environment.CurrentDirectory + @"\Golden\" + txtGoldenImage.Text);
                picCompare.Image = Image.FromFile(Environment.CurrentDirectory + @"\Defect\" + txtCompareImage.Text);

                //ImageProcessor imageProcessor = new ImageProcessor((Bitmap)picGoldenImage.Image);
                //picResult.Image = imageProcessor.CutBackground((Bitmap)picCompare.Image, 20);
                Dictionary<string, int> x = ImageHelper.CalulateRGB((Bitmap)picGoldenImage.Image,10); 

                List<string> FactorList = new List<string>();
                FactorList.Add("R");
                FactorList.Add("G");
                FactorList.Add("B");
                SOM ColorSOM = new SOM(3, 3, 1, FactorList, 0, 1);
                Bitmap xBitMap = (Bitmap)picCompare.Image;
                for (int i = 0; i < xBitMap.Width; i++)
                {
                    for (int j = 0; j < xBitMap.Height; j++)
                    {
                        INeuron SampleNode = new Neuron();
                        SampleNode.SetFactor("R", xBitMap.GetPixel(i, j).R/5);
                        SampleNode.SetFactor("G", xBitMap.GetPixel(i, j).G/5);
                        SampleNode.SetFactor("B", xBitMap.GetPixel(i, j).B/5);
                        SampleNode.SetAttribute("X", i);
                        SampleNode.SetAttribute("Y", j);
                        ColorSOM.AddNeuron(SampleNode);
                    }
                }
                ColorSOM.LearningCount = 10;
                ColorSOM.Clustering();
                //ColorSOM.PrintResult();
                SOMMapNode CurMapNode = null;
                int MaxNodeCount = 0;
                foreach (string ClusterName in ColorSOM.GetClusterName())
                {
                    if (ColorSOM.GetCluster(ClusterName).SampleCount > MaxNodeCount)
                    {
                        CurMapNode = (SOMMapNode)ColorSOM.GetCluster(ClusterName);
                        MaxNodeCount = ColorSOM.GetCluster(ClusterName).SampleCount;
                    }
                }
                Bitmap NewGolden = new Bitmap((Bitmap)picGoldenImage.Image);
                for (int i = 0; i < CurMapNode.SampleCount; i++)
                {
                    INeuron SampleData = CurMapNode.GetSample(i);
                    NewGolden.SetPixel((int)SampleData.GetAttribute("X"), (int)SampleData.GetAttribute("Y"), Color.Black);
                }
                picResult.Image = NewGolden;
                picGoldenImage.SizeMode = PictureBoxSizeMode.StretchImage;
                picCompare.SizeMode = PictureBoxSizeMode.StretchImage;
                picResult.SizeMode = PictureBoxSizeMode.StretchImage;

                //picResult.Image = ImageHelper.CutBackground((Bitmap)picGoldenImage.Image, (Bitmap)picCompare.Image, int.Parse(txtTollence.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextResultSet sourceFile = new TextResultSet(Environment.CurrentDirectory + "\\TestData\\iris.txt", '\t');
            sourceFile.Load();
            List<string> FactorList = new List<string>();
            FactorList.Add("A");
            FactorList.Add("B");
            FactorList.Add("C");
            FactorList.Add("D");
            SOM ColorSOM = new SOM(3, 3, 1, FactorList,0,1);
            while (sourceFile.Read())
            {
                INeuron SampleNode = new Neuron();
                SampleNode.SetFactor("A", float.Parse(sourceFile.Cells("A").ToString()));
                SampleNode.SetFactor("B", float.Parse(sourceFile.Cells("B").ToString()));
                SampleNode.SetFactor("C", float.Parse(sourceFile.Cells("C").ToString()));
                SampleNode.SetFactor("D", float.Parse(sourceFile.Cells("D").ToString()));
                SampleNode.SetAttribute("E", float.Parse(sourceFile.Cells("E").ToString()));
                ColorSOM.AddNeuron(SampleNode);
            }
            ColorSOM.LearningCount = 1000;
            ColorSOM.Clustering();
            ColorSOM.PrintResult();

        }

    }
}
