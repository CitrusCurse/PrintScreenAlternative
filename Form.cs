using System;
using System.Collections.Generic; 
using System.ComponentModel; 
using System.Data; 
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq; 
using System.Text;
using System.Threading; 
using System.Threading.Tasks; 
using System.Windows.Forms; 


namespace PrintScreenAlternative
{
    public partial class Screenshot : Form
    {
        #region Notification Icon
        Icon logoIcon; 
        NotifyIcon theIcon;
        #endregion

        public Screenshot()
        {
            InitializeComponent();

            #region Icon
            logoIcon = new Icon("prntscrnicn.ico"); 
            theIcon = new NotifyIcon(); 
            theIcon.Icon = logoIcon; 
            theIcon.Visible = true;
            #endregion

            #region Context Menu & Hiding Form
            ContextMenu contextMenu = new ContextMenu();
            theIcon.ContextMenu = contextMenu;
            theIcon.MouseClick += theIcon_MouseClick;

            this.WindowState = FormWindowState.Minimized;           
            this.ShowInTaskbar = false;
            #endregion

            #region Popup Dialog Box
            //Goal: Configure this to only appear the first time the user uses the application until shut down
            MessageBox.Show(
                "Welcome to PrintScreen Alternative!\nLeft click the icon in the task tray to copy to the clipboard.\nRight click the icon to copy to clipboard and to save the image.", 
                "PrintScreen Alternative: Coded by Kristina Powell", 
                MessageBoxButtons.OK, MessageBoxIcon.None);
            #endregion
        }

        #region Hidden: exitMenuItem_Click Archived Values
        /*void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }*/
        #endregion

        void theIcon_MouseClick(object sender, MouseEventArgs e)
        {
            #region Variable Declaration & Get Initial Clipboard Image
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*.jpg";
            ImageFormat format = ImageFormat.Png;
            Bitmap img;
            SendKeys.Send("{PRTSC}");
            img = (Bitmap)Clipboard.GetImage();
            Thread.Sleep(500);
            #endregion

            #region Right Click: Print Screen & Save File
            if (e.Button == MouseButtons.Right)
            {
                SendKeys.Send("{PRTSC}");
                Thread.Sleep(500);
                img = (Bitmap)Clipboard.GetImage();

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(sfd.FileName);
                    switch (ext)
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                    }

                    img.Save(sfd.FileName, format);
                }

                theIcon.Dispose();
                this.Close();
                Application.Exit();
            }
            #endregion

            #region Left Click: Print Screen
            if (e.Button == MouseButtons.Left)
            {
                Thread.Sleep(50);
                SendKeys.Send("{PRTSC}");
                theIcon.Dispose();
                this.Close();
                Application.Exit();
            }

            #endregion

        }
    }
}
