namespace Day10_02_GrayScale_image_processing__Beta_1_
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.파일ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.화소점처리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.동일영상ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.반전영상ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.밝게어둡게ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파라볼라ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.감마ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.geometryProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이동ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.확대ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.축소ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전정방향ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전중앙역방향ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전화면크기유지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.회전사진크기유지ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.흑백평균값ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.스트레칭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.앤드인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.평활화ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaProcessingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.엠보싱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.블러핑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.샤프닝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.고주파필터샤프닝ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.수평수직엣지검출ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_outImage = new System.Windows.Forms.PictureBox();
            this.pb_inImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_outImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_inImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일ToolStripMenuItem,
            this.화소점처리ToolStripMenuItem,
            this.geometryProcessingToolStripMenuItem,
            this.areaProcessingToolStripMenuItem,
            this.areaProcessingToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1205, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            this.파일ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.저장ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            this.파일ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.파일ToolStripMenuItem.Text = "파일";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.열기ToolStripMenuItem.Text = "열기";
            this.열기ToolStripMenuItem.Click += new System.EventHandler(this.열기ToolStripMenuItem_Click);
            // 
            // 저장ToolStripMenuItem
            // 
            this.저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            this.저장ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.저장ToolStripMenuItem.Text = "저장";
            this.저장ToolStripMenuItem.Click += new System.EventHandler(this.저장ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(122, 26);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 화소점처리ToolStripMenuItem
            // 
            this.화소점처리ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.동일영상ToolStripMenuItem,
            this.반전영상ToolStripMenuItem,
            this.밝게어둡게ToolStripMenuItem,
            this.흑백ToolStripMenuItem,
            this.파라볼라ToolStripMenuItem,
            this.감마ToolStripMenuItem});
            this.화소점처리ToolStripMenuItem.Name = "화소점처리ToolStripMenuItem";
            this.화소점처리ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.화소점처리ToolStripMenuItem.Text = "화소점 처리";
            // 
            // 동일영상ToolStripMenuItem
            // 
            this.동일영상ToolStripMenuItem.Name = "동일영상ToolStripMenuItem";
            this.동일영상ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.동일영상ToolStripMenuItem.Text = "동일 영상";
            this.동일영상ToolStripMenuItem.Click += new System.EventHandler(this.동일영상ToolStripMenuItem_Click);
            // 
            // 반전영상ToolStripMenuItem
            // 
            this.반전영상ToolStripMenuItem.Name = "반전영상ToolStripMenuItem";
            this.반전영상ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.반전영상ToolStripMenuItem.Text = "반전 영상";
            this.반전영상ToolStripMenuItem.Click += new System.EventHandler(this.반전영상ToolStripMenuItem_Click);
            // 
            // 밝게어둡게ToolStripMenuItem
            // 
            this.밝게어둡게ToolStripMenuItem.Name = "밝게어둡게ToolStripMenuItem";
            this.밝게어둡게ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.밝게어둡게ToolStripMenuItem.Text = "밝게/어둡게";
            this.밝게어둡게ToolStripMenuItem.Click += new System.EventHandler(this.밝게어둡게ToolStripMenuItem_Click);
            // 
            // 흑백ToolStripMenuItem
            // 
            this.흑백ToolStripMenuItem.Name = "흑백ToolStripMenuItem";
            this.흑백ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.흑백ToolStripMenuItem.Text = "흑백(127기준)";
            this.흑백ToolStripMenuItem.Click += new System.EventHandler(this.흑백ToolStripMenuItem_Click);
            // 
            // 파라볼라ToolStripMenuItem
            // 
            this.파라볼라ToolStripMenuItem.Name = "파라볼라ToolStripMenuItem";
            this.파라볼라ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.파라볼라ToolStripMenuItem.Text = "파라볼라";
            this.파라볼라ToolStripMenuItem.Click += new System.EventHandler(this.파라볼라ToolStripMenuItem_Click);
            // 
            // 감마ToolStripMenuItem
            // 
            this.감마ToolStripMenuItem.Name = "감마ToolStripMenuItem";
            this.감마ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.감마ToolStripMenuItem.Text = "감마";
            this.감마ToolStripMenuItem.Click += new System.EventHandler(this.감마ToolStripMenuItem_Click);
            // 
            // geometryProcessingToolStripMenuItem
            // 
            this.geometryProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.회전ToolStripMenuItem,
            this.이동ToolStripMenuItem,
            this.확대ToolStripMenuItem,
            this.축소ToolStripMenuItem,
            this.회전정방향ToolStripMenuItem,
            this.회전중앙역방향ToolStripMenuItem,
            this.회전화면크기유지ToolStripMenuItem,
            this.회전사진크기유지ToolStripMenuItem});
            this.geometryProcessingToolStripMenuItem.Name = "geometryProcessingToolStripMenuItem";
            this.geometryProcessingToolStripMenuItem.Size = new System.Drawing.Size(166, 24);
            this.geometryProcessingToolStripMenuItem.Text = "Geometry processing";
            // 
            // 회전ToolStripMenuItem
            // 
            this.회전ToolStripMenuItem.Name = "회전ToolStripMenuItem";
            this.회전ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.회전ToolStripMenuItem.Text = "90도_회전";
            this.회전ToolStripMenuItem.Click += new System.EventHandler(this.회전ToolStripMenuItem_Click);
            // 
            // 이동ToolStripMenuItem
            // 
            this.이동ToolStripMenuItem.Name = "이동ToolStripMenuItem";
            this.이동ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.이동ToolStripMenuItem.Text = "이동";
            this.이동ToolStripMenuItem.Click += new System.EventHandler(this.이동ToolStripMenuItem_Click);
            // 
            // 확대ToolStripMenuItem
            // 
            this.확대ToolStripMenuItem.Name = "확대ToolStripMenuItem";
            this.확대ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.확대ToolStripMenuItem.Text = "확대";
            this.확대ToolStripMenuItem.Click += new System.EventHandler(this.확대ToolStripMenuItem_Click);
            // 
            // 축소ToolStripMenuItem
            // 
            this.축소ToolStripMenuItem.Name = "축소ToolStripMenuItem";
            this.축소ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.축소ToolStripMenuItem.Text = "축소";
            this.축소ToolStripMenuItem.Click += new System.EventHandler(this.축소ToolStripMenuItem_Click);
            // 
            // 회전정방향ToolStripMenuItem
            // 
            this.회전정방향ToolStripMenuItem.Name = "회전정방향ToolStripMenuItem";
            this.회전정방향ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.회전정방향ToolStripMenuItem.Text = "회전(정방향)";
            this.회전정방향ToolStripMenuItem.Click += new System.EventHandler(this.회전정방향ToolStripMenuItem_Click);
            // 
            // 회전중앙역방향ToolStripMenuItem
            // 
            this.회전중앙역방향ToolStripMenuItem.Name = "회전중앙역방향ToolStripMenuItem";
            this.회전중앙역방향ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.회전중앙역방향ToolStripMenuItem.Text = "회전(중앙_역방향)";
            this.회전중앙역방향ToolStripMenuItem.Click += new System.EventHandler(this.회전중앙역방향ToolStripMenuItem_Click);
            // 
            // 회전화면크기유지ToolStripMenuItem
            // 
            this.회전화면크기유지ToolStripMenuItem.Name = "회전화면크기유지ToolStripMenuItem";
            this.회전화면크기유지ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.회전화면크기유지ToolStripMenuItem.Text = "회전(화면크기유지)";
            this.회전화면크기유지ToolStripMenuItem.Click += new System.EventHandler(this.회전화면크기유지ToolStripMenuItem_Click);
            // 
            // 회전사진크기유지ToolStripMenuItem
            // 
            this.회전사진크기유지ToolStripMenuItem.Name = "회전사진크기유지ToolStripMenuItem";
            this.회전사진크기유지ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.회전사진크기유지ToolStripMenuItem.Text = "회전(사진크기유지)";
            this.회전사진크기유지ToolStripMenuItem.Click += new System.EventHandler(this.회전사진크기유지ToolStripMenuItem_Click);
            // 
            // areaProcessingToolStripMenuItem
            // 
            this.areaProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.흑백평균값ToolStripMenuItem,
            this.스트레칭ToolStripMenuItem,
            this.앤드인ToolStripMenuItem,
            this.평활화ToolStripMenuItem});
            this.areaProcessingToolStripMenuItem.Name = "areaProcessingToolStripMenuItem";
            this.areaProcessingToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this.areaProcessingToolStripMenuItem.Text = "histogram";
            // 
            // 흑백평균값ToolStripMenuItem
            // 
            this.흑백평균값ToolStripMenuItem.Name = "흑백평균값ToolStripMenuItem";
            this.흑백평균값ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.흑백평균값ToolStripMenuItem.Text = "흑백_average";
            this.흑백평균값ToolStripMenuItem.Click += new System.EventHandler(this.흑백평균값ToolStripMenuItem_Click);
            // 
            // 스트레칭ToolStripMenuItem
            // 
            this.스트레칭ToolStripMenuItem.Name = "스트레칭ToolStripMenuItem";
            this.스트레칭ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.스트레칭ToolStripMenuItem.Text = "스트레칭";
            this.스트레칭ToolStripMenuItem.Click += new System.EventHandler(this.스트레칭ToolStripMenuItem_Click);
            // 
            // 앤드인ToolStripMenuItem
            // 
            this.앤드인ToolStripMenuItem.Name = "앤드인ToolStripMenuItem";
            this.앤드인ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.앤드인ToolStripMenuItem.Text = "앤드_인";
            this.앤드인ToolStripMenuItem.Click += new System.EventHandler(this.앤드인ToolStripMenuItem_Click);
            // 
            // 평활화ToolStripMenuItem
            // 
            this.평활화ToolStripMenuItem.Name = "평활화ToolStripMenuItem";
            this.평활화ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.평활화ToolStripMenuItem.Text = "평활화";
            this.평활화ToolStripMenuItem.Click += new System.EventHandler(this.평활화ToolStripMenuItem_Click);
            // 
            // areaProcessingToolStripMenuItem1
            // 
            this.areaProcessingToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.엠보싱ToolStripMenuItem,
            this.블러핑ToolStripMenuItem,
            this.샤프닝ToolStripMenuItem,
            this.고주파필터샤프닝ToolStripMenuItem,
            this.수평수직엣지검출ToolStripMenuItem,
            this.loGToolStripMenuItem,
            this.doGToolStripMenuItem});
            this.areaProcessingToolStripMenuItem1.Name = "areaProcessingToolStripMenuItem1";
            this.areaProcessingToolStripMenuItem1.Size = new System.Drawing.Size(131, 24);
            this.areaProcessingToolStripMenuItem1.Text = "Area processing";
            // 
            // 엠보싱ToolStripMenuItem
            // 
            this.엠보싱ToolStripMenuItem.Name = "엠보싱ToolStripMenuItem";
            this.엠보싱ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.엠보싱ToolStripMenuItem.Text = "엠보싱";
            this.엠보싱ToolStripMenuItem.Click += new System.EventHandler(this.엠보싱ToolStripMenuItem_Click);
            // 
            // 블러핑ToolStripMenuItem
            // 
            this.블러핑ToolStripMenuItem.Name = "블러핑ToolStripMenuItem";
            this.블러핑ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.블러핑ToolStripMenuItem.Text = "블러핑";
            this.블러핑ToolStripMenuItem.Click += new System.EventHandler(this.블러핑ToolStripMenuItem_Click);
            // 
            // 샤프닝ToolStripMenuItem
            // 
            this.샤프닝ToolStripMenuItem.Name = "샤프닝ToolStripMenuItem";
            this.샤프닝ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.샤프닝ToolStripMenuItem.Text = "샤프닝";
            this.샤프닝ToolStripMenuItem.Click += new System.EventHandler(this.샤프닝ToolStripMenuItem_Click);
            // 
            // 고주파필터샤프닝ToolStripMenuItem
            // 
            this.고주파필터샤프닝ToolStripMenuItem.Name = "고주파필터샤프닝ToolStripMenuItem";
            this.고주파필터샤프닝ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.고주파필터샤프닝ToolStripMenuItem.Text = "고주파 필터 샤프닝";
            this.고주파필터샤프닝ToolStripMenuItem.Click += new System.EventHandler(this.고주파필터샤프닝ToolStripMenuItem_Click);
            // 
            // 수평수직엣지검출ToolStripMenuItem
            // 
            this.수평수직엣지검출ToolStripMenuItem.Name = "수평수직엣지검출ToolStripMenuItem";
            this.수평수직엣지검출ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.수평수직엣지검출ToolStripMenuItem.Text = "수평수직 엣지 검출";
            this.수평수직엣지검출ToolStripMenuItem.Click += new System.EventHandler(this.수평수직엣지검출ToolStripMenuItem_Click);
            // 
            // loGToolStripMenuItem
            // 
            this.loGToolStripMenuItem.Name = "loGToolStripMenuItem";
            this.loGToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.loGToolStripMenuItem.Text = "LoG";
            this.loGToolStripMenuItem.Click += new System.EventHandler(this.loGToolStripMenuItem_Click);
            // 
            // doGToolStripMenuItem
            // 
            this.doGToolStripMenuItem.Name = "doGToolStripMenuItem";
            this.doGToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.doGToolStripMenuItem.Text = "DoG";
            this.doGToolStripMenuItem.Click += new System.EventHandler(this.doGToolStripMenuItem_Click);
            // 
            // pb_outImage
            // 
            this.pb_outImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pb_outImage.Location = new System.Drawing.Point(649, 60);
            this.pb_outImage.Name = "pb_outImage";
            this.pb_outImage.Size = new System.Drawing.Size(512, 512);
            this.pb_outImage.TabIndex = 1;
            this.pb_outImage.TabStop = false;
            // 
            // pb_inImage
            // 
            this.pb_inImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pb_inImage.Location = new System.Drawing.Point(34, 60);
            this.pb_inImage.Name = "pb_inImage";
            this.pb_inImage.Size = new System.Drawing.Size(512, 512);
            this.pb_inImage.TabIndex = 2;
            this.pb_inImage.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 579);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1205, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(152, 20);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1205, 605);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pb_inImage);
            this.Controls.Add(this.pb_outImage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "그레이 영상처리 Ver 1.0 (Patch 1)";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_outImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_inImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 파일ToolStripMenuItem;
        private ToolStripMenuItem 열기ToolStripMenuItem;
        private ToolStripMenuItem 화소점처리ToolStripMenuItem;
        private ToolStripMenuItem geometryProcessingToolStripMenuItem;
        private ToolStripMenuItem areaProcessingToolStripMenuItem;
        private PictureBox pb_outImage;
        private ToolStripMenuItem areaProcessingToolStripMenuItem1;
        private ToolStripMenuItem 동일영상ToolStripMenuItem;
        private ToolStripMenuItem 반전영상ToolStripMenuItem;
        private ToolStripMenuItem 밝게어둡게ToolStripMenuItem;
        private ToolStripMenuItem 저장ToolStripMenuItem;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private ToolStripMenuItem 흑백ToolStripMenuItem;
        private ToolStripMenuItem 회전ToolStripMenuItem;
        private ToolStripMenuItem 이동ToolStripMenuItem;
        private ToolStripMenuItem 확대ToolStripMenuItem;
        private ToolStripMenuItem 축소ToolStripMenuItem;
        private ToolStripMenuItem 흑백평균값ToolStripMenuItem;
        private ToolStripMenuItem 파라볼라ToolStripMenuItem;
        private ToolStripMenuItem 스트레칭ToolStripMenuItem;
        private ToolStripMenuItem 앤드인ToolStripMenuItem;
        private ToolStripMenuItem 평활화ToolStripMenuItem;
        private PictureBox pb_inImage;
        private ToolStripMenuItem 회전정방향ToolStripMenuItem;
        private ToolStripMenuItem 회전중앙역방향ToolStripMenuItem;
        private ToolStripMenuItem 엠보싱ToolStripMenuItem;
        private ToolStripMenuItem 블러핑ToolStripMenuItem;
        private ToolStripMenuItem 샤프닝ToolStripMenuItem;
        private ToolStripMenuItem 고주파필터샤프닝ToolStripMenuItem;
        private ToolStripMenuItem 회전화면크기유지ToolStripMenuItem;
        private ToolStripMenuItem 회전사진크기유지ToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private ToolStripStatusLabel toolStripStatusLabel3;
        private ToolStripMenuItem 감마ToolStripMenuItem;
        private ToolStripMenuItem 수평수직엣지검출ToolStripMenuItem;
        private ToolStripMenuItem loGToolStripMenuItem;
        private ToolStripMenuItem doGToolStripMenuItem;
    }
}