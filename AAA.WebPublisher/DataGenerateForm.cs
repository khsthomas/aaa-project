using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AAA.WebPublisher
{
    public partial class DataGenerateForm : Form
    {
        public DataGenerateForm()
        {
            InitializeComponent();
        }

        private void btnFuturesEstimateVol_Click(object sender, EventArgs e)
        {
            //Date Time, Symbol, Open, High, Low, Close, Vol, Amt

            StreamReader sr = null;
            StreamWriter sw = null;
            List<string> lstTime = new List<string>();
            Dictionary<string, double> dicVolume;
            Dictionary<string, double> dicSum;
            Dictionary<string, double> dicSquareOfSum;
            Dictionary<string, double> dicMean;
            Dictionary<string, double> dicStddev;
            Dictionary<string, List<double>> dicRatio;
            string strLine;
            string[] strValues;
            string strTime;
            string strDate;
            double dVolume;
            double dRatio;
            double dMax;
            double dMin;
            string strPreviousDate = "";
            int iDayCount;            

            int iCount;
            double dSum;
            double dSquareOfSum;
            List<double> lstRatio;

            try
            {
                sr = new StreamReader(Environment.CurrentDirectory + @"\txf_1m_db.txt");
                dVolume = 0;
                dicVolume = new Dictionary<string, double>();
                dicSquareOfSum = new Dictionary<string,double>();
                dicSum = new Dictionary<string,double>();
                dicMean = new Dictionary<string, double>();
                dicStddev = new Dictionary<string, double>();
                dicRatio = new Dictionary<string,List<double>>();
                iDayCount = 0;

                while ((strLine = sr.ReadLine()) != null)
                {
                    strValues = strLine.Split(',');
                    strTime = strValues[0].Split(' ')[1];
                    strDate = strValues[0].Split(' ')[0];

                    if ((strPreviousDate != strDate) && (dVolume > 0))
                    {
                        for (int i = 0; i < lstTime.Count; i++)
                        {
                            dRatio = dicVolume[lstTime[lstTime.Count - 1]] / dicVolume[lstTime[i]];

                            if (dicSum.ContainsKey(lstTime[i]) == false)
                                dicSum.Add(lstTime[i], 0);
                            dicSum[lstTime[i]] += dRatio;

                            if (dicSquareOfSum.ContainsKey(lstTime[i]) == false)
                                dicSquareOfSum.Add(lstTime[i], 0);
                            dicSquareOfSum[lstTime[i]] += dRatio * dRatio;


                            if(dicRatio.ContainsKey(lstTime[i]) == false)
                                dicRatio.Add(lstTime[i], new List<double>());
                            dicRatio[lstTime[i]].Add(dRatio);
                        }
                        dVolume = 0;
                        iDayCount++;
                    }

                    if ((lstTime.IndexOf(strTime) < 0) && (strTime.CompareTo("08:46") >= 0) && (strTime.CompareTo("13:45") <= 0))
                        lstTime.Add(strTime);

                    dVolume += double.Parse(strValues[6]);
                    strPreviousDate = strDate;

                    if (dicVolume.ContainsKey(strTime) == false)
                        dicVolume.Add(strTime, 0);
                    dicVolume[strTime] = dVolume;
                }

                for (int i = 0; i < lstTime.Count; i++)
                {                    

                    dicMean.Add(lstTime[i], (iDayCount > 0 ? dicSum[lstTime[i]] / (double)iDayCount : 0.0));
                    dicStddev.Add(lstTime[i], Math.Sqrt((dicSquareOfSum[lstTime[i]] - dicSum[lstTime[i]] * dicSum[lstTime[i]] / (double)iDayCount) / (double)(iDayCount - 1)));

                    dMax = dicMean[lstTime[i]] + 1 * dicStddev[lstTime[i]];
                    dMin = dicMean[lstTime[i]] - 1 * dicStddev[lstTime[i]];

                    lstRatio = dicRatio[lstTime[i]];
                    iCount = 0;
                    dSum = 0;
                    dSquareOfSum = 0;

                    for(int j = 0; j < lstRatio.Count; j++)
                    {
                        if((lstRatio[j] < dMin) || (lstRatio[j] > dMax))
                            continue;

                        dSum += lstRatio[j];
                        dSquareOfSum += lstRatio[j] * lstRatio[j];
                        iCount++;
                    }

                    dicMean[lstTime[i]] = dSum / (double)iCount;
                    dicStddev[lstTime[i]] = Math.Sqrt((dSquareOfSum - dSum * dSum / (double)iCount) / (double)(iCount - 1));
                }
                sr.Close();

                sw = new StreamWriter(Environment.CurrentDirectory + @"\futures_estimate_vol_table.txt");

                for (int i = 0; i < lstTime.Count; i++)
                {
                    sw.WriteLine(lstTime[i] + "," + dicMean[lstTime[i]] + "," + dicStddev[lstTime[i]]);
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "," + ex.StackTrace);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
