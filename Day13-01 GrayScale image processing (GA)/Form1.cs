namespace Day10_02_GrayScale_image_processing__Beta_1_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ////////// 메뉴 클릭시 실행되는 함수
        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void 저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }
        private void 종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 전역 변수 선언
        static byte[,] inImage = null, outImage = null, tempImage = null;
        static int inH, inW, outH, outW;
        static string fileName;
        static Bitmap paper; // 그림을 그릴 종이 (볼펜으로 콕콕 찍기)

        private void 동일영상ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equal_image();
        }

        private void 반전영상ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reverseImage();
        }

        private void 밝게어둡게ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightnessImage();
        }

        private void 흑백ToolStripMenuItem_Click(object sender, EventArgs e)//흑백 127기준
        {
            grayScale127();
        }

        private void 파라볼라ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paraImage();
        }

        private void 감마ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamma();
        }

        private void 회전ToolStripMenuItem_Click(object sender, EventArgs e)//90도 회전
        {
            turn_90degree_rotation();
        }

        private void 이동ToolStripMenuItem_Click(object sender, EventArgs e)//이동
        {
            move();
        }

        private void 확대ToolStripMenuItem_Click(object sender, EventArgs e)//확대 (일단 2배)
        {
            zoomIn();
        }

        private void 축소ToolStripMenuItem_Click(object sender, EventArgs e)//축소 (일단 2배)
        {
            zoomOut();
        }

        private void 흑백평균값ToolStripMenuItem_Click(object sender, EventArgs e)//흑백평균값
        {
            grayScaleAvg();
        }

        private void 스트레칭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_stretch();
        }

        private void 앤드인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            end_in();
        }

        private void 평활화ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_equalize();
        }

        private void 회전정방향ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate1_image();
        }

        private void 회전중앙역방향ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate2_image();
        }

        private void 회전화면크기유지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate3_image();
        }

        private void 회전사진크기유지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rotate4_image();
            rotate5_image();
        }

        private void 엠보싱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            embossing();
        }

        private void 블러핑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blurr();
        }

        private void 샤프닝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sharpening();
        }

        private void 고주파필터샤프닝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hpfSharp();
        }

        private void 수평수직엣지검출ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vert_hori_edge();
        }

        private void loGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoG();
        }

        private void doGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoG();
        }

        //////////  공통 함수 부분 //////////////
        void openImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            fileName = ofd.FileName;

            BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open));
            // (중요!) 이미지의 폭과 높이
            long fsize = new FileInfo(fileName).Length;
            inH = inW = (int)Math.Sqrt(fsize);
            // 메모리 할당
            inImage = new byte[inH, inW];
            // 파일 --> 메모리
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    inImage[i, k] = br.ReadByte();
                
            br.Close();
            displayImage_input();
        }

        void saveImage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            string saveName;
            //sfd.DefaultExt = "raw";
            sfd.Filter = "RAW File (*.raw)|*.raw";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                saveName = sfd.FileName;
                pb_outImage.Image.Save(saveName);
                MessageBox.Show("저장완료");
            }

            //SaveFileDialog sfd = new SaveFileDialog();
            //string filename1 = "";

            //sfd.InitialDirectory = "C:/images";
            //sfd.Title = "저장";
            //sfd.DefaultExt = "raw";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    filename1 = sfd.FileName.ToString();
            //}


        }

        void displayImage_input()
        {
            // 크기 지정
            paper = new Bitmap(inH, inW); // 종이
            pb_inImage.Size = new Size(inH, inW); // 액자
            this.Size = new Size(inH + 100, inW + 150);  // 벽

            Color pen; // 펜(콕콕 찍을 용도)
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    byte ink = inImage[i, k]; // 잉크(색상값)
                    pen = Color.FromArgb(ink, ink, ink); // 펜에 잉크 묻히기
                    paper.SetPixel(k, i, pen); // 종이에 한점 콕 직기
                }
            }
            pb_inImage.Image = paper; // 액자에 종이 걸기
            toolStripStatusLabel1.Text = Path.GetFileName(fileName); ;
            toolStripStatusLabel2.Text = inH.ToString() + 'x' + inW.ToString();
            toolStripStatusLabel3.Text = inH.ToString() + 'x' + inW.ToString();
        }

        void tempdisplayImage()
        {
            // 크기 지정
            paper = new Bitmap(inH+50, inW+50); // 종이
            pb_inImage.Size = new Size(inH, inW); // 액자
            this.Size = new Size(inH + 100, inW + 150);  // 벽

            Color pen; // 펜(콕콕 찍을 용도)
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    byte ink = tempImage[i, k]; // 잉크(색상값)
                    pen = Color.FromArgb(ink, ink, ink); // 펜에 잉크 묻히기
                    paper.SetPixel(k, i, pen); // 종이에 한점 콕 직기
                }
            }
            pb_inImage.Image = paper; // 액자에 종이 걸기

        }

        void displayImage()
        {
            // pb_outImage 위치 선정
            pb_outImage.Location = new Point(inH + 80, pb_inImage.Location.Y);

            // 크기 지정
            paper = new Bitmap(outH, outW); // 종이
            pb_outImage.Size = new Size(outH, outW); // 액자
            if (outW > inW)
                this.Size = new Size(outH + 20 + inH + 120, outW + 150);  // 벽
            else
                this.Size = new Size(outH + 20 + inH + 120, inW + 150);  // 벽

            Color pen; // 펜(콕콕 찍을 용도)
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    byte ink = outImage[i, k]; // 잉크(색상값)
                    pen = Color.FromArgb(ink, ink, ink); // 펜에 잉크 묻히기
                    paper.SetPixel(k, i, pen); // 종이에 한점 콕 직기

                }
            }
            pb_outImage.Image = paper; // 액자에 종이 걸기
            toolStripStatusLabel3.Text = outH.ToString() + 'x' + outW.ToString();
        }


        /////// 영상 처리 함수 모음 ///////////
        void equal_image()  // 동일영상 알고리즘
        {
            if(inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = inImage[i, k];
            
            displayImage();
        }


        void reverseImage() //반전 영상
        {
            if (inImage == null)
                return;

            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = (byte)(255 - inImage[i, k]);

            displayImage();
        }


        int getValue()
        {
            int value;
            input1Form sub = new input1Form(); //서브 폼 준비
            if (sub.ShowDialog() == DialogResult.Cancel)
                value = 0;
            else
                value = (int)(sub.updown_value.Value);

            return value;
        }


        void brightnessImage() //밝게,어둡게
        {
            if (inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            int value = getValue();

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    int px = inImage[i, k] + value;
                    if (px > 255)
                        px = 255;
                    else if (px < 0)
                        px = 0;
                    outImage[i, k] = (byte)px;
                }
            }

            displayImage();
        }


        void grayScale127()//흑백 127기준
        {
            if (inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    int px = inImage[i, k];
                    if (px > 127)
                        px = 255;
                    else
                        px = 0;
                    outImage[i, k] = (byte)px;
                }
            }

            displayImage();
        }

        void paraImage() //파라볼라 --> 잘 안되는거 같다. 흑백처럼 나옴
        {
            if (inImage == null)
                return;

            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double value = 255 - 255 * ((double)inImage[i, k] / 128 - 1) * (inImage[i, k] / 128 - 1);
                    outImage[i, k] = (byte)value;
                }
            }

            displayImage();
        }

        void gamma()
        {
            if (inImage == null)
                return;

            // 감마 1.2 보정
            double value = 1.2;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double temp = 0;
                    temp = Math.Pow(inImage[i, k], (1 / value));
                    if (outImage[i, k] > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = (byte)temp;
                }
            }
            displayImage();
        }

        void turn_90degree_rotation()//90도 회전
        {
            if (inImage == null)
                return;

            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[k, inW - 1 - i] = inImage[i, k];

            displayImage();
        }

        void move() //이동 영상
        {
            if (inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            int value = getValue();

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    if (i < value || k < value)
                        outImage[i, k] = 0;
                    else
                        outImage[i, k] = inImage[i - value, k - value];
                }
            }

            displayImage();
        }

 
        void zoomIn() //2배 확대
        {
            if (inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....

            int value = getValue();

            outH = value * inH;
            outW = value * inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            //int value = getValue();

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    outImage[i, k] = inImage[i/value, k/value];

            displayImage();
        }

        void zoomOut() //2배 축소
        {
            if (inImage == null)
                return;
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH / 2;
            outW = inW / 2;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            //int value = getValue();

            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    outImage[i, k] = inImage[i * 2, k * 2];
                }
            }

            displayImage();
        }



        void grayScaleAvg() //흑백(평균값)
        {
            if (inImage == null)
            {
                return;
            }
            //평균 구하기
            int avg = 0;
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    avg += inImage[i, k];
                }
            }
            avg = avg / (inH * inW);

            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    int px = inImage[i, k];
                    if (px > avg)
                        px = 255;
                    else
                        px = 0;
                    outImage[i, k] = (byte)px;
                }
            }

            displayImage();
        }


        void histo_stretch()//스트레칭 영상 처리
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // out = (in - low) / (high - low) * 255
            int low = inImage[0, 0];
            int high = inImage[0, 0];

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] < low)
                        low = inImage[i, k];
                    if (inImage[i, k] > high)
                        high = inImage[i, k];
                }
            }

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double outValue = (inImage[i, k] - (double)low) / (high - (double)low) * 255;
                    if (outValue < 0)
                        outValue = 0.0;
                    else if(outValue > 255)
                        outValue = 255.0;

                    outImage[i, k] = (byte)outValue;
                }
            }
            displayImage();
        }


        void end_in()//스트레칭 영상 처리
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // out = (in - low) / (high - low) * 255
            int low = inImage[0, 0];
            int high = inImage[0, 0];

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    if (inImage[i, k] < low)
                        low = inImage[i, k];
                    if (inImage[i, k] > high)
                        high = inImage[i, k];
                }
            }
            low += 50;
            high -= 50;

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double outValue = (inImage[i, k] - (double)low) / (high - low) * 255;
                    if (outValue < 0)
                        outValue = 0.0;
                    else if (outValue > 255)
                        outValue = 255.0;

                    outImage[i, k] = (byte)outValue;
                }
            }
            displayImage();
        }



        void histo_equalize()  // 평활화 알고리즘
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            //1단계 : 히스토그램 생성
            int[] hist = new int[256];

            for(int i = 0; i < 256;i++)
            {
                hist[i] = 0;
            }

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    hist[inImage[i, k]] += 1;
                }
            }

            //2단계 : 누적 히스토그램 생성
            int[] sumHist = new int[256];
            int sValue = 0;

            for(int i = 0; i < 256;i++)
            {
                sValue += hist[i];
                sumHist[i] = sValue;
            }

            //3단계 : 정규화된 누적히스토그램 생성
            //n = (sumHist / (행, 열)) * 255.0
            double[] normalHist = new double[256];
            for(int i = 0; i < 256; i++)
            {
                normalHist[i] = (sumHist[i] / (double)(inH * inW)) * 255.0;
            }

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    outImage[i, k] = (byte)normalHist[inImage[i, k]];
                }
            }

            displayImage();
        }



        void rotate1_image() //회전 영상 - 안되는것
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();

            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    int xd = (int)(Math.Cos(angle) * i - Math.Sin(angle) * k);
                    int yd = (int)(Math.Cos(angle) * i - Math.Sin(angle) * k);
                    if((xd >= 0 && xd < outH) && (yd >= 0 && yd < outW))
                        outImage[xd, yd] = inImage[i, k];
                }
            }

            displayImage();
        }



        void rotate2_image()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;
            int cx = outH / 2;
            int cy = outW / 2;


            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    //int xs = (int)(Math.Cos(radian) * (i) + Math.Sin(radian) * (k));
                    //int ys = (int)(-Math.Sin(radian) * (i) + Math.Cos(radian) * (k));
                    //xs += cx;
                    //ys += cy;
                    //if ((xs >= 0 && xs < inH) && (ys >= 0 && ys < inW))
                    //    outImage[i, k] = inImage[xs, ys];



                    int xs = (int)(Math.Cos(radian) * (i - cx) + Math.Sin(radian) * (k - cy));
                    int ys = (int)(-Math.Sin(radian) * (i - cx) + Math.Cos(radian) * (k - cy));
                    xs += cx;
                    ys += cy;
                    if ((xs >= 0 && xs < inH) && (ys >= 0 && ys < inW))
                        outImage[i, k] = inImage[xs, ys];
                }
            }

            displayImage();
        }



        void rotate3_image()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;
            int cx = outH / 2;
            int cy = outW / 2;

            //각도에 따른 원본 사진 크기 수정
            tempImage = new byte[inH, inW];
            double temp = (double)inH / (Math.Cos(radian) + Math.Sin(radian));
            int tempx = (int)temp;

            Console.WriteLine(tempx);

            for (int i = 0; i < tempx; i++)
            {
                for (int k = 0; k < tempx; k++)
                {
                    if(i * inH / tempx < inH && k * inW / tempx < inW)
                        tempImage[i + ((inH - tempx) / 2), k + ((inW - tempx) / 2)] = inImage[(int)(i * inH/ tempx), (int)(k * inW / tempx)];
                }
            }


            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    int xs = (int)(Math.Cos(radian) * (i - cx) + Math.Sin(radian) * (k - cy));
                    int ys = (int)(-Math.Sin(radian) * (i - cx) + Math.Cos(radian) * (k - cy));
                    xs += cx;
                    ys += cy;
                    if ((xs >= 0 && xs < inH) && (ys >= 0 && ys < inW))
                        outImage[i, k] = tempImage[xs, ys];
                }
            }

            displayImage();
            //tempdisplayImage();
        }

        void rotate4_image()
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            //outH = inH;
            //outW = inW;
            // 출력 영상 메모리 할당.
            //outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;
            //int cx = outH / 2;
            //int cy = outW / 2;

            //outH, outW 사이즈 조절, tempImage 사이즈 맞추기
            double temp = inH * (Math.Cos(radian) + Math.Sin(radian));
            int tempx = (int)temp;

            tempImage = new byte[tempx, tempx];
            for (int i = 0; i < tempx; i++)
                for (int k = 0; k < tempx; k++)
                    tempImage[i, k] = 0;

            for(int i = 0; i < inH;i++)
                for(int k = 0; k < inW;k++)
                    tempImage[i + (tempx - inH) / 2, k + (tempx - inW) / 2] = inImage[i,k];



            Console.WriteLine(tempx);

            outH = tempx;
            outW = tempx;
            outImage = new byte[outH, outW];

            int cx = tempx / 2;
            int cy = tempx / 2;

            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    int xs = (int)(Math.Cos(radian) * (i - cx) + Math.Sin(radian) * (k - cy));
                    int ys = (int)(-Math.Sin(radian) * (i - cx) + Math.Cos(radian) * (k - cy));
                    xs += cx;
                    ys += cy;

                    if ((xs >= 0 && xs < outH) && (ys >= 0 && ys < outW))
                        outImage[i, k] = tempImage[xs, ys];
                    
                }
            }

            displayImage();
            //tempdisplayImage();
        }

        void rotate5_image()
        {
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;

            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            // x' = y*cos(90-seta) + x*cos();
            // y' = y*cos() + x*cos(90-seta);
            outW = (int)(inH * Math.Abs(Math.Cos((Math.PI / 2 - radian))) + inW * Math.Abs(Math.Cos(radian)));
            outH = (int)(inH * Math.Abs(Math.Cos(radian)) + inW * Math.Abs(Math.Cos(Math.PI / 2 - radian)));

            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];
            // ** 영상처리 알고리즘 **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys

            int xdc = outW / 2; int ydc = outH / 2;
            int xsc = inW / 2; int ysc = inH / 2;
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    // destion 기준을 source 기준으로 바꿈 (정방향 -> 역방향 기능)
                    int xs = (int)(Math.Cos(radian) * (i - xdc) + Math.Sin(radian) * (k - ydc));
                    int ys = (int)(-Math.Sin(radian) * (i - xdc) + Math.Cos(radian) * (k - ydc));
                    xs += xsc;
                    ys += ysc;

                    if (!((0 <= xs && xs < inW) && (0 <= ys && ys < inH)))
                        outImage[i, k] = 0;
                    else outImage[i, k] = inImage[xs, ys];

                }
            }
            ////////////////////////////
            displayImage();
        }



        void embossing()  // 앰보싱 알고리즘
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            const int MSIZE = 3;
            double[,] mask = { { -1.0, 0.0, 0.0 },
                                {0.0, 0.0, 0.0 },
                                {0.0, 0.0, 1.0 }}; //엠보싱 마스크

            //임시 입출력 메모리 확보
            double[,] tmpInput = new double[inH+2, inW+2];
            double[,] tmpOutput = new double[inH, inW+2];
            //임시 입력을 초기화(0, 127, 평균값)
            for(int i = 0; i < inH + 2; i++)
                for(int k = 0; k < inW+2; k++)
                    tmpInput[i, k] = 127.0;

            //입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //회선 연산
            for(int i  = 0; i < inH;i++)
            {
                for(int k = 0; k < inW;k++)
                {
                    //한점에 대한 마스크 연산
                    double S = 0.0;
                    for(int m = 0; m < MSIZE;m++)
                        for(int n = 0; n < MSIZE;n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            //마스크의 합계가 0이면, 127 정도 더해주기.
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                        outImage[i, k] = 0;
                    else if (tmpOutput[i, k] > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i,k] = (byte)tmpOutput[i, k];
                }
            }
            displayImage();
        }

        void blurr()  // 블러핑 알고리즘
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            const int MSIZE = 3;
            double[,] mask = { { 0.11, 0.11, 0.11 },
                                {0.11, 0.11, 0.11 },
                                {0.11, 0.11, 0.11 }}; //블러링 마스크

            //임시 입출력 메모리 확보
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 초기화(0, 127, 평균값)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //회선 연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //한점에 대한 마스크 연산
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////마스크의 합계가 0이면, 127 정도 더해주기.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                        outImage[i, k] = 0;
                    else if (tmpOutput[i, k] > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = (byte)tmpOutput[i, k];
                }
            }
            displayImage();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        void sharpening()  // 샤프닝 알고리즘
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            const int MSIZE = 3;
            //double[,] mask = { { 0, -1, 0 },
            //                    {-1, 5, -1 },
            //                    {0, -1, 0 }}; //샤프닝 마스크

            double[,] mask = { { -1, -1, -1 },
                                {-1, 9, -1 },
                                {-1, -1, -1 }}; //샤프닝 마스크

            //임시 입출력 메모리 확보
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 초기화(0, 127, 평균값)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //회선 연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //한점에 대한 마스크 연산
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////마스크의 합계가 0이면, 127 정도 더해주기.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                        outImage[i, k] = 0;
                    else if (tmpOutput[i, k] > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = (byte)tmpOutput[i, k];
                }
            }
            displayImage();
        }

        void hpfSharp()  // 고주파 필터 샤프닝 알고리즘
        {
            if (inImage == null)
            {
                return;
            }
            // 중요! 출력 영상의 크기를 결정 --> 알고리즘에 따라서....
            outH = inH;
            outW = inW;
            // 출력 영상 메모리 할당.
            outImage = new byte[outH, outW];

            // ** 영상처리 알고리즘 **
            const int MSIZE = 3;
            //double[,] mask = { { 0, -1, 0 },
            //                    {-1, 5, -1 },
            //                    {0, -1, 0 }}; //고주파 필터 샤프닝 마스크

            double[,] mask = {{-0.11, -0.11, -0.11},
                               {-0.11, 0.9, -0.11},
                               {-0.11, -0.11, -0.11}}; //샤프닝 마스크

            //임시 입출력 메모리 확보
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //임시 입력을 초기화(0, 127, 평균값)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //입력 --> 임시 입력
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //회선 연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //한점에 대한 마스크 연산
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////마스크의 합계가 0이면, 127 정도 더해주기.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //임시 출력 -> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                        outImage[i, k] = 0;
                    else if (tmpOutput[i, k] > 255)
                        outImage[i, k] = 255;
                    else
                        outImage[i, k] = (byte)tmpOutput[i, k];
                }
            }
            displayImage();
        }

        void vert_hori_edge() // 수직 수평 엣지 검출
        {
            if (inImage == null)
                return;
            //중요! 출력영상의 크기를 결정 --> 알고리즘에 따라서 ....
            outH = inH;
            outW = inW;
            //출력영상 메모리 할당
            outImage = new byte[outH, outW];
            //  ** 영상처리 알고리즘 **

            const int MSIZE = 3;
            double[,] mask;

            mask = new double[,]{ {0,0,0},
                               {-1,1,0},
                               {0,0,0} };//수직에지검출마스크1

            //mask = new double[,]{ {0,-1,0},
            //                   {0,1,0},
            //                   {0,0,0} };//수평에지검출마스크2

            //입출력 메모리확보
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];
            //임시 입력을 초기화
            for (int i = 0; i < inH + 2; i++)
            {
                for (int k = 0; k < inW + 2; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //입력-->임시입력
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 1, k + 1] = inImage[i, k];
                }
            }
            //회선연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                    {
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[i + m, k + n];
                        }
                    }
                    tmpOutput[i, k] = S;
                }
            }

            //마스크의 합계에 따라서 127정도를 더해주기
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }

            //임시출력 --> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                    {
                        outImage[i, k] = 0;
                    }
                    else if (tmpOutput[i, k] > 255)
                    {
                        outImage[i, k] = 255;
                    }
                    else
                    {
                        outImage[i, k] = (byte)tmpOutput[i, k];
                    }
                }
            }
            displayImage();
        }

        void LoG()
        {
            if (inImage == null)
                return;
            //중요! 출력영상의 크기를 결정 --> 알고리즘에 따라서 ....
            outH = inH;
            outW = inW;
            //출력영상 메모리 할당
            outImage = new byte[outH, outW];
            //  ** 영상처리 알고리즘 **
            const int MSIZE = 5;
            double[,] mask = { { 0.0, 0.0, -1, 0.0, 0.0 },
                        { 0.0, -1, -2, -1, 0.0 },
                        { -1, -2, 16, -2, -1 },
                        { 0.0, -1, -2, -1, 0.0 },
                        { 0.0, 0.0, -1, 0.0, 0.0 } };
            //입출력 메모리확보
            double[,] tmpInput = new double[inH + 4, inW + 4];
            double[,] tmpOutput = new double[outH, outW];
            //임시 입력을 초기화
            for (int i = 0; i < inH + 4; i++)
            {
                for (int k = 0; k < inW + 4; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //입력-->임시입력
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 2, k + 2] = inImage[i, k];
                }
            }
            //회선연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                    {
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[i + m, k + n];
                        }
                    }
                    tmpOutput[i, k] = S;
                }
            }
            //마스크의 합계에 따라서 127정도를 더해주기
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //임시출력 --> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                    {
                        outImage[i, k] = 0;
                    }
                    else if (tmpOutput[i, k] > 255)
                    {
                        outImage[i, k] = 255;
                    }
                    else
                    {
                        outImage[i, k] = (byte)tmpOutput[i, k];
                    }
                }
            }
            displayImage();
        }

        void DoG()
        {
            if (inImage == null)
                return;
            //중요! 출력영상의 크기를 결정 --> 알고리즘에 따라서 ....
            outH = inH;
            outW = inW;
            //출력영상 메모리 할당
            outImage = new byte[outH, outW];
            //  ** 영상처리 알고리즘 **
            const int MSIZE = 7;
            double[,] mask = { { 0.0, 0.0, -1.0, -1.0, -1.0, 0.0, 0.0 },
                        { 0.0, -2.0, -3.0, -3.0, -3.0, -2.0, 0.0 },
                        { -1.0, -3.0, 5.0, 5.0, 5.0, -3.0, -1.0 },
                        { -1.0, -3.0, 5.0, 16.0, 5.0, -3.0, -1.0 },
                        { -1.0, -3.0, 5.0, 5.0, 5.0, -3.0, -1.0 },
                        { 0.0, -2.0, -3.0, -3.0, -3.0, -2.0, 0.0 },
                        { 0.0, 0.0, -1.0, -1.0, -1.0, 0.0, 0.0 } };
            //입출력 메모리확보
            double[,] tmpInput = new double[inH + 6, inW + 6];
            double[,] tmpOutput = new double[outH, outW];
            //임시 입력을 초기화
            for (int i = 0; i < inH + 6; i++)
            {
                for (int k = 0; k < inW + 6; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //입력-->임시입력
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 3, k + 3] = inImage[i, k];
                }
            }
            //회선연산
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                    {
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[i + m, k + n];
                        }
                    }
                    tmpOutput[i, k] = S;
                }
            }
            //마스크의 합계에 따라서 127정도를 더해주기
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //임시출력 --> 출력
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    if (tmpOutput[i, k] < 0)
                    {
                        outImage[i, k] = 0;
                    }
                    else if (tmpOutput[i, k] > 255)
                    {
                        outImage[i, k] = 255;
                    }
                    else
                    {
                        outImage[i, k] = (byte)tmpOutput[i, k];
                    }
                }
            }
            displayImage();
        }
    }
}