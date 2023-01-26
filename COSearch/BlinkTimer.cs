using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSearch
{
    public partial class BlinkTimer : Form
    {
        public BlinkTimer(int[] timeline, int breakingFrames = 0, double frequency = 29.97 * 2)
        {
            InitializeComponent();

            dataGridView1.Rows.Add(timeline.Length);
            for (int i = 0; i < timeline.Length; i++)
                dataGridView1.Rows[i].Cells[0].Value = timeline[i];

            checkPoints = new int[timeline.Length];
            checkPoints[0] = timeline[0] * 2;
            for (int i = 1; i < timeline.Length; i++)
                checkPoints[i] = checkPoints[i - 1] + timeline[i] * 2;

            this.frequency = frequency;
            this.breakingFrames = breakingFrames;

            blinkSoundPlayer = new SoundPlayer(Properties.Resources.button_7);
            beepPlayer = new SoundPlayer(Properties.Resources.beep_07a);
        }

        private readonly SoundPlayer blinkSoundPlayer, beepPlayer;

        private readonly int breakingFrames;
        private readonly int beepCount = 5;
        private readonly double frequency;
        private readonly int[] checkPoints;

        // 瞬き開始までの開始時オフセット
        // 瞬き終了より早く切り上げる終了時オフセット
        // エンターキーバインド

        private int buffer = 0;
        private bool isWorking, isFinished = true;
        private async void button1_Click(object sender, EventArgs e)
        {
            if (isWorking || !isFinished)
            {
                isWorking = false;
                return;
            }


            isWorking = true;
            isFinished = false;
            button1.Text = "Stop";

            await Task.Run(() =>
            {
                void task()
                {
                    var rows = dataGridView1.Rows;
                    using (var graphic = pictureBox1.CreateGraphics())
                    {
                        // タイマーのバーを初期化
                        graphic.Clear(Color.Cyan);

                        var terminal = checkPoints.Last() - breakingFrames;
                        var interval = 10000000 / frequency;
                        var start = DateTime.Now.Ticks;
                        var nextFrame = start + interval;

                        var nextBeep = beepCount - 1;

                        rows[0].Selected = true;
                        int cnt = 0;
                        for (int i = 0; i < checkPoints.Length; i++)
                        {
                            // タイマーの1区間あたりの処理
                            while (cnt < checkPoints[i] + buffer)
                            {
                                var tick = DateTime.Now.Ticks;
                                if (tick >= nextFrame)
                                {
                                    // 中断処理
                                    if (!isWorking) return;

                                    cnt++;
                                    nextFrame += interval;

                                    // 残り時間の更新
                                    var rem = terminal + buffer - cnt;
                                    if (rem >= 0)
                                        Task.Run(() => { try { Invoke((MethodInvoker)(() => UpdateTime(rem))); } catch { } });

                                    // タイマーのバーの描画
                                    if (rem * 2 / frequency < beepCount - 1)
                                    {
                                        if (nextBeep == beepCount - 1)
                                        {
                                            graphic.Clear(Color.Red);
                                        }

                                        var barWidth = rem * 2.5f;
                                        graphic.FillRectangle(Brushes.White, barWidth, 0, 300 - barWidth, 50);
                                    }
                                    else
                                    {
                                        var barWidth = (checkPoints[i] + buffer - cnt) * 1.5f;
                                        graphic.FillRectangle(Brushes.White, barWidth, 0, 300 - barWidth, 50);
                                    }

                                    // 全体の待機時間の終わりらへんで音を鳴らす
                                    if (rem * 2 / frequency < nextBeep)
                                    {
                                        if (nextBeep >= 0)
                                            nextBeep--;
                                        Task.Run(() => Invoke((MethodInvoker)beepPlayer.Play));
                                    }
                                }
                            }

                            // 中断処理
                            if (!isWorking) return;

                            // 区間表示の更新
                            rows[i].Selected = false;
                            if (i < checkPoints.Length - 1)
                                rows[i + 1].Selected = true;
                            if (i >= 4)
                                Task.Run(() => Invoke((MethodInvoker)(() => dataGridView1.FirstDisplayedScrollingRowIndex = i - 4)));

                            // 全体の待機時間終了まで余裕がある場合のみ
                            if ((terminal + buffer - cnt) * 2 / frequency > beepCount)
                            {
                                // タイマーのバーを初期化
                                graphic.Clear(Color.Cyan);
                                // 区間の終わりに音を鳴らす処理
                                Task.Run(() => Invoke((MethodInvoker)blinkSoundPlayer.Play));
                            }
                            // カウント終了時にも1回鳴らす
                            else if (nextBeep == 0)
                            {
                                Task.Run(() => Invoke((MethodInvoker)beepPlayer.Play));
                            }
                        }
                    }
                }

                task();
                isWorking = false;
                isFinished = true;
            });

            pictureBox1.Visible = true;
            button1.Text = "Start";
        }

        private void UpdateTime(int frame) => label1.Text = $"{frame / frequency:f2}";

        private void UpdateBuffer(int diff)
        {
            buffer += diff;
            var sign = buffer == 0 ? "±" :
                buffer > 0 ? "+" : "";
            label2.Text = $"{sign}{buffer}";
        }
        private void button2_Click(object sender, EventArgs e) => UpdateBuffer(-5);
        private void button3_Click(object sender, EventArgs e) => UpdateBuffer(-1);
        private void button4_Click(object sender, EventArgs e) => UpdateBuffer(+1);
        private void button5_Click(object sender, EventArgs e) => UpdateBuffer(+5);


        private void BlinkTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isWorking)
            {
                e.Cancel = true;
                isWorking = false;
                while (!isFinished) { }

                Close();
            }
        }


    }
}
