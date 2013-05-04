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
    public partial class CreatePartsysHID : Form
    {
        public CreatePartsysHID()
        {
            InitializeComponent();
        }

        public string HID = "";

        private void btnCreate_Click(object sender, EventArgs e)
        {
            HID = Helper.HashID_Generate(PartsysName.Text).ToString();
        }
    }
}