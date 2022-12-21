using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace testlib
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string time = "9:00:00";
            string[] timeValue = time.Split(':');
            TimeSpan timeSpans = new TimeSpan(int.Parse(timeValue[0]), int.Parse(timeValue[1]), int.Parse(timeValue[2]));

            TimeSpan beginWorkingTime = TimeSpan.FromHours(8);
            TimeSpan endWorkingTime = TimeSpan.FromHours(18);
            TimeSpan[] startTimes = new TimeSpan[] { timeSpans, TimeSpan.FromHours(13), TimeSpan.FromHours(15) };

            int[] durations = new int[] { 30, 10, 15 };

            int consultationTime = 30;
            int prov = 0;

            List<TimeSpan> periods = new List<TimeSpan>();

            while (beginWorkingTime < endWorkingTime)
            {
                if (startTimes[prov] >= beginWorkingTime & startTimes[prov] <= beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime)) | startTimes[prov].Add(TimeSpan.FromMinutes(durations[prov])) >= beginWorkingTime & startTimes[prov].Add(TimeSpan.FromMinutes(durations[prov])) <= beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime)))
                {
                    beginWorkingTime = startTimes[prov];
                    periods.Add(beginWorkingTime);
                    beginWorkingTime = beginWorkingTime.Add(TimeSpan.FromMinutes(durations[prov]));
                    periods.Add(beginWorkingTime);
                    beginWorkingTime = beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime));
                    if (prov < startTimes.Length - 1)
                    {
                        prov++;
                    }

                }
                else
                {
                    periods.Add(beginWorkingTime);

                    beginWorkingTime = beginWorkingTime.Add(TimeSpan.FromMinutes(consultationTime));

                    periods.Add(beginWorkingTime);
                }

            }


            for (int i = 0; i < periods.Count - 1; i++)
            {
                if (periods[i + 1].Subtract(periods[i]) != TimeSpan.FromMinutes(consultationTime))
                {

                }
                else
                {
                    listBox1.Items.Add(periods[i] + "-" + periods[i + 1]);
                }

            }
        }
    }
}
