// ToEE World Builder .NET2 version 2.0.0 Open-Source Edition
// Copyright (C) 2005-2006    Michael Kamensky, all rights reserved.
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ToEE_World_Builder
{
    public partial class PathNodeAutoGen : Form
    {
        public PathNodeAutoGen()
        {
            InitializeComponent();
        }

        public int r_FX = -1;
        public int r_FY = -1;
        public int r_TX = -1;
        public int r_TY = -1;
        public int r_Step = -1;

        private void btnOK_Click(object sender, EventArgs e)
        {
            r_FX = int.Parse(FX.Text);
            r_FY = int.Parse(FY.Text);
            r_TX = int.Parse(TX.Text);
            r_TY = int.Parse(TY.Text);

            if ((r_TX < r_FX) || (r_TY < r_FY))
            {
                MessageBox.Show("An invalid coordinate box was specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            r_Step = int.Parse(txtStepping.Text);
        }
    }
}