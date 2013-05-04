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
using System.Collections;
using System.IO;

namespace ToEE_World_Builder
{
    public partial class ListInvenSource : Form
    {
        public ArrayList ITEMS = new ArrayList();

        public ListInvenSource()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            // process ITEMS here
            // format: ITEM_PROTO_ID,MONEY_AMOUNT
            if (lstInvSrc.SelectedIndex == -1)
                return;

            string inven = lstInvSrc.Items[lstInvSrc.SelectedIndex].ToString().Split('{','}')[3].Split(':')[1].Trim();
            string[] i_Items = inven.Split(' ');

            foreach (string item in i_Items)
            {
                string item0 = item.Replace(" ", "");
                string PROTO_ID = "";
                string AMOUNT = "-1";

                if (item0.IndexOf('(') == -1)
                {
                    // not a set
                    string param1 = item0.Split(',')[0];
                    string param2 = item0.Split(',')[1];

                    if (param1 == "buy_list_num")
                        continue;
                    else if (param1 == "jewelry")
                        continue;
                    else if (param1 == "gems")
                        continue;
                    else if (param1 == "platinum")
                    {
                        PROTO_ID = "7003";

                        if (param2.IndexOf("-") == -1)
                            AMOUNT = param2;
                        else
                        {
                            // Random amount
                            int low = int.Parse(param2.Split('-')[0]);
                            int high = int.Parse(param2.Split('-')[1]);
                            AMOUNT = r.Next(low, high + 1).ToString();
                        }
                    }
                    else if (param1 == "gold")
                    {
                        PROTO_ID = "7002";

                        if (param2.IndexOf("-") == -1)
                            AMOUNT = param2;
                        else
                        {
                            // Random amount
                            int low = int.Parse(param2.Split('-')[0]);
                            int high = int.Parse(param2.Split('-')[1]);
                            AMOUNT = r.Next(low, high + 1).ToString();
                        }
                    }
                    else if (param1 == "silver")
                    {
                        PROTO_ID = "7001";

                        if (param2.IndexOf("-") == -1)
                            AMOUNT = param2;
                        else
                        {
                            // Random amount
                            int low = int.Parse(param2.Split('-')[0]);
                            int high = int.Parse(param2.Split('-')[1]);
                            AMOUNT = r.Next(low, high + 1).ToString();
                        }
                    }
                    else if (param1 == "copper")
                    {
                        PROTO_ID = "7000";

                        if (param2.IndexOf("-") == -1)
                            AMOUNT = param2;
                        else
                        {
                            // Random amount
                            int low = int.Parse(param2.Split('-')[0]);
                            int high = int.Parse(param2.Split('-')[1]);
                            AMOUNT = r.Next(low, high + 1).ToString();
                        }
                    }
                    else
                    {
                        // standard item, param1 = chance
                        int ChanceValue = r.Next(0, 100);

                        if (ChanceValue < int.Parse(param1))
                            PROTO_ID = param2;
                        else
                            continue;
                    }
                }
                else
                {
                    string set = item0.Split('(', ')')[1].Trim();
                    string[] i_set = set.Split(',');
                    int i_item_to_choose = r.Next(0, i_set.GetUpperBound(0)+1);
                    PROTO_ID = i_set[i_item_to_choose];
                }
                ITEMS.Add(PROTO_ID + "," + AMOUNT);
            }
        }

        private void ListInvenSource_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Path.GetDirectoryName(Application.ExecutablePath) + "\\InvenSource.mes");
            string str = "";

            while ((str = sr.ReadLine()) != null)
            {
                if (str.Trim().Length > 1)
                    if ((str[0] == '{') && (str[str.Length-1] == '}'))
                        lstInvSrc.Items.Add(str);
            }

            sr.Close();
        }
    }
}