﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceDesktop.Presenter.Views;

namespace ServiceDesktop.Views.AboutSoftwareView
{
    public partial class AboutSoftware : Form, IAboutSoftwareView
    {
        public AboutSoftware()
        {
            InitializeComponent();
        }

        public new void Show()
        {
            ShowDialog();
        }
    }
}