﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharpBoot.Properties;

namespace SharpBoot
{
    public partial class About : Form
    {
        public static List<Image> Flags => new About().ilTranslators.Images.Cast<Image>().ToList();


        public About()
        {
            InitializeComponent();
            richTextBox1.Text = richTextBox1.Text.Insert(9, " " + Program.GetVersion())
                .Replace("{0}", ISOInfo.AppDBVersion.ToString())
                .Replace("{1}", Strings.SharpBootUsesSoft);
            if (Program.IsWin) Utils.SetWindowTheme(lvTranslators.Handle, "explorer", null);
            rtbMyWebsite.SelectAll();
            rtbMyWebsite.SelectionAlignment = HorizontalAlignment.Right;
            rtbMyWebsite.DeselectAll();
            Text = Strings.AboutSharpBoot;
            btnOK.Text = Strings.OK;
        }

        private void lvTranslators_DoubleClick(object sender, EventArgs e)
        {
            if (lvTranslators.SelectedItems.Count == 1)
            {
                var it = lvTranslators.SelectedItems[0];
                var url = "";
                if (it.SubItems.Count > 1) url = it.SubItems[1].Text;
                if (!string.IsNullOrEmpty(url)) Process.Start(url);
                lvTranslators.SelectedIndices.Clear();
            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText != "")
                Process.Start(e.LinkText);
        }
    }
}