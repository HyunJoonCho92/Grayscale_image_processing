namespace Day10_02_GrayScale_image_processing__Beta_1_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        ////////// �޴� Ŭ���� ����Ǵ� �Լ�
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openImage();
        }
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveImage();
        }
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ���� ���� ����
        static byte[,] inImage = null, outImage = null, tempImage = null;
        static int inH, inW, outH, outW;
        static string fileName;
        static Bitmap paper; // �׸��� �׸� ���� (�������� ���� ���)

        private void ���Ͽ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            equal_image();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reverseImage();
        }

        private void ��Ծ�Ӱ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightnessImage();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)//��� 127����
        {
            grayScale127();
        }

        private void �Ķ󺼶�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paraImage();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gamma();
        }

        private void ȸ��ToolStripMenuItem_Click(object sender, EventArgs e)//90�� ȸ��
        {
            turn_90degree_rotation();
        }

        private void �̵�ToolStripMenuItem_Click(object sender, EventArgs e)//�̵�
        {
            move();
        }

        private void Ȯ��ToolStripMenuItem_Click(object sender, EventArgs e)//Ȯ�� (�ϴ� 2��)
        {
            zoomIn();
        }

        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)//��� (�ϴ� 2��)
        {
            zoomOut();
        }

        private void �����հ�ToolStripMenuItem_Click(object sender, EventArgs e)//�����հ�
        {
            grayScaleAvg();
        }

        private void ��Ʈ��ĪToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_stretch();
        }

        private void �ص���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            end_in();
        }

        private void ��ȰȭToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histo_equalize();
        }

        private void ȸ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate1_image();
        }

        private void ȸ���߾ӿ�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate2_image();
        }

        private void ȸ��ȭ��ũ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rotate3_image();
        }

        private void ȸ������ũ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rotate4_image();
            rotate5_image();
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            embossing();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blurr();
        }

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sharpening();
        }

        private void ���������ͻ�����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hpfSharp();
        }

        private void ���������������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        //////////  ���� �Լ� �κ� //////////////
        void openImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            fileName = ofd.FileName;

            BinaryReader br = new BinaryReader(File.Open(fileName, FileMode.Open));
            // (�߿�!) �̹����� ���� ����
            long fsize = new FileInfo(fileName).Length;
            inH = inW = (int)Math.Sqrt(fsize);
            // �޸� �Ҵ�
            inImage = new byte[inH, inW];
            // ���� --> �޸�
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
                MessageBox.Show("����Ϸ�");
            }

            //SaveFileDialog sfd = new SaveFileDialog();
            //string filename1 = "";

            //sfd.InitialDirectory = "C:/images";
            //sfd.Title = "����";
            //sfd.DefaultExt = "raw";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    filename1 = sfd.FileName.ToString();
            //}


        }

        void displayImage_input()
        {
            // ũ�� ����
            paper = new Bitmap(inH, inW); // ����
            pb_inImage.Size = new Size(inH, inW); // ����
            this.Size = new Size(inH + 100, inW + 150);  // ��

            Color pen; // ��(���� ���� �뵵)
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    byte ink = inImage[i, k]; // ��ũ(����)
                    pen = Color.FromArgb(ink, ink, ink); // �濡 ��ũ ������
                    paper.SetPixel(k, i, pen); // ���̿� ���� �� ����
                }
            }
            pb_inImage.Image = paper; // ���ڿ� ���� �ɱ�
            toolStripStatusLabel1.Text = Path.GetFileName(fileName); ;
            toolStripStatusLabel2.Text = inH.ToString() + 'x' + inW.ToString();
            toolStripStatusLabel3.Text = inH.ToString() + 'x' + inW.ToString();
        }

        void tempdisplayImage()
        {
            // ũ�� ����
            paper = new Bitmap(inH+50, inW+50); // ����
            pb_inImage.Size = new Size(inH, inW); // ����
            this.Size = new Size(inH + 100, inW + 150);  // ��

            Color pen; // ��(���� ���� �뵵)
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    byte ink = tempImage[i, k]; // ��ũ(����)
                    pen = Color.FromArgb(ink, ink, ink); // �濡 ��ũ ������
                    paper.SetPixel(k, i, pen); // ���̿� ���� �� ����
                }
            }
            pb_inImage.Image = paper; // ���ڿ� ���� �ɱ�

        }

        void displayImage()
        {
            // pb_outImage ��ġ ����
            pb_outImage.Location = new Point(inH + 80, pb_inImage.Location.Y);

            // ũ�� ����
            paper = new Bitmap(outH, outW); // ����
            pb_outImage.Size = new Size(outH, outW); // ����
            if (outW > inW)
                this.Size = new Size(outH + 20 + inH + 120, outW + 150);  // ��
            else
                this.Size = new Size(outH + 20 + inH + 120, inW + 150);  // ��

            Color pen; // ��(���� ���� �뵵)
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    byte ink = outImage[i, k]; // ��ũ(����)
                    pen = Color.FromArgb(ink, ink, ink); // �濡 ��ũ ������
                    paper.SetPixel(k, i, pen); // ���̿� ���� �� ����

                }
            }
            pb_outImage.Image = paper; // ���ڿ� ���� �ɱ�
            toolStripStatusLabel3.Text = outH.ToString() + 'x' + outW.ToString();
        }


        /////// ���� ó�� �Լ� ���� ///////////
        void equal_image()  // ���Ͽ��� �˰���
        {
            if(inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = inImage[i, k];
            
            displayImage();
        }


        void reverseImage() //���� ����
        {
            if (inImage == null)
                return;

            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[i, k] = (byte)(255 - inImage[i, k]);

            displayImage();
        }


        int getValue()
        {
            int value;
            input1Form sub = new input1Form(); //���� �� �غ�
            if (sub.ShowDialog() == DialogResult.Cancel)
                value = 0;
            else
                value = (int)(sub.updown_value.Value);

            return value;
        }


        void brightnessImage() //���,��Ӱ�
        {
            if (inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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


        void grayScale127()//��� 127����
        {
            if (inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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

        void paraImage() //�Ķ󺼶� --> �� �ȵǴ°� ����. ���ó�� ����
        {
            if (inImage == null)
                return;

            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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

            // ���� 1.2 ����
            double value = 1.2;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
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

        void turn_90degree_rotation()//90�� ȸ��
        {
            if (inImage == null)
                return;

            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    outImage[k, inW - 1 - i] = inImage[i, k];

            displayImage();
        }

        void move() //�̵� ����
        {
            if (inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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

 
        void zoomIn() //2�� Ȯ��
        {
            if (inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....

            int value = getValue();

            outH = value * inH;
            outW = value * inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            //int value = getValue();

            for (int i = 0; i < outH; i++)
                for (int k = 0; k < outW; k++)
                    outImage[i, k] = inImage[i/value, k/value];

            displayImage();
        }

        void zoomOut() //2�� ���
        {
            if (inImage == null)
                return;
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH / 2;
            outW = inW / 2;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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



        void grayScaleAvg() //���(��հ�)
        {
            if (inImage == null)
            {
                return;
            }
            //��� ���ϱ�
            int avg = 0;
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    avg += inImage[i, k];
                }
            }
            avg = avg / (inH * inW);

            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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


        void histo_stretch()//��Ʈ��Ī ���� ó��
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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


        void end_in()//��Ʈ��Ī ���� ó��
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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



        void histo_equalize()  // ��Ȱȭ �˰���
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            //1�ܰ� : ������׷� ����
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

            //2�ܰ� : ���� ������׷� ����
            int[] sumHist = new int[256];
            int sValue = 0;

            for(int i = 0; i < 256;i++)
            {
                sValue += hist[i];
                sumHist[i] = sValue;
            }

            //3�ܰ� : ����ȭ�� ����������׷� ����
            //n = (sumHist / (��, ��)) * 255.0
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



        void rotate1_image() //ȸ�� ���� - �ȵǴ°�
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
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
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;
            int cx = outH / 2;
            int cy = outW / 2;

            //������ ���� ���� ���� ũ�� ����
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
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            //outH = inH;
            //outW = inW;
            // ��� ���� �޸� �Ҵ�.
            //outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys
            int angle = getValue();
            double radian = angle * Math.PI / 180.0;
            //int cx = outH / 2;
            //int cy = outW / 2;

            //outH, outW ������ ����, tempImage ������ ���߱�
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

            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            // x' = y*cos(90-seta) + x*cos();
            // y' = y*cos() + x*cos(90-seta);
            outW = (int)(inH * Math.Abs(Math.Cos((Math.PI / 2 - radian))) + inW * Math.Abs(Math.Cos(radian)));
            outH = (int)(inH * Math.Abs(Math.Cos(radian)) + inW * Math.Abs(Math.Cos(Math.PI / 2 - radian)));

            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];
            // ** ����ó�� �˰��� **
            // xd = cos * xs - sin * ys
            // yd = sin * xs + cos * ys

            int xdc = outW / 2; int ydc = outH / 2;
            int xsc = inW / 2; int ysc = inH / 2;
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    // destion ������ source �������� �ٲ� (������ -> ������ ���)
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



        void embossing()  // �ں��� �˰���
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            const int MSIZE = 3;
            double[,] mask = { { -1.0, 0.0, 0.0 },
                                {0.0, 0.0, 0.0 },
                                {0.0, 0.0, 1.0 }}; //������ ����ũ

            //�ӽ� ����� �޸� Ȯ��
            double[,] tmpInput = new double[inH+2, inW+2];
            double[,] tmpOutput = new double[inH, inW+2];
            //�ӽ� �Է��� �ʱ�ȭ(0, 127, ��հ�)
            for(int i = 0; i < inH + 2; i++)
                for(int k = 0; k < inW+2; k++)
                    tmpInput[i, k] = 127.0;

            //�Է� --> �ӽ� �Է�
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //ȸ�� ����
            for(int i  = 0; i < inH;i++)
            {
                for(int k = 0; k < inW;k++)
                {
                    //������ ���� ����ũ ����
                    double S = 0.0;
                    for(int m = 0; m < MSIZE;m++)
                        for(int n = 0; n < MSIZE;n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            //����ũ�� �հ谡 0�̸�, 127 ���� �����ֱ�.
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //�ӽ� ��� -> ���
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

        void blurr()  // ���� �˰���
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            const int MSIZE = 3;
            double[,] mask = { { 0.11, 0.11, 0.11 },
                                {0.11, 0.11, 0.11 },
                                {0.11, 0.11, 0.11 }}; //���� ����ũ

            //�ӽ� ����� �޸� Ȯ��
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //�ӽ� �Է��� �ʱ�ȭ(0, 127, ��հ�)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //�Է� --> �ӽ� �Է�
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //ȸ�� ����
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //������ ���� ����ũ ����
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////����ũ�� �հ谡 0�̸�, 127 ���� �����ֱ�.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //�ӽ� ��� -> ���
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

        void sharpening()  // ������ �˰���
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            const int MSIZE = 3;
            //double[,] mask = { { 0, -1, 0 },
            //                    {-1, 5, -1 },
            //                    {0, -1, 0 }}; //������ ����ũ

            double[,] mask = { { -1, -1, -1 },
                                {-1, 9, -1 },
                                {-1, -1, -1 }}; //������ ����ũ

            //�ӽ� ����� �޸� Ȯ��
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //�ӽ� �Է��� �ʱ�ȭ(0, 127, ��հ�)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //�Է� --> �ӽ� �Է�
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //ȸ�� ����
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //������ ���� ����ũ ����
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////����ũ�� �հ谡 0�̸�, 127 ���� �����ֱ�.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //�ӽ� ��� -> ���
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

        void hpfSharp()  // ������ ���� ������ �˰���
        {
            if (inImage == null)
            {
                return;
            }
            // �߿�! ��� ������ ũ�⸦ ���� --> �˰��� ����....
            outH = inH;
            outW = inW;
            // ��� ���� �޸� �Ҵ�.
            outImage = new byte[outH, outW];

            // ** ����ó�� �˰��� **
            const int MSIZE = 3;
            //double[,] mask = { { 0, -1, 0 },
            //                    {-1, 5, -1 },
            //                    {0, -1, 0 }}; //������ ���� ������ ����ũ

            double[,] mask = {{-0.11, -0.11, -0.11},
                               {-0.11, 0.9, -0.11},
                               {-0.11, -0.11, -0.11}}; //������ ����ũ

            //�ӽ� ����� �޸� Ȯ��
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];

            //�ӽ� �Է��� �ʱ�ȭ(0, 127, ��հ�)
            for (int i = 0; i < inH + 2; i++)
                for (int k = 0; k < inW + 2; k++)
                    tmpInput[i, k] = 127.0;

            //�Է� --> �ӽ� �Է�
            for (int i = 0; i < inH; i++)
                for (int k = 0; k < inW; k++)
                    tmpInput[i + 1, k + 1] = inImage[i, k];

            //ȸ�� ����
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    //������ ���� ����ũ ����
                    double S = 0.0;
                    for (int m = 0; m < MSIZE; m++)
                        for (int n = 0; n < MSIZE; n++)
                        {
                            S += mask[m, n] * tmpInput[m + i, n + k];
                        }
                    tmpOutput[i, k] = S;
                }
            }

            ////����ũ�� �հ谡 0�̸�, 127 ���� �����ֱ�.
            //for (int i = 0; i < outH; i++)
            //{
            //    for (int k = 0; k < outW; k++)
            //    {
            //        tmpOutput[i, k] += 127;
            //    }
            //}
            //�ӽ� ��� -> ���
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

        void vert_hori_edge() // ���� ���� ���� ����
        {
            if (inImage == null)
                return;
            //�߿�! ��¿����� ũ�⸦ ���� --> �˰��� ���� ....
            outH = inH;
            outW = inW;
            //��¿��� �޸� �Ҵ�
            outImage = new byte[outH, outW];
            //  ** ����ó�� �˰��� **

            const int MSIZE = 3;
            double[,] mask;

            mask = new double[,]{ {0,0,0},
                               {-1,1,0},
                               {0,0,0} };//�����������⸶��ũ1

            //mask = new double[,]{ {0,-1,0},
            //                   {0,1,0},
            //                   {0,0,0} };//���������⸶��ũ2

            //����� �޸�Ȯ��
            double[,] tmpInput = new double[inH + 2, inW + 2];
            double[,] tmpOutput = new double[outH, outW];
            //�ӽ� �Է��� �ʱ�ȭ
            for (int i = 0; i < inH + 2; i++)
            {
                for (int k = 0; k < inW + 2; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //�Է�-->�ӽ��Է�
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 1, k + 1] = inImage[i, k];
                }
            }
            //ȸ������
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

            //����ũ�� �հ迡 ���� 127������ �����ֱ�
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }

            //�ӽ���� --> ���
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
            //�߿�! ��¿����� ũ�⸦ ���� --> �˰��� ���� ....
            outH = inH;
            outW = inW;
            //��¿��� �޸� �Ҵ�
            outImage = new byte[outH, outW];
            //  ** ����ó�� �˰��� **
            const int MSIZE = 5;
            double[,] mask = { { 0.0, 0.0, -1, 0.0, 0.0 },
                        { 0.0, -1, -2, -1, 0.0 },
                        { -1, -2, 16, -2, -1 },
                        { 0.0, -1, -2, -1, 0.0 },
                        { 0.0, 0.0, -1, 0.0, 0.0 } };
            //����� �޸�Ȯ��
            double[,] tmpInput = new double[inH + 4, inW + 4];
            double[,] tmpOutput = new double[outH, outW];
            //�ӽ� �Է��� �ʱ�ȭ
            for (int i = 0; i < inH + 4; i++)
            {
                for (int k = 0; k < inW + 4; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //�Է�-->�ӽ��Է�
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 2, k + 2] = inImage[i, k];
                }
            }
            //ȸ������
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
            //����ũ�� �հ迡 ���� 127������ �����ֱ�
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //�ӽ���� --> ���
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
            //�߿�! ��¿����� ũ�⸦ ���� --> �˰��� ���� ....
            outH = inH;
            outW = inW;
            //��¿��� �޸� �Ҵ�
            outImage = new byte[outH, outW];
            //  ** ����ó�� �˰��� **
            const int MSIZE = 7;
            double[,] mask = { { 0.0, 0.0, -1.0, -1.0, -1.0, 0.0, 0.0 },
                        { 0.0, -2.0, -3.0, -3.0, -3.0, -2.0, 0.0 },
                        { -1.0, -3.0, 5.0, 5.0, 5.0, -3.0, -1.0 },
                        { -1.0, -3.0, 5.0, 16.0, 5.0, -3.0, -1.0 },
                        { -1.0, -3.0, 5.0, 5.0, 5.0, -3.0, -1.0 },
                        { 0.0, -2.0, -3.0, -3.0, -3.0, -2.0, 0.0 },
                        { 0.0, 0.0, -1.0, -1.0, -1.0, 0.0, 0.0 } };
            //����� �޸�Ȯ��
            double[,] tmpInput = new double[inH + 6, inW + 6];
            double[,] tmpOutput = new double[outH, outW];
            //�ӽ� �Է��� �ʱ�ȭ
            for (int i = 0; i < inH + 6; i++)
            {
                for (int k = 0; k < inW + 6; k++)
                {
                    tmpInput[i, k] = 127.0;
                }
            }
            //�Է�-->�ӽ��Է�
            for (int i = 0; i < inH; i++)
            {
                for (int k = 0; k < inW; k++)
                {
                    tmpInput[i + 3, k + 3] = inImage[i, k];
                }
            }
            //ȸ������
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
            //����ũ�� �հ迡 ���� 127������ �����ֱ�
            for (int i = 0; i < outH; i++)
            {
                for (int k = 0; k < outW; k++)
                {
                    tmpOutput[i, k] += 127;
                }
            }
            //�ӽ���� --> ���
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