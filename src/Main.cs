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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading;

namespace ToEE_World_Builder
{
	public class Worlded : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Prototype;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label MobileName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox MobType;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnSaveMob;
		private System.Windows.Forms.Button btnOpenMob;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button recomb_partial;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox SY;
		private System.Windows.Forms.TextBox SX;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.OpenFileDialog OFG1;
		private System.Windows.Forms.TextBox PY;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox PX;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.OpenFileDialog OFG;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label splitData;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label fdata;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.CheckBox pRotation;
		private System.Windows.Forms.TextBox vRotation;
		private System.Windows.Forms.Button btnChgGUID;
		private System.Windows.Forms.TabControl tabProps;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.CheckBox pLockDC;
		private System.Windows.Forms.TextBox vLockDC;
		private System.Windows.Forms.CheckBox pInvSlot;
		private System.Windows.Forms.TextBox vInvSlot;
		private System.Windows.Forms.CheckBox pParent;
		private System.Windows.Forms.Button vParent;
		private System.Windows.Forms.Label tParent;
		private System.Windows.Forms.CheckBox pObjFlags;
		private System.Windows.Forms.CheckBox pObjFlag00;
		private System.Windows.Forms.CheckBox pObjFlag01;
		private System.Windows.Forms.CheckBox pObjFlag02;
		private System.Windows.Forms.CheckBox pObjFlag03;
		private System.Windows.Forms.CheckBox pObjFlag04;
		private System.Windows.Forms.CheckBox pObjFlag05;
		private System.Windows.Forms.CheckBox pObjFlag06;
		private System.Windows.Forms.CheckBox pObjFlag07;
		private System.Windows.Forms.CheckBox pObjFlag08;
		private System.Windows.Forms.CheckBox pObjFlag09;
		private System.Windows.Forms.CheckBox pObjFlag10;
		private System.Windows.Forms.CheckBox pObjFlag11;
		private System.Windows.Forms.CheckBox pObjFlag12;
		private System.Windows.Forms.CheckBox pObjFlag13;
		private System.Windows.Forms.CheckBox pObjFlag14;
		private System.Windows.Forms.CheckBox pObjFlag15;
		private System.Windows.Forms.CheckBox pObjFlag16;
		private System.Windows.Forms.CheckBox pObjFlag17;
		private System.Windows.Forms.CheckBox pObjFlag18;
		private System.Windows.Forms.CheckBox pObjFlag19;
		private System.Windows.Forms.CheckBox pObjFlag20;
		private System.Windows.Forms.CheckBox pObjFlag21;
		private System.Windows.Forms.CheckBox pObjFlag22;
		private System.Windows.Forms.CheckBox pObjFlag23;
		private System.Windows.Forms.CheckBox pObjFlag24;
		private System.Windows.Forms.CheckBox pObjFlag25;
		private System.Windows.Forms.CheckBox pObjFlag26;
		private System.Windows.Forms.CheckBox pObjFlag27;
		private System.Windows.Forms.CheckBox pObjFlag28;
		private System.Windows.Forms.CheckBox pObjFlag29;
		private System.Windows.Forms.CheckBox pObjFlag30;
		private System.Windows.Forms.CheckBox pObjFlag31;
		private System.Windows.Forms.CheckBox pInvenSource;
		private System.Windows.Forms.TextBox vInvenSource;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.CheckBox pChestInv;
		private System.Windows.Forms.ListBox vChestInv;
		private System.Windows.Forms.Button btnAddChestInv;
		private System.Windows.Forms.Button btnRemoveChestInv;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button btnAddChestInv2;
		private System.Windows.Forms.ComboBox ChestInvProtos;
		private System.Windows.Forms.CheckBox pItmFlag00;
		private System.Windows.Forms.CheckBox pItmFlag01;
		private System.Windows.Forms.CheckBox pItmFlag02;
		private System.Windows.Forms.CheckBox pItmFlag03;
		private System.Windows.Forms.CheckBox pItmFlag04;
		private System.Windows.Forms.CheckBox pItmFlag05;
		private System.Windows.Forms.CheckBox pItmFlag06;
		private System.Windows.Forms.CheckBox pItmFlag07;
		private System.Windows.Forms.CheckBox pItmFlag08;
		private System.Windows.Forms.CheckBox pItmFlag09;
		private System.Windows.Forms.CheckBox pItmFlag10;
		private System.Windows.Forms.CheckBox pItmFlag11;
		private System.Windows.Forms.CheckBox pItmFlag12;
		private System.Windows.Forms.CheckBox pItmFlag13;
		private System.Windows.Forms.CheckBox pItmFlag14;
		private System.Windows.Forms.CheckBox pItmFlag15;
		private System.Windows.Forms.CheckBox pItmFlag16;
		private System.Windows.Forms.CheckBox pItmFlag17;
		private System.Windows.Forms.CheckBox pItmFlag18;
		private System.Windows.Forms.CheckBox pItmFlag19;
		private System.Windows.Forms.CheckBox pItmFlag20;
		private System.Windows.Forms.CheckBox pItmFlag21;
		private System.Windows.Forms.CheckBox pItmFlag22;
		private System.Windows.Forms.CheckBox pItmFlag23;
		private System.Windows.Forms.CheckBox pItmFlag24;
		private System.Windows.Forms.CheckBox pItmFlag25;
		private System.Windows.Forms.CheckBox pItmFlag26;
		private System.Windows.Forms.CheckBox pChestInvDel;
		private System.Windows.Forms.Button btnChestInvGUID;
		private System.Windows.Forms.CheckBox pOffsetX;
		private System.Windows.Forms.CheckBox pOffsetY;
		private System.Windows.Forms.TextBox vOffsetX;
		private System.Windows.Forms.TextBox vOffsetY;
		private System.Windows.Forms.CheckBox pRadius;
		private System.Windows.Forms.TextBox vRadius;
		private System.Windows.Forms.CheckBox pHeight;
		private System.Windows.Forms.TextBox vHeight;
		private System.Windows.Forms.CheckBox pMoneyQuantity;
		private System.Windows.Forms.TextBox vMoneyQuantity;
		private System.Windows.Forms.CheckBox pTeleport;
		private System.Windows.Forms.Button btnEmbed;
		private System.Windows.Forms.TextBox vTeleport;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tChestMoneyAmt;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Button btnNpcInvGUID;
		private System.Windows.Forms.CheckBox pNpcInvDel;
		private System.Windows.Forms.Button btnAddNpcInv2;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Button btnRemoveNpcInv;
		private System.Windows.Forms.Button btnAddNpcInv;
		private System.Windows.Forms.ListBox vNpcInv;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.ComboBox NpcInvProtos;
		private System.Windows.Forms.CheckBox pNpcInv;
		private System.Windows.Forms.TextBox tNpcMoneyAmt;
		private System.Windows.Forms.CheckBox pNpcInvenSource;
		private System.Windows.Forms.TextBox vNpcInvenSource;
		private System.Windows.Forms.Timer tmrSplash;
		private System.Windows.Forms.CheckBox pSubInv;
		private System.Windows.Forms.Button vSubInv;
		private System.Windows.Forms.Label tSubInv;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.TextBox tDialogEd;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox tScriptEd;
		private System.Windows.Forms.Button btnBrowse2;
		private System.Windows.Forms.Button btnSaveCfg;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox tDialogs;
		private System.Windows.Forms.Button btnBrowse3;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.TextBox tScripts;
		private System.Windows.Forms.Button btnBrowse4;
		private System.Windows.Forms.OpenFileDialog cfgBrowser;
		private System.Windows.Forms.OpenFileDialog cfgDialogs;
		private System.Windows.Forms.OpenFileDialog cfgScripts;
		private System.Windows.Forms.ListBox lstDialogs;
		private System.Windows.Forms.Button btnDelDialog;
		private System.Windows.Forms.Button btnEditDialog;
		private System.Windows.Forms.Button btnLoadDialogs;
		private System.Windows.Forms.ListBox lstScripts;
		private System.Windows.Forms.Button btnLoadScripts;
		private System.Windows.Forms.Button btnEditScript;
		private System.Windows.Forms.Button btnDelScript;
		private System.Windows.Forms.CheckBox pNpcInvSlot;
		private System.Windows.Forms.TextBox vNpcInvSlot;
		private System.Windows.Forms.TextBox vChestInvSlot;
		private System.Windows.Forms.CheckBox pChestInvSlot;
		private System.Windows.Forms.CheckBox pDispatcher;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ListBox lstJumpPoints;
		private System.Windows.Forms.Button btnOpenJP;
		private System.Windows.Forms.Button btnSaveJP;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox JPIndex;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.OpenFileDialog MultiODLG;
		private System.Windows.Forms.TextBox JPY;
		private System.Windows.Forms.TextBox JPX;
		private System.Windows.Forms.TextBox JPName;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.TextBox JPMap;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Button btnDelPoint;
		private System.Windows.Forms.Button btnAddPoint;
		private System.Windows.Forms.Button btnUpdatePoint;
		private System.Windows.Forms.CheckBox pKeyID;
		private System.Windows.Forms.TextBox vKeyID;
		private System.Windows.Forms.TextBox vKeyID2;
		private System.Windows.Forms.CheckBox pKeyID2;
		private System.Windows.Forms.TabControl GenericTab;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Button btnLoadDLL;
		private System.Windows.Forms.Button btnSaveDLL;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.TextBox PCCount;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.TextBox LawfulGood;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.TextBox LawfulNeutral;
		private System.Windows.Forms.TextBox LawfulEvil;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.TextBox NeutralEvil;
		private System.Windows.Forms.TextBox TrueNeutral;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.TextBox NeutralGood;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.TextBox ChaoticEvil;
		private System.Windows.Forms.TextBox ChaoticNeutral;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.TextBox ChaoticGood;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.ListBox lstProtoProps;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.ComboBox CurProto;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.TextBox tPropValue;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.ComboBox IntelliProp;
		private System.Windows.Forms.Button btnUpdateProto;
		private System.Windows.Forms.Button btnIPInsert;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.TextBox tProtoID;
		private System.Windows.Forms.Button btnAddProto;
		private System.Windows.Forms.Button btnDelProto;
		private System.Windows.Forms.Button btnSaveProtos;
		private System.Windows.Forms.Button btnGoToDesc;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.Button btnIPReplace;
		private System.Windows.Forms.TabPage h_YScripts;
		private System.Windows.Forms.TabPage i_YDialogs;
		private System.Windows.Forms.TabPage k_YY_DLLEd;
		private System.Windows.Forms.TabPage j_YY_Worldmap;
		private System.Windows.Forms.TabPage l_ZZConfig;
		private System.Windows.Forms.ListBox lstDesc;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.TextBox tDescID;
		private System.Windows.Forms.Label label79;
		private System.Windows.Forms.TextBox tDescript;
		private System.Windows.Forms.Label label80;
		private System.Windows.Forms.TextBox tLongDescript;
		private System.Windows.Forms.Button btnSetDescs;
		private System.Windows.Forms.Button btnSaveDesc;
		private System.Windows.Forms.Button btnLookUpProto;
		private System.Windows.Forms.Label label82;
		private System.Windows.Forms.Label label83;
		private System.Windows.Forms.Button btnOpenProps;
		private System.Windows.Forms.Button btnSaveProps;
		private System.Windows.Forms.Label label76;
		private System.Windows.Forms.TextBox tArtEntry;
		private System.Windows.Forms.Label label84;
		private System.Windows.Forms.TextBox tMapWidth;
		private System.Windows.Forms.Label label85;
		private System.Windows.Forms.TextBox tMapHeight;
		private System.Windows.Forms.Button btnRemoveDesc;
		private System.Windows.Forms.Button btnAddDesc;
		private System.Windows.Forms.NumericUpDown LocationX;
		private System.Windows.Forms.NumericUpDown LocationY;
		private System.Windows.Forms.Label label75;
		private System.Windows.Forms.Button btnOpenSec;
		private System.Windows.Forms.Button btnSaveSec;
		private System.Windows.Forms.Label label81;
		private System.Windows.Forms.TabControl tabSectorEd;
		private System.Windows.Forms.Button btnNewSector;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.Label tu_X_0;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label tu_X_Y;
		private System.Windows.Forms.Label tu_0_Y;
		private System.Windows.Forms.Label tu_0_0;
		private System.Windows.Forms.Label tCurSector;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.Button btnDelLights;
		private System.Windows.Forms.Button btnDelObjects;
		private System.Windows.Forms.Button btnResetTiles;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Label tv_0_Y;
		private System.Windows.Forms.Label tv_X_0;
		private System.Windows.Forms.Label tv_0_0;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.Label tv_X_Y;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.CheckBox p_OCOF;
		private System.Windows.Forms.CheckBox v_CFlag00;
		private System.Windows.Forms.CheckBox v_CFlag01;
		private System.Windows.Forms.CheckBox v_CFlag02;
		private System.Windows.Forms.CheckBox v_CFlag03;
		private System.Windows.Forms.CheckBox v_CFlag04;
		private System.Windows.Forms.CheckBox v_CFlag05;
		private System.Windows.Forms.CheckBox v_CFlag06;
		private System.Windows.Forms.CheckBox v_CFlag08;
		private System.Windows.Forms.CheckBox v_CFlag07;
		private System.Windows.Forms.CheckBox v_CFlag09;
		private System.Windows.Forms.CheckBox v_CFlag10;
		private System.Windows.Forms.CheckBox v_CFlag11;
		private System.Windows.Forms.CheckBox v_CFlag12;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.CheckBox chkEnableDebug;
		private System.Windows.Forms.TabPage b_Lights;
		private System.Windows.Forms.TabPage a_Tiles;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.ComboBox cmbTileSound;
		private System.Windows.Forms.NumericUpDown TY;
		private System.Windows.Forms.NumericUpDown TX;
		private System.Windows.Forms.Button btnUpdateTile;
		private System.Windows.Forms.Button btnUpdateAllTiles;
		private System.Windows.Forms.Label label105;
		private System.Windows.Forms.Label label106;
		private System.Windows.Forms.Button btnUpdateBoxTiles;
		private System.Windows.Forms.Label label107;
		private System.Windows.Forms.NumericUpDown FromTY;
		private System.Windows.Forms.NumericUpDown FromTX;
		private System.Windows.Forms.Label label108;
		private System.Windows.Forms.Label label109;
		private System.Windows.Forms.Label label110;
		private System.Windows.Forms.NumericUpDown ToTY;
		private System.Windows.Forms.NumericUpDown ToTX;
		private System.Windows.Forms.Label label111;
		private System.Windows.Forms.Label label112;
		private System.Windows.Forms.Button btnLoadTile;
		private System.Windows.Forms.Label label113;
		private System.Windows.Forms.TabPage aa_Mobiles;
		private System.Windows.Forms.TabPage bb_Sectors;
		private System.Windows.Forms.TabPage gg_YX_Descriptions;
		private System.Windows.Forms.TabPage ff_YT_Prototypes;
		private System.Windows.Forms.TabPage dd_SMapProps;
		private System.Windows.Forms.TabPage cc_SMJumpPts;
		private System.Windows.Forms.TabPage ee_N2DMaps;
		private System.Windows.Forms.CheckBox TILE_BLOCKS;
		private System.Windows.Forms.CheckBox TILE_SINKS;
		private System.Windows.Forms.CheckBox TILE_CAN_FLY_OVER;
		private System.Windows.Forms.CheckBox TILE_ICY;
		private System.Windows.Forms.CheckBox TILE_NATURAL;
		private System.Windows.Forms.CheckBox TILE_SOUNDPROOF;
		private System.Windows.Forms.CheckBox TILE_INDOOR;
		private System.Windows.Forms.CheckBox TILE_REFLECTIVE;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_VISION;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label119;
		private System.Windows.Forms.Label label120;
		private System.Windows.Forms.Label label121;
		private System.Windows.Forms.Label label122;
		private System.Windows.Forms.Label label123;
		private System.Windows.Forms.Label label124;
		private System.Windows.Forms.Label label125;
		private System.Windows.Forms.Label label128;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_LR;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_LM;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_LL;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_MR;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_MM;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_ML;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_UR;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_UM;
		private System.Windows.Forms.CheckBox TILE_BLOCKS_UL;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_LR;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_LM;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_LL;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_MR;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_MM;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_ML;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_UR;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_UM;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_UL;
		private System.Windows.Forms.CheckBox TILE_FLYOVER_COVER;
		private System.Windows.Forms.CheckBox chkAutoTile;
		private System.Windows.Forms.CheckBox SVB1_LR;
		private System.Windows.Forms.CheckBox SVB1_LM;
		private System.Windows.Forms.CheckBox SVB1_LL;
		private System.Windows.Forms.CheckBox SVB1_MR;
		private System.Windows.Forms.CheckBox SVB1_MM;
		private System.Windows.Forms.CheckBox SVB1_ML;
		private System.Windows.Forms.CheckBox SVB1_UR;
		private System.Windows.Forms.CheckBox SVB1_UM;
		private System.Windows.Forms.CheckBox SVB1_UL;
		private System.Windows.Forms.CheckBox SVB2_LR;
		private System.Windows.Forms.CheckBox SVB2_LM;
		private System.Windows.Forms.CheckBox SVB2_LL;
		private System.Windows.Forms.CheckBox SVB2_MR;
		private System.Windows.Forms.CheckBox SVB2_MM;
		private System.Windows.Forms.CheckBox SVB2_ML;
		private System.Windows.Forms.CheckBox SVB2_UR;
		private System.Windows.Forms.CheckBox SVB2_UM;
		private System.Windows.Forms.CheckBox SVB2_UL;
		private System.Windows.Forms.CheckBox SVB3_LR;
		private System.Windows.Forms.CheckBox SVB3_LM;
		private System.Windows.Forms.CheckBox SVB3_LL;
		private System.Windows.Forms.CheckBox SVB3_MR;
		private System.Windows.Forms.CheckBox SVB3_MM;
		private System.Windows.Forms.CheckBox SVB3_ML;
		private System.Windows.Forms.CheckBox SVB3_UR;
		private System.Windows.Forms.CheckBox SVB3_UM;
		private System.Windows.Forms.CheckBox SVB3_UL;
		private System.Windows.Forms.CheckBox SVB4_LR;
		private System.Windows.Forms.CheckBox SVB4_LM;
		private System.Windows.Forms.CheckBox SVB4_LL;
		private System.Windows.Forms.CheckBox SVB4_MR;
		private System.Windows.Forms.CheckBox SVB4_MM;
		private System.Windows.Forms.CheckBox SVB4_ML;
		private System.Windows.Forms.CheckBox SVB4_UR;
		private System.Windows.Forms.CheckBox SVB4_UM;
		private System.Windows.Forms.CheckBox SVB4_UL;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.Label label116;
		private System.Windows.Forms.CheckBox pModelScale;
		private System.Windows.Forms.TextBox vModelScale;
		private System.Windows.Forms.Label label117;
		private System.Windows.Forms.Label label127;
		private System.Windows.Forms.TextBox vOfsZ;
		private System.Windows.Forms.CheckBox pOfsZ;
		private System.Windows.Forms.GroupBox ObjHPGroup;
		private System.Windows.Forms.CheckBox pHP;
		private System.Windows.Forms.TextBox vHP;
		private System.Windows.Forms.TextBox vHPAdj;
		private System.Windows.Forms.CheckBox pHPAdj;
		private System.Windows.Forms.TextBox vHPDmg;
		private System.Windows.Forms.CheckBox pHPDmg;
		private System.Windows.Forms.GroupBox ObjSpeedGroup;
		private System.Windows.Forms.TextBox vSpdRun;
		private System.Windows.Forms.CheckBox pSpdRun;
		private System.Windows.Forms.TextBox vSpdWalk;
		private System.Windows.Forms.CheckBox pSpdWalk;
		private System.Windows.Forms.Label label129;
		private System.Windows.Forms.Label label130;
		private System.Windows.Forms.Label label131;
		private System.Windows.Forms.GroupBox MapPrpGroup;
		private System.Windows.Forms.GroupBox GlobalLitGroup;
		private System.Windows.Forms.Button btnSaveGLT;
		private System.Windows.Forms.Button btnOpenGLT;
		private System.Windows.Forms.TextBox tGLT1;
        private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label132;
		private System.Windows.Forms.TextBox tGLTRed;
		private System.Windows.Forms.Label label133;
		private System.Windows.Forms.TextBox tGLTGreen;
		private System.Windows.Forms.Label label134;
		private System.Windows.Forms.TextBox tGLTBlue;
		private System.Windows.Forms.Label label135;
		private System.Windows.Forms.TextBox tGLT3;
		private System.Windows.Forms.Label label136;
		private System.Windows.Forms.TextBox tGLT4;
		private System.Windows.Forms.Label label137;
		private System.Windows.Forms.TextBox tGLT5;
		private System.Windows.Forms.Label label138;
		private System.Windows.Forms.Label label139;
		private System.Windows.Forms.TextBox tGLTStartAngle;
		private System.Windows.Forms.TextBox tGLTEndAngle;
		private System.Windows.Forms.Label label140;
		private System.Windows.Forms.Label label141;
		private System.Windows.Forms.TextBox tGLT6;
		private System.Windows.Forms.TextBox tGLT7;
		private System.Windows.Forms.Label label142;
		private System.Windows.Forms.Label label143;
		private System.Windows.Forms.TextBox tGLT8;
		private System.Windows.Forms.GroupBox GroupAreaCleaner;
		private System.Windows.Forms.Label label144;
		private System.Windows.Forms.CheckBox chkMOB;
		private System.Windows.Forms.CheckBox chkSECSVB;
		private System.Windows.Forms.CheckBox chkCLIPPING;
		private System.Windows.Forms.CheckBox chkGMESH;
		private System.Windows.Forms.CheckBox chkPND;
		private System.Windows.Forms.CheckBox chkHSD;
		private System.Windows.Forms.Button btnCleanArea;
		private System.Windows.Forms.Label label145;
		private System.Windows.Forms.CheckBox pPLockDC;
		private System.Windows.Forms.TextBox vPLockDC;
		private System.Windows.Forms.TextBox vPKeyID;
		private System.Windows.Forms.CheckBox pPKeyID;
		private System.Windows.Forms.CheckBox v_PFlag00;
		private System.Windows.Forms.CheckBox v_PFlag01;
		private System.Windows.Forms.CheckBox v_PFlag02;
		private System.Windows.Forms.CheckBox v_PFlag03;
		private System.Windows.Forms.CheckBox v_PFlag04;
		private System.Windows.Forms.CheckBox v_PFlag05;
		private System.Windows.Forms.CheckBox v_PFlag06;
		private System.Windows.Forms.CheckBox v_PFlag07;
		private System.Windows.Forms.CheckBox v_PFlag08;
		private System.Windows.Forms.CheckBox v_PFlag09;
		private System.Windows.Forms.CheckBox p_OPF;
		private System.Windows.Forms.CheckBox HSD_LR;
		private System.Windows.Forms.CheckBox HSD_LM;
		private System.Windows.Forms.CheckBox HSD_LL;
		private System.Windows.Forms.CheckBox HSD_MR;
		private System.Windows.Forms.CheckBox HSD_MM;
		private System.Windows.Forms.CheckBox HSD_ML;
		private System.Windows.Forms.CheckBox HSD_UR;
		private System.Windows.Forms.CheckBox HSD_UM;
		private System.Windows.Forms.CheckBox HSD_UL;
		private System.Windows.Forms.CheckBox cfgDelEmpty;
		private System.Windows.Forms.NumericUpDown HGT_LR;
		private System.Windows.Forms.NumericUpDown HGT_LM;
		private System.Windows.Forms.NumericUpDown HGT_LL;
		private System.Windows.Forms.NumericUpDown HGT_MR;
		private System.Windows.Forms.NumericUpDown HGT_MM;
		private System.Windows.Forms.NumericUpDown HGT_ML;
		private System.Windows.Forms.NumericUpDown HGT_UR;
		private System.Windows.Forms.NumericUpDown HGT_UM;
		private System.Windows.Forms.NumericUpDown HGT_UL;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.NumericUpDown LightID;
		private System.Windows.Forms.Label label114;
		private System.Windows.Forms.Label label115;
		private System.Windows.Forms.Label label126;
		private System.Windows.Forms.TextBox Light1;
		private System.Windows.Forms.TextBox Light2;
		private System.Windows.Forms.Label label147;
		private System.Windows.Forms.TextBox Light3;
		private System.Windows.Forms.Label label148;
		private System.Windows.Forms.TextBox Light4;
		private System.Windows.Forms.Label label149;
		private System.Windows.Forms.TextBox Light5;
		private System.Windows.Forms.Label label150;
		private System.Windows.Forms.TextBox Light7;
		private System.Windows.Forms.Label label151;
		private System.Windows.Forms.TextBox Light6;
		private System.Windows.Forms.Label label152;
		private System.Windows.Forms.TextBox Light8;
		private System.Windows.Forms.Label label153;
		private System.Windows.Forms.TextBox Light9;
		private System.Windows.Forms.Label label154;
		private System.Windows.Forms.TextBox Light12;
		private System.Windows.Forms.Label label155;
		private System.Windows.Forms.TextBox Light13;
		private System.Windows.Forms.Label label156;
		private System.Windows.Forms.TextBox Light14;
		private System.Windows.Forms.Label label157;
		private System.Windows.Forms.TextBox Light15;
		private System.Windows.Forms.Label label158;
		private System.Windows.Forms.TextBox Light16;
		private System.Windows.Forms.Label label159;
		private System.Windows.Forms.TextBox Light17;
		private System.Windows.Forms.Label label160;
		private System.Windows.Forms.TextBox Light18;
		private System.Windows.Forms.Label label161;
		private System.Windows.Forms.TextBox Light19;
		private System.Windows.Forms.Label label162;
		private System.Windows.Forms.TextBox Light20;
		private System.Windows.Forms.Label label163;
		private System.Windows.Forms.TextBox Light21;
		private System.Windows.Forms.Label label164;
		private System.Windows.Forms.TextBox Light22;
		private System.Windows.Forms.Label label165;
		private System.Windows.Forms.TextBox Light23;
		private System.Windows.Forms.Label label166;
		private System.Windows.Forms.TextBox Light24;
		private System.Windows.Forms.Label label167;
		private System.Windows.Forms.NumericUpDown Light10_X;
		private System.Windows.Forms.NumericUpDown Light11_Y;
		private System.Windows.Forms.TextBox Light25;
		private System.Windows.Forms.Label label168;
		private System.Windows.Forms.TextBox Light26;
		private System.Windows.Forms.Label label169;
		private System.Windows.Forms.TextBox Light27;
		private System.Windows.Forms.Label label170;
		private System.Windows.Forms.TextBox Light28;
		private System.Windows.Forms.Label label171;
		private System.Windows.Forms.TextBox Light29;
		private System.Windows.Forms.Label label172;
		private System.Windows.Forms.TextBox Light30;
		private System.Windows.Forms.Label label173;
		private System.Windows.Forms.Label label174;
		private System.Windows.Forms.Button btnLightAdd;
		private System.Windows.Forms.Button btnDelLight;
		private System.Windows.Forms.Button btnLightUpdate;
		private System.Windows.Forms.Label label175;
		private System.Windows.Forms.TextBox vTransparency;
		private System.Windows.Forms.CheckBox pTransparency;
		private System.Windows.Forms.CheckBox chkObjIDGen;
		private System.Windows.Forms.CheckBox v_NFlag00;
		private System.Windows.Forms.CheckBox p_ONF;
		private System.Windows.Forms.CheckBox v_NFlag01;
		private System.Windows.Forms.CheckBox v_NFlag02;
		private System.Windows.Forms.CheckBox v_NFlag03;
		private System.Windows.Forms.CheckBox v_NFlag04;
		private System.Windows.Forms.CheckBox v_NFlag05;
		private System.Windows.Forms.CheckBox v_NFlag06;
		private System.Windows.Forms.CheckBox v_NFlag07;
		private System.Windows.Forms.CheckBox v_NFlag08;
		private System.Windows.Forms.CheckBox v_NFlag09;
		private System.Windows.Forms.CheckBox v_NFlag10;
		private System.Windows.Forms.CheckBox v_NFlag11;
		private System.Windows.Forms.CheckBox v_NFlag12;
		private System.Windows.Forms.CheckBox v_NFlag13;
		private System.Windows.Forms.CheckBox v_NFlag14;
		private System.Windows.Forms.CheckBox v_NFlag15;
		private System.Windows.Forms.CheckBox v_NFlag16;
		private System.Windows.Forms.CheckBox v_NFlag17;
		private System.Windows.Forms.CheckBox v_NFlag18;
		private System.Windows.Forms.CheckBox v_NFlag19;
		private System.Windows.Forms.CheckBox v_NFlag20;
		private System.Windows.Forms.CheckBox v_NFlag21;
		private System.Windows.Forms.CheckBox v_NFlag22;
		private System.Windows.Forms.CheckBox v_NFlag23;
		private System.Windows.Forms.CheckBox v_NFlag24;
		private System.Windows.Forms.CheckBox v_NFlag25;
		private System.Windows.Forms.CheckBox v_NFlag26;
		private System.Windows.Forms.CheckBox v_NFlag27;
		private System.Windows.Forms.CheckBox v_NFlag28;
		private System.Windows.Forms.CheckBox v_NFlag29;
		private System.Windows.Forms.CheckBox v_NFlag30;
		private System.Windows.Forms.CheckBox v_NFlag31;
		private System.Windows.Forms.CheckBox v_C1Flag29;
		private System.Windows.Forms.CheckBox v_C1Flag28;
		private System.Windows.Forms.CheckBox v_C1Flag27;
		private System.Windows.Forms.CheckBox v_C1Flag26;
		private System.Windows.Forms.CheckBox v_C1Flag25;
		private System.Windows.Forms.CheckBox v_C1Flag24;
		private System.Windows.Forms.CheckBox v_C1Flag23;
		private System.Windows.Forms.CheckBox v_C1Flag22;
		private System.Windows.Forms.CheckBox v_C1Flag21;
		private System.Windows.Forms.CheckBox v_C1Flag20;
		private System.Windows.Forms.CheckBox v_C1Flag19;
		private System.Windows.Forms.CheckBox v_C1Flag18;
		private System.Windows.Forms.CheckBox v_C1Flag17;
		private System.Windows.Forms.CheckBox v_C1Flag16;
		private System.Windows.Forms.CheckBox v_C1Flag15;
		private System.Windows.Forms.CheckBox v_C1Flag14;
		private System.Windows.Forms.CheckBox v_C1Flag13;
		private System.Windows.Forms.CheckBox v_C1Flag12;
		private System.Windows.Forms.CheckBox v_C1Flag11;
		private System.Windows.Forms.CheckBox v_C1Flag10;
		private System.Windows.Forms.CheckBox v_C1Flag09;
		private System.Windows.Forms.CheckBox v_C1Flag08;
		private System.Windows.Forms.CheckBox v_C1Flag07;
		private System.Windows.Forms.CheckBox v_C1Flag06;
		private System.Windows.Forms.CheckBox v_C1Flag05;
		private System.Windows.Forms.CheckBox v_C1Flag04;
		private System.Windows.Forms.CheckBox v_C1Flag03;
		private System.Windows.Forms.CheckBox v_C1Flag02;
		private System.Windows.Forms.CheckBox v_C1Flag01;
		private System.Windows.Forms.CheckBox v_C1Flag00;
		private System.Windows.Forms.CheckBox p_OCF;
		private System.Windows.Forms.CheckBox v_C1Flag31;
		private System.Windows.Forms.CheckBox v_C1Flag30;
		private System.Windows.Forms.CheckBox p_OIF;
		private System.Windows.Forms.CheckBox pItemAmt;
		private System.Windows.Forms.TextBox vItemAmt;
		private System.Windows.Forms.CheckBox v_C2Flag24;
		private System.Windows.Forms.CheckBox v_C2Flag23;
		private System.Windows.Forms.CheckBox v_C2Flag22;
		private System.Windows.Forms.CheckBox v_C2Flag21;
		private System.Windows.Forms.CheckBox v_C2Flag20;
		private System.Windows.Forms.CheckBox v_C2Flag19;
		private System.Windows.Forms.CheckBox v_C2Flag18;
		private System.Windows.Forms.CheckBox v_C2Flag17;
		private System.Windows.Forms.CheckBox v_C2Flag16;
		private System.Windows.Forms.CheckBox v_C2Flag15;
		private System.Windows.Forms.CheckBox v_C2Flag14;
		private System.Windows.Forms.CheckBox v_C2Flag13;
		private System.Windows.Forms.CheckBox v_C2Flag12;
		private System.Windows.Forms.CheckBox v_C2Flag11;
		private System.Windows.Forms.CheckBox v_C2Flag10;
		private System.Windows.Forms.CheckBox v_C2Flag09;
		private System.Windows.Forms.CheckBox v_C2Flag08;
		private System.Windows.Forms.CheckBox v_C2Flag07;
		private System.Windows.Forms.CheckBox v_C2Flag06;
		private System.Windows.Forms.CheckBox v_C2Flag05;
		private System.Windows.Forms.CheckBox v_C2Flag04;
		private System.Windows.Forms.CheckBox v_C2Flag03;
		private System.Windows.Forms.CheckBox v_C2Flag02;
		private System.Windows.Forms.CheckBox v_C2Flag01;
		private System.Windows.Forms.CheckBox v_C2Flag00;
		private System.Windows.Forms.CheckBox p_OCF2;
		private System.Windows.Forms.CheckBox v_C2Flag27;
		private System.Windows.Forms.CheckBox v_C2Flag26;
		private System.Windows.Forms.CheckBox v_C2Flag25;
		private System.Windows.Forms.CheckBox v_OAFlag04;
		private System.Windows.Forms.CheckBox v_OAFlag03;
		private System.Windows.Forms.CheckBox v_OAFlag02;
		private System.Windows.Forms.CheckBox v_OAFlag01;
		private System.Windows.Forms.CheckBox v_OAFlag00;
		private System.Windows.Forms.CheckBox p_OARF;
		private System.Windows.Forms.CheckBox v_WFlag04;
		private System.Windows.Forms.CheckBox v_WFlag03;
		private System.Windows.Forms.CheckBox v_WFlag02;
		private System.Windows.Forms.CheckBox v_WFlag01;
		private System.Windows.Forms.CheckBox v_WFlag00;
		private System.Windows.Forms.CheckBox p_OWF;
		private System.Windows.Forms.CheckBox v_WFlag09;
		private System.Windows.Forms.CheckBox v_WFlag08;
		private System.Windows.Forms.CheckBox v_WFlag07;
		private System.Windows.Forms.CheckBox v_WFlag06;
		private System.Windows.Forms.CheckBox v_WFlag05;
		private System.Windows.Forms.CheckBox v_WFlag12;
		private System.Windows.Forms.CheckBox v_WFlag11;
		private System.Windows.Forms.CheckBox v_WFlag10;
		private System.Windows.Forms.CheckBox v_SFlag12;
		private System.Windows.Forms.CheckBox v_SFlag11;
		private System.Windows.Forms.CheckBox v_SFlag10;
		private System.Windows.Forms.CheckBox v_SFlag09;
		private System.Windows.Forms.CheckBox v_SFlag08;
		private System.Windows.Forms.CheckBox v_SFlag07;
		private System.Windows.Forms.CheckBox v_SFlag06;
		private System.Windows.Forms.CheckBox v_SFlag05;
		private System.Windows.Forms.CheckBox v_SFlag04;
		private System.Windows.Forms.CheckBox v_SFlag03;
		private System.Windows.Forms.CheckBox v_SFlag02;
		private System.Windows.Forms.CheckBox v_SFlag01;
		private System.Windows.Forms.CheckBox v_SFlag00;
		private System.Windows.Forms.CheckBox p_OSCF;
		private System.Windows.Forms.TextBox vACAdj;
		private System.Windows.Forms.CheckBox pACAdj;
		private System.Windows.Forms.TextBox vACMaxDex;
		private System.Windows.Forms.CheckBox pACMaxDex;
		private System.Windows.Forms.TextBox vSpellFail;
		private System.Windows.Forms.CheckBox pSpellFail;
		private System.Windows.Forms.TextBox vArmorChk;
		private System.Windows.Forms.CheckBox pArmorChk;
		private System.Windows.Forms.TextBox vEffName;
		private System.Windows.Forms.CheckBox pEffName;
		private System.Windows.Forms.TextBox vSDDC;
		private System.Windows.Forms.CheckBox pSDDC;
		private System.Windows.Forms.CheckBox pAmmoAmt;
		private System.Windows.Forms.TextBox vAmmoAmt;
		private System.Windows.Forms.CheckBox v_SDFlag12;
		private System.Windows.Forms.CheckBox v_SDFlag11;
		private System.Windows.Forms.CheckBox v_SDFlag10;
		private System.Windows.Forms.CheckBox v_SDFlag09;
		private System.Windows.Forms.CheckBox v_SDFlag08;
		private System.Windows.Forms.CheckBox v_SDFlag07;
		private System.Windows.Forms.CheckBox v_SDFlag06;
		private System.Windows.Forms.CheckBox v_SDFlag05;
		private System.Windows.Forms.CheckBox v_SDFlag04;
		private System.Windows.Forms.CheckBox v_SDFlag03;
		private System.Windows.Forms.CheckBox v_SDFlag02;
		private System.Windows.Forms.CheckBox v_SDFlag01;
		private System.Windows.Forms.CheckBox v_SDFlag00;
		private System.Windows.Forms.CheckBox p_OSDF;
		private System.Windows.Forms.CheckBox v_SDFlag15;
		private System.Windows.Forms.CheckBox v_SDFlag14;
		private System.Windows.Forms.CheckBox v_SDFlag13;
		private System.Windows.Forms.TabPage c_Objects;
		private System.Windows.Forms.ListBox SecObjList;
		private System.Windows.Forms.Label label176;
		private System.Windows.Forms.Label label177;
		private System.Windows.Forms.Button btnDelObj;
		private System.Windows.Forms.Button btnXtrObj;
		private System.Windows.Forms.TextBox vObjName;
		private System.Windows.Forms.CheckBox pObjName;
		private System.Windows.Forms.CheckBox v_SDFlag31;
		private System.Windows.Forms.CheckBox v_SDFlag30;
		private System.Windows.Forms.CheckBox v_SDFlag29;
		private System.Windows.Forms.CheckBox v_SDFlag28;
		private System.Windows.Forms.CheckBox v_SDFlag27;
		private System.Windows.Forms.CheckBox v_SDFlag26;
		private System.Windows.Forms.CheckBox v_SDFlag25;
		private System.Windows.Forms.CheckBox v_SDFlag24;
		private System.Windows.Forms.CheckBox v_SDFlag23;
		private System.Windows.Forms.CheckBox v_SDFlag22;
		private System.Windows.Forms.CheckBox v_SDFlag21;
		private System.Windows.Forms.CheckBox v_SDFlag20;
		private System.Windows.Forms.CheckBox v_SDFlag19;
		private System.Windows.Forms.CheckBox v_SDFlag18;
		private System.Windows.Forms.CheckBox v_SDFlag17;
		private System.Windows.Forms.CheckBox v_SDFlag16;
		private System.Windows.Forms.Label label178;
		private System.Windows.Forms.TabPage a;
		private System.Windows.Forms.TabPage c;
		private System.Windows.Forms.TabPage d;
		private System.Windows.Forms.TabPage g;
		private System.Windows.Forms.TabPage i;
		private System.Windows.Forms.TabPage k;
		private System.Windows.Forms.TabPage m;
		private System.Windows.Forms.TabPage b;
		private System.Windows.Forms.TabPage e;
		private System.Windows.Forms.TabPage f;
		private System.Windows.Forms.TabPage h;
		private System.Windows.Forms.TabPage j;
		private System.Windows.Forms.TabPage l;
		private System.Windows.Forms.TabPage n;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.CheckBox pWaypoints;
		private System.Windows.Forms.ListBox vWaypoints;
		private System.Windows.Forms.Label label179;
		private System.Windows.Forms.Label label180;
		private System.Windows.Forms.TextBox vWayX;
		private System.Windows.Forms.TextBox vWayY;
		private System.Windows.Forms.Button btnWayAdd;
		private System.Windows.Forms.Button btnWayDel;
		private System.Windows.Forms.CheckBox pWeight;
		private System.Windows.Forms.TextBox vWeight;
		private System.Windows.Forms.CheckBox pWorth;
		private System.Windows.Forms.TextBox vWorth;
		private System.Windows.Forms.CheckBox pReach;
		private System.Windows.Forms.TextBox vReach;
		private System.Windows.Forms.CheckBox pFaction;
        private System.Windows.Forms.TextBox vFaction;
		private System.Windows.Forms.Label label187;
		private System.Windows.Forms.TextBox vDayFlags;
		private System.Windows.Forms.Label label188;
		private System.Windows.Forms.TextBox vNightFlags;
		private System.Windows.Forms.Label label190;
		private System.Windows.Forms.TextBox vTeleY;
		private System.Windows.Forms.TextBox vTeleX;
		private System.Windows.Forms.CheckBox pTeleMap;
		private System.Windows.Forms.TextBox vTeleMap;
		private System.Windows.Forms.CheckBox pTeleDest;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.Timer WM_SysMsg;
		private System.Windows.Forms.CheckBox pAI64;
		private System.Windows.Forms.TextBox vAI64;
		private System.Windows.Forms.Label label191;
		private System.Windows.Forms.Label label192;
		private System.Windows.Forms.Label label189;
		private System.Windows.Forms.Label label193;
		private System.Windows.Forms.CheckBox pMoneyIdx;
		private System.Windows.Forms.Label label194;
		private System.Windows.Forms.Label label195;
		private System.Windows.Forms.Label label196;
		private System.Windows.Forms.Label label197;
		private System.Windows.Forms.TextBox vMoneyIdx1;
		private System.Windows.Forms.TextBox vMoneyIdx2;
		private System.Windows.Forms.TextBox vMoneyIdx3;
		private System.Windows.Forms.TextBox vMoneyIdx4;
		private System.Windows.Forms.CheckBox pNotify1;
		private System.Windows.Forms.TextBox vNotify1;
		private System.Windows.Forms.CheckBox pNotify2;
		private System.Windows.Forms.TextBox vNotify2;
		private System.Windows.Forms.Label label77;
		private System.Windows.Forms.ListBox w_Paths;
		private System.Windows.Forms.Label label198;
		private System.Windows.Forms.Button btnOpenWorldMap;
		private System.Windows.Forms.Button btnSaveWorldMap;
		private System.Windows.Forms.Button btnDelPath;
		private System.Windows.Forms.Button btnAddPath;
		private System.Windows.Forms.Label label199;
		private System.Windows.Forms.Label wPar1;
		private System.Windows.Forms.TextBox tPar1;
		private System.Windows.Forms.Label wPar2;
		private System.Windows.Forms.Label wPar3;
		private System.Windows.Forms.Label wPar4;
		private System.Windows.Forms.TextBox tPar2;
		private System.Windows.Forms.TextBox tPar3;
		private System.Windows.Forms.TextBox tPar4;
		private System.Windows.Forms.Label label200;
		private System.Windows.Forms.Label label201;
		private System.Windows.Forms.ComboBox w_Opcodes;
		private System.Windows.Forms.Label label202;
		private System.Windows.Forms.ListBox w_PathCodes;
		private System.Windows.Forms.Label label203;
		private System.Windows.Forms.Label tPathElem;
		private System.Windows.Forms.Button btnInsertOpcode;
		private System.Windows.Forms.Button btnDeleteOpcode;
		private System.Windows.Forms.Button btnSetOpcode;
		private System.Windows.Forms.Button btnUpdatePath;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem mnuAddins;
		private System.Windows.Forms.MenuItem menuItem17;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem sectorCoordinateLookupToolStripMenuItem;
        private ToolStripMenuItem visualSectorAnalyzerPainterToolStripMenuItem;
        private ToolStripMenuItem pathNodeGeneratorToolStripMenuItem;
        private ToolStripMenuItem specialInventorySlotsForMobilesToolStripMenuItem;
        private ToolStripMenuItem creatingMerchantsToolStripMenuItem;
        private ToolStripMenuItem creatingMerchantsWithRespawningInventoriesToolStripMenuItem;
        private ToolStripMenuItem modifyingRestingOptionsForMapsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem aboutToEEWorldBuilderNET2ToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem prototypeSearchToolStripMenuItem;
        private CheckBox btnDblClickClean;
        private TextBox vWayAnim1;
        private Label label146;
        private CheckBox cAnimWpt;
        private TextBox vWayAnim4;
        private TextBox vWayAnim3;
        private TextBox vWayAnim2;
        private TextBox vWayAnim8;
        private TextBox vWayAnim7;
        private TextBox vWayAnim6;
        private TextBox vWayAnim5;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem commonWaypointAnimationIDsToolStripMenuItem;
        private ComboBox tGLT2;
        private ToolStripMenuItem sectorLightEditorToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem dayNightTransitionsEditorToolStripMenuItem;
        private TextBox vWayRot;
        private Label label204;
        private CheckBox cRotWpt;
        private CheckBox cDelayWpt;
        private TextBox vWayDelay;
        private Label label205;
        private TabPage d2;
        private Button btnAddFaction;
        private TextBox vFactionsIdx;
        private Label label206;
        private ListBox vFactions;
        private CheckBox pFactions;
        private Button btnDelFaction;
        private Label label207;
        private Button btnSVBWizard;
        private TextBox vNightJP;
        private TextBox vDayJP;
        private Label label211;
        private TextBox vNightOfsX;
        private TextBox vDayOfsX;
        private Label label208;
        private Label label209;
        private Label label186;
        private TextBox vNightMap;
        private TextBox vDayMap;
        private Label label185;
        private TextBox vNightY;
        private TextBox vDayY;
        private Label label184;
        private Label label183;
        private TextBox vNightX;
        private TextBox vDayX;
        private Label label182;
        private Label label181;
        private CheckBox pStandpoints;
        private TextBox vNightOfsY;
        private TextBox vDayOfsY;
        private Label label210;
        private CheckBox pLevelup;
        private TextBox vLevelup;
        private Button vNpcInvFill;
        private Button vChestInvFill;
        private Button vCleanNpcInv;
        private Button vCleanChestInv;
        private GroupBox groupBox1;
        private Button btnCleanD20States;
        private Label label212;
        private CheckBox chkCleanScripts;
        private TabPage d1;
        private CheckBox pNPCGenData;
        private TextBox vNPCGenData;
        private Label label213;
        private CheckBox vNPCGDay;
        private CheckBox vNPCGIgnoreTotal;
        private TextBox vNPCGSpawnTotal;
        private Label label215;
        private TextBox vNPCGSpawnConcurrent;
        private Label label214;
        private CheckBox vNPCGSpawnAll;
        private CheckBox vNPCGActive;
        private CheckBox vNPCGNight;
        private RadioButton vNPCGRate1;
        private Label label216;
        private RadioButton vNPCGRate8;
        private RadioButton vNPCGRate7;
        private RadioButton vNPCGRate6;
        private RadioButton vNPCGRate5;
        private RadioButton vNPCGRate4;
        private RadioButton vNPCGRate3;
        private RadioButton vNPCGRate2;
        private CheckBox pScoutPoint;
        private Label label217;
        private TextBox vScoutOfsY;
        private TextBox vScoutJP;
        private TextBox vScoutOfsX;
        private TextBox vScoutMap;
        private TextBox vScoutY;
        private Label label218;
        private TextBox vScoutX;
        private CheckBox pAbilities;
        private Label label224;
        private Label label223;
        private Label label222;
        private Label label221;
        private Label label220;
        private Label label219;
        private TextBox vCHA;
        private TextBox vWIS;
        private TextBox vINT;
        private TextBox vCON;
        private TextBox vDEX;
        private TextBox vSTR;
        private CheckBox pRace;
        private TextBox vRace;
        private CheckBox pGender;
        private TextBox vGender;
        private Label label226;
        private TextBox tWBBridge;
        private Label label225;
        private ToolStripMenuItem addinsToolStripMenuItem;
        private ToolStripMenuItem mobileObjectViewerToolStripMenuItem;
        private ToolStripMenuItem sectorSortUtilityToolStripMenuItem;
        private ToolStripMenuItem scriptOverrideToolToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem whatAreTheseAddinsForToolStripMenuItem;
        private Button btnNewGLT;
        private Button button9;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
		private System.ComponentModel.IContainer components;

		public Worlded()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Worlded));
            this.GenericTab = new System.Windows.Forms.TabControl();
            this.aa_Mobiles = new System.Windows.Forms.TabPage();
            this.vObjName = new System.Windows.Forms.TextBox();
            this.pObjName = new System.Windows.Forms.CheckBox();
            this.label175 = new System.Windows.Forms.Label();
            this.vTransparency = new System.Windows.Forms.TextBox();
            this.pTransparency = new System.Windows.Forms.CheckBox();
            this.label131 = new System.Windows.Forms.Label();
            this.ObjSpeedGroup = new System.Windows.Forms.GroupBox();
            this.label129 = new System.Windows.Forms.Label();
            this.vSpdRun = new System.Windows.Forms.TextBox();
            this.pSpdRun = new System.Windows.Forms.CheckBox();
            this.vSpdWalk = new System.Windows.Forms.TextBox();
            this.pSpdWalk = new System.Windows.Forms.CheckBox();
            this.ObjHPGroup = new System.Windows.Forms.GroupBox();
            this.vHPDmg = new System.Windows.Forms.TextBox();
            this.pHPDmg = new System.Windows.Forms.CheckBox();
            this.vHPAdj = new System.Windows.Forms.TextBox();
            this.pHPAdj = new System.Windows.Forms.CheckBox();
            this.vHP = new System.Windows.Forms.TextBox();
            this.pHP = new System.Windows.Forms.CheckBox();
            this.label127 = new System.Windows.Forms.Label();
            this.vOfsZ = new System.Windows.Forms.TextBox();
            this.pOfsZ = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.vModelScale = new System.Windows.Forms.TextBox();
            this.pModelScale = new System.Windows.Forms.CheckBox();
            this.LocationY = new System.Windows.Forms.NumericUpDown();
            this.LocationX = new System.Windows.Forms.NumericUpDown();
            this.pDispatcher = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnEmbed = new System.Windows.Forms.Button();
            this.vHeight = new System.Windows.Forms.TextBox();
            this.pHeight = new System.Windows.Forms.CheckBox();
            this.vRadius = new System.Windows.Forms.TextBox();
            this.pRadius = new System.Windows.Forms.CheckBox();
            this.vOffsetY = new System.Windows.Forms.TextBox();
            this.vOffsetX = new System.Windows.Forms.TextBox();
            this.pOffsetY = new System.Windows.Forms.CheckBox();
            this.pOffsetX = new System.Windows.Forms.CheckBox();
            this.tabProps = new System.Windows.Forms.TabControl();
            this.a = new System.Windows.Forms.TabPage();
            this.pObjFlag31 = new System.Windows.Forms.CheckBox();
            this.pObjFlag30 = new System.Windows.Forms.CheckBox();
            this.pObjFlag29 = new System.Windows.Forms.CheckBox();
            this.pObjFlag28 = new System.Windows.Forms.CheckBox();
            this.pObjFlag27 = new System.Windows.Forms.CheckBox();
            this.pObjFlag26 = new System.Windows.Forms.CheckBox();
            this.pObjFlag25 = new System.Windows.Forms.CheckBox();
            this.pObjFlag24 = new System.Windows.Forms.CheckBox();
            this.pObjFlag23 = new System.Windows.Forms.CheckBox();
            this.pObjFlag22 = new System.Windows.Forms.CheckBox();
            this.pObjFlag21 = new System.Windows.Forms.CheckBox();
            this.pObjFlag20 = new System.Windows.Forms.CheckBox();
            this.pObjFlag19 = new System.Windows.Forms.CheckBox();
            this.pObjFlag18 = new System.Windows.Forms.CheckBox();
            this.pObjFlag17 = new System.Windows.Forms.CheckBox();
            this.pObjFlag16 = new System.Windows.Forms.CheckBox();
            this.pObjFlag15 = new System.Windows.Forms.CheckBox();
            this.pObjFlag14 = new System.Windows.Forms.CheckBox();
            this.pObjFlag13 = new System.Windows.Forms.CheckBox();
            this.pObjFlag12 = new System.Windows.Forms.CheckBox();
            this.pObjFlag11 = new System.Windows.Forms.CheckBox();
            this.pObjFlag10 = new System.Windows.Forms.CheckBox();
            this.pObjFlag09 = new System.Windows.Forms.CheckBox();
            this.pObjFlag08 = new System.Windows.Forms.CheckBox();
            this.pObjFlag07 = new System.Windows.Forms.CheckBox();
            this.pObjFlag06 = new System.Windows.Forms.CheckBox();
            this.pObjFlag05 = new System.Windows.Forms.CheckBox();
            this.pObjFlag04 = new System.Windows.Forms.CheckBox();
            this.pObjFlag03 = new System.Windows.Forms.CheckBox();
            this.pObjFlag02 = new System.Windows.Forms.CheckBox();
            this.pObjFlag01 = new System.Windows.Forms.CheckBox();
            this.pObjFlag00 = new System.Windows.Forms.CheckBox();
            this.pObjFlags = new System.Windows.Forms.CheckBox();
            this.b = new System.Windows.Forms.TabPage();
            this.pNotify1 = new System.Windows.Forms.CheckBox();
            this.vNotify1 = new System.Windows.Forms.TextBox();
            this.v_PFlag09 = new System.Windows.Forms.CheckBox();
            this.v_PFlag08 = new System.Windows.Forms.CheckBox();
            this.v_PFlag07 = new System.Windows.Forms.CheckBox();
            this.v_PFlag06 = new System.Windows.Forms.CheckBox();
            this.v_PFlag05 = new System.Windows.Forms.CheckBox();
            this.v_PFlag04 = new System.Windows.Forms.CheckBox();
            this.v_PFlag03 = new System.Windows.Forms.CheckBox();
            this.v_PFlag02 = new System.Windows.Forms.CheckBox();
            this.v_PFlag01 = new System.Windows.Forms.CheckBox();
            this.v_PFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OPF = new System.Windows.Forms.CheckBox();
            this.vPKeyID = new System.Windows.Forms.TextBox();
            this.pPKeyID = new System.Windows.Forms.CheckBox();
            this.vPLockDC = new System.Windows.Forms.TextBox();
            this.pPLockDC = new System.Windows.Forms.CheckBox();
            this.c = new System.Windows.Forms.TabPage();
            this.label207 = new System.Windows.Forms.Label();
            this.label178 = new System.Windows.Forms.Label();
            this.v_SDFlag31 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag30 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag29 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag28 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag27 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag26 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag25 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag24 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag23 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag22 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag21 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag20 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag19 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag18 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag17 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag16 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag15 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag14 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag13 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag12 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag11 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag10 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag09 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag08 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag07 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag06 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag05 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag04 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag03 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag02 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag01 = new System.Windows.Forms.CheckBox();
            this.v_SDFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OSDF = new System.Windows.Forms.CheckBox();
            this.vSDDC = new System.Windows.Forms.TextBox();
            this.pSDDC = new System.Windows.Forms.CheckBox();
            this.vEffName = new System.Windows.Forms.TextBox();
            this.pEffName = new System.Windows.Forms.CheckBox();
            this.d = new System.Windows.Forms.TabPage();
            this.v_SFlag12 = new System.Windows.Forms.CheckBox();
            this.v_SFlag11 = new System.Windows.Forms.CheckBox();
            this.v_SFlag10 = new System.Windows.Forms.CheckBox();
            this.v_SFlag09 = new System.Windows.Forms.CheckBox();
            this.v_SFlag08 = new System.Windows.Forms.CheckBox();
            this.v_SFlag07 = new System.Windows.Forms.CheckBox();
            this.v_SFlag06 = new System.Windows.Forms.CheckBox();
            this.v_SFlag05 = new System.Windows.Forms.CheckBox();
            this.v_SFlag04 = new System.Windows.Forms.CheckBox();
            this.v_SFlag03 = new System.Windows.Forms.CheckBox();
            this.v_SFlag02 = new System.Windows.Forms.CheckBox();
            this.v_SFlag01 = new System.Windows.Forms.CheckBox();
            this.v_SFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OSCF = new System.Windows.Forms.CheckBox();
            this.label26 = new System.Windows.Forms.Label();
            this.vTeleport = new System.Windows.Forms.TextBox();
            this.pTeleport = new System.Windows.Forms.CheckBox();
            this.g = new System.Windows.Forms.TabPage();
            this.pGender = new System.Windows.Forms.CheckBox();
            this.vGender = new System.Windows.Forms.TextBox();
            this.pRace = new System.Windows.Forms.CheckBox();
            this.vRace = new System.Windows.Forms.TextBox();
            this.vCleanNpcInv = new System.Windows.Forms.Button();
            this.vNpcInvFill = new System.Windows.Forms.Button();
            this.pLevelup = new System.Windows.Forms.CheckBox();
            this.vLevelup = new System.Windows.Forms.TextBox();
            this.vWayDelay = new System.Windows.Forms.TextBox();
            this.label205 = new System.Windows.Forms.Label();
            this.vWayRot = new System.Windows.Forms.TextBox();
            this.label204 = new System.Windows.Forms.Label();
            this.cRotWpt = new System.Windows.Forms.CheckBox();
            this.cDelayWpt = new System.Windows.Forms.CheckBox();
            this.vWayAnim8 = new System.Windows.Forms.TextBox();
            this.vWayAnim7 = new System.Windows.Forms.TextBox();
            this.vWayAnim6 = new System.Windows.Forms.TextBox();
            this.vWayAnim5 = new System.Windows.Forms.TextBox();
            this.vWayAnim4 = new System.Windows.Forms.TextBox();
            this.vWayAnim3 = new System.Windows.Forms.TextBox();
            this.vWayAnim2 = new System.Windows.Forms.TextBox();
            this.cAnimWpt = new System.Windows.Forms.CheckBox();
            this.vWayAnim1 = new System.Windows.Forms.TextBox();
            this.label146 = new System.Windows.Forms.Label();
            this.vMoneyIdx4 = new System.Windows.Forms.TextBox();
            this.vMoneyIdx3 = new System.Windows.Forms.TextBox();
            this.vMoneyIdx2 = new System.Windows.Forms.TextBox();
            this.vMoneyIdx1 = new System.Windows.Forms.TextBox();
            this.label197 = new System.Windows.Forms.Label();
            this.label196 = new System.Windows.Forms.Label();
            this.label195 = new System.Windows.Forms.Label();
            this.label194 = new System.Windows.Forms.Label();
            this.pMoneyIdx = new System.Windows.Forms.CheckBox();
            this.label193 = new System.Windows.Forms.Label();
            this.label189 = new System.Windows.Forms.Label();
            this.label192 = new System.Windows.Forms.Label();
            this.label191 = new System.Windows.Forms.Label();
            this.vAI64 = new System.Windows.Forms.TextBox();
            this.pAI64 = new System.Windows.Forms.CheckBox();
            this.vTeleY = new System.Windows.Forms.TextBox();
            this.label190 = new System.Windows.Forms.Label();
            this.vTeleX = new System.Windows.Forms.TextBox();
            this.pTeleMap = new System.Windows.Forms.CheckBox();
            this.vTeleMap = new System.Windows.Forms.TextBox();
            this.pTeleDest = new System.Windows.Forms.CheckBox();
            this.vNightFlags = new System.Windows.Forms.TextBox();
            this.label188 = new System.Windows.Forms.Label();
            this.vDayFlags = new System.Windows.Forms.TextBox();
            this.label187 = new System.Windows.Forms.Label();
            this.pFaction = new System.Windows.Forms.CheckBox();
            this.vFaction = new System.Windows.Forms.TextBox();
            this.pReach = new System.Windows.Forms.CheckBox();
            this.vReach = new System.Windows.Forms.TextBox();
            this.btnWayDel = new System.Windows.Forms.Button();
            this.btnWayAdd = new System.Windows.Forms.Button();
            this.vWayY = new System.Windows.Forms.TextBox();
            this.vWayX = new System.Windows.Forms.TextBox();
            this.label180 = new System.Windows.Forms.Label();
            this.label179 = new System.Windows.Forms.Label();
            this.vWaypoints = new System.Windows.Forms.ListBox();
            this.pWaypoints = new System.Windows.Forms.CheckBox();
            this.vNpcInvSlot = new System.Windows.Forms.TextBox();
            this.pNpcInvSlot = new System.Windows.Forms.CheckBox();
            this.tSubInv = new System.Windows.Forms.Label();
            this.vSubInv = new System.Windows.Forms.Button();
            this.pSubInv = new System.Windows.Forms.CheckBox();
            this.vNpcInvenSource = new System.Windows.Forms.TextBox();
            this.pNpcInvenSource = new System.Windows.Forms.CheckBox();
            this.tNpcMoneyAmt = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.btnNpcInvGUID = new System.Windows.Forms.Button();
            this.pNpcInvDel = new System.Windows.Forms.CheckBox();
            this.btnAddNpcInv2 = new System.Windows.Forms.Button();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.btnRemoveNpcInv = new System.Windows.Forms.Button();
            this.btnAddNpcInv = new System.Windows.Forms.Button();
            this.vNpcInv = new System.Windows.Forms.ListBox();
            this.label44 = new System.Windows.Forms.Label();
            this.pNpcInv = new System.Windows.Forms.CheckBox();
            this.NpcInvProtos = new System.Windows.Forms.ComboBox();
            this.d2 = new System.Windows.Forms.TabPage();
            this.label224 = new System.Windows.Forms.Label();
            this.label223 = new System.Windows.Forms.Label();
            this.label222 = new System.Windows.Forms.Label();
            this.label221 = new System.Windows.Forms.Label();
            this.label220 = new System.Windows.Forms.Label();
            this.label219 = new System.Windows.Forms.Label();
            this.vCHA = new System.Windows.Forms.TextBox();
            this.vWIS = new System.Windows.Forms.TextBox();
            this.vINT = new System.Windows.Forms.TextBox();
            this.vCON = new System.Windows.Forms.TextBox();
            this.vDEX = new System.Windows.Forms.TextBox();
            this.vSTR = new System.Windows.Forms.TextBox();
            this.pAbilities = new System.Windows.Forms.CheckBox();
            this.vScoutOfsY = new System.Windows.Forms.TextBox();
            this.vScoutJP = new System.Windows.Forms.TextBox();
            this.vScoutOfsX = new System.Windows.Forms.TextBox();
            this.vScoutMap = new System.Windows.Forms.TextBox();
            this.vScoutY = new System.Windows.Forms.TextBox();
            this.label218 = new System.Windows.Forms.Label();
            this.vScoutX = new System.Windows.Forms.TextBox();
            this.pScoutPoint = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkCleanScripts = new System.Windows.Forms.CheckBox();
            this.btnCleanD20States = new System.Windows.Forms.Button();
            this.label212 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.vNightOfsY = new System.Windows.Forms.TextBox();
            this.vDayOfsY = new System.Windows.Forms.TextBox();
            this.vNightJP = new System.Windows.Forms.TextBox();
            this.vDayJP = new System.Windows.Forms.TextBox();
            this.label211 = new System.Windows.Forms.Label();
            this.vNightOfsX = new System.Windows.Forms.TextBox();
            this.vDayOfsX = new System.Windows.Forms.TextBox();
            this.label208 = new System.Windows.Forms.Label();
            this.label209 = new System.Windows.Forms.Label();
            this.label186 = new System.Windows.Forms.Label();
            this.vNightMap = new System.Windows.Forms.TextBox();
            this.vDayMap = new System.Windows.Forms.TextBox();
            this.label185 = new System.Windows.Forms.Label();
            this.vNightY = new System.Windows.Forms.TextBox();
            this.vDayY = new System.Windows.Forms.TextBox();
            this.label184 = new System.Windows.Forms.Label();
            this.label183 = new System.Windows.Forms.Label();
            this.vNightX = new System.Windows.Forms.TextBox();
            this.vDayX = new System.Windows.Forms.TextBox();
            this.label182 = new System.Windows.Forms.Label();
            this.label181 = new System.Windows.Forms.Label();
            this.pStandpoints = new System.Windows.Forms.CheckBox();
            this.btnDelFaction = new System.Windows.Forms.Button();
            this.btnAddFaction = new System.Windows.Forms.Button();
            this.vFactionsIdx = new System.Windows.Forms.TextBox();
            this.label206 = new System.Windows.Forms.Label();
            this.vFactions = new System.Windows.Forms.ListBox();
            this.pFactions = new System.Windows.Forms.CheckBox();
            this.d1 = new System.Windows.Forms.TabPage();
            this.label217 = new System.Windows.Forms.Label();
            this.vNPCGRate8 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate7 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate6 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate5 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate4 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate3 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate2 = new System.Windows.Forms.RadioButton();
            this.vNPCGRate1 = new System.Windows.Forms.RadioButton();
            this.label216 = new System.Windows.Forms.Label();
            this.vNPCGIgnoreTotal = new System.Windows.Forms.CheckBox();
            this.vNPCGSpawnTotal = new System.Windows.Forms.TextBox();
            this.label215 = new System.Windows.Forms.Label();
            this.vNPCGSpawnConcurrent = new System.Windows.Forms.TextBox();
            this.label214 = new System.Windows.Forms.Label();
            this.vNPCGSpawnAll = new System.Windows.Forms.CheckBox();
            this.vNPCGActive = new System.Windows.Forms.CheckBox();
            this.vNPCGNight = new System.Windows.Forms.CheckBox();
            this.vNPCGDay = new System.Windows.Forms.CheckBox();
            this.label213 = new System.Windows.Forms.Label();
            this.pNPCGenData = new System.Windows.Forms.CheckBox();
            this.vNPCGenData = new System.Windows.Forms.TextBox();
            this.e = new System.Windows.Forms.TabPage();
            this.vCleanChestInv = new System.Windows.Forms.Button();
            this.vChestInvFill = new System.Windows.Forms.Button();
            this.pNotify2 = new System.Windows.Forms.CheckBox();
            this.vNotify2 = new System.Windows.Forms.TextBox();
            this.v_CFlag12 = new System.Windows.Forms.CheckBox();
            this.v_CFlag11 = new System.Windows.Forms.CheckBox();
            this.v_CFlag10 = new System.Windows.Forms.CheckBox();
            this.v_CFlag09 = new System.Windows.Forms.CheckBox();
            this.v_CFlag07 = new System.Windows.Forms.CheckBox();
            this.v_CFlag08 = new System.Windows.Forms.CheckBox();
            this.v_CFlag06 = new System.Windows.Forms.CheckBox();
            this.v_CFlag05 = new System.Windows.Forms.CheckBox();
            this.v_CFlag04 = new System.Windows.Forms.CheckBox();
            this.v_CFlag03 = new System.Windows.Forms.CheckBox();
            this.v_CFlag02 = new System.Windows.Forms.CheckBox();
            this.v_CFlag01 = new System.Windows.Forms.CheckBox();
            this.v_CFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OCOF = new System.Windows.Forms.CheckBox();
            this.vKeyID = new System.Windows.Forms.TextBox();
            this.pKeyID = new System.Windows.Forms.CheckBox();
            this.vChestInvSlot = new System.Windows.Forms.TextBox();
            this.pChestInvSlot = new System.Windows.Forms.CheckBox();
            this.tChestMoneyAmt = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.btnChestInvGUID = new System.Windows.Forms.Button();
            this.pChestInvDel = new System.Windows.Forms.CheckBox();
            this.btnAddChestInv2 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnRemoveChestInv = new System.Windows.Forms.Button();
            this.btnAddChestInv = new System.Windows.Forms.Button();
            this.vChestInv = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.pChestInv = new System.Windows.Forms.CheckBox();
            this.vInvenSource = new System.Windows.Forms.TextBox();
            this.pInvenSource = new System.Windows.Forms.CheckBox();
            this.vLockDC = new System.Windows.Forms.TextBox();
            this.pLockDC = new System.Windows.Forms.CheckBox();
            this.ChestInvProtos = new System.Windows.Forms.ComboBox();
            this.f = new System.Windows.Forms.TabPage();
            this.vMoneyQuantity = new System.Windows.Forms.TextBox();
            this.pMoneyQuantity = new System.Windows.Forms.CheckBox();
            this.h = new System.Windows.Forms.TabPage();
            this.v_NFlag31 = new System.Windows.Forms.CheckBox();
            this.v_NFlag30 = new System.Windows.Forms.CheckBox();
            this.v_NFlag29 = new System.Windows.Forms.CheckBox();
            this.v_NFlag28 = new System.Windows.Forms.CheckBox();
            this.v_NFlag27 = new System.Windows.Forms.CheckBox();
            this.v_NFlag26 = new System.Windows.Forms.CheckBox();
            this.v_NFlag25 = new System.Windows.Forms.CheckBox();
            this.v_NFlag24 = new System.Windows.Forms.CheckBox();
            this.v_NFlag23 = new System.Windows.Forms.CheckBox();
            this.v_NFlag22 = new System.Windows.Forms.CheckBox();
            this.v_NFlag21 = new System.Windows.Forms.CheckBox();
            this.v_NFlag20 = new System.Windows.Forms.CheckBox();
            this.v_NFlag19 = new System.Windows.Forms.CheckBox();
            this.v_NFlag18 = new System.Windows.Forms.CheckBox();
            this.v_NFlag17 = new System.Windows.Forms.CheckBox();
            this.v_NFlag16 = new System.Windows.Forms.CheckBox();
            this.v_NFlag15 = new System.Windows.Forms.CheckBox();
            this.v_NFlag14 = new System.Windows.Forms.CheckBox();
            this.v_NFlag13 = new System.Windows.Forms.CheckBox();
            this.v_NFlag12 = new System.Windows.Forms.CheckBox();
            this.v_NFlag11 = new System.Windows.Forms.CheckBox();
            this.v_NFlag10 = new System.Windows.Forms.CheckBox();
            this.v_NFlag09 = new System.Windows.Forms.CheckBox();
            this.v_NFlag08 = new System.Windows.Forms.CheckBox();
            this.v_NFlag07 = new System.Windows.Forms.CheckBox();
            this.v_NFlag06 = new System.Windows.Forms.CheckBox();
            this.v_NFlag05 = new System.Windows.Forms.CheckBox();
            this.v_NFlag04 = new System.Windows.Forms.CheckBox();
            this.v_NFlag03 = new System.Windows.Forms.CheckBox();
            this.v_NFlag02 = new System.Windows.Forms.CheckBox();
            this.v_NFlag01 = new System.Windows.Forms.CheckBox();
            this.v_NFlag00 = new System.Windows.Forms.CheckBox();
            this.p_ONF = new System.Windows.Forms.CheckBox();
            this.i = new System.Windows.Forms.TabPage();
            this.v_C1Flag31 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag30 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag29 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag28 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag27 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag26 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag25 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag24 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag23 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag22 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag21 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag20 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag19 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag18 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag17 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag16 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag15 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag14 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag13 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag12 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag11 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag10 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag09 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag08 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag07 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag06 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag05 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag04 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag03 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag02 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag01 = new System.Windows.Forms.CheckBox();
            this.v_C1Flag00 = new System.Windows.Forms.CheckBox();
            this.p_OCF = new System.Windows.Forms.CheckBox();
            this.j = new System.Windows.Forms.TabPage();
            this.v_C2Flag27 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag26 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag25 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag24 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag23 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag22 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag21 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag20 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag19 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag18 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag17 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag16 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag15 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag14 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag13 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag12 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag11 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag10 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag09 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag08 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag07 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag06 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag05 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag04 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag03 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag02 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag01 = new System.Windows.Forms.CheckBox();
            this.v_C2Flag00 = new System.Windows.Forms.CheckBox();
            this.p_OCF2 = new System.Windows.Forms.CheckBox();
            this.k = new System.Windows.Forms.TabPage();
            this.pWorth = new System.Windows.Forms.CheckBox();
            this.vWorth = new System.Windows.Forms.TextBox();
            this.pWeight = new System.Windows.Forms.CheckBox();
            this.vWeight = new System.Windows.Forms.TextBox();
            this.pItemAmt = new System.Windows.Forms.CheckBox();
            this.vItemAmt = new System.Windows.Forms.TextBox();
            this.pItmFlag26 = new System.Windows.Forms.CheckBox();
            this.pItmFlag25 = new System.Windows.Forms.CheckBox();
            this.pItmFlag24 = new System.Windows.Forms.CheckBox();
            this.pItmFlag23 = new System.Windows.Forms.CheckBox();
            this.pItmFlag22 = new System.Windows.Forms.CheckBox();
            this.pItmFlag21 = new System.Windows.Forms.CheckBox();
            this.pItmFlag20 = new System.Windows.Forms.CheckBox();
            this.pItmFlag19 = new System.Windows.Forms.CheckBox();
            this.pItmFlag18 = new System.Windows.Forms.CheckBox();
            this.pItmFlag17 = new System.Windows.Forms.CheckBox();
            this.pItmFlag16 = new System.Windows.Forms.CheckBox();
            this.pItmFlag15 = new System.Windows.Forms.CheckBox();
            this.pItmFlag14 = new System.Windows.Forms.CheckBox();
            this.pItmFlag13 = new System.Windows.Forms.CheckBox();
            this.pItmFlag12 = new System.Windows.Forms.CheckBox();
            this.pItmFlag11 = new System.Windows.Forms.CheckBox();
            this.pItmFlag10 = new System.Windows.Forms.CheckBox();
            this.pItmFlag09 = new System.Windows.Forms.CheckBox();
            this.pItmFlag08 = new System.Windows.Forms.CheckBox();
            this.pItmFlag07 = new System.Windows.Forms.CheckBox();
            this.pItmFlag06 = new System.Windows.Forms.CheckBox();
            this.pItmFlag05 = new System.Windows.Forms.CheckBox();
            this.pItmFlag04 = new System.Windows.Forms.CheckBox();
            this.pItmFlag03 = new System.Windows.Forms.CheckBox();
            this.pItmFlag02 = new System.Windows.Forms.CheckBox();
            this.pItmFlag01 = new System.Windows.Forms.CheckBox();
            this.pItmFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OIF = new System.Windows.Forms.CheckBox();
            this.vParent = new System.Windows.Forms.Button();
            this.tParent = new System.Windows.Forms.Label();
            this.pParent = new System.Windows.Forms.CheckBox();
            this.pInvSlot = new System.Windows.Forms.CheckBox();
            this.vInvSlot = new System.Windows.Forms.TextBox();
            this.l = new System.Windows.Forms.TabPage();
            this.vArmorChk = new System.Windows.Forms.TextBox();
            this.pArmorChk = new System.Windows.Forms.CheckBox();
            this.vSpellFail = new System.Windows.Forms.TextBox();
            this.pSpellFail = new System.Windows.Forms.CheckBox();
            this.vACMaxDex = new System.Windows.Forms.TextBox();
            this.pACMaxDex = new System.Windows.Forms.CheckBox();
            this.vACAdj = new System.Windows.Forms.TextBox();
            this.pACAdj = new System.Windows.Forms.CheckBox();
            this.v_OAFlag04 = new System.Windows.Forms.CheckBox();
            this.v_OAFlag03 = new System.Windows.Forms.CheckBox();
            this.v_OAFlag02 = new System.Windows.Forms.CheckBox();
            this.v_OAFlag01 = new System.Windows.Forms.CheckBox();
            this.v_OAFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OARF = new System.Windows.Forms.CheckBox();
            this.m = new System.Windows.Forms.TabPage();
            this.pAmmoAmt = new System.Windows.Forms.CheckBox();
            this.vAmmoAmt = new System.Windows.Forms.TextBox();
            this.v_WFlag12 = new System.Windows.Forms.CheckBox();
            this.v_WFlag11 = new System.Windows.Forms.CheckBox();
            this.v_WFlag10 = new System.Windows.Forms.CheckBox();
            this.v_WFlag09 = new System.Windows.Forms.CheckBox();
            this.v_WFlag08 = new System.Windows.Forms.CheckBox();
            this.v_WFlag07 = new System.Windows.Forms.CheckBox();
            this.v_WFlag06 = new System.Windows.Forms.CheckBox();
            this.v_WFlag05 = new System.Windows.Forms.CheckBox();
            this.v_WFlag04 = new System.Windows.Forms.CheckBox();
            this.v_WFlag03 = new System.Windows.Forms.CheckBox();
            this.v_WFlag02 = new System.Windows.Forms.CheckBox();
            this.v_WFlag01 = new System.Windows.Forms.CheckBox();
            this.v_WFlag00 = new System.Windows.Forms.CheckBox();
            this.p_OWF = new System.Windows.Forms.CheckBox();
            this.n = new System.Windows.Forms.TabPage();
            this.vKeyID2 = new System.Windows.Forms.TextBox();
            this.pKeyID2 = new System.Windows.Forms.CheckBox();
            this.btnChgGUID = new System.Windows.Forms.Button();
            this.vRotation = new System.Windows.Forms.TextBox();
            this.pRotation = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MobType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSaveMob = new System.Windows.Forms.Button();
            this.btnOpenMob = new System.Windows.Forms.Button();
            this.MobileName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Prototype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bb_Sectors = new System.Windows.Forms.TabPage();
            this.tv_X_0 = new System.Windows.Forms.Label();
            this.tv_0_Y = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.btnResetTiles = new System.Windows.Forms.Button();
            this.btnDelObjects = new System.Windows.Forms.Button();
            this.btnDelLights = new System.Windows.Forms.Button();
            this.label88 = new System.Windows.Forms.Label();
            this.tu_0_0 = new System.Windows.Forms.Label();
            this.tu_0_Y = new System.Windows.Forms.Label();
            this.tu_X_Y = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.tu_X_0 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.label93 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.tCurSector = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.btnNewSector = new System.Windows.Forms.Button();
            this.tabSectorEd = new System.Windows.Forms.TabControl();
            this.a_Tiles = new System.Windows.Forms.TabPage();
            this.btnSVBWizard = new System.Windows.Forms.Button();
            this.HGT_UL = new System.Windows.Forms.NumericUpDown();
            this.HGT_UM = new System.Windows.Forms.NumericUpDown();
            this.HGT_UR = new System.Windows.Forms.NumericUpDown();
            this.HGT_ML = new System.Windows.Forms.NumericUpDown();
            this.HGT_MM = new System.Windows.Forms.NumericUpDown();
            this.HGT_MR = new System.Windows.Forms.NumericUpDown();
            this.HGT_LL = new System.Windows.Forms.NumericUpDown();
            this.HGT_LM = new System.Windows.Forms.NumericUpDown();
            this.HGT_LR = new System.Windows.Forms.NumericUpDown();
            this.HSD_UL = new System.Windows.Forms.CheckBox();
            this.HSD_UM = new System.Windows.Forms.CheckBox();
            this.HSD_UR = new System.Windows.Forms.CheckBox();
            this.HSD_ML = new System.Windows.Forms.CheckBox();
            this.HSD_MM = new System.Windows.Forms.CheckBox();
            this.HSD_MR = new System.Windows.Forms.CheckBox();
            this.HSD_LL = new System.Windows.Forms.CheckBox();
            this.HSD_LM = new System.Windows.Forms.CheckBox();
            this.HSD_LR = new System.Windows.Forms.CheckBox();
            this.label116 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.SVB4_UL = new System.Windows.Forms.CheckBox();
            this.SVB4_UM = new System.Windows.Forms.CheckBox();
            this.SVB4_UR = new System.Windows.Forms.CheckBox();
            this.SVB4_ML = new System.Windows.Forms.CheckBox();
            this.SVB4_MM = new System.Windows.Forms.CheckBox();
            this.SVB4_MR = new System.Windows.Forms.CheckBox();
            this.SVB4_LL = new System.Windows.Forms.CheckBox();
            this.SVB4_LM = new System.Windows.Forms.CheckBox();
            this.SVB4_LR = new System.Windows.Forms.CheckBox();
            this.SVB3_UL = new System.Windows.Forms.CheckBox();
            this.SVB3_UM = new System.Windows.Forms.CheckBox();
            this.SVB3_UR = new System.Windows.Forms.CheckBox();
            this.SVB3_ML = new System.Windows.Forms.CheckBox();
            this.SVB3_MM = new System.Windows.Forms.CheckBox();
            this.SVB3_MR = new System.Windows.Forms.CheckBox();
            this.SVB3_LL = new System.Windows.Forms.CheckBox();
            this.SVB3_LM = new System.Windows.Forms.CheckBox();
            this.SVB3_LR = new System.Windows.Forms.CheckBox();
            this.SVB2_UL = new System.Windows.Forms.CheckBox();
            this.SVB2_UM = new System.Windows.Forms.CheckBox();
            this.SVB2_UR = new System.Windows.Forms.CheckBox();
            this.SVB2_ML = new System.Windows.Forms.CheckBox();
            this.SVB2_MM = new System.Windows.Forms.CheckBox();
            this.SVB2_MR = new System.Windows.Forms.CheckBox();
            this.SVB2_LL = new System.Windows.Forms.CheckBox();
            this.SVB2_LM = new System.Windows.Forms.CheckBox();
            this.SVB2_LR = new System.Windows.Forms.CheckBox();
            this.SVB1_UL = new System.Windows.Forms.CheckBox();
            this.SVB1_UM = new System.Windows.Forms.CheckBox();
            this.SVB1_UR = new System.Windows.Forms.CheckBox();
            this.SVB1_ML = new System.Windows.Forms.CheckBox();
            this.SVB1_MM = new System.Windows.Forms.CheckBox();
            this.SVB1_MR = new System.Windows.Forms.CheckBox();
            this.SVB1_LL = new System.Windows.Forms.CheckBox();
            this.SVB1_LM = new System.Windows.Forms.CheckBox();
            this.chkAutoTile = new System.Windows.Forms.CheckBox();
            this.SVB1_LR = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_COVER = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_UL = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_UM = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_UR = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_ML = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_MM = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_MR = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_LL = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_LM = new System.Windows.Forms.CheckBox();
            this.TILE_FLYOVER_LR = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_UL = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_UM = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_UR = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_ML = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_MM = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_MR = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_LL = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_LM = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS_LR = new System.Windows.Forms.CheckBox();
            this.label128 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label125 = new System.Windows.Forms.Label();
            this.label124 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label122 = new System.Windows.Forms.Label();
            this.label121 = new System.Windows.Forms.Label();
            this.label120 = new System.Windows.Forms.Label();
            this.label119 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.TILE_BLOCKS_VISION = new System.Windows.Forms.CheckBox();
            this.TILE_REFLECTIVE = new System.Windows.Forms.CheckBox();
            this.TILE_INDOOR = new System.Windows.Forms.CheckBox();
            this.TILE_SOUNDPROOF = new System.Windows.Forms.CheckBox();
            this.TILE_NATURAL = new System.Windows.Forms.CheckBox();
            this.TILE_ICY = new System.Windows.Forms.CheckBox();
            this.TILE_CAN_FLY_OVER = new System.Windows.Forms.CheckBox();
            this.TILE_SINKS = new System.Windows.Forms.CheckBox();
            this.TILE_BLOCKS = new System.Windows.Forms.CheckBox();
            this.label113 = new System.Windows.Forms.Label();
            this.btnLoadTile = new System.Windows.Forms.Button();
            this.label112 = new System.Windows.Forms.Label();
            this.ToTY = new System.Windows.Forms.NumericUpDown();
            this.ToTX = new System.Windows.Forms.NumericUpDown();
            this.label111 = new System.Windows.Forms.Label();
            this.label110 = new System.Windows.Forms.Label();
            this.label109 = new System.Windows.Forms.Label();
            this.FromTY = new System.Windows.Forms.NumericUpDown();
            this.FromTX = new System.Windows.Forms.NumericUpDown();
            this.label108 = new System.Windows.Forms.Label();
            this.label107 = new System.Windows.Forms.Label();
            this.btnUpdateBoxTiles = new System.Windows.Forms.Button();
            this.label106 = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.btnUpdateAllTiles = new System.Windows.Forms.Button();
            this.btnUpdateTile = new System.Windows.Forms.Button();
            this.cmbTileSound = new System.Windows.Forms.ComboBox();
            this.label104 = new System.Windows.Forms.Label();
            this.TY = new System.Windows.Forms.NumericUpDown();
            this.TX = new System.Windows.Forms.NumericUpDown();
            this.label101 = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.label103 = new System.Windows.Forms.Label();
            this.b_Lights = new System.Windows.Forms.TabPage();
            this.btnLightUpdate = new System.Windows.Forms.Button();
            this.btnDelLight = new System.Windows.Forms.Button();
            this.btnLightAdd = new System.Windows.Forms.Button();
            this.label174 = new System.Windows.Forms.Label();
            this.Light30 = new System.Windows.Forms.TextBox();
            this.label173 = new System.Windows.Forms.Label();
            this.Light29 = new System.Windows.Forms.TextBox();
            this.label172 = new System.Windows.Forms.Label();
            this.Light28 = new System.Windows.Forms.TextBox();
            this.label171 = new System.Windows.Forms.Label();
            this.Light27 = new System.Windows.Forms.TextBox();
            this.label170 = new System.Windows.Forms.Label();
            this.Light26 = new System.Windows.Forms.TextBox();
            this.label169 = new System.Windows.Forms.Label();
            this.Light25 = new System.Windows.Forms.TextBox();
            this.label168 = new System.Windows.Forms.Label();
            this.Light11_Y = new System.Windows.Forms.NumericUpDown();
            this.Light10_X = new System.Windows.Forms.NumericUpDown();
            this.Light24 = new System.Windows.Forms.TextBox();
            this.label167 = new System.Windows.Forms.Label();
            this.Light23 = new System.Windows.Forms.TextBox();
            this.label166 = new System.Windows.Forms.Label();
            this.Light22 = new System.Windows.Forms.TextBox();
            this.label165 = new System.Windows.Forms.Label();
            this.Light21 = new System.Windows.Forms.TextBox();
            this.label164 = new System.Windows.Forms.Label();
            this.Light20 = new System.Windows.Forms.TextBox();
            this.label163 = new System.Windows.Forms.Label();
            this.Light19 = new System.Windows.Forms.TextBox();
            this.label162 = new System.Windows.Forms.Label();
            this.Light18 = new System.Windows.Forms.TextBox();
            this.label161 = new System.Windows.Forms.Label();
            this.Light17 = new System.Windows.Forms.TextBox();
            this.label160 = new System.Windows.Forms.Label();
            this.Light16 = new System.Windows.Forms.TextBox();
            this.label159 = new System.Windows.Forms.Label();
            this.Light15 = new System.Windows.Forms.TextBox();
            this.label158 = new System.Windows.Forms.Label();
            this.Light14 = new System.Windows.Forms.TextBox();
            this.label157 = new System.Windows.Forms.Label();
            this.Light13 = new System.Windows.Forms.TextBox();
            this.label156 = new System.Windows.Forms.Label();
            this.Light12 = new System.Windows.Forms.TextBox();
            this.label155 = new System.Windows.Forms.Label();
            this.Light9 = new System.Windows.Forms.TextBox();
            this.label154 = new System.Windows.Forms.Label();
            this.Light8 = new System.Windows.Forms.TextBox();
            this.label153 = new System.Windows.Forms.Label();
            this.Light6 = new System.Windows.Forms.TextBox();
            this.label152 = new System.Windows.Forms.Label();
            this.Light7 = new System.Windows.Forms.TextBox();
            this.label151 = new System.Windows.Forms.Label();
            this.Light5 = new System.Windows.Forms.TextBox();
            this.label150 = new System.Windows.Forms.Label();
            this.Light4 = new System.Windows.Forms.TextBox();
            this.label149 = new System.Windows.Forms.Label();
            this.Light3 = new System.Windows.Forms.TextBox();
            this.label148 = new System.Windows.Forms.Label();
            this.Light2 = new System.Windows.Forms.TextBox();
            this.label147 = new System.Windows.Forms.Label();
            this.Light1 = new System.Windows.Forms.TextBox();
            this.label126 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label114 = new System.Windows.Forms.Label();
            this.LightID = new System.Windows.Forms.NumericUpDown();
            this.label100 = new System.Windows.Forms.Label();
            this.c_Objects = new System.Windows.Forms.TabPage();
            this.btnXtrObj = new System.Windows.Forms.Button();
            this.btnDelObj = new System.Windows.Forms.Button();
            this.label177 = new System.Windows.Forms.Label();
            this.label176 = new System.Windows.Forms.Label();
            this.SecObjList = new System.Windows.Forms.ListBox();
            this.label81 = new System.Windows.Forms.Label();
            this.btnSaveSec = new System.Windows.Forms.Button();
            this.btnOpenSec = new System.Windows.Forms.Button();
            this.label75 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tv_0_0 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.tv_X_Y = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label99 = new System.Windows.Forms.Label();
            this.cc_SMJumpPts = new System.Windows.Forms.TabPage();
            this.btnUpdatePoint = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.JPMap = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.JPY = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.JPX = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.JPName = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.JPIndex = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.btnDelPoint = new System.Windows.Forms.Button();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.btnSaveJP = new System.Windows.Forms.Button();
            this.btnOpenJP = new System.Windows.Forms.Button();
            this.lstJumpPoints = new System.Windows.Forms.ListBox();
            this.dd_SMapProps = new System.Windows.Forms.TabPage();
            this.GroupAreaCleaner = new System.Windows.Forms.GroupBox();
            this.label145 = new System.Windows.Forms.Label();
            this.btnCleanArea = new System.Windows.Forms.Button();
            this.chkHSD = new System.Windows.Forms.CheckBox();
            this.chkPND = new System.Windows.Forms.CheckBox();
            this.chkGMESH = new System.Windows.Forms.CheckBox();
            this.chkCLIPPING = new System.Windows.Forms.CheckBox();
            this.chkSECSVB = new System.Windows.Forms.CheckBox();
            this.chkMOB = new System.Windows.Forms.CheckBox();
            this.label144 = new System.Windows.Forms.Label();
            this.GlobalLitGroup = new System.Windows.Forms.GroupBox();
            this.btnNewGLT = new System.Windows.Forms.Button();
            this.tGLT2 = new System.Windows.Forms.ComboBox();
            this.tGLT8 = new System.Windows.Forms.TextBox();
            this.label143 = new System.Windows.Forms.Label();
            this.tGLT7 = new System.Windows.Forms.TextBox();
            this.label142 = new System.Windows.Forms.Label();
            this.tGLT6 = new System.Windows.Forms.TextBox();
            this.label141 = new System.Windows.Forms.Label();
            this.tGLTEndAngle = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.tGLTStartAngle = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.tGLT5 = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.tGLT4 = new System.Windows.Forms.TextBox();
            this.label137 = new System.Windows.Forms.Label();
            this.tGLT3 = new System.Windows.Forms.TextBox();
            this.label136 = new System.Windows.Forms.Label();
            this.tGLTBlue = new System.Windows.Forms.TextBox();
            this.label135 = new System.Windows.Forms.Label();
            this.tGLTGreen = new System.Windows.Forms.TextBox();
            this.label134 = new System.Windows.Forms.Label();
            this.tGLTRed = new System.Windows.Forms.TextBox();
            this.label133 = new System.Windows.Forms.Label();
            this.label132 = new System.Windows.Forms.Label();
            this.tGLT1 = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.btnSaveGLT = new System.Windows.Forms.Button();
            this.btnOpenGLT = new System.Windows.Forms.Button();
            this.MapPrpGroup = new System.Windows.Forms.GroupBox();
            this.tMapHeight = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.tMapWidth = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.tArtEntry = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.btnSaveProps = new System.Windows.Forms.Button();
            this.btnOpenProps = new System.Windows.Forms.Button();
            this.label130 = new System.Windows.Forms.Label();
            this.ee_N2DMaps = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.recomb_partial = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.SY = new System.Windows.Forms.TextBox();
            this.SX = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.PY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.PX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.splitData = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.fdata = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ff_YT_Prototypes = new System.Windows.Forms.TabPage();
            this.btnDblClickClean = new System.Windows.Forms.CheckBox();
            this.btnIPReplace = new System.Windows.Forms.Button();
            this.btnGoToDesc = new System.Windows.Forms.Button();
            this.btnSaveProtos = new System.Windows.Forms.Button();
            this.btnDelProto = new System.Windows.Forms.Button();
            this.btnAddProto = new System.Windows.Forms.Button();
            this.tProtoID = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.btnIPInsert = new System.Windows.Forms.Button();
            this.btnUpdateProto = new System.Windows.Forms.Button();
            this.IntelliProp = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.tPropValue = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.CurProto = new System.Windows.Forms.ComboBox();
            this.label71 = new System.Windows.Forms.Label();
            this.lstProtoProps = new System.Windows.Forms.ListBox();
            this.gg_YX_Descriptions = new System.Windows.Forms.TabPage();
            this.btnAddDesc = new System.Windows.Forms.Button();
            this.btnRemoveDesc = new System.Windows.Forms.Button();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.btnLookUpProto = new System.Windows.Forms.Button();
            this.btnSaveDesc = new System.Windows.Forms.Button();
            this.btnSetDescs = new System.Windows.Forms.Button();
            this.tLongDescript = new System.Windows.Forms.TextBox();
            this.label80 = new System.Windows.Forms.Label();
            this.tDescript = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.tDescID = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.lstDesc = new System.Windows.Forms.ListBox();
            this.h_YScripts = new System.Windows.Forms.TabPage();
            this.btnLoadScripts = new System.Windows.Forms.Button();
            this.btnEditScript = new System.Windows.Forms.Button();
            this.btnDelScript = new System.Windows.Forms.Button();
            this.lstScripts = new System.Windows.Forms.ListBox();
            this.i_YDialogs = new System.Windows.Forms.TabPage();
            this.btnLoadDialogs = new System.Windows.Forms.Button();
            this.btnEditDialog = new System.Windows.Forms.Button();
            this.btnDelDialog = new System.Windows.Forms.Button();
            this.lstDialogs = new System.Windows.Forms.ListBox();
            this.j_YY_Worldmap = new System.Windows.Forms.TabPage();
            this.btnUpdatePath = new System.Windows.Forms.Button();
            this.btnSetOpcode = new System.Windows.Forms.Button();
            this.btnDeleteOpcode = new System.Windows.Forms.Button();
            this.btnInsertOpcode = new System.Windows.Forms.Button();
            this.tPathElem = new System.Windows.Forms.Label();
            this.label203 = new System.Windows.Forms.Label();
            this.w_PathCodes = new System.Windows.Forms.ListBox();
            this.label202 = new System.Windows.Forms.Label();
            this.w_Opcodes = new System.Windows.Forms.ComboBox();
            this.label201 = new System.Windows.Forms.Label();
            this.label200 = new System.Windows.Forms.Label();
            this.tPar4 = new System.Windows.Forms.TextBox();
            this.tPar3 = new System.Windows.Forms.TextBox();
            this.tPar2 = new System.Windows.Forms.TextBox();
            this.wPar4 = new System.Windows.Forms.Label();
            this.wPar3 = new System.Windows.Forms.Label();
            this.wPar2 = new System.Windows.Forms.Label();
            this.tPar1 = new System.Windows.Forms.TextBox();
            this.wPar1 = new System.Windows.Forms.Label();
            this.label199 = new System.Windows.Forms.Label();
            this.btnDelPath = new System.Windows.Forms.Button();
            this.btnAddPath = new System.Windows.Forms.Button();
            this.btnSaveWorldMap = new System.Windows.Forms.Button();
            this.btnOpenWorldMap = new System.Windows.Forms.Button();
            this.label198 = new System.Windows.Forms.Label();
            this.w_Paths = new System.Windows.Forms.ListBox();
            this.label77 = new System.Windows.Forms.Label();
            this.k_YY_DLLEd = new System.Windows.Forms.TabPage();
            this.chkEnableDebug = new System.Windows.Forms.CheckBox();
            this.label70 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.ChaoticEvil = new System.Windows.Forms.TextBox();
            this.ChaoticNeutral = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.ChaoticGood = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.NeutralEvil = new System.Windows.Forms.TextBox();
            this.TrueNeutral = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.NeutralGood = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.LawfulEvil = new System.Windows.Forms.TextBox();
            this.LawfulNeutral = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.LawfulGood = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.PCCount = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.btnSaveDLL = new System.Windows.Forms.Button();
            this.btnLoadDLL = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.l_ZZConfig = new System.Windows.Forms.TabPage();
            this.label226 = new System.Windows.Forms.Label();
            this.tWBBridge = new System.Windows.Forms.TextBox();
            this.label225 = new System.Windows.Forms.Label();
            this.chkObjIDGen = new System.Windows.Forms.CheckBox();
            this.cfgDelEmpty = new System.Windows.Forms.CheckBox();
            this.btnBrowse4 = new System.Windows.Forms.Button();
            this.tScripts = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.btnBrowse3 = new System.Windows.Forms.Button();
            this.tDialogs = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.btnSaveCfg = new System.Windows.Forms.Button();
            this.btnBrowse2 = new System.Windows.Forms.Button();
            this.tScriptEd = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.tDialogEd = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.mnuAddins = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.OFG1 = new System.Windows.Forms.OpenFileDialog();
            this.OFG = new System.Windows.Forms.OpenFileDialog();
            this.tmrSplash = new System.Windows.Forms.Timer(this.components);
            this.cfgBrowser = new System.Windows.Forms.OpenFileDialog();
            this.cfgDialogs = new System.Windows.Forms.OpenFileDialog();
            this.cfgScripts = new System.Windows.Forms.OpenFileDialog();
            this.MultiODLG = new System.Windows.Forms.OpenFileDialog();
            this.WM_SysMsg = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorLightEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorCoordinateLookupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualSectorAnalyzerPainterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.dayNightTransitionsEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathNodeGeneratorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.prototypeSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mobileObjectViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectorSortUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptOverrideToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.whatAreTheseAddinsForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialInventorySlotsForMobilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingMerchantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyingRestingOptionsForMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.commonWaypointAnimationIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.GenericTab.SuspendLayout();
            this.aa_Mobiles.SuspendLayout();
            this.ObjSpeedGroup.SuspendLayout();
            this.ObjHPGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocationX)).BeginInit();
            this.tabProps.SuspendLayout();
            this.a.SuspendLayout();
            this.b.SuspendLayout();
            this.c.SuspendLayout();
            this.d.SuspendLayout();
            this.g.SuspendLayout();
            this.d2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.d1.SuspendLayout();
            this.e.SuspendLayout();
            this.f.SuspendLayout();
            this.h.SuspendLayout();
            this.i.SuspendLayout();
            this.j.SuspendLayout();
            this.k.SuspendLayout();
            this.l.SuspendLayout();
            this.m.SuspendLayout();
            this.n.SuspendLayout();
            this.bb_Sectors.SuspendLayout();
            this.tabSectorEd.SuspendLayout();
            this.a_Tiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_ML)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_MM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_MR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToTX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TX)).BeginInit();
            this.b_Lights.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Light11_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light10_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightID)).BeginInit();
            this.c_Objects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cc_SMJumpPts.SuspendLayout();
            this.dd_SMapProps.SuspendLayout();
            this.GroupAreaCleaner.SuspendLayout();
            this.GlobalLitGroup.SuspendLayout();
            this.MapPrpGroup.SuspendLayout();
            this.ee_N2DMaps.SuspendLayout();
            this.ff_YT_Prototypes.SuspendLayout();
            this.gg_YX_Descriptions.SuspendLayout();
            this.h_YScripts.SuspendLayout();
            this.i_YDialogs.SuspendLayout();
            this.j_YY_Worldmap.SuspendLayout();
            this.k_YY_DLLEd.SuspendLayout();
            this.l_ZZConfig.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenericTab
            // 
            this.GenericTab.Controls.Add(this.aa_Mobiles);
            this.GenericTab.Controls.Add(this.bb_Sectors);
            this.GenericTab.Controls.Add(this.cc_SMJumpPts);
            this.GenericTab.Controls.Add(this.dd_SMapProps);
            this.GenericTab.Controls.Add(this.ee_N2DMaps);
            this.GenericTab.Controls.Add(this.ff_YT_Prototypes);
            this.GenericTab.Controls.Add(this.gg_YX_Descriptions);
            this.GenericTab.Controls.Add(this.h_YScripts);
            this.GenericTab.Controls.Add(this.i_YDialogs);
            this.GenericTab.Controls.Add(this.j_YY_Worldmap);
            this.GenericTab.Controls.Add(this.k_YY_DLLEd);
            this.GenericTab.Controls.Add(this.l_ZZConfig);
            this.GenericTab.Location = new System.Drawing.Point(0, 27);
            this.GenericTab.Name = "GenericTab";
            this.GenericTab.SelectedIndex = 0;
            this.GenericTab.Size = new System.Drawing.Size(816, 632);
            this.GenericTab.TabIndex = 1;
            // 
            // aa_Mobiles
            // 
            this.aa_Mobiles.Controls.Add(this.vObjName);
            this.aa_Mobiles.Controls.Add(this.pObjName);
            this.aa_Mobiles.Controls.Add(this.label175);
            this.aa_Mobiles.Controls.Add(this.vTransparency);
            this.aa_Mobiles.Controls.Add(this.pTransparency);
            this.aa_Mobiles.Controls.Add(this.label131);
            this.aa_Mobiles.Controls.Add(this.ObjSpeedGroup);
            this.aa_Mobiles.Controls.Add(this.ObjHPGroup);
            this.aa_Mobiles.Controls.Add(this.label127);
            this.aa_Mobiles.Controls.Add(this.vOfsZ);
            this.aa_Mobiles.Controls.Add(this.pOfsZ);
            this.aa_Mobiles.Controls.Add(this.label117);
            this.aa_Mobiles.Controls.Add(this.vModelScale);
            this.aa_Mobiles.Controls.Add(this.pModelScale);
            this.aa_Mobiles.Controls.Add(this.LocationY);
            this.aa_Mobiles.Controls.Add(this.LocationX);
            this.aa_Mobiles.Controls.Add(this.pDispatcher);
            this.aa_Mobiles.Controls.Add(this.label38);
            this.aa_Mobiles.Controls.Add(this.label37);
            this.aa_Mobiles.Controls.Add(this.label36);
            this.aa_Mobiles.Controls.Add(this.label35);
            this.aa_Mobiles.Controls.Add(this.btnEmbed);
            this.aa_Mobiles.Controls.Add(this.vHeight);
            this.aa_Mobiles.Controls.Add(this.pHeight);
            this.aa_Mobiles.Controls.Add(this.vRadius);
            this.aa_Mobiles.Controls.Add(this.pRadius);
            this.aa_Mobiles.Controls.Add(this.vOffsetY);
            this.aa_Mobiles.Controls.Add(this.vOffsetX);
            this.aa_Mobiles.Controls.Add(this.pOffsetY);
            this.aa_Mobiles.Controls.Add(this.pOffsetX);
            this.aa_Mobiles.Controls.Add(this.tabProps);
            this.aa_Mobiles.Controls.Add(this.btnChgGUID);
            this.aa_Mobiles.Controls.Add(this.vRotation);
            this.aa_Mobiles.Controls.Add(this.pRotation);
            this.aa_Mobiles.Controls.Add(this.label6);
            this.aa_Mobiles.Controls.Add(this.label5);
            this.aa_Mobiles.Controls.Add(this.label4);
            this.aa_Mobiles.Controls.Add(this.MobType);
            this.aa_Mobiles.Controls.Add(this.label3);
            this.aa_Mobiles.Controls.Add(this.btnNew);
            this.aa_Mobiles.Controls.Add(this.btnSaveMob);
            this.aa_Mobiles.Controls.Add(this.btnOpenMob);
            this.aa_Mobiles.Controls.Add(this.MobileName);
            this.aa_Mobiles.Controls.Add(this.label2);
            this.aa_Mobiles.Controls.Add(this.Prototype);
            this.aa_Mobiles.Controls.Add(this.label1);
            this.aa_Mobiles.Location = new System.Drawing.Point(4, 22);
            this.aa_Mobiles.Name = "aa_Mobiles";
            this.aa_Mobiles.Size = new System.Drawing.Size(808, 606);
            this.aa_Mobiles.TabIndex = 0;
            this.aa_Mobiles.Text = "Objects";
            // 
            // vObjName
            // 
            this.vObjName.Enabled = false;
            this.vObjName.Location = new System.Drawing.Point(128, 328);
            this.vObjName.Name = "vObjName";
            this.vObjName.Size = new System.Drawing.Size(80, 20);
            this.vObjName.TabIndex = 48;
            this.vObjName.Text = "0";
            // 
            // pObjName
            // 
            this.pObjName.Location = new System.Drawing.Point(8, 328);
            this.pObjName.Name = "pObjName";
            this.pObjName.Size = new System.Drawing.Size(112, 24);
            this.pObjName.TabIndex = 47;
            this.pObjName.Text = "Object Name:";
            this.pObjName.CheckedChanged += new System.EventHandler(this.pObjName_CheckedChanged);
            // 
            // label175
            // 
            this.label175.Location = new System.Drawing.Point(160, 302);
            this.label175.Name = "label175";
            this.label175.Size = new System.Drawing.Size(176, 28);
            this.label175.TabIndex = 46;
            this.label175.Text = "(0-255, 128 = 50% transparency), works only for certain models";
            // 
            // vTransparency
            // 
            this.vTransparency.Enabled = false;
            this.vTransparency.Location = new System.Drawing.Point(128, 305);
            this.vTransparency.Name = "vTransparency";
            this.vTransparency.Size = new System.Drawing.Size(32, 20);
            this.vTransparency.TabIndex = 45;
            this.vTransparency.Text = "255";
            // 
            // pTransparency
            // 
            this.pTransparency.Location = new System.Drawing.Point(8, 304);
            this.pTransparency.Name = "pTransparency";
            this.pTransparency.Size = new System.Drawing.Size(112, 24);
            this.pTransparency.TabIndex = 44;
            this.pTransparency.Text = "Transparency:";
            this.pTransparency.CheckedChanged += new System.EventHandler(this.pTransparency_CheckedChanged);
            // 
            // label131
            // 
            this.label131.Location = new System.Drawing.Point(240, 258);
            this.label131.Name = "label131";
            this.label131.Size = new System.Drawing.Size(96, 24);
            this.label131.TabIndex = 43;
            this.label131.Text = "(float. point value)";
            // 
            // ObjSpeedGroup
            // 
            this.ObjSpeedGroup.Controls.Add(this.label129);
            this.ObjSpeedGroup.Controls.Add(this.vSpdRun);
            this.ObjSpeedGroup.Controls.Add(this.pSpdRun);
            this.ObjSpeedGroup.Controls.Add(this.vSpdWalk);
            this.ObjSpeedGroup.Controls.Add(this.pSpdWalk);
            this.ObjSpeedGroup.Location = new System.Drawing.Point(8, 488);
            this.ObjSpeedGroup.Name = "ObjSpeedGroup";
            this.ObjSpeedGroup.Size = new System.Drawing.Size(320, 104);
            this.ObjSpeedGroup.TabIndex = 42;
            this.ObjSpeedGroup.TabStop = false;
            this.ObjSpeedGroup.Text = "Object Speed";
            // 
            // label129
            // 
            this.label129.Location = new System.Drawing.Point(16, 70);
            this.label129.Name = "label129";
            this.label129.Size = new System.Drawing.Size(296, 30);
            this.label129.TabIndex = 32;
            this.label129.Text = "Object speed is a floating point value. 0 = 0%, 0.5 = 50%, 1 = 100%, 2 = 200%, et" +
                "c.";
            // 
            // vSpdRun
            // 
            this.vSpdRun.Enabled = false;
            this.vSpdRun.Location = new System.Drawing.Point(104, 44);
            this.vSpdRun.Name = "vSpdRun";
            this.vSpdRun.Size = new System.Drawing.Size(80, 20);
            this.vSpdRun.TabIndex = 3;
            this.vSpdRun.Text = "1";
            // 
            // pSpdRun
            // 
            this.pSpdRun.Location = new System.Drawing.Point(8, 40);
            this.pSpdRun.Name = "pSpdRun";
            this.pSpdRun.Size = new System.Drawing.Size(96, 24);
            this.pSpdRun.TabIndex = 2;
            this.pSpdRun.Text = "Speed (Run):";
            this.pSpdRun.CheckedChanged += new System.EventHandler(this.pSpdRun_CheckedChanged);
            // 
            // vSpdWalk
            // 
            this.vSpdWalk.Enabled = false;
            this.vSpdWalk.Location = new System.Drawing.Point(104, 18);
            this.vSpdWalk.Name = "vSpdWalk";
            this.vSpdWalk.Size = new System.Drawing.Size(80, 20);
            this.vSpdWalk.TabIndex = 1;
            this.vSpdWalk.Text = "1";
            // 
            // pSpdWalk
            // 
            this.pSpdWalk.Location = new System.Drawing.Point(8, 16);
            this.pSpdWalk.Name = "pSpdWalk";
            this.pSpdWalk.Size = new System.Drawing.Size(112, 24);
            this.pSpdWalk.TabIndex = 0;
            this.pSpdWalk.Text = "Speed (Walk):";
            this.pSpdWalk.CheckedChanged += new System.EventHandler(this.pSpdWalk_CheckedChanged);
            // 
            // ObjHPGroup
            // 
            this.ObjHPGroup.Controls.Add(this.vHPDmg);
            this.ObjHPGroup.Controls.Add(this.pHPDmg);
            this.ObjHPGroup.Controls.Add(this.vHPAdj);
            this.ObjHPGroup.Controls.Add(this.pHPAdj);
            this.ObjHPGroup.Controls.Add(this.vHP);
            this.ObjHPGroup.Controls.Add(this.pHP);
            this.ObjHPGroup.Location = new System.Drawing.Point(8, 384);
            this.ObjHPGroup.Name = "ObjHPGroup";
            this.ObjHPGroup.Size = new System.Drawing.Size(320, 96);
            this.ObjHPGroup.TabIndex = 41;
            this.ObjHPGroup.TabStop = false;
            this.ObjHPGroup.Text = "Object Hit Points";
            // 
            // vHPDmg
            // 
            this.vHPDmg.Enabled = false;
            this.vHPDmg.Location = new System.Drawing.Point(88, 66);
            this.vHPDmg.Name = "vHPDmg";
            this.vHPDmg.Size = new System.Drawing.Size(80, 20);
            this.vHPDmg.TabIndex = 5;
            this.vHPDmg.Text = "0";
            // 
            // pHPDmg
            // 
            this.pHPDmg.Location = new System.Drawing.Point(8, 64);
            this.pHPDmg.Name = "pHPDmg";
            this.pHPDmg.Size = new System.Drawing.Size(88, 24);
            this.pHPDmg.TabIndex = 4;
            this.pHPDmg.Text = "HP Damage:";
            this.pHPDmg.CheckedChanged += new System.EventHandler(this.pHPDmg_CheckedChanged);
            // 
            // vHPAdj
            // 
            this.vHPAdj.Enabled = false;
            this.vHPAdj.Location = new System.Drawing.Point(88, 42);
            this.vHPAdj.Name = "vHPAdj";
            this.vHPAdj.Size = new System.Drawing.Size(80, 20);
            this.vHPAdj.TabIndex = 3;
            this.vHPAdj.Text = "0";
            // 
            // pHPAdj
            // 
            this.pHPAdj.Location = new System.Drawing.Point(8, 40);
            this.pHPAdj.Name = "pHPAdj";
            this.pHPAdj.Size = new System.Drawing.Size(88, 24);
            this.pHPAdj.TabIndex = 2;
            this.pHPAdj.Text = "HP Adj:";
            this.pHPAdj.CheckedChanged += new System.EventHandler(this.pHPAdj_CheckedChanged);
            // 
            // vHP
            // 
            this.vHP.Enabled = false;
            this.vHP.Location = new System.Drawing.Point(88, 18);
            this.vHP.Name = "vHP";
            this.vHP.Size = new System.Drawing.Size(80, 20);
            this.vHP.TabIndex = 1;
            this.vHP.Text = "50";
            // 
            // pHP
            // 
            this.pHP.Location = new System.Drawing.Point(8, 16);
            this.pHP.Name = "pHP";
            this.pHP.Size = new System.Drawing.Size(88, 24);
            this.pHP.TabIndex = 0;
            this.pHP.Text = "Hit Points:";
            this.pHP.CheckedChanged += new System.EventHandler(this.pHP_CheckedChanged);
            // 
            // label127
            // 
            this.label127.Location = new System.Drawing.Point(192, 214);
            this.label127.Name = "label127";
            this.label127.Size = new System.Drawing.Size(136, 16);
            this.label127.TabIndex = 40;
            this.label127.Text = "(floating point value)";
            // 
            // vOfsZ
            // 
            this.vOfsZ.Enabled = false;
            this.vOfsZ.Location = new System.Drawing.Point(80, 208);
            this.vOfsZ.Name = "vOfsZ";
            this.vOfsZ.Size = new System.Drawing.Size(112, 20);
            this.vOfsZ.TabIndex = 39;
            this.vOfsZ.Text = "0";
            // 
            // pOfsZ
            // 
            this.pOfsZ.Location = new System.Drawing.Point(8, 208);
            this.pOfsZ.Name = "pOfsZ";
            this.pOfsZ.Size = new System.Drawing.Size(80, 24);
            this.pOfsZ.TabIndex = 38;
            this.pOfsZ.Text = "Offset Z:";
            this.pOfsZ.CheckedChanged += new System.EventHandler(this.pOfsZ_CheckedChanged);
            // 
            // label117
            // 
            this.label117.Location = new System.Drawing.Point(176, 284);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(80, 16);
            this.label117.TabIndex = 37;
            this.label117.Text = "%";
            // 
            // vModelScale
            // 
            this.vModelScale.Enabled = false;
            this.vModelScale.Location = new System.Drawing.Point(128, 280);
            this.vModelScale.Name = "vModelScale";
            this.vModelScale.Size = new System.Drawing.Size(48, 20);
            this.vModelScale.TabIndex = 36;
            this.vModelScale.Text = "100";
            // 
            // pModelScale
            // 
            this.pModelScale.Location = new System.Drawing.Point(8, 280);
            this.pModelScale.Name = "pModelScale";
            this.pModelScale.Size = new System.Drawing.Size(112, 24);
            this.pModelScale.TabIndex = 35;
            this.pModelScale.Text = "3D Model Scale:";
            this.pModelScale.CheckedChanged += new System.EventHandler(this.pModelScale_CheckedChanged);
            // 
            // LocationY
            // 
            this.LocationY.Location = new System.Drawing.Point(184, 104);
            this.LocationY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LocationY.Name = "LocationY";
            this.LocationY.Size = new System.Drawing.Size(48, 20);
            this.LocationY.TabIndex = 34;
            // 
            // LocationX
            // 
            this.LocationX.Location = new System.Drawing.Point(104, 104);
            this.LocationX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.LocationX.Name = "LocationX";
            this.LocationX.Size = new System.Drawing.Size(48, 20);
            this.LocationX.TabIndex = 33;
            // 
            // pDispatcher
            // 
            this.pDispatcher.Location = new System.Drawing.Point(8, 352);
            this.pDispatcher.Name = "pDispatcher";
            this.pDispatcher.Size = new System.Drawing.Size(136, 24);
            this.pDispatcher.TabIndex = 32;
            this.pDispatcher.Text = "Dispatcher (true/false)";
            this.pDispatcher.CheckedChanged += new System.EventHandler(this.pDispatcher_CheckedChanged);
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(192, 238);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(136, 16);
            this.label38.TabIndex = 30;
            this.label38.Text = "(floating point value)";
            // 
            // label37
            // 
            this.label37.Location = new System.Drawing.Point(192, 190);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(136, 16);
            this.label37.TabIndex = 29;
            this.label37.Text = "(floating point value)";
            // 
            // label36
            // 
            this.label36.Location = new System.Drawing.Point(192, 166);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(136, 16);
            this.label36.TabIndex = 28;
            this.label36.Text = "(floating point value)";
            // 
            // label35
            // 
            this.label35.Location = new System.Drawing.Point(192, 142);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(136, 16);
            this.label35.TabIndex = 27;
            this.label35.Text = "(floating point value)";
            // 
            // btnEmbed
            // 
            this.btnEmbed.Location = new System.Drawing.Point(728, 7);
            this.btnEmbed.Name = "btnEmbed";
            this.btnEmbed.Size = new System.Drawing.Size(67, 24);
            this.btnEmbed.TabIndex = 26;
            this.btnEmbed.Text = "Embed";
            this.btnEmbed.Click += new System.EventHandler(this.btnEmbed_Click);
            // 
            // vHeight
            // 
            this.vHeight.Enabled = false;
            this.vHeight.Location = new System.Drawing.Point(128, 256);
            this.vHeight.Name = "vHeight";
            this.vHeight.Size = new System.Drawing.Size(112, 20);
            this.vHeight.TabIndex = 25;
            this.vHeight.Text = "0";
            // 
            // pHeight
            // 
            this.pHeight.Location = new System.Drawing.Point(8, 256);
            this.pHeight.Name = "pHeight";
            this.pHeight.Size = new System.Drawing.Size(120, 24);
            this.pHeight.TabIndex = 24;
            this.pHeight.Text = "3D Render Height:";
            this.pHeight.CheckedChanged += new System.EventHandler(this.pHeight_CheckedChanged);
            // 
            // vRadius
            // 
            this.vRadius.Enabled = false;
            this.vRadius.Location = new System.Drawing.Point(80, 232);
            this.vRadius.Name = "vRadius";
            this.vRadius.Size = new System.Drawing.Size(112, 20);
            this.vRadius.TabIndex = 23;
            this.vRadius.Text = "0";
            // 
            // pRadius
            // 
            this.pRadius.Location = new System.Drawing.Point(8, 232);
            this.pRadius.Name = "pRadius";
            this.pRadius.Size = new System.Drawing.Size(80, 24);
            this.pRadius.TabIndex = 22;
            this.pRadius.Text = "Radius:";
            this.pRadius.CheckedChanged += new System.EventHandler(this.pRadius_CheckedChanged);
            // 
            // vOffsetY
            // 
            this.vOffsetY.Enabled = false;
            this.vOffsetY.Location = new System.Drawing.Point(80, 186);
            this.vOffsetY.Name = "vOffsetY";
            this.vOffsetY.Size = new System.Drawing.Size(112, 20);
            this.vOffsetY.TabIndex = 21;
            this.vOffsetY.Text = "0";
            // 
            // vOffsetX
            // 
            this.vOffsetX.Enabled = false;
            this.vOffsetX.Location = new System.Drawing.Point(80, 162);
            this.vOffsetX.Name = "vOffsetX";
            this.vOffsetX.Size = new System.Drawing.Size(112, 20);
            this.vOffsetX.TabIndex = 20;
            this.vOffsetX.Text = "0";
            // 
            // pOffsetY
            // 
            this.pOffsetY.Location = new System.Drawing.Point(8, 184);
            this.pOffsetY.Name = "pOffsetY";
            this.pOffsetY.Size = new System.Drawing.Size(80, 24);
            this.pOffsetY.TabIndex = 19;
            this.pOffsetY.Text = "Offset Y:";
            this.pOffsetY.CheckedChanged += new System.EventHandler(this.pOffsetY_CheckedChanged);
            // 
            // pOffsetX
            // 
            this.pOffsetX.Location = new System.Drawing.Point(8, 160);
            this.pOffsetX.Name = "pOffsetX";
            this.pOffsetX.Size = new System.Drawing.Size(80, 24);
            this.pOffsetX.TabIndex = 18;
            this.pOffsetX.Text = "Offset X:";
            this.pOffsetX.CheckedChanged += new System.EventHandler(this.pOffsetX_CheckedChanged);
            // 
            // tabProps
            // 
            this.tabProps.Controls.Add(this.a);
            this.tabProps.Controls.Add(this.b);
            this.tabProps.Controls.Add(this.c);
            this.tabProps.Controls.Add(this.d);
            this.tabProps.Controls.Add(this.g);
            this.tabProps.Controls.Add(this.d2);
            this.tabProps.Controls.Add(this.d1);
            this.tabProps.Controls.Add(this.e);
            this.tabProps.Controls.Add(this.f);
            this.tabProps.Controls.Add(this.h);
            this.tabProps.Controls.Add(this.i);
            this.tabProps.Controls.Add(this.j);
            this.tabProps.Controls.Add(this.k);
            this.tabProps.Controls.Add(this.l);
            this.tabProps.Controls.Add(this.m);
            this.tabProps.Controls.Add(this.n);
            this.tabProps.Location = new System.Drawing.Point(336, 40);
            this.tabProps.Name = "tabProps";
            this.tabProps.SelectedIndex = 0;
            this.tabProps.Size = new System.Drawing.Size(464, 560);
            this.tabProps.TabIndex = 17;
            // 
            // a
            // 
            this.a.BackColor = System.Drawing.SystemColors.Control;
            this.a.Controls.Add(this.pObjFlag31);
            this.a.Controls.Add(this.pObjFlag30);
            this.a.Controls.Add(this.pObjFlag29);
            this.a.Controls.Add(this.pObjFlag28);
            this.a.Controls.Add(this.pObjFlag27);
            this.a.Controls.Add(this.pObjFlag26);
            this.a.Controls.Add(this.pObjFlag25);
            this.a.Controls.Add(this.pObjFlag24);
            this.a.Controls.Add(this.pObjFlag23);
            this.a.Controls.Add(this.pObjFlag22);
            this.a.Controls.Add(this.pObjFlag21);
            this.a.Controls.Add(this.pObjFlag20);
            this.a.Controls.Add(this.pObjFlag19);
            this.a.Controls.Add(this.pObjFlag18);
            this.a.Controls.Add(this.pObjFlag17);
            this.a.Controls.Add(this.pObjFlag16);
            this.a.Controls.Add(this.pObjFlag15);
            this.a.Controls.Add(this.pObjFlag14);
            this.a.Controls.Add(this.pObjFlag13);
            this.a.Controls.Add(this.pObjFlag12);
            this.a.Controls.Add(this.pObjFlag11);
            this.a.Controls.Add(this.pObjFlag10);
            this.a.Controls.Add(this.pObjFlag09);
            this.a.Controls.Add(this.pObjFlag08);
            this.a.Controls.Add(this.pObjFlag07);
            this.a.Controls.Add(this.pObjFlag06);
            this.a.Controls.Add(this.pObjFlag05);
            this.a.Controls.Add(this.pObjFlag04);
            this.a.Controls.Add(this.pObjFlag03);
            this.a.Controls.Add(this.pObjFlag02);
            this.a.Controls.Add(this.pObjFlag01);
            this.a.Controls.Add(this.pObjFlag00);
            this.a.Controls.Add(this.pObjFlags);
            this.a.Location = new System.Drawing.Point(4, 22);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(456, 534);
            this.a.TabIndex = 2;
            this.a.Text = "Object";
            // 
            // pObjFlag31
            // 
            this.pObjFlag31.Location = new System.Drawing.Point(96, 512);
            this.pObjFlag31.Name = "pObjFlag31";
            this.pObjFlag31.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag31.TabIndex = 50;
            this.pObjFlag31.Text = "OF_RADIUS_SET";
            // 
            // pObjFlag30
            // 
            this.pObjFlag30.Location = new System.Drawing.Point(96, 496);
            this.pObjFlag30.Name = "pObjFlag30";
            this.pObjFlag30.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag30.TabIndex = 49;
            this.pObjFlag30.Text = "OF_TELEPORTED";
            // 
            // pObjFlag29
            // 
            this.pObjFlag29.Location = new System.Drawing.Point(96, 480);
            this.pObjFlag29.Name = "pObjFlag29";
            this.pObjFlag29.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag29.TabIndex = 48;
            this.pObjFlag29.Text = "OF_ANIMATED_DEAD";
            // 
            // pObjFlag28
            // 
            this.pObjFlag28.Location = new System.Drawing.Point(96, 464);
            this.pObjFlag28.Name = "pObjFlag28";
            this.pObjFlag28.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag28.TabIndex = 47;
            this.pObjFlag28.Text = "OF_HEIGHT_SET";
            // 
            // pObjFlag27
            // 
            this.pObjFlag27.Location = new System.Drawing.Point(96, 448);
            this.pObjFlag27.Name = "pObjFlag27";
            this.pObjFlag27.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag27.TabIndex = 46;
            this.pObjFlag27.Text = "OF_UNUSED_08000000";
            // 
            // pObjFlag26
            // 
            this.pObjFlag26.Location = new System.Drawing.Point(96, 432);
            this.pObjFlag26.Name = "pObjFlag26";
            this.pObjFlag26.Size = new System.Drawing.Size(160, 16);
            this.pObjFlag26.TabIndex = 45;
            this.pObjFlag26.Text = "OF_DISALLOW_WADING";
            // 
            // pObjFlag25
            // 
            this.pObjFlag25.Location = new System.Drawing.Point(96, 416);
            this.pObjFlag25.Name = "pObjFlag25";
            this.pObjFlag25.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag25.TabIndex = 44;
            this.pObjFlag25.Text = "OF_TRAP_SPOTTED";
            // 
            // pObjFlag24
            // 
            this.pObjFlag24.Location = new System.Drawing.Point(96, 400);
            this.pObjFlag24.Name = "pObjFlag24";
            this.pObjFlag24.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag24.TabIndex = 43;
            this.pObjFlag24.Text = "OF_TRAP_PC";
            // 
            // pObjFlag23
            // 
            this.pObjFlag23.Location = new System.Drawing.Point(96, 384);
            this.pObjFlag23.Name = "pObjFlag23";
            this.pObjFlag23.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag23.TabIndex = 42;
            this.pObjFlag23.Text = "OF_EXTINCT";
            // 
            // pObjFlag22
            // 
            this.pObjFlag22.Location = new System.Drawing.Point(96, 368);
            this.pObjFlag22.Name = "pObjFlag22";
            this.pObjFlag22.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag22.TabIndex = 41;
            this.pObjFlag22.Text = "OF_INVULNERABLE";
            // 
            // pObjFlag21
            // 
            this.pObjFlag21.Location = new System.Drawing.Point(96, 352);
            this.pObjFlag21.Name = "pObjFlag21";
            this.pObjFlag21.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag21.TabIndex = 40;
            this.pObjFlag21.Text = "OF_TEXT_FLOATER";
            // 
            // pObjFlag20
            // 
            this.pObjFlag20.Location = new System.Drawing.Point(96, 336);
            this.pObjFlag20.Name = "pObjFlag20";
            this.pObjFlag20.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag20.TabIndex = 39;
            this.pObjFlag20.Text = "OF_DONTLIGHT";
            // 
            // pObjFlag19
            // 
            this.pObjFlag19.Location = new System.Drawing.Point(96, 320);
            this.pObjFlag19.Name = "pObjFlag19";
            this.pObjFlag19.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag19.TabIndex = 38;
            this.pObjFlag19.Text = "OF_STONED";
            // 
            // pObjFlag18
            // 
            this.pObjFlag18.Location = new System.Drawing.Point(96, 304);
            this.pObjFlag18.Name = "pObjFlag18";
            this.pObjFlag18.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag18.TabIndex = 37;
            this.pObjFlag18.Text = "OF_UNUSED_40000";
            // 
            // pObjFlag17
            // 
            this.pObjFlag17.Location = new System.Drawing.Point(96, 288);
            this.pObjFlag17.Name = "pObjFlag17";
            this.pObjFlag17.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag17.TabIndex = 36;
            this.pObjFlag17.Text = "OF_WADING";
            // 
            // pObjFlag16
            // 
            this.pObjFlag16.Location = new System.Drawing.Point(96, 272);
            this.pObjFlag16.Name = "pObjFlag16";
            this.pObjFlag16.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag16.TabIndex = 35;
            this.pObjFlag16.Text = "OF_NOHEIGHT";
            // 
            // pObjFlag15
            // 
            this.pObjFlag15.Location = new System.Drawing.Point(96, 256);
            this.pObjFlag15.Name = "pObjFlag15";
            this.pObjFlag15.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag15.TabIndex = 34;
            this.pObjFlag15.Text = "OF_RANDOM_SIZE";
            // 
            // pObjFlag14
            // 
            this.pObjFlag14.Location = new System.Drawing.Point(96, 240);
            this.pObjFlag14.Name = "pObjFlag14";
            this.pObjFlag14.Size = new System.Drawing.Size(152, 16);
            this.pObjFlag14.TabIndex = 33;
            this.pObjFlag14.Text = "OF_PROVIDES_COVER";
            // 
            // pObjFlag13
            // 
            this.pObjFlag13.Location = new System.Drawing.Point(96, 224);
            this.pObjFlag13.Name = "pObjFlag13";
            this.pObjFlag13.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag13.TabIndex = 32;
            this.pObjFlag13.Text = "OF_DYNAMIC";
            // 
            // pObjFlag12
            // 
            this.pObjFlag12.Location = new System.Drawing.Point(96, 208);
            this.pObjFlag12.Name = "pObjFlag12";
            this.pObjFlag12.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag12.TabIndex = 31;
            this.pObjFlag12.Text = "OF_INVENTORY";
            // 
            // pObjFlag11
            // 
            this.pObjFlag11.Location = new System.Drawing.Point(96, 192);
            this.pObjFlag11.Name = "pObjFlag11";
            this.pObjFlag11.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag11.TabIndex = 30;
            this.pObjFlag11.Text = "OF_CLICK_THROUGH";
            // 
            // pObjFlag10
            // 
            this.pObjFlag10.Location = new System.Drawing.Point(96, 176);
            this.pObjFlag10.Name = "pObjFlag10";
            this.pObjFlag10.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag10.TabIndex = 29;
            this.pObjFlag10.Text = "OF_NO_BLOCK";
            // 
            // pObjFlag09
            // 
            this.pObjFlag09.Location = new System.Drawing.Point(96, 160);
            this.pObjFlag09.Name = "pObjFlag09";
            this.pObjFlag09.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag09.TabIndex = 28;
            this.pObjFlag09.Text = "OF_INVISIBLE";
            // 
            // pObjFlag08
            // 
            this.pObjFlag08.Location = new System.Drawing.Point(96, 144);
            this.pObjFlag08.Name = "pObjFlag08";
            this.pObjFlag08.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag08.TabIndex = 27;
            this.pObjFlag08.Text = "OF_DONTDRAW";
            // 
            // pObjFlag07
            // 
            this.pObjFlag07.Location = new System.Drawing.Point(96, 128);
            this.pObjFlag07.Name = "pObjFlag07";
            this.pObjFlag07.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag07.TabIndex = 26;
            this.pObjFlag07.Text = "OF_SHRUNK";
            // 
            // pObjFlag06
            // 
            this.pObjFlag06.Location = new System.Drawing.Point(96, 112);
            this.pObjFlag06.Name = "pObjFlag06";
            this.pObjFlag06.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag06.TabIndex = 25;
            this.pObjFlag06.Text = "OF_TRANSLUCENT";
            // 
            // pObjFlag05
            // 
            this.pObjFlag05.Location = new System.Drawing.Point(96, 96);
            this.pObjFlag05.Name = "pObjFlag05";
            this.pObjFlag05.Size = new System.Drawing.Size(152, 16);
            this.pObjFlag05.TabIndex = 24;
            this.pObjFlag05.Text = "OF_SHOOT_THROUGH";
            // 
            // pObjFlag04
            // 
            this.pObjFlag04.Location = new System.Drawing.Point(96, 80);
            this.pObjFlag04.Name = "pObjFlag04";
            this.pObjFlag04.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag04.TabIndex = 23;
            this.pObjFlag04.Text = "OF_SEE_THROUGH";
            // 
            // pObjFlag03
            // 
            this.pObjFlag03.Location = new System.Drawing.Point(96, 64);
            this.pObjFlag03.Name = "pObjFlag03";
            this.pObjFlag03.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag03.TabIndex = 22;
            this.pObjFlag03.Text = "OF_TEXT";
            // 
            // pObjFlag02
            // 
            this.pObjFlag02.Location = new System.Drawing.Point(96, 48);
            this.pObjFlag02.Name = "pObjFlag02";
            this.pObjFlag02.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag02.TabIndex = 21;
            this.pObjFlag02.Text = "OF_FLAT";
            // 
            // pObjFlag01
            // 
            this.pObjFlag01.Location = new System.Drawing.Point(96, 32);
            this.pObjFlag01.Name = "pObjFlag01";
            this.pObjFlag01.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag01.TabIndex = 20;
            this.pObjFlag01.Text = "OF_OFF";
            // 
            // pObjFlag00
            // 
            this.pObjFlag00.Location = new System.Drawing.Point(96, 16);
            this.pObjFlag00.Name = "pObjFlag00";
            this.pObjFlag00.Size = new System.Drawing.Size(144, 16);
            this.pObjFlag00.TabIndex = 19;
            this.pObjFlag00.Text = "OF_DESTROYED";
            // 
            // pObjFlags
            // 
            this.pObjFlags.Location = new System.Drawing.Point(8, 10);
            this.pObjFlags.Name = "pObjFlags";
            this.pObjFlags.Size = new System.Drawing.Size(96, 24);
            this.pObjFlags.TabIndex = 18;
            this.pObjFlags.Text = "Object Flags:";
            this.pObjFlags.CheckedChanged += new System.EventHandler(this.pObjFlags_CheckedChanged);
            // 
            // b
            // 
            this.b.BackColor = System.Drawing.SystemColors.Control;
            this.b.Controls.Add(this.pNotify1);
            this.b.Controls.Add(this.vNotify1);
            this.b.Controls.Add(this.v_PFlag09);
            this.b.Controls.Add(this.v_PFlag08);
            this.b.Controls.Add(this.v_PFlag07);
            this.b.Controls.Add(this.v_PFlag06);
            this.b.Controls.Add(this.v_PFlag05);
            this.b.Controls.Add(this.v_PFlag04);
            this.b.Controls.Add(this.v_PFlag03);
            this.b.Controls.Add(this.v_PFlag02);
            this.b.Controls.Add(this.v_PFlag01);
            this.b.Controls.Add(this.v_PFlag00);
            this.b.Controls.Add(this.p_OPF);
            this.b.Controls.Add(this.vPKeyID);
            this.b.Controls.Add(this.pPKeyID);
            this.b.Controls.Add(this.vPLockDC);
            this.b.Controls.Add(this.pPLockDC);
            this.b.Location = new System.Drawing.Point(4, 22);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(456, 534);
            this.b.TabIndex = 7;
            this.b.Text = "Portals";
            // 
            // pNotify1
            // 
            this.pNotify1.Location = new System.Drawing.Point(8, 256);
            this.pNotify1.Name = "pNotify1";
            this.pNotify1.Size = new System.Drawing.Size(192, 24);
            this.pNotify1.TabIndex = 89;
            this.pNotify1.Text = "Notify NPC with Unique Name ID:";
            this.pNotify1.Visible = false;
            this.pNotify1.CheckedChanged += new System.EventHandler(this.pNotify1_CheckedChanged);
            // 
            // vNotify1
            // 
            this.vNotify1.Enabled = false;
            this.vNotify1.Location = new System.Drawing.Point(200, 258);
            this.vNotify1.Name = "vNotify1";
            this.vNotify1.Size = new System.Drawing.Size(69, 20);
            this.vNotify1.TabIndex = 88;
            this.vNotify1.Text = "0";
            this.vNotify1.Visible = false;
            // 
            // v_PFlag09
            // 
            this.v_PFlag09.Enabled = false;
            this.v_PFlag09.Location = new System.Drawing.Point(64, 224);
            this.v_PFlag09.Name = "v_PFlag09";
            this.v_PFlag09.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag09.TabIndex = 69;
            this.v_PFlag09.Text = "Open";
            // 
            // v_PFlag08
            // 
            this.v_PFlag08.Enabled = false;
            this.v_PFlag08.Location = new System.Drawing.Point(64, 208);
            this.v_PFlag08.Name = "v_PFlag08";
            this.v_PFlag08.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag08.TabIndex = 68;
            this.v_PFlag08.Text = "Not Sticky";
            // 
            // v_PFlag07
            // 
            this.v_PFlag07.Enabled = false;
            this.v_PFlag07.Location = new System.Drawing.Point(64, 192);
            this.v_PFlag07.Name = "v_PFlag07";
            this.v_PFlag07.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag07.TabIndex = 67;
            this.v_PFlag07.Text = "Busted";
            // 
            // v_PFlag06
            // 
            this.v_PFlag06.Enabled = false;
            this.v_PFlag06.Location = new System.Drawing.Point(64, 176);
            this.v_PFlag06.Name = "v_PFlag06";
            this.v_PFlag06.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag06.TabIndex = 66;
            this.v_PFlag06.Text = "Locked (Night)";
            // 
            // v_PFlag05
            // 
            this.v_PFlag05.Enabled = false;
            this.v_PFlag05.Location = new System.Drawing.Point(64, 160);
            this.v_PFlag05.Name = "v_PFlag05";
            this.v_PFlag05.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag05.TabIndex = 65;
            this.v_PFlag05.Text = "Locked (Day)";
            // 
            // v_PFlag04
            // 
            this.v_PFlag04.Enabled = false;
            this.v_PFlag04.Location = new System.Drawing.Point(64, 144);
            this.v_PFlag04.Name = "v_PFlag04";
            this.v_PFlag04.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag04.TabIndex = 64;
            this.v_PFlag04.Text = "Always Locked";
            // 
            // v_PFlag03
            // 
            this.v_PFlag03.Enabled = false;
            this.v_PFlag03.Location = new System.Drawing.Point(64, 128);
            this.v_PFlag03.Name = "v_PFlag03";
            this.v_PFlag03.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag03.TabIndex = 63;
            this.v_PFlag03.Text = "Never Locked";
            // 
            // v_PFlag02
            // 
            this.v_PFlag02.Enabled = false;
            this.v_PFlag02.Location = new System.Drawing.Point(64, 112);
            this.v_PFlag02.Name = "v_PFlag02";
            this.v_PFlag02.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag02.TabIndex = 62;
            this.v_PFlag02.Text = "Magically Held";
            // 
            // v_PFlag01
            // 
            this.v_PFlag01.Enabled = false;
            this.v_PFlag01.Location = new System.Drawing.Point(64, 96);
            this.v_PFlag01.Name = "v_PFlag01";
            this.v_PFlag01.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag01.TabIndex = 61;
            this.v_PFlag01.Text = "Jammed";
            // 
            // v_PFlag00
            // 
            this.v_PFlag00.Enabled = false;
            this.v_PFlag00.Location = new System.Drawing.Point(64, 80);
            this.v_PFlag00.Name = "v_PFlag00";
            this.v_PFlag00.Size = new System.Drawing.Size(152, 16);
            this.v_PFlag00.TabIndex = 60;
            this.v_PFlag00.Text = "Locked";
            // 
            // p_OPF
            // 
            this.p_OPF.Location = new System.Drawing.Point(8, 72);
            this.p_OPF.Name = "p_OPF";
            this.p_OPF.Size = new System.Drawing.Size(56, 24);
            this.p_OPF.TabIndex = 20;
            this.p_OPF.Text = "Flags:";
            this.p_OPF.CheckedChanged += new System.EventHandler(this.p_OPF_CheckedChanged);
            // 
            // vPKeyID
            // 
            this.vPKeyID.Enabled = false;
            this.vPKeyID.Location = new System.Drawing.Point(80, 34);
            this.vPKeyID.Name = "vPKeyID";
            this.vPKeyID.Size = new System.Drawing.Size(40, 20);
            this.vPKeyID.TabIndex = 19;
            this.vPKeyID.Text = "0";
            // 
            // pPKeyID
            // 
            this.pPKeyID.Location = new System.Drawing.Point(8, 32);
            this.pPKeyID.Name = "pPKeyID";
            this.pPKeyID.Size = new System.Drawing.Size(80, 24);
            this.pPKeyID.TabIndex = 18;
            this.pPKeyID.Text = "Key ID:";
            this.pPKeyID.CheckedChanged += new System.EventHandler(this.pPKeyID_CheckedChanged);
            // 
            // vPLockDC
            // 
            this.vPLockDC.Enabled = false;
            this.vPLockDC.Location = new System.Drawing.Point(80, 10);
            this.vPLockDC.Name = "vPLockDC";
            this.vPLockDC.Size = new System.Drawing.Size(40, 20);
            this.vPLockDC.TabIndex = 17;
            this.vPLockDC.Text = "0";
            // 
            // pPLockDC
            // 
            this.pPLockDC.Location = new System.Drawing.Point(8, 8);
            this.pPLockDC.Name = "pPLockDC";
            this.pPLockDC.Size = new System.Drawing.Size(80, 24);
            this.pPLockDC.TabIndex = 0;
            this.pPLockDC.Text = "Lock DC:";
            this.pPLockDC.CheckedChanged += new System.EventHandler(this.pPLockDC_CheckedChanged);
            // 
            // c
            // 
            this.c.BackColor = System.Drawing.SystemColors.Control;
            this.c.Controls.Add(this.label207);
            this.c.Controls.Add(this.label178);
            this.c.Controls.Add(this.v_SDFlag31);
            this.c.Controls.Add(this.v_SDFlag30);
            this.c.Controls.Add(this.v_SDFlag29);
            this.c.Controls.Add(this.v_SDFlag28);
            this.c.Controls.Add(this.v_SDFlag27);
            this.c.Controls.Add(this.v_SDFlag26);
            this.c.Controls.Add(this.v_SDFlag25);
            this.c.Controls.Add(this.v_SDFlag24);
            this.c.Controls.Add(this.v_SDFlag23);
            this.c.Controls.Add(this.v_SDFlag22);
            this.c.Controls.Add(this.v_SDFlag21);
            this.c.Controls.Add(this.v_SDFlag20);
            this.c.Controls.Add(this.v_SDFlag19);
            this.c.Controls.Add(this.v_SDFlag18);
            this.c.Controls.Add(this.v_SDFlag17);
            this.c.Controls.Add(this.v_SDFlag16);
            this.c.Controls.Add(this.v_SDFlag15);
            this.c.Controls.Add(this.v_SDFlag14);
            this.c.Controls.Add(this.v_SDFlag13);
            this.c.Controls.Add(this.v_SDFlag12);
            this.c.Controls.Add(this.v_SDFlag11);
            this.c.Controls.Add(this.v_SDFlag10);
            this.c.Controls.Add(this.v_SDFlag09);
            this.c.Controls.Add(this.v_SDFlag08);
            this.c.Controls.Add(this.v_SDFlag07);
            this.c.Controls.Add(this.v_SDFlag06);
            this.c.Controls.Add(this.v_SDFlag05);
            this.c.Controls.Add(this.v_SDFlag04);
            this.c.Controls.Add(this.v_SDFlag03);
            this.c.Controls.Add(this.v_SDFlag02);
            this.c.Controls.Add(this.v_SDFlag01);
            this.c.Controls.Add(this.v_SDFlag00);
            this.c.Controls.Add(this.p_OSDF);
            this.c.Controls.Add(this.vSDDC);
            this.c.Controls.Add(this.pSDDC);
            this.c.Controls.Add(this.vEffName);
            this.c.Controls.Add(this.pEffName);
            this.c.Location = new System.Drawing.Point(4, 22);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(456, 534);
            this.c.TabIndex = 13;
            this.c.Text = "Secret Doors";
            // 
            // label207
            // 
            this.label207.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label207.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label207.Location = new System.Drawing.Point(80, 424);
            this.label207.Name = "label207";
            this.label207.Size = new System.Drawing.Size(296, 58);
            this.label207.TabIndex = 165;
            this.label207.Text = "VERY IMPORTANT: You MUST put a check mark in both the Secret Door DC *AND* the Fl" +
                "ags entries, and it seems lke you must set OSDF_UNK1 in order for the secret doo" +
                "r to work.";
            this.label207.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label178
            // 
            this.label178.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label178.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label178.Location = new System.Drawing.Point(80, 352);
            this.label178.Name = "label178";
            this.label178.Size = new System.Drawing.Size(296, 58);
            this.label178.TabIndex = 164;
            this.label178.Text = "Do NOT edit the OSDF_DC_* and OSDF_RANK_* fields by hand! They are now set automa" +
                "tically! Please use the Secret Door DC field to set up the secret door DC (min 0" +
                ", max 127).";
            this.label178.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // v_SDFlag31
            // 
            this.v_SDFlag31.Enabled = false;
            this.v_SDFlag31.Location = new System.Drawing.Point(256, 320);
            this.v_SDFlag31.Name = "v_SDFlag31";
            this.v_SDFlag31.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag31.TabIndex = 163;
            this.v_SDFlag31.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag30
            // 
            this.v_SDFlag30.Enabled = false;
            this.v_SDFlag30.Location = new System.Drawing.Point(256, 304);
            this.v_SDFlag30.Name = "v_SDFlag30";
            this.v_SDFlag30.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag30.TabIndex = 162;
            this.v_SDFlag30.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag29
            // 
            this.v_SDFlag29.Enabled = false;
            this.v_SDFlag29.Location = new System.Drawing.Point(256, 288);
            this.v_SDFlag29.Name = "v_SDFlag29";
            this.v_SDFlag29.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag29.TabIndex = 161;
            this.v_SDFlag29.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag28
            // 
            this.v_SDFlag28.Enabled = false;
            this.v_SDFlag28.Location = new System.Drawing.Point(256, 272);
            this.v_SDFlag28.Name = "v_SDFlag28";
            this.v_SDFlag28.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag28.TabIndex = 160;
            this.v_SDFlag28.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag27
            // 
            this.v_SDFlag27.Enabled = false;
            this.v_SDFlag27.Location = new System.Drawing.Point(256, 256);
            this.v_SDFlag27.Name = "v_SDFlag27";
            this.v_SDFlag27.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag27.TabIndex = 159;
            this.v_SDFlag27.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag26
            // 
            this.v_SDFlag26.Enabled = false;
            this.v_SDFlag26.Location = new System.Drawing.Point(256, 240);
            this.v_SDFlag26.Name = "v_SDFlag26";
            this.v_SDFlag26.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag26.TabIndex = 158;
            this.v_SDFlag26.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag25
            // 
            this.v_SDFlag25.Enabled = false;
            this.v_SDFlag25.Location = new System.Drawing.Point(256, 224);
            this.v_SDFlag25.Name = "v_SDFlag25";
            this.v_SDFlag25.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag25.TabIndex = 157;
            this.v_SDFlag25.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag24
            // 
            this.v_SDFlag24.Enabled = false;
            this.v_SDFlag24.Location = new System.Drawing.Point(256, 208);
            this.v_SDFlag24.Name = "v_SDFlag24";
            this.v_SDFlag24.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag24.TabIndex = 156;
            this.v_SDFlag24.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag23
            // 
            this.v_SDFlag23.Enabled = false;
            this.v_SDFlag23.Location = new System.Drawing.Point(256, 192);
            this.v_SDFlag23.Name = "v_SDFlag23";
            this.v_SDFlag23.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag23.TabIndex = 155;
            this.v_SDFlag23.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag22
            // 
            this.v_SDFlag22.Enabled = false;
            this.v_SDFlag22.Location = new System.Drawing.Point(256, 176);
            this.v_SDFlag22.Name = "v_SDFlag22";
            this.v_SDFlag22.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag22.TabIndex = 154;
            this.v_SDFlag22.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag21
            // 
            this.v_SDFlag21.Enabled = false;
            this.v_SDFlag21.Location = new System.Drawing.Point(256, 160);
            this.v_SDFlag21.Name = "v_SDFlag21";
            this.v_SDFlag21.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag21.TabIndex = 153;
            this.v_SDFlag21.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag20
            // 
            this.v_SDFlag20.Enabled = false;
            this.v_SDFlag20.Location = new System.Drawing.Point(256, 144);
            this.v_SDFlag20.Name = "v_SDFlag20";
            this.v_SDFlag20.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag20.TabIndex = 152;
            this.v_SDFlag20.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag19
            // 
            this.v_SDFlag19.Enabled = false;
            this.v_SDFlag19.Location = new System.Drawing.Point(256, 128);
            this.v_SDFlag19.Name = "v_SDFlag19";
            this.v_SDFlag19.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag19.TabIndex = 151;
            this.v_SDFlag19.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag18
            // 
            this.v_SDFlag18.Enabled = false;
            this.v_SDFlag18.Location = new System.Drawing.Point(256, 112);
            this.v_SDFlag18.Name = "v_SDFlag18";
            this.v_SDFlag18.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag18.TabIndex = 150;
            this.v_SDFlag18.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag17
            // 
            this.v_SDFlag17.Enabled = false;
            this.v_SDFlag17.Location = new System.Drawing.Point(256, 96);
            this.v_SDFlag17.Name = "v_SDFlag17";
            this.v_SDFlag17.Size = new System.Drawing.Size(200, 16);
            this.v_SDFlag17.TabIndex = 149;
            this.v_SDFlag17.Text = "OSDF_SECRET_DOOR_FOUND";
            // 
            // v_SDFlag16
            // 
            this.v_SDFlag16.Enabled = false;
            this.v_SDFlag16.Location = new System.Drawing.Point(256, 80);
            this.v_SDFlag16.Name = "v_SDFlag16";
            this.v_SDFlag16.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag16.TabIndex = 148;
            this.v_SDFlag16.Text = "OSDF_SECRET_DOOR";
            // 
            // v_SDFlag15
            // 
            this.v_SDFlag15.Enabled = false;
            this.v_SDFlag15.Location = new System.Drawing.Point(64, 320);
            this.v_SDFlag15.Name = "v_SDFlag15";
            this.v_SDFlag15.Size = new System.Drawing.Size(200, 16);
            this.v_SDFlag15.TabIndex = 147;
            this.v_SDFlag15.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag14
            // 
            this.v_SDFlag14.Enabled = false;
            this.v_SDFlag14.Location = new System.Drawing.Point(64, 304);
            this.v_SDFlag14.Name = "v_SDFlag14";
            this.v_SDFlag14.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag14.TabIndex = 146;
            this.v_SDFlag14.Text = "OSDF_UNUSED";
            // 
            // v_SDFlag13
            // 
            this.v_SDFlag13.Enabled = false;
            this.v_SDFlag13.Location = new System.Drawing.Point(64, 288);
            this.v_SDFlag13.Name = "v_SDFlag13";
            this.v_SDFlag13.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag13.TabIndex = 145;
            this.v_SDFlag13.Text = "OSDF_RANK_6";
            // 
            // v_SDFlag12
            // 
            this.v_SDFlag12.Enabled = false;
            this.v_SDFlag12.Location = new System.Drawing.Point(64, 272);
            this.v_SDFlag12.Name = "v_SDFlag12";
            this.v_SDFlag12.Size = new System.Drawing.Size(200, 16);
            this.v_SDFlag12.TabIndex = 144;
            this.v_SDFlag12.Text = "OSDF_RANK_5";
            // 
            // v_SDFlag11
            // 
            this.v_SDFlag11.Enabled = false;
            this.v_SDFlag11.Location = new System.Drawing.Point(64, 256);
            this.v_SDFlag11.Name = "v_SDFlag11";
            this.v_SDFlag11.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag11.TabIndex = 143;
            this.v_SDFlag11.Text = "OSDF_RANK_4";
            // 
            // v_SDFlag10
            // 
            this.v_SDFlag10.Enabled = false;
            this.v_SDFlag10.Location = new System.Drawing.Point(64, 240);
            this.v_SDFlag10.Name = "v_SDFlag10";
            this.v_SDFlag10.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag10.TabIndex = 142;
            this.v_SDFlag10.Text = "OSDF_RANK_3";
            // 
            // v_SDFlag09
            // 
            this.v_SDFlag09.Enabled = false;
            this.v_SDFlag09.Location = new System.Drawing.Point(64, 224);
            this.v_SDFlag09.Name = "v_SDFlag09";
            this.v_SDFlag09.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag09.TabIndex = 141;
            this.v_SDFlag09.Text = "OSDF_RANK_2";
            // 
            // v_SDFlag08
            // 
            this.v_SDFlag08.Enabled = false;
            this.v_SDFlag08.Location = new System.Drawing.Point(64, 208);
            this.v_SDFlag08.Name = "v_SDFlag08";
            this.v_SDFlag08.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag08.TabIndex = 140;
            this.v_SDFlag08.Text = "OSDF_RANK_1";
            // 
            // v_SDFlag07
            // 
            this.v_SDFlag07.Enabled = false;
            this.v_SDFlag07.Location = new System.Drawing.Point(64, 192);
            this.v_SDFlag07.Name = "v_SDFlag07";
            this.v_SDFlag07.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag07.TabIndex = 139;
            this.v_SDFlag07.Text = "OSDF_RANK_0";
            // 
            // v_SDFlag06
            // 
            this.v_SDFlag06.Enabled = false;
            this.v_SDFlag06.Location = new System.Drawing.Point(64, 176);
            this.v_SDFlag06.Name = "v_SDFlag06";
            this.v_SDFlag06.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag06.TabIndex = 138;
            this.v_SDFlag06.Text = "OSDF_DC_6";
            // 
            // v_SDFlag05
            // 
            this.v_SDFlag05.Enabled = false;
            this.v_SDFlag05.Location = new System.Drawing.Point(64, 160);
            this.v_SDFlag05.Name = "v_SDFlag05";
            this.v_SDFlag05.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag05.TabIndex = 137;
            this.v_SDFlag05.Text = "OSDF_DC_5";
            // 
            // v_SDFlag04
            // 
            this.v_SDFlag04.Enabled = false;
            this.v_SDFlag04.Location = new System.Drawing.Point(64, 144);
            this.v_SDFlag04.Name = "v_SDFlag04";
            this.v_SDFlag04.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag04.TabIndex = 136;
            this.v_SDFlag04.Text = "OSDF_DC_4";
            // 
            // v_SDFlag03
            // 
            this.v_SDFlag03.Enabled = false;
            this.v_SDFlag03.Location = new System.Drawing.Point(64, 128);
            this.v_SDFlag03.Name = "v_SDFlag03";
            this.v_SDFlag03.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag03.TabIndex = 135;
            this.v_SDFlag03.Text = "OSDF_DC_3";
            // 
            // v_SDFlag02
            // 
            this.v_SDFlag02.Enabled = false;
            this.v_SDFlag02.Location = new System.Drawing.Point(64, 112);
            this.v_SDFlag02.Name = "v_SDFlag02";
            this.v_SDFlag02.Size = new System.Drawing.Size(192, 16);
            this.v_SDFlag02.TabIndex = 134;
            this.v_SDFlag02.Text = "OSDF_DC_2";
            // 
            // v_SDFlag01
            // 
            this.v_SDFlag01.Enabled = false;
            this.v_SDFlag01.Location = new System.Drawing.Point(64, 96);
            this.v_SDFlag01.Name = "v_SDFlag01";
            this.v_SDFlag01.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag01.TabIndex = 133;
            this.v_SDFlag01.Text = "OSDF_DC_1";
            // 
            // v_SDFlag00
            // 
            this.v_SDFlag00.Enabled = false;
            this.v_SDFlag00.Location = new System.Drawing.Point(64, 80);
            this.v_SDFlag00.Name = "v_SDFlag00";
            this.v_SDFlag00.Size = new System.Drawing.Size(184, 16);
            this.v_SDFlag00.TabIndex = 132;
            this.v_SDFlag00.Text = "OSDF_DC_0";
            // 
            // p_OSDF
            // 
            this.p_OSDF.Location = new System.Drawing.Point(8, 72);
            this.p_OSDF.Name = "p_OSDF";
            this.p_OSDF.Size = new System.Drawing.Size(96, 24);
            this.p_OSDF.TabIndex = 131;
            this.p_OSDF.Text = "Flags:";
            this.p_OSDF.CheckedChanged += new System.EventHandler(this.p_OSDF_CheckedChanged);
            // 
            // vSDDC
            // 
            this.vSDDC.Enabled = false;
            this.vSDDC.Location = new System.Drawing.Point(152, 34);
            this.vSDDC.Name = "vSDDC";
            this.vSDDC.Size = new System.Drawing.Size(56, 20);
            this.vSDDC.TabIndex = 31;
            this.vSDDC.Text = "0";
            // 
            // pSDDC
            // 
            this.pSDDC.Location = new System.Drawing.Point(8, 32);
            this.pSDDC.Name = "pSDDC";
            this.pSDDC.Size = new System.Drawing.Size(144, 24);
            this.pSDDC.TabIndex = 30;
            this.pSDDC.Text = "Secret Door DC:";
            this.pSDDC.CheckedChanged += new System.EventHandler(this.pSDDC_CheckedChanged);
            // 
            // vEffName
            // 
            this.vEffName.Enabled = false;
            this.vEffName.Location = new System.Drawing.Point(152, 10);
            this.vEffName.Name = "vEffName";
            this.vEffName.Size = new System.Drawing.Size(56, 20);
            this.vEffName.TabIndex = 29;
            this.vEffName.Text = "0";
            // 
            // pEffName
            // 
            this.pEffName.Location = new System.Drawing.Point(8, 8);
            this.pEffName.Name = "pEffName";
            this.pEffName.Size = new System.Drawing.Size(208, 24);
            this.pEffName.TabIndex = 28;
            this.pEffName.Text = "Secret Door Effect Name:";
            this.pEffName.CheckedChanged += new System.EventHandler(this.pEffName_CheckedChanged);
            // 
            // d
            // 
            this.d.BackColor = System.Drawing.SystemColors.Control;
            this.d.Controls.Add(this.v_SFlag12);
            this.d.Controls.Add(this.v_SFlag11);
            this.d.Controls.Add(this.v_SFlag10);
            this.d.Controls.Add(this.v_SFlag09);
            this.d.Controls.Add(this.v_SFlag08);
            this.d.Controls.Add(this.v_SFlag07);
            this.d.Controls.Add(this.v_SFlag06);
            this.d.Controls.Add(this.v_SFlag05);
            this.d.Controls.Add(this.v_SFlag04);
            this.d.Controls.Add(this.v_SFlag03);
            this.d.Controls.Add(this.v_SFlag02);
            this.d.Controls.Add(this.v_SFlag01);
            this.d.Controls.Add(this.v_SFlag00);
            this.d.Controls.Add(this.p_OSCF);
            this.d.Controls.Add(this.label26);
            this.d.Controls.Add(this.vTeleport);
            this.d.Controls.Add(this.pTeleport);
            this.d.Location = new System.Drawing.Point(4, 22);
            this.d.Name = "d";
            this.d.Size = new System.Drawing.Size(456, 534);
            this.d.TabIndex = 4;
            this.d.Text = "Scenery";
            // 
            // v_SFlag12
            // 
            this.v_SFlag12.Enabled = false;
            this.v_SFlag12.Location = new System.Drawing.Point(64, 264);
            this.v_SFlag12.Name = "v_SFlag12";
            this.v_SFlag12.Size = new System.Drawing.Size(200, 16);
            this.v_SFlag12.TabIndex = 130;
            this.v_SFlag12.Text = "OSCF_USE_OPEN_WORLDMAP";
            // 
            // v_SFlag11
            // 
            this.v_SFlag11.Enabled = false;
            this.v_SFlag11.Location = new System.Drawing.Point(64, 248);
            this.v_SFlag11.Name = "v_SFlag11";
            this.v_SFlag11.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag11.TabIndex = 129;
            this.v_SFlag11.Text = "OSCF_TAGGED_SCENERY";
            // 
            // v_SFlag10
            // 
            this.v_SFlag10.Enabled = false;
            this.v_SFlag10.Location = new System.Drawing.Point(64, 232);
            this.v_SFlag10.Name = "v_SFlag10";
            this.v_SFlag10.Size = new System.Drawing.Size(192, 16);
            this.v_SFlag10.TabIndex = 128;
            this.v_SFlag10.Text = "OSCF_RESPAWNING";
            // 
            // v_SFlag09
            // 
            this.v_SFlag09.Enabled = false;
            this.v_SFlag09.Location = new System.Drawing.Point(64, 216);
            this.v_SFlag09.Name = "v_SFlag09";
            this.v_SFlag09.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag09.TabIndex = 127;
            this.v_SFlag09.Text = "OSCF_UNDER_ALL";
            // 
            // v_SFlag08
            // 
            this.v_SFlag08.Enabled = false;
            this.v_SFlag08.Location = new System.Drawing.Point(64, 200);
            this.v_SFlag08.Name = "v_SFlag08";
            this.v_SFlag08.Size = new System.Drawing.Size(192, 16);
            this.v_SFlag08.TabIndex = 126;
            this.v_SFlag08.Text = "OSCF_SOUND_EXTRA_LARGE";
            // 
            // v_SFlag07
            // 
            this.v_SFlag07.Enabled = false;
            this.v_SFlag07.Location = new System.Drawing.Point(64, 184);
            this.v_SFlag07.Name = "v_SFlag07";
            this.v_SFlag07.Size = new System.Drawing.Size(192, 16);
            this.v_SFlag07.TabIndex = 125;
            this.v_SFlag07.Text = "OSCF_SOUND_MEDIUM";
            // 
            // v_SFlag06
            // 
            this.v_SFlag06.Enabled = false;
            this.v_SFlag06.Location = new System.Drawing.Point(64, 168);
            this.v_SFlag06.Name = "v_SFlag06";
            this.v_SFlag06.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag06.TabIndex = 124;
            this.v_SFlag06.Text = "OSCF_SOUND_SMALL";
            // 
            // v_SFlag05
            // 
            this.v_SFlag05.Enabled = false;
            this.v_SFlag05.Location = new System.Drawing.Point(64, 152);
            this.v_SFlag05.Name = "v_SFlag05";
            this.v_SFlag05.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag05.TabIndex = 123;
            this.v_SFlag05.Text = "OSCF_RESPAWNABLE";
            // 
            // v_SFlag04
            // 
            this.v_SFlag04.Enabled = false;
            this.v_SFlag04.Location = new System.Drawing.Point(64, 136);
            this.v_SFlag04.Name = "v_SFlag04";
            this.v_SFlag04.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag04.TabIndex = 122;
            this.v_SFlag04.Text = "OSCF_IS_FIRE";
            // 
            // v_SFlag03
            // 
            this.v_SFlag03.Enabled = false;
            this.v_SFlag03.Location = new System.Drawing.Point(64, 120);
            this.v_SFlag03.Name = "v_SFlag03";
            this.v_SFlag03.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag03.TabIndex = 121;
            this.v_SFlag03.Text = "OSCF_MARKS_TOWNMAP";
            // 
            // v_SFlag02
            // 
            this.v_SFlag02.Enabled = false;
            this.v_SFlag02.Location = new System.Drawing.Point(64, 104);
            this.v_SFlag02.Name = "v_SFlag02";
            this.v_SFlag02.Size = new System.Drawing.Size(192, 16);
            this.v_SFlag02.TabIndex = 120;
            this.v_SFlag02.Text = "OSCF_NOCTURNAL";
            // 
            // v_SFlag01
            // 
            this.v_SFlag01.Enabled = false;
            this.v_SFlag01.Location = new System.Drawing.Point(64, 88);
            this.v_SFlag01.Name = "v_SFlag01";
            this.v_SFlag01.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag01.TabIndex = 119;
            this.v_SFlag01.Text = "OSCF_BUSTED";
            // 
            // v_SFlag00
            // 
            this.v_SFlag00.Enabled = false;
            this.v_SFlag00.Location = new System.Drawing.Point(64, 72);
            this.v_SFlag00.Name = "v_SFlag00";
            this.v_SFlag00.Size = new System.Drawing.Size(184, 16);
            this.v_SFlag00.TabIndex = 118;
            this.v_SFlag00.Text = "OSCF_NO_AUTO_ANIMATE";
            // 
            // p_OSCF
            // 
            this.p_OSCF.Location = new System.Drawing.Point(8, 64);
            this.p_OSCF.Name = "p_OSCF";
            this.p_OSCF.Size = new System.Drawing.Size(96, 24);
            this.p_OSCF.TabIndex = 117;
            this.p_OSCF.Text = "Flags:";
            this.p_OSCF.CheckedChanged += new System.EventHandler(this.p_OSCF_CheckedChanged);
            // 
            // label26
            // 
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label26.Location = new System.Drawing.Point(264, 12);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(184, 60);
            this.label26.TabIndex = 28;
            this.label26.Text = "(used for door and passage icons), number should correspond to an entry in JUMPPO" +
                "INT.TAB (use Jump Point editor to edit jump points)";
            // 
            // vTeleport
            // 
            this.vTeleport.Location = new System.Drawing.Point(200, 10);
            this.vTeleport.Name = "vTeleport";
            this.vTeleport.Size = new System.Drawing.Size(56, 20);
            this.vTeleport.TabIndex = 27;
            this.vTeleport.Text = "0";
            // 
            // pTeleport
            // 
            this.pTeleport.Location = new System.Drawing.Point(8, 8);
            this.pTeleport.Name = "pTeleport";
            this.pTeleport.Size = new System.Drawing.Size(208, 24);
            this.pTeleport.TabIndex = 26;
            this.pTeleport.Text = "Use As A Teleport With Destination:";
            this.pTeleport.CheckedChanged += new System.EventHandler(this.pTeleport_CheckedChanged);
            // 
            // g
            // 
            this.g.BackColor = System.Drawing.SystemColors.Control;
            this.g.Controls.Add(this.pGender);
            this.g.Controls.Add(this.vGender);
            this.g.Controls.Add(this.pRace);
            this.g.Controls.Add(this.vRace);
            this.g.Controls.Add(this.vCleanNpcInv);
            this.g.Controls.Add(this.vNpcInvFill);
            this.g.Controls.Add(this.pLevelup);
            this.g.Controls.Add(this.vLevelup);
            this.g.Controls.Add(this.vWayDelay);
            this.g.Controls.Add(this.label205);
            this.g.Controls.Add(this.vWayRot);
            this.g.Controls.Add(this.label204);
            this.g.Controls.Add(this.cRotWpt);
            this.g.Controls.Add(this.cDelayWpt);
            this.g.Controls.Add(this.vWayAnim8);
            this.g.Controls.Add(this.vWayAnim7);
            this.g.Controls.Add(this.vWayAnim6);
            this.g.Controls.Add(this.vWayAnim5);
            this.g.Controls.Add(this.vWayAnim4);
            this.g.Controls.Add(this.vWayAnim3);
            this.g.Controls.Add(this.vWayAnim2);
            this.g.Controls.Add(this.cAnimWpt);
            this.g.Controls.Add(this.vWayAnim1);
            this.g.Controls.Add(this.label146);
            this.g.Controls.Add(this.vMoneyIdx4);
            this.g.Controls.Add(this.vMoneyIdx3);
            this.g.Controls.Add(this.vMoneyIdx2);
            this.g.Controls.Add(this.vMoneyIdx1);
            this.g.Controls.Add(this.label197);
            this.g.Controls.Add(this.label196);
            this.g.Controls.Add(this.label195);
            this.g.Controls.Add(this.label194);
            this.g.Controls.Add(this.pMoneyIdx);
            this.g.Controls.Add(this.label193);
            this.g.Controls.Add(this.label189);
            this.g.Controls.Add(this.label192);
            this.g.Controls.Add(this.label191);
            this.g.Controls.Add(this.vAI64);
            this.g.Controls.Add(this.pAI64);
            this.g.Controls.Add(this.vTeleY);
            this.g.Controls.Add(this.label190);
            this.g.Controls.Add(this.vTeleX);
            this.g.Controls.Add(this.pTeleMap);
            this.g.Controls.Add(this.vTeleMap);
            this.g.Controls.Add(this.pTeleDest);
            this.g.Controls.Add(this.vNightFlags);
            this.g.Controls.Add(this.label188);
            this.g.Controls.Add(this.vDayFlags);
            this.g.Controls.Add(this.label187);
            this.g.Controls.Add(this.pFaction);
            this.g.Controls.Add(this.vFaction);
            this.g.Controls.Add(this.pReach);
            this.g.Controls.Add(this.vReach);
            this.g.Controls.Add(this.btnWayDel);
            this.g.Controls.Add(this.btnWayAdd);
            this.g.Controls.Add(this.vWayY);
            this.g.Controls.Add(this.vWayX);
            this.g.Controls.Add(this.label180);
            this.g.Controls.Add(this.label179);
            this.g.Controls.Add(this.vWaypoints);
            this.g.Controls.Add(this.pWaypoints);
            this.g.Controls.Add(this.vNpcInvSlot);
            this.g.Controls.Add(this.pNpcInvSlot);
            this.g.Controls.Add(this.tSubInv);
            this.g.Controls.Add(this.vSubInv);
            this.g.Controls.Add(this.pSubInv);
            this.g.Controls.Add(this.vNpcInvenSource);
            this.g.Controls.Add(this.pNpcInvenSource);
            this.g.Controls.Add(this.tNpcMoneyAmt);
            this.g.Controls.Add(this.label40);
            this.g.Controls.Add(this.btnNpcInvGUID);
            this.g.Controls.Add(this.pNpcInvDel);
            this.g.Controls.Add(this.btnAddNpcInv2);
            this.g.Controls.Add(this.label41);
            this.g.Controls.Add(this.label42);
            this.g.Controls.Add(this.label43);
            this.g.Controls.Add(this.btnRemoveNpcInv);
            this.g.Controls.Add(this.btnAddNpcInv);
            this.g.Controls.Add(this.vNpcInv);
            this.g.Controls.Add(this.label44);
            this.g.Controls.Add(this.pNpcInv);
            this.g.Controls.Add(this.NpcInvProtos);
            this.g.Location = new System.Drawing.Point(4, 22);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(456, 534);
            this.g.TabIndex = 5;
            this.g.Text = "NPC/Critters";
            // 
            // pGender
            // 
            this.pGender.Location = new System.Drawing.Point(240, 138);
            this.pGender.Name = "pGender";
            this.pGender.Size = new System.Drawing.Size(120, 24);
            this.pGender.TabIndex = 129;
            this.pGender.Text = "Gender ID:";
            this.pGender.CheckedChanged += new System.EventHandler(this.pGender_CheckedChanged);
            // 
            // vGender
            // 
            this.vGender.Enabled = false;
            this.vGender.Location = new System.Drawing.Point(360, 138);
            this.vGender.Name = "vGender";
            this.vGender.Size = new System.Drawing.Size(88, 20);
            this.vGender.TabIndex = 128;
            this.vGender.Text = "0";
            // 
            // pRace
            // 
            this.pRace.Location = new System.Drawing.Point(240, 112);
            this.pRace.Name = "pRace";
            this.pRace.Size = new System.Drawing.Size(120, 24);
            this.pRace.TabIndex = 127;
            this.pRace.Text = "Race ID:";
            this.pRace.CheckedChanged += new System.EventHandler(this.pRace_CheckedChanged);
            // 
            // vRace
            // 
            this.vRace.Enabled = false;
            this.vRace.Location = new System.Drawing.Point(360, 112);
            this.vRace.Name = "vRace";
            this.vRace.Size = new System.Drawing.Size(88, 20);
            this.vRace.TabIndex = 126;
            this.vRace.Text = "0";
            // 
            // vCleanNpcInv
            // 
            this.vCleanNpcInv.Location = new System.Drawing.Point(121, 191);
            this.vCleanNpcInv.Name = "vCleanNpcInv";
            this.vCleanNpcInv.Size = new System.Drawing.Size(105, 23);
            this.vCleanNpcInv.TabIndex = 125;
            this.vCleanNpcInv.Text = "Clean Inventory";
            this.vCleanNpcInv.UseVisualStyleBackColor = true;
            this.vCleanNpcInv.Click += new System.EventHandler(this.vCleanNpcInv_Click);
            // 
            // vNpcInvFill
            // 
            this.vNpcInvFill.Location = new System.Drawing.Point(15, 191);
            this.vNpcInvFill.Name = "vNpcInvFill";
            this.vNpcInvFill.Size = new System.Drawing.Size(105, 23);
            this.vNpcInvFill.TabIndex = 124;
            this.vNpcInvFill.Text = "Load InvenSource";
            this.vNpcInvFill.UseVisualStyleBackColor = true;
            this.vNpcInvFill.Click += new System.EventHandler(this.vNpcInvFill_Click);
            // 
            // pLevelup
            // 
            this.pLevelup.Location = new System.Drawing.Point(240, 69);
            this.pLevelup.Name = "pLevelup";
            this.pLevelup.Size = new System.Drawing.Size(143, 37);
            this.pLevelup.TabIndex = 123;
            this.pLevelup.Text = "NPC Levelup Scheme (per LEVELUP.TAB?)";
            this.pLevelup.CheckedChanged += new System.EventHandler(this.pLevelup_CheckedChanged);
            // 
            // vLevelup
            // 
            this.vLevelup.Enabled = false;
            this.vLevelup.Location = new System.Drawing.Point(387, 77);
            this.vLevelup.Name = "vLevelup";
            this.vLevelup.Size = new System.Drawing.Size(60, 20);
            this.vLevelup.TabIndex = 122;
            this.vLevelup.Text = "0";
            // 
            // vWayDelay
            // 
            this.vWayDelay.Location = new System.Drawing.Point(294, 429);
            this.vWayDelay.Name = "vWayDelay";
            this.vWayDelay.Size = new System.Drawing.Size(53, 20);
            this.vWayDelay.TabIndex = 121;
            this.vWayDelay.Text = "0";
            // 
            // label205
            // 
            this.label205.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label205.Location = new System.Drawing.Point(240, 429);
            this.label205.Name = "label205";
            this.label205.Size = new System.Drawing.Size(54, 17);
            this.label205.TabIndex = 120;
            this.label205.Text = "Delay:";
            // 
            // vWayRot
            // 
            this.vWayRot.Location = new System.Drawing.Point(294, 405);
            this.vWayRot.Name = "vWayRot";
            this.vWayRot.Size = new System.Drawing.Size(53, 20);
            this.vWayRot.TabIndex = 119;
            this.vWayRot.Text = "0";
            // 
            // label204
            // 
            this.label204.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label204.Location = new System.Drawing.Point(240, 408);
            this.label204.Name = "label204";
            this.label204.Size = new System.Drawing.Size(54, 23);
            this.label204.TabIndex = 118;
            this.label204.Text = "Rotation:";
            // 
            // cRotWpt
            // 
            this.cRotWpt.AutoSize = true;
            this.cRotWpt.Enabled = false;
            this.cRotWpt.Location = new System.Drawing.Point(261, 470);
            this.cRotWpt.Name = "cRotWpt";
            this.cRotWpt.Size = new System.Drawing.Size(93, 17);
            this.cRotWpt.TabIndex = 117;
            this.cRotWpt.Text = "Uses Rotation";
            this.cRotWpt.UseVisualStyleBackColor = true;
            // 
            // cDelayWpt
            // 
            this.cDelayWpt.AutoSize = true;
            this.cDelayWpt.Enabled = false;
            this.cDelayWpt.Location = new System.Drawing.Point(146, 485);
            this.cDelayWpt.Name = "cDelayWpt";
            this.cDelayWpt.Size = new System.Drawing.Size(80, 17);
            this.cDelayWpt.TabIndex = 116;
            this.cDelayWpt.Text = "Uses Delay";
            this.cDelayWpt.UseVisualStyleBackColor = true;
            // 
            // vWayAnim8
            // 
            this.vWayAnim8.Enabled = false;
            this.vWayAnim8.Location = new System.Drawing.Point(327, 449);
            this.vWayAnim8.Name = "vWayAnim8";
            this.vWayAnim8.Size = new System.Drawing.Size(20, 20);
            this.vWayAnim8.TabIndex = 115;
            this.vWayAnim8.Text = "0";
            // 
            // vWayAnim7
            // 
            this.vWayAnim7.Enabled = false;
            this.vWayAnim7.Location = new System.Drawing.Point(308, 449);
            this.vWayAnim7.Name = "vWayAnim7";
            this.vWayAnim7.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim7.TabIndex = 114;
            this.vWayAnim7.Text = "0";
            // 
            // vWayAnim6
            // 
            this.vWayAnim6.Enabled = false;
            this.vWayAnim6.Location = new System.Drawing.Point(288, 449);
            this.vWayAnim6.Name = "vWayAnim6";
            this.vWayAnim6.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim6.TabIndex = 113;
            this.vWayAnim6.Text = "0";
            // 
            // vWayAnim5
            // 
            this.vWayAnim5.Enabled = false;
            this.vWayAnim5.Location = new System.Drawing.Point(270, 449);
            this.vWayAnim5.Name = "vWayAnim5";
            this.vWayAnim5.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim5.TabIndex = 112;
            this.vWayAnim5.Text = "0";
            // 
            // vWayAnim4
            // 
            this.vWayAnim4.Enabled = false;
            this.vWayAnim4.Location = new System.Drawing.Point(251, 449);
            this.vWayAnim4.Name = "vWayAnim4";
            this.vWayAnim4.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim4.TabIndex = 111;
            this.vWayAnim4.Text = "0";
            // 
            // vWayAnim3
            // 
            this.vWayAnim3.Enabled = false;
            this.vWayAnim3.Location = new System.Drawing.Point(232, 449);
            this.vWayAnim3.Name = "vWayAnim3";
            this.vWayAnim3.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim3.TabIndex = 110;
            this.vWayAnim3.Text = "0";
            // 
            // vWayAnim2
            // 
            this.vWayAnim2.Enabled = false;
            this.vWayAnim2.Location = new System.Drawing.Point(212, 449);
            this.vWayAnim2.Name = "vWayAnim2";
            this.vWayAnim2.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim2.TabIndex = 109;
            this.vWayAnim2.Text = "0";
            // 
            // cAnimWpt
            // 
            this.cAnimWpt.AutoSize = true;
            this.cAnimWpt.Enabled = false;
            this.cAnimWpt.Location = new System.Drawing.Point(146, 470);
            this.cAnimWpt.Name = "cAnimWpt";
            this.cAnimWpt.Size = new System.Drawing.Size(118, 17);
            this.cAnimWpt.TabIndex = 108;
            this.cAnimWpt.Text = "Animated Waypoint";
            this.cAnimWpt.UseVisualStyleBackColor = true;
            // 
            // vWayAnim1
            // 
            this.vWayAnim1.Enabled = false;
            this.vWayAnim1.Location = new System.Drawing.Point(192, 449);
            this.vWayAnim1.Name = "vWayAnim1";
            this.vWayAnim1.Size = new System.Drawing.Size(24, 20);
            this.vWayAnim1.TabIndex = 107;
            this.vWayAnim1.Text = "0";
            // 
            // label146
            // 
            this.label146.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label146.Location = new System.Drawing.Point(142, 452);
            this.label146.Name = "label146";
            this.label146.Size = new System.Drawing.Size(62, 23);
            this.label146.TabIndex = 106;
            this.label146.Text = "Anim IDs:";
            // 
            // vMoneyIdx4
            // 
            this.vMoneyIdx4.Enabled = false;
            this.vMoneyIdx4.Location = new System.Drawing.Point(410, 482);
            this.vMoneyIdx4.Name = "vMoneyIdx4";
            this.vMoneyIdx4.Size = new System.Drawing.Size(40, 20);
            this.vMoneyIdx4.TabIndex = 105;
            this.vMoneyIdx4.Text = "0";
            // 
            // vMoneyIdx3
            // 
            this.vMoneyIdx3.Enabled = false;
            this.vMoneyIdx3.Location = new System.Drawing.Point(410, 466);
            this.vMoneyIdx3.Name = "vMoneyIdx3";
            this.vMoneyIdx3.Size = new System.Drawing.Size(40, 20);
            this.vMoneyIdx3.TabIndex = 104;
            this.vMoneyIdx3.Text = "0";
            // 
            // vMoneyIdx2
            // 
            this.vMoneyIdx2.Enabled = false;
            this.vMoneyIdx2.Location = new System.Drawing.Point(410, 450);
            this.vMoneyIdx2.Name = "vMoneyIdx2";
            this.vMoneyIdx2.Size = new System.Drawing.Size(40, 20);
            this.vMoneyIdx2.TabIndex = 103;
            this.vMoneyIdx2.Text = "0";
            // 
            // vMoneyIdx1
            // 
            this.vMoneyIdx1.Enabled = false;
            this.vMoneyIdx1.Location = new System.Drawing.Point(410, 434);
            this.vMoneyIdx1.Name = "vMoneyIdx1";
            this.vMoneyIdx1.Size = new System.Drawing.Size(40, 20);
            this.vMoneyIdx1.TabIndex = 102;
            this.vMoneyIdx1.Text = "0";
            // 
            // label197
            // 
            this.label197.Location = new System.Drawing.Point(362, 482);
            this.label197.Name = "label197";
            this.label197.Size = new System.Drawing.Size(64, 16);
            this.label197.TabIndex = 101;
            this.label197.Text = "Platinum:";
            // 
            // label196
            // 
            this.label196.Location = new System.Drawing.Point(362, 466);
            this.label196.Name = "label196";
            this.label196.Size = new System.Drawing.Size(64, 16);
            this.label196.TabIndex = 100;
            this.label196.Text = "Gold:";
            // 
            // label195
            // 
            this.label195.Location = new System.Drawing.Point(362, 450);
            this.label195.Name = "label195";
            this.label195.Size = new System.Drawing.Size(64, 16);
            this.label195.TabIndex = 99;
            this.label195.Text = "Silver:";
            // 
            // label194
            // 
            this.label194.Location = new System.Drawing.Point(362, 434);
            this.label194.Name = "label194";
            this.label194.Size = new System.Drawing.Size(64, 16);
            this.label194.TabIndex = 98;
            this.label194.Text = "Copper:";
            // 
            // pMoneyIdx
            // 
            this.pMoneyIdx.Location = new System.Drawing.Point(360, 408);
            this.pMoneyIdx.Name = "pMoneyIdx";
            this.pMoneyIdx.Size = new System.Drawing.Size(92, 18);
            this.pMoneyIdx.TabIndex = 97;
            this.pMoneyIdx.Text = "Money Index:";
            this.pMoneyIdx.CheckedChanged += new System.EventHandler(this.pMoneyIdx_CheckedChanged);
            // 
            // label193
            // 
            this.label193.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label193.Location = new System.Drawing.Point(0, 400);
            this.label193.Name = "label193";
            this.label193.Size = new System.Drawing.Size(456, 1);
            this.label193.TabIndex = 96;
            this.label193.Text = "label193";
            // 
            // label189
            // 
            this.label189.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label189.Location = new System.Drawing.Point(356, 400);
            this.label189.Name = "label189";
            this.label189.Size = new System.Drawing.Size(1, 136);
            this.label189.TabIndex = 95;
            this.label189.Text = "label189";
            // 
            // label192
            // 
            this.label192.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label192.Location = new System.Drawing.Point(312, 266);
            this.label192.Name = "label192";
            this.label192.Size = new System.Drawing.Size(136, 23);
            this.label192.TabIndex = 94;
            this.label192.Text = "0123456789ABCDEF";
            // 
            // label191
            // 
            this.label191.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label191.Location = new System.Drawing.Point(256, 197);
            this.label191.Name = "label191";
            this.label191.Size = new System.Drawing.Size(56, 64);
            this.label191.TabIndex = 93;
            this.label191.Text = " 0..15 16..31 32..47 48..63";
            // 
            // vAI64
            // 
            this.vAI64.Enabled = false;
            this.vAI64.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vAI64.Location = new System.Drawing.Point(312, 194);
            this.vAI64.MaxLength = 64;
            this.vAI64.Multiline = true;
            this.vAI64.Name = "vAI64";
            this.vAI64.Size = new System.Drawing.Size(136, 72);
            this.vAI64.TabIndex = 92;
            this.vAI64.Text = "0000000000000000000000000000000000000000000000000000000000000000";
            // 
            // pAI64
            // 
            this.pAI64.Location = new System.Drawing.Point(240, 170);
            this.pAI64.Name = "pAI64";
            this.pAI64.Size = new System.Drawing.Size(208, 24);
            this.pAI64.TabIndex = 91;
            this.pAI64.Text = "64-bit AI Flags (internal):";
            this.pAI64.CheckedChanged += new System.EventHandler(this.pAI64_CheckedChanged);
            // 
            // vTeleY
            // 
            this.vTeleY.Enabled = false;
            this.vTeleY.Location = new System.Drawing.Point(408, 296);
            this.vTeleY.Name = "vTeleY";
            this.vTeleY.Size = new System.Drawing.Size(44, 20);
            this.vTeleY.TabIndex = 90;
            this.vTeleY.Text = "0";
            // 
            // label190
            // 
            this.label190.Location = new System.Drawing.Point(384, 298);
            this.label190.Name = "label190";
            this.label190.Size = new System.Drawing.Size(24, 16);
            this.label190.TabIndex = 89;
            this.label190.Text = "Y=";
            // 
            // vTeleX
            // 
            this.vTeleX.Enabled = false;
            this.vTeleX.Location = new System.Drawing.Point(336, 296);
            this.vTeleX.Name = "vTeleX";
            this.vTeleX.Size = new System.Drawing.Size(44, 20);
            this.vTeleX.TabIndex = 88;
            this.vTeleX.Text = "0";
            // 
            // pTeleMap
            // 
            this.pTeleMap.Location = new System.Drawing.Point(240, 320);
            this.pTeleMap.Name = "pTeleMap";
            this.pTeleMap.Size = new System.Drawing.Size(96, 24);
            this.pTeleMap.TabIndex = 87;
            this.pTeleMap.Text = "Teleport Map:";
            this.pTeleMap.CheckedChanged += new System.EventHandler(this.pTeleMap_CheckedChanged);
            // 
            // vTeleMap
            // 
            this.vTeleMap.Enabled = false;
            this.vTeleMap.Location = new System.Drawing.Point(336, 320);
            this.vTeleMap.Name = "vTeleMap";
            this.vTeleMap.Size = new System.Drawing.Size(69, 20);
            this.vTeleMap.TabIndex = 86;
            this.vTeleMap.Text = "0";
            // 
            // pTeleDest
            // 
            this.pTeleDest.Location = new System.Drawing.Point(240, 296);
            this.pTeleDest.Name = "pTeleDest";
            this.pTeleDest.Size = new System.Drawing.Size(120, 24);
            this.pTeleDest.TabIndex = 85;
            this.pTeleDest.Text = "Teleport Dest X=:";
            this.pTeleDest.CheckedChanged += new System.EventHandler(this.pTeleDest_CheckedChanged);
            // 
            // vNightFlags
            // 
            this.vNightFlags.Enabled = false;
            this.vNightFlags.Location = new System.Drawing.Point(360, 353);
            this.vNightFlags.Name = "vNightFlags";
            this.vNightFlags.Size = new System.Drawing.Size(96, 20);
            this.vNightFlags.TabIndex = 82;
            this.vNightFlags.Text = "0";
            this.vNightFlags.Visible = false;
            // 
            // label188
            // 
            this.label188.Location = new System.Drawing.Point(353, 355);
            this.label188.Name = "label188";
            this.label188.Size = new System.Drawing.Size(112, 16);
            this.label188.TabIndex = 81;
            this.label188.Text = "Night unknown flags:";
            this.label188.Visible = false;
            // 
            // vDayFlags
            // 
            this.vDayFlags.Enabled = false;
            this.vDayFlags.Location = new System.Drawing.Point(360, 348);
            this.vDayFlags.Name = "vDayFlags";
            this.vDayFlags.Size = new System.Drawing.Size(96, 20);
            this.vDayFlags.TabIndex = 80;
            this.vDayFlags.Text = "0";
            this.vDayFlags.Visible = false;
            // 
            // label187
            // 
            this.label187.Location = new System.Drawing.Point(356, 348);
            this.label187.Name = "label187";
            this.label187.Size = new System.Drawing.Size(104, 16);
            this.label187.TabIndex = 79;
            this.label187.Text = "Day unknown flags:";
            this.label187.Visible = false;
            // 
            // pFaction
            // 
            this.pFaction.Location = new System.Drawing.Point(352, 352);
            this.pFaction.Name = "pFaction";
            this.pFaction.Size = new System.Drawing.Size(120, 24);
            this.pFaction.TabIndex = 65;
            this.pFaction.Text = "Faction ID:";
            this.pFaction.Visible = false;
            this.pFaction.CheckedChanged += new System.EventHandler(this.pFaction_CheckedChanged);
            // 
            // vFaction
            // 
            this.vFaction.Enabled = false;
            this.vFaction.Location = new System.Drawing.Point(359, 348);
            this.vFaction.Name = "vFaction";
            this.vFaction.Size = new System.Drawing.Size(88, 20);
            this.vFaction.TabIndex = 64;
            this.vFaction.Text = "0";
            this.vFaction.Visible = false;
            // 
            // pReach
            // 
            this.pReach.Location = new System.Drawing.Point(240, 40);
            this.pReach.Name = "pReach";
            this.pReach.Size = new System.Drawing.Size(120, 24);
            this.pReach.TabIndex = 63;
            this.pReach.Text = "Attack Reach:";
            this.pReach.CheckedChanged += new System.EventHandler(this.pReach_CheckedChanged);
            // 
            // vReach
            // 
            this.vReach.Enabled = false;
            this.vReach.Location = new System.Drawing.Point(360, 40);
            this.vReach.Name = "vReach";
            this.vReach.Size = new System.Drawing.Size(88, 20);
            this.vReach.TabIndex = 62;
            this.vReach.Text = "0";
            // 
            // btnWayDel
            // 
            this.btnWayDel.Location = new System.Drawing.Point(215, 503);
            this.btnWayDel.Name = "btnWayDel";
            this.btnWayDel.Size = new System.Drawing.Size(57, 23);
            this.btnWayDel.TabIndex = 61;
            this.btnWayDel.Text = "Delete";
            this.btnWayDel.Click += new System.EventHandler(this.btnWayDel_Click);
            // 
            // btnWayAdd
            // 
            this.btnWayAdd.Location = new System.Drawing.Point(152, 503);
            this.btnWayAdd.Name = "btnWayAdd";
            this.btnWayAdd.Size = new System.Drawing.Size(57, 23);
            this.btnWayAdd.TabIndex = 60;
            this.btnWayAdd.Text = "Add";
            this.btnWayAdd.Click += new System.EventHandler(this.btnWayAdd_Click);
            // 
            // vWayY
            // 
            this.vWayY.Location = new System.Drawing.Point(180, 429);
            this.vWayY.Name = "vWayY";
            this.vWayY.Size = new System.Drawing.Size(53, 20);
            this.vWayY.TabIndex = 59;
            this.vWayY.Text = "0";
            // 
            // vWayX
            // 
            this.vWayX.Location = new System.Drawing.Point(180, 406);
            this.vWayX.Name = "vWayX";
            this.vWayX.Size = new System.Drawing.Size(53, 20);
            this.vWayX.TabIndex = 58;
            this.vWayX.Text = "0";
            // 
            // label180
            // 
            this.label180.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label180.Location = new System.Drawing.Point(154, 429);
            this.label180.Name = "label180";
            this.label180.Size = new System.Drawing.Size(24, 23);
            this.label180.TabIndex = 57;
            this.label180.Text = "Y=";
            // 
            // label179
            // 
            this.label179.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label179.Location = new System.Drawing.Point(154, 408);
            this.label179.Name = "label179";
            this.label179.Size = new System.Drawing.Size(24, 23);
            this.label179.TabIndex = 56;
            this.label179.Text = "X=";
            // 
            // vWaypoints
            // 
            this.vWaypoints.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vWaypoints.HorizontalScrollbar = true;
            this.vWaypoints.ItemHeight = 16;
            this.vWaypoints.Location = new System.Drawing.Point(8, 424);
            this.vWaypoints.Name = "vWaypoints";
            this.vWaypoints.Size = new System.Drawing.Size(128, 100);
            this.vWaypoints.TabIndex = 55;
            this.vWaypoints.SelectedIndexChanged += new System.EventHandler(this.vWaypoints_SelectedIndexChanged);
            // 
            // pWaypoints
            // 
            this.pWaypoints.Location = new System.Drawing.Point(8, 400);
            this.pWaypoints.Name = "pWaypoints";
            this.pWaypoints.Size = new System.Drawing.Size(80, 24);
            this.pWaypoints.TabIndex = 54;
            this.pWaypoints.Text = "Waypoints:";
            this.pWaypoints.CheckedChanged += new System.EventHandler(this.pWaypoints_CheckedChanged);
            // 
            // vNpcInvSlot
            // 
            this.vNpcInvSlot.Location = new System.Drawing.Point(104, 296);
            this.vNpcInvSlot.Name = "vNpcInvSlot";
            this.vNpcInvSlot.Size = new System.Drawing.Size(88, 20);
            this.vNpcInvSlot.TabIndex = 53;
            this.vNpcInvSlot.Text = "0";
            // 
            // pNpcInvSlot
            // 
            this.pNpcInvSlot.Location = new System.Drawing.Point(16, 296);
            this.pNpcInvSlot.Name = "pNpcInvSlot";
            this.pNpcInvSlot.Size = new System.Drawing.Size(104, 16);
            this.pNpcInvSlot.TabIndex = 52;
            this.pNpcInvSlot.Text = "Specific slot:";
            this.pNpcInvSlot.CheckedChanged += new System.EventHandler(this.pNpcInvSlot_CheckedChanged);
            // 
            // tSubInv
            // 
            this.tSubInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tSubInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tSubInv.Location = new System.Drawing.Point(24, 376);
            this.tSubInv.Name = "tSubInv";
            this.tSubInv.Size = new System.Drawing.Size(424, 24);
            this.tSubInv.TabIndex = 51;
            this.tSubInv.Text = "SUBSTITUTE INVENTORY OBJECT NOT DEFINED";
            // 
            // vSubInv
            // 
            this.vSubInv.Location = new System.Drawing.Point(272, 350);
            this.vSubInv.Name = "vSubInv";
            this.vSubInv.Size = new System.Drawing.Size(75, 23);
            this.vSubInv.TabIndex = 50;
            this.vSubInv.Text = "Define";
            this.vSubInv.Click += new System.EventHandler(this.vSubInv_Click);
            // 
            // pSubInv
            // 
            this.pSubInv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pSubInv.Location = new System.Drawing.Point(8, 352);
            this.pSubInv.Name = "pSubInv";
            this.pSubInv.Size = new System.Drawing.Size(272, 16);
            this.pSubInv.TabIndex = 49;
            this.pSubInv.Text = "Substitute Inventory Container (for merchants):";
            this.pSubInv.CheckedChanged += new System.EventHandler(this.pSubInv_CheckedChanged);
            // 
            // vNpcInvenSource
            // 
            this.vNpcInvenSource.Location = new System.Drawing.Point(416, 8);
            this.vNpcInvenSource.Name = "vNpcInvenSource";
            this.vNpcInvenSource.Size = new System.Drawing.Size(32, 20);
            this.vNpcInvenSource.TabIndex = 48;
            this.vNpcInvenSource.Text = "0";
            // 
            // pNpcInvenSource
            // 
            this.pNpcInvenSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pNpcInvenSource.Location = new System.Drawing.Point(240, 10);
            this.pNpcInvenSource.Name = "pNpcInvenSource";
            this.pNpcInvenSource.Size = new System.Drawing.Size(170, 30);
            this.pNpcInvenSource.TabIndex = 47;
            this.pNpcInvenSource.Text = "InvenSource ID (Used for NPC loot inventory respawn):";
            this.pNpcInvenSource.CheckedChanged += new System.EventHandler(this.pNpcInvenSource_CheckedChanged);
            // 
            // tNpcMoneyAmt
            // 
            this.tNpcMoneyAmt.Location = new System.Drawing.Point(136, 270);
            this.tNpcMoneyAmt.Name = "tNpcMoneyAmt";
            this.tNpcMoneyAmt.Size = new System.Drawing.Size(88, 20);
            this.tNpcMoneyAmt.TabIndex = 46;
            this.tNpcMoneyAmt.Text = "1";
            // 
            // label40
            // 
            this.label40.Location = new System.Drawing.Point(16, 272);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(136, 16);
            this.label40.TabIndex = 45;
            this.label40.Text = "Amount (for money):";
            // 
            // btnNpcInvGUID
            // 
            this.btnNpcInvGUID.Location = new System.Drawing.Point(152, 10);
            this.btnNpcInvGUID.Name = "btnNpcInvGUID";
            this.btnNpcInvGUID.Size = new System.Drawing.Size(72, 24);
            this.btnNpcInvGUID.TabIndex = 44;
            this.btnNpcInvGUID.Text = "Show GUID";
            this.btnNpcInvGUID.Click += new System.EventHandler(this.btnNpcInvGUID_Click);
            // 
            // pNpcInvDel
            // 
            this.pNpcInvDel.Checked = true;
            this.pNpcInvDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pNpcInvDel.Location = new System.Drawing.Point(16, 312);
            this.pNpcInvDel.Name = "pNpcInvDel";
            this.pNpcInvDel.Size = new System.Drawing.Size(200, 24);
            this.pNpcInvDel.TabIndex = 43;
            this.pNpcInvDel.Text = "Delete files when removing items";
            // 
            // btnAddNpcInv2
            // 
            this.btnAddNpcInv2.Location = new System.Drawing.Point(88, 240);
            this.btnAddNpcInv2.Name = "btnAddNpcInv2";
            this.btnAddNpcInv2.Size = new System.Drawing.Size(64, 23);
            this.btnAddNpcInv2.TabIndex = 42;
            this.btnAddNpcInv2.Text = "Add Exist.";
            this.btnAddNpcInv2.Click += new System.EventHandler(this.btnAddNpcInv2_Click);
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Location = new System.Drawing.Point(8, 8);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(1, 337);
            this.label41.TabIndex = 41;
            this.label41.Text = "label41";
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Location = new System.Drawing.Point(232, 1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(1, 344);
            this.label42.TabIndex = 40;
            this.label42.Text = "label42";
            // 
            // label43
            // 
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label43.Location = new System.Drawing.Point(8, 344);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(224, 1);
            this.label43.TabIndex = 39;
            this.label43.Text = "label43";
            // 
            // btnRemoveNpcInv
            // 
            this.btnRemoveNpcInv.Location = new System.Drawing.Point(160, 240);
            this.btnRemoveNpcInv.Name = "btnRemoveNpcInv";
            this.btnRemoveNpcInv.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveNpcInv.TabIndex = 38;
            this.btnRemoveNpcInv.Text = "Remove";
            this.btnRemoveNpcInv.Click += new System.EventHandler(this.btnRemoveNpcInv_Click);
            // 
            // btnAddNpcInv
            // 
            this.btnAddNpcInv.Location = new System.Drawing.Point(16, 240);
            this.btnAddNpcInv.Name = "btnAddNpcInv";
            this.btnAddNpcInv.Size = new System.Drawing.Size(64, 23);
            this.btnAddNpcInv.TabIndex = 37;
            this.btnAddNpcInv.Text = "Add New";
            this.btnAddNpcInv.Click += new System.EventHandler(this.btnAddNpcInv_Click);
            // 
            // vNpcInv
            // 
            this.vNpcInv.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vNpcInv.ItemHeight = 14;
            this.vNpcInv.Location = new System.Drawing.Point(16, 32);
            this.vNpcInv.Name = "vNpcInv";
            this.vNpcInv.Size = new System.Drawing.Size(208, 158);
            this.vNpcInv.TabIndex = 36;
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Location = new System.Drawing.Point(8, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(224, 1);
            this.label44.TabIndex = 35;
            this.label44.Text = "label44";
            // 
            // pNpcInv
            // 
            this.pNpcInv.Location = new System.Drawing.Point(16, 8);
            this.pNpcInv.Name = "pNpcInv";
            this.pNpcInv.Size = new System.Drawing.Size(147, 24);
            this.pNpcInv.TabIndex = 34;
            this.pNpcInv.Text = "Inventory (Loot/Worn):";
            this.pNpcInv.CheckedChanged += new System.EventHandler(this.pNpcInv_CheckedChanged);
            // 
            // NpcInvProtos
            // 
            this.NpcInvProtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NpcInvProtos.Location = new System.Drawing.Point(16, 216);
            this.NpcInvProtos.Name = "NpcInvProtos";
            this.NpcInvProtos.Size = new System.Drawing.Size(208, 21);
            this.NpcInvProtos.Sorted = true;
            this.NpcInvProtos.TabIndex = 33;
            // 
            // d2
            // 
            this.d2.BackColor = System.Drawing.SystemColors.Control;
            this.d2.Controls.Add(this.label224);
            this.d2.Controls.Add(this.label223);
            this.d2.Controls.Add(this.label222);
            this.d2.Controls.Add(this.label221);
            this.d2.Controls.Add(this.label220);
            this.d2.Controls.Add(this.label219);
            this.d2.Controls.Add(this.vCHA);
            this.d2.Controls.Add(this.vWIS);
            this.d2.Controls.Add(this.vINT);
            this.d2.Controls.Add(this.vCON);
            this.d2.Controls.Add(this.vDEX);
            this.d2.Controls.Add(this.vSTR);
            this.d2.Controls.Add(this.pAbilities);
            this.d2.Controls.Add(this.vScoutOfsY);
            this.d2.Controls.Add(this.vScoutJP);
            this.d2.Controls.Add(this.vScoutOfsX);
            this.d2.Controls.Add(this.vScoutMap);
            this.d2.Controls.Add(this.vScoutY);
            this.d2.Controls.Add(this.label218);
            this.d2.Controls.Add(this.vScoutX);
            this.d2.Controls.Add(this.pScoutPoint);
            this.d2.Controls.Add(this.groupBox1);
            this.d2.Controls.Add(this.label210);
            this.d2.Controls.Add(this.vNightOfsY);
            this.d2.Controls.Add(this.vDayOfsY);
            this.d2.Controls.Add(this.vNightJP);
            this.d2.Controls.Add(this.vDayJP);
            this.d2.Controls.Add(this.label211);
            this.d2.Controls.Add(this.vNightOfsX);
            this.d2.Controls.Add(this.vDayOfsX);
            this.d2.Controls.Add(this.label208);
            this.d2.Controls.Add(this.label209);
            this.d2.Controls.Add(this.label186);
            this.d2.Controls.Add(this.vNightMap);
            this.d2.Controls.Add(this.vDayMap);
            this.d2.Controls.Add(this.label185);
            this.d2.Controls.Add(this.vNightY);
            this.d2.Controls.Add(this.vDayY);
            this.d2.Controls.Add(this.label184);
            this.d2.Controls.Add(this.label183);
            this.d2.Controls.Add(this.vNightX);
            this.d2.Controls.Add(this.vDayX);
            this.d2.Controls.Add(this.label182);
            this.d2.Controls.Add(this.label181);
            this.d2.Controls.Add(this.pStandpoints);
            this.d2.Controls.Add(this.btnDelFaction);
            this.d2.Controls.Add(this.btnAddFaction);
            this.d2.Controls.Add(this.vFactionsIdx);
            this.d2.Controls.Add(this.label206);
            this.d2.Controls.Add(this.vFactions);
            this.d2.Controls.Add(this.pFactions);
            this.d2.Location = new System.Drawing.Point(4, 22);
            this.d2.Name = "d2";
            this.d2.Size = new System.Drawing.Size(456, 534);
            this.d2.TabIndex = 14;
            this.d2.Text = "NPC/Critters 2";
            // 
            // label224
            // 
            this.label224.AutoSize = true;
            this.label224.Location = new System.Drawing.Point(330, 290);
            this.label224.Name = "label224";
            this.label224.Size = new System.Drawing.Size(29, 13);
            this.label224.TabIndex = 124;
            this.label224.Text = "CHA";
            // 
            // label223
            // 
            this.label223.AutoSize = true;
            this.label223.Location = new System.Drawing.Point(283, 290);
            this.label223.Name = "label223";
            this.label223.Size = new System.Drawing.Size(28, 13);
            this.label223.TabIndex = 123;
            this.label223.Text = "WIS";
            // 
            // label222
            // 
            this.label222.AutoSize = true;
            this.label222.Location = new System.Drawing.Point(233, 290);
            this.label222.Name = "label222";
            this.label222.Size = new System.Drawing.Size(25, 13);
            this.label222.TabIndex = 122;
            this.label222.Text = "INT";
            // 
            // label221
            // 
            this.label221.AutoSize = true;
            this.label221.Location = new System.Drawing.Point(180, 290);
            this.label221.Name = "label221";
            this.label221.Size = new System.Drawing.Size(30, 13);
            this.label221.TabIndex = 121;
            this.label221.Text = "CON";
            // 
            // label220
            // 
            this.label220.AutoSize = true;
            this.label220.Location = new System.Drawing.Point(127, 290);
            this.label220.Name = "label220";
            this.label220.Size = new System.Drawing.Size(29, 13);
            this.label220.TabIndex = 120;
            this.label220.Text = "DEX";
            // 
            // label219
            // 
            this.label219.AutoSize = true;
            this.label219.Location = new System.Drawing.Point(81, 290);
            this.label219.Name = "label219";
            this.label219.Size = new System.Drawing.Size(29, 13);
            this.label219.TabIndex = 119;
            this.label219.Text = "STR";
            // 
            // vCHA
            // 
            this.vCHA.Enabled = false;
            this.vCHA.Location = new System.Drawing.Point(325, 312);
            this.vCHA.Name = "vCHA";
            this.vCHA.Size = new System.Drawing.Size(44, 20);
            this.vCHA.TabIndex = 118;
            this.vCHA.Text = "0";
            // 
            // vWIS
            // 
            this.vWIS.Enabled = false;
            this.vWIS.Location = new System.Drawing.Point(275, 312);
            this.vWIS.Name = "vWIS";
            this.vWIS.Size = new System.Drawing.Size(44, 20);
            this.vWIS.TabIndex = 117;
            this.vWIS.Text = "0";
            // 
            // vINT
            // 
            this.vINT.Enabled = false;
            this.vINT.Location = new System.Drawing.Point(225, 312);
            this.vINT.Name = "vINT";
            this.vINT.Size = new System.Drawing.Size(44, 20);
            this.vINT.TabIndex = 116;
            this.vINT.Text = "0";
            // 
            // vCON
            // 
            this.vCON.Enabled = false;
            this.vCON.Location = new System.Drawing.Point(175, 312);
            this.vCON.Name = "vCON";
            this.vCON.Size = new System.Drawing.Size(44, 20);
            this.vCON.TabIndex = 115;
            this.vCON.Text = "0";
            // 
            // vDEX
            // 
            this.vDEX.Enabled = false;
            this.vDEX.Location = new System.Drawing.Point(125, 312);
            this.vDEX.Name = "vDEX";
            this.vDEX.Size = new System.Drawing.Size(44, 20);
            this.vDEX.TabIndex = 114;
            this.vDEX.Text = "0";
            // 
            // vSTR
            // 
            this.vSTR.Enabled = false;
            this.vSTR.Location = new System.Drawing.Point(75, 312);
            this.vSTR.Name = "vSTR";
            this.vSTR.Size = new System.Drawing.Size(44, 20);
            this.vSTR.TabIndex = 113;
            this.vSTR.Text = "0";
            // 
            // pAbilities
            // 
            this.pAbilities.Location = new System.Drawing.Point(10, 310);
            this.pAbilities.Name = "pAbilities";
            this.pAbilities.Size = new System.Drawing.Size(88, 24);
            this.pAbilities.TabIndex = 112;
            this.pAbilities.Text = "Abilities:";
            this.pAbilities.CheckedChanged += new System.EventHandler(this.pAbilities_CheckedChanged);
            // 
            // vScoutOfsY
            // 
            this.vScoutOfsY.Enabled = false;
            this.vScoutOfsY.Location = new System.Drawing.Point(268, 419);
            this.vScoutOfsY.Name = "vScoutOfsY";
            this.vScoutOfsY.Size = new System.Drawing.Size(44, 20);
            this.vScoutOfsY.TabIndex = 111;
            this.vScoutOfsY.Text = "0";
            // 
            // vScoutJP
            // 
            this.vScoutJP.Enabled = false;
            this.vScoutJP.Location = new System.Drawing.Point(333, 419);
            this.vScoutJP.Name = "vScoutJP";
            this.vScoutJP.Size = new System.Drawing.Size(44, 20);
            this.vScoutJP.TabIndex = 110;
            this.vScoutJP.Text = "-1";
            // 
            // vScoutOfsX
            // 
            this.vScoutOfsX.Enabled = false;
            this.vScoutOfsX.Location = new System.Drawing.Point(209, 419);
            this.vScoutOfsX.Name = "vScoutOfsX";
            this.vScoutOfsX.Size = new System.Drawing.Size(44, 20);
            this.vScoutOfsX.TabIndex = 109;
            this.vScoutOfsX.Text = "0";
            // 
            // vScoutMap
            // 
            this.vScoutMap.Enabled = false;
            this.vScoutMap.Location = new System.Drawing.Point(411, 419);
            this.vScoutMap.Name = "vScoutMap";
            this.vScoutMap.Size = new System.Drawing.Size(44, 20);
            this.vScoutMap.TabIndex = 108;
            this.vScoutMap.Text = "0";
            // 
            // vScoutY
            // 
            this.vScoutY.Enabled = false;
            this.vScoutY.Location = new System.Drawing.Point(156, 419);
            this.vScoutY.Name = "vScoutY";
            this.vScoutY.Size = new System.Drawing.Size(44, 20);
            this.vScoutY.TabIndex = 107;
            this.vScoutY.Text = "0";
            // 
            // label218
            // 
            this.label218.Location = new System.Drawing.Point(132, 419);
            this.label218.Name = "label218";
            this.label218.Size = new System.Drawing.Size(24, 16);
            this.label218.TabIndex = 106;
            this.label218.Text = "Y=";
            // 
            // vScoutX
            // 
            this.vScoutX.Enabled = false;
            this.vScoutX.Location = new System.Drawing.Point(84, 419);
            this.vScoutX.Name = "vScoutX";
            this.vScoutX.Size = new System.Drawing.Size(44, 20);
            this.vScoutX.TabIndex = 105;
            this.vScoutX.Text = "0";
            // 
            // pScoutPoint
            // 
            this.pScoutPoint.AutoSize = true;
            this.pScoutPoint.Location = new System.Drawing.Point(10, 419);
            this.pScoutPoint.Name = "pScoutPoint";
            this.pScoutPoint.Size = new System.Drawing.Size(70, 17);
            this.pScoutPoint.TabIndex = 104;
            this.pScoutPoint.Text = "Scout X=";
            this.pScoutPoint.UseVisualStyleBackColor = true;
            this.pScoutPoint.CheckedChanged += new System.EventHandler(this.pScoutPoint_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkCleanScripts);
            this.groupBox1.Controls.Add(this.btnCleanD20States);
            this.groupBox1.Controls.Add(this.label212);
            this.groupBox1.Location = new System.Drawing.Point(183, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 274);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Internal d20 states";
            // 
            // chkCleanScripts
            // 
            this.chkCleanScripts.AutoSize = true;
            this.chkCleanScripts.Location = new System.Drawing.Point(70, 136);
            this.chkCleanScripts.Name = "chkCleanScripts";
            this.chkCleanScripts.Size = new System.Drawing.Size(127, 17);
            this.chkCleanScripts.TabIndex = 2;
            this.chkCleanScripts.Text = "Clean script overrides";
            this.chkCleanScripts.UseVisualStyleBackColor = true;
            // 
            // btnCleanD20States
            // 
            this.btnCleanD20States.Location = new System.Drawing.Point(26, 159);
            this.btnCleanD20States.Name = "btnCleanD20States";
            this.btnCleanD20States.Size = new System.Drawing.Size(215, 23);
            this.btnCleanD20States.TabIndex = 1;
            this.btnCleanD20States.Text = "Clean the Internal Hardcoded Info";
            this.btnCleanD20States.UseVisualStyleBackColor = true;
            this.btnCleanD20States.Click += new System.EventHandler(this.btnCleanD20States_Click);
            // 
            // label212
            // 
            this.label212.Location = new System.Drawing.Point(6, 23);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(260, 111);
            this.label212.TabIndex = 0;
            this.label212.Text = resources.GetString("label212.Text");
            this.label212.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label210
            // 
            this.label210.Location = new System.Drawing.Point(127, 466);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(218, 60);
            this.label210.TabIndex = 102;
            this.label210.Text = "If a jump point is set to -1, it is not defined, and a standpoint is used as defi" +
                "ned above (per parameters). Otherwise the jumppoint is loaded from JUMPPOINT.TAB" +
                ".";
            this.label210.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vNightOfsY
            // 
            this.vNightOfsY.Enabled = false;
            this.vNightOfsY.Location = new System.Drawing.Point(268, 400);
            this.vNightOfsY.Name = "vNightOfsY";
            this.vNightOfsY.Size = new System.Drawing.Size(44, 20);
            this.vNightOfsY.TabIndex = 101;
            this.vNightOfsY.Text = "0";
            // 
            // vDayOfsY
            // 
            this.vDayOfsY.Enabled = false;
            this.vDayOfsY.Location = new System.Drawing.Point(268, 384);
            this.vDayOfsY.Name = "vDayOfsY";
            this.vDayOfsY.Size = new System.Drawing.Size(44, 20);
            this.vDayOfsY.TabIndex = 100;
            this.vDayOfsY.Text = "0";
            // 
            // vNightJP
            // 
            this.vNightJP.Enabled = false;
            this.vNightJP.Location = new System.Drawing.Point(333, 400);
            this.vNightJP.Name = "vNightJP";
            this.vNightJP.Size = new System.Drawing.Size(44, 20);
            this.vNightJP.TabIndex = 99;
            this.vNightJP.Text = "-1";
            // 
            // vDayJP
            // 
            this.vDayJP.Enabled = false;
            this.vDayJP.Location = new System.Drawing.Point(333, 384);
            this.vDayJP.Name = "vDayJP";
            this.vDayJP.Size = new System.Drawing.Size(44, 20);
            this.vDayJP.TabIndex = 98;
            this.vDayJP.Text = "-1";
            // 
            // label211
            // 
            this.label211.Location = new System.Drawing.Point(330, 368);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(78, 16);
            this.label211.TabIndex = 96;
            this.label211.Text = "Jump Points:";
            // 
            // vNightOfsX
            // 
            this.vNightOfsX.Enabled = false;
            this.vNightOfsX.Location = new System.Drawing.Point(209, 400);
            this.vNightOfsX.Name = "vNightOfsX";
            this.vNightOfsX.Size = new System.Drawing.Size(44, 20);
            this.vNightOfsX.TabIndex = 95;
            this.vNightOfsX.Text = "0";
            // 
            // vDayOfsX
            // 
            this.vDayOfsX.Enabled = false;
            this.vDayOfsX.Location = new System.Drawing.Point(209, 384);
            this.vDayOfsX.Name = "vDayOfsX";
            this.vDayOfsX.Size = new System.Drawing.Size(44, 20);
            this.vDayOfsX.TabIndex = 94;
            this.vDayOfsX.Text = "0";
            // 
            // label208
            // 
            this.label208.Location = new System.Drawing.Point(268, 368);
            this.label208.Name = "label208";
            this.label208.Size = new System.Drawing.Size(56, 16);
            this.label208.TabIndex = 93;
            this.label208.Text = "Y Offsets:";
            // 
            // label209
            // 
            this.label209.Location = new System.Drawing.Point(206, 368);
            this.label209.Name = "label209";
            this.label209.Size = new System.Drawing.Size(56, 16);
            this.label209.TabIndex = 92;
            this.label209.Text = "X Offsets:";
            // 
            // label186
            // 
            this.label186.Location = new System.Drawing.Point(127, 450);
            this.label186.Name = "label186";
            this.label186.Size = new System.Drawing.Size(208, 16);
            this.label186.TabIndex = 91;
            this.label186.Text = "(Maps are given per MapList.mes)";
            this.label186.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // vNightMap
            // 
            this.vNightMap.Enabled = false;
            this.vNightMap.Location = new System.Drawing.Point(411, 400);
            this.vNightMap.Name = "vNightMap";
            this.vNightMap.Size = new System.Drawing.Size(44, 20);
            this.vNightMap.TabIndex = 90;
            this.vNightMap.Text = "0";
            // 
            // vDayMap
            // 
            this.vDayMap.Enabled = false;
            this.vDayMap.Location = new System.Drawing.Point(411, 384);
            this.vDayMap.Name = "vDayMap";
            this.vDayMap.Size = new System.Drawing.Size(44, 20);
            this.vDayMap.TabIndex = 89;
            this.vDayMap.Text = "0";
            // 
            // label185
            // 
            this.label185.Location = new System.Drawing.Point(411, 368);
            this.label185.Name = "label185";
            this.label185.Size = new System.Drawing.Size(64, 16);
            this.label185.TabIndex = 88;
            this.label185.Text = "Map IDs:";
            // 
            // vNightY
            // 
            this.vNightY.Enabled = false;
            this.vNightY.Location = new System.Drawing.Point(156, 400);
            this.vNightY.Name = "vNightY";
            this.vNightY.Size = new System.Drawing.Size(44, 20);
            this.vNightY.TabIndex = 87;
            this.vNightY.Text = "0";
            // 
            // vDayY
            // 
            this.vDayY.Enabled = false;
            this.vDayY.Location = new System.Drawing.Point(156, 384);
            this.vDayY.Name = "vDayY";
            this.vDayY.Size = new System.Drawing.Size(44, 20);
            this.vDayY.TabIndex = 86;
            this.vDayY.Text = "0";
            // 
            // label184
            // 
            this.label184.Location = new System.Drawing.Point(132, 400);
            this.label184.Name = "label184";
            this.label184.Size = new System.Drawing.Size(24, 16);
            this.label184.TabIndex = 85;
            this.label184.Text = "Y=";
            // 
            // label183
            // 
            this.label183.Location = new System.Drawing.Point(132, 384);
            this.label183.Name = "label183";
            this.label183.Size = new System.Drawing.Size(24, 16);
            this.label183.TabIndex = 84;
            this.label183.Text = "Y=";
            // 
            // vNightX
            // 
            this.vNightX.Enabled = false;
            this.vNightX.Location = new System.Drawing.Point(84, 400);
            this.vNightX.Name = "vNightX";
            this.vNightX.Size = new System.Drawing.Size(44, 20);
            this.vNightX.TabIndex = 83;
            this.vNightX.Text = "0";
            // 
            // vDayX
            // 
            this.vDayX.Enabled = false;
            this.vDayX.Location = new System.Drawing.Point(84, 384);
            this.vDayX.Name = "vDayX";
            this.vDayX.Size = new System.Drawing.Size(44, 20);
            this.vDayX.TabIndex = 82;
            this.vDayX.Text = "0";
            // 
            // label182
            // 
            this.label182.Location = new System.Drawing.Point(36, 400);
            this.label182.Name = "label182";
            this.label182.Size = new System.Drawing.Size(56, 16);
            this.label182.TabIndex = 81;
            this.label182.Text = "Night X=";
            // 
            // label181
            // 
            this.label181.Location = new System.Drawing.Point(36, 384);
            this.label181.Name = "label181";
            this.label181.Size = new System.Drawing.Size(56, 16);
            this.label181.TabIndex = 80;
            this.label181.Text = "Day X=";
            // 
            // pStandpoints
            // 
            this.pStandpoints.Location = new System.Drawing.Point(10, 360);
            this.pStandpoints.Name = "pStandpoints";
            this.pStandpoints.Size = new System.Drawing.Size(88, 24);
            this.pStandpoints.TabIndex = 79;
            this.pStandpoints.Text = "Standpoints:";
            this.pStandpoints.CheckedChanged += new System.EventHandler(this.pStandpoints_CheckedChanged);
            // 
            // btnDelFaction
            // 
            this.btnDelFaction.Enabled = false;
            this.btnDelFaction.Location = new System.Drawing.Point(88, 263);
            this.btnDelFaction.Name = "btnDelFaction";
            this.btnDelFaction.Size = new System.Drawing.Size(75, 23);
            this.btnDelFaction.TabIndex = 5;
            this.btnDelFaction.Text = "Del Faction";
            this.btnDelFaction.UseVisualStyleBackColor = true;
            this.btnDelFaction.Click += new System.EventHandler(this.btnDelFaction_Click);
            // 
            // btnAddFaction
            // 
            this.btnAddFaction.Enabled = false;
            this.btnAddFaction.Location = new System.Drawing.Point(10, 263);
            this.btnAddFaction.Name = "btnAddFaction";
            this.btnAddFaction.Size = new System.Drawing.Size(75, 23);
            this.btnAddFaction.TabIndex = 4;
            this.btnAddFaction.Text = "Add Faction";
            this.btnAddFaction.UseVisualStyleBackColor = true;
            this.btnAddFaction.Click += new System.EventHandler(this.btnAddFaction_Click);
            // 
            // vFactionsIdx
            // 
            this.vFactionsIdx.Enabled = false;
            this.vFactionsIdx.Location = new System.Drawing.Point(63, 237);
            this.vFactionsIdx.Name = "vFactionsIdx";
            this.vFactionsIdx.Size = new System.Drawing.Size(100, 20);
            this.vFactionsIdx.TabIndex = 3;
            this.vFactionsIdx.Text = "0";
            // 
            // label206
            // 
            this.label206.AutoSize = true;
            this.label206.Location = new System.Drawing.Point(7, 240);
            this.label206.Name = "label206";
            this.label206.Size = new System.Drawing.Size(59, 13);
            this.label206.TabIndex = 2;
            this.label206.Text = "Faction ID:";
            // 
            // vFactions
            // 
            this.vFactions.Enabled = false;
            this.vFactions.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.vFactions.FormattingEnabled = true;
            this.vFactions.ItemHeight = 16;
            this.vFactions.Location = new System.Drawing.Point(10, 35);
            this.vFactions.Name = "vFactions";
            this.vFactions.Size = new System.Drawing.Size(153, 196);
            this.vFactions.TabIndex = 1;
            // 
            // pFactions
            // 
            this.pFactions.AutoSize = true;
            this.pFactions.Location = new System.Drawing.Point(10, 12);
            this.pFactions.Name = "pFactions";
            this.pFactions.Size = new System.Drawing.Size(69, 17);
            this.pFactions.TabIndex = 0;
            this.pFactions.Text = "Factions:";
            this.pFactions.UseVisualStyleBackColor = true;
            this.pFactions.CheckedChanged += new System.EventHandler(this.pFactions_CheckedChanged);
            // 
            // d1
            // 
            this.d1.BackColor = System.Drawing.SystemColors.Control;
            this.d1.Controls.Add(this.label217);
            this.d1.Controls.Add(this.vNPCGRate8);
            this.d1.Controls.Add(this.vNPCGRate7);
            this.d1.Controls.Add(this.vNPCGRate6);
            this.d1.Controls.Add(this.vNPCGRate5);
            this.d1.Controls.Add(this.vNPCGRate4);
            this.d1.Controls.Add(this.vNPCGRate3);
            this.d1.Controls.Add(this.vNPCGRate2);
            this.d1.Controls.Add(this.vNPCGRate1);
            this.d1.Controls.Add(this.label216);
            this.d1.Controls.Add(this.vNPCGIgnoreTotal);
            this.d1.Controls.Add(this.vNPCGSpawnTotal);
            this.d1.Controls.Add(this.label215);
            this.d1.Controls.Add(this.vNPCGSpawnConcurrent);
            this.d1.Controls.Add(this.label214);
            this.d1.Controls.Add(this.vNPCGSpawnAll);
            this.d1.Controls.Add(this.vNPCGActive);
            this.d1.Controls.Add(this.vNPCGNight);
            this.d1.Controls.Add(this.vNPCGDay);
            this.d1.Controls.Add(this.label213);
            this.d1.Controls.Add(this.pNPCGenData);
            this.d1.Controls.Add(this.vNPCGenData);
            this.d1.Location = new System.Drawing.Point(4, 22);
            this.d1.Name = "d1";
            this.d1.Size = new System.Drawing.Size(456, 534);
            this.d1.TabIndex = 15;
            this.d1.Text = "NPC Generators";
            // 
            // label217
            // 
            this.label217.Location = new System.Drawing.Point(33, 459);
            this.label217.Name = "label217";
            this.label217.Size = new System.Drawing.Size(420, 45);
            this.label217.TabIndex = 149;
            this.label217.Text = "NOTE: You need to set the ONF_GENERATOR flag in order to use the NPC as a generat" +
                "or. NPC_GENERATOR_RATE* flags will be automatically set as you modify the Spawn " +
                "Beat Rate here.";
            // 
            // vNPCGRate8
            // 
            this.vNPCGRate8.AutoSize = true;
            this.vNPCGRate8.Enabled = false;
            this.vNPCGRate8.Location = new System.Drawing.Point(125, 411);
            this.vNPCGRate8.Name = "vNPCGRate8";
            this.vNPCGRate8.Size = new System.Drawing.Size(47, 17);
            this.vNPCGRate8.TabIndex = 148;
            this.vNPCGRate8.TabStop = true;
            this.vNPCGRate8.Text = "Year";
            this.vNPCGRate8.UseVisualStyleBackColor = true;
            this.vNPCGRate8.CheckedChanged += new System.EventHandler(this.vNPCGRate8_CheckedChanged);
            // 
            // vNPCGRate7
            // 
            this.vNPCGRate7.AutoSize = true;
            this.vNPCGRate7.Enabled = false;
            this.vNPCGRate7.Location = new System.Drawing.Point(125, 388);
            this.vNPCGRate7.Name = "vNPCGRate7";
            this.vNPCGRate7.Size = new System.Drawing.Size(55, 17);
            this.vNPCGRate7.TabIndex = 147;
            this.vNPCGRate7.TabStop = true;
            this.vNPCGRate7.Text = "Month";
            this.vNPCGRate7.UseVisualStyleBackColor = true;
            this.vNPCGRate7.CheckedChanged += new System.EventHandler(this.vNPCGRate7_CheckedChanged);
            // 
            // vNPCGRate6
            // 
            this.vNPCGRate6.AutoSize = true;
            this.vNPCGRate6.Enabled = false;
            this.vNPCGRate6.Location = new System.Drawing.Point(125, 365);
            this.vNPCGRate6.Name = "vNPCGRate6";
            this.vNPCGRate6.Size = new System.Drawing.Size(54, 17);
            this.vNPCGRate6.TabIndex = 146;
            this.vNPCGRate6.TabStop = true;
            this.vNPCGRate6.Text = "Week";
            this.vNPCGRate6.UseVisualStyleBackColor = true;
            this.vNPCGRate6.CheckedChanged += new System.EventHandler(this.vNPCGRate6_CheckedChanged);
            // 
            // vNPCGRate5
            // 
            this.vNPCGRate5.AutoSize = true;
            this.vNPCGRate5.Enabled = false;
            this.vNPCGRate5.Location = new System.Drawing.Point(125, 343);
            this.vNPCGRate5.Name = "vNPCGRate5";
            this.vNPCGRate5.Size = new System.Drawing.Size(44, 17);
            this.vNPCGRate5.TabIndex = 145;
            this.vNPCGRate5.TabStop = true;
            this.vNPCGRate5.Text = "Day";
            this.vNPCGRate5.UseVisualStyleBackColor = true;
            this.vNPCGRate5.CheckedChanged += new System.EventHandler(this.vNPCGRate5_CheckedChanged);
            // 
            // vNPCGRate4
            // 
            this.vNPCGRate4.AutoSize = true;
            this.vNPCGRate4.Enabled = false;
            this.vNPCGRate4.Location = new System.Drawing.Point(125, 320);
            this.vNPCGRate4.Name = "vNPCGRate4";
            this.vNPCGRate4.Size = new System.Drawing.Size(48, 17);
            this.vNPCGRate4.TabIndex = 144;
            this.vNPCGRate4.TabStop = true;
            this.vNPCGRate4.Text = "Hour";
            this.vNPCGRate4.UseVisualStyleBackColor = true;
            this.vNPCGRate4.CheckedChanged += new System.EventHandler(this.vNPCGRate4_CheckedChanged);
            // 
            // vNPCGRate3
            // 
            this.vNPCGRate3.AutoSize = true;
            this.vNPCGRate3.Enabled = false;
            this.vNPCGRate3.Location = new System.Drawing.Point(125, 297);
            this.vNPCGRate3.Name = "vNPCGRate3";
            this.vNPCGRate3.Size = new System.Drawing.Size(57, 17);
            this.vNPCGRate3.TabIndex = 143;
            this.vNPCGRate3.TabStop = true;
            this.vNPCGRate3.Text = "Minute";
            this.vNPCGRate3.UseVisualStyleBackColor = true;
            this.vNPCGRate3.CheckedChanged += new System.EventHandler(this.vNPCGRate3_CheckedChanged);
            // 
            // vNPCGRate2
            // 
            this.vNPCGRate2.AutoSize = true;
            this.vNPCGRate2.Enabled = false;
            this.vNPCGRate2.Location = new System.Drawing.Point(125, 274);
            this.vNPCGRate2.Name = "vNPCGRate2";
            this.vNPCGRate2.Size = new System.Drawing.Size(88, 17);
            this.vNPCGRate2.TabIndex = 142;
            this.vNPCGRate2.TabStop = true;
            this.vNPCGRate2.Text = "Half a Minute";
            this.vNPCGRate2.UseVisualStyleBackColor = true;
            this.vNPCGRate2.CheckedChanged += new System.EventHandler(this.vNPCGRate2_CheckedChanged);
            // 
            // vNPCGRate1
            // 
            this.vNPCGRate1.AutoSize = true;
            this.vNPCGRate1.Checked = true;
            this.vNPCGRate1.Enabled = false;
            this.vNPCGRate1.Location = new System.Drawing.Point(125, 251);
            this.vNPCGRate1.Name = "vNPCGRate1";
            this.vNPCGRate1.Size = new System.Drawing.Size(62, 17);
            this.vNPCGRate1.TabIndex = 141;
            this.vNPCGRate1.TabStop = true;
            this.vNPCGRate1.Text = "Second";
            this.vNPCGRate1.UseVisualStyleBackColor = true;
            this.vNPCGRate1.CheckedChanged += new System.EventHandler(this.vNPCGRate1_CheckedChanged);
            // 
            // label216
            // 
            this.label216.AutoSize = true;
            this.label216.Location = new System.Drawing.Point(25, 253);
            this.label216.Name = "label216";
            this.label216.Size = new System.Drawing.Size(94, 13);
            this.label216.TabIndex = 140;
            this.label216.Text = "Spawn Beat Rate:";
            // 
            // vNPCGIgnoreTotal
            // 
            this.vNPCGIgnoreTotal.AutoSize = true;
            this.vNPCGIgnoreTotal.Enabled = false;
            this.vNPCGIgnoreTotal.Location = new System.Drawing.Point(267, 198);
            this.vNPCGIgnoreTotal.Name = "vNPCGIgnoreTotal";
            this.vNPCGIgnoreTotal.Size = new System.Drawing.Size(83, 17);
            this.vNPCGIgnoreTotal.TabIndex = 139;
            this.vNPCGIgnoreTotal.Text = "Ignore Total";
            this.vNPCGIgnoreTotal.UseVisualStyleBackColor = true;
            // 
            // vNPCGSpawnTotal
            // 
            this.vNPCGSpawnTotal.Enabled = false;
            this.vNPCGSpawnTotal.Location = new System.Drawing.Point(209, 196);
            this.vNPCGSpawnTotal.Name = "vNPCGSpawnTotal";
            this.vNPCGSpawnTotal.Size = new System.Drawing.Size(52, 20);
            this.vNPCGSpawnTotal.TabIndex = 138;
            this.vNPCGSpawnTotal.Text = "1";
            // 
            // label215
            // 
            this.label215.AutoSize = true;
            this.label215.Location = new System.Drawing.Point(25, 199);
            this.label215.Name = "label215";
            this.label215.Size = new System.Drawing.Size(156, 13);
            this.label215.TabIndex = 137;
            this.label215.Text = "Total Spawn Maximum (1..127):";
            // 
            // vNPCGSpawnConcurrent
            // 
            this.vNPCGSpawnConcurrent.Enabled = false;
            this.vNPCGSpawnConcurrent.Location = new System.Drawing.Point(209, 170);
            this.vNPCGSpawnConcurrent.Name = "vNPCGSpawnConcurrent";
            this.vNPCGSpawnConcurrent.Size = new System.Drawing.Size(52, 20);
            this.vNPCGSpawnConcurrent.TabIndex = 136;
            this.vNPCGSpawnConcurrent.Text = "1";
            // 
            // label214
            // 
            this.label214.AutoSize = true;
            this.label214.Location = new System.Drawing.Point(25, 173);
            this.label214.Name = "label214";
            this.label214.Size = new System.Drawing.Size(178, 13);
            this.label214.TabIndex = 135;
            this.label214.Text = "Concurrent Spawn Maximum (1..31):";
            // 
            // vNPCGSpawnAll
            // 
            this.vNPCGSpawnAll.AutoSize = true;
            this.vNPCGSpawnAll.Enabled = false;
            this.vNPCGSpawnAll.Location = new System.Drawing.Point(28, 144);
            this.vNPCGSpawnAll.Name = "vNPCGSpawnAll";
            this.vNPCGSpawnAll.Size = new System.Drawing.Size(266, 17);
            this.vNPCGSpawnAll.TabIndex = 134;
            this.vNPCGSpawnAll.Text = "Spawn All (if unchecked, spawn only one per beat)";
            this.vNPCGSpawnAll.UseVisualStyleBackColor = true;
            // 
            // vNPCGActive
            // 
            this.vNPCGActive.AutoSize = true;
            this.vNPCGActive.Enabled = false;
            this.vNPCGActive.Location = new System.Drawing.Point(28, 121);
            this.vNPCGActive.Name = "vNPCGActive";
            this.vNPCGActive.Size = new System.Drawing.Size(110, 17);
            this.vNPCGActive.TabIndex = 133;
            this.vNPCGActive.Text = "Active On-Screen";
            this.vNPCGActive.UseVisualStyleBackColor = true;
            // 
            // vNPCGNight
            // 
            this.vNPCGNight.AutoSize = true;
            this.vNPCGNight.Enabled = false;
            this.vNPCGNight.Location = new System.Drawing.Point(28, 98);
            this.vNPCGNight.Name = "vNPCGNight";
            this.vNPCGNight.Size = new System.Drawing.Size(115, 17);
            this.vNPCGNight.TabIndex = 132;
            this.vNPCGNight.Text = "Active at Nighttime";
            this.vNPCGNight.UseVisualStyleBackColor = true;
            // 
            // vNPCGDay
            // 
            this.vNPCGDay.AutoSize = true;
            this.vNPCGDay.Enabled = false;
            this.vNPCGDay.Location = new System.Drawing.Point(28, 76);
            this.vNPCGDay.Name = "vNPCGDay";
            this.vNPCGDay.Size = new System.Drawing.Size(109, 17);
            this.vNPCGDay.TabIndex = 131;
            this.vNPCGDay.Text = "Active at Daytime";
            this.vNPCGDay.UseVisualStyleBackColor = true;
            // 
            // label213
            // 
            this.label213.AutoSize = true;
            this.label213.Location = new System.Drawing.Point(25, 54);
            this.label213.Name = "label213";
            this.label213.Size = new System.Drawing.Size(110, 13);
            this.label213.TabIndex = 130;
            this.label213.Text = "Generator ID (0..255):";
            // 
            // pNPCGenData
            // 
            this.pNPCGenData.Location = new System.Drawing.Point(15, 10);
            this.pNPCGenData.Name = "pNPCGenData";
            this.pNPCGenData.Size = new System.Drawing.Size(157, 35);
            this.pNPCGenData.TabIndex = 129;
            this.pNPCGenData.Text = "NPC is a Generator";
            this.pNPCGenData.CheckedChanged += new System.EventHandler(this.pNPCGenData_CheckedChanged);
            // 
            // vNPCGenData
            // 
            this.vNPCGenData.Enabled = false;
            this.vNPCGenData.Location = new System.Drawing.Point(141, 51);
            this.vNPCGenData.Name = "vNPCGenData";
            this.vNPCGenData.Size = new System.Drawing.Size(52, 20);
            this.vNPCGenData.TabIndex = 128;
            this.vNPCGenData.Text = "0";
            // 
            // e
            // 
            this.e.BackColor = System.Drawing.SystemColors.Control;
            this.e.Controls.Add(this.vCleanChestInv);
            this.e.Controls.Add(this.vChestInvFill);
            this.e.Controls.Add(this.pNotify2);
            this.e.Controls.Add(this.vNotify2);
            this.e.Controls.Add(this.v_CFlag12);
            this.e.Controls.Add(this.v_CFlag11);
            this.e.Controls.Add(this.v_CFlag10);
            this.e.Controls.Add(this.v_CFlag09);
            this.e.Controls.Add(this.v_CFlag07);
            this.e.Controls.Add(this.v_CFlag08);
            this.e.Controls.Add(this.v_CFlag06);
            this.e.Controls.Add(this.v_CFlag05);
            this.e.Controls.Add(this.v_CFlag04);
            this.e.Controls.Add(this.v_CFlag03);
            this.e.Controls.Add(this.v_CFlag02);
            this.e.Controls.Add(this.v_CFlag01);
            this.e.Controls.Add(this.v_CFlag00);
            this.e.Controls.Add(this.p_OCOF);
            this.e.Controls.Add(this.vKeyID);
            this.e.Controls.Add(this.pKeyID);
            this.e.Controls.Add(this.vChestInvSlot);
            this.e.Controls.Add(this.pChestInvSlot);
            this.e.Controls.Add(this.tChestMoneyAmt);
            this.e.Controls.Add(this.label27);
            this.e.Controls.Add(this.btnChestInvGUID);
            this.e.Controls.Add(this.pChestInvDel);
            this.e.Controls.Add(this.btnAddChestInv2);
            this.e.Controls.Add(this.label25);
            this.e.Controls.Add(this.label24);
            this.e.Controls.Add(this.label23);
            this.e.Controls.Add(this.btnRemoveChestInv);
            this.e.Controls.Add(this.btnAddChestInv);
            this.e.Controls.Add(this.vChestInv);
            this.e.Controls.Add(this.label22);
            this.e.Controls.Add(this.pChestInv);
            this.e.Controls.Add(this.vInvenSource);
            this.e.Controls.Add(this.pInvenSource);
            this.e.Controls.Add(this.vLockDC);
            this.e.Controls.Add(this.pLockDC);
            this.e.Controls.Add(this.ChestInvProtos);
            this.e.Location = new System.Drawing.Point(4, 22);
            this.e.Name = "e";
            this.e.Size = new System.Drawing.Size(456, 534);
            this.e.TabIndex = 0;
            this.e.Text = "Containers";
            // 
            // vCleanChestInv
            // 
            this.vCleanChestInv.Location = new System.Drawing.Point(121, 248);
            this.vCleanChestInv.Name = "vCleanChestInv";
            this.vCleanChestInv.Size = new System.Drawing.Size(105, 23);
            this.vCleanChestInv.TabIndex = 126;
            this.vCleanChestInv.Text = "Clean Inventory";
            this.vCleanChestInv.UseVisualStyleBackColor = true;
            this.vCleanChestInv.Click += new System.EventHandler(this.vCleanChestInv_Click);
            // 
            // vChestInvFill
            // 
            this.vChestInvFill.Location = new System.Drawing.Point(15, 248);
            this.vChestInvFill.Name = "vChestInvFill";
            this.vChestInvFill.Size = new System.Drawing.Size(105, 23);
            this.vChestInvFill.TabIndex = 125;
            this.vChestInvFill.Text = "Load InvenSource";
            this.vChestInvFill.UseVisualStyleBackColor = true;
            this.vChestInvFill.Click += new System.EventHandler(this.vChestInvFill_Click);
            // 
            // pNotify2
            // 
            this.pNotify2.Location = new System.Drawing.Point(8, 416);
            this.pNotify2.Name = "pNotify2";
            this.pNotify2.Size = new System.Drawing.Size(192, 24);
            this.pNotify2.TabIndex = 91;
            this.pNotify2.Text = "Notify NPC with Unique Name ID:";
            this.pNotify2.Visible = false;
            this.pNotify2.CheckedChanged += new System.EventHandler(this.pNotify2_CheckedChanged);
            // 
            // vNotify2
            // 
            this.vNotify2.Enabled = false;
            this.vNotify2.Location = new System.Drawing.Point(200, 418);
            this.vNotify2.Name = "vNotify2";
            this.vNotify2.Size = new System.Drawing.Size(69, 20);
            this.vNotify2.TabIndex = 90;
            this.vNotify2.Text = "0";
            this.vNotify2.Visible = false;
            // 
            // v_CFlag12
            // 
            this.v_CFlag12.Enabled = false;
            this.v_CFlag12.Location = new System.Drawing.Point(296, 264);
            this.v_CFlag12.Name = "v_CFlag12";
            this.v_CFlag12.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag12.TabIndex = 72;
            this.v_CFlag12.Text = "Has Been Opened";
            // 
            // v_CFlag11
            // 
            this.v_CFlag11.Enabled = false;
            this.v_CFlag11.Location = new System.Drawing.Point(296, 248);
            this.v_CFlag11.Name = "v_CFlag11";
            this.v_CFlag11.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag11.TabIndex = 71;
            this.v_CFlag11.Text = "Open";
            // 
            // v_CFlag10
            // 
            this.v_CFlag10.Enabled = false;
            this.v_CFlag10.Location = new System.Drawing.Point(296, 232);
            this.v_CFlag10.Name = "v_CFlag10";
            this.v_CFlag10.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag10.TabIndex = 70;
            this.v_CFlag10.Text = "Inven. Spawn Independ.";
            // 
            // v_CFlag09
            // 
            this.v_CFlag09.Enabled = false;
            this.v_CFlag09.Location = new System.Drawing.Point(296, 216);
            this.v_CFlag09.Name = "v_CFlag09";
            this.v_CFlag09.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag09.TabIndex = 69;
            this.v_CFlag09.Text = "Inven. Spawn Once";
            // 
            // v_CFlag07
            // 
            this.v_CFlag07.Enabled = false;
            this.v_CFlag07.Location = new System.Drawing.Point(296, 184);
            this.v_CFlag07.Name = "v_CFlag07";
            this.v_CFlag07.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag07.TabIndex = 68;
            this.v_CFlag07.Text = "Busted";
            // 
            // v_CFlag08
            // 
            this.v_CFlag08.Enabled = false;
            this.v_CFlag08.Location = new System.Drawing.Point(296, 200);
            this.v_CFlag08.Name = "v_CFlag08";
            this.v_CFlag08.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag08.TabIndex = 67;
            this.v_CFlag08.Text = "Not Sticky";
            // 
            // v_CFlag06
            // 
            this.v_CFlag06.Enabled = false;
            this.v_CFlag06.Location = new System.Drawing.Point(296, 168);
            this.v_CFlag06.Name = "v_CFlag06";
            this.v_CFlag06.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag06.TabIndex = 66;
            this.v_CFlag06.Text = "Locked (Night)";
            // 
            // v_CFlag05
            // 
            this.v_CFlag05.Enabled = false;
            this.v_CFlag05.Location = new System.Drawing.Point(296, 152);
            this.v_CFlag05.Name = "v_CFlag05";
            this.v_CFlag05.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag05.TabIndex = 65;
            this.v_CFlag05.Text = "Locked (Day)";
            // 
            // v_CFlag04
            // 
            this.v_CFlag04.Enabled = false;
            this.v_CFlag04.Location = new System.Drawing.Point(296, 136);
            this.v_CFlag04.Name = "v_CFlag04";
            this.v_CFlag04.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag04.TabIndex = 64;
            this.v_CFlag04.Text = "Always Locked";
            // 
            // v_CFlag03
            // 
            this.v_CFlag03.Enabled = false;
            this.v_CFlag03.Location = new System.Drawing.Point(296, 120);
            this.v_CFlag03.Name = "v_CFlag03";
            this.v_CFlag03.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag03.TabIndex = 62;
            this.v_CFlag03.Text = "Never Locked";
            // 
            // v_CFlag02
            // 
            this.v_CFlag02.Enabled = false;
            this.v_CFlag02.Location = new System.Drawing.Point(296, 104);
            this.v_CFlag02.Name = "v_CFlag02";
            this.v_CFlag02.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag02.TabIndex = 61;
            this.v_CFlag02.Text = "Magically Held";
            // 
            // v_CFlag01
            // 
            this.v_CFlag01.Enabled = false;
            this.v_CFlag01.Location = new System.Drawing.Point(296, 88);
            this.v_CFlag01.Name = "v_CFlag01";
            this.v_CFlag01.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag01.TabIndex = 60;
            this.v_CFlag01.Text = "Jammed";
            // 
            // v_CFlag00
            // 
            this.v_CFlag00.Enabled = false;
            this.v_CFlag00.Location = new System.Drawing.Point(296, 72);
            this.v_CFlag00.Name = "v_CFlag00";
            this.v_CFlag00.Size = new System.Drawing.Size(152, 16);
            this.v_CFlag00.TabIndex = 59;
            this.v_CFlag00.Text = "Locked";
            // 
            // p_OCOF
            // 
            this.p_OCOF.Location = new System.Drawing.Point(240, 64);
            this.p_OCOF.Name = "p_OCOF";
            this.p_OCOF.Size = new System.Drawing.Size(56, 24);
            this.p_OCOF.TabIndex = 58;
            this.p_OCOF.Text = "Flags:";
            this.p_OCOF.CheckedChanged += new System.EventHandler(this.p_OCOF_CheckedChanged);
            // 
            // vKeyID
            // 
            this.vKeyID.Enabled = false;
            this.vKeyID.Location = new System.Drawing.Point(80, 34);
            this.vKeyID.Name = "vKeyID";
            this.vKeyID.Size = new System.Drawing.Size(40, 20);
            this.vKeyID.TabIndex = 57;
            this.vKeyID.Text = "0";
            // 
            // pKeyID
            // 
            this.pKeyID.Location = new System.Drawing.Point(8, 32);
            this.pKeyID.Name = "pKeyID";
            this.pKeyID.Size = new System.Drawing.Size(72, 24);
            this.pKeyID.TabIndex = 56;
            this.pKeyID.Text = "Key ID:";
            this.pKeyID.CheckedChanged += new System.EventHandler(this.pKeyID_CheckedChanged);
            // 
            // vChestInvSlot
            // 
            this.vChestInvSlot.Location = new System.Drawing.Point(104, 352);
            this.vChestInvSlot.Name = "vChestInvSlot";
            this.vChestInvSlot.Size = new System.Drawing.Size(88, 20);
            this.vChestInvSlot.TabIndex = 55;
            this.vChestInvSlot.Text = "0";
            // 
            // pChestInvSlot
            // 
            this.pChestInvSlot.Location = new System.Drawing.Point(16, 352);
            this.pChestInvSlot.Name = "pChestInvSlot";
            this.pChestInvSlot.Size = new System.Drawing.Size(104, 16);
            this.pChestInvSlot.TabIndex = 54;
            this.pChestInvSlot.Text = "Specific slot:";
            this.pChestInvSlot.CheckedChanged += new System.EventHandler(this.pChestInvSlot_CheckedChanged);
            // 
            // tChestMoneyAmt
            // 
            this.tChestMoneyAmt.Location = new System.Drawing.Point(136, 326);
            this.tChestMoneyAmt.Name = "tChestMoneyAmt";
            this.tChestMoneyAmt.Size = new System.Drawing.Size(88, 20);
            this.tChestMoneyAmt.TabIndex = 32;
            this.tChestMoneyAmt.Text = "1";
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(16, 328);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(136, 16);
            this.label27.TabIndex = 31;
            this.label27.Text = "Amount (for money):";
            // 
            // btnChestInvGUID
            // 
            this.btnChestInvGUID.Location = new System.Drawing.Point(152, 66);
            this.btnChestInvGUID.Name = "btnChestInvGUID";
            this.btnChestInvGUID.Size = new System.Drawing.Size(72, 24);
            this.btnChestInvGUID.TabIndex = 30;
            this.btnChestInvGUID.Text = "Show GUID";
            this.btnChestInvGUID.Click += new System.EventHandler(this.btnChestInvGUID_Click);
            // 
            // pChestInvDel
            // 
            this.pChestInvDel.Checked = true;
            this.pChestInvDel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pChestInvDel.Location = new System.Drawing.Point(16, 376);
            this.pChestInvDel.Name = "pChestInvDel";
            this.pChestInvDel.Size = new System.Drawing.Size(200, 24);
            this.pChestInvDel.TabIndex = 29;
            this.pChestInvDel.Text = "Delete files when removing items";
            // 
            // btnAddChestInv2
            // 
            this.btnAddChestInv2.Location = new System.Drawing.Point(88, 296);
            this.btnAddChestInv2.Name = "btnAddChestInv2";
            this.btnAddChestInv2.Size = new System.Drawing.Size(64, 23);
            this.btnAddChestInv2.TabIndex = 28;
            this.btnAddChestInv2.Text = "Add Exist.";
            this.btnAddChestInv2.Click += new System.EventHandler(this.btnAddChestInv2_Click);
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Location = new System.Drawing.Point(8, 64);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1, 337);
            this.label25.TabIndex = 27;
            this.label25.Text = "label25";
            // 
            // label24
            // 
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Location = new System.Drawing.Point(232, 64);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(1, 337);
            this.label24.TabIndex = 26;
            this.label24.Text = "label24";
            // 
            // label23
            // 
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label23.Location = new System.Drawing.Point(8, 400);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(224, 1);
            this.label23.TabIndex = 24;
            this.label23.Text = "label23";
            // 
            // btnRemoveChestInv
            // 
            this.btnRemoveChestInv.Location = new System.Drawing.Point(160, 296);
            this.btnRemoveChestInv.Name = "btnRemoveChestInv";
            this.btnRemoveChestInv.Size = new System.Drawing.Size(64, 23);
            this.btnRemoveChestInv.TabIndex = 23;
            this.btnRemoveChestInv.Text = "Remove";
            this.btnRemoveChestInv.Click += new System.EventHandler(this.btnRemoveChestInv_Click);
            // 
            // btnAddChestInv
            // 
            this.btnAddChestInv.Location = new System.Drawing.Point(16, 296);
            this.btnAddChestInv.Name = "btnAddChestInv";
            this.btnAddChestInv.Size = new System.Drawing.Size(64, 23);
            this.btnAddChestInv.TabIndex = 22;
            this.btnAddChestInv.Text = "Add New";
            this.btnAddChestInv.Click += new System.EventHandler(this.btnAddChestInv_Click);
            // 
            // vChestInv
            // 
            this.vChestInv.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vChestInv.ItemHeight = 14;
            this.vChestInv.Location = new System.Drawing.Point(16, 88);
            this.vChestInv.Name = "vChestInv";
            this.vChestInv.Size = new System.Drawing.Size(208, 158);
            this.vChestInv.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(8, 64);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(224, 1);
            this.label22.TabIndex = 20;
            this.label22.Text = "label22";
            // 
            // pChestInv
            // 
            this.pChestInv.Location = new System.Drawing.Point(16, 64);
            this.pChestInv.Name = "pChestInv";
            this.pChestInv.Size = new System.Drawing.Size(80, 24);
            this.pChestInv.TabIndex = 19;
            this.pChestInv.Text = "Inventory:";
            this.pChestInv.CheckedChanged += new System.EventHandler(this.pChestInv_CheckedChanged);
            // 
            // vInvenSource
            // 
            this.vInvenSource.Enabled = false;
            this.vInvenSource.Location = new System.Drawing.Point(305, 14);
            this.vInvenSource.Name = "vInvenSource";
            this.vInvenSource.Size = new System.Drawing.Size(56, 20);
            this.vInvenSource.TabIndex = 18;
            this.vInvenSource.Text = "0";
            // 
            // pInvenSource
            // 
            this.pInvenSource.Location = new System.Drawing.Point(144, 8);
            this.pInvenSource.Name = "pInvenSource";
            this.pInvenSource.Size = new System.Drawing.Size(172, 32);
            this.pInvenSource.TabIndex = 17;
            this.pInvenSource.Text = "Inventory Source ID (used to respawn the inventory):";
            this.pInvenSource.CheckedChanged += new System.EventHandler(this.pInvenSource_CheckedChanged);
            // 
            // vLockDC
            // 
            this.vLockDC.Enabled = false;
            this.vLockDC.Location = new System.Drawing.Point(80, 10);
            this.vLockDC.Name = "vLockDC";
            this.vLockDC.Size = new System.Drawing.Size(40, 20);
            this.vLockDC.TabIndex = 16;
            this.vLockDC.Text = "0";
            // 
            // pLockDC
            // 
            this.pLockDC.Location = new System.Drawing.Point(8, 8);
            this.pLockDC.Name = "pLockDC";
            this.pLockDC.Size = new System.Drawing.Size(72, 24);
            this.pLockDC.TabIndex = 15;
            this.pLockDC.Text = "Lock DC:";
            this.pLockDC.CheckedChanged += new System.EventHandler(this.pLockDC_CheckedChanged);
            // 
            // ChestInvProtos
            // 
            this.ChestInvProtos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChestInvProtos.Location = new System.Drawing.Point(16, 272);
            this.ChestInvProtos.Name = "ChestInvProtos";
            this.ChestInvProtos.Size = new System.Drawing.Size(208, 21);
            this.ChestInvProtos.Sorted = true;
            this.ChestInvProtos.TabIndex = 18;
            // 
            // f
            // 
            this.f.BackColor = System.Drawing.SystemColors.Control;
            this.f.Controls.Add(this.vMoneyQuantity);
            this.f.Controls.Add(this.pMoneyQuantity);
            this.f.Location = new System.Drawing.Point(4, 22);
            this.f.Name = "f";
            this.f.Size = new System.Drawing.Size(456, 534);
            this.f.TabIndex = 3;
            this.f.Text = "Money";
            // 
            // vMoneyQuantity
            // 
            this.vMoneyQuantity.Location = new System.Drawing.Point(72, 10);
            this.vMoneyQuantity.Name = "vMoneyQuantity";
            this.vMoneyQuantity.Size = new System.Drawing.Size(48, 20);
            this.vMoneyQuantity.TabIndex = 14;
            this.vMoneyQuantity.Text = "0";
            // 
            // pMoneyQuantity
            // 
            this.pMoneyQuantity.Location = new System.Drawing.Point(8, 8);
            this.pMoneyQuantity.Name = "pMoneyQuantity";
            this.pMoneyQuantity.Size = new System.Drawing.Size(72, 24);
            this.pMoneyQuantity.TabIndex = 0;
            this.pMoneyQuantity.Text = "Quantity:";
            this.pMoneyQuantity.CheckedChanged += new System.EventHandler(this.pMoneyQuantity_CheckedChanged);
            // 
            // h
            // 
            this.h.BackColor = System.Drawing.SystemColors.Control;
            this.h.Controls.Add(this.v_NFlag31);
            this.h.Controls.Add(this.v_NFlag30);
            this.h.Controls.Add(this.v_NFlag29);
            this.h.Controls.Add(this.v_NFlag28);
            this.h.Controls.Add(this.v_NFlag27);
            this.h.Controls.Add(this.v_NFlag26);
            this.h.Controls.Add(this.v_NFlag25);
            this.h.Controls.Add(this.v_NFlag24);
            this.h.Controls.Add(this.v_NFlag23);
            this.h.Controls.Add(this.v_NFlag22);
            this.h.Controls.Add(this.v_NFlag21);
            this.h.Controls.Add(this.v_NFlag20);
            this.h.Controls.Add(this.v_NFlag19);
            this.h.Controls.Add(this.v_NFlag18);
            this.h.Controls.Add(this.v_NFlag17);
            this.h.Controls.Add(this.v_NFlag16);
            this.h.Controls.Add(this.v_NFlag15);
            this.h.Controls.Add(this.v_NFlag14);
            this.h.Controls.Add(this.v_NFlag13);
            this.h.Controls.Add(this.v_NFlag12);
            this.h.Controls.Add(this.v_NFlag11);
            this.h.Controls.Add(this.v_NFlag10);
            this.h.Controls.Add(this.v_NFlag09);
            this.h.Controls.Add(this.v_NFlag08);
            this.h.Controls.Add(this.v_NFlag07);
            this.h.Controls.Add(this.v_NFlag06);
            this.h.Controls.Add(this.v_NFlag05);
            this.h.Controls.Add(this.v_NFlag04);
            this.h.Controls.Add(this.v_NFlag03);
            this.h.Controls.Add(this.v_NFlag02);
            this.h.Controls.Add(this.v_NFlag01);
            this.h.Controls.Add(this.v_NFlag00);
            this.h.Controls.Add(this.p_ONF);
            this.h.Location = new System.Drawing.Point(4, 22);
            this.h.Name = "h";
            this.h.Size = new System.Drawing.Size(456, 534);
            this.h.TabIndex = 10;
            this.h.Text = "NPC Flags";
            // 
            // v_NFlag31
            // 
            this.v_NFlag31.Enabled = false;
            this.v_NFlag31.Location = new System.Drawing.Point(88, 512);
            this.v_NFlag31.Name = "v_NFlag31";
            this.v_NFlag31.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag31.TabIndex = 92;
            this.v_NFlag31.Text = "ONF_EXTRAPLANAR";
            // 
            // v_NFlag30
            // 
            this.v_NFlag30.Enabled = false;
            this.v_NFlag30.Location = new System.Drawing.Point(88, 496);
            this.v_NFlag30.Name = "v_NFlag30";
            this.v_NFlag30.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag30.TabIndex = 91;
            this.v_NFlag30.Text = "ONF_BOSS_MONSTER";
            // 
            // v_NFlag29
            // 
            this.v_NFlag29.Enabled = false;
            this.v_NFlag29.Location = new System.Drawing.Point(88, 480);
            this.v_NFlag29.Name = "v_NFlag29";
            this.v_NFlag29.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag29.TabIndex = 90;
            this.v_NFlag29.Text = "ONF_NO_ATTACK";
            // 
            // v_NFlag28
            // 
            this.v_NFlag28.Enabled = false;
            this.v_NFlag28.Location = new System.Drawing.Point(88, 464);
            this.v_NFlag28.Name = "v_NFlag28";
            this.v_NFlag28.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag28.TabIndex = 89;
            this.v_NFlag28.Text = "ONF_BACKING_OFF";
            // 
            // v_NFlag27
            // 
            this.v_NFlag27.Enabled = false;
            this.v_NFlag27.Location = new System.Drawing.Point(88, 448);
            this.v_NFlag27.Name = "v_NFlag27";
            this.v_NFlag27.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag27.TabIndex = 88;
            this.v_NFlag27.Text = "ONF_UNUSED_08000000";
            // 
            // v_NFlag26
            // 
            this.v_NFlag26.Enabled = false;
            this.v_NFlag26.Location = new System.Drawing.Point(88, 432);
            this.v_NFlag26.Name = "v_NFlag26";
            this.v_NFlag26.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag26.TabIndex = 87;
            this.v_NFlag26.Text = "ONF_UNUSED_04000000";
            // 
            // v_NFlag25
            // 
            this.v_NFlag25.Enabled = false;
            this.v_NFlag25.Location = new System.Drawing.Point(88, 416);
            this.v_NFlag25.Name = "v_NFlag25";
            this.v_NFlag25.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag25.TabIndex = 86;
            this.v_NFlag25.Text = "ONF_UNUSED_02000000";
            // 
            // v_NFlag24
            // 
            this.v_NFlag24.Enabled = false;
            this.v_NFlag24.Location = new System.Drawing.Point(88, 400);
            this.v_NFlag24.Name = "v_NFlag24";
            this.v_NFlag24.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag24.TabIndex = 85;
            this.v_NFlag24.Text = "ONF_DEMAINTAIN_SPELLS";
            // 
            // v_NFlag23
            // 
            this.v_NFlag23.Enabled = false;
            this.v_NFlag23.Location = new System.Drawing.Point(88, 384);
            this.v_NFlag23.Name = "v_NFlag23";
            this.v_NFlag23.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag23.TabIndex = 84;
            this.v_NFlag23.Text = "ONF_GENERATOR_RATE3";
            // 
            // v_NFlag22
            // 
            this.v_NFlag22.Enabled = false;
            this.v_NFlag22.Location = new System.Drawing.Point(88, 368);
            this.v_NFlag22.Name = "v_NFlag22";
            this.v_NFlag22.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag22.TabIndex = 83;
            this.v_NFlag22.Text = "ONF_GENERATOR_RATE2";
            // 
            // v_NFlag21
            // 
            this.v_NFlag21.Enabled = false;
            this.v_NFlag21.Location = new System.Drawing.Point(88, 352);
            this.v_NFlag21.Name = "v_NFlag21";
            this.v_NFlag21.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag21.TabIndex = 82;
            this.v_NFlag21.Text = "ONF_GENERATOR_RATE1";
            // 
            // v_NFlag20
            // 
            this.v_NFlag20.Enabled = false;
            this.v_NFlag20.Location = new System.Drawing.Point(88, 336);
            this.v_NFlag20.Name = "v_NFlag20";
            this.v_NFlag20.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag20.TabIndex = 81;
            this.v_NFlag20.Text = "ONF_GENERATED";
            // 
            // v_NFlag19
            // 
            this.v_NFlag19.Enabled = false;
            this.v_NFlag19.Location = new System.Drawing.Point(88, 320);
            this.v_NFlag19.Name = "v_NFlag19";
            this.v_NFlag19.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag19.TabIndex = 80;
            this.v_NFlag19.Text = "ONF_GENERATOR";
            // 
            // v_NFlag18
            // 
            this.v_NFlag18.Enabled = false;
            this.v_NFlag18.Location = new System.Drawing.Point(88, 304);
            this.v_NFlag18.Name = "v_NFlag18";
            this.v_NFlag18.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag18.TabIndex = 79;
            this.v_NFlag18.Text = "ONF_CAST_HIGHEST";
            // 
            // v_NFlag17
            // 
            this.v_NFlag17.Enabled = false;
            this.v_NFlag17.Location = new System.Drawing.Point(88, 288);
            this.v_NFlag17.Name = "v_NFlag17";
            this.v_NFlag17.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag17.TabIndex = 78;
            this.v_NFlag17.Text = "ONF_NO_EQUIP";
            // 
            // v_NFlag16
            // 
            this.v_NFlag16.Enabled = false;
            this.v_NFlag16.Location = new System.Drawing.Point(88, 272);
            this.v_NFlag16.Name = "v_NFlag16";
            this.v_NFlag16.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag16.TabIndex = 77;
            this.v_NFlag16.Text = "ONF_CHECK_LEADER";
            // 
            // v_NFlag15
            // 
            this.v_NFlag15.Enabled = false;
            this.v_NFlag15.Location = new System.Drawing.Point(88, 256);
            this.v_NFlag15.Name = "v_NFlag15";
            this.v_NFlag15.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag15.TabIndex = 76;
            this.v_NFlag15.Text = "ONF_FAMILIAR";
            // 
            // v_NFlag14
            // 
            this.v_NFlag14.Enabled = false;
            this.v_NFlag14.Location = new System.Drawing.Point(88, 240);
            this.v_NFlag14.Name = "v_NFlag14";
            this.v_NFlag14.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag14.TabIndex = 75;
            this.v_NFlag14.Text = "ONF_FENCE";
            // 
            // v_NFlag13
            // 
            this.v_NFlag13.Enabled = false;
            this.v_NFlag13.Location = new System.Drawing.Point(88, 224);
            this.v_NFlag13.Name = "v_NFlag13";
            this.v_NFlag13.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag13.TabIndex = 74;
            this.v_NFlag13.Text = "ONF_WANDERS_IN_DARK";
            // 
            // v_NFlag12
            // 
            this.v_NFlag12.Enabled = false;
            this.v_NFlag12.Location = new System.Drawing.Point(88, 208);
            this.v_NFlag12.Name = "v_NFlag12";
            this.v_NFlag12.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag12.TabIndex = 73;
            this.v_NFlag12.Text = "ONF_WANDERS";
            // 
            // v_NFlag11
            // 
            this.v_NFlag11.Enabled = false;
            this.v_NFlag11.Location = new System.Drawing.Point(88, 192);
            this.v_NFlag11.Name = "v_NFlag11";
            this.v_NFlag11.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag11.TabIndex = 72;
            this.v_NFlag11.Text = "ONF_KOS_OVERRIDE";
            // 
            // v_NFlag10
            // 
            this.v_NFlag10.Enabled = false;
            this.v_NFlag10.Location = new System.Drawing.Point(88, 176);
            this.v_NFlag10.Name = "v_NFlag10";
            this.v_NFlag10.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag10.TabIndex = 71;
            this.v_NFlag10.Text = "ONF_FORCED_FOLLOWER";
            // 
            // v_NFlag09
            // 
            this.v_NFlag09.Enabled = false;
            this.v_NFlag09.Location = new System.Drawing.Point(88, 160);
            this.v_NFlag09.Name = "v_NFlag09";
            this.v_NFlag09.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag09.TabIndex = 70;
            this.v_NFlag09.Text = "ONF_USE_ALERTPOINTS";
            // 
            // v_NFlag08
            // 
            this.v_NFlag08.Enabled = false;
            this.v_NFlag08.Location = new System.Drawing.Point(88, 144);
            this.v_NFlag08.Name = "v_NFlag08";
            this.v_NFlag08.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag08.TabIndex = 69;
            this.v_NFlag08.Text = "ONF_KOS";
            // 
            // v_NFlag07
            // 
            this.v_NFlag07.Enabled = false;
            this.v_NFlag07.Location = new System.Drawing.Point(88, 128);
            this.v_NFlag07.Name = "v_NFlag07";
            this.v_NFlag07.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag07.TabIndex = 68;
            this.v_NFlag07.Text = "ONF_UNUSED_00000080";
            // 
            // v_NFlag06
            // 
            this.v_NFlag06.Enabled = false;
            this.v_NFlag06.Location = new System.Drawing.Point(88, 112);
            this.v_NFlag06.Name = "v_NFlag06";
            this.v_NFlag06.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag06.TabIndex = 67;
            this.v_NFlag06.Text = "ONF_LOGBOOK_IGNORES";
            // 
            // v_NFlag05
            // 
            this.v_NFlag05.Enabled = false;
            this.v_NFlag05.Location = new System.Drawing.Point(88, 96);
            this.v_NFlag05.Name = "v_NFlag05";
            this.v_NFlag05.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag05.TabIndex = 66;
            this.v_NFlag05.Text = "ONF_JILTED";
            // 
            // v_NFlag04
            // 
            this.v_NFlag04.Enabled = false;
            this.v_NFlag04.Location = new System.Drawing.Point(88, 80);
            this.v_NFlag04.Name = "v_NFlag04";
            this.v_NFlag04.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag04.TabIndex = 65;
            this.v_NFlag04.Text = "ONF_AI_SPREAD_OUT";
            // 
            // v_NFlag03
            // 
            this.v_NFlag03.Enabled = false;
            this.v_NFlag03.Location = new System.Drawing.Point(88, 64);
            this.v_NFlag03.Name = "v_NFlag03";
            this.v_NFlag03.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag03.TabIndex = 64;
            this.v_NFlag03.Text = "ONF_AI_WAIT_HERE";
            // 
            // v_NFlag02
            // 
            this.v_NFlag02.Enabled = false;
            this.v_NFlag02.Location = new System.Drawing.Point(88, 48);
            this.v_NFlag02.Name = "v_NFlag02";
            this.v_NFlag02.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag02.TabIndex = 63;
            this.v_NFlag02.Text = "ONF_WAYPOINTS_NIGHT";
            // 
            // v_NFlag01
            // 
            this.v_NFlag01.Enabled = false;
            this.v_NFlag01.Location = new System.Drawing.Point(88, 32);
            this.v_NFlag01.Name = "v_NFlag01";
            this.v_NFlag01.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag01.TabIndex = 62;
            this.v_NFlag01.Text = "ONF_WAYPOINTS_DAY";
            // 
            // v_NFlag00
            // 
            this.v_NFlag00.Enabled = false;
            this.v_NFlag00.Location = new System.Drawing.Point(88, 16);
            this.v_NFlag00.Name = "v_NFlag00";
            this.v_NFlag00.Size = new System.Drawing.Size(184, 16);
            this.v_NFlag00.TabIndex = 61;
            this.v_NFlag00.Text = "ONF_EX_FOLLOWER";
            // 
            // p_ONF
            // 
            this.p_ONF.Location = new System.Drawing.Point(8, 8);
            this.p_ONF.Name = "p_ONF";
            this.p_ONF.Size = new System.Drawing.Size(88, 24);
            this.p_ONF.TabIndex = 60;
            this.p_ONF.Text = "NPC Flags:";
            this.p_ONF.CheckedChanged += new System.EventHandler(this.p_ONF_CheckedChanged);
            // 
            // i
            // 
            this.i.BackColor = System.Drawing.SystemColors.Control;
            this.i.Controls.Add(this.v_C1Flag31);
            this.i.Controls.Add(this.v_C1Flag30);
            this.i.Controls.Add(this.v_C1Flag29);
            this.i.Controls.Add(this.v_C1Flag28);
            this.i.Controls.Add(this.v_C1Flag27);
            this.i.Controls.Add(this.v_C1Flag26);
            this.i.Controls.Add(this.v_C1Flag25);
            this.i.Controls.Add(this.v_C1Flag24);
            this.i.Controls.Add(this.v_C1Flag23);
            this.i.Controls.Add(this.v_C1Flag22);
            this.i.Controls.Add(this.v_C1Flag21);
            this.i.Controls.Add(this.v_C1Flag20);
            this.i.Controls.Add(this.v_C1Flag19);
            this.i.Controls.Add(this.v_C1Flag18);
            this.i.Controls.Add(this.v_C1Flag17);
            this.i.Controls.Add(this.v_C1Flag16);
            this.i.Controls.Add(this.v_C1Flag15);
            this.i.Controls.Add(this.v_C1Flag14);
            this.i.Controls.Add(this.v_C1Flag13);
            this.i.Controls.Add(this.v_C1Flag12);
            this.i.Controls.Add(this.v_C1Flag11);
            this.i.Controls.Add(this.v_C1Flag10);
            this.i.Controls.Add(this.v_C1Flag09);
            this.i.Controls.Add(this.v_C1Flag08);
            this.i.Controls.Add(this.v_C1Flag07);
            this.i.Controls.Add(this.v_C1Flag06);
            this.i.Controls.Add(this.v_C1Flag05);
            this.i.Controls.Add(this.v_C1Flag04);
            this.i.Controls.Add(this.v_C1Flag03);
            this.i.Controls.Add(this.v_C1Flag02);
            this.i.Controls.Add(this.v_C1Flag01);
            this.i.Controls.Add(this.v_C1Flag00);
            this.i.Controls.Add(this.p_OCF);
            this.i.Location = new System.Drawing.Point(4, 22);
            this.i.Name = "i";
            this.i.Size = new System.Drawing.Size(456, 534);
            this.i.TabIndex = 11;
            this.i.Text = "Critter Flags";
            // 
            // v_C1Flag31
            // 
            this.v_C1Flag31.Enabled = false;
            this.v_C1Flag31.Location = new System.Drawing.Point(88, 512);
            this.v_C1Flag31.Name = "v_C1Flag31";
            this.v_C1Flag31.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag31.TabIndex = 123;
            this.v_C1Flag31.Text = "OCF_FATIGUE_LIMITING";
            // 
            // v_C1Flag30
            // 
            this.v_C1Flag30.Enabled = false;
            this.v_C1Flag30.Location = new System.Drawing.Point(88, 496);
            this.v_C1Flag30.Name = "v_C1Flag30";
            this.v_C1Flag30.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag30.TabIndex = 122;
            this.v_C1Flag30.Text = "OCF_UNUSED_40000000";
            // 
            // v_C1Flag29
            // 
            this.v_C1Flag29.Enabled = false;
            this.v_C1Flag29.Location = new System.Drawing.Point(88, 480);
            this.v_C1Flag29.Name = "v_C1Flag29";
            this.v_C1Flag29.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag29.TabIndex = 121;
            this.v_C1Flag29.Text = "OCF_MECHANICAL";
            // 
            // v_C1Flag28
            // 
            this.v_C1Flag28.Enabled = false;
            this.v_C1Flag28.Location = new System.Drawing.Point(88, 464);
            this.v_C1Flag28.Name = "v_C1Flag28";
            this.v_C1Flag28.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag28.TabIndex = 120;
            this.v_C1Flag28.Text = "OCF_NON_LETHAL_COMBAT";
            // 
            // v_C1Flag27
            // 
            this.v_C1Flag27.Enabled = false;
            this.v_C1Flag27.Location = new System.Drawing.Point(88, 448);
            this.v_C1Flag27.Name = "v_C1Flag27";
            this.v_C1Flag27.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag27.TabIndex = 119;
            this.v_C1Flag27.Text = "OCF_NO_FLEE";
            // 
            // v_C1Flag26
            // 
            this.v_C1Flag26.Enabled = false;
            this.v_C1Flag26.Location = new System.Drawing.Point(88, 432);
            this.v_C1Flag26.Name = "v_C1Flag26";
            this.v_C1Flag26.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag26.TabIndex = 118;
            this.v_C1Flag26.Text = "OCF_UNUSED_04000000";
            // 
            // v_C1Flag25
            // 
            this.v_C1Flag25.Enabled = false;
            this.v_C1Flag25.Location = new System.Drawing.Point(88, 416);
            this.v_C1Flag25.Name = "v_C1Flag25";
            this.v_C1Flag25.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag25.TabIndex = 117;
            this.v_C1Flag25.Text = "OCF_UNUSED_02000000";
            // 
            // v_C1Flag24
            // 
            this.v_C1Flag24.Enabled = false;
            this.v_C1Flag24.Location = new System.Drawing.Point(88, 400);
            this.v_C1Flag24.Name = "v_C1Flag24";
            this.v_C1Flag24.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag24.TabIndex = 116;
            this.v_C1Flag24.Text = "OCF_UNRESURRECTABLE";
            // 
            // v_C1Flag23
            // 
            this.v_C1Flag23.Enabled = false;
            this.v_C1Flag23.Location = new System.Drawing.Point(88, 384);
            this.v_C1Flag23.Name = "v_C1Flag23";
            this.v_C1Flag23.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag23.TabIndex = 115;
            this.v_C1Flag23.Text = "OCF_UNREVIVIFIABLE";
            // 
            // v_C1Flag22
            // 
            this.v_C1Flag22.Enabled = false;
            this.v_C1Flag22.Location = new System.Drawing.Point(88, 368);
            this.v_C1Flag22.Name = "v_C1Flag22";
            this.v_C1Flag22.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag22.TabIndex = 114;
            this.v_C1Flag22.Text = "OCF_LIGHT_XLARGE";
            // 
            // v_C1Flag21
            // 
            this.v_C1Flag21.Enabled = false;
            this.v_C1Flag21.Location = new System.Drawing.Point(88, 352);
            this.v_C1Flag21.Name = "v_C1Flag21";
            this.v_C1Flag21.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag21.TabIndex = 113;
            this.v_C1Flag21.Text = "OCF_LIGHT_LARGE";
            // 
            // v_C1Flag20
            // 
            this.v_C1Flag20.Enabled = false;
            this.v_C1Flag20.Location = new System.Drawing.Point(88, 336);
            this.v_C1Flag20.Name = "v_C1Flag20";
            this.v_C1Flag20.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag20.TabIndex = 112;
            this.v_C1Flag20.Text = "OCF_LIGHT_MEDIUM";
            // 
            // v_C1Flag19
            // 
            this.v_C1Flag19.Enabled = false;
            this.v_C1Flag19.Location = new System.Drawing.Point(88, 320);
            this.v_C1Flag19.Name = "v_C1Flag19";
            this.v_C1Flag19.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag19.TabIndex = 111;
            this.v_C1Flag19.Text = "OCF_LIGHT_SMALL";
            // 
            // v_C1Flag18
            // 
            this.v_C1Flag18.Enabled = false;
            this.v_C1Flag18.Location = new System.Drawing.Point(88, 304);
            this.v_C1Flag18.Name = "v_C1Flag18";
            this.v_C1Flag18.Size = new System.Drawing.Size(192, 16);
            this.v_C1Flag18.TabIndex = 110;
            this.v_C1Flag18.Text = "OCF_COMBAT_MODE_ACTIVE";
            // 
            // v_C1Flag17
            // 
            this.v_C1Flag17.Enabled = false;
            this.v_C1Flag17.Location = new System.Drawing.Point(88, 288);
            this.v_C1Flag17.Name = "v_C1Flag17";
            this.v_C1Flag17.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag17.TabIndex = 109;
            this.v_C1Flag17.Text = "OCF_ENCOUNTER";
            // 
            // v_C1Flag16
            // 
            this.v_C1Flag16.Enabled = false;
            this.v_C1Flag16.Location = new System.Drawing.Point(88, 272);
            this.v_C1Flag16.Name = "v_C1Flag16";
            this.v_C1Flag16.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag16.TabIndex = 108;
            this.v_C1Flag16.Text = "OCF_SPELL_FLEE";
            // 
            // v_C1Flag15
            // 
            this.v_C1Flag15.Enabled = false;
            this.v_C1Flag15.Location = new System.Drawing.Point(88, 256);
            this.v_C1Flag15.Name = "v_C1Flag15";
            this.v_C1Flag15.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag15.TabIndex = 107;
            this.v_C1Flag15.Text = "OCF_MONSTER";
            // 
            // v_C1Flag14
            // 
            this.v_C1Flag14.Enabled = false;
            this.v_C1Flag14.Location = new System.Drawing.Point(88, 240);
            this.v_C1Flag14.Name = "v_C1Flag14";
            this.v_C1Flag14.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag14.TabIndex = 106;
            this.v_C1Flag14.Text = "OCF_SURRENDERED";
            // 
            // v_C1Flag13
            // 
            this.v_C1Flag13.Enabled = false;
            this.v_C1Flag13.Location = new System.Drawing.Point(88, 224);
            this.v_C1Flag13.Name = "v_C1Flag13";
            this.v_C1Flag13.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag13.TabIndex = 105;
            this.v_C1Flag13.Text = "OCF_MUTE";
            // 
            // v_C1Flag12
            // 
            this.v_C1Flag12.Enabled = false;
            this.v_C1Flag12.Location = new System.Drawing.Point(88, 208);
            this.v_C1Flag12.Name = "v_C1Flag12";
            this.v_C1Flag12.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag12.TabIndex = 104;
            this.v_C1Flag12.Text = "OCF_SLEEPING";
            // 
            // v_C1Flag11
            // 
            this.v_C1Flag11.Enabled = false;
            this.v_C1Flag11.Location = new System.Drawing.Point(88, 192);
            this.v_C1Flag11.Name = "v_C1Flag11";
            this.v_C1Flag11.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag11.TabIndex = 103;
            this.v_C1Flag11.Text = "OCF_UNUSED_00000800";
            // 
            // v_C1Flag10
            // 
            this.v_C1Flag10.Enabled = false;
            this.v_C1Flag10.Location = new System.Drawing.Point(88, 176);
            this.v_C1Flag10.Name = "v_C1Flag10";
            this.v_C1Flag10.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag10.TabIndex = 102;
            this.v_C1Flag10.Text = "OCF_UNUSED_00000400";
            // 
            // v_C1Flag09
            // 
            this.v_C1Flag09.Enabled = false;
            this.v_C1Flag09.Location = new System.Drawing.Point(88, 160);
            this.v_C1Flag09.Name = "v_C1Flag09";
            this.v_C1Flag09.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag09.TabIndex = 101;
            this.v_C1Flag09.Text = "OCF_UNUSED_00000200";
            // 
            // v_C1Flag08
            // 
            this.v_C1Flag08.Enabled = false;
            this.v_C1Flag08.Location = new System.Drawing.Point(88, 144);
            this.v_C1Flag08.Name = "v_C1Flag08";
            this.v_C1Flag08.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag08.TabIndex = 100;
            this.v_C1Flag08.Text = "OCF_HAS_ARCANE_ABILITY";
            // 
            // v_C1Flag07
            // 
            this.v_C1Flag07.Enabled = false;
            this.v_C1Flag07.Location = new System.Drawing.Point(88, 128);
            this.v_C1Flag07.Name = "v_C1Flag07";
            this.v_C1Flag07.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag07.TabIndex = 99;
            this.v_C1Flag07.Text = "OCF_BLINDED";
            // 
            // v_C1Flag06
            // 
            this.v_C1Flag06.Enabled = false;
            this.v_C1Flag06.Location = new System.Drawing.Point(88, 112);
            this.v_C1Flag06.Name = "v_C1Flag06";
            this.v_C1Flag06.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag06.TabIndex = 98;
            this.v_C1Flag06.Text = "OCF_PARALYZED";
            // 
            // v_C1Flag05
            // 
            this.v_C1Flag05.Enabled = false;
            this.v_C1Flag05.Location = new System.Drawing.Point(88, 96);
            this.v_C1Flag05.Name = "v_C1Flag05";
            this.v_C1Flag05.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag05.TabIndex = 97;
            this.v_C1Flag05.Text = "OCF_STUNNED";
            // 
            // v_C1Flag04
            // 
            this.v_C1Flag04.Enabled = false;
            this.v_C1Flag04.Location = new System.Drawing.Point(88, 80);
            this.v_C1Flag04.Name = "v_C1Flag04";
            this.v_C1Flag04.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag04.TabIndex = 96;
            this.v_C1Flag04.Text = "OCF_FLEEING";
            // 
            // v_C1Flag03
            // 
            this.v_C1Flag03.Enabled = false;
            this.v_C1Flag03.Location = new System.Drawing.Point(88, 64);
            this.v_C1Flag03.Name = "v_C1Flag03";
            this.v_C1Flag03.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag03.TabIndex = 95;
            this.v_C1Flag03.Text = "OCF_UNUSED_00000008";
            // 
            // v_C1Flag02
            // 
            this.v_C1Flag02.Enabled = false;
            this.v_C1Flag02.Location = new System.Drawing.Point(88, 48);
            this.v_C1Flag02.Name = "v_C1Flag02";
            this.v_C1Flag02.Size = new System.Drawing.Size(192, 16);
            this.v_C1Flag02.TabIndex = 94;
            this.v_C1Flag02.Text = "OCF_EXPERIENCE_AWARDED";
            // 
            // v_C1Flag01
            // 
            this.v_C1Flag01.Enabled = false;
            this.v_C1Flag01.Location = new System.Drawing.Point(88, 32);
            this.v_C1Flag01.Name = "v_C1Flag01";
            this.v_C1Flag01.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag01.TabIndex = 93;
            this.v_C1Flag01.Text = "OCF_MOVING_SILENTLY";
            // 
            // v_C1Flag00
            // 
            this.v_C1Flag00.Enabled = false;
            this.v_C1Flag00.Location = new System.Drawing.Point(88, 16);
            this.v_C1Flag00.Name = "v_C1Flag00";
            this.v_C1Flag00.Size = new System.Drawing.Size(184, 16);
            this.v_C1Flag00.TabIndex = 92;
            this.v_C1Flag00.Text = "OCF_IS_CONCEALED";
            // 
            // p_OCF
            // 
            this.p_OCF.Location = new System.Drawing.Point(8, 8);
            this.p_OCF.Name = "p_OCF";
            this.p_OCF.Size = new System.Drawing.Size(96, 24);
            this.p_OCF.TabIndex = 91;
            this.p_OCF.Text = "Crit. Flags 1:";
            this.p_OCF.CheckedChanged += new System.EventHandler(this.p_OCF_CheckedChanged);
            // 
            // j
            // 
            this.j.BackColor = System.Drawing.SystemColors.Control;
            this.j.Controls.Add(this.v_C2Flag27);
            this.j.Controls.Add(this.v_C2Flag26);
            this.j.Controls.Add(this.v_C2Flag25);
            this.j.Controls.Add(this.v_C2Flag24);
            this.j.Controls.Add(this.v_C2Flag23);
            this.j.Controls.Add(this.v_C2Flag22);
            this.j.Controls.Add(this.v_C2Flag21);
            this.j.Controls.Add(this.v_C2Flag20);
            this.j.Controls.Add(this.v_C2Flag19);
            this.j.Controls.Add(this.v_C2Flag18);
            this.j.Controls.Add(this.v_C2Flag17);
            this.j.Controls.Add(this.v_C2Flag16);
            this.j.Controls.Add(this.v_C2Flag15);
            this.j.Controls.Add(this.v_C2Flag14);
            this.j.Controls.Add(this.v_C2Flag13);
            this.j.Controls.Add(this.v_C2Flag12);
            this.j.Controls.Add(this.v_C2Flag11);
            this.j.Controls.Add(this.v_C2Flag10);
            this.j.Controls.Add(this.v_C2Flag09);
            this.j.Controls.Add(this.v_C2Flag08);
            this.j.Controls.Add(this.v_C2Flag07);
            this.j.Controls.Add(this.v_C2Flag06);
            this.j.Controls.Add(this.v_C2Flag05);
            this.j.Controls.Add(this.v_C2Flag04);
            this.j.Controls.Add(this.v_C2Flag03);
            this.j.Controls.Add(this.v_C2Flag02);
            this.j.Controls.Add(this.v_C2Flag01);
            this.j.Controls.Add(this.v_C2Flag00);
            this.j.Controls.Add(this.p_OCF2);
            this.j.Location = new System.Drawing.Point(4, 22);
            this.j.Name = "j";
            this.j.Size = new System.Drawing.Size(456, 534);
            this.j.TabIndex = 12;
            this.j.Text = "Critter Flags 2";
            // 
            // v_C2Flag27
            // 
            this.v_C2Flag27.Enabled = false;
            this.v_C2Flag27.Location = new System.Drawing.Point(88, 448);
            this.v_C2Flag27.Name = "v_C2Flag27";
            this.v_C2Flag27.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag27.TabIndex = 145;
            this.v_C2Flag27.Text = "OCF2_ACTION5_PAUSED";
            // 
            // v_C2Flag26
            // 
            this.v_C2Flag26.Enabled = false;
            this.v_C2Flag26.Location = new System.Drawing.Point(88, 432);
            this.v_C2Flag26.Name = "v_C2Flag26";
            this.v_C2Flag26.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag26.TabIndex = 144;
            this.v_C2Flag26.Text = "OCF2_ACTION4_PAUSED";
            // 
            // v_C2Flag25
            // 
            this.v_C2Flag25.Enabled = false;
            this.v_C2Flag25.Location = new System.Drawing.Point(88, 416);
            this.v_C2Flag25.Name = "v_C2Flag25";
            this.v_C2Flag25.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag25.TabIndex = 143;
            this.v_C2Flag25.Text = "OCF2_ACTION3_PAUSED";
            // 
            // v_C2Flag24
            // 
            this.v_C2Flag24.Enabled = false;
            this.v_C2Flag24.Location = new System.Drawing.Point(88, 400);
            this.v_C2Flag24.Name = "v_C2Flag24";
            this.v_C2Flag24.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag24.TabIndex = 142;
            this.v_C2Flag24.Text = "OCF2_ACTION2_PAUSED";
            // 
            // v_C2Flag23
            // 
            this.v_C2Flag23.Enabled = false;
            this.v_C2Flag23.Location = new System.Drawing.Point(88, 384);
            this.v_C2Flag23.Name = "v_C2Flag23";
            this.v_C2Flag23.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag23.TabIndex = 141;
            this.v_C2Flag23.Text = "OCF2_ACTION1_PAUSED";
            // 
            // v_C2Flag22
            // 
            this.v_C2Flag22.Enabled = false;
            this.v_C2Flag22.Location = new System.Drawing.Point(88, 368);
            this.v_C2Flag22.Name = "v_C2Flag22";
            this.v_C2Flag22.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag22.TabIndex = 140;
            this.v_C2Flag22.Text = "OCF2_ACTION0_PAUSED";
            // 
            // v_C2Flag21
            // 
            this.v_C2Flag21.Enabled = false;
            this.v_C2Flag21.Location = new System.Drawing.Point(88, 352);
            this.v_C2Flag21.Name = "v_C2Flag21";
            this.v_C2Flag21.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag21.TabIndex = 139;
            this.v_C2Flag21.Text = "OCF2_TARGET_LOCK";
            // 
            // v_C2Flag20
            // 
            this.v_C2Flag20.Enabled = false;
            this.v_C2Flag20.Location = new System.Drawing.Point(88, 336);
            this.v_C2Flag20.Name = "v_C2Flag20";
            this.v_C2Flag20.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag20.TabIndex = 138;
            this.v_C2Flag20.Text = "OCF2_REACTION_6";
            // 
            // v_C2Flag19
            // 
            this.v_C2Flag19.Enabled = false;
            this.v_C2Flag19.Location = new System.Drawing.Point(88, 320);
            this.v_C2Flag19.Name = "v_C2Flag19";
            this.v_C2Flag19.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag19.TabIndex = 137;
            this.v_C2Flag19.Text = "OCF2_REACTION_5";
            // 
            // v_C2Flag18
            // 
            this.v_C2Flag18.Enabled = false;
            this.v_C2Flag18.Location = new System.Drawing.Point(88, 304);
            this.v_C2Flag18.Name = "v_C2Flag18";
            this.v_C2Flag18.Size = new System.Drawing.Size(192, 16);
            this.v_C2Flag18.TabIndex = 136;
            this.v_C2Flag18.Text = "OCF2_REACTION_4";
            // 
            // v_C2Flag17
            // 
            this.v_C2Flag17.Enabled = false;
            this.v_C2Flag17.Location = new System.Drawing.Point(88, 288);
            this.v_C2Flag17.Name = "v_C2Flag17";
            this.v_C2Flag17.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag17.TabIndex = 135;
            this.v_C2Flag17.Text = "OCF2_REACTION_3";
            // 
            // v_C2Flag16
            // 
            this.v_C2Flag16.Enabled = false;
            this.v_C2Flag16.Location = new System.Drawing.Point(88, 272);
            this.v_C2Flag16.Name = "v_C2Flag16";
            this.v_C2Flag16.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag16.TabIndex = 134;
            this.v_C2Flag16.Text = "OCF2_REACTION_2";
            // 
            // v_C2Flag15
            // 
            this.v_C2Flag15.Enabled = false;
            this.v_C2Flag15.Location = new System.Drawing.Point(88, 256);
            this.v_C2Flag15.Name = "v_C2Flag15";
            this.v_C2Flag15.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag15.TabIndex = 133;
            this.v_C2Flag15.Text = "OCF2_REACTION_1";
            // 
            // v_C2Flag14
            // 
            this.v_C2Flag14.Enabled = false;
            this.v_C2Flag14.Location = new System.Drawing.Point(88, 240);
            this.v_C2Flag14.Name = "v_C2Flag14";
            this.v_C2Flag14.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag14.TabIndex = 132;
            this.v_C2Flag14.Text = "OCF2_REACTION_0";
            // 
            // v_C2Flag13
            // 
            this.v_C2Flag13.Enabled = false;
            this.v_C2Flag13.Location = new System.Drawing.Point(88, 224);
            this.v_C2Flag13.Name = "v_C2Flag13";
            this.v_C2Flag13.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag13.TabIndex = 131;
            this.v_C2Flag13.Text = "OCF2_NO_DISINTEGRATE";
            // 
            // v_C2Flag12
            // 
            this.v_C2Flag12.Enabled = false;
            this.v_C2Flag12.Location = new System.Drawing.Point(88, 208);
            this.v_C2Flag12.Name = "v_C2Flag12";
            this.v_C2Flag12.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag12.TabIndex = 130;
            this.v_C2Flag12.Text = "OCF2_NO_SLIP";
            // 
            // v_C2Flag11
            // 
            this.v_C2Flag11.Enabled = false;
            this.v_C2Flag11.Location = new System.Drawing.Point(88, 192);
            this.v_C2Flag11.Name = "v_C2Flag11";
            this.v_C2Flag11.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag11.TabIndex = 129;
            this.v_C2Flag11.Text = "OCF2_DARK_SIGHT";
            // 
            // v_C2Flag10
            // 
            this.v_C2Flag10.Enabled = false;
            this.v_C2Flag10.Location = new System.Drawing.Point(88, 176);
            this.v_C2Flag10.Name = "v_C2Flag10";
            this.v_C2Flag10.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag10.TabIndex = 128;
            this.v_C2Flag10.Text = "OCF2_ELEMENTAL";
            // 
            // v_C2Flag09
            // 
            this.v_C2Flag09.Enabled = false;
            this.v_C2Flag09.Location = new System.Drawing.Point(88, 160);
            this.v_C2Flag09.Name = "v_C2Flag09";
            this.v_C2Flag09.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag09.TabIndex = 127;
            this.v_C2Flag09.Text = "OCF2_NIGH_INVULNERABLE";
            // 
            // v_C2Flag08
            // 
            this.v_C2Flag08.Enabled = false;
            this.v_C2Flag08.Location = new System.Drawing.Point(88, 144);
            this.v_C2Flag08.Name = "v_C2Flag08";
            this.v_C2Flag08.Size = new System.Drawing.Size(200, 16);
            this.v_C2Flag08.TabIndex = 126;
            this.v_C2Flag08.Text = "OCF2_NO_BLOOD_SPLOTCHES";
            // 
            // v_C2Flag07
            // 
            this.v_C2Flag07.Enabled = false;
            this.v_C2Flag07.Location = new System.Drawing.Point(88, 128);
            this.v_C2Flag07.Name = "v_C2Flag07";
            this.v_C2Flag07.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag07.TabIndex = 125;
            this.v_C2Flag07.Text = "OCF2_NO_PICKPOCKET";
            // 
            // v_C2Flag06
            // 
            this.v_C2Flag06.Enabled = false;
            this.v_C2Flag06.Location = new System.Drawing.Point(88, 112);
            this.v_C2Flag06.Name = "v_C2Flag06";
            this.v_C2Flag06.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag06.TabIndex = 124;
            this.v_C2Flag06.Text = "OCF2_NO_DECAY";
            // 
            // v_C2Flag05
            // 
            this.v_C2Flag05.Enabled = false;
            this.v_C2Flag05.Location = new System.Drawing.Point(88, 96);
            this.v_C2Flag05.Name = "v_C2Flag05";
            this.v_C2Flag05.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag05.TabIndex = 123;
            this.v_C2Flag05.Text = "OCF2_UNUSED_00000020";
            // 
            // v_C2Flag04
            // 
            this.v_C2Flag04.Enabled = false;
            this.v_C2Flag04.Location = new System.Drawing.Point(88, 80);
            this.v_C2Flag04.Name = "v_C2Flag04";
            this.v_C2Flag04.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag04.TabIndex = 122;
            this.v_C2Flag04.Text = "OCF2_SLOW_PARTY";
            // 
            // v_C2Flag03
            // 
            this.v_C2Flag03.Enabled = false;
            this.v_C2Flag03.Location = new System.Drawing.Point(88, 64);
            this.v_C2Flag03.Name = "v_C2Flag03";
            this.v_C2Flag03.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag03.TabIndex = 121;
            this.v_C2Flag03.Text = "OCF2_FATIGUE_DRAINING";
            // 
            // v_C2Flag02
            // 
            this.v_C2Flag02.Enabled = false;
            this.v_C2Flag02.Location = new System.Drawing.Point(88, 48);
            this.v_C2Flag02.Name = "v_C2Flag02";
            this.v_C2Flag02.Size = new System.Drawing.Size(192, 16);
            this.v_C2Flag02.TabIndex = 120;
            this.v_C2Flag02.Text = "OCF2_USING_BOOMERANG";
            // 
            // v_C2Flag01
            // 
            this.v_C2Flag01.Enabled = false;
            this.v_C2Flag01.Location = new System.Drawing.Point(88, 32);
            this.v_C2Flag01.Name = "v_C2Flag01";
            this.v_C2Flag01.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag01.TabIndex = 119;
            this.v_C2Flag01.Text = "OCF2_AUTO_ANIMATES";
            // 
            // v_C2Flag00
            // 
            this.v_C2Flag00.Enabled = false;
            this.v_C2Flag00.Location = new System.Drawing.Point(88, 16);
            this.v_C2Flag00.Name = "v_C2Flag00";
            this.v_C2Flag00.Size = new System.Drawing.Size(184, 16);
            this.v_C2Flag00.TabIndex = 118;
            this.v_C2Flag00.Text = "OCF2_ITEM_STOLEN";
            // 
            // p_OCF2
            // 
            this.p_OCF2.Location = new System.Drawing.Point(8, 8);
            this.p_OCF2.Name = "p_OCF2";
            this.p_OCF2.Size = new System.Drawing.Size(96, 24);
            this.p_OCF2.TabIndex = 117;
            this.p_OCF2.Text = "Crit. Flags 2:";
            this.p_OCF2.CheckedChanged += new System.EventHandler(this.p_OCF2_CheckedChanged);
            // 
            // k
            // 
            this.k.BackColor = System.Drawing.SystemColors.Control;
            this.k.Controls.Add(this.pWorth);
            this.k.Controls.Add(this.vWorth);
            this.k.Controls.Add(this.pWeight);
            this.k.Controls.Add(this.vWeight);
            this.k.Controls.Add(this.pItemAmt);
            this.k.Controls.Add(this.vItemAmt);
            this.k.Controls.Add(this.pItmFlag26);
            this.k.Controls.Add(this.pItmFlag25);
            this.k.Controls.Add(this.pItmFlag24);
            this.k.Controls.Add(this.pItmFlag23);
            this.k.Controls.Add(this.pItmFlag22);
            this.k.Controls.Add(this.pItmFlag21);
            this.k.Controls.Add(this.pItmFlag20);
            this.k.Controls.Add(this.pItmFlag19);
            this.k.Controls.Add(this.pItmFlag18);
            this.k.Controls.Add(this.pItmFlag17);
            this.k.Controls.Add(this.pItmFlag16);
            this.k.Controls.Add(this.pItmFlag15);
            this.k.Controls.Add(this.pItmFlag14);
            this.k.Controls.Add(this.pItmFlag13);
            this.k.Controls.Add(this.pItmFlag12);
            this.k.Controls.Add(this.pItmFlag11);
            this.k.Controls.Add(this.pItmFlag10);
            this.k.Controls.Add(this.pItmFlag09);
            this.k.Controls.Add(this.pItmFlag08);
            this.k.Controls.Add(this.pItmFlag07);
            this.k.Controls.Add(this.pItmFlag06);
            this.k.Controls.Add(this.pItmFlag05);
            this.k.Controls.Add(this.pItmFlag04);
            this.k.Controls.Add(this.pItmFlag03);
            this.k.Controls.Add(this.pItmFlag02);
            this.k.Controls.Add(this.pItmFlag01);
            this.k.Controls.Add(this.pItmFlag00);
            this.k.Controls.Add(this.p_OIF);
            this.k.Controls.Add(this.vParent);
            this.k.Controls.Add(this.tParent);
            this.k.Controls.Add(this.pParent);
            this.k.Controls.Add(this.pInvSlot);
            this.k.Controls.Add(this.vInvSlot);
            this.k.Location = new System.Drawing.Point(4, 22);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(456, 534);
            this.k.TabIndex = 1;
            this.k.Text = "Items";
            // 
            // pWorth
            // 
            this.pWorth.Location = new System.Drawing.Point(216, 30);
            this.pWorth.Name = "pWorth";
            this.pWorth.Size = new System.Drawing.Size(96, 24);
            this.pWorth.TabIndex = 55;
            this.pWorth.Text = "Item Worth:";
            this.pWorth.CheckedChanged += new System.EventHandler(this.pWorth_CheckedChanged);
            // 
            // vWorth
            // 
            this.vWorth.Enabled = false;
            this.vWorth.Location = new System.Drawing.Point(312, 32);
            this.vWorth.Name = "vWorth";
            this.vWorth.Size = new System.Drawing.Size(136, 20);
            this.vWorth.TabIndex = 54;
            this.vWorth.Text = "0";
            // 
            // pWeight
            // 
            this.pWeight.Location = new System.Drawing.Point(216, 8);
            this.pWeight.Name = "pWeight";
            this.pWeight.Size = new System.Drawing.Size(96, 24);
            this.pWeight.TabIndex = 53;
            this.pWeight.Text = "Item Weight:";
            this.pWeight.CheckedChanged += new System.EventHandler(this.pWeight_CheckedChanged);
            // 
            // vWeight
            // 
            this.vWeight.Enabled = false;
            this.vWeight.Location = new System.Drawing.Point(312, 8);
            this.vWeight.Name = "vWeight";
            this.vWeight.Size = new System.Drawing.Size(136, 20);
            this.vWeight.TabIndex = 52;
            this.vWeight.Text = "0";
            // 
            // pItemAmt
            // 
            this.pItemAmt.Location = new System.Drawing.Point(8, 32);
            this.pItemAmt.Name = "pItemAmt";
            this.pItemAmt.Size = new System.Drawing.Size(152, 24);
            this.pItemAmt.TabIndex = 51;
            this.pItemAmt.Text = "Item Quantity:";
            this.pItemAmt.CheckedChanged += new System.EventHandler(this.pItemAmt_CheckedChanged);
            // 
            // vItemAmt
            // 
            this.vItemAmt.Enabled = false;
            this.vItemAmt.Location = new System.Drawing.Point(160, 32);
            this.vItemAmt.Name = "vItemAmt";
            this.vItemAmt.Size = new System.Drawing.Size(40, 20);
            this.vItemAmt.TabIndex = 50;
            this.vItemAmt.Text = "0";
            // 
            // pItmFlag26
            // 
            this.pItmFlag26.Location = new System.Drawing.Point(80, 512);
            this.pItmFlag26.Name = "pItmFlag26";
            this.pItmFlag26.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag26.TabIndex = 49;
            this.pItmFlag26.Text = "OIF_NO_TRANSFER";
            // 
            // pItmFlag25
            // 
            this.pItmFlag25.Location = new System.Drawing.Point(80, 496);
            this.pItmFlag25.Name = "pItmFlag25";
            this.pItmFlag25.Size = new System.Drawing.Size(160, 16);
            this.pItmFlag25.TabIndex = 48;
            this.pItmFlag25.Text = "OIF_USES_WAND_ANIM";
            // 
            // pItmFlag24
            // 
            this.pItmFlag24.Location = new System.Drawing.Point(80, 480);
            this.pItmFlag24.Name = "pItmFlag24";
            this.pItmFlag24.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag24.TabIndex = 47;
            this.pItmFlag24.Text = "OIF_NO_LOOT";
            // 
            // pItmFlag23
            // 
            this.pItmFlag23.Location = new System.Drawing.Point(80, 464);
            this.pItmFlag23.Name = "pItmFlag23";
            this.pItmFlag23.Size = new System.Drawing.Size(184, 16);
            this.pItmFlag23.TabIndex = 46;
            this.pItmFlag23.Text = "OIF_EXPIRES_AFTER_USE";
            // 
            // pItmFlag22
            // 
            this.pItmFlag22.Location = new System.Drawing.Point(80, 448);
            this.pItmFlag22.Name = "pItmFlag22";
            this.pItmFlag22.Size = new System.Drawing.Size(192, 16);
            this.pItmFlag22.TabIndex = 45;
            this.pItmFlag22.Text = "OIF_DRAW_WHEN_PARENTED";
            // 
            // pItmFlag21
            // 
            this.pItmFlag21.Location = new System.Drawing.Point(80, 432);
            this.pItmFlag21.Name = "pItmFlag21";
            this.pItmFlag21.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag21.TabIndex = 44;
            this.pItmFlag21.Text = "OIF_VALID_AI_ACTION";
            // 
            // pItmFlag20
            // 
            this.pItmFlag20.Location = new System.Drawing.Point(80, 416);
            this.pItmFlag20.Name = "pItmFlag20";
            this.pItmFlag20.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag20.TabIndex = 43;
            this.pItmFlag20.Text = "OIF_NO_RANGED_USE";
            // 
            // pItmFlag19
            // 
            this.pItmFlag19.Location = new System.Drawing.Point(80, 400);
            this.pItmFlag19.Name = "pItmFlag19";
            this.pItmFlag19.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag19.TabIndex = 42;
            this.pItmFlag19.Text = "OIF_NO_NPC_PICKUP";
            // 
            // pItmFlag18
            // 
            this.pItmFlag18.Location = new System.Drawing.Point(80, 384);
            this.pItmFlag18.Name = "pItmFlag18";
            this.pItmFlag18.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag18.TabIndex = 41;
            this.pItmFlag18.Text = "OIF_UBER";
            // 
            // pItmFlag17
            // 
            this.pItmFlag17.Location = new System.Drawing.Point(80, 368);
            this.pItmFlag17.Name = "pItmFlag17";
            this.pItmFlag17.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag17.TabIndex = 40;
            this.pItmFlag17.Text = "OIF_NO_DECAY";
            // 
            // pItmFlag16
            // 
            this.pItmFlag16.Location = new System.Drawing.Point(80, 352);
            this.pItmFlag16.Name = "pItmFlag16";
            this.pItmFlag16.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag16.TabIndex = 39;
            this.pItmFlag16.Text = "OIF_USE_IS_THROW";
            // 
            // pItmFlag15
            // 
            this.pItmFlag15.Location = new System.Drawing.Point(80, 336);
            this.pItmFlag15.Name = "pItmFlag15";
            this.pItmFlag15.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag15.TabIndex = 38;
            this.pItmFlag15.Text = "OIF_STOLEN";
            // 
            // pItmFlag14
            // 
            this.pItmFlag14.Location = new System.Drawing.Point(80, 320);
            this.pItmFlag14.Name = "pItmFlag14";
            this.pItmFlag14.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag14.TabIndex = 37;
            this.pItmFlag14.Text = "OIF_MT_TRIGGERED";
            // 
            // pItmFlag13
            // 
            this.pItmFlag13.Location = new System.Drawing.Point(80, 304);
            this.pItmFlag13.Name = "pItmFlag13";
            this.pItmFlag13.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag13.TabIndex = 36;
            this.pItmFlag13.Text = "OIF_PERSISTENT";
            // 
            // pItmFlag12
            // 
            this.pItmFlag12.Location = new System.Drawing.Point(80, 288);
            this.pItmFlag12.Name = "pItmFlag12";
            this.pItmFlag12.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag12.TabIndex = 35;
            this.pItmFlag12.Text = "OIF_LIGHT_XLARGE";
            // 
            // pItmFlag11
            // 
            this.pItmFlag11.Location = new System.Drawing.Point(80, 272);
            this.pItmFlag11.Name = "pItmFlag11";
            this.pItmFlag11.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag11.TabIndex = 34;
            this.pItmFlag11.Text = "OIF_LIGHT_LARGE";
            // 
            // pItmFlag10
            // 
            this.pItmFlag10.Location = new System.Drawing.Point(80, 256);
            this.pItmFlag10.Name = "pItmFlag10";
            this.pItmFlag10.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag10.TabIndex = 33;
            this.pItmFlag10.Text = "OIF_LIGHT_MEDIUM";
            // 
            // pItmFlag09
            // 
            this.pItmFlag09.Location = new System.Drawing.Point(80, 240);
            this.pItmFlag09.Name = "pItmFlag09";
            this.pItmFlag09.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag09.TabIndex = 32;
            this.pItmFlag09.Text = "OIF_LIGHT_SMALL";
            // 
            // pItmFlag08
            // 
            this.pItmFlag08.Location = new System.Drawing.Point(80, 224);
            this.pItmFlag08.Name = "pItmFlag08";
            this.pItmFlag08.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag08.TabIndex = 31;
            this.pItmFlag08.Text = "OIF_NEEDS_TARGET";
            // 
            // pItmFlag07
            // 
            this.pItmFlag07.Location = new System.Drawing.Point(80, 208);
            this.pItmFlag07.Name = "pItmFlag07";
            this.pItmFlag07.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag07.TabIndex = 30;
            this.pItmFlag07.Text = "OIF_CAN_USE_BOX";
            // 
            // pItmFlag06
            // 
            this.pItmFlag06.Location = new System.Drawing.Point(80, 192);
            this.pItmFlag06.Name = "pItmFlag06";
            this.pItmFlag06.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag06.TabIndex = 29;
            this.pItmFlag06.Text = "OIF_NEEDS_SPELL";
            // 
            // pItmFlag05
            // 
            this.pItmFlag05.Location = new System.Drawing.Point(80, 176);
            this.pItmFlag05.Name = "pItmFlag05";
            this.pItmFlag05.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag05.TabIndex = 28;
            this.pItmFlag05.Text = "OIF_NO_DROP";
            // 
            // pItmFlag04
            // 
            this.pItmFlag04.Location = new System.Drawing.Point(80, 160);
            this.pItmFlag04.Name = "pItmFlag04";
            this.pItmFlag04.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag04.TabIndex = 27;
            this.pItmFlag04.Text = "OIF_NO_DISPLAY";
            // 
            // pItmFlag03
            // 
            this.pItmFlag03.Location = new System.Drawing.Point(80, 144);
            this.pItmFlag03.Name = "pItmFlag03";
            this.pItmFlag03.Size = new System.Drawing.Size(152, 16);
            this.pItmFlag03.TabIndex = 26;
            this.pItmFlag03.Text = "OIF_NO_PICKPOCKET";
            // 
            // pItmFlag02
            // 
            this.pItmFlag02.Location = new System.Drawing.Point(80, 128);
            this.pItmFlag02.Name = "pItmFlag02";
            this.pItmFlag02.Size = new System.Drawing.Size(136, 16);
            this.pItmFlag02.TabIndex = 25;
            this.pItmFlag02.Text = "OIF_IS_MAGICAL";
            // 
            // pItmFlag01
            // 
            this.pItmFlag01.Location = new System.Drawing.Point(80, 112);
            this.pItmFlag01.Name = "pItmFlag01";
            this.pItmFlag01.Size = new System.Drawing.Size(136, 16);
            this.pItmFlag01.TabIndex = 24;
            this.pItmFlag01.Text = "OIF_WONT_SELL";
            // 
            // pItmFlag00
            // 
            this.pItmFlag00.Location = new System.Drawing.Point(80, 96);
            this.pItmFlag00.Name = "pItmFlag00";
            this.pItmFlag00.Size = new System.Drawing.Size(136, 16);
            this.pItmFlag00.TabIndex = 23;
            this.pItmFlag00.Text = "OIF_IDENTIFIED";
            // 
            // p_OIF
            // 
            this.p_OIF.Location = new System.Drawing.Point(8, 88);
            this.p_OIF.Name = "p_OIF";
            this.p_OIF.Size = new System.Drawing.Size(80, 24);
            this.p_OIF.TabIndex = 22;
            this.p_OIF.Text = "Item flags:";
            this.p_OIF.CheckedChanged += new System.EventHandler(this.p_OIF_CheckedChanged);
            // 
            // vParent
            // 
            this.vParent.Location = new System.Drawing.Point(112, 56);
            this.vParent.Name = "vParent";
            this.vParent.Size = new System.Drawing.Size(24, 23);
            this.vParent.TabIndex = 21;
            this.vParent.Text = "...";
            this.vParent.Click += new System.EventHandler(this.vParent_Click);
            // 
            // tParent
            // 
            this.tParent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tParent.Location = new System.Drawing.Point(142, 61);
            this.tParent.Name = "tParent";
            this.tParent.Size = new System.Drawing.Size(293, 16);
            this.tParent.TabIndex = 20;
            this.tParent.Text = "PARENT OBJECT NOT DEFINED";
            // 
            // pParent
            // 
            this.pParent.Location = new System.Drawing.Point(8, 56);
            this.pParent.Name = "pParent";
            this.pParent.Size = new System.Drawing.Size(112, 24);
            this.pParent.TabIndex = 19;
            this.pParent.Text = "Parent Container:";
            this.pParent.CheckedChanged += new System.EventHandler(this.pParent_CheckedChanged);
            // 
            // pInvSlot
            // 
            this.pInvSlot.Location = new System.Drawing.Point(8, 8);
            this.pInvSlot.Name = "pInvSlot";
            this.pInvSlot.Size = new System.Drawing.Size(152, 24);
            this.pInvSlot.TabIndex = 18;
            this.pInvSlot.Text = "Inventory Slot (Location):";
            this.pInvSlot.CheckedChanged += new System.EventHandler(this.pInvSlot_CheckedChanged);
            // 
            // vInvSlot
            // 
            this.vInvSlot.Enabled = false;
            this.vInvSlot.Location = new System.Drawing.Point(160, 10);
            this.vInvSlot.Name = "vInvSlot";
            this.vInvSlot.Size = new System.Drawing.Size(40, 20);
            this.vInvSlot.TabIndex = 18;
            this.vInvSlot.Text = "0";
            // 
            // l
            // 
            this.l.BackColor = System.Drawing.SystemColors.Control;
            this.l.Controls.Add(this.vArmorChk);
            this.l.Controls.Add(this.pArmorChk);
            this.l.Controls.Add(this.vSpellFail);
            this.l.Controls.Add(this.pSpellFail);
            this.l.Controls.Add(this.vACMaxDex);
            this.l.Controls.Add(this.pACMaxDex);
            this.l.Controls.Add(this.vACAdj);
            this.l.Controls.Add(this.pACAdj);
            this.l.Controls.Add(this.v_OAFlag04);
            this.l.Controls.Add(this.v_OAFlag03);
            this.l.Controls.Add(this.v_OAFlag02);
            this.l.Controls.Add(this.v_OAFlag01);
            this.l.Controls.Add(this.v_OAFlag00);
            this.l.Controls.Add(this.p_OARF);
            this.l.Location = new System.Drawing.Point(4, 22);
            this.l.Name = "l";
            this.l.Size = new System.Drawing.Size(456, 534);
            this.l.TabIndex = 8;
            this.l.Text = "Armor";
            // 
            // vArmorChk
            // 
            this.vArmorChk.Enabled = false;
            this.vArmorChk.Location = new System.Drawing.Point(128, 186);
            this.vArmorChk.Name = "vArmorChk";
            this.vArmorChk.Size = new System.Drawing.Size(48, 20);
            this.vArmorChk.TabIndex = 110;
            this.vArmorChk.Text = "0";
            // 
            // pArmorChk
            // 
            this.pArmorChk.Location = new System.Drawing.Point(8, 184);
            this.pArmorChk.Name = "pArmorChk";
            this.pArmorChk.Size = new System.Drawing.Size(136, 24);
            this.pArmorChk.TabIndex = 109;
            this.pArmorChk.Text = "Armor Check Penalty:";
            this.pArmorChk.CheckedChanged += new System.EventHandler(this.pArmorChk_CheckedChanged);
            // 
            // vSpellFail
            // 
            this.vSpellFail.Enabled = false;
            this.vSpellFail.Location = new System.Drawing.Point(128, 162);
            this.vSpellFail.Name = "vSpellFail";
            this.vSpellFail.Size = new System.Drawing.Size(48, 20);
            this.vSpellFail.TabIndex = 108;
            this.vSpellFail.Text = "0";
            // 
            // pSpellFail
            // 
            this.pSpellFail.Location = new System.Drawing.Point(8, 160);
            this.pSpellFail.Name = "pSpellFail";
            this.pSpellFail.Size = new System.Drawing.Size(128, 24);
            this.pSpellFail.TabIndex = 107;
            this.pSpellFail.Text = "Arcane Spell Failure:";
            this.pSpellFail.CheckedChanged += new System.EventHandler(this.pSpellFail_CheckedChanged);
            // 
            // vACMaxDex
            // 
            this.vACMaxDex.Enabled = false;
            this.vACMaxDex.Location = new System.Drawing.Point(104, 138);
            this.vACMaxDex.Name = "vACMaxDex";
            this.vACMaxDex.Size = new System.Drawing.Size(48, 20);
            this.vACMaxDex.TabIndex = 106;
            this.vACMaxDex.Text = "0";
            // 
            // pACMaxDex
            // 
            this.pACMaxDex.Location = new System.Drawing.Point(8, 136);
            this.pACMaxDex.Name = "pACMaxDex";
            this.pACMaxDex.Size = new System.Drawing.Size(112, 24);
            this.pACMaxDex.TabIndex = 105;
            this.pACMaxDex.Text = "Max Dex Bonus:";
            this.pACMaxDex.CheckedChanged += new System.EventHandler(this.pACMaxDex_CheckedChanged);
            // 
            // vACAdj
            // 
            this.vACAdj.Enabled = false;
            this.vACAdj.Location = new System.Drawing.Point(104, 112);
            this.vACAdj.Name = "vACAdj";
            this.vACAdj.Size = new System.Drawing.Size(48, 20);
            this.vACAdj.TabIndex = 104;
            this.vACAdj.Text = "0";
            // 
            // pACAdj
            // 
            this.pACAdj.Location = new System.Drawing.Point(8, 112);
            this.pACAdj.Name = "pACAdj";
            this.pACAdj.Size = new System.Drawing.Size(104, 24);
            this.pACAdj.TabIndex = 103;
            this.pACAdj.Text = "AC Adjustment:";
            this.pACAdj.CheckedChanged += new System.EventHandler(this.pACAdj_CheckedChanged);
            // 
            // v_OAFlag04
            // 
            this.v_OAFlag04.Enabled = false;
            this.v_OAFlag04.Location = new System.Drawing.Point(64, 80);
            this.v_OAFlag04.Name = "v_OAFlag04";
            this.v_OAFlag04.Size = new System.Drawing.Size(184, 16);
            this.v_OAFlag04.TabIndex = 102;
            this.v_OAFlag04.Text = "OARF_ARMOR_NONE";
            // 
            // v_OAFlag03
            // 
            this.v_OAFlag03.Enabled = false;
            this.v_OAFlag03.Location = new System.Drawing.Point(64, 64);
            this.v_OAFlag03.Name = "v_OAFlag03";
            this.v_OAFlag03.Size = new System.Drawing.Size(184, 16);
            this.v_OAFlag03.TabIndex = 101;
            this.v_OAFlag03.Text = "OARF_HELM_TYPE_2";
            // 
            // v_OAFlag02
            // 
            this.v_OAFlag02.Enabled = false;
            this.v_OAFlag02.Location = new System.Drawing.Point(64, 48);
            this.v_OAFlag02.Name = "v_OAFlag02";
            this.v_OAFlag02.Size = new System.Drawing.Size(192, 16);
            this.v_OAFlag02.TabIndex = 100;
            this.v_OAFlag02.Text = "OARF_HELM_TYPE_1";
            // 
            // v_OAFlag01
            // 
            this.v_OAFlag01.Enabled = false;
            this.v_OAFlag01.Location = new System.Drawing.Point(64, 32);
            this.v_OAFlag01.Name = "v_OAFlag01";
            this.v_OAFlag01.Size = new System.Drawing.Size(184, 16);
            this.v_OAFlag01.TabIndex = 99;
            this.v_OAFlag01.Text = "OARF_ARMOR_TYPE_2";
            // 
            // v_OAFlag00
            // 
            this.v_OAFlag00.Enabled = false;
            this.v_OAFlag00.Location = new System.Drawing.Point(64, 16);
            this.v_OAFlag00.Name = "v_OAFlag00";
            this.v_OAFlag00.Size = new System.Drawing.Size(184, 16);
            this.v_OAFlag00.TabIndex = 98;
            this.v_OAFlag00.Text = "OARF_ARMOR_TYPE_1";
            // 
            // p_OARF
            // 
            this.p_OARF.Location = new System.Drawing.Point(8, 8);
            this.p_OARF.Name = "p_OARF";
            this.p_OARF.Size = new System.Drawing.Size(96, 24);
            this.p_OARF.TabIndex = 97;
            this.p_OARF.Text = "Flags:";
            this.p_OARF.CheckedChanged += new System.EventHandler(this.p_OARF_CheckedChanged);
            // 
            // m
            // 
            this.m.BackColor = System.Drawing.SystemColors.Control;
            this.m.Controls.Add(this.pAmmoAmt);
            this.m.Controls.Add(this.vAmmoAmt);
            this.m.Controls.Add(this.v_WFlag12);
            this.m.Controls.Add(this.v_WFlag11);
            this.m.Controls.Add(this.v_WFlag10);
            this.m.Controls.Add(this.v_WFlag09);
            this.m.Controls.Add(this.v_WFlag08);
            this.m.Controls.Add(this.v_WFlag07);
            this.m.Controls.Add(this.v_WFlag06);
            this.m.Controls.Add(this.v_WFlag05);
            this.m.Controls.Add(this.v_WFlag04);
            this.m.Controls.Add(this.v_WFlag03);
            this.m.Controls.Add(this.v_WFlag02);
            this.m.Controls.Add(this.v_WFlag01);
            this.m.Controls.Add(this.v_WFlag00);
            this.m.Controls.Add(this.p_OWF);
            this.m.Location = new System.Drawing.Point(4, 22);
            this.m.Name = "m";
            this.m.Size = new System.Drawing.Size(456, 534);
            this.m.TabIndex = 9;
            this.m.Text = "Weapon / Ammo";
            // 
            // pAmmoAmt
            // 
            this.pAmmoAmt.Location = new System.Drawing.Point(8, 232);
            this.pAmmoAmt.Name = "pAmmoAmt";
            this.pAmmoAmt.Size = new System.Drawing.Size(160, 24);
            this.pAmmoAmt.TabIndex = 118;
            this.pAmmoAmt.Text = "Quantity (Only For Ammo):";
            this.pAmmoAmt.CheckedChanged += new System.EventHandler(this.pAmmoAmt_CheckedChanged);
            // 
            // vAmmoAmt
            // 
            this.vAmmoAmt.Enabled = false;
            this.vAmmoAmt.Location = new System.Drawing.Point(168, 234);
            this.vAmmoAmt.Name = "vAmmoAmt";
            this.vAmmoAmt.Size = new System.Drawing.Size(40, 20);
            this.vAmmoAmt.TabIndex = 117;
            this.vAmmoAmt.Text = "0";
            // 
            // v_WFlag12
            // 
            this.v_WFlag12.Enabled = false;
            this.v_WFlag12.Location = new System.Drawing.Point(64, 208);
            this.v_WFlag12.Name = "v_WFlag12";
            this.v_WFlag12.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag12.TabIndex = 116;
            this.v_WFlag12.Text = "OWF_MAGIC_STAFF";
            // 
            // v_WFlag11
            // 
            this.v_WFlag11.Enabled = false;
            this.v_WFlag11.Location = new System.Drawing.Point(64, 192);
            this.v_WFlag11.Name = "v_WFlag11";
            this.v_WFlag11.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag11.TabIndex = 115;
            this.v_WFlag11.Text = "OWF_WEAPON_LOADED";
            // 
            // v_WFlag10
            // 
            this.v_WFlag10.Enabled = false;
            this.v_WFlag10.Location = new System.Drawing.Point(64, 176);
            this.v_WFlag10.Name = "v_WFlag10";
            this.v_WFlag10.Size = new System.Drawing.Size(192, 16);
            this.v_WFlag10.TabIndex = 114;
            this.v_WFlag10.Text = "OWF_RANGED_WEAPON";
            // 
            // v_WFlag09
            // 
            this.v_WFlag09.Enabled = false;
            this.v_WFlag09.Location = new System.Drawing.Point(64, 160);
            this.v_WFlag09.Name = "v_WFlag09";
            this.v_WFlag09.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag09.TabIndex = 113;
            this.v_WFlag09.Text = "OWF_DEFAULT_THROWS";
            // 
            // v_WFlag08
            // 
            this.v_WFlag08.Enabled = false;
            this.v_WFlag08.Location = new System.Drawing.Point(64, 144);
            this.v_WFlag08.Name = "v_WFlag08";
            this.v_WFlag08.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag08.TabIndex = 112;
            this.v_WFlag08.Text = "OWF_DAMAGE_ARMOR";
            // 
            // v_WFlag07
            // 
            this.v_WFlag07.Enabled = false;
            this.v_WFlag07.Location = new System.Drawing.Point(64, 128);
            this.v_WFlag07.Name = "v_WFlag07";
            this.v_WFlag07.Size = new System.Drawing.Size(192, 16);
            this.v_WFlag07.TabIndex = 111;
            this.v_WFlag07.Text = "OWF_IGNORE_RESISTANCE";
            // 
            // v_WFlag06
            // 
            this.v_WFlag06.Enabled = false;
            this.v_WFlag06.Location = new System.Drawing.Point(64, 112);
            this.v_WFlag06.Name = "v_WFlag06";
            this.v_WFlag06.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag06.TabIndex = 110;
            this.v_WFlag06.Text = "OWF_BOOMERANGS";
            // 
            // v_WFlag05
            // 
            this.v_WFlag05.Enabled = false;
            this.v_WFlag05.Location = new System.Drawing.Point(64, 96);
            this.v_WFlag05.Name = "v_WFlag05";
            this.v_WFlag05.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag05.TabIndex = 109;
            this.v_WFlag05.Text = "OWF_TRANS_PROJECTILE";
            // 
            // v_WFlag04
            // 
            this.v_WFlag04.Enabled = false;
            this.v_WFlag04.Location = new System.Drawing.Point(64, 80);
            this.v_WFlag04.Name = "v_WFlag04";
            this.v_WFlag04.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag04.TabIndex = 108;
            this.v_WFlag04.Text = "OWF_THROWABLE";
            // 
            // v_WFlag03
            // 
            this.v_WFlag03.Enabled = false;
            this.v_WFlag03.Location = new System.Drawing.Point(64, 64);
            this.v_WFlag03.Name = "v_WFlag03";
            this.v_WFlag03.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag03.TabIndex = 107;
            this.v_WFlag03.Text = "OWF_UNUSED_2";
            // 
            // v_WFlag02
            // 
            this.v_WFlag02.Enabled = false;
            this.v_WFlag02.Location = new System.Drawing.Point(64, 48);
            this.v_WFlag02.Name = "v_WFlag02";
            this.v_WFlag02.Size = new System.Drawing.Size(192, 16);
            this.v_WFlag02.TabIndex = 106;
            this.v_WFlag02.Text = "OWF_UNUSED_1";
            // 
            // v_WFlag01
            // 
            this.v_WFlag01.Enabled = false;
            this.v_WFlag01.Location = new System.Drawing.Point(64, 32);
            this.v_WFlag01.Name = "v_WFlag01";
            this.v_WFlag01.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag01.TabIndex = 105;
            this.v_WFlag01.Text = "OWF_SILENT";
            // 
            // v_WFlag00
            // 
            this.v_WFlag00.Enabled = false;
            this.v_WFlag00.Location = new System.Drawing.Point(64, 16);
            this.v_WFlag00.Name = "v_WFlag00";
            this.v_WFlag00.Size = new System.Drawing.Size(184, 16);
            this.v_WFlag00.TabIndex = 104;
            this.v_WFlag00.Text = "OWF_LOUD";
            // 
            // p_OWF
            // 
            this.p_OWF.Location = new System.Drawing.Point(8, 8);
            this.p_OWF.Name = "p_OWF";
            this.p_OWF.Size = new System.Drawing.Size(96, 24);
            this.p_OWF.TabIndex = 103;
            this.p_OWF.Text = "Flags:";
            this.p_OWF.CheckedChanged += new System.EventHandler(this.p_OWF_CheckedChanged);
            // 
            // n
            // 
            this.n.BackColor = System.Drawing.SystemColors.Control;
            this.n.Controls.Add(this.vKeyID2);
            this.n.Controls.Add(this.pKeyID2);
            this.n.Location = new System.Drawing.Point(4, 22);
            this.n.Name = "n";
            this.n.Size = new System.Drawing.Size(456, 534);
            this.n.TabIndex = 6;
            this.n.Text = "Keys";
            // 
            // vKeyID2
            // 
            this.vKeyID2.Enabled = false;
            this.vKeyID2.Location = new System.Drawing.Point(80, 10);
            this.vKeyID2.Name = "vKeyID2";
            this.vKeyID2.Size = new System.Drawing.Size(40, 20);
            this.vKeyID2.TabIndex = 59;
            this.vKeyID2.Text = "0";
            // 
            // pKeyID2
            // 
            this.pKeyID2.Location = new System.Drawing.Point(8, 8);
            this.pKeyID2.Name = "pKeyID2";
            this.pKeyID2.Size = new System.Drawing.Size(72, 24);
            this.pKeyID2.TabIndex = 58;
            this.pKeyID2.Text = "Key ID:";
            this.pKeyID2.CheckedChanged += new System.EventHandler(this.pKeyID2_CheckedChanged);
            // 
            // btnChgGUID
            // 
            this.btnChgGUID.Location = new System.Drawing.Point(509, 7);
            this.btnChgGUID.Name = "btnChgGUID";
            this.btnChgGUID.Size = new System.Drawing.Size(67, 24);
            this.btnChgGUID.TabIndex = 16;
            this.btnChgGUID.Text = "New GUID";
            this.btnChgGUID.Click += new System.EventHandler(this.btnChgGUID_Click);
            // 
            // vRotation
            // 
            this.vRotation.Enabled = false;
            this.vRotation.Location = new System.Drawing.Point(80, 138);
            this.vRotation.Name = "vRotation";
            this.vRotation.Size = new System.Drawing.Size(112, 20);
            this.vRotation.TabIndex = 15;
            this.vRotation.Text = "0";
            // 
            // pRotation
            // 
            this.pRotation.Location = new System.Drawing.Point(8, 134);
            this.pRotation.Name = "pRotation";
            this.pRotation.Size = new System.Drawing.Size(80, 24);
            this.pRotation.TabIndex = 14;
            this.pRotation.Text = "Rotation:";
            this.pRotation.CheckedChanged += new System.EventHandler(this.pRotation_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(160, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y=";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(80, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "X=";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 24);
            this.label4.TabIndex = 9;
            this.label4.Text = "Location:";
            // 
            // MobType
            // 
            this.MobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MobType.Location = new System.Drawing.Point(80, 72);
            this.MobType.Name = "MobType";
            this.MobType.Size = new System.Drawing.Size(248, 21);
            this.MobType.TabIndex = 8;
            this.MobType.SelectedIndexChanged += new System.EventHandler(this.MobType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "Object Type:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(436, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(67, 24);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSaveMob
            // 
            this.btnSaveMob.Location = new System.Drawing.Point(655, 7);
            this.btnSaveMob.Name = "btnSaveMob";
            this.btnSaveMob.Size = new System.Drawing.Size(67, 24);
            this.btnSaveMob.TabIndex = 5;
            this.btnSaveMob.Text = "Save";
            this.btnSaveMob.Click += new System.EventHandler(this.btnSaveMob_Click);
            // 
            // btnOpenMob
            // 
            this.btnOpenMob.Location = new System.Drawing.Point(582, 7);
            this.btnOpenMob.Name = "btnOpenMob";
            this.btnOpenMob.Size = new System.Drawing.Size(67, 24);
            this.btnOpenMob.TabIndex = 4;
            this.btnOpenMob.Text = "Open...";
            this.btnOpenMob.Click += new System.EventHandler(this.btnOpenMob_Click);
            // 
            // MobileName
            // 
            this.MobileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MobileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MobileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MobileName.Location = new System.Drawing.Point(80, 8);
            this.MobileName.Name = "MobileName";
            this.MobileName.Size = new System.Drawing.Size(350, 23);
            this.MobileName.TabIndex = 3;
            this.MobileName.Text = "<NO OBJECT LOADED>";
            this.MobileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prototype:";
            // 
            // Prototype
            // 
            this.Prototype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Prototype.Location = new System.Drawing.Point(80, 40);
            this.Prototype.Name = "Prototype";
            this.Prototype.Size = new System.Drawing.Size(248, 21);
            this.Prototype.Sorted = true;
            this.Prototype.TabIndex = 1;
            this.Prototype.SelectedIndexChanged += new System.EventHandler(this.Prototype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Object GUID:";
            // 
            // bb_Sectors
            // 
            this.bb_Sectors.Controls.Add(this.tv_X_0);
            this.bb_Sectors.Controls.Add(this.tv_0_Y);
            this.bb_Sectors.Controls.Add(this.label96);
            this.bb_Sectors.Controls.Add(this.btnResetTiles);
            this.bb_Sectors.Controls.Add(this.btnDelObjects);
            this.bb_Sectors.Controls.Add(this.btnDelLights);
            this.bb_Sectors.Controls.Add(this.label88);
            this.bb_Sectors.Controls.Add(this.tu_0_0);
            this.bb_Sectors.Controls.Add(this.tu_0_Y);
            this.bb_Sectors.Controls.Add(this.tu_X_Y);
            this.bb_Sectors.Controls.Add(this.label92);
            this.bb_Sectors.Controls.Add(this.tu_X_0);
            this.bb_Sectors.Controls.Add(this.label94);
            this.bb_Sectors.Controls.Add(this.label93);
            this.bb_Sectors.Controls.Add(this.label91);
            this.bb_Sectors.Controls.Add(this.label89);
            this.bb_Sectors.Controls.Add(this.tCurSector);
            this.bb_Sectors.Controls.Add(this.label87);
            this.bb_Sectors.Controls.Add(this.btnNewSector);
            this.bb_Sectors.Controls.Add(this.tabSectorEd);
            this.bb_Sectors.Controls.Add(this.label81);
            this.bb_Sectors.Controls.Add(this.btnSaveSec);
            this.bb_Sectors.Controls.Add(this.btnOpenSec);
            this.bb_Sectors.Controls.Add(this.label75);
            this.bb_Sectors.Controls.Add(this.label90);
            this.bb_Sectors.Controls.Add(this.pictureBox1);
            this.bb_Sectors.Controls.Add(this.tv_0_0);
            this.bb_Sectors.Controls.Add(this.label97);
            this.bb_Sectors.Controls.Add(this.tv_X_Y);
            this.bb_Sectors.Controls.Add(this.label95);
            this.bb_Sectors.Controls.Add(this.label98);
            this.bb_Sectors.Controls.Add(this.label99);
            this.bb_Sectors.Location = new System.Drawing.Point(4, 22);
            this.bb_Sectors.Name = "bb_Sectors";
            this.bb_Sectors.Size = new System.Drawing.Size(808, 606);
            this.bb_Sectors.TabIndex = 2;
            this.bb_Sectors.Text = "Sectors";
            // 
            // tv_X_0
            // 
            this.tv_X_0.BackColor = System.Drawing.Color.White;
            this.tv_X_0.Location = new System.Drawing.Point(8, 384);
            this.tv_X_0.Name = "tv_X_0";
            this.tv_X_0.Size = new System.Drawing.Size(54, 23);
            this.tv_X_0.TabIndex = 24;
            this.tv_X_0.Text = "(0,0)";
            this.tv_X_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tv_0_Y
            // 
            this.tv_0_Y.BackColor = System.Drawing.Color.White;
            this.tv_0_Y.Location = new System.Drawing.Point(176, 384);
            this.tv_0_Y.Name = "tv_0_Y";
            this.tv_0_Y.Size = new System.Drawing.Size(56, 23);
            this.tv_0_Y.TabIndex = 23;
            this.tv_0_Y.Text = "(0,0)";
            // 
            // label96
            // 
            this.label96.BackColor = System.Drawing.Color.White;
            this.label96.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label96.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label96.Location = new System.Drawing.Point(32, 280);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(184, 16);
            this.label96.TabIndex = 22;
            this.label96.Text = "ISOMETRIC SCHEMATIC VIEW";
            // 
            // btnResetTiles
            // 
            this.btnResetTiles.Enabled = false;
            this.btnResetTiles.Location = new System.Drawing.Point(64, 576);
            this.btnResetTiles.Name = "btnResetTiles";
            this.btnResetTiles.Size = new System.Drawing.Size(112, 23);
            this.btnResetTiles.TabIndex = 21;
            this.btnResetTiles.Text = "Reset All Tiles";
            this.btnResetTiles.Click += new System.EventHandler(this.btnResetTiles_Click);
            // 
            // btnDelObjects
            // 
            this.btnDelObjects.Enabled = false;
            this.btnDelObjects.Location = new System.Drawing.Point(64, 544);
            this.btnDelObjects.Name = "btnDelObjects";
            this.btnDelObjects.Size = new System.Drawing.Size(112, 23);
            this.btnDelObjects.TabIndex = 20;
            this.btnDelObjects.Text = "Delete All Objects";
            this.btnDelObjects.Click += new System.EventHandler(this.btnDelObjects_Click);
            // 
            // btnDelLights
            // 
            this.btnDelLights.Enabled = false;
            this.btnDelLights.Location = new System.Drawing.Point(64, 512);
            this.btnDelLights.Name = "btnDelLights";
            this.btnDelLights.Size = new System.Drawing.Size(112, 23);
            this.btnDelLights.TabIndex = 19;
            this.btnDelLights.Text = "Delete All Lights";
            this.btnDelLights.Click += new System.EventHandler(this.btnDelLights_Click);
            // 
            // label88
            // 
            this.label88.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label88.Location = new System.Drawing.Point(4, 264);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(236, 1);
            this.label88.TabIndex = 18;
            this.label88.Text = "label88";
            // 
            // tu_0_0
            // 
            this.tu_0_0.BackColor = System.Drawing.Color.White;
            this.tu_0_0.Location = new System.Drawing.Point(164, 152);
            this.tu_0_0.Name = "tu_0_0";
            this.tu_0_0.Size = new System.Drawing.Size(64, 23);
            this.tu_0_0.TabIndex = 17;
            this.tu_0_0.Text = "(0,0)";
            // 
            // tu_0_Y
            // 
            this.tu_0_Y.BackColor = System.Drawing.Color.White;
            this.tu_0_Y.Location = new System.Drawing.Point(164, 232);
            this.tu_0_Y.Name = "tu_0_Y";
            this.tu_0_Y.Size = new System.Drawing.Size(64, 23);
            this.tu_0_Y.TabIndex = 16;
            this.tu_0_Y.Text = "(0,0)";
            // 
            // tu_X_Y
            // 
            this.tu_X_Y.BackColor = System.Drawing.Color.White;
            this.tu_X_Y.Location = new System.Drawing.Point(8, 232);
            this.tu_X_Y.Name = "tu_X_Y";
            this.tu_X_Y.Size = new System.Drawing.Size(72, 23);
            this.tu_X_Y.TabIndex = 15;
            this.tu_X_Y.Text = "(0,0)";
            this.tu_X_Y.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label92
            // 
            this.label92.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label92.Location = new System.Drawing.Point(80, 240);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(80, 1);
            this.label92.TabIndex = 14;
            this.label92.Text = "label92";
            // 
            // tu_X_0
            // 
            this.tu_X_0.BackColor = System.Drawing.Color.White;
            this.tu_X_0.Location = new System.Drawing.Point(8, 152);
            this.tu_X_0.Name = "tu_X_0";
            this.tu_X_0.Size = new System.Drawing.Size(72, 23);
            this.tu_X_0.TabIndex = 13;
            this.tu_X_0.Text = "(0,0)";
            this.tu_X_0.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label94
            // 
            this.label94.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label94.Location = new System.Drawing.Point(160, 160);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(1, 80);
            this.label94.TabIndex = 12;
            this.label94.Text = "label94";
            // 
            // label93
            // 
            this.label93.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label93.Location = new System.Drawing.Point(80, 160);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(1, 80);
            this.label93.TabIndex = 11;
            this.label93.Text = "label93";
            // 
            // label91
            // 
            this.label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label91.Location = new System.Drawing.Point(80, 160);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(80, 1);
            this.label91.TabIndex = 9;
            this.label91.Text = "label91";
            // 
            // label89
            // 
            this.label89.BackColor = System.Drawing.Color.White;
            this.label89.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label89.Location = new System.Drawing.Point(40, 120);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(168, 23);
            this.label89.TabIndex = 8;
            this.label89.Text = "UPRIGHT SCHEMATIC VIEW";
            // 
            // tCurSector
            // 
            this.tCurSector.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tCurSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tCurSector.Location = new System.Drawing.Point(72, 72);
            this.tCurSector.Name = "tCurSector";
            this.tCurSector.Size = new System.Drawing.Size(160, 23);
            this.tCurSector.TabIndex = 7;
            this.tCurSector.Text = "NO SECTOR FILE IS OPEN";
            // 
            // label87
            // 
            this.label87.Location = new System.Drawing.Point(8, 72);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(64, 23);
            this.label87.TabIndex = 6;
            this.label87.Text = "Sector File:";
            // 
            // btnNewSector
            // 
            this.btnNewSector.Location = new System.Drawing.Point(16, 16);
            this.btnNewSector.Name = "btnNewSector";
            this.btnNewSector.Size = new System.Drawing.Size(64, 23);
            this.btnNewSector.TabIndex = 5;
            this.btnNewSector.Text = "New";
            this.btnNewSector.Click += new System.EventHandler(this.btnNewSector_Click);
            // 
            // tabSectorEd
            // 
            this.tabSectorEd.Controls.Add(this.a_Tiles);
            this.tabSectorEd.Controls.Add(this.b_Lights);
            this.tabSectorEd.Controls.Add(this.c_Objects);
            this.tabSectorEd.Enabled = false;
            this.tabSectorEd.Location = new System.Drawing.Point(248, 8);
            this.tabSectorEd.Name = "tabSectorEd";
            this.tabSectorEd.SelectedIndex = 0;
            this.tabSectorEd.Size = new System.Drawing.Size(560, 592);
            this.tabSectorEd.TabIndex = 4;
            // 
            // a_Tiles
            // 
            this.a_Tiles.Controls.Add(this.btnSVBWizard);
            this.a_Tiles.Controls.Add(this.HGT_UL);
            this.a_Tiles.Controls.Add(this.HGT_UM);
            this.a_Tiles.Controls.Add(this.HGT_UR);
            this.a_Tiles.Controls.Add(this.HGT_ML);
            this.a_Tiles.Controls.Add(this.HGT_MM);
            this.a_Tiles.Controls.Add(this.HGT_MR);
            this.a_Tiles.Controls.Add(this.HGT_LL);
            this.a_Tiles.Controls.Add(this.HGT_LM);
            this.a_Tiles.Controls.Add(this.HGT_LR);
            this.a_Tiles.Controls.Add(this.HSD_UL);
            this.a_Tiles.Controls.Add(this.HSD_UM);
            this.a_Tiles.Controls.Add(this.HSD_UR);
            this.a_Tiles.Controls.Add(this.HSD_ML);
            this.a_Tiles.Controls.Add(this.HSD_MM);
            this.a_Tiles.Controls.Add(this.HSD_MR);
            this.a_Tiles.Controls.Add(this.HSD_LL);
            this.a_Tiles.Controls.Add(this.HSD_LM);
            this.a_Tiles.Controls.Add(this.HSD_LR);
            this.a_Tiles.Controls.Add(this.label116);
            this.a_Tiles.Controls.Add(this.label86);
            this.a_Tiles.Controls.Add(this.SVB4_UL);
            this.a_Tiles.Controls.Add(this.SVB4_UM);
            this.a_Tiles.Controls.Add(this.SVB4_UR);
            this.a_Tiles.Controls.Add(this.SVB4_ML);
            this.a_Tiles.Controls.Add(this.SVB4_MM);
            this.a_Tiles.Controls.Add(this.SVB4_MR);
            this.a_Tiles.Controls.Add(this.SVB4_LL);
            this.a_Tiles.Controls.Add(this.SVB4_LM);
            this.a_Tiles.Controls.Add(this.SVB4_LR);
            this.a_Tiles.Controls.Add(this.SVB3_UL);
            this.a_Tiles.Controls.Add(this.SVB3_UM);
            this.a_Tiles.Controls.Add(this.SVB3_UR);
            this.a_Tiles.Controls.Add(this.SVB3_ML);
            this.a_Tiles.Controls.Add(this.SVB3_MM);
            this.a_Tiles.Controls.Add(this.SVB3_MR);
            this.a_Tiles.Controls.Add(this.SVB3_LL);
            this.a_Tiles.Controls.Add(this.SVB3_LM);
            this.a_Tiles.Controls.Add(this.SVB3_LR);
            this.a_Tiles.Controls.Add(this.SVB2_UL);
            this.a_Tiles.Controls.Add(this.SVB2_UM);
            this.a_Tiles.Controls.Add(this.SVB2_UR);
            this.a_Tiles.Controls.Add(this.SVB2_ML);
            this.a_Tiles.Controls.Add(this.SVB2_MM);
            this.a_Tiles.Controls.Add(this.SVB2_MR);
            this.a_Tiles.Controls.Add(this.SVB2_LL);
            this.a_Tiles.Controls.Add(this.SVB2_LM);
            this.a_Tiles.Controls.Add(this.SVB2_LR);
            this.a_Tiles.Controls.Add(this.SVB1_UL);
            this.a_Tiles.Controls.Add(this.SVB1_UM);
            this.a_Tiles.Controls.Add(this.SVB1_UR);
            this.a_Tiles.Controls.Add(this.SVB1_ML);
            this.a_Tiles.Controls.Add(this.SVB1_MM);
            this.a_Tiles.Controls.Add(this.SVB1_MR);
            this.a_Tiles.Controls.Add(this.SVB1_LL);
            this.a_Tiles.Controls.Add(this.SVB1_LM);
            this.a_Tiles.Controls.Add(this.chkAutoTile);
            this.a_Tiles.Controls.Add(this.SVB1_LR);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_COVER);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_UL);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_UM);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_UR);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_ML);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_MM);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_MR);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_LL);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_LM);
            this.a_Tiles.Controls.Add(this.TILE_FLYOVER_LR);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_UL);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_UM);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_UR);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_ML);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_MM);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_MR);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_LL);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_LM);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_LR);
            this.a_Tiles.Controls.Add(this.label128);
            this.a_Tiles.Controls.Add(this.lbl);
            this.a_Tiles.Controls.Add(this.label125);
            this.a_Tiles.Controls.Add(this.label124);
            this.a_Tiles.Controls.Add(this.label123);
            this.a_Tiles.Controls.Add(this.label122);
            this.a_Tiles.Controls.Add(this.label121);
            this.a_Tiles.Controls.Add(this.label120);
            this.a_Tiles.Controls.Add(this.label119);
            this.a_Tiles.Controls.Add(this.label118);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS_VISION);
            this.a_Tiles.Controls.Add(this.TILE_REFLECTIVE);
            this.a_Tiles.Controls.Add(this.TILE_INDOOR);
            this.a_Tiles.Controls.Add(this.TILE_SOUNDPROOF);
            this.a_Tiles.Controls.Add(this.TILE_NATURAL);
            this.a_Tiles.Controls.Add(this.TILE_ICY);
            this.a_Tiles.Controls.Add(this.TILE_CAN_FLY_OVER);
            this.a_Tiles.Controls.Add(this.TILE_SINKS);
            this.a_Tiles.Controls.Add(this.TILE_BLOCKS);
            this.a_Tiles.Controls.Add(this.label113);
            this.a_Tiles.Controls.Add(this.btnLoadTile);
            this.a_Tiles.Controls.Add(this.label112);
            this.a_Tiles.Controls.Add(this.ToTY);
            this.a_Tiles.Controls.Add(this.ToTX);
            this.a_Tiles.Controls.Add(this.label111);
            this.a_Tiles.Controls.Add(this.label110);
            this.a_Tiles.Controls.Add(this.label109);
            this.a_Tiles.Controls.Add(this.FromTY);
            this.a_Tiles.Controls.Add(this.FromTX);
            this.a_Tiles.Controls.Add(this.label108);
            this.a_Tiles.Controls.Add(this.label107);
            this.a_Tiles.Controls.Add(this.btnUpdateBoxTiles);
            this.a_Tiles.Controls.Add(this.label106);
            this.a_Tiles.Controls.Add(this.label105);
            this.a_Tiles.Controls.Add(this.btnUpdateAllTiles);
            this.a_Tiles.Controls.Add(this.btnUpdateTile);
            this.a_Tiles.Controls.Add(this.cmbTileSound);
            this.a_Tiles.Controls.Add(this.label104);
            this.a_Tiles.Controls.Add(this.TY);
            this.a_Tiles.Controls.Add(this.TX);
            this.a_Tiles.Controls.Add(this.label101);
            this.a_Tiles.Controls.Add(this.label102);
            this.a_Tiles.Controls.Add(this.label103);
            this.a_Tiles.Location = new System.Drawing.Point(4, 22);
            this.a_Tiles.Name = "a_Tiles";
            this.a_Tiles.Size = new System.Drawing.Size(552, 566);
            this.a_Tiles.TabIndex = 1;
            this.a_Tiles.Text = "Tiles";
            // 
            // btnSVBWizard
            // 
            this.btnSVBWizard.Location = new System.Drawing.Point(456, 57);
            this.btnSVBWizard.Name = "btnSVBWizard";
            this.btnSVBWizard.Size = new System.Drawing.Size(88, 23);
            this.btnSVBWizard.TabIndex = 176;
            this.btnSVBWizard.Text = "SVB Wizard ...";
            this.btnSVBWizard.UseVisualStyleBackColor = true;
            this.btnSVBWizard.Visible = false;
            this.btnSVBWizard.Click += new System.EventHandler(this.btnSVBWizard_Click);
            // 
            // HGT_UL
            // 
            this.HGT_UL.Enabled = false;
            this.HGT_UL.Location = new System.Drawing.Point(328, 184);
            this.HGT_UL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_UL.Name = "HGT_UL";
            this.HGT_UL.Size = new System.Drawing.Size(40, 20);
            this.HGT_UL.TabIndex = 175;
            // 
            // HGT_UM
            // 
            this.HGT_UM.Enabled = false;
            this.HGT_UM.Location = new System.Drawing.Point(416, 184);
            this.HGT_UM.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_UM.Name = "HGT_UM";
            this.HGT_UM.Size = new System.Drawing.Size(40, 20);
            this.HGT_UM.TabIndex = 174;
            // 
            // HGT_UR
            // 
            this.HGT_UR.Enabled = false;
            this.HGT_UR.Location = new System.Drawing.Point(502, 185);
            this.HGT_UR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_UR.Name = "HGT_UR";
            this.HGT_UR.Size = new System.Drawing.Size(40, 20);
            this.HGT_UR.TabIndex = 173;
            // 
            // HGT_ML
            // 
            this.HGT_ML.Enabled = false;
            this.HGT_ML.Location = new System.Drawing.Point(328, 312);
            this.HGT_ML.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_ML.Name = "HGT_ML";
            this.HGT_ML.Size = new System.Drawing.Size(40, 20);
            this.HGT_ML.TabIndex = 172;
            // 
            // HGT_MM
            // 
            this.HGT_MM.Enabled = false;
            this.HGT_MM.Location = new System.Drawing.Point(416, 312);
            this.HGT_MM.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_MM.Name = "HGT_MM";
            this.HGT_MM.Size = new System.Drawing.Size(40, 20);
            this.HGT_MM.TabIndex = 171;
            // 
            // HGT_MR
            // 
            this.HGT_MR.Enabled = false;
            this.HGT_MR.Location = new System.Drawing.Point(502, 312);
            this.HGT_MR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_MR.Name = "HGT_MR";
            this.HGT_MR.Size = new System.Drawing.Size(40, 20);
            this.HGT_MR.TabIndex = 170;
            // 
            // HGT_LL
            // 
            this.HGT_LL.Enabled = false;
            this.HGT_LL.Location = new System.Drawing.Point(328, 440);
            this.HGT_LL.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_LL.Name = "HGT_LL";
            this.HGT_LL.Size = new System.Drawing.Size(40, 20);
            this.HGT_LL.TabIndex = 169;
            // 
            // HGT_LM
            // 
            this.HGT_LM.Enabled = false;
            this.HGT_LM.Location = new System.Drawing.Point(416, 440);
            this.HGT_LM.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_LM.Name = "HGT_LM";
            this.HGT_LM.Size = new System.Drawing.Size(40, 20);
            this.HGT_LM.TabIndex = 168;
            // 
            // HGT_LR
            // 
            this.HGT_LR.Enabled = false;
            this.HGT_LR.Location = new System.Drawing.Point(504, 440);
            this.HGT_LR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.HGT_LR.Name = "HGT_LR";
            this.HGT_LR.Size = new System.Drawing.Size(40, 20);
            this.HGT_LR.TabIndex = 167;
            // 
            // HSD_UL
            // 
            this.HSD_UL.Location = new System.Drawing.Point(288, 184);
            this.HSD_UL.Name = "HSD_UL";
            this.HSD_UL.Size = new System.Drawing.Size(72, 16);
            this.HSD_UL.TabIndex = 166;
            this.HSD_UL.Text = "Wtr";
            this.HSD_UL.CheckedChanged += new System.EventHandler(this.HSD_UL_CheckedChanged);
            // 
            // HSD_UM
            // 
            this.HSD_UM.Location = new System.Drawing.Point(376, 184);
            this.HSD_UM.Name = "HSD_UM";
            this.HSD_UM.Size = new System.Drawing.Size(72, 16);
            this.HSD_UM.TabIndex = 165;
            this.HSD_UM.Text = "Wtr";
            this.HSD_UM.CheckedChanged += new System.EventHandler(this.HSD_UM_CheckedChanged);
            // 
            // HSD_UR
            // 
            this.HSD_UR.Location = new System.Drawing.Point(462, 185);
            this.HSD_UR.Name = "HSD_UR";
            this.HSD_UR.Size = new System.Drawing.Size(72, 16);
            this.HSD_UR.TabIndex = 164;
            this.HSD_UR.Text = "Wtr";
            this.HSD_UR.CheckedChanged += new System.EventHandler(this.HSD_UR_CheckedChanged);
            // 
            // HSD_ML
            // 
            this.HSD_ML.Location = new System.Drawing.Point(288, 312);
            this.HSD_ML.Name = "HSD_ML";
            this.HSD_ML.Size = new System.Drawing.Size(72, 16);
            this.HSD_ML.TabIndex = 163;
            this.HSD_ML.Text = "Wtr";
            this.HSD_ML.CheckedChanged += new System.EventHandler(this.HSD_ML_CheckedChanged);
            // 
            // HSD_MM
            // 
            this.HSD_MM.Location = new System.Drawing.Point(376, 312);
            this.HSD_MM.Name = "HSD_MM";
            this.HSD_MM.Size = new System.Drawing.Size(72, 16);
            this.HSD_MM.TabIndex = 162;
            this.HSD_MM.Text = "Wtr";
            this.HSD_MM.CheckedChanged += new System.EventHandler(this.HSD_MM_CheckedChanged);
            // 
            // HSD_MR
            // 
            this.HSD_MR.Location = new System.Drawing.Point(462, 312);
            this.HSD_MR.Name = "HSD_MR";
            this.HSD_MR.Size = new System.Drawing.Size(72, 16);
            this.HSD_MR.TabIndex = 161;
            this.HSD_MR.Text = "Wtr";
            this.HSD_MR.CheckedChanged += new System.EventHandler(this.HSD_MR_CheckedChanged);
            // 
            // HSD_LL
            // 
            this.HSD_LL.Location = new System.Drawing.Point(288, 440);
            this.HSD_LL.Name = "HSD_LL";
            this.HSD_LL.Size = new System.Drawing.Size(72, 16);
            this.HSD_LL.TabIndex = 160;
            this.HSD_LL.Text = "Wtr";
            this.HSD_LL.CheckedChanged += new System.EventHandler(this.HSD_LL_CheckedChanged);
            // 
            // HSD_LM
            // 
            this.HSD_LM.Location = new System.Drawing.Point(376, 440);
            this.HSD_LM.Name = "HSD_LM";
            this.HSD_LM.Size = new System.Drawing.Size(72, 16);
            this.HSD_LM.TabIndex = 159;
            this.HSD_LM.Text = "Wtr";
            this.HSD_LM.CheckedChanged += new System.EventHandler(this.HSD_LM_CheckedChanged);
            // 
            // HSD_LR
            // 
            this.HSD_LR.Location = new System.Drawing.Point(464, 440);
            this.HSD_LR.Name = "HSD_LR";
            this.HSD_LR.Size = new System.Drawing.Size(72, 16);
            this.HSD_LR.TabIndex = 158;
            this.HSD_LR.Text = "Wtr";
            this.HSD_LR.CheckedChanged += new System.EventHandler(this.HSD_LR_CheckedChanged);
            // 
            // label116
            // 
            this.label116.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label116.Location = new System.Drawing.Point(16, 265);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(248, 199);
            this.label116.TabIndex = 157;
            this.label116.Text = resources.GetString("label116.Text");
            // 
            // label86
            // 
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label86.Location = new System.Drawing.Point(16, 243);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(46, 23);
            this.label86.TabIndex = 156;
            this.label86.Text = "NOTE:";
            // 
            // SVB4_UL
            // 
            this.SVB4_UL.Location = new System.Drawing.Point(288, 168);
            this.SVB4_UL.Name = "SVB4_UL";
            this.SVB4_UL.Size = new System.Drawing.Size(72, 16);
            this.SVB4_UL.TabIndex = 155;
            this.SVB4_UL.Text = "Archway*";
            // 
            // SVB4_UM
            // 
            this.SVB4_UM.Location = new System.Drawing.Point(376, 168);
            this.SVB4_UM.Name = "SVB4_UM";
            this.SVB4_UM.Size = new System.Drawing.Size(72, 16);
            this.SVB4_UM.TabIndex = 154;
            this.SVB4_UM.Text = "Archway*";
            // 
            // SVB4_UR
            // 
            this.SVB4_UR.Location = new System.Drawing.Point(462, 169);
            this.SVB4_UR.Name = "SVB4_UR";
            this.SVB4_UR.Size = new System.Drawing.Size(72, 16);
            this.SVB4_UR.TabIndex = 153;
            this.SVB4_UR.Text = "Archway*";
            // 
            // SVB4_ML
            // 
            this.SVB4_ML.Location = new System.Drawing.Point(288, 296);
            this.SVB4_ML.Name = "SVB4_ML";
            this.SVB4_ML.Size = new System.Drawing.Size(72, 16);
            this.SVB4_ML.TabIndex = 152;
            this.SVB4_ML.Text = "Archway*";
            // 
            // SVB4_MM
            // 
            this.SVB4_MM.Location = new System.Drawing.Point(376, 296);
            this.SVB4_MM.Name = "SVB4_MM";
            this.SVB4_MM.Size = new System.Drawing.Size(72, 16);
            this.SVB4_MM.TabIndex = 151;
            this.SVB4_MM.Text = "Archway*";
            // 
            // SVB4_MR
            // 
            this.SVB4_MR.Location = new System.Drawing.Point(462, 296);
            this.SVB4_MR.Name = "SVB4_MR";
            this.SVB4_MR.Size = new System.Drawing.Size(72, 16);
            this.SVB4_MR.TabIndex = 150;
            this.SVB4_MR.Text = "Archway*";
            // 
            // SVB4_LL
            // 
            this.SVB4_LL.Location = new System.Drawing.Point(288, 424);
            this.SVB4_LL.Name = "SVB4_LL";
            this.SVB4_LL.Size = new System.Drawing.Size(72, 16);
            this.SVB4_LL.TabIndex = 149;
            this.SVB4_LL.Text = "Archway*";
            // 
            // SVB4_LM
            // 
            this.SVB4_LM.Location = new System.Drawing.Point(376, 424);
            this.SVB4_LM.Name = "SVB4_LM";
            this.SVB4_LM.Size = new System.Drawing.Size(72, 16);
            this.SVB4_LM.TabIndex = 148;
            this.SVB4_LM.Text = "Archway*";
            // 
            // SVB4_LR
            // 
            this.SVB4_LR.Location = new System.Drawing.Point(464, 424);
            this.SVB4_LR.Name = "SVB4_LR";
            this.SVB4_LR.Size = new System.Drawing.Size(72, 16);
            this.SVB4_LR.TabIndex = 147;
            this.SVB4_LR.Text = "Archway*";
            // 
            // SVB3_UL
            // 
            this.SVB3_UL.Location = new System.Drawing.Point(288, 152);
            this.SVB3_UL.Name = "SVB3_UL";
            this.SVB3_UL.Size = new System.Drawing.Size(72, 16);
            this.SVB3_UL.TabIndex = 146;
            this.SVB3_UL.Text = "Base(*)";
            // 
            // SVB3_UM
            // 
            this.SVB3_UM.Location = new System.Drawing.Point(376, 152);
            this.SVB3_UM.Name = "SVB3_UM";
            this.SVB3_UM.Size = new System.Drawing.Size(72, 16);
            this.SVB3_UM.TabIndex = 145;
            this.SVB3_UM.Text = "Base(*)";
            // 
            // SVB3_UR
            // 
            this.SVB3_UR.Location = new System.Drawing.Point(462, 153);
            this.SVB3_UR.Name = "SVB3_UR";
            this.SVB3_UR.Size = new System.Drawing.Size(72, 16);
            this.SVB3_UR.TabIndex = 144;
            this.SVB3_UR.Text = "Base(*)";
            // 
            // SVB3_ML
            // 
            this.SVB3_ML.Location = new System.Drawing.Point(288, 280);
            this.SVB3_ML.Name = "SVB3_ML";
            this.SVB3_ML.Size = new System.Drawing.Size(72, 16);
            this.SVB3_ML.TabIndex = 143;
            this.SVB3_ML.Text = "Base(*)";
            // 
            // SVB3_MM
            // 
            this.SVB3_MM.Location = new System.Drawing.Point(376, 280);
            this.SVB3_MM.Name = "SVB3_MM";
            this.SVB3_MM.Size = new System.Drawing.Size(72, 16);
            this.SVB3_MM.TabIndex = 142;
            this.SVB3_MM.Text = "Base(*)";
            // 
            // SVB3_MR
            // 
            this.SVB3_MR.Location = new System.Drawing.Point(462, 280);
            this.SVB3_MR.Name = "SVB3_MR";
            this.SVB3_MR.Size = new System.Drawing.Size(72, 16);
            this.SVB3_MR.TabIndex = 141;
            this.SVB3_MR.Text = "Base(*)";
            // 
            // SVB3_LL
            // 
            this.SVB3_LL.Location = new System.Drawing.Point(288, 408);
            this.SVB3_LL.Name = "SVB3_LL";
            this.SVB3_LL.Size = new System.Drawing.Size(72, 16);
            this.SVB3_LL.TabIndex = 140;
            this.SVB3_LL.Text = "Base(*)";
            // 
            // SVB3_LM
            // 
            this.SVB3_LM.Location = new System.Drawing.Point(376, 408);
            this.SVB3_LM.Name = "SVB3_LM";
            this.SVB3_LM.Size = new System.Drawing.Size(72, 16);
            this.SVB3_LM.TabIndex = 139;
            this.SVB3_LM.Text = "Base(*)";
            // 
            // SVB3_LR
            // 
            this.SVB3_LR.Location = new System.Drawing.Point(464, 408);
            this.SVB3_LR.Name = "SVB3_LR";
            this.SVB3_LR.Size = new System.Drawing.Size(72, 16);
            this.SVB3_LR.TabIndex = 138;
            this.SVB3_LR.Text = "Base(*)";
            // 
            // SVB2_UL
            // 
            this.SVB2_UL.Location = new System.Drawing.Point(288, 136);
            this.SVB2_UL.Name = "SVB2_UL";
            this.SVB2_UL.Size = new System.Drawing.Size(72, 16);
            this.SVB2_UL.TabIndex = 137;
            this.SVB2_UL.Text = "End(*)";
            // 
            // SVB2_UM
            // 
            this.SVB2_UM.Location = new System.Drawing.Point(376, 136);
            this.SVB2_UM.Name = "SVB2_UM";
            this.SVB2_UM.Size = new System.Drawing.Size(72, 16);
            this.SVB2_UM.TabIndex = 136;
            this.SVB2_UM.Text = "End(*)";
            // 
            // SVB2_UR
            // 
            this.SVB2_UR.Location = new System.Drawing.Point(462, 137);
            this.SVB2_UR.Name = "SVB2_UR";
            this.SVB2_UR.Size = new System.Drawing.Size(72, 16);
            this.SVB2_UR.TabIndex = 135;
            this.SVB2_UR.Text = "End(*)";
            // 
            // SVB2_ML
            // 
            this.SVB2_ML.Location = new System.Drawing.Point(288, 264);
            this.SVB2_ML.Name = "SVB2_ML";
            this.SVB2_ML.Size = new System.Drawing.Size(72, 16);
            this.SVB2_ML.TabIndex = 134;
            this.SVB2_ML.Text = "End(*)";
            // 
            // SVB2_MM
            // 
            this.SVB2_MM.Location = new System.Drawing.Point(376, 264);
            this.SVB2_MM.Name = "SVB2_MM";
            this.SVB2_MM.Size = new System.Drawing.Size(72, 16);
            this.SVB2_MM.TabIndex = 133;
            this.SVB2_MM.Text = "End(*)";
            // 
            // SVB2_MR
            // 
            this.SVB2_MR.Location = new System.Drawing.Point(462, 264);
            this.SVB2_MR.Name = "SVB2_MR";
            this.SVB2_MR.Size = new System.Drawing.Size(72, 16);
            this.SVB2_MR.TabIndex = 132;
            this.SVB2_MR.Text = "End(*)";
            // 
            // SVB2_LL
            // 
            this.SVB2_LL.Location = new System.Drawing.Point(288, 392);
            this.SVB2_LL.Name = "SVB2_LL";
            this.SVB2_LL.Size = new System.Drawing.Size(72, 16);
            this.SVB2_LL.TabIndex = 131;
            this.SVB2_LL.Text = "End(*)";
            // 
            // SVB2_LM
            // 
            this.SVB2_LM.Location = new System.Drawing.Point(376, 392);
            this.SVB2_LM.Name = "SVB2_LM";
            this.SVB2_LM.Size = new System.Drawing.Size(72, 16);
            this.SVB2_LM.TabIndex = 130;
            this.SVB2_LM.Text = "End(*)";
            // 
            // SVB2_LR
            // 
            this.SVB2_LR.Location = new System.Drawing.Point(464, 392);
            this.SVB2_LR.Name = "SVB2_LR";
            this.SVB2_LR.Size = new System.Drawing.Size(72, 16);
            this.SVB2_LR.TabIndex = 129;
            this.SVB2_LR.Text = "End(*)";
            // 
            // SVB1_UL
            // 
            this.SVB1_UL.Location = new System.Drawing.Point(288, 120);
            this.SVB1_UL.Name = "SVB1_UL";
            this.SVB1_UL.Size = new System.Drawing.Size(72, 16);
            this.SVB1_UL.TabIndex = 128;
            this.SVB1_UL.Text = "Extend(*)";
            // 
            // SVB1_UM
            // 
            this.SVB1_UM.Location = new System.Drawing.Point(376, 120);
            this.SVB1_UM.Name = "SVB1_UM";
            this.SVB1_UM.Size = new System.Drawing.Size(72, 16);
            this.SVB1_UM.TabIndex = 127;
            this.SVB1_UM.Text = "Extend(*)";
            // 
            // SVB1_UR
            // 
            this.SVB1_UR.Location = new System.Drawing.Point(462, 121);
            this.SVB1_UR.Name = "SVB1_UR";
            this.SVB1_UR.Size = new System.Drawing.Size(72, 16);
            this.SVB1_UR.TabIndex = 126;
            this.SVB1_UR.Text = "Extend(*)";
            // 
            // SVB1_ML
            // 
            this.SVB1_ML.Location = new System.Drawing.Point(288, 248);
            this.SVB1_ML.Name = "SVB1_ML";
            this.SVB1_ML.Size = new System.Drawing.Size(72, 16);
            this.SVB1_ML.TabIndex = 125;
            this.SVB1_ML.Text = "Extend(*)";
            // 
            // SVB1_MM
            // 
            this.SVB1_MM.Location = new System.Drawing.Point(376, 248);
            this.SVB1_MM.Name = "SVB1_MM";
            this.SVB1_MM.Size = new System.Drawing.Size(72, 16);
            this.SVB1_MM.TabIndex = 124;
            this.SVB1_MM.Text = "Extend(*)";
            // 
            // SVB1_MR
            // 
            this.SVB1_MR.Location = new System.Drawing.Point(462, 248);
            this.SVB1_MR.Name = "SVB1_MR";
            this.SVB1_MR.Size = new System.Drawing.Size(72, 16);
            this.SVB1_MR.TabIndex = 123;
            this.SVB1_MR.Text = "Extend(*)";
            // 
            // SVB1_LL
            // 
            this.SVB1_LL.Location = new System.Drawing.Point(288, 376);
            this.SVB1_LL.Name = "SVB1_LL";
            this.SVB1_LL.Size = new System.Drawing.Size(72, 16);
            this.SVB1_LL.TabIndex = 122;
            this.SVB1_LL.Text = "Extend(*)";
            // 
            // SVB1_LM
            // 
            this.SVB1_LM.Location = new System.Drawing.Point(376, 376);
            this.SVB1_LM.Name = "SVB1_LM";
            this.SVB1_LM.Size = new System.Drawing.Size(72, 16);
            this.SVB1_LM.TabIndex = 121;
            this.SVB1_LM.Text = "Extend(*)";
            // 
            // chkAutoTile
            // 
            this.chkAutoTile.Location = new System.Drawing.Point(288, 8);
            this.chkAutoTile.Name = "chkAutoTile";
            this.chkAutoTile.Size = new System.Drawing.Size(256, 24);
            this.chkAutoTile.TabIndex = 120;
            this.chkAutoTile.Text = "Auto load tile whenever X or Y are changed";
            // 
            // SVB1_LR
            // 
            this.SVB1_LR.Location = new System.Drawing.Point(464, 376);
            this.SVB1_LR.Name = "SVB1_LR";
            this.SVB1_LR.Size = new System.Drawing.Size(72, 16);
            this.SVB1_LR.TabIndex = 119;
            this.SVB1_LR.Text = "Extend(*)";
            // 
            // TILE_FLYOVER_COVER
            // 
            this.TILE_FLYOVER_COVER.Location = new System.Drawing.Point(64, 210);
            this.TILE_FLYOVER_COVER.Name = "TILE_FLYOVER_COVER";
            this.TILE_FLYOVER_COVER.Size = new System.Drawing.Size(216, 40);
            this.TILE_FLYOVER_COVER.TabIndex = 118;
            this.TILE_FLYOVER_COVER.Text = "FLYOVER/COVER (in this tile, semi-tiles that are marked as \'fly over\' provide cov" +
                "er)";
            // 
            // TILE_FLYOVER_UL
            // 
            this.TILE_FLYOVER_UL.Location = new System.Drawing.Point(288, 104);
            this.TILE_FLYOVER_UL.Name = "TILE_FLYOVER_UL";
            this.TILE_FLYOVER_UL.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_UL.TabIndex = 117;
            this.TILE_FLYOVER_UL.Text = "Fly Over";
            // 
            // TILE_FLYOVER_UM
            // 
            this.TILE_FLYOVER_UM.Location = new System.Drawing.Point(376, 104);
            this.TILE_FLYOVER_UM.Name = "TILE_FLYOVER_UM";
            this.TILE_FLYOVER_UM.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_UM.TabIndex = 116;
            this.TILE_FLYOVER_UM.Text = "Fly Over";
            // 
            // TILE_FLYOVER_UR
            // 
            this.TILE_FLYOVER_UR.Location = new System.Drawing.Point(462, 105);
            this.TILE_FLYOVER_UR.Name = "TILE_FLYOVER_UR";
            this.TILE_FLYOVER_UR.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_UR.TabIndex = 115;
            this.TILE_FLYOVER_UR.Text = "Fly Over";
            // 
            // TILE_FLYOVER_ML
            // 
            this.TILE_FLYOVER_ML.Location = new System.Drawing.Point(288, 232);
            this.TILE_FLYOVER_ML.Name = "TILE_FLYOVER_ML";
            this.TILE_FLYOVER_ML.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_ML.TabIndex = 114;
            this.TILE_FLYOVER_ML.Text = "Fly Over";
            // 
            // TILE_FLYOVER_MM
            // 
            this.TILE_FLYOVER_MM.Location = new System.Drawing.Point(376, 232);
            this.TILE_FLYOVER_MM.Name = "TILE_FLYOVER_MM";
            this.TILE_FLYOVER_MM.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_MM.TabIndex = 113;
            this.TILE_FLYOVER_MM.Text = "Fly Over";
            // 
            // TILE_FLYOVER_MR
            // 
            this.TILE_FLYOVER_MR.Location = new System.Drawing.Point(462, 232);
            this.TILE_FLYOVER_MR.Name = "TILE_FLYOVER_MR";
            this.TILE_FLYOVER_MR.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_MR.TabIndex = 112;
            this.TILE_FLYOVER_MR.Text = "Fly Over";
            // 
            // TILE_FLYOVER_LL
            // 
            this.TILE_FLYOVER_LL.Location = new System.Drawing.Point(288, 360);
            this.TILE_FLYOVER_LL.Name = "TILE_FLYOVER_LL";
            this.TILE_FLYOVER_LL.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_LL.TabIndex = 111;
            this.TILE_FLYOVER_LL.Text = "Fly Over";
            // 
            // TILE_FLYOVER_LM
            // 
            this.TILE_FLYOVER_LM.Location = new System.Drawing.Point(376, 360);
            this.TILE_FLYOVER_LM.Name = "TILE_FLYOVER_LM";
            this.TILE_FLYOVER_LM.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_LM.TabIndex = 110;
            this.TILE_FLYOVER_LM.Text = "Fly Over";
            // 
            // TILE_FLYOVER_LR
            // 
            this.TILE_FLYOVER_LR.Location = new System.Drawing.Point(464, 360);
            this.TILE_FLYOVER_LR.Name = "TILE_FLYOVER_LR";
            this.TILE_FLYOVER_LR.Size = new System.Drawing.Size(72, 16);
            this.TILE_FLYOVER_LR.TabIndex = 109;
            this.TILE_FLYOVER_LR.Text = "Fly Over";
            // 
            // TILE_BLOCKS_UL
            // 
            this.TILE_BLOCKS_UL.Location = new System.Drawing.Point(288, 88);
            this.TILE_BLOCKS_UL.Name = "TILE_BLOCKS_UL";
            this.TILE_BLOCKS_UL.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_UL.TabIndex = 108;
            this.TILE_BLOCKS_UL.Text = "Blocks";
            // 
            // TILE_BLOCKS_UM
            // 
            this.TILE_BLOCKS_UM.Location = new System.Drawing.Point(376, 88);
            this.TILE_BLOCKS_UM.Name = "TILE_BLOCKS_UM";
            this.TILE_BLOCKS_UM.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_UM.TabIndex = 107;
            this.TILE_BLOCKS_UM.Text = "Blocks";
            // 
            // TILE_BLOCKS_UR
            // 
            this.TILE_BLOCKS_UR.Location = new System.Drawing.Point(462, 89);
            this.TILE_BLOCKS_UR.Name = "TILE_BLOCKS_UR";
            this.TILE_BLOCKS_UR.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_UR.TabIndex = 106;
            this.TILE_BLOCKS_UR.Text = "Blocks";
            // 
            // TILE_BLOCKS_ML
            // 
            this.TILE_BLOCKS_ML.Location = new System.Drawing.Point(288, 216);
            this.TILE_BLOCKS_ML.Name = "TILE_BLOCKS_ML";
            this.TILE_BLOCKS_ML.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_ML.TabIndex = 105;
            this.TILE_BLOCKS_ML.Text = "Blocks";
            // 
            // TILE_BLOCKS_MM
            // 
            this.TILE_BLOCKS_MM.Location = new System.Drawing.Point(376, 216);
            this.TILE_BLOCKS_MM.Name = "TILE_BLOCKS_MM";
            this.TILE_BLOCKS_MM.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_MM.TabIndex = 104;
            this.TILE_BLOCKS_MM.Text = "Blocks";
            // 
            // TILE_BLOCKS_MR
            // 
            this.TILE_BLOCKS_MR.Location = new System.Drawing.Point(462, 216);
            this.TILE_BLOCKS_MR.Name = "TILE_BLOCKS_MR";
            this.TILE_BLOCKS_MR.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_MR.TabIndex = 103;
            this.TILE_BLOCKS_MR.Text = "Blocks";
            // 
            // TILE_BLOCKS_LL
            // 
            this.TILE_BLOCKS_LL.Location = new System.Drawing.Point(288, 344);
            this.TILE_BLOCKS_LL.Name = "TILE_BLOCKS_LL";
            this.TILE_BLOCKS_LL.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_LL.TabIndex = 102;
            this.TILE_BLOCKS_LL.Text = "Blocks";
            // 
            // TILE_BLOCKS_LM
            // 
            this.TILE_BLOCKS_LM.Location = new System.Drawing.Point(376, 344);
            this.TILE_BLOCKS_LM.Name = "TILE_BLOCKS_LM";
            this.TILE_BLOCKS_LM.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_LM.TabIndex = 101;
            this.TILE_BLOCKS_LM.Text = "Blocks";
            // 
            // TILE_BLOCKS_LR
            // 
            this.TILE_BLOCKS_LR.Location = new System.Drawing.Point(464, 344);
            this.TILE_BLOCKS_LR.Name = "TILE_BLOCKS_LR";
            this.TILE_BLOCKS_LR.Size = new System.Drawing.Size(72, 16);
            this.TILE_BLOCKS_LR.TabIndex = 100;
            this.TILE_BLOCKS_LR.Text = "Blocks";
            // 
            // label128
            // 
            this.label128.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label128.Location = new System.Drawing.Point(456, 336);
            this.label128.Name = "label128";
            this.label128.Size = new System.Drawing.Size(88, 128);
            this.label128.TabIndex = 99;
            // 
            // lbl
            // 
            this.lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl.Location = new System.Drawing.Point(368, 336);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(88, 128);
            this.lbl.TabIndex = 98;
            // 
            // label125
            // 
            this.label125.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label125.Location = new System.Drawing.Point(280, 336);
            this.label125.Name = "label125";
            this.label125.Size = new System.Drawing.Size(88, 128);
            this.label125.TabIndex = 97;
            // 
            // label124
            // 
            this.label124.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label124.Location = new System.Drawing.Point(456, 208);
            this.label124.Name = "label124";
            this.label124.Size = new System.Drawing.Size(88, 128);
            this.label124.TabIndex = 96;
            // 
            // label123
            // 
            this.label123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label123.Location = new System.Drawing.Point(368, 208);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(88, 128);
            this.label123.TabIndex = 95;
            // 
            // label122
            // 
            this.label122.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label122.Location = new System.Drawing.Point(280, 208);
            this.label122.Name = "label122";
            this.label122.Size = new System.Drawing.Size(88, 128);
            this.label122.TabIndex = 94;
            // 
            // label121
            // 
            this.label121.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label121.Location = new System.Drawing.Point(456, 80);
            this.label121.Name = "label121";
            this.label121.Size = new System.Drawing.Size(88, 128);
            this.label121.TabIndex = 93;
            // 
            // label120
            // 
            this.label120.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label120.Location = new System.Drawing.Point(368, 80);
            this.label120.Name = "label120";
            this.label120.Size = new System.Drawing.Size(88, 128);
            this.label120.TabIndex = 92;
            // 
            // label119
            // 
            this.label119.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label119.Location = new System.Drawing.Point(280, 80);
            this.label119.Name = "label119";
            this.label119.Size = new System.Drawing.Size(88, 128);
            this.label119.TabIndex = 91;
            // 
            // label118
            // 
            this.label118.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label118.Location = new System.Drawing.Point(280, 64);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(184, 16);
            this.label118.TabIndex = 90;
            this.label118.Text = "Semi-tiles (1/9th of a tile each):";
            // 
            // TILE_BLOCKS_VISION
            // 
            this.TILE_BLOCKS_VISION.Location = new System.Drawing.Point(64, 192);
            this.TILE_BLOCKS_VISION.Name = "TILE_BLOCKS_VISION";
            this.TILE_BLOCKS_VISION.Size = new System.Drawing.Size(208, 16);
            this.TILE_BLOCKS_VISION.TabIndex = 89;
            this.TILE_BLOCKS_VISION.Text = "BLOCKS VISION";
            // 
            // TILE_REFLECTIVE
            // 
            this.TILE_REFLECTIVE.Location = new System.Drawing.Point(64, 176);
            this.TILE_REFLECTIVE.Name = "TILE_REFLECTIVE";
            this.TILE_REFLECTIVE.Size = new System.Drawing.Size(208, 16);
            this.TILE_REFLECTIVE.TabIndex = 88;
            this.TILE_REFLECTIVE.Text = "REFLECTIVE (does nothing?)";
            // 
            // TILE_INDOOR
            // 
            this.TILE_INDOOR.Location = new System.Drawing.Point(64, 160);
            this.TILE_INDOOR.Name = "TILE_INDOOR";
            this.TILE_INDOOR.Size = new System.Drawing.Size(208, 16);
            this.TILE_INDOOR.TabIndex = 87;
            this.TILE_INDOOR.Text = "INDOOR";
            // 
            // TILE_SOUNDPROOF
            // 
            this.TILE_SOUNDPROOF.Location = new System.Drawing.Point(64, 144);
            this.TILE_SOUNDPROOF.Name = "TILE_SOUNDPROOF";
            this.TILE_SOUNDPROOF.Size = new System.Drawing.Size(208, 16);
            this.TILE_SOUNDPROOF.TabIndex = 86;
            this.TILE_SOUNDPROOF.Text = "SOUNDPROOF (deadens sounds)";
            // 
            // TILE_NATURAL
            // 
            this.TILE_NATURAL.Location = new System.Drawing.Point(64, 128);
            this.TILE_NATURAL.Name = "TILE_NATURAL";
            this.TILE_NATURAL.Size = new System.Drawing.Size(208, 16);
            this.TILE_NATURAL.TabIndex = 85;
            this.TILE_NATURAL.Text = "NATURAL (not a man-made tile)";
            // 
            // TILE_ICY
            // 
            this.TILE_ICY.Location = new System.Drawing.Point(64, 112);
            this.TILE_ICY.Name = "TILE_ICY";
            this.TILE_ICY.Size = new System.Drawing.Size(208, 16);
            this.TILE_ICY.TabIndex = 84;
            this.TILE_ICY.Text = "ICY (does nothing?)";
            // 
            // TILE_CAN_FLY_OVER
            // 
            this.TILE_CAN_FLY_OVER.Location = new System.Drawing.Point(64, 96);
            this.TILE_CAN_FLY_OVER.Name = "TILE_CAN_FLY_OVER";
            this.TILE_CAN_FLY_OVER.Size = new System.Drawing.Size(216, 16);
            this.TILE_CAN_FLY_OVER.TabIndex = 83;
            this.TILE_CAN_FLY_OVER.Text = "BLOCKS, CAN FLY OVER (obsolete)";
            // 
            // TILE_SINKS
            // 
            this.TILE_SINKS.Location = new System.Drawing.Point(64, 80);
            this.TILE_SINKS.Name = "TILE_SINKS";
            this.TILE_SINKS.Size = new System.Drawing.Size(208, 16);
            this.TILE_SINKS.TabIndex = 82;
            this.TILE_SINKS.Text = "SINKS (obsolete, don\'t use)";
            // 
            // TILE_BLOCKS
            // 
            this.TILE_BLOCKS.Location = new System.Drawing.Point(64, 64);
            this.TILE_BLOCKS.Name = "TILE_BLOCKS";
            this.TILE_BLOCKS.Size = new System.Drawing.Size(208, 16);
            this.TILE_BLOCKS.TabIndex = 81;
            this.TILE_BLOCKS.Text = "BLOCKS (obsolete, don\'t use)";
            // 
            // label113
            // 
            this.label113.Location = new System.Drawing.Point(8, 64);
            this.label113.Name = "label113";
            this.label113.Size = new System.Drawing.Size(88, 23);
            this.label113.TabIndex = 60;
            this.label113.Text = "Tile Flags:";
            // 
            // btnLoadTile
            // 
            this.btnLoadTile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadTile.Location = new System.Drawing.Point(200, 8);
            this.btnLoadTile.Name = "btnLoadTile";
            this.btnLoadTile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTile.TabIndex = 58;
            this.btnLoadTile.Text = "Load Tile";
            this.btnLoadTile.Click += new System.EventHandler(this.btnLoadTile_Click);
            // 
            // label112
            // 
            this.label112.Location = new System.Drawing.Point(408, 536);
            this.label112.Name = "label112";
            this.label112.Size = new System.Drawing.Size(24, 23);
            this.label112.TabIndex = 57;
            this.label112.Text = "X=";
            // 
            // ToTY
            // 
            this.ToTY.Location = new System.Drawing.Point(504, 536);
            this.ToTY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ToTY.Name = "ToTY";
            this.ToTY.Size = new System.Drawing.Size(48, 20);
            this.ToTY.TabIndex = 56;
            // 
            // ToTX
            // 
            this.ToTX.Location = new System.Drawing.Point(432, 536);
            this.ToTX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.ToTX.Name = "ToTX";
            this.ToTX.Size = new System.Drawing.Size(48, 20);
            this.ToTX.TabIndex = 55;
            // 
            // label111
            // 
            this.label111.Location = new System.Drawing.Point(480, 536);
            this.label111.Name = "label111";
            this.label111.Size = new System.Drawing.Size(24, 23);
            this.label111.TabIndex = 54;
            this.label111.Text = "Y=";
            // 
            // label110
            // 
            this.label110.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label110.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label110.Location = new System.Drawing.Point(392, 536);
            this.label110.Name = "label110";
            this.label110.Size = new System.Drawing.Size(16, 16);
            this.label110.TabIndex = 53;
            this.label110.Text = "to";
            // 
            // label109
            // 
            this.label109.Location = new System.Drawing.Point(240, 536);
            this.label109.Name = "label109";
            this.label109.Size = new System.Drawing.Size(24, 23);
            this.label109.TabIndex = 52;
            this.label109.Text = "X=";
            // 
            // FromTY
            // 
            this.FromTY.Location = new System.Drawing.Point(336, 536);
            this.FromTY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.FromTY.Name = "FromTY";
            this.FromTY.Size = new System.Drawing.Size(48, 20);
            this.FromTY.TabIndex = 51;
            // 
            // FromTX
            // 
            this.FromTX.Location = new System.Drawing.Point(264, 536);
            this.FromTX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.FromTX.Name = "FromTX";
            this.FromTX.Size = new System.Drawing.Size(48, 20);
            this.FromTX.TabIndex = 50;
            // 
            // label108
            // 
            this.label108.Location = new System.Drawing.Point(312, 536);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(24, 23);
            this.label108.TabIndex = 49;
            this.label108.Text = "Y=";
            // 
            // label107
            // 
            this.label107.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label107.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label107.Location = new System.Drawing.Point(168, 536);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(80, 16);
            this.label107.TabIndex = 47;
            this.label107.Text = "Update from";
            // 
            // btnUpdateBoxTiles
            // 
            this.btnUpdateBoxTiles.Location = new System.Drawing.Point(8, 528);
            this.btnUpdateBoxTiles.Name = "btnUpdateBoxTiles";
            this.btnUpdateBoxTiles.Size = new System.Drawing.Size(152, 23);
            this.btnUpdateBoxTiles.TabIndex = 46;
            this.btnUpdateBoxTiles.Text = "Update a box of tiles";
            this.btnUpdateBoxTiles.Click += new System.EventHandler(this.btnUpdateBoxTiles_Click);
            // 
            // label106
            // 
            this.label106.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label106.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label106.Location = new System.Drawing.Point(168, 504);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(368, 16);
            this.label106.TabIndex = 45;
            this.label106.Text = "This operation will update all the tiles defined by this sector";
            // 
            // label105
            // 
            this.label105.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label105.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label105.Location = new System.Drawing.Point(168, 472);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(368, 16);
            this.label105.TabIndex = 44;
            this.label105.Text = "This operation will update a single tile with information above";
            // 
            // btnUpdateAllTiles
            // 
            this.btnUpdateAllTiles.Location = new System.Drawing.Point(8, 496);
            this.btnUpdateAllTiles.Name = "btnUpdateAllTiles";
            this.btnUpdateAllTiles.Size = new System.Drawing.Size(152, 23);
            this.btnUpdateAllTiles.TabIndex = 43;
            this.btnUpdateAllTiles.Text = "Update all tiles in the sector";
            this.btnUpdateAllTiles.Click += new System.EventHandler(this.btnUpdateAllTiles_Click);
            // 
            // btnUpdateTile
            // 
            this.btnUpdateTile.Location = new System.Drawing.Point(8, 464);
            this.btnUpdateTile.Name = "btnUpdateTile";
            this.btnUpdateTile.Size = new System.Drawing.Size(152, 23);
            this.btnUpdateTile.TabIndex = 42;
            this.btnUpdateTile.Text = "Update the Tile";
            this.btnUpdateTile.Click += new System.EventHandler(this.btnUpdateTile_Click);
            // 
            // cmbTileSound
            // 
            this.cmbTileSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTileSound.Items.AddRange(new object[] {
            "00 - Reserved (Unused)",
            "01 - Reserved (Unused)",
            "02 - Dirt",
            "03 - Grass",
            "04 - Water",
            "05 - Deep Water (no sound?)",
            "06 - Ice",
            "07 - Fire (no sound?)",
            "08 - Wood",
            "09 - Stone",
            "10 - Metal",
            "11 - Marsh",
            "12 - Unused?",
            "13 - Unused?",
            "14 - Unused?",
            "15 - Unused?"});
            this.cmbTileSound.Location = new System.Drawing.Point(176, 40);
            this.cmbTileSound.Name = "cmbTileSound";
            this.cmbTileSound.Size = new System.Drawing.Size(216, 21);
            this.cmbTileSound.TabIndex = 41;
            // 
            // label104
            // 
            this.label104.Location = new System.Drawing.Point(8, 40);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(168, 23);
            this.label104.TabIndex = 40;
            this.label104.Text = "Material Type / Footstep Sound:";
            // 
            // TY
            // 
            this.TY.Location = new System.Drawing.Point(144, 8);
            this.TY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TY.Name = "TY";
            this.TY.Size = new System.Drawing.Size(48, 20);
            this.TY.TabIndex = 39;
            this.TY.ValueChanged += new System.EventHandler(this.TY_ValueChanged);
            // 
            // TX
            // 
            this.TX.Location = new System.Drawing.Point(64, 8);
            this.TX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TX.Name = "TX";
            this.TX.Size = new System.Drawing.Size(48, 20);
            this.TX.TabIndex = 38;
            this.TX.ValueChanged += new System.EventHandler(this.TX_ValueChanged);
            // 
            // label101
            // 
            this.label101.Location = new System.Drawing.Point(120, 8);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(24, 23);
            this.label101.TabIndex = 37;
            this.label101.Text = "Y=";
            // 
            // label102
            // 
            this.label102.Location = new System.Drawing.Point(40, 8);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(24, 23);
            this.label102.TabIndex = 36;
            this.label102.Text = "X=";
            // 
            // label103
            // 
            this.label103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label103.Location = new System.Drawing.Point(8, 8);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(72, 24);
            this.label103.TabIndex = 35;
            this.label103.Text = "Tile:";
            // 
            // b_Lights
            // 
            this.b_Lights.Controls.Add(this.btnLightUpdate);
            this.b_Lights.Controls.Add(this.btnDelLight);
            this.b_Lights.Controls.Add(this.btnLightAdd);
            this.b_Lights.Controls.Add(this.label174);
            this.b_Lights.Controls.Add(this.Light30);
            this.b_Lights.Controls.Add(this.label173);
            this.b_Lights.Controls.Add(this.Light29);
            this.b_Lights.Controls.Add(this.label172);
            this.b_Lights.Controls.Add(this.Light28);
            this.b_Lights.Controls.Add(this.label171);
            this.b_Lights.Controls.Add(this.Light27);
            this.b_Lights.Controls.Add(this.label170);
            this.b_Lights.Controls.Add(this.Light26);
            this.b_Lights.Controls.Add(this.label169);
            this.b_Lights.Controls.Add(this.Light25);
            this.b_Lights.Controls.Add(this.label168);
            this.b_Lights.Controls.Add(this.Light11_Y);
            this.b_Lights.Controls.Add(this.Light10_X);
            this.b_Lights.Controls.Add(this.Light24);
            this.b_Lights.Controls.Add(this.label167);
            this.b_Lights.Controls.Add(this.Light23);
            this.b_Lights.Controls.Add(this.label166);
            this.b_Lights.Controls.Add(this.Light22);
            this.b_Lights.Controls.Add(this.label165);
            this.b_Lights.Controls.Add(this.Light21);
            this.b_Lights.Controls.Add(this.label164);
            this.b_Lights.Controls.Add(this.Light20);
            this.b_Lights.Controls.Add(this.label163);
            this.b_Lights.Controls.Add(this.Light19);
            this.b_Lights.Controls.Add(this.label162);
            this.b_Lights.Controls.Add(this.Light18);
            this.b_Lights.Controls.Add(this.label161);
            this.b_Lights.Controls.Add(this.Light17);
            this.b_Lights.Controls.Add(this.label160);
            this.b_Lights.Controls.Add(this.Light16);
            this.b_Lights.Controls.Add(this.label159);
            this.b_Lights.Controls.Add(this.Light15);
            this.b_Lights.Controls.Add(this.label158);
            this.b_Lights.Controls.Add(this.Light14);
            this.b_Lights.Controls.Add(this.label157);
            this.b_Lights.Controls.Add(this.Light13);
            this.b_Lights.Controls.Add(this.label156);
            this.b_Lights.Controls.Add(this.Light12);
            this.b_Lights.Controls.Add(this.label155);
            this.b_Lights.Controls.Add(this.Light9);
            this.b_Lights.Controls.Add(this.label154);
            this.b_Lights.Controls.Add(this.Light8);
            this.b_Lights.Controls.Add(this.label153);
            this.b_Lights.Controls.Add(this.Light6);
            this.b_Lights.Controls.Add(this.label152);
            this.b_Lights.Controls.Add(this.Light7);
            this.b_Lights.Controls.Add(this.label151);
            this.b_Lights.Controls.Add(this.Light5);
            this.b_Lights.Controls.Add(this.label150);
            this.b_Lights.Controls.Add(this.Light4);
            this.b_Lights.Controls.Add(this.label149);
            this.b_Lights.Controls.Add(this.Light3);
            this.b_Lights.Controls.Add(this.label148);
            this.b_Lights.Controls.Add(this.Light2);
            this.b_Lights.Controls.Add(this.label147);
            this.b_Lights.Controls.Add(this.Light1);
            this.b_Lights.Controls.Add(this.label126);
            this.b_Lights.Controls.Add(this.label115);
            this.b_Lights.Controls.Add(this.label114);
            this.b_Lights.Controls.Add(this.LightID);
            this.b_Lights.Controls.Add(this.label100);
            this.b_Lights.Location = new System.Drawing.Point(4, 22);
            this.b_Lights.Name = "b_Lights";
            this.b_Lights.Size = new System.Drawing.Size(552, 566);
            this.b_Lights.TabIndex = 0;
            this.b_Lights.Text = "Lights";
            // 
            // btnLightUpdate
            // 
            this.btnLightUpdate.Location = new System.Drawing.Point(332, 432);
            this.btnLightUpdate.Name = "btnLightUpdate";
            this.btnLightUpdate.Size = new System.Drawing.Size(96, 23);
            this.btnLightUpdate.TabIndex = 67;
            this.btnLightUpdate.Text = "Update Light";
            this.btnLightUpdate.Click += new System.EventHandler(this.btnLightUpdate_Click);
            // 
            // btnDelLight
            // 
            this.btnDelLight.Location = new System.Drawing.Point(228, 432);
            this.btnDelLight.Name = "btnDelLight";
            this.btnDelLight.Size = new System.Drawing.Size(96, 23);
            this.btnDelLight.TabIndex = 66;
            this.btnDelLight.Text = "Delete Light";
            this.btnDelLight.Click += new System.EventHandler(this.btnDelLight_Click);
            // 
            // btnLightAdd
            // 
            this.btnLightAdd.Location = new System.Drawing.Point(124, 432);
            this.btnLightAdd.Name = "btnLightAdd";
            this.btnLightAdd.Size = new System.Drawing.Size(96, 23);
            this.btnLightAdd.TabIndex = 65;
            this.btnLightAdd.Text = "Add Light";
            this.btnLightAdd.Click += new System.EventHandler(this.btnLightAdd_Click);
            // 
            // label174
            // 
            this.label174.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label174.Location = new System.Drawing.Point(0, 416);
            this.label174.Name = "label174";
            this.label174.Size = new System.Drawing.Size(552, 1);
            this.label174.TabIndex = 64;
            this.label174.Text = "label174";
            // 
            // Light30
            // 
            this.Light30.Location = new System.Drawing.Point(368, 336);
            this.Light30.Name = "Light30";
            this.Light30.Size = new System.Drawing.Size(100, 20);
            this.Light30.TabIndex = 63;
            this.Light30.Text = "0";
            // 
            // label173
            // 
            this.label173.Location = new System.Drawing.Point(248, 336);
            this.label173.Name = "label173";
            this.label173.Size = new System.Drawing.Size(136, 16);
            this.label173.TabIndex = 62;
            this.label173.Text = "Unknown 21:";
            // 
            // Light29
            // 
            this.Light29.Location = new System.Drawing.Point(368, 312);
            this.Light29.Name = "Light29";
            this.Light29.Size = new System.Drawing.Size(100, 20);
            this.Light29.TabIndex = 61;
            this.Light29.Text = "0";
            // 
            // label172
            // 
            this.label172.Location = new System.Drawing.Point(248, 312);
            this.label172.Name = "label172";
            this.label172.Size = new System.Drawing.Size(136, 16);
            this.label172.TabIndex = 60;
            this.label172.Text = "Unk. 20 (affects color):";
            // 
            // Light28
            // 
            this.Light28.Location = new System.Drawing.Point(368, 288);
            this.Light28.Name = "Light28";
            this.Light28.Size = new System.Drawing.Size(100, 20);
            this.Light28.TabIndex = 59;
            this.Light28.Text = "0";
            // 
            // label171
            // 
            this.label171.Location = new System.Drawing.Point(248, 288);
            this.label171.Name = "label171";
            this.label171.Size = new System.Drawing.Size(136, 16);
            this.label171.TabIndex = 58;
            this.label171.Text = "Unk. 19 (facing_z?):";
            // 
            // Light27
            // 
            this.Light27.Location = new System.Drawing.Point(368, 264);
            this.Light27.Name = "Light27";
            this.Light27.Size = new System.Drawing.Size(100, 20);
            this.Light27.TabIndex = 57;
            this.Light27.Text = "0";
            // 
            // label170
            // 
            this.label170.Location = new System.Drawing.Point(248, 264);
            this.label170.Name = "label170";
            this.label170.Size = new System.Drawing.Size(136, 16);
            this.label170.TabIndex = 56;
            this.label170.Text = "Unk. 18 (facing_y?):";
            // 
            // Light26
            // 
            this.Light26.Location = new System.Drawing.Point(368, 240);
            this.Light26.Name = "Light26";
            this.Light26.Size = new System.Drawing.Size(100, 20);
            this.Light26.TabIndex = 55;
            this.Light26.Text = "0";
            // 
            // label169
            // 
            this.label169.Location = new System.Drawing.Point(248, 240);
            this.label169.Name = "label169";
            this.label169.Size = new System.Drawing.Size(136, 16);
            this.label169.TabIndex = 54;
            this.label169.Text = "Unk.17 (facing_x?):";
            // 
            // Light25
            // 
            this.Light25.Location = new System.Drawing.Point(368, 216);
            this.Light25.Name = "Light25";
            this.Light25.Size = new System.Drawing.Size(100, 20);
            this.Light25.TabIndex = 53;
            this.Light25.Text = "0";
            // 
            // label168
            // 
            this.label168.Location = new System.Drawing.Point(248, 216);
            this.label168.Name = "label168";
            this.label168.Size = new System.Drawing.Size(136, 16);
            this.label168.TabIndex = 52;
            this.label168.Text = "Unknown 16:";
            // 
            // Light11_Y
            // 
            this.Light11_Y.Location = new System.Drawing.Point(296, 8);
            this.Light11_Y.Name = "Light11_Y";
            this.Light11_Y.Size = new System.Drawing.Size(56, 20);
            this.Light11_Y.TabIndex = 51;
            // 
            // Light10_X
            // 
            this.Light10_X.Location = new System.Drawing.Point(216, 8);
            this.Light10_X.Name = "Light10_X";
            this.Light10_X.Size = new System.Drawing.Size(56, 20);
            this.Light10_X.TabIndex = 50;
            // 
            // Light24
            // 
            this.Light24.Location = new System.Drawing.Point(368, 192);
            this.Light24.Name = "Light24";
            this.Light24.Size = new System.Drawing.Size(100, 20);
            this.Light24.TabIndex = 49;
            this.Light24.Text = "0";
            // 
            // label167
            // 
            this.label167.Location = new System.Drawing.Point(248, 192);
            this.label167.Name = "label167";
            this.label167.Size = new System.Drawing.Size(136, 16);
            this.label167.TabIndex = 48;
            this.label167.Text = "Unk. 15 (end_angle?):";
            // 
            // Light23
            // 
            this.Light23.Location = new System.Drawing.Point(368, 168);
            this.Light23.Name = "Light23";
            this.Light23.Size = new System.Drawing.Size(100, 20);
            this.Light23.TabIndex = 47;
            this.Light23.Text = "0";
            // 
            // label166
            // 
            this.label166.Location = new System.Drawing.Point(248, 168);
            this.label166.Name = "label166";
            this.label166.Size = new System.Drawing.Size(136, 16);
            this.label166.TabIndex = 46;
            this.label166.Text = "Unk. 14 (start_angle?):";
            // 
            // Light22
            // 
            this.Light22.Location = new System.Drawing.Point(368, 144);
            this.Light22.Name = "Light22";
            this.Light22.Size = new System.Drawing.Size(100, 20);
            this.Light22.TabIndex = 45;
            this.Light22.Text = "0";
            // 
            // label165
            // 
            this.label165.Location = new System.Drawing.Point(248, 144);
            this.label165.Name = "label165";
            this.label165.Size = new System.Drawing.Size(136, 16);
            this.label165.TabIndex = 44;
            this.label165.Text = "Unknown 13:";
            // 
            // Light21
            // 
            this.Light21.Location = new System.Drawing.Point(368, 120);
            this.Light21.Name = "Light21";
            this.Light21.Size = new System.Drawing.Size(100, 20);
            this.Light21.TabIndex = 43;
            this.Light21.Text = "0";
            // 
            // label164
            // 
            this.label164.Location = new System.Drawing.Point(248, 120);
            this.label164.Name = "label164";
            this.label164.Size = new System.Drawing.Size(136, 16);
            this.label164.TabIndex = 42;
            this.label164.Text = "Unknown 12:";
            // 
            // Light20
            // 
            this.Light20.Location = new System.Drawing.Point(368, 96);
            this.Light20.Name = "Light20";
            this.Light20.Size = new System.Drawing.Size(100, 20);
            this.Light20.TabIndex = 41;
            this.Light20.Text = "0";
            // 
            // label163
            // 
            this.label163.Location = new System.Drawing.Point(248, 96);
            this.label163.Name = "label163";
            this.label163.Size = new System.Drawing.Size(136, 16);
            this.label163.TabIndex = 40;
            this.label163.Text = "Unknown 11:";
            // 
            // Light19
            // 
            this.Light19.Location = new System.Drawing.Point(368, 72);
            this.Light19.Name = "Light19";
            this.Light19.Size = new System.Drawing.Size(100, 20);
            this.Light19.TabIndex = 39;
            this.Light19.Text = "0";
            // 
            // label162
            // 
            this.label162.Location = new System.Drawing.Point(248, 72);
            this.label162.Name = "label162";
            this.label162.Size = new System.Drawing.Size(136, 16);
            this.label162.TabIndex = 38;
            this.label162.Text = "Unknown 10 (angle?):";
            // 
            // Light18
            // 
            this.Light18.Location = new System.Drawing.Point(368, 48);
            this.Light18.Name = "Light18";
            this.Light18.Size = new System.Drawing.Size(100, 20);
            this.Light18.TabIndex = 37;
            this.Light18.Text = "0";
            // 
            // label161
            // 
            this.label161.Location = new System.Drawing.Point(248, 48);
            this.label161.Name = "label161";
            this.label161.Size = new System.Drawing.Size(136, 16);
            this.label161.TabIndex = 36;
            this.label161.Text = "Light Radius:";
            // 
            // Light17
            // 
            this.Light17.Location = new System.Drawing.Point(128, 384);
            this.Light17.Name = "Light17";
            this.Light17.Size = new System.Drawing.Size(100, 20);
            this.Light17.TabIndex = 35;
            this.Light17.Text = "0";
            // 
            // label160
            // 
            this.label160.Location = new System.Drawing.Point(8, 384);
            this.label160.Name = "label160";
            this.label160.Size = new System.Drawing.Size(136, 16);
            this.label160.TabIndex = 34;
            this.label160.Text = "Unknown 9:";
            // 
            // Light16
            // 
            this.Light16.Location = new System.Drawing.Point(128, 360);
            this.Light16.Name = "Light16";
            this.Light16.Size = new System.Drawing.Size(100, 20);
            this.Light16.TabIndex = 33;
            this.Light16.Text = "0";
            // 
            // label159
            // 
            this.label159.Location = new System.Drawing.Point(8, 360);
            this.label159.Name = "label159";
            this.label159.Size = new System.Drawing.Size(136, 16);
            this.label159.TabIndex = 32;
            this.label159.Text = "Unknown 8:";
            // 
            // Light15
            // 
            this.Light15.Location = new System.Drawing.Point(128, 336);
            this.Light15.Name = "Light15";
            this.Light15.Size = new System.Drawing.Size(100, 20);
            this.Light15.TabIndex = 31;
            this.Light15.Text = "0";
            // 
            // label158
            // 
            this.label158.Location = new System.Drawing.Point(8, 336);
            this.label158.Name = "label158";
            this.label158.Size = new System.Drawing.Size(136, 16);
            this.label158.TabIndex = 30;
            this.label158.Text = "Unknown 7:";
            // 
            // Light14
            // 
            this.Light14.Location = new System.Drawing.Point(128, 312);
            this.Light14.Name = "Light14";
            this.Light14.Size = new System.Drawing.Size(100, 20);
            this.Light14.TabIndex = 29;
            this.Light14.Text = "0";
            // 
            // label157
            // 
            this.label157.Location = new System.Drawing.Point(8, 312);
            this.label157.Name = "label157";
            this.label157.Size = new System.Drawing.Size(136, 16);
            this.label157.TabIndex = 28;
            this.label157.Text = "Offset Z:";
            // 
            // Light13
            // 
            this.Light13.Location = new System.Drawing.Point(128, 288);
            this.Light13.Name = "Light13";
            this.Light13.Size = new System.Drawing.Size(100, 20);
            this.Light13.TabIndex = 27;
            this.Light13.Text = "0";
            // 
            // label156
            // 
            this.label156.Location = new System.Drawing.Point(8, 288);
            this.label156.Name = "label156";
            this.label156.Size = new System.Drawing.Size(136, 16);
            this.label156.TabIndex = 26;
            this.label156.Text = "Offset Y:";
            // 
            // Light12
            // 
            this.Light12.Location = new System.Drawing.Point(128, 264);
            this.Light12.Name = "Light12";
            this.Light12.Size = new System.Drawing.Size(100, 20);
            this.Light12.TabIndex = 25;
            this.Light12.Text = "0";
            // 
            // label155
            // 
            this.label155.Location = new System.Drawing.Point(8, 264);
            this.label155.Name = "label155";
            this.label155.Size = new System.Drawing.Size(136, 16);
            this.label155.TabIndex = 24;
            this.label155.Text = "Offset X:";
            // 
            // Light9
            // 
            this.Light9.Location = new System.Drawing.Point(128, 240);
            this.Light9.Name = "Light9";
            this.Light9.Size = new System.Drawing.Size(100, 20);
            this.Light9.TabIndex = 23;
            this.Light9.Text = "0";
            // 
            // label154
            // 
            this.label154.Location = new System.Drawing.Point(8, 240);
            this.label154.Name = "label154";
            this.label154.Size = new System.Drawing.Size(136, 16);
            this.label154.TabIndex = 22;
            this.label154.Text = "Unknown 6:";
            // 
            // Light8
            // 
            this.Light8.Location = new System.Drawing.Point(128, 216);
            this.Light8.Name = "Light8";
            this.Light8.Size = new System.Drawing.Size(100, 20);
            this.Light8.TabIndex = 21;
            this.Light8.Text = "0";
            // 
            // label153
            // 
            this.label153.Location = new System.Drawing.Point(8, 216);
            this.label153.Name = "label153";
            this.label153.Size = new System.Drawing.Size(136, 16);
            this.label153.TabIndex = 20;
            this.label153.Text = "Unknown 5:";
            // 
            // Light6
            // 
            this.Light6.Location = new System.Drawing.Point(128, 192);
            this.Light6.Name = "Light6";
            this.Light6.Size = new System.Drawing.Size(100, 20);
            this.Light6.TabIndex = 19;
            this.Light6.Text = "0";
            // 
            // label152
            // 
            this.label152.Location = new System.Drawing.Point(8, 192);
            this.label152.Name = "label152";
            this.label152.Size = new System.Drawing.Size(136, 16);
            this.label152.TabIndex = 18;
            this.label152.Text = "Blue (0...255):";
            // 
            // Light7
            // 
            this.Light7.Location = new System.Drawing.Point(128, 168);
            this.Light7.Name = "Light7";
            this.Light7.Size = new System.Drawing.Size(100, 20);
            this.Light7.TabIndex = 17;
            this.Light7.Text = "0";
            // 
            // label151
            // 
            this.label151.Location = new System.Drawing.Point(8, 168);
            this.label151.Name = "label151";
            this.label151.Size = new System.Drawing.Size(136, 16);
            this.label151.TabIndex = 16;
            this.label151.Text = "Green (0...255):";
            // 
            // Light5
            // 
            this.Light5.Location = new System.Drawing.Point(128, 144);
            this.Light5.Name = "Light5";
            this.Light5.Size = new System.Drawing.Size(100, 20);
            this.Light5.TabIndex = 15;
            this.Light5.Text = "0";
            // 
            // label150
            // 
            this.label150.Location = new System.Drawing.Point(8, 144);
            this.label150.Name = "label150";
            this.label150.Size = new System.Drawing.Size(136, 16);
            this.label150.TabIndex = 14;
            this.label150.Text = "Red (0...255):";
            // 
            // Light4
            // 
            this.Light4.Location = new System.Drawing.Point(128, 120);
            this.Light4.Name = "Light4";
            this.Light4.Size = new System.Drawing.Size(100, 20);
            this.Light4.TabIndex = 13;
            this.Light4.Text = "0";
            // 
            // label149
            // 
            this.label149.Location = new System.Drawing.Point(8, 120);
            this.label149.Name = "label149";
            this.label149.Size = new System.Drawing.Size(136, 16);
            this.label149.TabIndex = 12;
            this.label149.Text = "Unknown 4 (flags?):";
            // 
            // Light3
            // 
            this.Light3.Location = new System.Drawing.Point(128, 96);
            this.Light3.Name = "Light3";
            this.Light3.Size = new System.Drawing.Size(100, 20);
            this.Light3.TabIndex = 11;
            this.Light3.Text = "0";
            // 
            // label148
            // 
            this.label148.Location = new System.Drawing.Point(8, 96);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(136, 16);
            this.label148.TabIndex = 10;
            this.label148.Text = "Unknown 3 (light type?):";
            // 
            // Light2
            // 
            this.Light2.Location = new System.Drawing.Point(128, 72);
            this.Light2.Name = "Light2";
            this.Light2.Size = new System.Drawing.Size(100, 20);
            this.Light2.TabIndex = 9;
            this.Light2.Text = "0";
            // 
            // label147
            // 
            this.label147.Location = new System.Drawing.Point(8, 72);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(136, 16);
            this.label147.TabIndex = 8;
            this.label147.Text = "Unknown 2:";
            // 
            // Light1
            // 
            this.Light1.Location = new System.Drawing.Point(128, 48);
            this.Light1.Name = "Light1";
            this.Light1.Size = new System.Drawing.Size(100, 20);
            this.Light1.TabIndex = 7;
            this.Light1.Text = "0";
            // 
            // label126
            // 
            this.label126.Location = new System.Drawing.Point(8, 50);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(136, 16);
            this.label126.TabIndex = 6;
            this.label126.Text = "Unknown 1:";
            // 
            // label115
            // 
            this.label115.Location = new System.Drawing.Point(280, 10);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(24, 16);
            this.label115.TabIndex = 4;
            this.label115.Text = "Y=";
            // 
            // label114
            // 
            this.label114.Location = new System.Drawing.Point(152, 10);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(80, 16);
            this.label114.TabIndex = 2;
            this.label114.Text = "Location: X=";
            // 
            // LightID
            // 
            this.LightID.Location = new System.Drawing.Point(64, 8);
            this.LightID.Name = "LightID";
            this.LightID.Size = new System.Drawing.Size(56, 20);
            this.LightID.TabIndex = 1;
            this.LightID.ValueChanged += new System.EventHandler(this.LightID_ValueChanged);
            // 
            // label100
            // 
            this.label100.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label100.Location = new System.Drawing.Point(8, 10);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(56, 16);
            this.label100.TabIndex = 0;
            this.label100.Text = "Light ID:";
            // 
            // c_Objects
            // 
            this.c_Objects.Controls.Add(this.btnXtrObj);
            this.c_Objects.Controls.Add(this.btnDelObj);
            this.c_Objects.Controls.Add(this.label177);
            this.c_Objects.Controls.Add(this.label176);
            this.c_Objects.Controls.Add(this.SecObjList);
            this.c_Objects.Location = new System.Drawing.Point(4, 22);
            this.c_Objects.Name = "c_Objects";
            this.c_Objects.Size = new System.Drawing.Size(552, 566);
            this.c_Objects.TabIndex = 2;
            this.c_Objects.Text = "Static Objects";
            // 
            // btnXtrObj
            // 
            this.btnXtrObj.Location = new System.Drawing.Point(280, 536);
            this.btnXtrObj.Name = "btnXtrObj";
            this.btnXtrObj.Size = new System.Drawing.Size(104, 23);
            this.btnXtrObj.TabIndex = 4;
            this.btnXtrObj.Text = "Extract Object";
            this.btnXtrObj.Click += new System.EventHandler(this.btnXtrObj_Click);
            // 
            // btnDelObj
            // 
            this.btnDelObj.Location = new System.Drawing.Point(168, 536);
            this.btnDelObj.Name = "btnDelObj";
            this.btnDelObj.Size = new System.Drawing.Size(104, 23);
            this.btnDelObj.TabIndex = 3;
            this.btnDelObj.Text = "Delete Object";
            this.btnDelObj.Click += new System.EventHandler(this.btnDelObj_Click);
            // 
            // label177
            // 
            this.label177.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label177.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label177.Location = new System.Drawing.Point(150, 8);
            this.label177.Name = "label177";
            this.label177.Size = new System.Drawing.Size(288, 16);
            this.label177.TabIndex = 2;
            this.label177.Text = "(use the \"Objects\" tab to embed new objects here):";
            // 
            // label176
            // 
            this.label176.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label176.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label176.Location = new System.Drawing.Point(6, 8);
            this.label176.Name = "label176";
            this.label176.Size = new System.Drawing.Size(538, 16);
            this.label176.TabIndex = 1;
            this.label176.Text = "Embedded static objects";
            // 
            // SecObjList
            // 
            this.SecObjList.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecObjList.ItemHeight = 15;
            this.SecObjList.Location = new System.Drawing.Point(0, 24);
            this.SecObjList.Name = "SecObjList";
            this.SecObjList.Size = new System.Drawing.Size(552, 499);
            this.SecObjList.TabIndex = 0;
            this.SecObjList.SelectedIndexChanged += new System.EventHandler(this.SecObjList_SelectedIndexChanged);
            // 
            // label81
            // 
            this.label81.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label81.Location = new System.Drawing.Point(4, 56);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(236, 1);
            this.label81.TabIndex = 3;
            this.label81.Text = "label81";
            // 
            // btnSaveSec
            // 
            this.btnSaveSec.Enabled = false;
            this.btnSaveSec.Location = new System.Drawing.Point(160, 16);
            this.btnSaveSec.Name = "btnSaveSec";
            this.btnSaveSec.Size = new System.Drawing.Size(64, 23);
            this.btnSaveSec.TabIndex = 2;
            this.btnSaveSec.Text = "Save";
            this.btnSaveSec.Click += new System.EventHandler(this.btnSaveSec_Click);
            // 
            // btnOpenSec
            // 
            this.btnOpenSec.Location = new System.Drawing.Point(88, 16);
            this.btnOpenSec.Name = "btnOpenSec";
            this.btnOpenSec.Size = new System.Drawing.Size(64, 23);
            this.btnOpenSec.TabIndex = 1;
            this.btnOpenSec.Text = "Open...";
            this.btnOpenSec.Click += new System.EventHandler(this.btnOpenSec_Click);
            // 
            // label75
            // 
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.Cursor = System.Windows.Forms.Cursors.Default;
            this.label75.Location = new System.Drawing.Point(240, 4);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(1, 598);
            this.label75.TabIndex = 0;
            this.label75.Text = "label75";
            // 
            // label90
            // 
            this.label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label90.Location = new System.Drawing.Point(4, 104);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(236, 1);
            this.label90.TabIndex = 4;
            this.label90.Text = "label90";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(52, 328);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(136, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // tv_0_0
            // 
            this.tv_0_0.BackColor = System.Drawing.Color.White;
            this.tv_0_0.Location = new System.Drawing.Point(84, 310);
            this.tv_0_0.Name = "tv_0_0";
            this.tv_0_0.Size = new System.Drawing.Size(72, 23);
            this.tv_0_0.TabIndex = 16;
            this.tv_0_0.Text = "(0,0)";
            this.tv_0_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label97
            // 
            this.label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label97.Location = new System.Drawing.Point(4, 504);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(236, 1);
            this.label97.TabIndex = 19;
            this.label97.Text = "label97";
            // 
            // tv_X_Y
            // 
            this.tv_X_Y.BackColor = System.Drawing.Color.White;
            this.tv_X_Y.Location = new System.Drawing.Point(84, 458);
            this.tv_X_Y.Name = "tv_X_Y";
            this.tv_X_Y.Size = new System.Drawing.Size(72, 23);
            this.tv_X_Y.TabIndex = 17;
            this.tv_X_Y.Text = "(0,0)";
            this.tv_X_Y.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label95
            // 
            this.label95.BackColor = System.Drawing.Color.White;
            this.label95.Location = new System.Drawing.Point(8, 304);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(224, 184);
            this.label95.TabIndex = 22;
            // 
            // label98
            // 
            this.label98.BackColor = System.Drawing.Color.White;
            this.label98.Location = new System.Drawing.Point(8, 112);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(224, 144);
            this.label98.TabIndex = 25;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.Color.White;
            this.label99.Location = new System.Drawing.Point(8, 272);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(224, 32);
            this.label99.TabIndex = 26;
            // 
            // cc_SMJumpPts
            // 
            this.cc_SMJumpPts.Controls.Add(this.btnUpdatePoint);
            this.cc_SMJumpPts.Controls.Add(this.label55);
            this.cc_SMJumpPts.Controls.Add(this.JPMap);
            this.cc_SMJumpPts.Controls.Add(this.label54);
            this.cc_SMJumpPts.Controls.Add(this.JPY);
            this.cc_SMJumpPts.Controls.Add(this.label53);
            this.cc_SMJumpPts.Controls.Add(this.JPX);
            this.cc_SMJumpPts.Controls.Add(this.label52);
            this.cc_SMJumpPts.Controls.Add(this.JPName);
            this.cc_SMJumpPts.Controls.Add(this.label51);
            this.cc_SMJumpPts.Controls.Add(this.JPIndex);
            this.cc_SMJumpPts.Controls.Add(this.label50);
            this.cc_SMJumpPts.Controls.Add(this.btnDelPoint);
            this.cc_SMJumpPts.Controls.Add(this.btnAddPoint);
            this.cc_SMJumpPts.Controls.Add(this.btnSaveJP);
            this.cc_SMJumpPts.Controls.Add(this.btnOpenJP);
            this.cc_SMJumpPts.Controls.Add(this.lstJumpPoints);
            this.cc_SMJumpPts.Location = new System.Drawing.Point(4, 22);
            this.cc_SMJumpPts.Name = "cc_SMJumpPts";
            this.cc_SMJumpPts.Size = new System.Drawing.Size(808, 606);
            this.cc_SMJumpPts.TabIndex = 7;
            this.cc_SMJumpPts.Text = "Jump Points";
            // 
            // btnUpdatePoint
            // 
            this.btnUpdatePoint.Location = new System.Drawing.Point(376, 576);
            this.btnUpdatePoint.Name = "btnUpdatePoint";
            this.btnUpdatePoint.Size = new System.Drawing.Size(80, 23);
            this.btnUpdatePoint.TabIndex = 16;
            this.btnUpdatePoint.Text = "Update Point";
            this.btnUpdatePoint.Click += new System.EventHandler(this.btnUpdatePoint_Click);
            // 
            // label55
            // 
            this.label55.Location = new System.Drawing.Point(632, 82);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(168, 24);
            this.label55.TabIndex = 15;
            this.label55.Text = "must correspond to MapList.mes";
            // 
            // JPMap
            // 
            this.JPMap.Location = new System.Drawing.Point(568, 80);
            this.JPMap.Name = "JPMap";
            this.JPMap.Size = new System.Drawing.Size(64, 20);
            this.JPMap.TabIndex = 14;
            this.JPMap.Text = "0";
            // 
            // label54
            // 
            this.label54.Location = new System.Drawing.Point(472, 80);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(96, 24);
            this.label54.TabIndex = 13;
            this.label54.Text = "Target Map:";
            // 
            // JPY
            // 
            this.JPY.Location = new System.Drawing.Point(568, 128);
            this.JPY.Name = "JPY";
            this.JPY.Size = new System.Drawing.Size(64, 20);
            this.JPY.TabIndex = 12;
            this.JPY.Text = "0";
            // 
            // label53
            // 
            this.label53.Location = new System.Drawing.Point(472, 128);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(64, 24);
            this.label53.TabIndex = 11;
            this.label53.Text = "Target Y:";
            // 
            // JPX
            // 
            this.JPX.Location = new System.Drawing.Point(568, 104);
            this.JPX.Name = "JPX";
            this.JPX.Size = new System.Drawing.Size(64, 20);
            this.JPX.TabIndex = 10;
            this.JPX.Text = "0";
            // 
            // label52
            // 
            this.label52.Location = new System.Drawing.Point(472, 104);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(64, 24);
            this.label52.TabIndex = 9;
            this.label52.Text = "Target X:";
            // 
            // JPName
            // 
            this.JPName.Location = new System.Drawing.Point(568, 32);
            this.JPName.Name = "JPName";
            this.JPName.Size = new System.Drawing.Size(232, 20);
            this.JPName.TabIndex = 8;
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(472, 32);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(96, 24);
            this.label51.TabIndex = 7;
            this.label51.Text = "Jump point Name:";
            // 
            // JPIndex
            // 
            this.JPIndex.Location = new System.Drawing.Point(568, 8);
            this.JPIndex.Name = "JPIndex";
            this.JPIndex.Size = new System.Drawing.Size(64, 20);
            this.JPIndex.TabIndex = 6;
            this.JPIndex.Text = "0";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(472, 8);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(96, 24);
            this.label50.TabIndex = 5;
            this.label50.Text = "Jump point Index:";
            // 
            // btnDelPoint
            // 
            this.btnDelPoint.Location = new System.Drawing.Point(288, 576);
            this.btnDelPoint.Name = "btnDelPoint";
            this.btnDelPoint.Size = new System.Drawing.Size(80, 23);
            this.btnDelPoint.TabIndex = 4;
            this.btnDelPoint.Text = "Delete Point";
            this.btnDelPoint.Click += new System.EventHandler(this.btnDelPoint_Click);
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Location = new System.Drawing.Point(200, 576);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(80, 23);
            this.btnAddPoint.TabIndex = 3;
            this.btnAddPoint.Text = "Add Point";
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // btnSaveJP
            // 
            this.btnSaveJP.Location = new System.Drawing.Point(112, 576);
            this.btnSaveJP.Name = "btnSaveJP";
            this.btnSaveJP.Size = new System.Drawing.Size(80, 23);
            this.btnSaveJP.TabIndex = 2;
            this.btnSaveJP.Text = "Save";
            this.btnSaveJP.Click += new System.EventHandler(this.btnSaveJP_Click);
            // 
            // btnOpenJP
            // 
            this.btnOpenJP.Location = new System.Drawing.Point(24, 576);
            this.btnOpenJP.Name = "btnOpenJP";
            this.btnOpenJP.Size = new System.Drawing.Size(80, 23);
            this.btnOpenJP.TabIndex = 1;
            this.btnOpenJP.Text = "Open...";
            this.btnOpenJP.Click += new System.EventHandler(this.btnOpenJP_Click);
            // 
            // lstJumpPoints
            // 
            this.lstJumpPoints.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstJumpPoints.ItemHeight = 16;
            this.lstJumpPoints.Location = new System.Drawing.Point(8, 8);
            this.lstJumpPoints.Name = "lstJumpPoints";
            this.lstJumpPoints.Size = new System.Drawing.Size(464, 564);
            this.lstJumpPoints.TabIndex = 0;
            this.lstJumpPoints.SelectedIndexChanged += new System.EventHandler(this.lstJumpPoints_SelectedIndexChanged);
            // 
            // dd_SMapProps
            // 
            this.dd_SMapProps.Controls.Add(this.GroupAreaCleaner);
            this.dd_SMapProps.Controls.Add(this.GlobalLitGroup);
            this.dd_SMapProps.Controls.Add(this.MapPrpGroup);
            this.dd_SMapProps.Location = new System.Drawing.Point(4, 22);
            this.dd_SMapProps.Name = "dd_SMapProps";
            this.dd_SMapProps.Size = new System.Drawing.Size(808, 606);
            this.dd_SMapProps.TabIndex = 3;
            this.dd_SMapProps.Text = "Map Properties";
            // 
            // GroupAreaCleaner
            // 
            this.GroupAreaCleaner.Controls.Add(this.label145);
            this.GroupAreaCleaner.Controls.Add(this.btnCleanArea);
            this.GroupAreaCleaner.Controls.Add(this.chkHSD);
            this.GroupAreaCleaner.Controls.Add(this.chkPND);
            this.GroupAreaCleaner.Controls.Add(this.chkGMESH);
            this.GroupAreaCleaner.Controls.Add(this.chkCLIPPING);
            this.GroupAreaCleaner.Controls.Add(this.chkSECSVB);
            this.GroupAreaCleaner.Controls.Add(this.chkMOB);
            this.GroupAreaCleaner.Controls.Add(this.label144);
            this.GroupAreaCleaner.Location = new System.Drawing.Point(320, 8);
            this.GroupAreaCleaner.Name = "GroupAreaCleaner";
            this.GroupAreaCleaner.Size = new System.Drawing.Size(480, 576);
            this.GroupAreaCleaner.TabIndex = 2;
            this.GroupAreaCleaner.TabStop = false;
            this.GroupAreaCleaner.Text = "Area Cleaner";
            // 
            // label145
            // 
            this.label145.Location = new System.Drawing.Point(16, 216);
            this.label145.Name = "label145";
            this.label145.Size = new System.Drawing.Size(456, 112);
            this.label145.TabIndex = 8;
            this.label145.Text = resources.GetString("label145.Text");
            // 
            // btnCleanArea
            // 
            this.btnCleanArea.Location = new System.Drawing.Point(164, 168);
            this.btnCleanArea.Name = "btnCleanArea";
            this.btnCleanArea.Size = new System.Drawing.Size(152, 23);
            this.btnCleanArea.TabIndex = 7;
            this.btnCleanArea.Text = "Clean an area...";
            this.btnCleanArea.Click += new System.EventHandler(this.btnCleanArea_Click);
            // 
            // chkHSD
            // 
            this.chkHSD.Location = new System.Drawing.Point(8, 144);
            this.chkHSD.Name = "chkHSD";
            this.chkHSD.Size = new System.Drawing.Size(464, 16);
            this.chkHSD.TabIndex = 6;
            this.chkHSD.Text = "Remove HSD watered tile data files (***)";
            // 
            // chkPND
            // 
            this.chkPND.Location = new System.Drawing.Point(8, 128);
            this.chkPND.Name = "chkPND";
            this.chkPND.Size = new System.Drawing.Size(464, 16);
            this.chkPND.TabIndex = 5;
            this.chkPND.Text = "Remove path nodes (***)";
            // 
            // chkGMESH
            // 
            this.chkGMESH.Location = new System.Drawing.Point(8, 112);
            this.chkGMESH.Name = "chkGMESH";
            this.chkGMESH.Size = new System.Drawing.Size(464, 16);
            this.chkGMESH.TabIndex = 4;
            this.chkGMESH.Text = "Remove ground mesh data (***)";
            // 
            // chkCLIPPING
            // 
            this.chkCLIPPING.Location = new System.Drawing.Point(8, 96);
            this.chkCLIPPING.Name = "chkCLIPPING";
            this.chkCLIPPING.Size = new System.Drawing.Size(464, 16);
            this.chkCLIPPING.TabIndex = 3;
            this.chkCLIPPING.Text = "Remove clipping geometry data (***)";
            // 
            // chkSECSVB
            // 
            this.chkSECSVB.Location = new System.Drawing.Point(8, 80);
            this.chkSECSVB.Name = "chkSECSVB";
            this.chkSECSVB.Size = new System.Drawing.Size(464, 16);
            this.chkSECSVB.TabIndex = 2;
            this.chkSECSVB.Text = "Remove sector data (will delete all wall blocking information, lights, and static" +
                " objects)";
            // 
            // chkMOB
            // 
            this.chkMOB.Location = new System.Drawing.Point(8, 64);
            this.chkMOB.Name = "chkMOB";
            this.chkMOB.Size = new System.Drawing.Size(464, 16);
            this.chkMOB.TabIndex = 1;
            this.chkMOB.Text = "Remove mobile objects";
            // 
            // label144
            // 
            this.label144.Location = new System.Drawing.Point(8, 16);
            this.label144.Name = "label144";
            this.label144.Size = new System.Drawing.Size(464, 48);
            this.label144.TabIndex = 0;
            this.label144.Text = resources.GetString("label144.Text");
            // 
            // GlobalLitGroup
            // 
            this.GlobalLitGroup.Controls.Add(this.btnNewGLT);
            this.GlobalLitGroup.Controls.Add(this.tGLT2);
            this.GlobalLitGroup.Controls.Add(this.tGLT8);
            this.GlobalLitGroup.Controls.Add(this.label143);
            this.GlobalLitGroup.Controls.Add(this.tGLT7);
            this.GlobalLitGroup.Controls.Add(this.label142);
            this.GlobalLitGroup.Controls.Add(this.tGLT6);
            this.GlobalLitGroup.Controls.Add(this.label141);
            this.GlobalLitGroup.Controls.Add(this.tGLTEndAngle);
            this.GlobalLitGroup.Controls.Add(this.label140);
            this.GlobalLitGroup.Controls.Add(this.tGLTStartAngle);
            this.GlobalLitGroup.Controls.Add(this.label139);
            this.GlobalLitGroup.Controls.Add(this.tGLT5);
            this.GlobalLitGroup.Controls.Add(this.label138);
            this.GlobalLitGroup.Controls.Add(this.tGLT4);
            this.GlobalLitGroup.Controls.Add(this.label137);
            this.GlobalLitGroup.Controls.Add(this.tGLT3);
            this.GlobalLitGroup.Controls.Add(this.label136);
            this.GlobalLitGroup.Controls.Add(this.tGLTBlue);
            this.GlobalLitGroup.Controls.Add(this.label135);
            this.GlobalLitGroup.Controls.Add(this.tGLTGreen);
            this.GlobalLitGroup.Controls.Add(this.label134);
            this.GlobalLitGroup.Controls.Add(this.tGLTRed);
            this.GlobalLitGroup.Controls.Add(this.label133);
            this.GlobalLitGroup.Controls.Add(this.label132);
            this.GlobalLitGroup.Controls.Add(this.tGLT1);
            this.GlobalLitGroup.Controls.Add(this.label39);
            this.GlobalLitGroup.Controls.Add(this.btnSaveGLT);
            this.GlobalLitGroup.Controls.Add(this.btnOpenGLT);
            this.GlobalLitGroup.Location = new System.Drawing.Point(8, 208);
            this.GlobalLitGroup.Name = "GlobalLitGroup";
            this.GlobalLitGroup.Size = new System.Drawing.Size(304, 376);
            this.GlobalLitGroup.TabIndex = 1;
            this.GlobalLitGroup.TabStop = false;
            this.GlobalLitGroup.Text = "Global Area Lighting (GLOBAL.LIT)";
            // 
            // btnNewGLT
            // 
            this.btnNewGLT.Location = new System.Drawing.Point(34, 347);
            this.btnNewGLT.Name = "btnNewGLT";
            this.btnNewGLT.Size = new System.Drawing.Size(75, 23);
            this.btnNewGLT.TabIndex = 34;
            this.btnNewGLT.Text = "New";
            this.btnNewGLT.Click += new System.EventHandler(this.btnNewGLT_Click);
            // 
            // tGLT2
            // 
            this.tGLT2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tGLT2.FormattingEnabled = true;
            this.tGLT2.Items.AddRange(new object[] {
            "None",
            "Point",
            "Directional",
            "Spot (recommended for global.lit)",
            "Ambient"});
            this.tGLT2.Location = new System.Drawing.Point(98, 48);
            this.tGLT2.Name = "tGLT2";
            this.tGLT2.Size = new System.Drawing.Size(190, 21);
            this.tGLT2.TabIndex = 9;
            // 
            // tGLT8
            // 
            this.tGLT8.Enabled = false;
            this.tGLT8.Location = new System.Drawing.Point(216, 312);
            this.tGLT8.Name = "tGLT8";
            this.tGLT8.Size = new System.Drawing.Size(72, 20);
            this.tGLT8.TabIndex = 33;
            this.tGLT8.Text = "0";
            // 
            // label143
            // 
            this.label143.Location = new System.Drawing.Point(8, 312);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(216, 24);
            this.label143.TabIndex = 32;
            this.label143.Text = "Angle (floating point value)";
            // 
            // tGLT7
            // 
            this.tGLT7.Enabled = false;
            this.tGLT7.Location = new System.Drawing.Point(216, 288);
            this.tGLT7.Name = "tGLT7";
            this.tGLT7.Size = new System.Drawing.Size(72, 20);
            this.tGLT7.TabIndex = 31;
            this.tGLT7.Text = "0";
            // 
            // label142
            // 
            this.label142.Location = new System.Drawing.Point(8, 288);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(216, 24);
            this.label142.TabIndex = 30;
            this.label142.Text = "Range (floating point value)";
            // 
            // tGLT6
            // 
            this.tGLT6.Enabled = false;
            this.tGLT6.Location = new System.Drawing.Point(216, 264);
            this.tGLT6.Name = "tGLT6";
            this.tGLT6.Size = new System.Drawing.Size(72, 20);
            this.tGLT6.TabIndex = 29;
            this.tGLT6.Text = "0";
            // 
            // label141
            // 
            this.label141.Location = new System.Drawing.Point(8, 264);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(216, 24);
            this.label141.TabIndex = 28;
            this.label141.Text = "Direction: Z (floating point value)";
            // 
            // tGLTEndAngle
            // 
            this.tGLTEndAngle.Enabled = false;
            this.tGLTEndAngle.Location = new System.Drawing.Point(216, 240);
            this.tGLTEndAngle.Name = "tGLTEndAngle";
            this.tGLTEndAngle.Size = new System.Drawing.Size(72, 20);
            this.tGLTEndAngle.TabIndex = 27;
            this.tGLTEndAngle.Text = "0";
            // 
            // label140
            // 
            this.label140.Location = new System.Drawing.Point(8, 240);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(216, 24);
            this.label140.TabIndex = 26;
            this.label140.Text = "Direction: Y (floating point value)";
            // 
            // tGLTStartAngle
            // 
            this.tGLTStartAngle.Enabled = false;
            this.tGLTStartAngle.Location = new System.Drawing.Point(216, 216);
            this.tGLTStartAngle.Name = "tGLTStartAngle";
            this.tGLTStartAngle.Size = new System.Drawing.Size(72, 20);
            this.tGLTStartAngle.TabIndex = 25;
            this.tGLTStartAngle.Text = "0";
            // 
            // label139
            // 
            this.label139.Location = new System.Drawing.Point(8, 216);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(216, 24);
            this.label139.TabIndex = 24;
            this.label139.Text = "Direction: X (floating point value)";
            // 
            // tGLT5
            // 
            this.tGLT5.Enabled = false;
            this.tGLT5.Location = new System.Drawing.Point(216, 192);
            this.tGLT5.Name = "tGLT5";
            this.tGLT5.Size = new System.Drawing.Size(72, 20);
            this.tGLT5.TabIndex = 23;
            this.tGLT5.Text = "0";
            // 
            // label138
            // 
            this.label138.Location = new System.Drawing.Point(8, 192);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(216, 24);
            this.label138.TabIndex = 22;
            this.label138.Text = "Position: Z (floating point value)";
            // 
            // tGLT4
            // 
            this.tGLT4.Enabled = false;
            this.tGLT4.Location = new System.Drawing.Point(216, 168);
            this.tGLT4.Name = "tGLT4";
            this.tGLT4.Size = new System.Drawing.Size(72, 20);
            this.tGLT4.TabIndex = 21;
            this.tGLT4.Text = "0";
            // 
            // label137
            // 
            this.label137.Location = new System.Drawing.Point(8, 168);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(216, 24);
            this.label137.TabIndex = 20;
            this.label137.Text = "Position: Y (floating point value)";
            // 
            // tGLT3
            // 
            this.tGLT3.Enabled = false;
            this.tGLT3.Location = new System.Drawing.Point(216, 144);
            this.tGLT3.Name = "tGLT3";
            this.tGLT3.Size = new System.Drawing.Size(72, 20);
            this.tGLT3.TabIndex = 19;
            this.tGLT3.Text = "0";
            // 
            // label136
            // 
            this.label136.Location = new System.Drawing.Point(8, 144);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(216, 24);
            this.label136.TabIndex = 18;
            this.label136.Text = "Position: X (floating point value)";
            // 
            // tGLTBlue
            // 
            this.tGLTBlue.Enabled = false;
            this.tGLTBlue.Location = new System.Drawing.Point(216, 120);
            this.tGLTBlue.Name = "tGLTBlue";
            this.tGLTBlue.Size = new System.Drawing.Size(72, 20);
            this.tGLTBlue.TabIndex = 17;
            this.tGLTBlue.Text = "0";
            // 
            // label135
            // 
            this.label135.Location = new System.Drawing.Point(8, 120);
            this.label135.Name = "label135";
            this.label135.Size = new System.Drawing.Size(216, 24);
            this.label135.TabIndex = 16;
            this.label135.Text = "Blue (floating point value):";
            // 
            // tGLTGreen
            // 
            this.tGLTGreen.Enabled = false;
            this.tGLTGreen.Location = new System.Drawing.Point(216, 96);
            this.tGLTGreen.Name = "tGLTGreen";
            this.tGLTGreen.Size = new System.Drawing.Size(72, 20);
            this.tGLTGreen.TabIndex = 15;
            this.tGLTGreen.Text = "0";
            // 
            // label134
            // 
            this.label134.Location = new System.Drawing.Point(8, 96);
            this.label134.Name = "label134";
            this.label134.Size = new System.Drawing.Size(216, 24);
            this.label134.TabIndex = 14;
            this.label134.Text = "Green (floating point value):";
            // 
            // tGLTRed
            // 
            this.tGLTRed.Enabled = false;
            this.tGLTRed.Location = new System.Drawing.Point(216, 72);
            this.tGLTRed.Name = "tGLTRed";
            this.tGLTRed.Size = new System.Drawing.Size(72, 20);
            this.tGLTRed.TabIndex = 13;
            this.tGLTRed.Text = "0";
            // 
            // label133
            // 
            this.label133.Location = new System.Drawing.Point(8, 72);
            this.label133.Name = "label133";
            this.label133.Size = new System.Drawing.Size(216, 24);
            this.label133.TabIndex = 12;
            this.label133.Text = "Red (floating point value):";
            // 
            // label132
            // 
            this.label132.Location = new System.Drawing.Point(8, 48);
            this.label132.Name = "label132";
            this.label132.Size = new System.Drawing.Size(216, 24);
            this.label132.TabIndex = 10;
            this.label132.Text = "Light Type:";
            // 
            // tGLT1
            // 
            this.tGLT1.Enabled = false;
            this.tGLT1.Location = new System.Drawing.Point(216, 24);
            this.tGLT1.Name = "tGLT1";
            this.tGLT1.Size = new System.Drawing.Size(72, 20);
            this.tGLT1.TabIndex = 9;
            this.tGLT1.Text = "0";
            // 
            // label39
            // 
            this.label39.Location = new System.Drawing.Point(8, 24);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(216, 24);
            this.label39.TabIndex = 8;
            this.label39.Text = "32-bit Flags (always 1 in global.lit):";
            // 
            // btnSaveGLT
            // 
            this.btnSaveGLT.Enabled = false;
            this.btnSaveGLT.Location = new System.Drawing.Point(195, 347);
            this.btnSaveGLT.Name = "btnSaveGLT";
            this.btnSaveGLT.Size = new System.Drawing.Size(75, 23);
            this.btnSaveGLT.TabIndex = 3;
            this.btnSaveGLT.Text = "Save";
            this.btnSaveGLT.Click += new System.EventHandler(this.btnSaveGLT_Click);
            // 
            // btnOpenGLT
            // 
            this.btnOpenGLT.Location = new System.Drawing.Point(115, 347);
            this.btnOpenGLT.Name = "btnOpenGLT";
            this.btnOpenGLT.Size = new System.Drawing.Size(75, 23);
            this.btnOpenGLT.TabIndex = 2;
            this.btnOpenGLT.Text = "Open...";
            this.btnOpenGLT.Click += new System.EventHandler(this.btnOpenGLT_Click);
            // 
            // MapPrpGroup
            // 
            this.MapPrpGroup.Controls.Add(this.tMapHeight);
            this.MapPrpGroup.Controls.Add(this.label85);
            this.MapPrpGroup.Controls.Add(this.tMapWidth);
            this.MapPrpGroup.Controls.Add(this.label84);
            this.MapPrpGroup.Controls.Add(this.tArtEntry);
            this.MapPrpGroup.Controls.Add(this.label76);
            this.MapPrpGroup.Controls.Add(this.btnSaveProps);
            this.MapPrpGroup.Controls.Add(this.btnOpenProps);
            this.MapPrpGroup.Controls.Add(this.label130);
            this.MapPrpGroup.Location = new System.Drawing.Point(8, 8);
            this.MapPrpGroup.Name = "MapPrpGroup";
            this.MapPrpGroup.Size = new System.Drawing.Size(304, 184);
            this.MapPrpGroup.TabIndex = 0;
            this.MapPrpGroup.TabStop = false;
            this.MapPrpGroup.Text = "Map Properties (MAP.PRP)";
            // 
            // tMapHeight
            // 
            this.tMapHeight.Enabled = false;
            this.tMapHeight.Location = new System.Drawing.Point(216, 72);
            this.tMapHeight.Name = "tMapHeight";
            this.tMapHeight.Size = new System.Drawing.Size(72, 20);
            this.tMapHeight.TabIndex = 7;
            this.tMapHeight.Text = "0";
            // 
            // label85
            // 
            this.label85.Location = new System.Drawing.Point(8, 72);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(216, 24);
            this.label85.TabIndex = 6;
            this.label85.Text = "Height (in 64x64 sectors):";
            // 
            // tMapWidth
            // 
            this.tMapWidth.Enabled = false;
            this.tMapWidth.Location = new System.Drawing.Point(216, 48);
            this.tMapWidth.Name = "tMapWidth";
            this.tMapWidth.Size = new System.Drawing.Size(72, 20);
            this.tMapWidth.TabIndex = 5;
            this.tMapWidth.Text = "0";
            // 
            // label84
            // 
            this.label84.Location = new System.Drawing.Point(8, 48);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(216, 24);
            this.label84.TabIndex = 4;
            this.label84.Text = "Width (in 64x64 sectors):";
            // 
            // tArtEntry
            // 
            this.tArtEntry.Enabled = false;
            this.tArtEntry.Location = new System.Drawing.Point(216, 24);
            this.tArtEntry.Name = "tArtEntry";
            this.tArtEntry.Size = new System.Drawing.Size(72, 20);
            this.tArtEntry.TabIndex = 3;
            this.tArtEntry.Text = "0";
            // 
            // label76
            // 
            this.label76.Location = new System.Drawing.Point(8, 26);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(216, 24);
            this.label76.TabIndex = 2;
            this.label76.Text = "2D Map Entry (per ART/GROUND.MES):";
            // 
            // btnSaveProps
            // 
            this.btnSaveProps.Enabled = false;
            this.btnSaveProps.Location = new System.Drawing.Point(152, 104);
            this.btnSaveProps.Name = "btnSaveProps";
            this.btnSaveProps.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProps.TabIndex = 1;
            this.btnSaveProps.Text = "Save";
            this.btnSaveProps.Click += new System.EventHandler(this.btnSaveProps_Click);
            // 
            // btnOpenProps
            // 
            this.btnOpenProps.Location = new System.Drawing.Point(72, 104);
            this.btnOpenProps.Name = "btnOpenProps";
            this.btnOpenProps.Size = new System.Drawing.Size(75, 23);
            this.btnOpenProps.TabIndex = 0;
            this.btnOpenProps.Text = "Open...";
            this.btnOpenProps.Click += new System.EventHandler(this.btnOpenProps_Click);
            // 
            // label130
            // 
            this.label130.Location = new System.Drawing.Point(8, 136);
            this.label130.Name = "label130";
            this.label130.Size = new System.Drawing.Size(288, 40);
            this.label130.TabIndex = 1;
            this.label130.Text = "NOTE: Width and height is always 15 x 15 sectors for ToEE maps, even though the a" +
                "ctual map can be smaller (it depends on the JPEG chunks)";
            this.label130.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ee_N2DMaps
            // 
            this.ee_N2DMaps.Controls.Add(this.button9);
            this.ee_N2DMaps.Controls.Add(this.button8);
            this.ee_N2DMaps.Controls.Add(this.button7);
            this.ee_N2DMaps.Controls.Add(this.button6);
            this.ee_N2DMaps.Controls.Add(this.button5);
            this.ee_N2DMaps.Controls.Add(this.label34);
            this.ee_N2DMaps.Controls.Add(this.label33);
            this.ee_N2DMaps.Controls.Add(this.label32);
            this.ee_N2DMaps.Controls.Add(this.label31);
            this.ee_N2DMaps.Controls.Add(this.label30);
            this.ee_N2DMaps.Controls.Add(this.label29);
            this.ee_N2DMaps.Controls.Add(this.label28);
            this.ee_N2DMaps.Controls.Add(this.label21);
            this.ee_N2DMaps.Controls.Add(this.recomb_partial);
            this.ee_N2DMaps.Controls.Add(this.label12);
            this.ee_N2DMaps.Controls.Add(this.SY);
            this.ee_N2DMaps.Controls.Add(this.SX);
            this.ee_N2DMaps.Controls.Add(this.label11);
            this.ee_N2DMaps.Controls.Add(this.PY);
            this.ee_N2DMaps.Controls.Add(this.label10);
            this.ee_N2DMaps.Controls.Add(this.PX);
            this.ee_N2DMaps.Controls.Add(this.label7);
            this.ee_N2DMaps.Controls.Add(this.label8);
            this.ee_N2DMaps.Controls.Add(this.button3);
            this.ee_N2DMaps.Controls.Add(this.button4);
            this.ee_N2DMaps.Controls.Add(this.label9);
            this.ee_N2DMaps.Controls.Add(this.label15);
            this.ee_N2DMaps.Controls.Add(this.label16);
            this.ee_N2DMaps.Controls.Add(this.label17);
            this.ee_N2DMaps.Controls.Add(this.splitData);
            this.ee_N2DMaps.Controls.Add(this.button1);
            this.ee_N2DMaps.Controls.Add(this.fdata);
            this.ee_N2DMaps.Controls.Add(this.button2);
            this.ee_N2DMaps.Controls.Add(this.label18);
            this.ee_N2DMaps.Controls.Add(this.label19);
            this.ee_N2DMaps.Controls.Add(this.label20);
            this.ee_N2DMaps.Controls.Add(this.label14);
            this.ee_N2DMaps.Controls.Add(this.label13);
            this.ee_N2DMaps.Location = new System.Drawing.Point(4, 22);
            this.ee_N2DMaps.Name = "ee_N2DMaps";
            this.ee_N2DMaps.Size = new System.Drawing.Size(808, 606);
            this.ee_N2DMaps.TabIndex = 1;
            this.ee_N2DMaps.Text = "2D Maps";
            // 
            // label34
            // 
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Location = new System.Drawing.Point(8, 536);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(792, 32);
            this.label34.TabIndex = 59;
            this.label34.Text = resources.GetString("label34.Text");
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Location = new System.Drawing.Point(8, 504);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(792, 32);
            this.label33.TabIndex = 58;
            this.label33.Text = resources.GetString("label33.Text");
            // 
            // label32
            // 
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.Location = new System.Drawing.Point(8, 456);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(792, 40);
            this.label32.TabIndex = 57;
            this.label32.Text = resources.GetString("label32.Text");
            // 
            // label31
            // 
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label31.Location = new System.Drawing.Point(8, 416);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(792, 32);
            this.label31.TabIndex = 56;
            this.label31.Text = resources.GetString("label31.Text");
            // 
            // label30
            // 
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Location = new System.Drawing.Point(8, 392);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(792, 32);
            this.label30.TabIndex = 55;
            this.label30.Text = "The 2D game maps are located within \"modules/ToEE.dat\" file, so first you\'ll need" +
                " to unpack this file. Afterwards, you can begin working with them.";
            // 
            // label29
            // 
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Location = new System.Drawing.Point(8, 352);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(792, 32);
            this.label29.TabIndex = 54;
            this.label29.Text = resources.GetString("label29.Text");
            // 
            // label28
            // 
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(8, 336);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(176, 16);
            this.label28.TabIndex = 53;
            this.label28.Text = "INSTRUCTIONS:";
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(0, 328);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(808, 1);
            this.label21.TabIndex = 52;
            // 
            // recomb_partial
            // 
            this.recomb_partial.Location = new System.Drawing.Point(385, 120);
            this.recomb_partial.Name = "recomb_partial";
            this.recomb_partial.Size = new System.Drawing.Size(124, 23);
            this.recomb_partial.TabIndex = 49;
            this.recomb_partial.Text = "Recombine Partially";
            this.recomb_partial.Click += new System.EventHandler(this.recomb_partial_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(321, 96);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 23);
            this.label12.TabIndex = 48;
            this.label12.Text = " * ";
            // 
            // SY
            // 
            this.SY.Location = new System.Drawing.Point(345, 120);
            this.SY.Name = "SY";
            this.SY.Size = new System.Drawing.Size(32, 20);
            this.SY.TabIndex = 47;
            // 
            // SX
            // 
            this.SX.Location = new System.Drawing.Point(289, 120);
            this.SX.Name = "SX";
            this.SX.Size = new System.Drawing.Size(32, 20);
            this.SX.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(217, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 45;
            this.label11.Text = "starting at X=";
            // 
            // PY
            // 
            this.PY.Location = new System.Drawing.Point(345, 96);
            this.PY.Name = "PY";
            this.PY.Size = new System.Drawing.Size(32, 20);
            this.PY.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(323, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 23);
            this.label10.TabIndex = 43;
            this.label10.Text = "Y=";
            // 
            // PX
            // 
            this.PX.Location = new System.Drawing.Point(289, 96);
            this.PX.Name = "PX";
            this.PX.Size = new System.Drawing.Size(32, 20);
            this.PX.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(121, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 23);
            this.label7.TabIndex = 41;
            this.label7.Text = "Partial Recombiner:";
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(244, 288);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(328, 23);
            this.label8.TabIndex = 40;
            this.label8.Text = "Note - the _4 and _8 maps should be split separately";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(322, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 23);
            this.button3.TabIndex = 39;
            this.button3.Text = "Split";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(322, 248);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 23);
            this.button4.TabIndex = 38;
            this.button4.Text = "Recombine";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(250, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 37;
            this.label9.Text = "Recombiner:";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(250, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 23);
            this.label15.TabIndex = 36;
            this.label15.Text = "Splitter:";
            // 
            // label16
            // 
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(236, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(328, 23);
            this.label16.TabIndex = 35;
            this.label16.Text = "MINIMAPS (reside in modules/ToEE/townmap):";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(240, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(328, 23);
            this.label17.TabIndex = 34;
            this.label17.Text = "THE BIG MAP (resides in modules/ToEE/art/ground):";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // splitData
            // 
            this.splitData.Location = new System.Drawing.Point(297, 32);
            this.splitData.Name = "splitData";
            this.splitData.Size = new System.Drawing.Size(100, 16);
            this.splitData.TabIndex = 33;
            this.splitData.Text = "No data loaded";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Split";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fdata
            // 
            this.fdata.Location = new System.Drawing.Point(297, 64);
            this.fdata.Name = "fdata";
            this.fdata.Size = new System.Drawing.Size(100, 16);
            this.fdata.TabIndex = 31;
            this.fdata.Text = "No data loaded";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(193, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 30;
            this.button2.Text = "Recombine";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(121, 64);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 23);
            this.label18.TabIndex = 29;
            this.label18.Text = "Recombiner:";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(0, 160);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(808, 1);
            this.label19.TabIndex = 28;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(121, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 27;
            this.label20.Text = "Splitter:";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(241, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 23);
            this.label14.TabIndex = 51;
            this.label14.Text = "combine";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(385, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 50;
            this.label13.Text = "blocks";
            // 
            // ff_YT_Prototypes
            // 
            this.ff_YT_Prototypes.Controls.Add(this.btnDblClickClean);
            this.ff_YT_Prototypes.Controls.Add(this.btnIPReplace);
            this.ff_YT_Prototypes.Controls.Add(this.btnGoToDesc);
            this.ff_YT_Prototypes.Controls.Add(this.btnSaveProtos);
            this.ff_YT_Prototypes.Controls.Add(this.btnDelProto);
            this.ff_YT_Prototypes.Controls.Add(this.btnAddProto);
            this.ff_YT_Prototypes.Controls.Add(this.tProtoID);
            this.ff_YT_Prototypes.Controls.Add(this.label74);
            this.ff_YT_Prototypes.Controls.Add(this.btnIPInsert);
            this.ff_YT_Prototypes.Controls.Add(this.btnUpdateProto);
            this.ff_YT_Prototypes.Controls.Add(this.IntelliProp);
            this.ff_YT_Prototypes.Controls.Add(this.label73);
            this.ff_YT_Prototypes.Controls.Add(this.tPropValue);
            this.ff_YT_Prototypes.Controls.Add(this.label72);
            this.ff_YT_Prototypes.Controls.Add(this.CurProto);
            this.ff_YT_Prototypes.Controls.Add(this.label71);
            this.ff_YT_Prototypes.Controls.Add(this.lstProtoProps);
            this.ff_YT_Prototypes.Location = new System.Drawing.Point(4, 22);
            this.ff_YT_Prototypes.Name = "ff_YT_Prototypes";
            this.ff_YT_Prototypes.Size = new System.Drawing.Size(808, 606);
            this.ff_YT_Prototypes.TabIndex = 8;
            this.ff_YT_Prototypes.Text = "Prototypes";
            // 
            // btnDblClickClean
            // 
            this.btnDblClickClean.AutoSize = true;
            this.btnDblClickClean.Location = new System.Drawing.Point(614, 578);
            this.btnDblClickClean.Name = "btnDblClickClean";
            this.btnDblClickClean.Size = new System.Drawing.Size(185, 17);
            this.btnDblClickClean.TabIndex = 16;
            this.btnDblClickClean.Text = "Use Double Click to Clean Entries";
            this.btnDblClickClean.UseVisualStyleBackColor = true;
            // 
            // btnIPReplace
            // 
            this.btnIPReplace.Location = new System.Drawing.Point(520, 576);
            this.btnIPReplace.Name = "btnIPReplace";
            this.btnIPReplace.Size = new System.Drawing.Size(88, 24);
            this.btnIPReplace.TabIndex = 15;
            this.btnIPReplace.Text = "Replace";
            this.btnIPReplace.Click += new System.EventHandler(this.btnIPReplace_Click);
            // 
            // btnGoToDesc
            // 
            this.btnGoToDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnGoToDesc.Location = new System.Drawing.Point(368, 6);
            this.btnGoToDesc.Name = "btnGoToDesc";
            this.btnGoToDesc.Size = new System.Drawing.Size(96, 23);
            this.btnGoToDesc.TabIndex = 14;
            this.btnGoToDesc.Text = "Go to Description";
            this.btnGoToDesc.Click += new System.EventHandler(this.btnGoToDesc_Click);
            // 
            // btnSaveProtos
            // 
            this.btnSaveProtos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveProtos.Location = new System.Drawing.Point(664, 6);
            this.btnSaveProtos.Name = "btnSaveProtos";
            this.btnSaveProtos.Size = new System.Drawing.Size(88, 23);
            this.btnSaveProtos.TabIndex = 13;
            this.btnSaveProtos.Text = "Save All";
            this.btnSaveProtos.Click += new System.EventHandler(this.btnSaveProtos_Click);
            // 
            // btnDelProto
            // 
            this.btnDelProto.Location = new System.Drawing.Point(568, 6);
            this.btnDelProto.Name = "btnDelProto";
            this.btnDelProto.Size = new System.Drawing.Size(88, 23);
            this.btnDelProto.TabIndex = 12;
            this.btnDelProto.Text = "Delete Proto";
            this.btnDelProto.Click += new System.EventHandler(this.btnDelProto_Click);
            // 
            // btnAddProto
            // 
            this.btnAddProto.Location = new System.Drawing.Point(472, 6);
            this.btnAddProto.Name = "btnAddProto";
            this.btnAddProto.Size = new System.Drawing.Size(88, 23);
            this.btnAddProto.TabIndex = 11;
            this.btnAddProto.Text = "Add New Proto";
            this.btnAddProto.Click += new System.EventHandler(this.btnAddProto_Click);
            // 
            // tProtoID
            // 
            this.tProtoID.Location = new System.Drawing.Point(288, 6);
            this.tProtoID.Name = "tProtoID";
            this.tProtoID.Size = new System.Drawing.Size(72, 20);
            this.tProtoID.TabIndex = 10;
            this.tProtoID.Text = "0";
            // 
            // label74
            // 
            this.label74.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label74.Location = new System.Drawing.Point(264, 8);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(24, 23);
            this.label74.TabIndex = 9;
            this.label74.Text = "ID:";
            // 
            // btnIPInsert
            // 
            this.btnIPInsert.Location = new System.Drawing.Point(424, 576);
            this.btnIPInsert.Name = "btnIPInsert";
            this.btnIPInsert.Size = new System.Drawing.Size(88, 24);
            this.btnIPInsert.TabIndex = 8;
            this.btnIPInsert.Text = "Add";
            this.btnIPInsert.Click += new System.EventHandler(this.btnIPInsert_Click);
            // 
            // btnUpdateProto
            // 
            this.btnUpdateProto.Location = new System.Drawing.Point(712, 552);
            this.btnUpdateProto.Name = "btnUpdateProto";
            this.btnUpdateProto.Size = new System.Drawing.Size(88, 24);
            this.btnUpdateProto.TabIndex = 7;
            this.btnUpdateProto.Text = "Set";
            this.btnUpdateProto.Click += new System.EventHandler(this.btnUpdateProto_Click);
            // 
            // IntelliProp
            // 
            this.IntelliProp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IntelliProp.Location = new System.Drawing.Point(104, 576);
            this.IntelliProp.Name = "IntelliProp";
            this.IntelliProp.Size = new System.Drawing.Size(320, 21);
            this.IntelliProp.Sorted = true;
            this.IntelliProp.TabIndex = 6;
            // 
            // label73
            // 
            this.label73.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label73.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label73.Location = new System.Drawing.Point(8, 576);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(96, 23);
            this.label73.TabIndex = 5;
            this.label73.Text = "IntelliProperties:";
            // 
            // tPropValue
            // 
            this.tPropValue.Location = new System.Drawing.Point(48, 552);
            this.tPropValue.Name = "tPropValue";
            this.tPropValue.Size = new System.Drawing.Size(664, 20);
            this.tPropValue.TabIndex = 4;
            // 
            // label72
            // 
            this.label72.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label72.Location = new System.Drawing.Point(8, 552);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(48, 23);
            this.label72.TabIndex = 3;
            this.label72.Text = "Value:";
            // 
            // CurProto
            // 
            this.CurProto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CurProto.Location = new System.Drawing.Point(72, 6);
            this.CurProto.Name = "CurProto";
            this.CurProto.Size = new System.Drawing.Size(184, 21);
            this.CurProto.Sorted = true;
            this.CurProto.TabIndex = 2;
            this.CurProto.SelectedIndexChanged += new System.EventHandler(this.CurProto_SelectedIndexChanged);
            // 
            // label71
            // 
            this.label71.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label71.Location = new System.Drawing.Point(8, 8);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(72, 23);
            this.label71.TabIndex = 1;
            this.label71.Text = "Prototype:";
            // 
            // lstProtoProps
            // 
            this.lstProtoProps.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstProtoProps.ItemHeight = 16;
            this.lstProtoProps.Location = new System.Drawing.Point(8, 32);
            this.lstProtoProps.Name = "lstProtoProps";
            this.lstProtoProps.Size = new System.Drawing.Size(792, 516);
            this.lstProtoProps.TabIndex = 0;
            this.lstProtoProps.SelectedIndexChanged += new System.EventHandler(this.lstProtoProps_SelectedIndexChanged);
            this.lstProtoProps.DoubleClick += new System.EventHandler(this.lstProtoProps_DoubleClick);
            // 
            // gg_YX_Descriptions
            // 
            this.gg_YX_Descriptions.Controls.Add(this.btnAddDesc);
            this.gg_YX_Descriptions.Controls.Add(this.btnRemoveDesc);
            this.gg_YX_Descriptions.Controls.Add(this.label83);
            this.gg_YX_Descriptions.Controls.Add(this.label82);
            this.gg_YX_Descriptions.Controls.Add(this.btnLookUpProto);
            this.gg_YX_Descriptions.Controls.Add(this.btnSaveDesc);
            this.gg_YX_Descriptions.Controls.Add(this.btnSetDescs);
            this.gg_YX_Descriptions.Controls.Add(this.tLongDescript);
            this.gg_YX_Descriptions.Controls.Add(this.label80);
            this.gg_YX_Descriptions.Controls.Add(this.tDescript);
            this.gg_YX_Descriptions.Controls.Add(this.label79);
            this.gg_YX_Descriptions.Controls.Add(this.tDescID);
            this.gg_YX_Descriptions.Controls.Add(this.label78);
            this.gg_YX_Descriptions.Controls.Add(this.lstDesc);
            this.gg_YX_Descriptions.Location = new System.Drawing.Point(4, 22);
            this.gg_YX_Descriptions.Name = "gg_YX_Descriptions";
            this.gg_YX_Descriptions.Size = new System.Drawing.Size(808, 606);
            this.gg_YX_Descriptions.TabIndex = 9;
            this.gg_YX_Descriptions.Text = "Proto Descriptions";
            // 
            // btnAddDesc
            // 
            this.btnAddDesc.Location = new System.Drawing.Point(384, 216);
            this.btnAddDesc.Name = "btnAddDesc";
            this.btnAddDesc.Size = new System.Drawing.Size(75, 23);
            this.btnAddDesc.TabIndex = 16;
            this.btnAddDesc.Text = "Add";
            this.btnAddDesc.Click += new System.EventHandler(this.btnAddDesc_Click);
            // 
            // btnRemoveDesc
            // 
            this.btnRemoveDesc.Location = new System.Drawing.Point(464, 216);
            this.btnRemoveDesc.Name = "btnRemoveDesc";
            this.btnRemoveDesc.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveDesc.TabIndex = 15;
            this.btnRemoveDesc.Text = "Remove";
            this.btnRemoveDesc.Click += new System.EventHandler(this.btnRemoveDesc_Click);
            // 
            // label83
            // 
            this.label83.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label83.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label83.Location = new System.Drawing.Point(376, 336);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(424, 80);
            this.label83.TabIndex = 14;
            this.label83.Text = "NOTE: Your changes will NOT be saved to the files until you press the \"SAVE\" butt" +
                "on! If you forget to save you will lose all your changes next time you start ToE" +
                "E World Builder!";
            this.label83.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label82
            // 
            this.label82.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label82.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label82.Location = new System.Drawing.Point(376, 256);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(424, 80);
            this.label82.TabIndex = 13;
            this.label82.Text = resources.GetString("label82.Text");
            this.label82.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnLookUpProto
            // 
            this.btnLookUpProto.Location = new System.Drawing.Point(624, 216);
            this.btnLookUpProto.Name = "btnLookUpProto";
            this.btnLookUpProto.Size = new System.Drawing.Size(88, 23);
            this.btnLookUpProto.TabIndex = 11;
            this.btnLookUpProto.Text = "Look up Proto";
            this.btnLookUpProto.Click += new System.EventHandler(this.btnLookUpProto_Click);
            // 
            // btnSaveDesc
            // 
            this.btnSaveDesc.Location = new System.Drawing.Point(720, 216);
            this.btnSaveDesc.Name = "btnSaveDesc";
            this.btnSaveDesc.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDesc.TabIndex = 10;
            this.btnSaveDesc.Text = "Save";
            this.btnSaveDesc.Click += new System.EventHandler(this.btnSaveDesc_Click);
            // 
            // btnSetDescs
            // 
            this.btnSetDescs.Location = new System.Drawing.Point(544, 216);
            this.btnSetDescs.Name = "btnSetDescs";
            this.btnSetDescs.Size = new System.Drawing.Size(75, 23);
            this.btnSetDescs.TabIndex = 7;
            this.btnSetDescs.Text = "Update";
            this.btnSetDescs.Click += new System.EventHandler(this.btnSetDescs_Click);
            // 
            // tLongDescript
            // 
            this.tLongDescript.Location = new System.Drawing.Point(464, 64);
            this.tLongDescript.Multiline = true;
            this.tLongDescript.Name = "tLongDescript";
            this.tLongDescript.Size = new System.Drawing.Size(336, 144);
            this.tLongDescript.TabIndex = 6;
            // 
            // label80
            // 
            this.label80.Location = new System.Drawing.Point(376, 64);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(96, 23);
            this.label80.TabIndex = 5;
            this.label80.Text = "Long Description:";
            // 
            // tDescript
            // 
            this.tDescript.Location = new System.Drawing.Point(440, 32);
            this.tDescript.Name = "tDescript";
            this.tDescript.Size = new System.Drawing.Size(360, 20);
            this.tDescript.TabIndex = 4;
            // 
            // label79
            // 
            this.label79.Location = new System.Drawing.Point(376, 32);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(64, 23);
            this.label79.TabIndex = 3;
            this.label79.Text = "Description:";
            // 
            // tDescID
            // 
            this.tDescID.Location = new System.Drawing.Point(440, 8);
            this.tDescID.Name = "tDescID";
            this.tDescID.Size = new System.Drawing.Size(72, 20);
            this.tDescID.TabIndex = 2;
            this.tDescID.Text = "0";
            // 
            // label78
            // 
            this.label78.Location = new System.Drawing.Point(376, 8);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(64, 23);
            this.label78.TabIndex = 1;
            this.label78.Text = "ID:";
            // 
            // lstDesc
            // 
            this.lstDesc.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDesc.ItemHeight = 16;
            this.lstDesc.Location = new System.Drawing.Point(8, 8);
            this.lstDesc.Name = "lstDesc";
            this.lstDesc.Size = new System.Drawing.Size(360, 580);
            this.lstDesc.TabIndex = 0;
            this.lstDesc.SelectedIndexChanged += new System.EventHandler(this.lstDesc_SelectedIndexChanged);
            // 
            // h_YScripts
            // 
            this.h_YScripts.Controls.Add(this.btnLoadScripts);
            this.h_YScripts.Controls.Add(this.btnEditScript);
            this.h_YScripts.Controls.Add(this.btnDelScript);
            this.h_YScripts.Controls.Add(this.lstScripts);
            this.h_YScripts.Location = new System.Drawing.Point(4, 22);
            this.h_YScripts.Name = "h_YScripts";
            this.h_YScripts.Size = new System.Drawing.Size(808, 606);
            this.h_YScripts.TabIndex = 6;
            this.h_YScripts.Text = "Scripts";
            // 
            // btnLoadScripts
            // 
            this.btnLoadScripts.Location = new System.Drawing.Point(216, 574);
            this.btnLoadScripts.Name = "btnLoadScripts";
            this.btnLoadScripts.Size = new System.Drawing.Size(120, 23);
            this.btnLoadScripts.TabIndex = 7;
            this.btnLoadScripts.Text = "Load/Reload Scripts";
            this.btnLoadScripts.Click += new System.EventHandler(this.btnLoadScripts_Click);
            // 
            // btnEditScript
            // 
            this.btnEditScript.Location = new System.Drawing.Point(344, 574);
            this.btnEditScript.Name = "btnEditScript";
            this.btnEditScript.Size = new System.Drawing.Size(120, 23);
            this.btnEditScript.TabIndex = 6;
            this.btnEditScript.Text = "Edit Script";
            this.btnEditScript.Click += new System.EventHandler(this.btnEditScript_Click);
            // 
            // btnDelScript
            // 
            this.btnDelScript.Location = new System.Drawing.Point(472, 574);
            this.btnDelScript.Name = "btnDelScript";
            this.btnDelScript.Size = new System.Drawing.Size(120, 23);
            this.btnDelScript.TabIndex = 5;
            this.btnDelScript.Text = "Delete Script";
            this.btnDelScript.Click += new System.EventHandler(this.btnDelScript_Click);
            // 
            // lstScripts
            // 
            this.lstScripts.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstScripts.ItemHeight = 17;
            this.lstScripts.Location = new System.Drawing.Point(8, 16);
            this.lstScripts.Name = "lstScripts";
            this.lstScripts.Size = new System.Drawing.Size(792, 548);
            this.lstScripts.TabIndex = 1;
            // 
            // i_YDialogs
            // 
            this.i_YDialogs.Controls.Add(this.btnLoadDialogs);
            this.i_YDialogs.Controls.Add(this.btnEditDialog);
            this.i_YDialogs.Controls.Add(this.btnDelDialog);
            this.i_YDialogs.Controls.Add(this.lstDialogs);
            this.i_YDialogs.Location = new System.Drawing.Point(4, 22);
            this.i_YDialogs.Name = "i_YDialogs";
            this.i_YDialogs.Size = new System.Drawing.Size(808, 606);
            this.i_YDialogs.TabIndex = 5;
            this.i_YDialogs.Text = "Dialogs";
            // 
            // btnLoadDialogs
            // 
            this.btnLoadDialogs.Location = new System.Drawing.Point(216, 574);
            this.btnLoadDialogs.Name = "btnLoadDialogs";
            this.btnLoadDialogs.Size = new System.Drawing.Size(120, 23);
            this.btnLoadDialogs.TabIndex = 4;
            this.btnLoadDialogs.Text = "Load/Reload Dialogs";
            this.btnLoadDialogs.Click += new System.EventHandler(this.btnLoadDialogs_Click);
            // 
            // btnEditDialog
            // 
            this.btnEditDialog.Location = new System.Drawing.Point(344, 574);
            this.btnEditDialog.Name = "btnEditDialog";
            this.btnEditDialog.Size = new System.Drawing.Size(120, 23);
            this.btnEditDialog.TabIndex = 3;
            this.btnEditDialog.Text = "Edit Dialog";
            this.btnEditDialog.Click += new System.EventHandler(this.btnEditDialog_Click);
            // 
            // btnDelDialog
            // 
            this.btnDelDialog.Location = new System.Drawing.Point(472, 574);
            this.btnDelDialog.Name = "btnDelDialog";
            this.btnDelDialog.Size = new System.Drawing.Size(120, 23);
            this.btnDelDialog.TabIndex = 2;
            this.btnDelDialog.Text = "Delete Dialog";
            this.btnDelDialog.Click += new System.EventHandler(this.btnDelDialog_Click);
            // 
            // lstDialogs
            // 
            this.lstDialogs.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstDialogs.ItemHeight = 17;
            this.lstDialogs.Location = new System.Drawing.Point(8, 16);
            this.lstDialogs.Name = "lstDialogs";
            this.lstDialogs.Size = new System.Drawing.Size(792, 548);
            this.lstDialogs.TabIndex = 0;
            // 
            // j_YY_Worldmap
            // 
            this.j_YY_Worldmap.Controls.Add(this.btnUpdatePath);
            this.j_YY_Worldmap.Controls.Add(this.btnSetOpcode);
            this.j_YY_Worldmap.Controls.Add(this.btnDeleteOpcode);
            this.j_YY_Worldmap.Controls.Add(this.btnInsertOpcode);
            this.j_YY_Worldmap.Controls.Add(this.tPathElem);
            this.j_YY_Worldmap.Controls.Add(this.label203);
            this.j_YY_Worldmap.Controls.Add(this.w_PathCodes);
            this.j_YY_Worldmap.Controls.Add(this.label202);
            this.j_YY_Worldmap.Controls.Add(this.w_Opcodes);
            this.j_YY_Worldmap.Controls.Add(this.label201);
            this.j_YY_Worldmap.Controls.Add(this.label200);
            this.j_YY_Worldmap.Controls.Add(this.tPar4);
            this.j_YY_Worldmap.Controls.Add(this.tPar3);
            this.j_YY_Worldmap.Controls.Add(this.tPar2);
            this.j_YY_Worldmap.Controls.Add(this.wPar4);
            this.j_YY_Worldmap.Controls.Add(this.wPar3);
            this.j_YY_Worldmap.Controls.Add(this.wPar2);
            this.j_YY_Worldmap.Controls.Add(this.tPar1);
            this.j_YY_Worldmap.Controls.Add(this.wPar1);
            this.j_YY_Worldmap.Controls.Add(this.label199);
            this.j_YY_Worldmap.Controls.Add(this.btnDelPath);
            this.j_YY_Worldmap.Controls.Add(this.btnAddPath);
            this.j_YY_Worldmap.Controls.Add(this.btnSaveWorldMap);
            this.j_YY_Worldmap.Controls.Add(this.btnOpenWorldMap);
            this.j_YY_Worldmap.Controls.Add(this.label198);
            this.j_YY_Worldmap.Controls.Add(this.w_Paths);
            this.j_YY_Worldmap.Controls.Add(this.label77);
            this.j_YY_Worldmap.Location = new System.Drawing.Point(4, 22);
            this.j_YY_Worldmap.Name = "j_YY_Worldmap";
            this.j_YY_Worldmap.Size = new System.Drawing.Size(808, 606);
            this.j_YY_Worldmap.TabIndex = 11;
            this.j_YY_Worldmap.Text = "World Map";
            // 
            // btnUpdatePath
            // 
            this.btnUpdatePath.Enabled = false;
            this.btnUpdatePath.Location = new System.Drawing.Point(280, 208);
            this.btnUpdatePath.Name = "btnUpdatePath";
            this.btnUpdatePath.Size = new System.Drawing.Size(155, 23);
            this.btnUpdatePath.TabIndex = 28;
            this.btnUpdatePath.Text = "Update Path Parameters";
            this.btnUpdatePath.Click += new System.EventHandler(this.btnUpdatePath_Click);
            // 
            // btnSetOpcode
            // 
            this.btnSetOpcode.Enabled = false;
            this.btnSetOpcode.Location = new System.Drawing.Point(528, 576);
            this.btnSetOpcode.Name = "btnSetOpcode";
            this.btnSetOpcode.Size = new System.Drawing.Size(72, 23);
            this.btnSetOpcode.TabIndex = 27;
            this.btnSetOpcode.Text = "Set";
            this.btnSetOpcode.Click += new System.EventHandler(this.btnSetOpcode_Click);
            // 
            // btnDeleteOpcode
            // 
            this.btnDeleteOpcode.Enabled = false;
            this.btnDeleteOpcode.Location = new System.Drawing.Point(688, 576);
            this.btnDeleteOpcode.Name = "btnDeleteOpcode";
            this.btnDeleteOpcode.Size = new System.Drawing.Size(72, 23);
            this.btnDeleteOpcode.TabIndex = 24;
            this.btnDeleteOpcode.Text = "Delete";
            this.btnDeleteOpcode.Click += new System.EventHandler(this.btnDeleteOpcode_Click);
            // 
            // btnInsertOpcode
            // 
            this.btnInsertOpcode.Enabled = false;
            this.btnInsertOpcode.Location = new System.Drawing.Point(608, 576);
            this.btnInsertOpcode.Name = "btnInsertOpcode";
            this.btnInsertOpcode.Size = new System.Drawing.Size(72, 23);
            this.btnInsertOpcode.TabIndex = 23;
            this.btnInsertOpcode.Text = "Insert";
            this.btnInsertOpcode.Click += new System.EventHandler(this.btnInsertOpcode_Click);
            // 
            // tPathElem
            // 
            this.tPathElem.Location = new System.Drawing.Point(600, 552);
            this.tPathElem.Name = "tPathElem";
            this.tPathElem.Size = new System.Drawing.Size(100, 23);
            this.tPathElem.TabIndex = 22;
            this.tPathElem.Text = "0";
            // 
            // label203
            // 
            this.label203.Location = new System.Drawing.Point(480, 552);
            this.label203.Name = "label203";
            this.label203.Size = new System.Drawing.Size(136, 23);
            this.label203.TabIndex = 21;
            this.label203.Text = "Selected Path Element:";
            // 
            // w_PathCodes
            // 
            this.w_PathCodes.Enabled = false;
            this.w_PathCodes.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.w_PathCodes.ItemHeight = 16;
            this.w_PathCodes.Location = new System.Drawing.Point(480, 72);
            this.w_PathCodes.Name = "w_PathCodes";
            this.w_PathCodes.Size = new System.Drawing.Size(320, 452);
            this.w_PathCodes.TabIndex = 20;
            this.w_PathCodes.SelectedIndexChanged += new System.EventHandler(this.w_PathCodes_SelectedIndexChanged);
            // 
            // label202
            // 
            this.label202.Location = new System.Drawing.Point(480, 532);
            this.label202.Name = "label202";
            this.label202.Size = new System.Drawing.Size(72, 16);
            this.label202.TabIndex = 19;
            this.label202.Text = "Opcode:";
            // 
            // w_Opcodes
            // 
            this.w_Opcodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.w_Opcodes.Enabled = false;
            this.w_Opcodes.Location = new System.Drawing.Point(552, 528);
            this.w_Opcodes.Name = "w_Opcodes";
            this.w_Opcodes.Size = new System.Drawing.Size(248, 21);
            this.w_Opcodes.TabIndex = 18;
            // 
            // label201
            // 
            this.label201.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label201.Location = new System.Drawing.Point(472, 48);
            this.label201.Name = "label201";
            this.label201.Size = new System.Drawing.Size(1, 560);
            this.label201.TabIndex = 17;
            this.label201.Text = "label201";
            // 
            // label200
            // 
            this.label200.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label200.Location = new System.Drawing.Point(0, 48);
            this.label200.Name = "label200";
            this.label200.Size = new System.Drawing.Size(808, 1);
            this.label200.TabIndex = 16;
            this.label200.Text = "label200";
            // 
            // tPar4
            // 
            this.tPar4.Enabled = false;
            this.tPar4.Location = new System.Drawing.Point(352, 144);
            this.tPar4.Name = "tPar4";
            this.tPar4.Size = new System.Drawing.Size(100, 20);
            this.tPar4.TabIndex = 15;
            this.tPar4.Text = "0";
            // 
            // tPar3
            // 
            this.tPar3.Enabled = false;
            this.tPar3.Location = new System.Drawing.Point(352, 120);
            this.tPar3.Name = "tPar3";
            this.tPar3.Size = new System.Drawing.Size(100, 20);
            this.tPar3.TabIndex = 14;
            this.tPar3.Text = "0";
            // 
            // tPar2
            // 
            this.tPar2.Enabled = false;
            this.tPar2.Location = new System.Drawing.Point(352, 96);
            this.tPar2.Name = "tPar2";
            this.tPar2.Size = new System.Drawing.Size(100, 20);
            this.tPar2.TabIndex = 13;
            this.tPar2.Text = "0";
            // 
            // wPar4
            // 
            this.wPar4.Location = new System.Drawing.Point(264, 144);
            this.wPar4.Name = "wPar4";
            this.wPar4.Size = new System.Drawing.Size(88, 24);
            this.wPar4.TabIndex = 12;
            this.wPar4.Text = "PARAM4:";
            // 
            // wPar3
            // 
            this.wPar3.Location = new System.Drawing.Point(264, 120);
            this.wPar3.Name = "wPar3";
            this.wPar3.Size = new System.Drawing.Size(88, 24);
            this.wPar3.TabIndex = 11;
            this.wPar3.Text = "PARAM3:";
            // 
            // wPar2
            // 
            this.wPar2.Location = new System.Drawing.Point(264, 96);
            this.wPar2.Name = "wPar2";
            this.wPar2.Size = new System.Drawing.Size(88, 24);
            this.wPar2.TabIndex = 10;
            this.wPar2.Text = "PARAM2:";
            // 
            // tPar1
            // 
            this.tPar1.Enabled = false;
            this.tPar1.Location = new System.Drawing.Point(352, 72);
            this.tPar1.Name = "tPar1";
            this.tPar1.Size = new System.Drawing.Size(100, 20);
            this.tPar1.TabIndex = 9;
            this.tPar1.Text = "0";
            // 
            // wPar1
            // 
            this.wPar1.Location = new System.Drawing.Point(264, 72);
            this.wPar1.Name = "wPar1";
            this.wPar1.Size = new System.Drawing.Size(88, 24);
            this.wPar1.TabIndex = 8;
            this.wPar1.Text = "PARAM1:";
            // 
            // label199
            // 
            this.label199.Location = new System.Drawing.Point(480, 56);
            this.label199.Name = "label199";
            this.label199.Size = new System.Drawing.Size(144, 16);
            this.label199.TabIndex = 7;
            this.label199.Text = "Path Opcodes:";
            // 
            // btnDelPath
            // 
            this.btnDelPath.Enabled = false;
            this.btnDelPath.Location = new System.Drawing.Point(360, 176);
            this.btnDelPath.Name = "btnDelPath";
            this.btnDelPath.Size = new System.Drawing.Size(75, 23);
            this.btnDelPath.TabIndex = 6;
            this.btnDelPath.Text = "Delete Path";
            this.btnDelPath.Click += new System.EventHandler(this.btnDelPath_Click);
            // 
            // btnAddPath
            // 
            this.btnAddPath.Enabled = false;
            this.btnAddPath.Location = new System.Drawing.Point(280, 176);
            this.btnAddPath.Name = "btnAddPath";
            this.btnAddPath.Size = new System.Drawing.Size(75, 23);
            this.btnAddPath.TabIndex = 5;
            this.btnAddPath.Text = "Add Path";
            this.btnAddPath.Click += new System.EventHandler(this.btnAddPath_Click);
            // 
            // btnSaveWorldMap
            // 
            this.btnSaveWorldMap.Enabled = false;
            this.btnSaveWorldMap.Location = new System.Drawing.Point(128, 568);
            this.btnSaveWorldMap.Name = "btnSaveWorldMap";
            this.btnSaveWorldMap.Size = new System.Drawing.Size(75, 23);
            this.btnSaveWorldMap.TabIndex = 4;
            this.btnSaveWorldMap.Text = "Save";
            this.btnSaveWorldMap.Click += new System.EventHandler(this.btnSaveWorldMap_Click);
            // 
            // btnOpenWorldMap
            // 
            this.btnOpenWorldMap.Location = new System.Drawing.Point(48, 568);
            this.btnOpenWorldMap.Name = "btnOpenWorldMap";
            this.btnOpenWorldMap.Size = new System.Drawing.Size(75, 23);
            this.btnOpenWorldMap.TabIndex = 3;
            this.btnOpenWorldMap.Text = "Open...";
            this.btnOpenWorldMap.Click += new System.EventHandler(this.btnOpenWorldMap_Click);
            // 
            // label198
            // 
            this.label198.Location = new System.Drawing.Point(8, 56);
            this.label198.Name = "label198";
            this.label198.Size = new System.Drawing.Size(144, 16);
            this.label198.TabIndex = 2;
            this.label198.Text = "Paths:";
            // 
            // w_Paths
            // 
            this.w_Paths.Enabled = false;
            this.w_Paths.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.w_Paths.ItemHeight = 16;
            this.w_Paths.Location = new System.Drawing.Point(8, 72);
            this.w_Paths.Name = "w_Paths";
            this.w_Paths.Size = new System.Drawing.Size(248, 484);
            this.w_Paths.TabIndex = 1;
            this.w_Paths.SelectedIndexChanged += new System.EventHandler(this.w_Paths_SelectedIndexChanged);
            // 
            // label77
            // 
            this.label77.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label77.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label77.Location = new System.Drawing.Point(8, 16);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(800, 24);
            this.label77.TabIndex = 0;
            this.label77.Text = "World Map Paths Editor: this mode will help you edit the \"worldmap_ui_paths.bin\" " +
                "file that controls navigation on the world map";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // k_YY_DLLEd
            // 
            this.k_YY_DLLEd.Controls.Add(this.chkEnableDebug);
            this.k_YY_DLLEd.Controls.Add(this.label70);
            this.k_YY_DLLEd.Controls.Add(this.label69);
            this.k_YY_DLLEd.Controls.Add(this.label66);
            this.k_YY_DLLEd.Controls.Add(this.ChaoticEvil);
            this.k_YY_DLLEd.Controls.Add(this.ChaoticNeutral);
            this.k_YY_DLLEd.Controls.Add(this.label67);
            this.k_YY_DLLEd.Controls.Add(this.ChaoticGood);
            this.k_YY_DLLEd.Controls.Add(this.label68);
            this.k_YY_DLLEd.Controls.Add(this.label63);
            this.k_YY_DLLEd.Controls.Add(this.NeutralEvil);
            this.k_YY_DLLEd.Controls.Add(this.TrueNeutral);
            this.k_YY_DLLEd.Controls.Add(this.label64);
            this.k_YY_DLLEd.Controls.Add(this.NeutralGood);
            this.k_YY_DLLEd.Controls.Add(this.label65);
            this.k_YY_DLLEd.Controls.Add(this.label62);
            this.k_YY_DLLEd.Controls.Add(this.LawfulEvil);
            this.k_YY_DLLEd.Controls.Add(this.LawfulNeutral);
            this.k_YY_DLLEd.Controls.Add(this.label61);
            this.k_YY_DLLEd.Controls.Add(this.LawfulGood);
            this.k_YY_DLLEd.Controls.Add(this.label60);
            this.k_YY_DLLEd.Controls.Add(this.label59);
            this.k_YY_DLLEd.Controls.Add(this.PCCount);
            this.k_YY_DLLEd.Controls.Add(this.label58);
            this.k_YY_DLLEd.Controls.Add(this.label57);
            this.k_YY_DLLEd.Controls.Add(this.btnSaveDLL);
            this.k_YY_DLLEd.Controls.Add(this.btnLoadDLL);
            this.k_YY_DLLEd.Controls.Add(this.label56);
            this.k_YY_DLLEd.Location = new System.Drawing.Point(4, 22);
            this.k_YY_DLLEd.Name = "k_YY_DLLEd";
            this.k_YY_DLLEd.Size = new System.Drawing.Size(808, 606);
            this.k_YY_DLLEd.TabIndex = 10;
            this.k_YY_DLLEd.Text = "DLL Editor";
            // 
            // chkEnableDebug
            // 
            this.chkEnableDebug.Enabled = false;
            this.chkEnableDebug.Location = new System.Drawing.Point(8, 192);
            this.chkEnableDebug.Name = "chkEnableDebug";
            this.chkEnableDebug.Size = new System.Drawing.Size(304, 24);
            this.chkEnableDebug.TabIndex = 27;
            this.chkEnableDebug.Text = "Enable the debug output to console (PRINT statements)";
            // 
            // label70
            // 
            this.label70.Location = new System.Drawing.Point(264, 42);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(64, 23);
            this.label70.TabIndex = 26;
            this.label70.Text = "(max 8)";
            // 
            // label69
            // 
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Location = new System.Drawing.Point(0, 224);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(808, 1);
            this.label69.TabIndex = 25;
            this.label69.Text = "label69";
            // 
            // label66
            // 
            this.label66.Location = new System.Drawing.Point(336, 152);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(80, 23);
            this.label66.TabIndex = 24;
            this.label66.Text = "Chaotic Evil:";
            // 
            // ChaoticEvil
            // 
            this.ChaoticEvil.Enabled = false;
            this.ChaoticEvil.Location = new System.Drawing.Point(416, 152);
            this.ChaoticEvil.Name = "ChaoticEvil";
            this.ChaoticEvil.Size = new System.Drawing.Size(72, 20);
            this.ChaoticEvil.TabIndex = 23;
            this.ChaoticEvil.Text = "0";
            // 
            // ChaoticNeutral
            // 
            this.ChaoticNeutral.Enabled = false;
            this.ChaoticNeutral.Location = new System.Drawing.Point(416, 128);
            this.ChaoticNeutral.Name = "ChaoticNeutral";
            this.ChaoticNeutral.Size = new System.Drawing.Size(72, 20);
            this.ChaoticNeutral.TabIndex = 22;
            this.ChaoticNeutral.Text = "0";
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(336, 128);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(88, 23);
            this.label67.TabIndex = 21;
            this.label67.Text = "Chaotic Neutral:";
            // 
            // ChaoticGood
            // 
            this.ChaoticGood.Enabled = false;
            this.ChaoticGood.Location = new System.Drawing.Point(416, 104);
            this.ChaoticGood.Name = "ChaoticGood";
            this.ChaoticGood.Size = new System.Drawing.Size(72, 20);
            this.ChaoticGood.TabIndex = 20;
            this.ChaoticGood.Text = "0";
            // 
            // label68
            // 
            this.label68.Location = new System.Drawing.Point(336, 104);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(80, 23);
            this.label68.TabIndex = 19;
            this.label68.Text = "Chaotic Good:";
            // 
            // label63
            // 
            this.label63.Location = new System.Drawing.Point(168, 152);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(80, 23);
            this.label63.TabIndex = 18;
            this.label63.Text = "Neutral Evil:";
            // 
            // NeutralEvil
            // 
            this.NeutralEvil.Enabled = false;
            this.NeutralEvil.Location = new System.Drawing.Point(248, 152);
            this.NeutralEvil.Name = "NeutralEvil";
            this.NeutralEvil.Size = new System.Drawing.Size(72, 20);
            this.NeutralEvil.TabIndex = 17;
            this.NeutralEvil.Text = "0";
            // 
            // TrueNeutral
            // 
            this.TrueNeutral.Enabled = false;
            this.TrueNeutral.Location = new System.Drawing.Point(248, 128);
            this.TrueNeutral.Name = "TrueNeutral";
            this.TrueNeutral.Size = new System.Drawing.Size(72, 20);
            this.TrueNeutral.TabIndex = 16;
            this.TrueNeutral.Text = "0";
            // 
            // label64
            // 
            this.label64.Location = new System.Drawing.Point(168, 128);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(80, 23);
            this.label64.TabIndex = 15;
            this.label64.Text = "True Neutral:";
            // 
            // NeutralGood
            // 
            this.NeutralGood.Enabled = false;
            this.NeutralGood.Location = new System.Drawing.Point(248, 104);
            this.NeutralGood.Name = "NeutralGood";
            this.NeutralGood.Size = new System.Drawing.Size(72, 20);
            this.NeutralGood.TabIndex = 14;
            this.NeutralGood.Text = "0";
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(168, 104);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(80, 23);
            this.label65.TabIndex = 13;
            this.label65.Text = "Neutral Good:";
            // 
            // label62
            // 
            this.label62.Location = new System.Drawing.Point(8, 152);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(80, 23);
            this.label62.TabIndex = 12;
            this.label62.Text = "Lawful Evil:";
            // 
            // LawfulEvil
            // 
            this.LawfulEvil.Enabled = false;
            this.LawfulEvil.Location = new System.Drawing.Point(88, 152);
            this.LawfulEvil.Name = "LawfulEvil";
            this.LawfulEvil.Size = new System.Drawing.Size(72, 20);
            this.LawfulEvil.TabIndex = 11;
            this.LawfulEvil.Text = "0";
            // 
            // LawfulNeutral
            // 
            this.LawfulNeutral.Enabled = false;
            this.LawfulNeutral.Location = new System.Drawing.Point(88, 128);
            this.LawfulNeutral.Name = "LawfulNeutral";
            this.LawfulNeutral.Size = new System.Drawing.Size(72, 20);
            this.LawfulNeutral.TabIndex = 10;
            this.LawfulNeutral.Text = "0";
            // 
            // label61
            // 
            this.label61.Location = new System.Drawing.Point(8, 128);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(80, 23);
            this.label61.TabIndex = 9;
            this.label61.Text = "Lawful Neutral:";
            // 
            // LawfulGood
            // 
            this.LawfulGood.Enabled = false;
            this.LawfulGood.Location = new System.Drawing.Point(88, 104);
            this.LawfulGood.Name = "LawfulGood";
            this.LawfulGood.Size = new System.Drawing.Size(72, 20);
            this.LawfulGood.TabIndex = 8;
            this.LawfulGood.Text = "0";
            // 
            // label60
            // 
            this.label60.Location = new System.Drawing.Point(8, 104);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(72, 23);
            this.label60.TabIndex = 7;
            this.label60.Text = "Lawful Good:";
            // 
            // label59
            // 
            this.label59.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label59.Location = new System.Drawing.Point(8, 80);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(216, 23);
            this.label59.TabIndex = 6;
            this.label59.Text = "STARTING MAPS (per MapList.mes):";
            // 
            // PCCount
            // 
            this.PCCount.Enabled = false;
            this.PCCount.Location = new System.Drawing.Point(232, 40);
            this.PCCount.Name = "PCCount";
            this.PCCount.Size = new System.Drawing.Size(32, 20);
            this.PCCount.TabIndex = 5;
            this.PCCount.Text = "5";
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(8, 42);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(232, 23);
            this.label58.TabIndex = 4;
            this.label58.Text = "Maximum Player Characters allowed in party:";
            // 
            // label57
            // 
            this.label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label57.Location = new System.Drawing.Point(0, 32);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(808, 1);
            this.label57.TabIndex = 3;
            this.label57.Text = "label57";
            // 
            // btnSaveDLL
            // 
            this.btnSaveDLL.Location = new System.Drawing.Point(407, 240);
            this.btnSaveDLL.Name = "btnSaveDLL";
            this.btnSaveDLL.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDLL.TabIndex = 2;
            this.btnSaveDLL.Text = "Save DLL";
            this.btnSaveDLL.Click += new System.EventHandler(this.btnSaveDLL_Click);
            // 
            // btnLoadDLL
            // 
            this.btnLoadDLL.Location = new System.Drawing.Point(327, 240);
            this.btnLoadDLL.Name = "btnLoadDLL";
            this.btnLoadDLL.Size = new System.Drawing.Size(75, 23);
            this.btnLoadDLL.TabIndex = 1;
            this.btnLoadDLL.Text = "Load DLL...";
            this.btnLoadDLL.Click += new System.EventHandler(this.btnLoadDLL_Click);
            // 
            // label56
            // 
            this.label56.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label56.Location = new System.Drawing.Point(8, 8);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(536, 23);
            this.label56.TabIndex = 0;
            this.label56.Text = "CAUTION: The DLL editor will *only* work with ToEE patch 2.0 and moebius2778\'s fi" +
                "xed DLL!";
            // 
            // l_ZZConfig
            // 
            this.l_ZZConfig.Controls.Add(this.label226);
            this.l_ZZConfig.Controls.Add(this.tWBBridge);
            this.l_ZZConfig.Controls.Add(this.label225);
            this.l_ZZConfig.Controls.Add(this.chkObjIDGen);
            this.l_ZZConfig.Controls.Add(this.cfgDelEmpty);
            this.l_ZZConfig.Controls.Add(this.btnBrowse4);
            this.l_ZZConfig.Controls.Add(this.tScripts);
            this.l_ZZConfig.Controls.Add(this.label49);
            this.l_ZZConfig.Controls.Add(this.btnBrowse3);
            this.l_ZZConfig.Controls.Add(this.tDialogs);
            this.l_ZZConfig.Controls.Add(this.label48);
            this.l_ZZConfig.Controls.Add(this.btnSaveCfg);
            this.l_ZZConfig.Controls.Add(this.btnBrowse2);
            this.l_ZZConfig.Controls.Add(this.tScriptEd);
            this.l_ZZConfig.Controls.Add(this.label47);
            this.l_ZZConfig.Controls.Add(this.btnBrowse);
            this.l_ZZConfig.Controls.Add(this.tDialogEd);
            this.l_ZZConfig.Controls.Add(this.label46);
            this.l_ZZConfig.Controls.Add(this.label45);
            this.l_ZZConfig.Location = new System.Drawing.Point(4, 22);
            this.l_ZZConfig.Name = "l_ZZConfig";
            this.l_ZZConfig.Size = new System.Drawing.Size(808, 606);
            this.l_ZZConfig.TabIndex = 4;
            this.l_ZZConfig.Text = "Configuration";
            // 
            // label226
            // 
            this.label226.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label226.Location = new System.Drawing.Point(135, 217);
            this.label226.Name = "label226";
            this.label226.Size = new System.Drawing.Size(668, 37);
            this.label226.TabIndex = 18;
            this.label226.Text = "NOTE: Make sure that the ToEE-to-WB Bridge Path is set to the same folder as PATH" +
                "_INTEROP variable in the Ed.py! You must have Editor\'s Assistant Script 6.0 or n" +
                "ewer installed for this option to work.";
            // 
            // tWBBridge
            // 
            this.tWBBridge.Location = new System.Drawing.Point(138, 194);
            this.tWBBridge.Name = "tWBBridge";
            this.tWBBridge.Size = new System.Drawing.Size(664, 20);
            this.tWBBridge.TabIndex = 17;
            this.tWBBridge.Text = "C:\\";
            // 
            // label225
            // 
            this.label225.Location = new System.Drawing.Point(8, 197);
            this.label225.Name = "label225";
            this.label225.Size = new System.Drawing.Size(155, 24);
            this.label225.TabIndex = 16;
            this.label225.Text = "ToEE-to-WB Bridge Path:";
            // 
            // chkObjIDGen
            // 
            this.chkObjIDGen.Checked = true;
            this.chkObjIDGen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkObjIDGen.Location = new System.Drawing.Point(8, 285);
            this.chkObjIDGen.Name = "chkObjIDGen";
            this.chkObjIDGen.Size = new System.Drawing.Size(616, 16);
            this.chkObjIDGen.TabIndex = 15;
            this.chkObjIDGen.Text = "Enable extended backward compatibility with original ToEE mobile object files";
            // 
            // cfgDelEmpty
            // 
            this.cfgDelEmpty.Checked = true;
            this.cfgDelEmpty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cfgDelEmpty.Location = new System.Drawing.Point(8, 261);
            this.cfgDelEmpty.Name = "cfgDelEmpty";
            this.cfgDelEmpty.Size = new System.Drawing.Size(480, 24);
            this.cfgDelEmpty.TabIndex = 14;
            this.cfgDelEmpty.Text = "Don\'t save and remove empty SVB and HSD files (if they store no information)";
            // 
            // btnBrowse4
            // 
            this.btnBrowse4.Location = new System.Drawing.Point(728, 152);
            this.btnBrowse4.Name = "btnBrowse4";
            this.btnBrowse4.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse4.TabIndex = 13;
            this.btnBrowse4.Text = "Browse...";
            this.btnBrowse4.Click += new System.EventHandler(this.btnBrowse4_Click);
            // 
            // tScripts
            // 
            this.tScripts.Location = new System.Drawing.Point(120, 152);
            this.tScripts.Name = "tScripts";
            this.tScripts.Size = new System.Drawing.Size(608, 20);
            this.tScripts.TabIndex = 12;
            // 
            // label49
            // 
            this.label49.Location = new System.Drawing.Point(8, 152);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(120, 24);
            this.label49.TabIndex = 11;
            this.label49.Text = "Path to Script Files:";
            // 
            // btnBrowse3
            // 
            this.btnBrowse3.Location = new System.Drawing.Point(728, 120);
            this.btnBrowse3.Name = "btnBrowse3";
            this.btnBrowse3.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse3.TabIndex = 10;
            this.btnBrowse3.Text = "Browse...";
            this.btnBrowse3.Click += new System.EventHandler(this.btnBrowse3_Click);
            // 
            // tDialogs
            // 
            this.tDialogs.Location = new System.Drawing.Point(120, 120);
            this.tDialogs.Name = "tDialogs";
            this.tDialogs.Size = new System.Drawing.Size(608, 20);
            this.tDialogs.TabIndex = 9;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(8, 120);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(120, 24);
            this.label48.TabIndex = 8;
            this.label48.Text = "Path to Dialog Files:";
            // 
            // btnSaveCfg
            // 
            this.btnSaveCfg.Location = new System.Drawing.Point(368, 317);
            this.btnSaveCfg.Name = "btnSaveCfg";
            this.btnSaveCfg.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCfg.TabIndex = 7;
            this.btnSaveCfg.Text = "Save";
            this.btnSaveCfg.Click += new System.EventHandler(this.btnSaveCfg_Click);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(728, 80);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse2.TabIndex = 6;
            this.btnBrowse2.Text = "Browse...";
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // tScriptEd
            // 
            this.tScriptEd.Location = new System.Drawing.Point(120, 80);
            this.tScriptEd.Name = "tScriptEd";
            this.tScriptEd.Size = new System.Drawing.Size(608, 20);
            this.tScriptEd.TabIndex = 5;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(8, 80);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(120, 24);
            this.label47.TabIndex = 4;
            this.label47.Text = "External Script Editor:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(728, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // tDialogEd
            // 
            this.tDialogEd.Location = new System.Drawing.Point(120, 48);
            this.tDialogEd.Name = "tDialogEd";
            this.tDialogEd.Size = new System.Drawing.Size(608, 20);
            this.tDialogEd.TabIndex = 2;
            // 
            // label46
            // 
            this.label46.Location = new System.Drawing.Point(8, 48);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(120, 24);
            this.label46.TabIndex = 1;
            this.label46.Text = "External Dialog Editor:";
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label45.Location = new System.Drawing.Point(188, 8);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(432, 40);
            this.label45.TabIndex = 0;
            this.label45.Text = "Temple of Elemental Evil World Builder Configuration";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem8,
            this.menuItem13,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            this.menuItem1.Text = "File";
            this.menuItem1.Visible = false;
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem10});
            this.menuItem8.Text = "Debug";
            this.menuItem8.Visible = false;
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.Text = "DEBUG: Show bitmap";
            this.menuItem9.Click += new System.EventHandler(this.debug_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "DEBUG: Sectors";
            this.menuItem10.Click += new System.EventHandler(this.debug2_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem14,
            this.menuItem15,
            this.menuItem17,
            this.menuItem16,
            this.mnuAddins});
            this.menuItem13.Text = "Tools";
            this.menuItem13.Visible = false;
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 0;
            this.menuItem14.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItem14.Text = "Sector Coordinate Lookup";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.menuItem15.Text = "Visual Sector Analyzer/Painter";
            this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 2;
            this.menuItem17.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItem17.Text = "Path Node Generator";
            this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 3;
            this.menuItem16.Text = "-";
            // 
            // mnuAddins
            // 
            this.mnuAddins.Index = 4;
            this.mnuAddins.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem18});
            this.mnuAddins.Text = "Add-ins";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 0;
            this.menuItem18.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem7,
            this.menuItem11,
            this.menuItem12,
            this.menuItem5,
            this.menuItem6});
            this.menuItem3.Text = "Help";
            this.menuItem3.Visible = false;
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Special inventory slots for mobiles";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "Creating merchants";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "Creating merchants with respawning inventories";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 3;
            this.menuItem12.Text = "Modifying resting options for maps";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 4;
            this.menuItem5.Text = "-";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 5;
            this.menuItem6.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItem6.Text = "About ToEE World Builder...";
            this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // OFG1
            // 
            this.OFG1.Filter = "ToEE Map Combined Image (*.jpg, *.bmp)|*.jpg; *.bmp";
            // 
            // OFG
            // 
            this.OFG.Filter = "ToEE Map JPEG Constituents (*.jpg)|*.jpg";
            // 
            // tmrSplash
            // 
            this.tmrSplash.Interval = 1;
            this.tmrSplash.Tick += new System.EventHandler(this.tmrSplash_Tick);
            // 
            // cfgBrowser
            // 
            this.cfgBrowser.Filter = "Editor executable (*.exe)|*.exe";
            // 
            // cfgDialogs
            // 
            this.cfgDialogs.Filter = "Dialogs (*.dlg)|*.dlg";
            // 
            // cfgScripts
            // 
            this.cfgScripts.Filter = "Scripts (*.py)|*.py";
            // 
            // WM_SysMsg
            // 
            this.WM_SysMsg.Enabled = true;
            this.WM_SysMsg.Interval = 1;
            this.WM_SysMsg.Tick += new System.EventHandler(this.WM_SysMsg_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.addinsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sectorLightEditorToolStripMenuItem,
            this.sectorCoordinateLookupToolStripMenuItem,
            this.visualSectorAnalyzerPainterToolStripMenuItem,
            this.toolStripMenuItem3,
            this.dayNightTransitionsEditorToolStripMenuItem,
            this.pathNodeGeneratorToolStripMenuItem,
            this.toolStripMenuItem1,
            this.prototypeSearchToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // sectorLightEditorToolStripMenuItem
            // 
            this.sectorLightEditorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sectorLightEditorToolStripMenuItem.Image")));
            this.sectorLightEditorToolStripMenuItem.Name = "sectorLightEditorToolStripMenuItem";
            this.sectorLightEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.sectorLightEditorToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.sectorLightEditorToolStripMenuItem.Text = "Sector Light Editor";
            this.sectorLightEditorToolStripMenuItem.Click += new System.EventHandler(this.sectorLightEditorToolStripMenuItem_Click);
            // 
            // sectorCoordinateLookupToolStripMenuItem
            // 
            this.sectorCoordinateLookupToolStripMenuItem.Name = "sectorCoordinateLookupToolStripMenuItem";
            this.sectorCoordinateLookupToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.sectorCoordinateLookupToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.sectorCoordinateLookupToolStripMenuItem.Text = "Sector Coordinate Lookup";
            this.sectorCoordinateLookupToolStripMenuItem.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // visualSectorAnalyzerPainterToolStripMenuItem
            // 
            this.visualSectorAnalyzerPainterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visualSectorAnalyzerPainterToolStripMenuItem.Image")));
            this.visualSectorAnalyzerPainterToolStripMenuItem.Name = "visualSectorAnalyzerPainterToolStripMenuItem";
            this.visualSectorAnalyzerPainterToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.visualSectorAnalyzerPainterToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.visualSectorAnalyzerPainterToolStripMenuItem.Text = "Visual Sector Analyzer/Painter";
            this.visualSectorAnalyzerPainterToolStripMenuItem.Click += new System.EventHandler(this.menuItem15_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(269, 6);
            // 
            // dayNightTransitionsEditorToolStripMenuItem
            // 
            this.dayNightTransitionsEditorToolStripMenuItem.Name = "dayNightTransitionsEditorToolStripMenuItem";
            this.dayNightTransitionsEditorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dayNightTransitionsEditorToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.dayNightTransitionsEditorToolStripMenuItem.Text = "Day/Night Transitions Editor";
            this.dayNightTransitionsEditorToolStripMenuItem.Click += new System.EventHandler(this.dayNightTransitionsEditorToolStripMenuItem_Click);
            // 
            // pathNodeGeneratorToolStripMenuItem
            // 
            this.pathNodeGeneratorToolStripMenuItem.Name = "pathNodeGeneratorToolStripMenuItem";
            this.pathNodeGeneratorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pathNodeGeneratorToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.pathNodeGeneratorToolStripMenuItem.Text = "Path Node Generator";
            this.pathNodeGeneratorToolStripMenuItem.Click += new System.EventHandler(this.menuItem17_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(269, 6);
            // 
            // prototypeSearchToolStripMenuItem
            // 
            this.prototypeSearchToolStripMenuItem.Name = "prototypeSearchToolStripMenuItem";
            this.prototypeSearchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.prototypeSearchToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.prototypeSearchToolStripMenuItem.Text = "Prototype Search";
            this.prototypeSearchToolStripMenuItem.Click += new System.EventHandler(this.prototypeSearchToolStripMenuItem_Click);
            // 
            // addinsToolStripMenuItem
            // 
            this.addinsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mobileObjectViewerToolStripMenuItem,
            this.sectorSortUtilityToolStripMenuItem,
            this.scriptOverrideToolToolStripMenuItem,
            this.toolStripMenuItem4,
            this.whatAreTheseAddinsForToolStripMenuItem});
            this.addinsToolStripMenuItem.Name = "addinsToolStripMenuItem";
            this.addinsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.addinsToolStripMenuItem.Text = "Addins";
            // 
            // mobileObjectViewerToolStripMenuItem
            // 
            this.mobileObjectViewerToolStripMenuItem.Name = "mobileObjectViewerToolStripMenuItem";
            this.mobileObjectViewerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.mobileObjectViewerToolStripMenuItem.Text = "Mobile Object Viewer";
            this.mobileObjectViewerToolStripMenuItem.Click += new System.EventHandler(this.mobileObjectViewerToolStripMenuItem_Click);
            // 
            // sectorSortUtilityToolStripMenuItem
            // 
            this.sectorSortUtilityToolStripMenuItem.Name = "sectorSortUtilityToolStripMenuItem";
            this.sectorSortUtilityToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.sectorSortUtilityToolStripMenuItem.Text = "Sector Sort Tool";
            this.sectorSortUtilityToolStripMenuItem.Click += new System.EventHandler(this.sectorSortUtilityToolStripMenuItem_Click);
            // 
            // scriptOverrideToolToolStripMenuItem
            // 
            this.scriptOverrideToolToolStripMenuItem.Name = "scriptOverrideToolToolStripMenuItem";
            this.scriptOverrideToolToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.scriptOverrideToolToolStripMenuItem.Text = "Script Override Tool";
            this.scriptOverrideToolToolStripMenuItem.Click += new System.EventHandler(this.scriptOverrideToolToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(210, 6);
            // 
            // whatAreTheseAddinsForToolStripMenuItem
            // 
            this.whatAreTheseAddinsForToolStripMenuItem.Name = "whatAreTheseAddinsForToolStripMenuItem";
            this.whatAreTheseAddinsForToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.whatAreTheseAddinsForToolStripMenuItem.Text = "What are these addins for?";
            this.whatAreTheseAddinsForToolStripMenuItem.Click += new System.EventHandler(this.whatAreTheseAddinsForToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.specialInventorySlotsForMobilesToolStripMenuItem,
            this.creatingMerchantsToolStripMenuItem,
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem,
            this.modifyingRestingOptionsForMapsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.commonWaypointAnimationIDsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // specialInventorySlotsForMobilesToolStripMenuItem
            // 
            this.specialInventorySlotsForMobilesToolStripMenuItem.Name = "specialInventorySlotsForMobilesToolStripMenuItem";
            this.specialInventorySlotsForMobilesToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.specialInventorySlotsForMobilesToolStripMenuItem.Text = "Special Inventory Slots for Mobiles";
            this.specialInventorySlotsForMobilesToolStripMenuItem.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // creatingMerchantsToolStripMenuItem
            // 
            this.creatingMerchantsToolStripMenuItem.Name = "creatingMerchantsToolStripMenuItem";
            this.creatingMerchantsToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.creatingMerchantsToolStripMenuItem.Text = "Creating Merchants";
            this.creatingMerchantsToolStripMenuItem.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // creatingMerchantsWithRespawningInventoriesToolStripMenuItem
            // 
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem.Name = "creatingMerchantsWithRespawningInventoriesToolStripMenuItem";
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem.Text = "Creating Merchants with Respawning Inventories";
            this.creatingMerchantsWithRespawningInventoriesToolStripMenuItem.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // modifyingRestingOptionsForMapsToolStripMenuItem
            // 
            this.modifyingRestingOptionsForMapsToolStripMenuItem.Name = "modifyingRestingOptionsForMapsToolStripMenuItem";
            this.modifyingRestingOptionsForMapsToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.modifyingRestingOptionsForMapsToolStripMenuItem.Text = "Modifying Resting Options for Maps";
            this.modifyingRestingOptionsForMapsToolStripMenuItem.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(329, 6);
            // 
            // commonWaypointAnimationIDsToolStripMenuItem
            // 
            this.commonWaypointAnimationIDsToolStripMenuItem.Name = "commonWaypointAnimationIDsToolStripMenuItem";
            this.commonWaypointAnimationIDsToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.commonWaypointAnimationIDsToolStripMenuItem.Text = "Common Waypoint Animation IDs";
            this.commonWaypointAnimationIDsToolStripMenuItem.Click += new System.EventHandler(this.commonWaypointAnimationIDsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(329, 6);
            // 
            // aboutToEEWorldBuilderNET2ToolStripMenuItem
            // 
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem.Name = "aboutToEEWorldBuilderNET2ToolStripMenuItem";
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem.Size = new System.Drawing.Size(332, 22);
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem.Text = "About ToEE World Builder .NET2...";
            this.aboutToEEWorldBuilderNET2ToolStripMenuItem.Click += new System.EventHandler(this.menuItem6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(385, 32);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 23);
            this.button5.TabIndex = 60;
            this.button5.Text = "Split (BMP->BMP)";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(385, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 23);
            this.button6.TabIndex = 61;
            this.button6.Text = "Recombine (JPG->BMP)";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(515, 120);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(172, 23);
            this.button7.TabIndex = 62;
            this.button7.Text = "Recombine Partially (JPG->BMP)";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(424, 216);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(134, 23);
            this.button8.TabIndex = 63;
            this.button8.Text = "Split (BMP)";
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(424, 248);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(134, 23);
            this.button9.TabIndex = 64;
            this.button9.Text = "Recombine (JPG->BMP)";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Worlded
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(818, 642);
            this.Controls.Add(this.GenericTab);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Menu = this.mnuMain;
            this.Name = "Worlded";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temple of Elemental Evil World Builder .NET2";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Worlded_Closing);
            this.Load += new System.EventHandler(this.Worlded_Load);
            this.GenericTab.ResumeLayout(false);
            this.aa_Mobiles.ResumeLayout(false);
            this.aa_Mobiles.PerformLayout();
            this.ObjSpeedGroup.ResumeLayout(false);
            this.ObjSpeedGroup.PerformLayout();
            this.ObjHPGroup.ResumeLayout(false);
            this.ObjHPGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LocationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LocationX)).EndInit();
            this.tabProps.ResumeLayout(false);
            this.a.ResumeLayout(false);
            this.b.ResumeLayout(false);
            this.b.PerformLayout();
            this.c.ResumeLayout(false);
            this.c.PerformLayout();
            this.d.ResumeLayout(false);
            this.d.PerformLayout();
            this.g.ResumeLayout(false);
            this.g.PerformLayout();
            this.d2.ResumeLayout(false);
            this.d2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.d1.ResumeLayout(false);
            this.d1.PerformLayout();
            this.e.ResumeLayout(false);
            this.e.PerformLayout();
            this.f.ResumeLayout(false);
            this.f.PerformLayout();
            this.h.ResumeLayout(false);
            this.i.ResumeLayout(false);
            this.j.ResumeLayout(false);
            this.k.ResumeLayout(false);
            this.k.PerformLayout();
            this.l.ResumeLayout(false);
            this.l.PerformLayout();
            this.m.ResumeLayout(false);
            this.m.PerformLayout();
            this.n.ResumeLayout(false);
            this.n.PerformLayout();
            this.bb_Sectors.ResumeLayout(false);
            this.tabSectorEd.ResumeLayout(false);
            this.a_Tiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_UR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_ML)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_MM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_MR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HGT_LR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToTX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromTX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TX)).EndInit();
            this.b_Lights.ResumeLayout(false);
            this.b_Lights.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Light11_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Light10_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LightID)).EndInit();
            this.c_Objects.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cc_SMJumpPts.ResumeLayout(false);
            this.cc_SMJumpPts.PerformLayout();
            this.dd_SMapProps.ResumeLayout(false);
            this.GroupAreaCleaner.ResumeLayout(false);
            this.GlobalLitGroup.ResumeLayout(false);
            this.GlobalLitGroup.PerformLayout();
            this.MapPrpGroup.ResumeLayout(false);
            this.MapPrpGroup.PerformLayout();
            this.ee_N2DMaps.ResumeLayout(false);
            this.ee_N2DMaps.PerformLayout();
            this.ff_YT_Prototypes.ResumeLayout(false);
            this.ff_YT_Prototypes.PerformLayout();
            this.gg_YX_Descriptions.ResumeLayout(false);
            this.gg_YX_Descriptions.PerformLayout();
            this.h_YScripts.ResumeLayout(false);
            this.i_YDialogs.ResumeLayout(false);
            this.j_YY_Worldmap.ResumeLayout(false);
            this.j_YY_Worldmap.PerformLayout();
            this.k_YY_DLLEd.ResumeLayout(false);
            this.k_YY_DLLEd.PerformLayout();
            this.l_ZZConfig.ResumeLayout(false);
            this.l_ZZConfig.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
	    {
            Application.EnableVisualStyles();
			Application.Run(new Worlded());
		}

		#region Debug stuff

		private void debug_Click(object sender, System.EventArgs e)
		{
			// Set the message: SM_TEST_MSG
			SysMsg.SM_TEST_MSG_QUEUE.Add("test 1");
			SysMsg.SM_TEST_MSG_QUEUE.Add("test 2");
			SysMsg.SM_TEST_MSG = true;
		}

		private void debug2_Click(object sender, System.EventArgs e)
		{
			StreamReader sr = new StreamReader("in.feat");
			StreamWriter sw = new StreamWriter("out.feat");
			string st = "";

			while ((st = sr.ReadLine()) != null)
			{
				sw.Write(String.Format("ar.Add(\"{0}\");", st.Split('\t')[1].Trim()));
			}

			sr.Close();
			sw.Close();
		}

		#endregion

		#region Generic Interface

		private int SPLASH_STATE = 0;
		private ArrayList Addins = new ArrayList();

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?",
				"Please confirm quitting",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.Yes)
				Application.Exit();
		}

		private void Worlded_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?",
				"Please confirm quitting",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				e.Cancel = true;
		}

		private Hashtable Proto_Types = new Hashtable();
		//private Hashtable Properties = new Hashtable();
		private Hashtable LongDescs = new Hashtable();
		private Hashtable Descriptions = new Hashtable();

		ArrayList protos = new ArrayList();
		ArrayList desc = new ArrayList();
		ArrayList ldesc = new ArrayList();

		private void Worlded_Load(object sender, System.EventArgs e)
		{
			// If there's no SARC file, recreate it
			if (!File.Exists("ToEE World Builder.sar"))
			{
				StreamWriter sw = new StreamWriter("ToEE World Builder.sar");
				sw.WriteLine("// FOR THE SAKE OF YOUR OWN SANITY, DO **NOT** MODIFY THIS FILE!!!");
				sw.WriteLine("// MODIFYING THIS FILE CAN CAUSE FATAL ERRORS WHILE SAVING BACK MOBILE OBJECTS !");
				sw.WriteLine("");
				sw.WriteLine("SARC=5729");
				sw.WriteLine("[END INTERNAL PATCH]");
				sw.Close();
			}

			// Load worldmap path editor opcode info
			if (File.Exists("ToEE World Builder.opc"))
			{
				StreamReader sr = new StreamReader("ToEE World Builder.opc");
				string str = "";

				for (int i=0; i<6; i++)
					sr.ReadLine();

				wPar1.Text = sr.ReadLine();
				wPar2.Text = sr.ReadLine();
				wPar3.Text = sr.ReadLine();
				wPar4.Text = sr.ReadLine();

				while ((str=sr.ReadLine())!="[END INTERNAL PATCH]")
					w_Opcodes.Items.Add(str);

				sr.Close();
			}

			// Load configuration
			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\ToEE World Builder.ini"))
			{
				StreamReader cfg = new StreamReader(new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\ToEE World Builder.ini", FileMode.Open));
				tDialogEd.Text = cfg.ReadLine();
				tScriptEd.Text = cfg.ReadLine();
				tDialogs.Text = cfg.ReadLine();
				tScripts.Text = cfg.ReadLine();
				cfgDelEmpty.Checked = bool.Parse(cfg.ReadLine());
				chkObjIDGen.Checked = bool.Parse(cfg.ReadLine());
                try
                {
                    tWBBridge.Text = cfg.ReadLine();
                    if (tWBBridge.Text == "")
                    {
                        MessageBox.Show("Your configuration file may be outdated. Please check your WB configuration (ENSURE THAT THE PATH TO TOEE-TO-WB BRIDGE IS NOT EMPTY!) and save it again.", "Obsolete configuration format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tWBBridge.Text = "C:\\";
                        Helper.InteropPath = "C:\\wb200_il.lri";
                    }
                    if (tWBBridge.Text[tWBBridge.Text.Length-1] == '\\')
                        Helper.InteropPath = tWBBridge.Text + "wb200_il.lri";
                    else
                        Helper.InteropPath = tWBBridge.Text + "\\wb200_il.lri";
                }
                catch (Exception)
                {
                    MessageBox.Show("Your configuration file is outdated. Please check your WB configuration and save it again.", "Obsolete configuration format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tWBBridge.Text = "C:\\";
                    Helper.InteropPath = "C:\\wb200_il.lri";
                }
                if (File.Exists(Helper.InteropPath))
                    File.Delete(Helper.InteropPath);

				cfg.Close();
			}

			// Memory setup: initialize runtime-critical arrays
			Helper.HSD_Tiles = Helper.HSD_NewArray();

			// Display splash screen and enter worlded loading routine
			tmrSplash.Enabled = true;
		}

		Splash s = new Splash();	
		private void tmrSplash_Tick(object sender, System.EventArgs e)
		{
			if (SPLASH_STATE == 0)
			{
				tmrSplash.Interval = 50;
				SPLASH_STATE++;
				s.Show();
				return;
			}

			if (SPLASH_STATE == 1)
				tmrSplash.Enabled = false;

            // v1.7.5c: Disabled the old light editor. The code remains for compatibility only.
            tabSectorEd.TabPages[1].Dispose();

			pNpcInvSlot.Enabled = false;
			// Check for PROTOS.TAB, DESCRIPTION.MES, and LONG_DESCRIPTION.MES
			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\protos.tab"))
			{
				MessageBox.Show("ToEE World Editor requires a PROTOS.TAB file!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\description.mes"))
			{
				MessageBox.Show("ToEE World Editor requires a DESCRIPTION.MES file!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\long_description.mes"))
			{
				MessageBox.Show("ToEE World Editor requires a LONG_DESCRIPTION.MES file!",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			// Initialize the Mobile Properties hash table
			// for (int i=0; i<512; i++)
			//	Properties.Add(i, null);

			// Load up add-ins
			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\ToEE World Builder.aim"))
			{
				StreamReader sr = new StreamReader("ToEE World Builder.aim");
				string st = "";
				while ((st=sr.ReadLine())!="[END ADDIN LIST]")
				{
					if (st.Trim()=="")
						continue;
					if (st.Substring(0,1)=="/")
						continue;

					string[] aim_data = st.Split('=');
					mnuAddins.MenuItems.Add(aim_data[0], new EventHandler(CallAddin));
				}
				sr.Close();
			}

			// Load PROTOS, DESCRIPTION, and LONG_DESCRIPTION files
			StreamReader f_protos = new StreamReader("protos.tab");
			StreamReader f_desc = new StreamReader("description.mes");
			StreamReader f_ldesc = new StreamReader("long_description.mes");

			string str = "";

			while ((str = f_protos.ReadLine()) != null)
				protos.Add(str);

			while ((str = f_desc.ReadLine()) != null)
			{
				desc.Add(str);
				if (str.Trim() == "")
					continue;
				if (str.Substring(0,1) != "{")
					continue;

				string[] __DESC = str.Split('{','}');
				try
				{
					Descriptions.Add(__DESC[1], __DESC[3]);
				}
				catch (Exception)
				{
					MessageBox.Show("Warning: duplicate description detected in DESCRIPTION.MES (entry #"+__DESC[1]+")\n\nIt is recommended that you fix this error before proceeding.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}

				// Adding to the description editor
				lstDesc.Items.Add(__DESC[1]+": "+__DESC[3]);
			}

			while ((str = f_ldesc.ReadLine()) != null)
			{
				ldesc.Add(str);
				if (str.Trim() == "")
					continue;
				if (str.Substring(0,1) != "{")
					continue;

				string[] __LDESC = str.Split('{','}');
				try
				{
					LongDescs.Add(__LDESC[1], __LDESC[3]);
				}
				catch (Exception)
				{
					MessageBox.Show("Warning: duplicate long description detected in LONG_DESCRIPTION.MES (entry #"+__LDESC[1]+")\n\nIt is recommended that you fix this error before proceeding.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			f_ldesc.Close();
			f_desc.Close();
			f_protos.Close();

			string[] proto;
			foreach(string st in protos)
			{
				proto = st.Split('\t');
				string ID = proto[0].Trim();
				string DESC = "<No description>";

				if (!MobType.Items.Contains(proto[1]))
					MobType.Items.Add(proto[1]);

				if (Descriptions[ID] != null) // && Descriptions[ID].ToString().Trim() != "")
					DESC = Descriptions[ID].ToString();
				//else
				//	DESC = "(Unnamed)";

				string TARGET_LINE = DESC+" -> #"+ID;
				
				Prototype.Items.Add(TARGET_LINE);

				ChestInvProtos.Items.Add(TARGET_LINE);
				NpcInvProtos.Items.Add(TARGET_LINE);
				CurProto.Items.Add(TARGET_LINE);
				try
				{
					Proto_Types.Add(TARGET_LINE, proto[1].Trim());
					Helper.Proto_By_ID.Add(ID, DESC);
				}
				catch (Exception)
				{
					MessageBox.Show("Warning: duplicate prototype detected in PROTOS.TAB (entry #"+ID+")\n\nIt is recommended that you fix this error before proceeding.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			SetInterfaceState(false);
			s.Dispose();
			
			// Set the default data for certain boxes
			cmbTileSound.SelectedIndex = 2;
		}

		private void CallAddin(object sender, System.EventArgs e)
		{
			string[] aim_nametag = sender.ToString().Split(':');
			string aim_name = aim_nametag[aim_nametag.GetUpperBound(0)].Trim();
			string proc_to_exec = "";

			StreamReader sr = new StreamReader("ToEE World Builder.aim");
			string st = "";
			while ((st=sr.ReadLine())!="[END ADDIN LIST]")
			{
				if (st.Trim()=="")
					continue;
				if (st.Substring(0,1)=="/")
					continue;

				string[] aim_data = st.Split('=');
				if (aim_data[0] == aim_name)
					proc_to_exec = aim_data[1];
			}
			sr.Close();

			if (proc_to_exec != "" && File.Exists(Path.GetDirectoryName(Application.ExecutablePath)+"\\Addins\\"+proc_to_exec))
				System.Diagnostics.Process.Start(Path.GetDirectoryName(Application.ExecutablePath)+"\\Addins\\"+proc_to_exec);
		}

		#endregion

		#region MOB Editor
		// + Begin MOB Fields +
		private string MOB_GUID = "";
		private byte[] MOB_GUID_BYTES = new byte[24];
		private string MOB_BITMAP = "";
		private string MOB_OBJFLAGS_BITMAP = "";
		private byte[] MOB_PROP_152 = new byte[24]; // Used to store item parent GUID
		private byte[] MOB_PROP_SUBINV = new byte[24]; // Used to store NPC substitute inventory object GUID
		private bool INDIRECT = false;
		private bool INDIRECT_CALLBACK = false;
		private ArrayList CHEST_INV = new ArrayList();
		private UInt32 CONTAINER_INV_LIST_IDX = 0;
		private ArrayList NPC_INV = new ArrayList();
		private UInt32 NPC_INV_LIST_IDX = 0;
		private ArrayList NPC_WAYPOINTS = new ArrayList(); // v1.3: waypoint sys
		private UInt32 SAR_POS = 0; // SARC index for containers
		private UInt32 SAR_POS_NPC = 0; // SARC index for NPCs
		private UInt32 SAR_POS_WAY = 0; // SARC index for waypoints
		private UInt32 SAR_POS_STN = 0; // SARC index for standpoints
		private UInt32 SAR_POS_MDX = 0; // SARC index for money
        private UInt32 SAR_POS_FCN = 0; // SARC index for factions
        private UInt32 SAR_POS_ABL = 0; // SARC index for abilities
        private ArrayList IMPORTED_ENTRY30 = new ArrayList();
        private ArrayList IMPORTED_ENTRY40 = new ArrayList();
        private ArrayList IMPORTED_ENTRY41 = new ArrayList();
        private ArrayList IMPORTED_ENTRY42 = new ArrayList();
		private ArrayList IMPORTED_ENTRY73 = new ArrayList();
        private UInt32 IMPORTED_ENTRY293 = 0;
		private bool LOADING = false;
		// - End MOB Fields -

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to create a new object?",
				"Please confirm operation",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				return;

			SetInterfaceState(true);

			Helper.MOB_GenerateGUID(out MOB_GUID, out MOB_GUID_BYTES);

			MobileName.Text = MOB_GUID;
			Prototype.SelectedIndex = 0;
			MOB_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(MobType.Text));
			MOB_BITMAP = Helper.MOB_SetProperty(MOB_BITMAP, 0);
			MOB_OBJFLAGS_BITMAP = Helper.MOB_CreateBitmap(1);
			MOB_PROP_152 = new byte[24];
			MOB_PROP_SUBINV = new byte[24];
            IMPORTED_ENTRY30 = new ArrayList();            
            IMPORTED_ENTRY40 = new ArrayList();
            IMPORTED_ENTRY41 = new ArrayList();
            IMPORTED_ENTRY42 = new ArrayList();
			IMPORTED_ENTRY73 = new ArrayList();
            IMPORTED_ENTRY293 = 0;
			CHEST_INV = new ArrayList();
			NPC_INV = new ArrayList();
			NPC_WAYPOINTS = new ArrayList();
			SAR_POS = 0;
			SAR_POS_NPC = 0;
			SAR_POS_WAY = 0;
			SAR_POS_STN = 0;
			SAR_POS_MDX = 0;
            SAR_POS_FCN = 0;
            SAR_POS_ABL = 0;

			SwitchOffCheckboxes();
		}

        private void btnNewMOBAdvanced_Click(object sender, EventArgs e)
        {
            // advanced: create from a GUID
            // (TODO)
        }

		private void Prototype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			INDIRECT = true;

			try
			{
				MobType.SelectedIndex = MobType.Items.IndexOf(Proto_Types[Prototype.Items[Prototype.SelectedIndex]].ToString());
			}
			catch (Exception)
			{
				MessageBox.Show("Unexpected Error 007: An error encountered attempting to set the mobile type. This means that PROTOS.TAB and/or DESCRIPTION.MES was changed but the files were not reparsed correctly. You need to restart ToEE World Builder in order to restore correct functionality. We are sorry for the inconvenience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (INDIRECT_CALLBACK)
			{
				INDIRECT_CALLBACK = false;
				return;
			}

			// RESET: reset the MOB property bitmap here
			MOB_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(MobType.Text));
			MOB_BITMAP = Helper.MOB_SetProperty(MOB_BITMAP, 0);
			MOB_OBJFLAGS_BITMAP = Helper.MOB_CreateBitmap(1);
			MOB_PROP_152 = new byte[24];
			MOB_PROP_SUBINV = new byte[24];
			CHEST_INV = new ArrayList();
			NPC_INV = new ArrayList();
			NPC_WAYPOINTS = new ArrayList();

			SwitchOffCheckboxes();
		}

		private void MobType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (INDIRECT)
			{
				INDIRECT = false;
				return;
			}

			INDIRECT_CALLBACK = true;
			MessageBox.Show("Modifying the object type directly is not allowed!",
				"Error",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);

			Prototype_SelectedIndexChanged(sender, e);
		}

		private void btnOpenMob_Click(object sender, System.EventArgs e)
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));

			OpenMOB o = new OpenMOB();
			if (o.ShowDialog() == DialogResult.OK)
			{
				// Switch off checkboxes
				SwitchOffCheckboxes();

				SAR_POS = 0;
				SAR_POS_NPC = 0;
				SAR_POS_WAY = 0;
				SAR_POS_STN = 0;
				SAR_POS_MDX = 0;
                SAR_POS_FCN = 0;
                SAR_POS_ABL = 0;
                IMPORTED_ENTRY30 = new ArrayList();
                IMPORTED_ENTRY40 = new ArrayList();
                IMPORTED_ENTRY41 = new ArrayList();
				IMPORTED_ENTRY42 = new ArrayList();
				IMPORTED_ENTRY73 = new ArrayList();
                IMPORTED_ENTRY293 = 0;

				UInt32 data;
				UInt16 data_16;

				FileStream mob = new FileStream("Mobiles\\"+o.FileToOpen+".mob", FileMode.Open);
				BinaryReader r_mob = new BinaryReader(mob);

				MobileName.Text = o.FileToOpen;

				data = r_mob.ReadUInt32();
				if (data != 0x00000077)
				{
					MessageBox.Show("Object file format version mismatch!",
						"Error",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					r_mob.Close();
					mob.Close();
					return;
				}
				
				data = r_mob.ReadUInt32(); // Not used, at least for now
				data = r_mob.ReadUInt32(); // Not used, at least for now

				data = r_mob.ReadUInt32(); // Proto ID
				for (int i=0; i<Prototype.Items.Count; i++)
				{
					if (Prototype.Items[i].ToString().IndexOf("#"+data.ToString()) == Prototype.Items[i].ToString().Length - data.ToString().Length - 1) //!= -1
					{
						Prototype.SelectedIndex = i;
						break;
					}
				}

				data = r_mob.ReadUInt32(); // Not used, at least for now
				data = r_mob.ReadUInt32(); // Not used, at least for now
				data = r_mob.ReadUInt32(); // Not used, at least for now

				MOB_GUID_BYTES = r_mob.ReadBytes(24); // GUID

				UInt32 MOB_TYPE_F;
				MOB_TYPE_F = r_mob.ReadUInt32(); // Type. Ignored due to being auto-set.
				data_16 = r_mob.ReadUInt16(); // Number of properties. Ignored due to being auto-detected.

				// Read the bitmap
				// int BitmapSize = Helper.MOB_GetNumberofBitmapBlocks(Helper.GEN_GetMobileType(MobType.Text));
				int BitmapSize = Helper.MOB_GetNumberofBitmapBlocks((MobTypes)MOB_TYPE_F);
				int BitmapNoBytes = BitmapSize * 4;
				byte[] BitmapBytes = new byte[BitmapNoBytes];
				BitmapBytes = r_mob.ReadBytes(BitmapNoBytes);
				MOB_BITMAP = Helper.MOB_BytesToBitmap(BitmapBytes);

				SetInterfaceState(true);

				// Load properties
				try
				{
					LOADING = true;
					LoadMOB_Properties(r_mob, "Mobiles\\"+o.FileToOpen+".mob");
					LOADING = false;
				}
				catch (Exception)
				{
					// Show an error message and unload the object in case
					// there was a critical error parsing the properties.
					MessageBox.Show("A critical error occurred trying to load this mobile object file. It means that this file contains properties that are not yet supported in ToEE World Builder (and, therefore, the file can't be loaded correctly). In order to avoid data corruption the loading of this mobile object has been canceled.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					LOADING = false;
					MobileName.Text = "<NO OBJECT LOADED>";
					SwitchOffCheckboxes();
					SetInterfaceState(false);
				}

				r_mob.Close();
				mob.Close();
			}
		}

		// See if the float values are correctly set
		// IMPORTANT: Add all float MOB values here!
		private void TestFloats()
		{
			if (pOffsetX.Checked)
			{
				try
				{
					float.Parse(vOffsetX.Text);
				}
				catch (Exception)
				{
					vOffsetX.Text = "0";
					MessageBox.Show("X Offset had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pOffsetY.Checked)
			{
				try
				{
					float.Parse(vOffsetY.Text);
				}
				catch (Exception)
				{
					vOffsetY.Text = "0";
					MessageBox.Show("Y Offset had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pOfsZ.Checked)
			{
				try
				{
					float.Parse(vOfsZ.Text);
				}
				catch (Exception)
				{
					vOfsZ.Text = "0";
					MessageBox.Show("Z Offset had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pRadius.Checked)
			{
				try
				{
					float.Parse(vRadius.Text);
				}
				catch (Exception)
				{
					vRadius.Text = "0";
					MessageBox.Show("Radius had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pSpdWalk.Checked)
			{
				try
				{
					float.Parse(vSpdWalk.Text);
				}
				catch (Exception)
				{
					vSpdWalk.Text = "0";
					MessageBox.Show("Speed (Walk) had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pSpdRun.Checked)
			{
				try
				{
					float.Parse(vSpdRun.Text);
				}
				catch (Exception)
				{
					vSpdRun.Text = "0";
					MessageBox.Show("Speed (Run) had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pRotation.Checked)
			{
				try
				{
					float.Parse(vRotation.Text);
				}
				catch (Exception)
				{
					vRotation.Text = "0";
					MessageBox.Show("Rotation had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			if (pHeight.Checked)
			{
				try
				{
					float.Parse(vHeight.Text);
				}
				catch (Exception)
				{
					vHeight.Text = "0";
					MessageBox.Show("3D Render Height had an invalid floating point value passed to it! It's reset to zero.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}
		}

		// Save a MOB file
		private string __MOB_OVERRIDE_NAME = "";
		private void SaveMOB()
		{
			FileStream mob;

			if (__MOB_OVERRIDE_NAME == "")
				mob = new FileStream("Mobiles\\"+MobileName.Text+".mob", FileMode.Create);
			else
			{
				mob = new FileStream(__MOB_OVERRIDE_NAME, FileMode.Create);
				__MOB_OVERRIDE_NAME = "";
			}

			TestFloats();

			BinaryWriter w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(Prototype.Text.Split('#')[1]);

			// Do we have to embed in a sector? If so, use type 0x00 GUID,
			// otherwise use type 0x02 GUID
			if (Helper.EmbedMode)
			{
				MOB_GUID_BYTES[0]=0x00;
				Helper.EmbedMode = false;
			}
			else
			{
				MOB_GUID_BYTES[0]=0x02;
			}

			try
			{
				w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
				w_mob.Write(MOB_GUID_BYTES);
				w_mob.Write((Int32)Helper.GEN_GetMobileType(MobType.Text));
				w_mob.Write((Int16)Helper.MOB_GetNumberOfProperties(MOB_BITMAP));
		
				ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(MOB_BITMAP);

				foreach (object block in BitmapBytes)
					w_mob.Write((byte)block);

				// Save all the properties
				SaveMOB_Properties(w_mob);
			}
			catch (Exception)
			{
				w_mob.Close();
				mob.Close();
				throw new Exception("MOBSavingFailed");
			}

			w_mob.Close();
			mob.Close();
		}

		private void btnSaveMob_Click(object sender, System.EventArgs e)
		{
			if (MobileName.Text.Substring(0, 2) != "G_")
			{
				MessageBox.Show("No mobile file is open.",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if (MobType.Text == "obj_t_scenery" ||
				MobType.Text == "obj_t_portal" ||
				MobType.Text == "obj_t_projectile" /*UNKNOWN*/ ||
				MobType.Text == "obj_t_trap")
			{
				if (MessageBox.Show("Objects of the chosen type ("+MobType.Text+") should be embedded into sectors! Saving them as standalone MOB files may have unpredictable effect on the game. You can save the MOB file for this object only to be able to load it later and embed into a sector. Is that what you want to do?","Please confirm precarious operation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.No)
					return;
			}

			if (MessageBox.Show("Are you sure you want to save a mobile?",
				"Please confirm operation",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question) == DialogResult.No)
				return;

			// IMPORTANT: Check for errors
			if (Helper.MOB_GetPropertyState(MOB_BITMAP, 152) == TriState.True && tParent.Text.Substring(0, 2) != "G_")
			{
				MessageBox.Show("Warning: You have specified an option to include a back-reference to the parent container but you forgot to choose the container itself. Please correct the error before saving.","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			try
			{
				SaveMOB();

				MessageBox.Show("Mobile object file saved.",
					"Done",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				MessageBox.Show("There was an error parsing object properties. Saving failed. Please check all your properties (whether they are set correctly and whether they are valid for your object type, e.g. you can't define NPC flags for a door)\n\nIt is a known issue that sometimes setting an invalid flag and then turning it off causes this error, too. In that case you may want to reload the mobile object file. Sorry for the inconvenience.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				if (File.Exists("Mobiles\\"+MobileName.Text+".mob"))
					File.Delete("Mobiles\\"+MobileName.Text+".mob");
			}
		}

		private void SwitchOffCheckboxes()
		{
			// IMPORTANT: Clear all check boxes
			vWaypoints.Items.Clear();
			pRotation.Checked = false;
			pWorth.Checked = false;
			pWeight.Checked = false;
			pLockDC.Checked = false;
			pPLockDC.Checked = false;
			pPKeyID.Checked = false;
            pLevelup.Checked = false;
			pParent.Checked = false;
			pACAdj.Checked = false;
			pACMaxDex.Checked = false;
			pSDDC.Checked = false;
			pAmmoAmt.Checked = false;
			pSpellFail.Checked = false;
			pArmorChk.Checked = false;
			pItemAmt.Checked = false;
			pTransparency.Checked = false;
			pSubInv.Checked = false;
			pStandpoints.Checked = false;
            pNPCGenData.Checked = false;
			pEffName.Checked = false;
			pObjName.Checked = false;
			pInvSlot.Checked = false;
			tParent.Text = "PARENT OBJECT NOT DEFINED";
			tSubInv.Text = "SUBSTITUTE INVENTORY OBJECT NOT DEFINED";
			pAI64.Checked = false;
			pNotify1.Checked = false;
			pNotify2.Checked = false;
			pObjFlags.Checked = false;
			p_OCOF.Checked = false;
			p_OPF.Checked = false;
			p_ONF.Checked = false;
			p_OCF.Checked = false;
			p_OIF.Checked = false;
			p_OCF2.Checked = false;
			p_OARF.Checked = false;
			p_OWF.Checked = false;
			p_OSCF.Checked = false;
			p_OSDF.Checked = false;
			pMoneyIdx.Checked = false;
			pReach.Checked = false;
			pWaypoints.Checked = false;
            pFactions.Checked = false;
			pInvenSource.Checked = false;
			pChestInv.Checked = false;
			pNpcInv.Checked = false;
			pOffsetX.Checked = false;
			pOffsetY.Checked = false;
			pOfsZ.Checked = false;
			pRadius.Checked = false;
			pHeight.Checked = false;
			pMoneyQuantity.Checked = false;
			pTeleport.Checked = false;
			pNpcInvenSource.Checked = false;
			pDispatcher.Checked = false;
			vChestInv.Items.Clear();
			vNpcInv.Items.Clear();
			pKeyID.Checked = false;
			pKeyID2.Checked = false;
			pModelScale.Checked = false;
			pHP.Checked = false;
			pHPDmg.Checked = false;
			pHPAdj.Checked = false;
			pSpdWalk.Checked = false;
			pSpdRun.Checked = false;
			pFaction.Checked = false;
			pTeleDest.Checked = false;
			pTeleMap.Checked = false;
            pScoutPoint.Checked = false;
            pAbilities.Checked = false;
            pRace.Checked = false;
            pGender.Checked = false;
		}

		// IMPORTANT: Property save routine
		private void SaveMOB_Properties(BinaryWriter w_mob)
		{
			for (int i=0; i<512; i++)
			{
				TriState state = Helper.MOB_GetPropertyState(MOB_BITMAP, i);
				if (state == TriState.True)
				{
					// Main code to save props
					switch (i)
					{
						case 0:
							// obj_f_location
							UInt32 loc_x = UInt32.Parse(LocationX.Text);
							UInt32 loc_y = UInt32.Parse(LocationY.Text);
							w_mob.Write((byte)0x01);
							w_mob.Write(loc_x);
							w_mob.Write(loc_y);
							break;
						case 1:
							// obj_f_offset_x
							float ofsx = float.Parse(vOffsetX.Text);
							w_mob.Write(ofsx);
							break;
						case 2:
							// obj_f_offset_y
							float ofsy = float.Parse(vOffsetY.Text);
							w_mob.Write(ofsy);
							break;
						case 6:
							// obj_f_blit_alpha
							UInt32 alpha = UInt32.Parse(vTransparency.Text);
							w_mob.Write(alpha);
							break;
						case 7:
							// obj_f_scale
							uint scale = uint.Parse(vModelScale.Text);
							w_mob.Write(scale);
							break;
						case 21:
							// obj_f_flags
							UInt32 objflags = GetObjectFlags();
							w_mob.Write(objflags);
							break;
						case 23:
							// obj_f_name
							UInt32 name = UInt32.Parse(vObjName.Text);
							w_mob.Write(name);
							break;
						case 26:
							// obj_f_hp_pts
							UInt32 hp = UInt32.Parse(vHP.Text);
							w_mob.Write(hp);
							break;
						case 27:
							// obj_f_hp_adj
							UInt32 hp_adj = UInt32.Parse(vHPAdj.Text);
							w_mob.Write(hp_adj);
							break;
						case 28:
							// obj_f_hp_damage
							UInt32 hp_dmg = UInt32.Parse(vHPDmg.Text);
							w_mob.Write(hp_dmg);
							break;
                        case 30:
                            // obj_f_scripts_idx (EXPORTED)
                            ExportEntry(w_mob, IMPORTED_ENTRY30);
                            break;
						case 33:
							// obj_f_rotation
							float rot = float.Parse(vRotation.Text);
							w_mob.Write(rot);
							break;
						case 34:
							// obj_f_speed_walk
							float spd_w = float.Parse(vSpdWalk.Text);
							w_mob.Write(spd_w);
							break;
						case 35:
							// obj_f_speed_run
							float spd_r = float.Parse(vSpdRun.Text);
							w_mob.Write(spd_r);
							break;
						case 38:
							// obj_f_radius
							float rad = float.Parse(vRadius.Text);
							w_mob.Write(rad);
							break;
						case 39:
							// obj_f_3d_render_height
							float height = float.Parse(vHeight.Text);
							w_mob.Write(height);
							break;
                        case 40:
                            // obj_f_conditions (EXPORTED)
                            ExportEntry(w_mob, IMPORTED_ENTRY40);
                            break;
                        case 41:
                            // obj_f_conditions_arg0 (EXPORTED)
                            ExportEntry(w_mob, IMPORTED_ENTRY41);
                            break;
						case 42:
							// obj_f_permanent_mods (EXPORTED)
							ExportEntry(w_mob, IMPORTED_ENTRY42);
							break;
						case 44:
							// obj_f_dispatcher
							w_mob.Write((UInt32)0xFFFFFFFF);
							break;
						case 46:
							// obj_f_secretdoor_flags
							int sdflags = (int)GetSecretDoorFlags();
                            // now, we need to embed the door DC in here
                            sdflags = Helper.MAKE_DC(sdflags, int.Parse(vSDDC.Text));
							w_mob.Write(sdflags);
							break;
						case 47:
							// obj_f_secretdoor_effectname
							UInt32 eff = UInt32.Parse(vEffName.Text);
							w_mob.Write(eff);
							break;
						case 48:
							// obj_f_secretdoor_dc
                            int sddc = 0;
                            sddc = Helper.MAKE_DC(sddc, int.Parse(vSDDC.Text));
							w_mob.Write(sddc);
							break;
						case 53:
							// obj_f_offset_z
							float ofs_z = float.Parse(vOfsZ.Text);
							w_mob.Write(ofs_z);
							break;
						case 73:
							// obj_f_permanent_mod_data (EXPORTED)
							ExportEntry(w_mob, IMPORTED_ENTRY73);
							break;
						case 88:
							// obj_f_portal_flags
							UInt32 p_flags = GetPortalFlags();
							w_mob.Write(p_flags);
							break;
						case 89:
							// obj_f_portal_lock_dc
							UInt32 p_dc = UInt32.Parse(vPLockDC.Text);
							w_mob.Write(p_dc);
							break;
						case 90:
							// obj_f_portal_key_id
							UInt32 p_key_id = UInt32.Parse(vPKeyID.Text);
							w_mob.Write(p_key_id);
							break;
						case 91:
							// obj_f_portal_notify_npc
							UInt32 notify1 = UInt32.Parse(pNotify1.Text);
							w_mob.Write(notify1);
							break;
						case 102:
							// obj_f_container_flags
							UInt32 contflags = GetContainerFlags();
							w_mob.Write(contflags);
							break;
						case 103:
							// obj_f_container_lock_dc
							UInt32 dc = UInt32.Parse(vLockDC.Text);
							w_mob.Write(dc);
							break;
						case 104:
							// obj_f_container_key_id
							UInt32 key_id = UInt32.Parse(vKeyID.Text);
							w_mob.Write(key_id);
							break;
						case 105:
							// obj_f_container_inventory_num
							w_mob.Write((uint)vChestInv.Items.Count);
							break;
						case 106:
							// obj_f_container_inventory_list_idx
							SaveLinkedMobileObjects(w_mob);
							break;
						case 107:
							// obj_f_container_inventory_source (INVENSOURCE)
							UInt32 invsrc = UInt32.Parse(vInvenSource.Text);
							w_mob.Write(invsrc);
							break;
						case 108:
							// obj_f_container_notify_npc
							UInt32 notify2 = UInt32.Parse(pNotify2.Text);
							w_mob.Write(notify2);
							break;
						case 121:
							// obj_f_scenery_flags
							UInt32 scenflags = GetSceneryFlags();
							w_mob.Write(scenflags);
							break;
						case 126:
							// obj_f_scenery_teleport_to
							UInt32 scenery_dest = UInt32.Parse(vTeleport.Text);
							w_mob.Write(scenery_dest);
							break;
						case 151:
							// obj_f_item_flags
							UInt32 itemflags = GetItemFlags();
							w_mob.Write(itemflags);
							break;
						case 152:
							// obj_f_item_parent
							w_mob.Write((byte)0x01);
							w_mob.Write(MOB_PROP_152);
							break;
						case 153:
							// obj_f_item_weight
							UInt32 weight = UInt32.Parse(vWeight.Text);
							w_mob.Write(weight);
							break;
						case 154:
							// obj_f_item_worth
							UInt32 worth = UInt32.Parse(vWorth.Text);
							w_mob.Write(worth);
							break;
						case 156:
							// obj_f_item_inv_location
							UInt32 slot = UInt32.Parse(vInvSlot.Text);
							w_mob.Write(slot);
							break;
						case 167:
							// obj_f_item_quantity
							UInt32 quantity = UInt32.Parse(vItemAmt.Text);
							w_mob.Write(quantity);
							break;
						case 187:
							// obj_f_weapon_flags
							UInt32 weapflags = GetWeaponFlags();
							w_mob.Write(weapflags);
							break;
						case 210:
							// obj_f_ammo_quantity
							UInt32 ammo = UInt32.Parse(vAmmoAmt.Text);
							w_mob.Write(ammo);
							break;
						case 219:
							// obj_f_armor_flags
							UInt32 armorflags = GetArmorFlags();
							w_mob.Write(armorflags);
							break;
						case 220:
							// obj_f_armor_ac_adj
							Int32 acadj = Int32.Parse(vACAdj.Text);
							w_mob.Write(acadj);
							break;
						case 221:
							// obj_f_armor_max_dex_bonus
							Int32 maxdex = Int32.Parse(vACMaxDex.Text);
							w_mob.Write(maxdex);
							break;
						case 222:
							// obj_f_armor_arcane_spell_failure
							Int32 sf = Int32.Parse(vSpellFail.Text);
							w_mob.Write(sf);
							break;
						case 223:
							// obj_f_armor_armor_check_penalty
							Int32 chk = Int32.Parse(vArmorChk.Text);
							w_mob.Write(chk);
							break;
						case 230:
							// obj_f_money_quantity
							UInt32 mamount = UInt32.Parse(vMoneyQuantity.Text);
							w_mob.Write(mamount);
							break;
						case 255:
							// obj_f_key_key_id
							UInt32 id = UInt32.Parse(vKeyID2.Text);
							w_mob.Write(id);
							break;
						case 283:
							// obj_f_critter_flags
							UInt32 critflags1 = GetCritterFlags1();
							w_mob.Write(critflags1);
							break;
						case 284:
							// obj_f_critter_flags2
							UInt32 critflags2 = GetCritterFlags2();
							w_mob.Write(critflags2);
							break;
                        case 285:
                            // obj_f_critter_abilities_idx
                            SaveAbilities(w_mob);
                            break;
                        case 287:
                            // obj_f_critter_race
                            w_mob.Write(int.Parse(vRace.Text));
                            break;
                        case 288:
                            // obj_f_critter_gender
                            w_mob.Write(int.Parse(vGender.Text));
                            break;
                        case 293:
                            // obj_f_critter_pad_i_1 (unknown, imported only for now)
                            w_mob.Write(IMPORTED_ENTRY293);
                            break;
						case 307:
							// obj_f_critter_money_idx
							SaveMoneyIndex(w_mob);
							break;
						case 308:
							// obj_f_critter_inventory_num
							w_mob.Write((uint)vNpcInv.Items.Count);
							break;
						case 309:
							// obj_f_critter_inventory_list_idx
							SaveLinkedMobileObjectsForNPC(w_mob);
							break;
						case 310:
							// obj_f_critter_inventory_source
							UInt32 ninvsrc = UInt32.Parse(vNpcInvenSource.Text);
							w_mob.Write(ninvsrc);
							break;
						case 313:
							// obj_f_critter_teleport_dest
							w_mob.Write((byte)0x01);
							w_mob.Write(UInt32.Parse(vTeleX.Text));
							w_mob.Write(UInt32.Parse(vTeleY.Text));
							break;
						case 314:
							// obj_f_critter_teleport_map
							w_mob.Write(UInt32.Parse(vTeleMap.Text));
							break;
						case 317:
							// obj_f_critter_reach
							UInt32 reach = UInt32.Parse(vReach.Text);
							w_mob.Write(reach);
							break;
                        case 319:
                            // obj_f_critter_levelup_scheme
                            UInt32 scheme = UInt32.Parse(vLevelup.Text);
                            w_mob.Write(scheme);
                            break;
						case 353:
							// obj_f_npc_flags
							UInt32 npcflags = GetNPCFlags();
							w_mob.Write(npcflags);
							break;
						case 358:
							// obj_f_npc_waypoints
							SaveNPCWaypoints(w_mob);
							break;
						case 362:
							// obj_f_npc_faction
							SaveNPCFactions(w_mob);
							break;
						case 364:
							// obj_f_npc_substitute_inventory
							w_mob.Write((byte)0x01);
							w_mob.Write(MOB_PROP_SUBINV);
							break;
                        case 370:
                            // obj_f_npc_generator_data
                            uint gdata_storing = PackGeneratorData();
                            w_mob.Write(gdata_storing);
                            break;
						case 381:
							// obj_f_npc_ai_flags64
							ArrayList ar_tmp;
							try
							{
								ar_tmp = Helper.MOB_BitmapToBytes(vAI64.Text);
							}
							catch (Exception)
							{
								MessageBox.Show("Error: AI Flags 64 were not defined correctly! Please use only 0's and 1's, no spaces and no carriage return symbols!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
								break;
							}
							w_mob.Write((byte)0x01);
							foreach(object block in ar_tmp)
								w_mob.Write((byte)block);
							break;
						case 391:
							// obj_f_npc_standpoints
							SaveNPCStandpoints(w_mob);
							break;
						default:
							throw new Exception("Unexpected Error 004: Invalid property save routine branch was chosen at SaveMOB_Properties(BinaryWriter)!");
					}
				}
				else if (state == TriState.NotValid)
				{
					break;
				}
			}
		}

		// IMPORTANT: Property load routine
		private void LoadMOB_Properties(BinaryReader r_mob, string input_filename)
		{
			byte LEADING_BYTE; // Just a dummy byte for the leading byte (0x01)

			// IMPORTANT: Switch off all the properties
			pRotation.Checked = false;

			for (int i=0; i<512; i++)
			{
				TriState state = Helper.MOB_GetPropertyState(MOB_BITMAP, i);
				if (state == TriState.True)
				{                    
#if DEBUG
                     MessageBox.Show(i.ToString()+"; ofs:"+r_mob.BaseStream.Position.ToString());
#endif

					// Main code to load props
					switch (i)
					{
						case 0:
							// obj_f_location
							LEADING_BYTE = r_mob.ReadByte();
							LocationX.Text = r_mob.ReadUInt32().ToString();
							LocationY.Text = r_mob.ReadUInt32().ToString();
							break;
						case 1:
							// obj_f_offset_x
							vOffsetX.Text = r_mob.ReadSingle().ToString();
							pOffsetX.Checked = true;
							break;
						case 2:
							// obj_f_offset_y
							vOffsetY.Text = r_mob.ReadSingle().ToString();
							pOffsetY.Checked = true;
							break;
						case 6:
							// obj_f_blit_alpha
							vTransparency.Text = r_mob.ReadUInt32().ToString();
							pTransparency.Checked = true;
							break;
						case 7:
							// obj_f_scale
							vModelScale.Text = r_mob.ReadUInt32().ToString();
							pModelScale.Checked = true;
							break;
						case 21:
							// obj_f_flags
							uint ObjFlags = r_mob.ReadUInt32();
							pObjFlags.Checked = true;
							SetObjectFlags(ObjFlags);
							break;
						case 23:
							// obj_f_name
							vObjName.Text = r_mob.ReadUInt32().ToString();
							pObjName.Checked = true;
							break;
						case 26:
							// obj_f_hp_pts
							vHP.Text = r_mob.ReadUInt32().ToString();
							pHP.Checked = true;
							break;
						case 27:
							// obj_f_hp_adj
							vHPAdj.Text = r_mob.ReadUInt32().ToString();
							pHPAdj.Checked = true;
							break;
						case 28:
							// obj_f_hp_damage
							vHPDmg.Text = r_mob.ReadUInt32().ToString();
							pHPDmg.Checked = true;
							break;
                        case 30:
                            // obj_f_scripts_idx (IMPORTED)
                            IMPORTED_ENTRY30 = ImportEntry(r_mob, 30);
                            break;
						case 33:
							// obj_f_rotation
							vRotation.Text = r_mob.ReadSingle().ToString();
							pRotation.Checked = true;
							break;
						case 34:
							// obj_f_speed_walk
							vSpdWalk.Text = r_mob.ReadSingle().ToString();
							pSpdWalk.Checked = true;
							break;
						case 35:
							// obj_f_speed_run
							vSpdRun.Text = r_mob.ReadSingle().ToString();
							pSpdRun.Checked = true;
							break;
						case 38:
							// obj_f_radius
							vRadius.Text = r_mob.ReadSingle().ToString();
							pRadius.Checked = true;
							break;
						case 39:
							// obj_f_3d_render_height
							vHeight.Text = r_mob.ReadSingle().ToString();
							pHeight.Checked = true;
							break;
                        case 40:
                            // obj_f_conditions (IMPORTED)
                            IMPORTED_ENTRY40 = ImportEntry(r_mob, 40);
                            break;
                        case 41:
                            // obj_f_conditions_arg0 (IMPORTED)
                            IMPORTED_ENTRY41 = ImportEntry(r_mob, 41);
                            break;
						case 42:
							// obj_f_permanent_mods (IMPORTED)
							IMPORTED_ENTRY42 = ImportEntry(r_mob, 42);
							break;
						case 44:
							// obj_f_dispatcher
							if (r_mob.ReadUInt32() == 0xFFFFFFFF)
								pDispatcher.Checked = true;
							break;
						case 46:
							// obj_f_secretdoor_flags
							int SDFlags = r_mob.ReadInt32();
							p_OSDF.Checked = true;
							SetSecretDoorFlags((uint)SDFlags);
                            // we need to load the DC from here, I believe
                            vSDDC.Text = Helper.GET_DC(SDFlags).ToString();
							break;
						case 47:
							// obj_f_secretdoor_effectname
							vEffName.Text = r_mob.ReadUInt32().ToString();
							pEffName.Checked = true;
							break;
						case 48:
							// obj_f_secretdoor_dc
							vSDDC.Text = r_mob.ReadUInt32().ToString();
							pSDDC.Checked = true;
							break;
						case 53:
							// obj_f_offset_z
							vOfsZ.Text = r_mob.ReadSingle().ToString();
							pOfsZ.Checked = true;
							break;
						case 73:
							// obj_f_permanent_mod_data (IMPORTED)
							IMPORTED_ENTRY73 = ImportEntry(r_mob, 73);
							break;
						case 88:
							uint PortalFlags = r_mob.ReadUInt32();
							p_OPF.Checked = true;
							SetPortalFlags(PortalFlags);
							break;
						case 89:
							// obj_f_portal_lock_dc
							vPLockDC.Text = r_mob.ReadUInt32().ToString();
							pPLockDC.Checked = true;
							break;
						case 90:
							// obj_f_portal_key_id
							vPKeyID.Text = r_mob.ReadUInt32().ToString();
							pPKeyID.Checked = true;
							break;
						case 91:
							// obj_f_portal_notify_npc
							vNotify1.Text = r_mob.ReadUInt32().ToString();
							pNotify1.Checked = true;
							break;
						case 102:
							// obj_f_container_flags
							uint ContFlags = r_mob.ReadUInt32();
							p_OCOF.Checked = true;
							SetContainerFlags(ContFlags);
							break;
						case 103:
							// obj_f_container_lock_dc
							vLockDC.Text = r_mob.ReadUInt32().ToString();
							pLockDC.Checked = true;
							break;
						case 104:
							// obj_f_container_key_id
							vKeyID.Text = r_mob.ReadUInt32().ToString();
							pKeyID.Checked = true;
							break;
						case 105:
							// obj_f_container_inventory_num
							pChestInv.Checked = true;
							CONTAINER_INV_LIST_IDX = r_mob.ReadUInt32();
							break;
						case 106:
							// obj_f_container_inventory_list_idx
							LoadLinkedMobileObjects(r_mob);
							break;
						case 107:
							// obj_f_container_inventory_source
							vInvenSource.Text = r_mob.ReadUInt32().ToString();
							pInvenSource.Checked = true;
							break;
						case 108:
							// obj_f_container_notify_npc
							pNotify2.Checked = true;
							vNotify2.Text = r_mob.ReadUInt32().ToString();
							break;
						case 121:
							// obj_f_scenery_flags
							uint ScenFlags = r_mob.ReadUInt32();
							p_OSCF.Checked = true;
							SetSceneryFlags(ScenFlags);
							break;
						case 126:
							// obj_f_scenery_teleport_to
							vTeleport.Text = r_mob.ReadUInt32().ToString();
							pTeleport.Checked = true;
							break;
						case 151:
							// obj_f_item_flags
							uint ItemFlags = r_mob.ReadUInt32();
							p_OIF.Checked = true;
							SetItemFlags(ItemFlags);
							break;
						case 152:
							// obj_f_item_parent
							LEADING_BYTE = r_mob.ReadByte();
							MOB_PROP_152 = r_mob.ReadBytes(24);
							//tParent.Text = Path.GetFileNameWithoutExtension(input_filename);
							tParent.Text = Helper.GEN_ConvertBytesToStringGUID(MOB_PROP_152);
							pParent.Checked = true;
							break;
						case 153:
							// obj_f_item_weight
							vWeight.Text = r_mob.ReadUInt32().ToString();
							pWeight.Checked = true;
							break;
						case 154:
							// obj_f_item_worth
							vWorth.Text = r_mob.ReadUInt32().ToString();
							pWorth.Checked = true;
							break;
						case 156:
							// obj_f_item_inv_location
							vInvSlot.Text = r_mob.ReadUInt32().ToString();
							pInvSlot.Checked = true;
							break;
						case 167:
							// obj_f_item_quantity
							vItemAmt.Text = r_mob.ReadUInt32().ToString();
							pItemAmt.Checked = true;
							break;
						case 187:
							// obj_f_weapon_flags
							uint WeapFlags = r_mob.ReadUInt32();
							p_OWF.Checked = true;
							SetWeaponFlags(WeapFlags);
							break;
						case 210:
							// obj_f_ammo_quantity
							vAmmoAmt.Text = r_mob.ReadUInt32().ToString();
							pAmmoAmt.Checked = true;
							break;
						case 219:
							// obj_f_armor_flags
							uint ArmorFlags = r_mob.ReadUInt32();
							p_OARF.Checked = true;
							SetArmorFlags(ArmorFlags);
							break;
						case 220:
							// obj_f_armor_ac_adj
							vACAdj.Text = r_mob.ReadInt32().ToString();
							pACAdj.Checked = true;
							break;
						case 221:
							// obj_f_armor_max_dex_bonus
							vACMaxDex.Text = r_mob.ReadInt32().ToString();
							pACMaxDex.Checked = true;
							break;
						case 222:
							// obj_f_armor_arcane_spell_failure
							vSpellFail.Text = r_mob.ReadInt32().ToString();
							pSpellFail.Checked = true;
							break;
						case 223:
							// obj_f_armor_armor_check_penalty
							vArmorChk.Text = r_mob.ReadInt32().ToString();
							pArmorChk.Checked = true;
							break;
						case 230:
							// obj_f_money_quantity
							vMoneyQuantity.Text = r_mob.ReadUInt32().ToString();
							pMoneyQuantity.Checked = true;
							break;
						case 255:
							// obj_f_key_key_id
							vKeyID2.Text = r_mob.ReadUInt32().ToString();
							pKeyID2.Checked = true;
							break;
						case 283:
							// obj_f_critter_flags
							uint CritFlags1 = r_mob.ReadUInt32();
							p_OCF.Checked = true;
							SetCritterFlags1(CritFlags1);
							break;
						case 284:
							// obj_f_critter_flags2
							uint CritFlags2 = r_mob.ReadUInt32();
							p_OCF2.Checked = true;
							SetCritterFlags2(CritFlags2);
							break;
                        case 285:
                            // obj_f_critter_abilities_idx
                            LoadAbilities(r_mob);
                            break;
                        case 287:
                            // obj_f_critter_race
                            vRace.Text = r_mob.ReadInt32().ToString();
                            pRace.Checked = true;
                            break;
                        case 288:
                            // obj_f_critter_gender
                            vGender.Text = r_mob.ReadInt32().ToString();
                            pGender.Checked = true;
                            break;
                        case 293:
                            // obj_f_critter_pad_i_1 (exported)
                            uint Pad1 = r_mob.ReadUInt32();
                            if (Pad1 != 0)
                                MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 293, true);
                            IMPORTED_ENTRY293 = Pad1;
                            break;
						case 307:
							// obj_f_critter_money_idx
							LoadMoneyIndex(r_mob);
							break;
						case 308:
							// obj_f_critter_inventory_num
							pNpcInv.Checked = true;
							NPC_INV_LIST_IDX = r_mob.ReadUInt32();
							break;
						case 309:
							// obj_f_critter_inventory_list_idx
							LoadLinkedMobileObjectsForNPC(r_mob);
							break;
						case 310:
							// obj_f_critter_inventory_source
							vNpcInvenSource.Text = r_mob.ReadUInt32().ToString();
							pNpcInvenSource.Checked = true;
							break;
						case 313:
							// obj_f_critter_teleport_dest
							r_mob.ReadByte();
							vTeleX.Text = r_mob.ReadUInt32().ToString();
							vTeleY.Text = r_mob.ReadUInt32().ToString();
							pTeleDest.Checked = true;
							break;
						case 314:
							// obj_f_critter_teleport_map
							vTeleMap.Text = r_mob.ReadUInt32().ToString();
							pTeleMap.Checked = true;
							break;
						case 317:
							// obj_f_critter_reach
							vReach.Text = r_mob.ReadUInt32().ToString();
							pReach.Checked = true;
							break;
                        case 319:
                            // obj_f_critter_levelup_scheme
                            vLevelup.Text = r_mob.ReadUInt32().ToString();
                            pLevelup.Checked = true;
                            break;
						case 353:
							// obj_f_npc_flags
							uint NpcFlags = r_mob.ReadUInt32();
							p_ONF.Checked = true;
							SetNPCFlags(NpcFlags);
							break;
						case 358:
							// obj_f_npc_waypoints
							LoadNPCWaypoints(r_mob);
							break;
                        case 360:
                            // obj_f_npc_standpoint_day_INTERNAL_DO_NOT_USE
                            r_mob.ReadBytes(9);
                            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 360, false);		
                            break;
                        case 361:
                            // obj_f_npc_standpoint_night_INTERNAL_DO_NOT_USE
                            r_mob.ReadBytes(9);
                            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 361, false);		
                            break;
						case 362:
							// obj_f_npc_faction
                            LoadNPCFactions(r_mob);
							break;
						case 364:
							// obj_f_npc_substitute_inventory
							LEADING_BYTE = r_mob.ReadByte();
							MOB_PROP_SUBINV = r_mob.ReadBytes(24);
							//tSubInv.Text = Path.GetFileNameWithoutExtension(input_filename);
							tSubInv.Text = Helper.GEN_ConvertBytesToStringGUID(MOB_PROP_SUBINV);
							pSubInv.Checked = true;
							break;
                        case 370:
                            // obj_f_npc_generator_data
                            uint gdata = r_mob.ReadUInt32();
                            UnpackGeneratorData(gdata);
                            pNPCGenData.Checked = true;
                            break;
						case 381:
							// obj_f_npc_ai_flags64
							LEADING_BYTE = r_mob.ReadByte();
							vAI64.Text = Helper.GEN_UInt64_To_Bitmap(r_mob.ReadUInt64());
							pAI64.Checked = true;
							break;
						case 391:
							// obj_f_npc_standpoints
							LoadNPCStandpoints(r_mob);
							break;
						default:
							throw new Exception("Unexpected Error 005: Invalid property load routine branch was chosen at LoadMOB_Properties(BinaryReader)!");
					}
				}
				else if (state == TriState.NotValid)
				{
					break;
				}
			}
		}

        private void LoadAbilities(BinaryReader r_mob)
        {
            r_mob.ReadByte();
            r_mob.ReadBytes(4);
            r_mob.ReadBytes(4);
            SAR_POS_ABL = r_mob.ReadUInt32(); // SARC
            vSTR.Text = r_mob.ReadInt32().ToString();
            vDEX.Text = r_mob.ReadInt32().ToString();
            vCON.Text = r_mob.ReadInt32().ToString();
            vINT.Text = r_mob.ReadInt32().ToString();
            vWIS.Text = r_mob.ReadInt32().ToString();
            vCHA.Text = r_mob.ReadInt32().ToString();
            pAbilities.Checked = true;

            uint r_nument = r_mob.ReadUInt32();
            for (uint r = 0; r < r_nument; r++)
                r_mob.ReadUInt32();
        }

        private void SaveAbilities(BinaryWriter w_mob)
        {
            w_mob.Write((byte)0x01);
            w_mob.Write((Int32)0x04);
            w_mob.Write((Int32)0x06);

            if (SAR_POS_ABL == 0)
            {
                uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
                w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
                SAR_POS_ABL = sarc_idx;
            }
            else
                w_mob.Write((UInt32)SAR_POS_ABL);

            w_mob.Write(Int32.Parse(vSTR.Text));
            w_mob.Write(Int32.Parse(vDEX.Text));
            w_mob.Write(Int32.Parse(vCON.Text));
            w_mob.Write(Int32.Parse(vINT.Text));
            w_mob.Write(Int32.Parse(vWIS.Text));
            w_mob.Write(Int32.Parse(vCHA.Text));

            Helper.GetComp2Ex(w_mob, 6);
        }

        private uint PackGeneratorData()
        {
            // Note: spawn rate should be controlled in radiobox event handlers!
            uint gdata = 0;

            gdata = (uint)Helper.MAKE_GENID((int)gdata, int.Parse(vNPCGenData.Text));
            gdata = (uint)Helper.MAKE_SPAWNMAX((int)gdata, int.Parse(vNPCGSpawnConcurrent.Text));
            gdata = (uint)Helper.MAKE_TOTAL((int)gdata, int.Parse(vNPCGSpawnTotal.Text));

            // set flags
            if (vNPCGDay.Checked)
                gdata += (uint)Math.Pow(2, 27);
            if (vNPCGNight.Checked)
                gdata += (uint)Math.Pow(2, 28);
            if (vNPCGActive.Checked)
                gdata += (uint)Math.Pow(2, 29);
            if (vNPCGSpawnAll.Checked)
                gdata += (uint)Math.Pow(2, 30);
            if (vNPCGIgnoreTotal.Checked)
                gdata += (uint)Math.Pow(2, 31);

            return gdata;
        }

        private void UnpackGeneratorData(uint gdata)
        {
            string gbitmap = Helper.GEN_UInt32_To_Bitmap(gdata);
            int _gdata = (int)gdata;
            
            if ( (gdata & ((uint)Math.Pow(2,27))) != 0 )
                vNPCGDay.Checked = true;
            else
                vNPCGDay.Checked = false;

            if ( (gdata & ((uint)Math.Pow(2, 28))) != 0 )
                vNPCGNight.Checked = true;
            else
                vNPCGNight.Checked = false;

            if ((gdata & ((uint)Math.Pow(2, 29))) != 0)
                vNPCGActive.Checked = true;
            else
                vNPCGActive.Checked = false;

            if ((gdata & ((uint)Math.Pow(2, 30))) != 0)
                vNPCGSpawnAll.Checked = true;
            else
                vNPCGSpawnAll.Checked = false;

            if ((gdata & ((uint)Math.Pow(2, 31))) != 0)
                vNPCGIgnoreTotal.Checked = true;
            else
                vNPCGIgnoreTotal.Checked = false;

            vNPCGenData.Text = Helper.GET_GENID(_gdata).ToString();
            vNPCGSpawnConcurrent.Text = Helper.GET_SPAWNMAX(_gdata).ToString();
            vNPCGSpawnTotal.Text = Helper.GET_TOTAL(_gdata).ToString();

            // NPC rate flags setup
            if (Helper.MOB_GetPropertyState(MOB_BITMAP, 353) == TriState.True)
            {
                uint flags = GetNPCFlags();
                int rate = Helper.GET_NPCGEN((int)flags);

                if (rate == 0)
                {
                    vNPCGRate1.Checked = true;
                    vNPCGRate1_CheckedChanged(null, null);
                }
                else if (rate == 1)
                {
                    vNPCGRate2.Checked = true;
                    vNPCGRate2_CheckedChanged(null, null);
                }
                else if (rate == 2)
                {
                    vNPCGRate3.Checked = true;
                    vNPCGRate3_CheckedChanged(null, null);
                }
                else if (rate == 3)
                {
                    vNPCGRate4.Checked = true;
                    vNPCGRate4_CheckedChanged(null, null);
                }
                else if (rate == 4)
                {
                    vNPCGRate5.Checked = true;
                    vNPCGRate5_CheckedChanged(null, null);
                }
                else if (rate == 5)
                {
                    vNPCGRate6.Checked = true;
                    vNPCGRate6_CheckedChanged(null, null);
                }
                else if (rate == 6)
                {
                    vNPCGRate7.Checked = true;
                    vNPCGRate7_CheckedChanged(null, null);
                }
                else if (rate == 7)
                {
                    vNPCGRate8.Checked = true;
                    vNPCGRate8_CheckedChanged(null, null);
                }
            }
            else
            {
                vNPCGRate1.Checked = true;
            }
        }

		private ArrayList ImportEntry(BinaryReader r_mob, int entry_ID)
		{
			ArrayList i_Target = new ArrayList();
			uint mul1 = 0;
			uint mul2 = 0;
			uint num_bytes = 0;

			i_Target.Add(r_mob.ReadByte()); // leading 0x01
			mul1 = r_mob.ReadUInt32();
			mul2 = r_mob.ReadUInt32();
            r_mob.ReadUInt32(); // should be SARC here
            r_mob.BaseStream.Seek(-12, SeekOrigin.Current);

			num_bytes = mul1 * mul2;
			for (int i=0; i<num_bytes+12; i++)
				i_Target.Add(r_mob.ReadByte());

            // post-struct
            uint r_nument = r_mob.ReadUInt32();
            uint bytes_to_add = r_nument * 4 + 4;
            r_mob.BaseStream.Seek(-4, SeekOrigin.Current);

            for (uint r = 0; r < bytes_to_add; r++)
                i_Target.Add(r_mob.ReadByte());

			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, entry_ID, true);
			return i_Target;
		}

		private void ExportEntry(BinaryWriter w_mob, ArrayList entry_data)
		{
			foreach(object block in entry_data)
				w_mob.Write((byte)block);
		}

		private void LoadMoneyIndex(BinaryReader r_mob)
		{
			r_mob.ReadByte();
			r_mob.ReadBytes(4);
			r_mob.ReadBytes(4);
			SAR_POS_MDX = r_mob.ReadUInt32(); // SARC
			vMoneyIdx1.Text = r_mob.ReadUInt32().ToString();
			vMoneyIdx2.Text = r_mob.ReadUInt32().ToString();
			vMoneyIdx3.Text = r_mob.ReadUInt32().ToString();
			vMoneyIdx4.Text = r_mob.ReadUInt32().ToString();
			pMoneyIdx.Checked = true;

			uint r_nument = r_mob.ReadUInt32();
			for (uint r=0; r<r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void LoadLinkedMobileObjects(BinaryReader r_mob)
		{
			r_mob.ReadByte();
			r_mob.ReadBytes(4);
			r_mob.ReadBytes(4);
			SAR_POS = r_mob.ReadUInt32(); // SARC

			for (int i=0; i<CONTAINER_INV_LIST_IDX; i++)
			{
				byte[] GUID = r_mob.ReadBytes(24);
				string s_GUID = Helper.GEN_ConvertBytesToStringGUID(GUID);

				try
				{
					BinaryReader br = new BinaryReader(new FileStream("Mobiles\\"+s_GUID+".mob", FileMode.Open));
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					int proto = br.ReadInt32();
					br.Close();
					vChestInv.Items.Add(Helper.Proto_By_ID[proto.ToString()]+"\t\t\t\t"+s_GUID);
				}
				catch (Exception)
				{
					MessageBox.Show("Error: Can't find the linked inventory mobile object file: \n"+s_GUID+".mob","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			uint r_nument = r_mob.ReadUInt32();
			
			for (uint r=0; r<r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void LoadLinkedMobileObjectsForNPC(BinaryReader r_mob)
		{
			r_mob.ReadByte();
			r_mob.ReadBytes(4);
			r_mob.ReadBytes(4);
			SAR_POS_NPC = r_mob.ReadUInt32(); // SARC

			for (int i=0; i<NPC_INV_LIST_IDX; i++)
			{
				byte[] GUID = r_mob.ReadBytes(24);
				string s_GUID = Helper.GEN_ConvertBytesToStringGUID(GUID);

				try
				{
					BinaryReader br = new BinaryReader(new FileStream("Mobiles\\"+s_GUID+".mob", FileMode.Open));
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					int proto = br.ReadInt32();
					br.Close();
					vNpcInv.Items.Add(Helper.Proto_By_ID[proto.ToString()]+"\t\t\t\t"+s_GUID);
				}
				catch (Exception)
				{
					MessageBox.Show("Error: Can't find the linked inventory mobile object file: \n"+s_GUID+".mob","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				}
			}

			uint r_nument = r_mob.ReadUInt32();
			
			for (uint r=0; r<r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void SaveMoneyIndex(BinaryWriter w_mob)
		{
			w_mob.Write((byte)0x01);
			w_mob.Write((Int32)0x04);
			w_mob.Write((Int32)0x04);

			if (SAR_POS_MDX == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_MDX = sarc_idx;
			}
			else
				w_mob.Write((UInt32)SAR_POS_MDX);

			w_mob.Write(UInt32.Parse(vMoneyIdx1.Text));
			w_mob.Write(UInt32.Parse(vMoneyIdx2.Text));
			w_mob.Write(UInt32.Parse(vMoneyIdx3.Text));
			w_mob.Write(UInt32.Parse(vMoneyIdx4.Text));

			Helper.GetComp2Ex(w_mob, 4);
		}

		private void SaveLinkedMobileObjects(BinaryWriter w_mob)
		{
			w_mob.Write((byte)0x01);
			w_mob.Write((Int32)0x18);
			w_mob.Write((Int32)vChestInv.Items.Count);

			if (SAR_POS == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS = sarc_idx;
			}
			else
				w_mob.Write((UInt32)SAR_POS);

			for (int i=0; i<vChestInv.Items.Count; i++)
			{
				string MOB_UNIT = vChestInv.Items[i].ToString().Split('\t')[4];
				BinaryReader br = new BinaryReader(new FileStream("Mobiles\\"+MOB_UNIT+".mob", FileMode.Open));
				br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
				w_mob.Write(br.ReadBytes(24));
				br.Close();
			}

			Helper.GetComp2Ex(w_mob, (uint)vChestInv.Items.Count);
		}

		private void SaveLinkedMobileObjectsForNPC(BinaryWriter w_mob)
		{
			w_mob.Write((byte)0x01);
			w_mob.Write((Int32)0x18);
			w_mob.Write((Int32)vNpcInv.Items.Count);

			if (SAR_POS_NPC == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_NPC = sarc_idx;
			}
			else
				w_mob.Write((UInt32)SAR_POS_NPC);

			for (int i=0; i<vNpcInv.Items.Count; i++)
			{
				string MOB_UNIT = vNpcInv.Items[i].ToString().Split('\t')[4];
				BinaryReader br = new BinaryReader(new FileStream("Mobiles\\"+MOB_UNIT+".mob", FileMode.Open));
				br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
				w_mob.Write(br.ReadBytes(24));
				br.Close();
			}

			Helper.GetComp2Ex(w_mob, (uint)vNpcInv.Items.Count);
		}

        private void SaveNPCFactions(BinaryWriter w_mob)
        {
            w_mob.Write((byte)0x01);
            w_mob.Write((Int32)0x04);
            w_mob.Write((UInt32)(vFactions.Items.Count));
                
            // SARC
            if (SAR_POS_FCN == 0)
            {
                uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
                w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
                SAR_POS_FCN = sarc_idx;
            }
            else
                w_mob.Write((UInt32)SAR_POS_FCN);

            // the structure itself
            for (int i = 0; i < vFactions.Items.Count; i++)
                w_mob.Write(UInt32.Parse((string)vFactions.Items[i]));

            // the post-structure
            Helper.GetComp2Ex(w_mob, (UInt32)(vFactions.Items.Count));
        }

        private void SaveNPCWaypoints(BinaryWriter w_mob)
		{
			w_mob.Write((byte)0x01);
			w_mob.Write((Int32)0x08);
			w_mob.Write((UInt32)(vWaypoints.Items.Count * 8 + 2));

			// SARC
			if (SAR_POS_WAY == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_WAY = sarc_idx;
			}
			else
				w_mob.Write((UInt32)SAR_POS_WAY);

			// Pre-structure
			w_mob.Write((UInt32)(vWaypoints.Items.Count));
			w_mob.Write((Int32)0x00);
			w_mob.Write((Int32)0x00);
			w_mob.Write((Int32)0x00);

			// Structure
			for (int i=0; i<vWaypoints.Items.Count; i++)
			{
				Helper.SaveWaypoint(w_mob, (Helper.WaypointInfo)NPC_WAYPOINTS[i]);
			}

			// Post-structure
			Helper.GetComp2Ex(w_mob, (UInt32)(vWaypoints.Items.Count * 8 + 2));
		}

		private void SaveNPCStandpoints(BinaryWriter w_mob)
		{
			w_mob.Write((byte)0x01);
			w_mob.Write((Int32)0x08);

            if (!pScoutPoint.Checked)
                w_mob.Write((Int32)0x14);
            else
                w_mob.Write((Int32)0x1E); //0x1E for alertpoints

			// SARC
			if (SAR_POS_STN == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_STN = sarc_idx;
			}
			else
				w_mob.Write((UInt32)SAR_POS_STN);

			// Filler
			byte[] filler = new byte[48];
			for (int i=0; i<48; i++)
				filler[i] = 0x00;

			// Day point
			w_mob.Write(UInt32.Parse(vDayMap.Text));
			//w_mob.Write((UInt32)0x77F442AA);
			w_mob.Write((UInt32)0);
			w_mob.Write(UInt32.Parse(vDayX.Text));
			w_mob.Write(UInt32.Parse(vDayY.Text));
			w_mob.Write(Single.Parse(vDayOfsX.Text));
			w_mob.Write(Single.Parse(vDayOfsY.Text));
			//w_mob.Write((UInt32)204);
			//w_mob.Write((UInt32)0x0012EB28);
			w_mob.Write(Int32.Parse(vDayJP.Text));
			w_mob.Write((UInt32)0);
			w_mob.Write(filler);

			// Night point
			w_mob.Write(UInt32.Parse(vNightMap.Text));
			//w_mob.Write((UInt32)0x77F442AA);
			w_mob.Write((UInt32)0);
			w_mob.Write(UInt32.Parse(vNightX.Text));
			w_mob.Write(UInt32.Parse(vNightY.Text));
			w_mob.Write(Single.Parse(vNightOfsX.Text));
			w_mob.Write(Single.Parse(vNightOfsY.Text));
			//w_mob.Write((UInt32)208);
			//w_mob.Write((UInt32)0x0012EB28);
			w_mob.Write(Int32.Parse(vNightJP.Text));
			w_mob.Write((UInt32)0);
			w_mob.Write(filler);

            if (pScoutPoint.Checked)
            {
                w_mob.Write(UInt32.Parse(vScoutMap.Text));
                w_mob.Write((UInt32)0);
                w_mob.Write(UInt32.Parse(vScoutX.Text));
                w_mob.Write(UInt32.Parse(vScoutY.Text));
                w_mob.Write(Single.Parse(vScoutOfsX.Text));
                w_mob.Write(Single.Parse(vScoutOfsY.Text));
                w_mob.Write(Int32.Parse(vScoutJP.Text));
                w_mob.Write((UInt32)0);
                w_mob.Write(filler);
            }

			// Post-structure
            if (!pScoutPoint.Checked)
                Helper.GetComp2Ex(w_mob, 0x14);
            else
                Helper.GetComp2Ex(w_mob, 0x1E);

			//w_mob.Write((UInt32)0x02);
			//w_mob.Write((UInt32)0x0FFFFF);
			//w_mob.Write((UInt32)0x00);
		}

		private void LoadNPCStandpoints(BinaryReader r_mob)
		{
			pStandpoints.Checked = true;

			// Skip the pre-struct
            r_mob.ReadByte();
            r_mob.ReadUInt32();
			uint type = r_mob.ReadUInt32();

			// Load the SARC thingie
			SAR_POS_STN = r_mob.ReadUInt32();

			// Load standpoints
			vDayMap.Text = r_mob.ReadUInt32().ToString();
			vDayFlags.Text = r_mob.ReadUInt32().ToString();
			vDayX.Text = r_mob.ReadUInt32().ToString();
			vDayY.Text = r_mob.ReadUInt32().ToString();
            vDayOfsX.Text = r_mob.ReadSingle().ToString(); // -4
            vDayOfsY.Text = r_mob.ReadSingle().ToString(); // -4
            vDayJP.Text = r_mob.ReadInt32().ToString(); // -4
			r_mob.ReadBytes(52);

			vNightMap.Text = r_mob.ReadUInt32().ToString();
			vNightFlags.Text = r_mob.ReadUInt32().ToString();
			vNightX.Text = r_mob.ReadUInt32().ToString();
			vNightY.Text = r_mob.ReadUInt32().ToString();
            vNightOfsX.Text = r_mob.ReadSingle().ToString(); // -4
            vNightOfsY.Text = r_mob.ReadSingle().ToString(); // -4
            vNightJP.Text = r_mob.ReadInt32().ToString(); // -4
			r_mob.ReadBytes(52);

            if (type == 0x1E)
            {
                vScoutMap.Text = r_mob.ReadUInt32().ToString();
                r_mob.ReadUInt32().ToString();
                vScoutX.Text = r_mob.ReadUInt32().ToString();
                vScoutY.Text = r_mob.ReadUInt32().ToString();
                vScoutOfsX.Text = r_mob.ReadSingle().ToString(); // -4
                vScoutOfsY.Text = r_mob.ReadSingle().ToString(); // -4
                vScoutJP.Text = r_mob.ReadInt32().ToString(); // -4
                r_mob.ReadBytes(52);
                pScoutPoint.Checked = true;
            }
            else
                pScoutPoint.Checked = false;

			// Skip the post-struct
			r_mob.ReadBytes(12);
		}

        private void LoadNPCFactions(BinaryReader r_mob)
        {
            pFactions.Checked = true;

            // try to detect whether the pre-struct is empty
            byte LEADING_BYTE = r_mob.ReadByte();
            
            if (LEADING_BYTE != 1)
            {
                vFactions.Items.Clear();
                return;
            }

            r_mob.ReadUInt32();
            uint count = r_mob.ReadUInt32();
            SAR_POS_FCN = r_mob.ReadUInt32();

            // Load factions
            vFactions.Items.Clear();
            for (int i = 0; i < count; i++)
                vFactions.Items.Add(r_mob.ReadUInt32().ToString());

            // Skip the post-struct
            int post_struct_idx = r_mob.ReadInt32();

            for (int j = 0; j < post_struct_idx; j++)
                r_mob.ReadInt32();
        }

        private void LoadNPCWaypoints(BinaryReader r_mob)
		{
			// Ensure that structures are clear
			NPC_WAYPOINTS.Clear();
			vWaypoints.Items.Clear();
			pWaypoints.Checked = true;

			// Skip past ignored structures (auto-detected)
			r_mob.ReadByte(); // 0x01
			r_mob.ReadBytes(4); // 0x08
			int num_ents = r_mob.ReadInt32(); // num_ents (now used to predict the structure ending)
            int tot_size = num_ents * 8; // bytes to read since SARC

			// Load SARC
			SAR_POS_WAY = r_mob.ReadUInt32();

			// Pre-structure: detect num_way
            int bytes_read = 16;
            int num_way = r_mob.ReadInt32();            
			r_mob.ReadBytes(12); // skip past entries that are zeroed out

			// Load waypoint info
			for (int i=0; i<num_way; i++)
			{
				Helper.WaypointInfo w_loaded = Helper.LoadWaypoint(r_mob);
                bytes_read += 64;

				NPC_WAYPOINTS.Add(w_loaded);
                vWaypoints.Items.Add("(" + w_loaded.X.ToString() + ", " + w_loaded.Y.ToString() + "); #" + w_loaded.anim1 + ";#" + w_loaded.anim2 + ";#" + w_loaded.anim3 + ";#" + w_loaded.anim4 + ";#" + w_loaded.anim5 + ";#" + w_loaded.anim6 + ";#" + w_loaded.anim7 + ";#" + w_loaded.anim8 + "; ROT=" + w_loaded.Rotation + "; DELAY=" + w_loaded.delay);
			}

            // Attempt to predict extra structure overload and skip it
            int bytes_to_skip = tot_size - bytes_read;
            if (bytes_to_skip > 0)
                for (int k = 0; k < bytes_to_skip; k++)
                    r_mob.ReadByte();

			// Skip past the post-structure
			int post_struct_idx = r_mob.ReadInt32();

			for (int j=0; j<post_struct_idx; j++)
				r_mob.ReadInt32();
		}

		private void pReach_CheckedChanged(object sender, System.EventArgs e)
		{
			vReach.Enabled = pReach.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 317, vReach.Enabled);		
		}

		private void pRotation_CheckedChanged(object sender, System.EventArgs e)
		{
			vRotation.Enabled = pRotation.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 33, vRotation.Enabled);
		}

		private void btnChgGUID_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to assign a new GUID to the current mobile object?\n\nHINT: This may be used to duplicate a mobile object.\nNOTE: Don't duplicate NPC and containers with inventory! This may have unpredictable results in the game!","Please confirm GUID modification",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;

			Helper.MOB_GenerateGUID(out MOB_GUID, out MOB_GUID_BYTES);
			MobileName.Text = MOB_GUID;
		}

		private void SetInterfaceState(bool state)
		{
			vWaypoints.Items.Clear();
			Prototype.Enabled = state;
			MobType.Enabled = state;
			LocationX.Enabled = state;
			LocationY.Enabled = state;
			pHP.Enabled = state;
			pStandpoints.Enabled = state;
			pSDDC.Enabled = state;
			pHPAdj.Enabled = state;
			pHPDmg.Enabled = state;
			pSpdWalk.Enabled = state;
			pSpdRun.Enabled = state;
			pACAdj.Enabled = state;
			pObjName.Enabled = state;
			pAmmoAmt.Enabled = state;
			pWeight.Enabled = state;
			pWorth.Enabled = state;
			pEffName.Enabled = state;
			pACMaxDex.Enabled = state;
			pSpellFail.Enabled = state;
			pArmorChk.Enabled = state;
			pItemAmt.Enabled = state;
			pTransparency.Enabled = state;
			btnChgGUID.Enabled = state;
			btnSaveMob.Enabled = state;
			btnEmbed.Enabled = state;
			pRotation.Enabled = state;
			tabProps.Enabled = state;
			pLockDC.Enabled = state;
			pPLockDC.Enabled = state;
			pPKeyID.Enabled = state;
			pTeleDest.Enabled = state;
			pTeleMap.Enabled = state;
			pInvSlot.Enabled = state;
			pParent.Enabled = state;
			pSubInv.Enabled = state;
			vSubInv.Enabled = pSubInv.Checked;
			pObjFlags.Enabled = state;
			pFaction.Enabled = state;
			pInvenSource.Enabled = state;
			pChestInv.Enabled = state;
			pRadius.Enabled = state;
			pHeight.Enabled = state;
			pReach.Enabled = state;
			pMoneyQuantity.Enabled = state;
			vMoneyQuantity.Enabled = pMoneyQuantity.Checked;
			vChestInv.Enabled = pChestInv.Checked;	
			btnAddChestInv.Enabled = pChestInv.Checked;
			btnRemoveChestInv.Enabled = pChestInv.Checked;
			btnAddChestInv2.Enabled = pChestInv.Checked;
			ChestInvProtos.Enabled = pChestInv.Checked;
			pChestInvDel.Enabled = pChestInv.Checked;
			btnChestInvGUID.Enabled = pChestInv.Checked;
			tChestMoneyAmt.Enabled = pChestInv.Checked;
			vNpcInv.Enabled = pNpcInv.Checked;	
			btnAddNpcInv.Enabled = pNpcInv.Checked;
			btnRemoveNpcInv.Enabled = pNpcInv.Checked;
			btnAddNpcInv2.Enabled = pNpcInv.Checked;
			NpcInvProtos.Enabled = pNpcInv.Checked;
			pNpcInvDel.Enabled = pNpcInv.Checked;
			btnNpcInvGUID.Enabled = pNpcInv.Checked;
			tNpcMoneyAmt.Enabled = pNpcInv.Checked;
			pOffsetX.Enabled = state;
			pOffsetY.Enabled = state;
			pOfsZ.Enabled = state;
			pTeleport.Enabled = state;
			vTeleport.Enabled = pTeleport.Checked;
			pModelScale.Enabled = state;
			pKeyID.Enabled = state;
			pKeyID2.Enabled = state;
			pNpcInvenSource.Enabled = state;
			vNpcInvenSource.Enabled = pNpcInvenSource.Checked;
			pNpcInvSlot.Enabled = pNpcInv.Checked;
			vNpcInvSlot.Enabled = pNpcInv.Checked;
            vNpcInvFill.Enabled = pNpcInv.Checked;
			pChestInvSlot.Enabled = pChestInv.Checked;
			vChestInvSlot.Enabled = pChestInv.Checked;
            vChestInvFill.Enabled = pChestInv.Checked;
            vCleanChestInv.Enabled = pChestInv.Checked;
            vCleanNpcInv.Enabled = pNpcInv.Checked;
			pDispatcher.Enabled = state;
			pObjFlag00.Enabled = pObjFlags.Checked;
			pObjFlag01.Enabled = pObjFlags.Checked;
			pObjFlag02.Enabled = pObjFlags.Checked;
			pObjFlag03.Enabled = pObjFlags.Checked;
			pObjFlag04.Enabled = pObjFlags.Checked;
			pObjFlag05.Enabled = pObjFlags.Checked;
			pObjFlag06.Enabled = pObjFlags.Checked;
			pObjFlag07.Enabled = pObjFlags.Checked;
			pObjFlag08.Enabled = pObjFlags.Checked;
			pObjFlag09.Enabled = pObjFlags.Checked;
			pObjFlag10.Enabled = pObjFlags.Checked;
			pObjFlag11.Enabled = pObjFlags.Checked;
			pObjFlag12.Enabled = pObjFlags.Checked;
			pObjFlag13.Enabled = pObjFlags.Checked;
			pObjFlag14.Enabled = pObjFlags.Checked;
			pObjFlag15.Enabled = pObjFlags.Checked;
			pObjFlag16.Enabled = pObjFlags.Checked;
			pObjFlag17.Enabled = pObjFlags.Checked;
			pObjFlag18.Enabled = pObjFlags.Checked;
			pObjFlag19.Enabled = pObjFlags.Checked;
			pObjFlag20.Enabled = pObjFlags.Checked;
			pObjFlag21.Enabled = pObjFlags.Checked;
			pObjFlag22.Enabled = pObjFlags.Checked;
			pObjFlag23.Enabled = pObjFlags.Checked;
			pObjFlag24.Enabled = pObjFlags.Checked;
			pObjFlag25.Enabled = pObjFlags.Checked;
			pObjFlag26.Enabled = pObjFlags.Checked;
			pObjFlag27.Enabled = pObjFlags.Checked;
			pObjFlag28.Enabled = pObjFlags.Checked;
			pObjFlag29.Enabled = pObjFlags.Checked;
			pObjFlag30.Enabled = pObjFlags.Checked;
			pObjFlag31.Enabled = pObjFlags.Checked;
			p_OCOF.Enabled = state;
			v_CFlag00.Enabled = p_OCOF.Checked;
			v_CFlag01.Enabled = p_OCOF.Checked;
			v_CFlag02.Enabled = p_OCOF.Checked;
			v_CFlag03.Enabled = p_OCOF.Checked;
			v_CFlag04.Enabled = p_OCOF.Checked;
			v_CFlag05.Enabled = p_OCOF.Checked;
			v_CFlag06.Enabled = p_OCOF.Checked;
			v_CFlag07.Enabled = p_OCOF.Checked;
			v_CFlag08.Enabled = p_OCOF.Checked;
			v_CFlag09.Enabled = p_OCOF.Checked;
			v_CFlag10.Enabled = p_OCOF.Checked;
			v_CFlag11.Enabled = p_OCOF.Checked;
			v_CFlag12.Enabled = p_OCOF.Checked;
			p_OPF.Enabled = state;
			v_PFlag00.Enabled = p_OPF.Checked;
			v_PFlag01.Enabled = p_OPF.Checked;
			v_PFlag02.Enabled = p_OPF.Checked;
			v_PFlag03.Enabled = p_OPF.Checked;
			v_PFlag04.Enabled = p_OPF.Checked;
			v_PFlag05.Enabled = p_OPF.Checked;
			v_PFlag06.Enabled = p_OPF.Checked;
			v_PFlag07.Enabled = p_OPF.Checked;
			v_PFlag08.Enabled = p_OPF.Checked;
			v_PFlag09.Enabled = p_OPF.Checked;
			p_ONF.Enabled = state;
			v_NFlag00.Enabled = p_ONF.Checked;
			v_NFlag01.Enabled = p_ONF.Checked;
			v_NFlag02.Enabled = p_ONF.Checked;
			v_NFlag03.Enabled = p_ONF.Checked;
			v_NFlag04.Enabled = p_ONF.Checked;
			v_NFlag05.Enabled = p_ONF.Checked;
			v_NFlag06.Enabled = p_ONF.Checked;
			v_NFlag07.Enabled = p_ONF.Checked;
			v_NFlag08.Enabled = p_ONF.Checked;
			v_NFlag09.Enabled = p_ONF.Checked;
			v_NFlag10.Enabled = p_ONF.Checked;
			v_NFlag11.Enabled = p_ONF.Checked;
			v_NFlag12.Enabled = p_ONF.Checked;
			v_NFlag13.Enabled = p_ONF.Checked;
			v_NFlag14.Enabled = p_ONF.Checked;
			v_NFlag15.Enabled = p_ONF.Checked;
			v_NFlag16.Enabled = p_ONF.Checked;
			v_NFlag17.Enabled = p_ONF.Checked;
			v_NFlag18.Enabled = p_ONF.Checked;
			v_NFlag19.Enabled = p_ONF.Checked;
			v_NFlag20.Enabled = p_ONF.Checked;
			v_NFlag21.Enabled = p_ONF.Checked;
			v_NFlag22.Enabled = p_ONF.Checked;
			v_NFlag23.Enabled = p_ONF.Checked;
			v_NFlag24.Enabled = p_ONF.Checked;
			v_NFlag25.Enabled = p_ONF.Checked;
			v_NFlag26.Enabled = p_ONF.Checked;
			v_NFlag27.Enabled = p_ONF.Checked;
			v_NFlag28.Enabled = p_ONF.Checked;
			v_NFlag29.Enabled = p_ONF.Checked;
			v_NFlag30.Enabled = p_ONF.Checked;
			v_NFlag31.Enabled = p_ONF.Checked;
			p_OCF.Enabled = state;
			v_C1Flag00.Enabled = p_OCF.Checked;
			v_C1Flag01.Enabled = p_OCF.Checked;
			v_C1Flag02.Enabled = p_OCF.Checked;
			v_C1Flag03.Enabled = p_OCF.Checked;
			v_C1Flag04.Enabled = p_OCF.Checked;
			v_C1Flag05.Enabled = p_OCF.Checked;
			v_C1Flag06.Enabled = p_OCF.Checked;
			v_C1Flag07.Enabled = p_OCF.Checked;
			v_C1Flag08.Enabled = p_OCF.Checked;
			v_C1Flag09.Enabled = p_OCF.Checked;
			v_C1Flag10.Enabled = p_OCF.Checked;
			v_C1Flag11.Enabled = p_OCF.Checked;
			v_C1Flag12.Enabled = p_OCF.Checked;
			v_C1Flag13.Enabled = p_OCF.Checked;
			v_C1Flag14.Enabled = p_OCF.Checked;
			v_C1Flag15.Enabled = p_OCF.Checked;
			v_C1Flag16.Enabled = p_OCF.Checked;
			v_C1Flag17.Enabled = p_OCF.Checked;
			v_C1Flag18.Enabled = p_OCF.Checked;
			v_C1Flag19.Enabled = p_OCF.Checked;
			v_C1Flag20.Enabled = p_OCF.Checked;
			v_C1Flag21.Enabled = p_OCF.Checked;
			v_C1Flag22.Enabled = p_OCF.Checked;
			v_C1Flag23.Enabled = p_OCF.Checked;
			v_C1Flag24.Enabled = p_OCF.Checked;
			v_C1Flag25.Enabled = p_OCF.Checked;
			v_C1Flag26.Enabled = p_OCF.Checked;
			v_C1Flag27.Enabled = p_OCF.Checked;
			v_C1Flag28.Enabled = p_OCF.Checked;
			v_C1Flag29.Enabled = p_OCF.Checked;
			v_C1Flag30.Enabled = p_OCF.Checked;
			v_C1Flag31.Enabled = p_OCF.Checked;
			p_OIF.Enabled = state;
			pItmFlag00.Enabled = p_OIF.Checked;
			pItmFlag01.Enabled = p_OIF.Checked;
			pItmFlag02.Enabled = p_OIF.Checked;
			pItmFlag03.Enabled = p_OIF.Checked;
			pItmFlag04.Enabled = p_OIF.Checked;
			pItmFlag05.Enabled = p_OIF.Checked;
			pItmFlag06.Enabled = p_OIF.Checked;
			pItmFlag07.Enabled = p_OIF.Checked;
			pItmFlag08.Enabled = p_OIF.Checked;
			pItmFlag09.Enabled = p_OIF.Checked;
			pItmFlag10.Enabled = p_OIF.Checked;
			pItmFlag11.Enabled = p_OIF.Checked;
			pItmFlag12.Enabled = p_OIF.Checked;
			pItmFlag13.Enabled = p_OIF.Checked;
			pItmFlag14.Enabled = p_OIF.Checked;
			pItmFlag15.Enabled = p_OIF.Checked;
			pItmFlag16.Enabled = p_OIF.Checked;
			pItmFlag17.Enabled = p_OIF.Checked;
			pItmFlag18.Enabled = p_OIF.Checked;
			pItmFlag19.Enabled = p_OIF.Checked;
			pItmFlag20.Enabled = p_OIF.Checked;
			pItmFlag21.Enabled = p_OIF.Checked;
			pItmFlag22.Enabled = p_OIF.Checked;
			pItmFlag23.Enabled = p_OIF.Checked;
			pItmFlag24.Enabled = p_OIF.Checked;
			pItmFlag25.Enabled = p_OIF.Checked;
			pItmFlag26.Enabled = p_OIF.Checked;
			p_OCF2.Enabled = state;
			v_C2Flag00.Enabled = p_OCF2.Checked;
			v_C2Flag01.Enabled = p_OCF2.Checked;
			v_C2Flag02.Enabled = p_OCF2.Checked;
			v_C2Flag03.Enabled = p_OCF2.Checked;
			v_C2Flag04.Enabled = p_OCF2.Checked;
			v_C2Flag05.Enabled = p_OCF2.Checked;
			v_C2Flag06.Enabled = p_OCF2.Checked;
			v_C2Flag07.Enabled = p_OCF2.Checked;
			v_C2Flag08.Enabled = p_OCF2.Checked;
			v_C2Flag09.Enabled = p_OCF2.Checked;
			v_C2Flag10.Enabled = p_OCF2.Checked;
			v_C2Flag11.Enabled = p_OCF2.Checked;
			v_C2Flag12.Enabled = p_OCF2.Checked;
			v_C2Flag13.Enabled = p_OCF2.Checked;
			v_C2Flag14.Enabled = p_OCF2.Checked;
			v_C2Flag15.Enabled = p_OCF2.Checked;
			v_C2Flag16.Enabled = p_OCF2.Checked;
			v_C2Flag17.Enabled = p_OCF2.Checked;
			v_C2Flag18.Enabled = p_OCF2.Checked;
			v_C2Flag19.Enabled = p_OCF2.Checked;
			v_C2Flag20.Enabled = p_OCF2.Checked;
			v_C2Flag21.Enabled = p_OCF2.Checked;
			v_C2Flag22.Enabled = p_OCF2.Checked;
			v_C2Flag23.Enabled = p_OCF2.Checked;
			v_C2Flag24.Enabled = p_OCF2.Checked;
			v_C2Flag25.Enabled = p_OCF2.Checked;
			v_C2Flag26.Enabled = p_OCF2.Checked;
			v_C2Flag27.Enabled = p_OCF2.Checked;
			p_OARF.Enabled = state;
			v_OAFlag00.Enabled = p_OARF.Checked;
			v_OAFlag01.Enabled = p_OARF.Checked;
			v_OAFlag02.Enabled = p_OARF.Checked;
			v_OAFlag03.Enabled = p_OARF.Checked;
			v_OAFlag04.Enabled = p_OARF.Checked;
			p_OWF.Enabled = state;
			v_WFlag00.Enabled = p_OWF.Checked;
			v_WFlag01.Enabled = p_OWF.Checked;
			v_WFlag02.Enabled = p_OWF.Checked;
			v_WFlag03.Enabled = p_OWF.Checked;
			v_WFlag04.Enabled = p_OWF.Checked;
			v_WFlag05.Enabled = p_OWF.Checked;
			v_WFlag06.Enabled = p_OWF.Checked;
			v_WFlag07.Enabled = p_OWF.Checked;
			v_WFlag08.Enabled = p_OWF.Checked;
			v_WFlag09.Enabled = p_OWF.Checked;
			v_WFlag10.Enabled = p_OWF.Checked;
			v_WFlag11.Enabled = p_OWF.Checked;
			v_WFlag12.Enabled = p_OWF.Checked;
			p_OSCF.Enabled = state;
			v_SFlag00.Enabled = p_OSCF.Checked;
			v_SFlag01.Enabled = p_OSCF.Checked;
			v_SFlag02.Enabled = p_OSCF.Checked;
			v_SFlag03.Enabled = p_OSCF.Checked;
			v_SFlag04.Enabled = p_OSCF.Checked;
			v_SFlag05.Enabled = p_OSCF.Checked;
			v_SFlag06.Enabled = p_OSCF.Checked;
			v_SFlag07.Enabled = p_OSCF.Checked;
			v_SFlag08.Enabled = p_OSCF.Checked;
			v_SFlag09.Enabled = p_OSCF.Checked;
			v_SFlag10.Enabled = p_OSCF.Checked;
			v_SFlag11.Enabled = p_OSCF.Checked;
			v_SFlag12.Enabled = p_OSCF.Checked;
			p_OSDF.Enabled = state;
			v_SDFlag00.Enabled = p_OSDF.Checked;
			v_SDFlag01.Enabled = p_OSDF.Checked;
			v_SDFlag02.Enabled = p_OSDF.Checked;
			v_SDFlag03.Enabled = p_OSDF.Checked;
			v_SDFlag04.Enabled = p_OSDF.Checked;
			v_SDFlag05.Enabled = p_OSDF.Checked;
			v_SDFlag06.Enabled = p_OSDF.Checked;
			v_SDFlag07.Enabled = p_OSDF.Checked;
			v_SDFlag08.Enabled = p_OSDF.Checked;
			v_SDFlag09.Enabled = p_OSDF.Checked;
			v_SDFlag10.Enabled = p_OSDF.Checked;
			v_SDFlag11.Enabled = p_OSDF.Checked;
			v_SDFlag12.Enabled = p_OSDF.Checked;
			v_SDFlag13.Enabled = p_OSDF.Checked;
			v_SDFlag14.Enabled = p_OSDF.Checked;
			v_SDFlag15.Enabled = p_OSDF.Checked;
			v_SDFlag16.Enabled = p_OSDF.Checked;
			v_SDFlag17.Enabled = p_OSDF.Checked;
			v_SDFlag18.Enabled = p_OSDF.Checked;
			v_SDFlag19.Enabled = p_OSDF.Checked;
			v_SDFlag20.Enabled = p_OSDF.Checked;
			v_SDFlag21.Enabled = p_OSDF.Checked;
			v_SDFlag22.Enabled = p_OSDF.Checked;
			v_SDFlag23.Enabled = p_OSDF.Checked;
			v_SDFlag24.Enabled = p_OSDF.Checked;
			v_SDFlag25.Enabled = p_OSDF.Checked;
			v_SDFlag26.Enabled = p_OSDF.Checked;
			v_SDFlag27.Enabled = p_OSDF.Checked;
			v_SDFlag28.Enabled = p_OSDF.Checked;
			v_SDFlag29.Enabled = p_OSDF.Checked;
			v_SDFlag30.Enabled = p_OSDF.Checked;
			v_SDFlag31.Enabled = p_OSDF.Checked;
			pWaypoints.Enabled = state;
			vWaypoints.Enabled = pWaypoints.Checked;
			vWayX.Enabled = pWaypoints.Checked;
			vWayY.Enabled = pWaypoints.Checked;
            vWayRot.Enabled = pWaypoints.Checked;
            vWayDelay.Enabled = pWaypoints.Checked;
            cRotWpt.Enabled = pWaypoints.Checked;
            cDelayWpt.Enabled = pWaypoints.Checked;
            vWayAnim1.Enabled = pWaypoints.Checked;
            vWayAnim2.Enabled = pWaypoints.Checked;
            vWayAnim3.Enabled = pWaypoints.Checked;
            vWayAnim4.Enabled = pWaypoints.Checked;
            vWayAnim5.Enabled = pWaypoints.Checked;
            vWayAnim6.Enabled = pWaypoints.Checked;
            vWayAnim7.Enabled = pWaypoints.Checked;
            vWayAnim8.Enabled = pWaypoints.Checked;
            cAnimWpt.Enabled = pWaypoints.Checked;
			btnWayAdd.Enabled = pWaypoints.Checked;
			btnWayDel.Enabled = pWaypoints.Checked;
		}
	
		private void btnWayAdd_Click(object sender, System.EventArgs e)
		{
			try
			{
				uint.Parse(vWayX.Text);
				uint.Parse(vWayY.Text);
                byte.Parse(vWayAnim1.Text);
                byte.Parse(vWayAnim2.Text);
                byte.Parse(vWayAnim3.Text);
                byte.Parse(vWayAnim4.Text);
                byte.Parse(vWayAnim5.Text);
                byte.Parse(vWayAnim6.Text);
                byte.Parse(vWayAnim7.Text);
                byte.Parse(vWayAnim8.Text);
			}
			catch (Exception)
			{
				MessageBox.Show("Error defining waypoint parameters!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			// Add a WaypointInfo structure to the array
			NPC_WAYPOINTS.Add(Helper.CreateWaypoint(uint.Parse(vWayX.Text), uint.Parse(vWayY.Text), byte.Parse(vWayAnim1.Text), byte.Parse(vWayAnim2.Text), byte.Parse(vWayAnim3.Text),  byte.Parse(vWayAnim4.Text),  byte.Parse(vWayAnim5.Text),  byte.Parse(vWayAnim6.Text),  byte.Parse(vWayAnim7.Text),  byte.Parse(vWayAnim8.Text), float.Parse(vWayRot.Text), uint.Parse(vWayDelay.Text), cAnimWpt.Checked, cRotWpt.Checked, cDelayWpt.Checked));
            vWaypoints.Items.Add("(" + vWayX.Text + ", " + vWayY.Text + "); #" + vWayAnim1.Text + ";#" + vWayAnim2.Text + ";#" + vWayAnim3.Text + ";#" + vWayAnim4.Text + ";#" + vWayAnim5.Text + ";#" + vWayAnim6.Text + ";#" + vWayAnim7.Text + ";#" + vWayAnim8.Text+"; ROT="+vWayRot.Text+"; DELAY="+vWayDelay.Text);
		}

		private void btnWayDel_Click(object sender, System.EventArgs e)
		{
			if (vWaypoints.SelectedIndex == -1)
				return;

			// Delete a waypoint
			NPC_WAYPOINTS.RemoveAt(vWaypoints.SelectedIndex);
			vWaypoints.Items.RemoveAt(vWaypoints.SelectedIndex);
		}

		private uint GetContainerFlags()
		{
			uint FLAGS = 0;
			if (v_CFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_CFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_CFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_CFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_CFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_CFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_CFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_CFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_CFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_CFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_CFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_CFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_CFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetSecretDoorFlags()
		{
			uint FLAGS = 0;
			if (v_SDFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_SDFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_SDFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_SDFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_SDFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_SDFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_SDFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_SDFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_SDFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_SDFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_SDFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_SDFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_SDFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (v_SDFlag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (v_SDFlag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (v_SDFlag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (v_SDFlag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (v_SDFlag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (v_SDFlag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (v_SDFlag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (v_SDFlag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (v_SDFlag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (v_SDFlag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (v_SDFlag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (v_SDFlag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (v_SDFlag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (v_SDFlag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);
			if (v_SDFlag27.Checked)
				FLAGS += (uint)Math.Pow(2, 27);
			if (v_SDFlag28.Checked)
				FLAGS += (uint)Math.Pow(2, 28);
			if (v_SDFlag29.Checked)
				FLAGS += (uint)Math.Pow(2, 29);
			if (v_SDFlag30.Checked)
				FLAGS += (uint)Math.Pow(2, 30);
			if (v_SDFlag31.Checked)
				FLAGS += (uint)Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetWeaponFlags()
		{
			uint FLAGS = 0;
			if (v_WFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_WFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_WFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_WFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_WFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_WFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_WFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_WFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_WFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_WFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_WFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_WFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_WFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetSceneryFlags()
		{
			uint FLAGS = 0;
			if (v_SFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_SFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_SFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_SFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_SFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_SFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_SFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_SFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_SFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_SFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_SFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_SFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_SFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetArmorFlags()
		{
			uint FLAGS = 0;
			if (v_OAFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_OAFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_OAFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_OAFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_OAFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);

			return FLAGS;
		}

		private uint GetNPCFlags()
		{
			uint FLAGS = 0;
			if (v_NFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_NFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_NFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_NFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_NFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_NFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_NFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_NFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_NFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_NFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_NFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_NFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_NFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (v_NFlag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (v_NFlag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (v_NFlag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (v_NFlag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (v_NFlag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (v_NFlag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (v_NFlag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (v_NFlag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (v_NFlag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (v_NFlag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (v_NFlag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (v_NFlag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (v_NFlag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (v_NFlag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);
			if (v_NFlag27.Checked)
				FLAGS += (uint)Math.Pow(2, 27);
			if (v_NFlag28.Checked)
				FLAGS += (uint)Math.Pow(2, 28);
			if (v_NFlag29.Checked)
				FLAGS += (uint)Math.Pow(2, 29);
			if (v_NFlag30.Checked)
				FLAGS += (uint)Math.Pow(2, 30);
			if (v_NFlag31.Checked)
				FLAGS += (uint)Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetItemFlags()
		{
			uint FLAGS = 0;
			if (pItmFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (pItmFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (pItmFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (pItmFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (pItmFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (pItmFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (pItmFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (pItmFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (pItmFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (pItmFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (pItmFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (pItmFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (pItmFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (pItmFlag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (pItmFlag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (pItmFlag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (pItmFlag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (pItmFlag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (pItmFlag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (pItmFlag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (pItmFlag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (pItmFlag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (pItmFlag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (pItmFlag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (pItmFlag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (pItmFlag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (pItmFlag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);

			return FLAGS;
		}

		private uint GetCritterFlags1()
		{
			uint FLAGS = 0;
			if (v_C1Flag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_C1Flag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_C1Flag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_C1Flag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_C1Flag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_C1Flag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_C1Flag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_C1Flag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_C1Flag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_C1Flag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_C1Flag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_C1Flag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_C1Flag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (v_C1Flag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (v_C1Flag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (v_C1Flag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (v_C1Flag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (v_C1Flag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (v_C1Flag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (v_C1Flag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (v_C1Flag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (v_C1Flag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (v_C1Flag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (v_C1Flag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (v_C1Flag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (v_C1Flag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (v_C1Flag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);
			if (v_C1Flag27.Checked)
				FLAGS += (uint)Math.Pow(2, 27);
			if (v_C1Flag28.Checked)
				FLAGS += (uint)Math.Pow(2, 28);
			if (v_C1Flag29.Checked)
				FLAGS += (uint)Math.Pow(2, 29);
			if (v_C1Flag30.Checked)
				FLAGS += (uint)Math.Pow(2, 30);
			if (v_C1Flag31.Checked)
				FLAGS += (uint)Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetCritterFlags2()
		{
			uint FLAGS = 0;
			if (v_C2Flag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_C2Flag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_C2Flag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_C2Flag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_C2Flag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_C2Flag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_C2Flag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_C2Flag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_C2Flag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_C2Flag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (v_C2Flag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (v_C2Flag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (v_C2Flag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (v_C2Flag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (v_C2Flag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (v_C2Flag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (v_C2Flag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (v_C2Flag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (v_C2Flag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (v_C2Flag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (v_C2Flag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (v_C2Flag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (v_C2Flag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (v_C2Flag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (v_C2Flag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (v_C2Flag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (v_C2Flag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);
			if (v_C2Flag27.Checked)
				FLAGS += (uint)Math.Pow(2, 27);

			return FLAGS;
		}

		private uint GetPortalFlags()
		{
			uint FLAGS = 0;
			if (v_PFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (v_PFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (v_PFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (v_PFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (v_PFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (v_PFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (v_PFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (v_PFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (v_PFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (v_PFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);

			return FLAGS;
		}

		private uint GetObjectFlags()
		{
			uint FLAGS = 0;
			if (pObjFlag00.Checked)
				FLAGS += (uint)Math.Pow(2, 0);
			if (pObjFlag01.Checked)
				FLAGS += (uint)Math.Pow(2, 1);
			if (pObjFlag02.Checked)
				FLAGS += (uint)Math.Pow(2, 2);
			if (pObjFlag03.Checked)
				FLAGS += (uint)Math.Pow(2, 3);
			if (pObjFlag04.Checked)
				FLAGS += (uint)Math.Pow(2, 4);
			if (pObjFlag05.Checked)
				FLAGS += (uint)Math.Pow(2, 5);
			if (pObjFlag06.Checked)
				FLAGS += (uint)Math.Pow(2, 6);
			if (pObjFlag07.Checked)
				FLAGS += (uint)Math.Pow(2, 7);
			if (pObjFlag08.Checked)
				FLAGS += (uint)Math.Pow(2, 8);
			if (pObjFlag09.Checked)
				FLAGS += (uint)Math.Pow(2, 9);
			if (pObjFlag10.Checked)
				FLAGS += (uint)Math.Pow(2, 10);
			if (pObjFlag11.Checked)
				FLAGS += (uint)Math.Pow(2, 11);
			if (pObjFlag12.Checked)
				FLAGS += (uint)Math.Pow(2, 12);
			if (pObjFlag13.Checked)
				FLAGS += (uint)Math.Pow(2, 13);
			if (pObjFlag14.Checked)
				FLAGS += (uint)Math.Pow(2, 14);
			if (pObjFlag15.Checked)
				FLAGS += (uint)Math.Pow(2, 15);
			if (pObjFlag16.Checked)
				FLAGS += (uint)Math.Pow(2, 16);
			if (pObjFlag17.Checked)
				FLAGS += (uint)Math.Pow(2, 17);
			if (pObjFlag18.Checked)
				FLAGS += (uint)Math.Pow(2, 18);
			if (pObjFlag19.Checked)
				FLAGS += (uint)Math.Pow(2, 19);
			if (pObjFlag20.Checked)
				FLAGS += (uint)Math.Pow(2, 20);
			if (pObjFlag21.Checked)
				FLAGS += (uint)Math.Pow(2, 21);
			if (pObjFlag22.Checked)
				FLAGS += (uint)Math.Pow(2, 22);
			if (pObjFlag23.Checked)
				FLAGS += (uint)Math.Pow(2, 23);
			if (pObjFlag24.Checked)
				FLAGS += (uint)Math.Pow(2, 24);
			if (pObjFlag25.Checked)
				FLAGS += (uint)Math.Pow(2, 25);
			if (pObjFlag26.Checked)
				FLAGS += (uint)Math.Pow(2, 26);
			if (pObjFlag27.Checked)
				FLAGS += (uint)Math.Pow(2, 27);
			if (pObjFlag28.Checked)
				FLAGS += (uint)Math.Pow(2, 28);
			if (pObjFlag29.Checked)
				FLAGS += (uint)Math.Pow(2, 29);
			if (pObjFlag30.Checked)
				FLAGS += (uint)Math.Pow(2, 30);
			if (pObjFlag31.Checked)
				FLAGS += (uint)Math.Pow(2, 31);

			return FLAGS;
		}

		private void SetContainerFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_CFlag00.Checked = false;
			v_CFlag01.Checked = false;
			v_CFlag02.Checked = false;
			v_CFlag03.Checked = false;
			v_CFlag04.Checked = false;
			v_CFlag05.Checked = false;
			v_CFlag06.Checked = false;
			v_CFlag07.Checked = false;
			v_CFlag08.Checked = false;
			v_CFlag09.Checked = false;
			v_CFlag10.Checked = false;
			v_CFlag11.Checked = false;
			v_CFlag12.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_CFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_CFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_CFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_CFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_CFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_CFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_CFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_CFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_CFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_CFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_CFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_CFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_CFlag12.Checked = true;
		}

		private void SetSecretDoorFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_SDFlag00.Checked = false;
			v_SDFlag01.Checked = false;
			v_SDFlag02.Checked = false;
			v_SDFlag03.Checked = false;
			v_SDFlag04.Checked = false;
			v_SDFlag05.Checked = false;
			v_SDFlag06.Checked = false;
			v_SDFlag07.Checked = false;
			v_SDFlag08.Checked = false;
			v_SDFlag09.Checked = false;
			v_SDFlag10.Checked = false;
			v_SDFlag11.Checked = false;
			v_SDFlag12.Checked = false;
			v_SDFlag13.Checked = false;
			v_SDFlag14.Checked = false;
			v_SDFlag15.Checked = false;
			v_SDFlag16.Checked = false;
			v_SDFlag17.Checked = false;
			v_SDFlag18.Checked = false;
			v_SDFlag19.Checked = false;
			v_SDFlag20.Checked = false;
			v_SDFlag21.Checked = false;
			v_SDFlag22.Checked = false;
			v_SDFlag23.Checked = false;
			v_SDFlag24.Checked = false;
			v_SDFlag25.Checked = false;
			v_SDFlag26.Checked = false;
			v_SDFlag27.Checked = false;
			v_SDFlag28.Checked = false;
			v_SDFlag29.Checked = false;
			v_SDFlag30.Checked = false;
			v_SDFlag31.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_SDFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_SDFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_SDFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_SDFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_SDFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_SDFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_SDFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_SDFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_SDFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_SDFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_SDFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_SDFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_SDFlag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				v_SDFlag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				v_SDFlag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				v_SDFlag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				v_SDFlag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				v_SDFlag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				v_SDFlag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				v_SDFlag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				v_SDFlag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				v_SDFlag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				v_SDFlag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				v_SDFlag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				v_SDFlag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				v_SDFlag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				v_SDFlag26.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				v_SDFlag27.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 28) == TriState.True)
				v_SDFlag28.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 29) == TriState.True)
				v_SDFlag29.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 30) == TriState.True)
				v_SDFlag30.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 31) == TriState.True)
				v_SDFlag31.Checked = true;
		}

		private void SetSceneryFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_SFlag00.Checked = false;
			v_SFlag01.Checked = false;
			v_SFlag02.Checked = false;
			v_SFlag03.Checked = false;
			v_SFlag04.Checked = false;
			v_SFlag05.Checked = false;
			v_SFlag06.Checked = false;
			v_SFlag07.Checked = false;
			v_SFlag08.Checked = false;
			v_SFlag09.Checked = false;
			v_SFlag10.Checked = false;
			v_SFlag11.Checked = false;
			v_SFlag12.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_SFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_SFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_SFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_SFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_SFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_SFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_SFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_SFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_SFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_SFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_SFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_SFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_SFlag12.Checked = true;
		}

		private void p_OWF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_WFlag00.Enabled = p_OWF.Checked;
			v_WFlag01.Enabled = p_OWF.Checked;
			v_WFlag02.Enabled = p_OWF.Checked;
			v_WFlag03.Enabled = p_OWF.Checked;
			v_WFlag04.Enabled = p_OWF.Checked;
			v_WFlag05.Enabled = p_OWF.Checked;
			v_WFlag06.Enabled = p_OWF.Checked;
			v_WFlag07.Enabled = p_OWF.Checked;
			v_WFlag08.Enabled = p_OWF.Checked;
			v_WFlag09.Enabled = p_OWF.Checked;
			v_WFlag10.Enabled = p_OWF.Checked;
			v_WFlag11.Enabled = p_OWF.Checked;
			v_WFlag12.Enabled = p_OWF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 187, p_OWF.Enabled);		
		}

		private void SetWeaponFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_WFlag00.Checked = false;
			v_WFlag01.Checked = false;
			v_WFlag02.Checked = false;
			v_WFlag03.Checked = false;
			v_WFlag04.Checked = false;
			v_WFlag05.Checked = false;
			v_WFlag06.Checked = false;
			v_WFlag07.Checked = false;
			v_WFlag08.Checked = false;
			v_WFlag09.Checked = false;
			v_WFlag10.Checked = false;
			v_WFlag11.Checked = false;
			v_WFlag12.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_WFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_WFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_WFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_WFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_WFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_WFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_WFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_WFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_WFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_WFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_WFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_WFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_WFlag12.Checked = true;
		}
		
		private void p_OSCF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_SFlag00.Enabled = p_OSCF.Checked;
			v_SFlag01.Enabled = p_OSCF.Checked;
			v_SFlag02.Enabled = p_OSCF.Checked;
			v_SFlag03.Enabled = p_OSCF.Checked;
			v_SFlag04.Enabled = p_OSCF.Checked;
			v_SFlag05.Enabled = p_OSCF.Checked;
			v_SFlag06.Enabled = p_OSCF.Checked;
			v_SFlag07.Enabled = p_OSCF.Checked;
			v_SFlag08.Enabled = p_OSCF.Checked;
			v_SFlag09.Enabled = p_OSCF.Checked;
			v_SFlag10.Enabled = p_OSCF.Checked;
			v_SFlag11.Enabled = p_OSCF.Checked;
			v_SFlag12.Enabled = p_OSCF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 121, p_OSCF.Enabled);				
		}

		private void SetArmorFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_OAFlag00.Checked = false;
			v_OAFlag01.Checked = false;
			v_OAFlag02.Checked = false;
			v_OAFlag03.Checked = false;
			v_OAFlag04.Checked = false;
			
			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_OAFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_OAFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_OAFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_OAFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_OAFlag04.Checked = true;
		}

		private void SetNPCFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_NFlag00.Checked = false;
			v_NFlag01.Checked = false;
			v_NFlag02.Checked = false;
			v_NFlag03.Checked = false;
			v_NFlag04.Checked = false;
			v_NFlag05.Checked = false;
			v_NFlag06.Checked = false;
			v_NFlag07.Checked = false;
			v_NFlag08.Checked = false;
			v_NFlag09.Checked = false;
			v_NFlag10.Checked = false;
			v_NFlag11.Checked = false;
			v_NFlag12.Checked = false;
			v_NFlag13.Checked = false;
			v_NFlag14.Checked = false;
			v_NFlag15.Checked = false;
			v_NFlag16.Checked = false;
			v_NFlag17.Checked = false;
			v_NFlag18.Checked = false;
			v_NFlag19.Checked = false;
			v_NFlag20.Checked = false;
			v_NFlag21.Checked = false;
			v_NFlag22.Checked = false;
			v_NFlag23.Checked = false;
			v_NFlag24.Checked = false;
			v_NFlag25.Checked = false;
			v_NFlag26.Checked = false;
			v_NFlag27.Checked = false;
			v_NFlag28.Checked = false;
			v_NFlag29.Checked = false;
			v_NFlag30.Checked = false;
			v_NFlag31.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_NFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_NFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_NFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_NFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_NFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_NFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_NFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_NFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_NFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_NFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_NFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_NFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_NFlag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				v_NFlag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				v_NFlag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				v_NFlag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				v_NFlag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				v_NFlag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				v_NFlag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				v_NFlag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				v_NFlag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				v_NFlag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				v_NFlag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				v_NFlag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				v_NFlag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				v_NFlag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				v_NFlag26.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				v_NFlag27.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 28) == TriState.True)
				v_NFlag28.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 29) == TriState.True)
				v_NFlag29.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 30) == TriState.True)
				v_NFlag30.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 31) == TriState.True)
				v_NFlag31.Checked = true;
		}


		private void SetItemFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			pItmFlag00.Checked = false;
			pItmFlag01.Checked = false;
			pItmFlag02.Checked = false;
			pItmFlag03.Checked = false;
			pItmFlag04.Checked = false;
			pItmFlag05.Checked = false;
			pItmFlag06.Checked = false;
			pItmFlag07.Checked = false;
			pItmFlag08.Checked = false;
			pItmFlag09.Checked = false;
			pItmFlag10.Checked = false;
			pItmFlag11.Checked = false;
			pItmFlag12.Checked = false;
			pItmFlag13.Checked = false;
			pItmFlag14.Checked = false;
			pItmFlag15.Checked = false;
			pItmFlag16.Checked = false;
			pItmFlag17.Checked = false;
			pItmFlag18.Checked = false;
			pItmFlag19.Checked = false;
			pItmFlag20.Checked = false;
			pItmFlag21.Checked = false;
			pItmFlag22.Checked = false;
			pItmFlag23.Checked = false;
			pItmFlag24.Checked = false;
			pItmFlag25.Checked = false;
			pItmFlag26.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				pItmFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				pItmFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				pItmFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				pItmFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				pItmFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				pItmFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				pItmFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				pItmFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				pItmFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				pItmFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				pItmFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				pItmFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				pItmFlag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				pItmFlag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				pItmFlag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				pItmFlag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				pItmFlag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				pItmFlag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				pItmFlag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				pItmFlag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				pItmFlag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				pItmFlag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				pItmFlag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				pItmFlag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				pItmFlag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				pItmFlag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				pItmFlag26.Checked = true;
		}

		private void SetCritterFlags1(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_C1Flag00.Checked = false;
			v_C1Flag01.Checked = false;
			v_C1Flag02.Checked = false;
			v_C1Flag03.Checked = false;
			v_C1Flag04.Checked = false;
			v_C1Flag05.Checked = false;
			v_C1Flag06.Checked = false;
			v_C1Flag07.Checked = false;
			v_C1Flag08.Checked = false;
			v_C1Flag09.Checked = false;
			v_C1Flag10.Checked = false;
			v_C1Flag11.Checked = false;
			v_C1Flag12.Checked = false;
			v_C1Flag13.Checked = false;
			v_C1Flag14.Checked = false;
			v_C1Flag15.Checked = false;
			v_C1Flag16.Checked = false;
			v_C1Flag17.Checked = false;
			v_C1Flag18.Checked = false;
			v_C1Flag19.Checked = false;
			v_C1Flag20.Checked = false;
			v_C1Flag21.Checked = false;
			v_C1Flag22.Checked = false;
			v_C1Flag23.Checked = false;
			v_C1Flag24.Checked = false;
			v_C1Flag25.Checked = false;
			v_C1Flag26.Checked = false;
			v_C1Flag27.Checked = false;
			v_C1Flag28.Checked = false;
			v_C1Flag29.Checked = false;
			v_C1Flag30.Checked = false;
			v_C1Flag31.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_C1Flag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_C1Flag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_C1Flag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_C1Flag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_C1Flag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_C1Flag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_C1Flag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_C1Flag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_C1Flag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_C1Flag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_C1Flag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_C1Flag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_C1Flag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				v_C1Flag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				v_C1Flag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				v_C1Flag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				v_C1Flag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				v_C1Flag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				v_C1Flag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				v_C1Flag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				v_C1Flag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				v_C1Flag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				v_C1Flag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				v_C1Flag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				v_C1Flag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				v_C1Flag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				v_C1Flag26.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				v_C1Flag27.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 28) == TriState.True)
				v_C1Flag28.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 29) == TriState.True)
				v_C1Flag29.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 30) == TriState.True)
				v_C1Flag30.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 31) == TriState.True)
				v_C1Flag31.Checked = true;
		}

		private void SetCritterFlags2(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_C2Flag00.Checked = false;
			v_C2Flag01.Checked = false;
			v_C2Flag02.Checked = false;
			v_C2Flag03.Checked = false;
			v_C2Flag04.Checked = false;
			v_C2Flag05.Checked = false;
			v_C2Flag06.Checked = false;
			v_C2Flag07.Checked = false;
			v_C2Flag08.Checked = false;
			v_C2Flag09.Checked = false;
			v_C2Flag10.Checked = false;
			v_C2Flag11.Checked = false;
			v_C2Flag12.Checked = false;
			v_C2Flag13.Checked = false;
			v_C2Flag14.Checked = false;
			v_C2Flag15.Checked = false;
			v_C2Flag16.Checked = false;
			v_C2Flag17.Checked = false;
			v_C2Flag18.Checked = false;
			v_C2Flag19.Checked = false;
			v_C2Flag20.Checked = false;
			v_C2Flag21.Checked = false;
			v_C2Flag22.Checked = false;
			v_C2Flag23.Checked = false;
			v_C2Flag24.Checked = false;
			v_C2Flag25.Checked = false;
			v_C2Flag26.Checked = false;
			v_C2Flag27.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_C2Flag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_C2Flag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_C2Flag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_C2Flag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_C2Flag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_C2Flag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_C2Flag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_C2Flag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_C2Flag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_C2Flag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				v_C2Flag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				v_C2Flag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				v_C2Flag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				v_C2Flag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				v_C2Flag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				v_C2Flag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				v_C2Flag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				v_C2Flag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				v_C2Flag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				v_C2Flag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				v_C2Flag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				v_C2Flag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				v_C2Flag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				v_C2Flag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				v_C2Flag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				v_C2Flag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				v_C2Flag26.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				v_C2Flag27.Checked = true;
		}

		private void SetPortalFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			v_PFlag00.Checked = false;
			v_PFlag01.Checked = false;
			v_PFlag02.Checked = false;
			v_PFlag03.Checked = false;
			v_PFlag04.Checked = false;
			v_PFlag05.Checked = false;
			v_PFlag06.Checked = false;
			v_PFlag07.Checked = false;
			v_PFlag08.Checked = false;
			v_PFlag09.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				v_PFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				v_PFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				v_PFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				v_PFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				v_PFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				v_PFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				v_PFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				v_PFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				v_PFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				v_PFlag09.Checked = true;
		}

		private void SetObjectFlags(uint FlagsSource)
		{
			string Bitmap = Helper.GEN_UInt32_To_Bitmap(FlagsSource);

			pObjFlag00.Checked = false;
			pObjFlag01.Checked = false;
			pObjFlag02.Checked = false;
			pObjFlag03.Checked = false;
			pObjFlag04.Checked = false;
			pObjFlag05.Checked = false;
			pObjFlag06.Checked = false;
			pObjFlag07.Checked = false;
			pObjFlag08.Checked = false;
			pObjFlag09.Checked = false;
			pObjFlag10.Checked = false;
			pObjFlag11.Checked = false;
			pObjFlag12.Checked = false;
			pObjFlag13.Checked = false;
			pObjFlag14.Checked = false;
			pObjFlag15.Checked = false;
			pObjFlag16.Checked = false;
			pObjFlag17.Checked = false;
			pObjFlag18.Checked = false;
			pObjFlag19.Checked = false;
			pObjFlag20.Checked = false;
			pObjFlag21.Checked = false;
			pObjFlag22.Checked = false;
			pObjFlag23.Checked = false;
			pObjFlag24.Checked = false;
			pObjFlag25.Checked = false;
			pObjFlag26.Checked = false;
			pObjFlag27.Checked = false;
			pObjFlag28.Checked = false;
			pObjFlag29.Checked = false;
			pObjFlag30.Checked = false;
			pObjFlag31.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				pObjFlag00.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				pObjFlag01.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				pObjFlag02.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				pObjFlag03.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				pObjFlag04.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				pObjFlag05.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				pObjFlag06.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				pObjFlag07.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				pObjFlag08.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				pObjFlag09.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				pObjFlag10.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				pObjFlag11.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				pObjFlag12.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				pObjFlag13.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				pObjFlag14.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				pObjFlag15.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				pObjFlag16.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				pObjFlag17.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				pObjFlag18.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				pObjFlag19.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				pObjFlag20.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				pObjFlag21.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				pObjFlag22.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				pObjFlag23.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				pObjFlag24.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				pObjFlag25.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				pObjFlag26.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				pObjFlag27.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 28) == TriState.True)
				pObjFlag28.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 29) == TriState.True)
				pObjFlag29.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 30) == TriState.True)
				pObjFlag30.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 31) == TriState.True)
				pObjFlag31.Checked = true;
		}
		
		private void pLockDC_CheckedChanged(object sender, System.EventArgs e)
		{
			vLockDC.Enabled = pLockDC.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 103, vLockDC.Enabled);
		}

		private void pInvSlot_CheckedChanged(object sender, System.EventArgs e)
		{
			vInvSlot.Enabled = pInvSlot.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 156, vInvSlot.Enabled);
		}

		private void pParent_CheckedChanged(object sender, System.EventArgs e)
		{
			vParent.Enabled = pParent.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 152, vParent.Enabled);
		}
		
		private void pModelScale_CheckedChanged(object sender, System.EventArgs e)
		{
			vModelScale.Enabled = pModelScale.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 7, vModelScale.Enabled);
		}

		private void vParent_Click(object sender, System.EventArgs e)
		{
			LinkMOB linker = new LinkMOB();
			if (linker.ShowDialog() == DialogResult.OK)
			{
				tParent.Text = linker.GUID;
				MOB_PROP_152 = linker.LinkGUID;
			}
		}

		private void pObjFlags_CheckedChanged(object sender, System.EventArgs e)
		{
			pObjFlag00.Enabled = pObjFlags.Checked;
			pObjFlag01.Enabled = pObjFlags.Checked;
			pObjFlag02.Enabled = pObjFlags.Checked;
			pObjFlag03.Enabled = pObjFlags.Checked;
			pObjFlag04.Enabled = pObjFlags.Checked;
			pObjFlag05.Enabled = pObjFlags.Checked;
			pObjFlag06.Enabled = pObjFlags.Checked;
			pObjFlag07.Enabled = pObjFlags.Checked;
			pObjFlag08.Enabled = pObjFlags.Checked;
			pObjFlag09.Enabled = pObjFlags.Checked;
			pObjFlag10.Enabled = pObjFlags.Checked;
			pObjFlag11.Enabled = pObjFlags.Checked;
			pObjFlag12.Enabled = pObjFlags.Checked;
			pObjFlag13.Enabled = pObjFlags.Checked;
			pObjFlag14.Enabled = pObjFlags.Checked;
			pObjFlag15.Enabled = pObjFlags.Checked;
			pObjFlag16.Enabled = pObjFlags.Checked;
			pObjFlag17.Enabled = pObjFlags.Checked;
			pObjFlag18.Enabled = pObjFlags.Checked;
			pObjFlag19.Enabled = pObjFlags.Checked;
			pObjFlag20.Enabled = pObjFlags.Checked;
			pObjFlag21.Enabled = pObjFlags.Checked;
			pObjFlag22.Enabled = pObjFlags.Checked;
			pObjFlag23.Enabled = pObjFlags.Checked;
			pObjFlag24.Enabled = pObjFlags.Checked;
			pObjFlag25.Enabled = pObjFlags.Checked;
			pObjFlag26.Enabled = pObjFlags.Checked;
			pObjFlag27.Enabled = pObjFlags.Checked;
			pObjFlag28.Enabled = pObjFlags.Checked;
			pObjFlag29.Enabled = pObjFlags.Checked;
			pObjFlag30.Enabled = pObjFlags.Checked;
			pObjFlag31.Enabled = pObjFlags.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 21, pObjFlags.Checked);
		}
		
		private void p_OCOF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_CFlag00.Enabled = p_OCOF.Checked;
			v_CFlag01.Enabled = p_OCOF.Checked;
			v_CFlag02.Enabled = p_OCOF.Checked;
			v_CFlag03.Enabled = p_OCOF.Checked;
			v_CFlag04.Enabled = p_OCOF.Checked;
			v_CFlag05.Enabled = p_OCOF.Checked;
			v_CFlag06.Enabled = p_OCOF.Checked;
			v_CFlag07.Enabled = p_OCOF.Checked;
			v_CFlag08.Enabled = p_OCOF.Checked;
			v_CFlag09.Enabled = p_OCOF.Checked;
			v_CFlag10.Enabled = p_OCOF.Checked;
			v_CFlag11.Enabled = p_OCOF.Checked;
			v_CFlag12.Enabled = p_OCOF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 102, p_OCOF.Checked);
		}
		
		private void p_OSDF_CheckedChanged(object sender, System.EventArgs e)
		{
            v_SDFlag00.Enabled = p_OSDF.Checked;
			v_SDFlag01.Enabled = p_OSDF.Checked;
			v_SDFlag02.Enabled = p_OSDF.Checked;
			v_SDFlag03.Enabled = p_OSDF.Checked;
			v_SDFlag04.Enabled = p_OSDF.Checked;
			v_SDFlag05.Enabled = p_OSDF.Checked;
			v_SDFlag06.Enabled = p_OSDF.Checked;
			v_SDFlag07.Enabled = p_OSDF.Checked;
			v_SDFlag08.Enabled = p_OSDF.Checked;
			v_SDFlag09.Enabled = p_OSDF.Checked;
			v_SDFlag10.Enabled = p_OSDF.Checked;
			v_SDFlag11.Enabled = p_OSDF.Checked;
			v_SDFlag12.Enabled = p_OSDF.Checked;
			v_SDFlag13.Enabled = p_OSDF.Checked;
			v_SDFlag14.Enabled = p_OSDF.Checked;
			v_SDFlag15.Enabled = p_OSDF.Checked;
			v_SDFlag16.Enabled = p_OSDF.Checked;
			v_SDFlag17.Enabled = p_OSDF.Checked;
			v_SDFlag18.Enabled = p_OSDF.Checked;
			v_SDFlag19.Enabled = p_OSDF.Checked;
			v_SDFlag20.Enabled = p_OSDF.Checked;
			v_SDFlag21.Enabled = p_OSDF.Checked;
			v_SDFlag22.Enabled = p_OSDF.Checked;
			v_SDFlag23.Enabled = p_OSDF.Checked;
			v_SDFlag24.Enabled = p_OSDF.Checked;
			v_SDFlag25.Enabled = p_OSDF.Checked;
			v_SDFlag26.Enabled = p_OSDF.Checked;
			v_SDFlag27.Enabled = p_OSDF.Checked;
			v_SDFlag28.Enabled = p_OSDF.Checked;
			v_SDFlag29.Enabled = p_OSDF.Checked;
			v_SDFlag30.Enabled = p_OSDF.Checked;
			v_SDFlag31.Enabled = p_OSDF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 46, p_OSDF.Checked);		
		}

		private void p_OPF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_PFlag00.Enabled = p_OPF.Checked;
			v_PFlag01.Enabled = p_OPF.Checked;
			v_PFlag02.Enabled = p_OPF.Checked;
			v_PFlag03.Enabled = p_OPF.Checked;
			v_PFlag04.Enabled = p_OPF.Checked;
			v_PFlag05.Enabled = p_OPF.Checked;
			v_PFlag06.Enabled = p_OPF.Checked;
			v_PFlag07.Enabled = p_OPF.Checked;
			v_PFlag08.Enabled = p_OPF.Checked;
			v_PFlag09.Enabled = p_OPF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 88, p_OPF.Checked);
		}
		
		private void p_ONF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_NFlag00.Enabled = p_ONF.Checked;
			v_NFlag01.Enabled = p_ONF.Checked;
			v_NFlag02.Enabled = p_ONF.Checked;
			v_NFlag03.Enabled = p_ONF.Checked;
			v_NFlag04.Enabled = p_ONF.Checked;
			v_NFlag05.Enabled = p_ONF.Checked;
			v_NFlag06.Enabled = p_ONF.Checked;
			v_NFlag07.Enabled = p_ONF.Checked;
			v_NFlag08.Enabled = p_ONF.Checked;
			v_NFlag09.Enabled = p_ONF.Checked;
			v_NFlag10.Enabled = p_ONF.Checked;
			v_NFlag11.Enabled = p_ONF.Checked;
			v_NFlag12.Enabled = p_ONF.Checked;
			v_NFlag13.Enabled = p_ONF.Checked;
			v_NFlag14.Enabled = p_ONF.Checked;
			v_NFlag15.Enabled = p_ONF.Checked;
			v_NFlag16.Enabled = p_ONF.Checked;
			v_NFlag17.Enabled = p_ONF.Checked;
			v_NFlag18.Enabled = p_ONF.Checked;
			v_NFlag19.Enabled = p_ONF.Checked;
			v_NFlag20.Enabled = p_ONF.Checked;
			v_NFlag21.Enabled = p_ONF.Checked;
			v_NFlag22.Enabled = p_ONF.Checked;
			v_NFlag23.Enabled = p_ONF.Checked;
			v_NFlag24.Enabled = p_ONF.Checked;
			v_NFlag25.Enabled = p_ONF.Checked;
			v_NFlag26.Enabled = p_ONF.Checked;
			v_NFlag27.Enabled = p_ONF.Checked;
			v_NFlag28.Enabled = p_ONF.Checked;
			v_NFlag29.Enabled = p_ONF.Checked;
			v_NFlag30.Enabled = p_ONF.Checked;
			v_NFlag31.Enabled = p_ONF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 353, p_ONF.Checked);		
		}
		
		private void p_OIF_CheckedChanged(object sender, System.EventArgs e)
		{
			pItmFlag00.Enabled = p_OIF.Checked;
			pItmFlag01.Enabled = p_OIF.Checked;
			pItmFlag02.Enabled = p_OIF.Checked;
			pItmFlag03.Enabled = p_OIF.Checked;
			pItmFlag04.Enabled = p_OIF.Checked;
			pItmFlag05.Enabled = p_OIF.Checked;
			pItmFlag06.Enabled = p_OIF.Checked;
			pItmFlag07.Enabled = p_OIF.Checked;
			pItmFlag08.Enabled = p_OIF.Checked;
			pItmFlag09.Enabled = p_OIF.Checked;
			pItmFlag10.Enabled = p_OIF.Checked;
			pItmFlag11.Enabled = p_OIF.Checked;
			pItmFlag12.Enabled = p_OIF.Checked;
			pItmFlag13.Enabled = p_OIF.Checked;
			pItmFlag14.Enabled = p_OIF.Checked;
			pItmFlag15.Enabled = p_OIF.Checked;
			pItmFlag16.Enabled = p_OIF.Checked;
			pItmFlag17.Enabled = p_OIF.Checked;
			pItmFlag18.Enabled = p_OIF.Checked;
			pItmFlag19.Enabled = p_OIF.Checked;
			pItmFlag20.Enabled = p_OIF.Checked;
			pItmFlag21.Enabled = p_OIF.Checked;
			pItmFlag22.Enabled = p_OIF.Checked;
			pItmFlag23.Enabled = p_OIF.Checked;
			pItmFlag24.Enabled = p_OIF.Checked;
			pItmFlag25.Enabled = p_OIF.Checked;
			pItmFlag26.Enabled = p_OIF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 151, p_OIF.Checked);				
		}

		private void p_OCF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_C1Flag00.Enabled = p_OCF.Checked;
			v_C1Flag01.Enabled = p_OCF.Checked;
			v_C1Flag02.Enabled = p_OCF.Checked;
			v_C1Flag03.Enabled = p_OCF.Checked;
			v_C1Flag04.Enabled = p_OCF.Checked;
			v_C1Flag05.Enabled = p_OCF.Checked;
			v_C1Flag06.Enabled = p_OCF.Checked;
			v_C1Flag07.Enabled = p_OCF.Checked;
			v_C1Flag08.Enabled = p_OCF.Checked;
			v_C1Flag09.Enabled = p_OCF.Checked;
			v_C1Flag10.Enabled = p_OCF.Checked;
			v_C1Flag11.Enabled = p_OCF.Checked;
			v_C1Flag12.Enabled = p_OCF.Checked;
			v_C1Flag13.Enabled = p_OCF.Checked;
			v_C1Flag14.Enabled = p_OCF.Checked;
			v_C1Flag15.Enabled = p_OCF.Checked;
			v_C1Flag16.Enabled = p_OCF.Checked;
			v_C1Flag17.Enabled = p_OCF.Checked;
			v_C1Flag18.Enabled = p_OCF.Checked;
			v_C1Flag19.Enabled = p_OCF.Checked;
			v_C1Flag20.Enabled = p_OCF.Checked;
			v_C1Flag21.Enabled = p_OCF.Checked;
			v_C1Flag22.Enabled = p_OCF.Checked;
			v_C1Flag23.Enabled = p_OCF.Checked;
			v_C1Flag24.Enabled = p_OCF.Checked;
			v_C1Flag25.Enabled = p_OCF.Checked;
			v_C1Flag26.Enabled = p_OCF.Checked;
			v_C1Flag27.Enabled = p_OCF.Checked;
			v_C1Flag28.Enabled = p_OCF.Checked;
			v_C1Flag29.Enabled = p_OCF.Checked;
			v_C1Flag30.Enabled = p_OCF.Checked;
			v_C1Flag31.Enabled = p_OCF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 283, p_OCF.Checked);				
		}
		
		private void p_OCF2_CheckedChanged(object sender, System.EventArgs e)
		{
			v_C2Flag00.Enabled = p_OCF2.Checked;
			v_C2Flag01.Enabled = p_OCF2.Checked;
			v_C2Flag02.Enabled = p_OCF2.Checked;
			v_C2Flag03.Enabled = p_OCF2.Checked;
			v_C2Flag04.Enabled = p_OCF2.Checked;
			v_C2Flag05.Enabled = p_OCF2.Checked;
			v_C2Flag06.Enabled = p_OCF2.Checked;
			v_C2Flag07.Enabled = p_OCF2.Checked;
			v_C2Flag08.Enabled = p_OCF2.Checked;
			v_C2Flag09.Enabled = p_OCF2.Checked;
			v_C2Flag10.Enabled = p_OCF2.Checked;
			v_C2Flag11.Enabled = p_OCF2.Checked;
			v_C2Flag12.Enabled = p_OCF2.Checked;
			v_C2Flag13.Enabled = p_OCF2.Checked;
			v_C2Flag14.Enabled = p_OCF2.Checked;
			v_C2Flag15.Enabled = p_OCF2.Checked;
			v_C2Flag16.Enabled = p_OCF2.Checked;
			v_C2Flag17.Enabled = p_OCF2.Checked;
			v_C2Flag18.Enabled = p_OCF2.Checked;
			v_C2Flag19.Enabled = p_OCF2.Checked;
			v_C2Flag20.Enabled = p_OCF2.Checked;
			v_C2Flag21.Enabled = p_OCF2.Checked;
			v_C2Flag22.Enabled = p_OCF2.Checked;
			v_C2Flag23.Enabled = p_OCF2.Checked;
			v_C2Flag24.Enabled = p_OCF2.Checked;
			v_C2Flag25.Enabled = p_OCF2.Checked;
			v_C2Flag26.Enabled = p_OCF2.Checked;
			v_C2Flag27.Enabled = p_OCF2.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 284, p_OCF2.Checked);						
		}
	
		private void p_OARF_CheckedChanged(object sender, System.EventArgs e)
		{
			v_OAFlag00.Enabled = p_OARF.Checked;
			v_OAFlag01.Enabled = p_OARF.Checked;
			v_OAFlag02.Enabled = p_OARF.Checked;
			v_OAFlag03.Enabled = p_OARF.Checked;
			v_OAFlag04.Enabled = p_OARF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 219, p_OARF.Checked);								
		}

		private void pInvenSource_CheckedChanged(object sender, System.EventArgs e)
		{
			vInvenSource.Enabled = pInvenSource.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 107, vInvenSource.Enabled);
		}

		private void pChestInv_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!LOADING)
			{
				if (pChestInv.Checked == true && MobType.Text != "obj_t_container")
				{
					MessageBox.Show("You can't define the container inventory for an object of this type!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					pChestInv.Checked = false;
					return;
				}
			}

			vChestInv.Enabled = pChestInv.Checked;
            vChestInvFill.Enabled = pChestInv.Checked;
            vCleanChestInv.Enabled = pChestInv.Checked;
			btnAddChestInv.Enabled = pChestInv.Checked;
			btnRemoveChestInv.Enabled = pChestInv.Checked;
			btnAddChestInv2.Enabled = pChestInv.Checked;
			ChestInvProtos.Enabled = pChestInv.Checked;
			pChestInvDel.Enabled = pChestInv.Checked;
			btnChestInvGUID.Enabled = pChestInv.Checked;
			tChestMoneyAmt.Enabled = pChestInv.Checked;
			pChestInvSlot.Enabled = pChestInv.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 105, pChestInv.Checked);
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 106, pChestInv.Checked);
		}

		private void btnRemoveChestInv_Click(object sender, System.EventArgs e)
		{
			if (vChestInv.SelectedIndex == -1)
				return;

			if (pChestInvDel.Checked && (sender!=null))
			{
				if (MessageBox.Show("Are you sure you want to remove this object from the inventory?\n\nWARNING: This will also delete the associated mobile object file!", "Please confirm removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			if (pChestInvDel.Checked)
			{
				string MOB_OBJECT = vChestInv.Items[vChestInv.SelectedIndex].ToString().Split('\t')[4];
				if (File.Exists("Mobiles\\"+MOB_OBJECT+".mob"))
					File.Delete("Mobiles\\"+MOB_OBJECT+".mob");
			}

			vChestInv.Items.Remove(vChestInv.Items[vChestInv.SelectedIndex]);

			// R1.2: Save the container
			SaveMOB();
		}

		private void btnAddChestInv2_Click(object sender, System.EventArgs e)
		{
			LinkMOB inv_add = new LinkMOB();
			if (inv_add.ShowDialog() == DialogResult.OK)
			{
				string ProtoName = "";
				ProtoName = inv_add.FullString.Split('\t')[inv_add.FullString.Split('\t').GetUpperBound(0)];
				ProtoName += "\t\t\t\t" + inv_add.GUID;
				
				vChestInv.Items.Add(ProtoName);
			}
		}

		private void btnAddChestInv_Click(object sender, System.EventArgs e)
		{
			// Add a new item from proto
			if (ChestInvProtos.SelectedIndex == -1)
				return;

			string objtype = Proto_Types[ChestInvProtos.SelectedItem].ToString();
			if (objtype == "obj_t_portal" || objtype == "obj_t_container" || objtype == "obj_t_scenery" || objtype == "obj_t_projectile")
			{
				MessageBox.Show("The object of this type can't be added to a container!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			bool IS_MONEY = false;
			string ProtoName = ChestInvProtos.Items[ChestInvProtos.SelectedIndex].ToString().Split('#')[0];
			ProtoName = ProtoName.Substring(0, ProtoName.Length - 4).Trim();

			if (ChestInvProtos.Text.IndexOf("Copper ->") == 0 || ChestInvProtos.Text.IndexOf("Silver ->") == 0 || ChestInvProtos.Text.IndexOf("Gold ->") == 0 || ChestInvProtos.Text.IndexOf("Platinum ->") == 0)
				IS_MONEY = true;

			if (IS_MONEY)
				ProtoName += " (" + tChestMoneyAmt.Text + ")";

			// + Generate a mobile object for the given item +
			string ITEM_GUID = "";
			byte[] ITEM_GUID_BYTES = new byte[24];
			Helper.MOB_GenerateGUID(out ITEM_GUID, out ITEM_GUID_BYTES);
			ProtoName += "\t\t\t\t" + ITEM_GUID;

			FileStream mob = new FileStream("Mobiles\\"+ITEM_GUID+".mob", FileMode.Create);
			BinaryWriter w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(ChestInvProtos.Text.Split('#')[1]);

			int ITEM_INDEX_TO_MOBTYPE = MobType.Items.IndexOf(Proto_Types[ChestInvProtos.Items[ChestInvProtos.SelectedIndex]].ToString());
			string ITEM_TYPE = MobType.Items[ITEM_INDEX_TO_MOBTYPE].ToString();
			string ITEM_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(ITEM_TYPE));

			w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
			w_mob.Write(ITEM_GUID_BYTES);
			w_mob.Write((Int32)Helper.GEN_GetMobileType(ITEM_TYPE));

			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 0, true); // Location
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 21, true); // Flags
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 152, true); // Parent object back-reference
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 156, true); // Material slot
			
			if (IS_MONEY)
				ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 230, true); // Money quantity

			w_mob.Write((Int16)Helper.MOB_GetNumberOfProperties(ITEM_BITMAP));
			ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(ITEM_BITMAP);
			foreach (object block in BitmapBytes)
				w_mob.Write((byte)block);

			// Write properties
			// obj_f_location
			UInt32 loc_x = UInt32.Parse(LocationX.Text);
			UInt32 loc_y = UInt32.Parse(LocationY.Text);
			w_mob.Write((byte)0x01);
			w_mob.Write(loc_x);
			w_mob.Write(loc_y);
			// obj_f_flags
			w_mob.Write((Int32)5172); // Pre-defined flags for inventory object
			// obj_f_item_parent
			w_mob.Write((byte)0x01);
			w_mob.Write(MOB_GUID_BYTES);
			// obj_f_item_inv_slot
			if (!pChestInvSlot.Checked)
				w_mob.Write((Int32)vChestInv.Items.Count);
			else
			{
				w_mob.Write(Int32.Parse(vChestInvSlot.Text));
				pChestInvSlot.Checked = false;
			}
			// obj_f_money_quantity
			if (IS_MONEY)
				w_mob.Write(UInt32.Parse(tChestMoneyAmt.Text));

			w_mob.Close();
			mob.Close();
			// - Generate a mobile object for the given item -

			vChestInv.Items.Add(ProtoName);

			// R1.2: Save the container mobile object itself
			SaveMOB();
		}

        private void vCleanChestInv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clean the inventory?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            while (vChestInv.Items.Count != 0)
            {
                vChestInv.SelectedIndex = 0;
                btnRemoveChestInv_Click(null, null);
            }

            pChestInv.Checked = false;
            SaveMOB();
        }

		private void btnChestInvGUID_Click(object sender, System.EventArgs e)
		{
			if (vChestInv.SelectedIndex == -1)
				return;

			MessageBox.Show("Mobile object GUID:\n\n"+vChestInv.Items[vChestInv.SelectedIndex].ToString().Split('\t')[4], "Object GUID", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void pOffsetX_CheckedChanged(object sender, System.EventArgs e)
		{
			vOffsetX.Enabled = pOffsetX.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 1, vOffsetX.Enabled);
		}

		private void pOffsetY_CheckedChanged(object sender, System.EventArgs e)
		{
			vOffsetY.Enabled = pOffsetY.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 2, vOffsetY.Enabled);
		}
		
		private void pOfsZ_CheckedChanged(object sender, System.EventArgs e)
		{
			vOfsZ.Enabled = pOfsZ.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 53, vOfsZ.Enabled);
		}

		private void pRadius_CheckedChanged(object sender, System.EventArgs e)
		{
			vRadius.Enabled = pRadius.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 38, vRadius.Enabled);
		}
		
		private void pSpdWalk_CheckedChanged(object sender, System.EventArgs e)
		{
			vSpdWalk.Enabled = pSpdWalk.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 34, vSpdWalk.Enabled);		
		}
		
		private void pItemAmt_CheckedChanged(object sender, System.EventArgs e)
		{
			vItemAmt.Enabled = pItemAmt.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 167, vItemAmt.Enabled);
		}

		private void pSpdRun_CheckedChanged(object sender, System.EventArgs e)
		{
			vSpdRun.Enabled = pSpdRun.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 35, vSpdRun.Enabled);			
		}

		private void pHeight_CheckedChanged(object sender, System.EventArgs e)
		{
			vHeight.Enabled = pHeight.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 39, vHeight.Enabled);
		}

		private void pMoneyQuantity_CheckedChanged(object sender, System.EventArgs e)
		{
			vMoneyQuantity.Enabled = pMoneyQuantity.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 230, vHeight.Enabled);
		}

		private void pTeleport_CheckedChanged(object sender, System.EventArgs e)
		{
			vTeleport.Enabled = pTeleport.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 126, vTeleport.Enabled);
		}
		
		private void pHP_CheckedChanged(object sender, System.EventArgs e)
		{
			vHP.Enabled = pHP.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 26, vHP.Enabled);
		}

		private void pACAdj_CheckedChanged(object sender, System.EventArgs e)
		{
			vACAdj.Enabled = pACAdj.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 220, vACAdj.Enabled);		
		}

		private void pFaction_CheckedChanged(object sender, System.EventArgs e)
		{
			vFaction.Enabled = pFaction.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 362, vFaction.Enabled);				
		}

		private void pHPAdj_CheckedChanged(object sender, System.EventArgs e)
		{
			vHPAdj.Enabled = pHPAdj.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 27, vHPAdj.Enabled);			
		}
		
		private void pHPDmg_CheckedChanged(object sender, System.EventArgs e)
		{
			vHPDmg.Enabled = pHPDmg.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 28, vHPDmg.Enabled);					
		}

		// + NPC Inventory functions +
		private void pNpcInv_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!LOADING)
			{
				if (pNpcInv.Checked == true && MobType.Text != "obj_t_critter" && MobType.Text != "obj_t_npc")
				{
					MessageBox.Show("You can't define the NPC inventory for an object of this type!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					pNpcInv.Checked = false;
					return;
				}
			}

			vNpcInv.Enabled = pNpcInv.Checked;
            vNpcInvFill.Enabled = pNpcInv.Checked;
            vCleanNpcInv.Enabled = pNpcInv.Checked;
			btnAddNpcInv.Enabled = pNpcInv.Checked;
			btnRemoveNpcInv.Enabled = pNpcInv.Checked;
			btnAddNpcInv2.Enabled = pNpcInv.Checked;
			NpcInvProtos.Enabled = pNpcInv.Checked;
			pNpcInvDel.Enabled = pNpcInv.Checked;
			btnNpcInvGUID.Enabled = pNpcInv.Checked;
			tNpcMoneyAmt.Enabled = pNpcInv.Checked;
			pNpcInvSlot.Enabled = pNpcInv.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 308, pNpcInv.Checked);
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 309, pNpcInv.Checked);	
		}
		
		private void pWaypoints_CheckedChanged(object sender, System.EventArgs e)
		{
			vWaypoints.Enabled = pWaypoints.Checked;		
			vWayX.Enabled = pWaypoints.Checked;
			vWayY.Enabled = pWaypoints.Checked;
            vWayRot.Enabled = pWaypoints.Checked;
            vWayDelay.Enabled = pWaypoints.Checked;
            cRotWpt.Enabled = pWaypoints.Checked;
            cDelayWpt.Enabled = pWaypoints.Checked;
            vWayAnim1.Enabled = pWaypoints.Checked;
            vWayAnim2.Enabled = pWaypoints.Checked;
            vWayAnim3.Enabled = pWaypoints.Checked;
            vWayAnim4.Enabled = pWaypoints.Checked;
            vWayAnim5.Enabled = pWaypoints.Checked;
            vWayAnim6.Enabled = pWaypoints.Checked;
            vWayAnim7.Enabled = pWaypoints.Checked;
            vWayAnim8.Enabled = pWaypoints.Checked;
            cAnimWpt.Enabled = pWaypoints.Checked;
			btnWayAdd.Enabled = pWaypoints.Checked;
			btnWayDel.Enabled = pWaypoints.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 358, pWaypoints.Checked);	
		}

		private void btnNpcInvGUID_Click(object sender, System.EventArgs e)
		{
			if (vNpcInv.SelectedIndex == -1)
				return;

			MessageBox.Show("Mobile object GUID:\n\n"+vNpcInv.Items[vNpcInv.SelectedIndex].ToString().Split('\t')[4], "Object GUID", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnRemoveNpcInv_Click(object sender, System.EventArgs e)
		{
			if (vNpcInv.SelectedIndex == -1)
				return;

			if (pNpcInvDel.Checked && (sender != null))
			{
				if (MessageBox.Show("Are you sure you want to remove this object from the inventory?\n\nWARNING: This will also delete the associated mobile object file!", "Please confirm removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			if (pNpcInvDel.Checked)
			{
				string MOB_OBJECT = vNpcInv.Items[vNpcInv.SelectedIndex].ToString().Split('\t')[4];
				if (File.Exists("Mobiles\\"+MOB_OBJECT+".mob"))
					File.Delete("Mobiles\\"+MOB_OBJECT+".mob");
			}

			vNpcInv.Items.Remove(vNpcInv.Items[vNpcInv.SelectedIndex]);	

			// R1.2: Save the MOB
			SaveMOB();
		}

		private void btnAddNpcInv2_Click(object sender, System.EventArgs e)
		{
			LinkMOB inv_add = new LinkMOB();
			if (inv_add.ShowDialog() == DialogResult.OK)
			{
				string ProtoName = "";
				ProtoName = inv_add.FullString.Split('\t')[inv_add.FullString.Split('\t').GetUpperBound(0)];
				ProtoName += "\t\t\t\t" + inv_add.GUID;
				
				vNpcInv.Items.Add(ProtoName);
			}	
		}

		private void btnAddNpcInv_Click(object sender, System.EventArgs e)
		{
			// Add a new item from proto
			if (NpcInvProtos.SelectedIndex == -1)
				return;

			string objtype = Proto_Types[NpcInvProtos.SelectedItem].ToString();
			if (objtype == "obj_t_portal" || objtype == "obj_t_container" || objtype == "obj_t_scenery" || objtype == "obj_t_projectile")
			{
				MessageBox.Show("The object of this type can't be added to a NPC inventory!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			bool IS_MONEY = false;
			string ProtoName = NpcInvProtos.Items[NpcInvProtos.SelectedIndex].ToString().Split('#')[0];
			ProtoName = ProtoName.Substring(0, ProtoName.Length - 4).Trim();

			if (NpcInvProtos.Text.IndexOf("Copper ->") == 0 || NpcInvProtos.Text.IndexOf("Silver ->") == 0 || NpcInvProtos.Text.IndexOf("Gold ->") == 0 || NpcInvProtos.Text.IndexOf("Platinum ->") == 0)
				IS_MONEY = true;

			if (IS_MONEY)
				ProtoName += " (" + tNpcMoneyAmt.Text + ")";

			// + Generate a mobile object for the given item +
			string ITEM_GUID = "";
			byte[] ITEM_GUID_BYTES = new byte[24];
			Helper.MOB_GenerateGUID(out ITEM_GUID, out ITEM_GUID_BYTES);
			ProtoName += "\t\t\t\t" + ITEM_GUID;

			FileStream mob = new FileStream("Mobiles\\"+ITEM_GUID+".mob", FileMode.Create);
			BinaryWriter w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(NpcInvProtos.Text.Split('#')[1]);

			int ITEM_INDEX_TO_MOBTYPE = MobType.Items.IndexOf(Proto_Types[NpcInvProtos.Items[NpcInvProtos.SelectedIndex]].ToString());
			string ITEM_TYPE = MobType.Items[ITEM_INDEX_TO_MOBTYPE].ToString();
			string ITEM_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(ITEM_TYPE));

			w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
			w_mob.Write(ITEM_GUID_BYTES);
			w_mob.Write((Int32)Helper.GEN_GetMobileType(ITEM_TYPE));

			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 0, true); // Location
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 21, true); // Flags
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 152, true); // Parent object back-reference
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 156, true); // Material slot
			
			if (IS_MONEY)
				ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 230, true); // Money quantity

			w_mob.Write((Int16)Helper.MOB_GetNumberOfProperties(ITEM_BITMAP));
			ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(ITEM_BITMAP);
			foreach (object block in BitmapBytes)
				w_mob.Write((byte)block);

			// Write properties
			// obj_f_location
			UInt32 loc_x = UInt32.Parse(LocationX.Text);
			UInt32 loc_y = UInt32.Parse(LocationY.Text);
			w_mob.Write((byte)0x01);
			w_mob.Write(loc_x);
			w_mob.Write(loc_y);
			// obj_f_flags
			w_mob.Write((Int32)5172); // Pre-defined flags for inventory object
			// obj_f_item_parent
			w_mob.Write((byte)0x01);
			w_mob.Write(MOB_GUID_BYTES);
			// obj_f_item_inv_slot
			if (!pNpcInvSlot.Checked)
				w_mob.Write((Int32)vNpcInv.Items.Count);
			else
			{
				w_mob.Write(Int32.Parse(vNpcInvSlot.Text));
				pNpcInvSlot.Checked = false;
			}
			// obj_f_money_quantity
			if (IS_MONEY)
				w_mob.Write(UInt32.Parse(tNpcMoneyAmt.Text));

			w_mob.Close();
			mob.Close();
			// - Generate a mobile object for the given item -

			vNpcInv.Items.Add(ProtoName);	
	
			// R1.2: Save MOB
			SaveMOB();
		}


        private void vCleanNpcInv_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clean the inventory?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            while (vNpcInv.Items.Count != 0)
            {
                vNpcInv.SelectedIndex = 0;
                btnRemoveNpcInv_Click(null, null);
            }

            pNpcInv.Checked = false;
            SaveMOB();
        }
        // - NPC Inventory functions -

        private bool NPC_INVENSOURCE_CALLBACK = false;
		private void pNpcInvenSource_CheckedChanged(object sender, System.EventArgs e)
		{
			if (NPC_INVENSOURCE_CALLBACK)
			{
				NPC_INVENSOURCE_CALLBACK = false;
				return;
			}

			if (MobType.Text != "obj_t_npc")
			{
				MessageBox.Show("This is not a NPC! You can't set this property for non-NPC objects!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				NPC_INVENSOURCE_CALLBACK = true;
				pNpcInvenSource.Checked = false;
			}

			vNpcInvenSource.Enabled = pNpcInvenSource.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 310, vNpcInvenSource.Enabled);	
		}

		private void pSubInv_CheckedChanged(object sender, System.EventArgs e)
		{
			vSubInv.Enabled = pSubInv.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 364, vSubInv.Enabled);
		}

		private void vSubInv_Click(object sender, System.EventArgs e)
		{
			LinkMOB linker = new LinkMOB();
			if (linker.ShowDialog() == DialogResult.OK)
			{
				tSubInv.Text = linker.GUID;
				MOB_PROP_SUBINV = linker.LinkGUID;
			}	
		}

		private void pNpcInvSlot_CheckedChanged(object sender, System.EventArgs e)
		{
			vNpcInvSlot.Enabled = pNpcInvSlot.Checked;
		}

		private void pMoneyIdx_CheckedChanged(object sender, System.EventArgs e)
		{
			vMoneyIdx1.Enabled = pMoneyIdx.Checked;		
			vMoneyIdx2.Enabled = pMoneyIdx.Checked;		
			vMoneyIdx3.Enabled = pMoneyIdx.Checked;		
			vMoneyIdx4.Enabled = pMoneyIdx.Checked;		
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 307, vMoneyIdx1.Enabled);
		}

		private void pChestInvSlot_CheckedChanged(object sender, System.EventArgs e)
		{
			vChestInvSlot.Enabled = pChestInvSlot.Checked;		
		}

		private void pDispatcher_CheckedChanged(object sender, System.EventArgs e)
		{
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 44, pDispatcher.Checked);
		}
		
		private void pPLockDC_CheckedChanged(object sender, System.EventArgs e)
		{
			vPLockDC.Enabled = pPLockDC.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 89, pPLockDC.Checked);
		}

		private void pAmmoAmt_CheckedChanged(object sender, System.EventArgs e)
		{
			vAmmoAmt.Enabled = pAmmoAmt.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 210, pAmmoAmt.Checked);		
		}

		private void pSDDC_CheckedChanged(object sender, System.EventArgs e)
		{
			vSDDC.Enabled = pSDDC.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 48, pSDDC.Checked);		
		}

		private void pObjName_CheckedChanged(object sender, System.EventArgs e)
		{
			vObjName.Enabled = pObjName.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 23, pObjName.Checked);				
		}

		private void pEffName_CheckedChanged(object sender, System.EventArgs e)
		{
			vEffName.Enabled = pEffName.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 47, pEffName.Checked);		
		}

		private void pACMaxDex_CheckedChanged(object sender, System.EventArgs e)
		{
			vACMaxDex.Enabled = pACMaxDex.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 221, pACMaxDex.Checked);		
		}

		private void pAI64_CheckedChanged(object sender, System.EventArgs e)
		{
			vAI64.Enabled = pAI64.Checked;		
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 381, pAI64.Checked);		
		}

		private void pTransparency_CheckedChanged(object sender, System.EventArgs e)
		{
			vTransparency.Enabled = pTransparency.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 6, pTransparency.Checked);
		}

		private void pSpellFail_CheckedChanged(object sender, System.EventArgs e)
		{
			vSpellFail.Enabled = pSpellFail.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 222, pSpellFail.Checked);		
		}

		private void pArmorChk_CheckedChanged(object sender, System.EventArgs e)
		{
			vArmorChk.Enabled = pArmorChk.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 223, pArmorChk.Checked);				
		}

		private void pTeleDest_CheckedChanged(object sender, System.EventArgs e)
		{
			vTeleX.Enabled = pTeleDest.Checked;
			vTeleY.Enabled = pTeleDest.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 313, pTeleDest.Checked);				
		}

		private void pTeleMap_CheckedChanged(object sender, System.EventArgs e)
		{
			vTeleMap.Enabled = pTeleMap.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 314, pTeleMap.Checked);						
		}

		private void pNotify1_CheckedChanged(object sender, System.EventArgs e)
		{
			vNotify1.Enabled = pNotify1.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 91, pNotify1.Checked);								
		}

		private void pNotify2_CheckedChanged(object sender, System.EventArgs e)
		{
			vNotify2.Enabled = pNotify2.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 108, pNotify2.Checked);										
		}

        private void pNPCGenData_CheckedChanged(object sender, EventArgs e)
        {
            vNPCGenData.Enabled = pNPCGenData.Checked;
            vNPCGDay.Enabled = pNPCGenData.Checked;
            vNPCGActive.Enabled = pNPCGenData.Checked;
            vNPCGIgnoreTotal.Enabled = pNPCGenData.Checked;
            vNPCGNight.Enabled = pNPCGenData.Checked;
            vNPCGRate1.Enabled = pNPCGenData.Checked;
            vNPCGRate2.Enabled = pNPCGenData.Checked;
            vNPCGRate3.Enabled = pNPCGenData.Checked;
            vNPCGRate4.Enabled = pNPCGenData.Checked;
            vNPCGRate5.Enabled = pNPCGenData.Checked;
            vNPCGRate6.Enabled = pNPCGenData.Checked;
            vNPCGRate7.Enabled = pNPCGenData.Checked;
            vNPCGRate8.Enabled = pNPCGenData.Checked;
            vNPCGSpawnAll.Enabled = pNPCGenData.Checked;
            vNPCGSpawnConcurrent.Enabled = pNPCGenData.Checked;
            vNPCGSpawnTotal.Enabled = pNPCGenData.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 370, pNPCGenData.Checked);										
        }

		private void pWeight_CheckedChanged(object sender, System.EventArgs e)
		{
			vWeight.Enabled = pWeight.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 153, pWeight.Checked);						
		}

		private void pWorth_CheckedChanged(object sender, System.EventArgs e)
		{
			vWorth.Enabled = pWorth.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 154, pWorth.Checked);								
		}

		private void pPKeyID_CheckedChanged(object sender, System.EventArgs e)
		{
			vPKeyID.Enabled = pPKeyID.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 90, pPKeyID.Checked);		
		}


        private void pLevelup_CheckedChanged(object sender, EventArgs e)
        {
            vLevelup.Enabled = pLevelup.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 319, pLevelup.Checked);		
        }

		private void pStandpoints_CheckedChanged(object sender, System.EventArgs e)
		{
			vDayX.Enabled = pStandpoints.Checked;		
			vDayY.Enabled = pStandpoints.Checked;
			vNightX.Enabled = pStandpoints.Checked;
			vNightY.Enabled = pStandpoints.Checked;
			vDayMap.Enabled = pStandpoints.Checked;
			vNightMap.Enabled = pStandpoints.Checked;
			vDayFlags.Enabled = pStandpoints.Checked;
			vNightFlags.Enabled = pStandpoints.Checked;
            vDayOfsX.Enabled = pStandpoints.Checked;
            vDayOfsY.Enabled = pStandpoints.Checked;
            vNightOfsX.Enabled = pStandpoints.Checked;
            vNightOfsY.Enabled = pStandpoints.Checked;
            vDayJP.Enabled = pStandpoints.Checked;
            vNightJP.Enabled = pStandpoints.Checked;
            pScoutPoint.Enabled = pStandpoints.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 391, pStandpoints.Checked);		
		}

		private void pKeyID_CheckedChanged(object sender, System.EventArgs e)
		{
			vKeyID.Enabled = pKeyID.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 104, pKeyID.Checked);
		}

		private void pKeyID2_CheckedChanged(object sender, System.EventArgs e)
		{
			vKeyID2.Enabled = pKeyID2.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 255, pKeyID2.Checked);
		}

		// EMBED IN SECTORS
		private void btnEmbed_Click(object sender, System.EventArgs e)
		{
			if (MobType.Text != "obj_t_scenery" &&
				MobType.Text != "obj_t_portal" &&
				MobType.Text != "obj_t_projectile" /*UNKNOWN*/ &&
				MobType.Text != "obj_t_trap")
			{
				MessageBox.Show("Objects of the chosen type ("+MobType.Text+") should not be embedded into sectors!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			// FIX: BETA R1.1
			Helper.SectorName = Helper.SEC_GetSectorCorrespondence(int.Parse(LocationX.Text), int.Parse(LocationY.Text)).ToString()+".sec";
			EmbedInSector e_sect = new EmbedInSector();
			if (e_sect.ShowDialog() == DialogResult.OK)
			{
				// Error: no file was ever specified
				if (e_sect.FileName == "")
					return;

				// If the sector doesn't exist yet, create an empty one
				if (!File.Exists(e_sect.FileName))
				{
					BinaryWriter w_sec = new BinaryWriter(new FileStream(e_sect.FileName, FileMode.Create));
					Helper.SEC_CreateEmptySectorFile(w_sec);
					w_sec.Close();
				}

				// Phase 1: save the temporary object file
				string tempobj = Path.GetDirectoryName(Application.ExecutablePath)+"\\temp.obj";
				__MOB_OVERRIDE_NAME = tempobj;
				Helper.EmbedMode = true; // R1.3: Embed mode to set guid type 0x00
				SaveMOB();
				
				// Phase 2: Find out the total number of objects in the sector file
				uint CURRENT_NUM_OF_OBJS;
				BinaryReader r_obj0 = new BinaryReader(new FileStream(e_sect.FileName, FileMode.Open));
				r_obj0.BaseStream.Seek(-4, SeekOrigin.End);
				CURRENT_NUM_OF_OBJS = r_obj0.ReadUInt32();
				r_obj0.Close();
				CURRENT_NUM_OF_OBJS++; // increase the number of object entries

				// Phase 3: write the temporary object data to the sector file
				BinaryReader r_obj = new BinaryReader(new FileStream(tempobj, FileMode.Open));
				BinaryWriter w_embed = new BinaryWriter(new FileStream(e_sect.FileName, FileMode.Open));
				w_embed.BaseStream.Seek(-4, SeekOrigin.End);

				while (r_obj.BaseStream.Position != r_obj.BaseStream.Length)
					w_embed.Write(r_obj.ReadByte());

				w_embed.Write(CURRENT_NUM_OF_OBJS); // write the number of objects
				r_obj.Close();
				w_embed.Close();

				// Phase 4: delete the temporary object data file
				File.Delete(tempobj);
                
				MessageBox.Show("Object embedded successfully.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

        private void vWaypoints_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vWaypoints.SelectedIndex == -1)
                return;

            Helper.WaypointInfo wp = (Helper.WaypointInfo)NPC_WAYPOINTS[vWaypoints.SelectedIndex];
            vWayX.Text = wp.X.ToString();
            vWayY.Text = wp.Y.ToString();
            vWayAnim1.Text = wp.anim1.ToString();
            vWayAnim2.Text = wp.anim2.ToString();
            vWayAnim3.Text = wp.anim3.ToString();
            vWayAnim4.Text = wp.anim4.ToString();
            vWayAnim5.Text = wp.anim5.ToString();
            vWayAnim6.Text = wp.anim6.ToString();
            vWayAnim7.Text = wp.anim7.ToString();
            vWayAnim8.Text = wp.anim8.ToString();
            vWayRot.Text = wp.Rotation.ToString();
            vWayDelay.Text = wp.delay.ToString();

            string Bitmap = Helper.GEN_UInt32_To_Bitmap(wp.flags);

            cRotWpt.Checked = false;
            cDelayWpt.Checked = false;
            cAnimWpt.Checked = false;

            if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
                cRotWpt.Checked = true;
            if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
                cDelayWpt.Checked = true;
            if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
                cAnimWpt.Checked = true;
        }

        private void pScoutPoint_CheckedChanged(object sender, EventArgs e)
        {
            vScoutX.Enabled = pScoutPoint.Checked;
            vScoutY.Enabled = pScoutPoint.Checked;
            vScoutOfsX.Enabled = pScoutPoint.Checked;
            vScoutOfsY.Enabled = pScoutPoint.Checked;
            vScoutJP.Enabled = pScoutPoint.Checked;
            vScoutMap.Enabled = pScoutPoint.Checked;
        }

        private void pFactions_CheckedChanged(object sender, EventArgs e)
        {
            vFactions.Enabled = pFactions.Checked;
            vFactionsIdx.Enabled = pFactions.Checked;
            btnAddFaction.Enabled = pFactions.Checked;
            btnDelFaction.Enabled = pFactions.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 362, vFactions.Enabled);
        }

        private void pRace_CheckedChanged(object sender, EventArgs e)
        {
            vRace.Enabled = pRace.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 287, pRace.Checked);
        }

        private void pGender_CheckedChanged(object sender, EventArgs e)
        {
            vGender.Enabled = pGender.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 288, pGender.Checked);
        }

        private void pAbilities_CheckedChanged(object sender, EventArgs e)
        {
            vSTR.Enabled = pAbilities.Checked;
            vDEX.Enabled = pAbilities.Checked;
            vCON.Enabled = pAbilities.Checked;
            vINT.Enabled = pAbilities.Checked;
            vWIS.Enabled = pAbilities.Checked;
            vCHA.Enabled = pAbilities.Checked;
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 285, pAbilities.Checked);
        }

        private void btnAddFaction_Click(object sender, EventArgs e)
        {
            vFactions.Items.Add(vFactionsIdx.Text);
        }

        private void btnDelFaction_Click(object sender, EventArgs e)
        {
            if (vFactions.SelectedIndex == -1)
                return;

            vFactions.Items.RemoveAt(vFactions.SelectedIndex);
        }

        // + Fill from inventory source +
        private void vNpcInvFill_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\InvenSource.mes"))
            {
                MessageBox.Show("You need to copy INVENSOURCE.MES to your ToEEWB folder in order to be able to use this feature!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListInvenSource inv = new ListInvenSource();
            if (inv.ShowDialog() == DialogResult.OK)
            {
                // add items here
                foreach (string item in inv.ITEMS)
                {
                    string proto = "#"+item.Split(',')[0];
                    string amount = item.Split(',')[1];

                    foreach (string protoID in NpcInvProtos.Items)
                    {
                        if (protoID.IndexOf(proto) == protoID.Length - proto.Length)
                        {
                            NpcInvProtos.SelectedItem = protoID;
                            break;
                        }
                    }
                    if (amount != "-1")
                        tNpcMoneyAmt.Text = amount;

                    btnAddNpcInv_Click(sender, e);
                    Thread.Sleep(100);
                }
            }
        }

        private void vChestInvFill_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\InvenSource.mes"))
            {
                MessageBox.Show("You need to copy INVENSOURCE.MES to your ToEEWB folder in order to be able to use this feature!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListInvenSource inv = new ListInvenSource();
            if (inv.ShowDialog() == DialogResult.OK)
            {
                 // add items here
                foreach (string item in inv.ITEMS)
                {
                    string proto = "#" + item.Split(',')[0];
                    string amount = item.Split(',')[1];

                    foreach (string protoID in ChestInvProtos.Items)
                    {
                        if (protoID.IndexOf(proto) == protoID.Length - proto.Length)
                        {
                            ChestInvProtos.SelectedItem = protoID;
                            break;
                        }
                    }
                    if (amount != "-1")
                        tChestMoneyAmt.Text = amount;

                    btnAddChestInv_Click(sender, e);
                    Thread.Sleep(100);
                }
            }
        }
        // - Fill from inventory source -

        private void btnCleanD20States_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clean the internal hardcoded info from the .MOB file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (chkCleanScripts.Checked)
                MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 30, false);

            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 40, false);
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 41, false);
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 42, false);
            MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 73, false);

            MessageBox.Show("Done", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void vNPCGRate1_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 0);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 0);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate2_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 1);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 1);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate3_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 2);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 2);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate4_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 3);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 3);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate5_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 4);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 4);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate6_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 5);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 5);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate7_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 6);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 6);
                SetNPCFlags(flags);
            }
        }

        private void vNPCGRate8_CheckedChanged(object sender, EventArgs e)
        {
            if (p_ONF.Checked)
            {
                uint flags = GetNPCFlags();
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 7);
                SetNPCFlags(flags);
            }
            else
            {
                p_ONF.Checked = true;
                uint flags = 0;
                flags = (uint)Helper.MAKE_NPCGEN((int)flags, 7);
                SetNPCFlags(flags);
            }
        }
		#endregion

		#region Map Splitter/Recombiner
		private void button2_Click(object sender, System.EventArgs e)
		{
			int MX = 0;  // Max X coord
			int MY = 0;  // Max Y coord
			int LX = 65535; // Min X coord
			int LY = 65535; // Min Y coord

			if (OFG.ShowDialog() == DialogResult.Cancel)
				return;

			// Phase 1. Make a list of JPEGs
			string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName),"????????.jpg");
			string last_path = Path.GetDirectoryName(files[0]);
			string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
			//MessageBox.Show(m_path);
			//return;

			if (files.GetUpperBound(0) > 800)
			{
				// Too many files. Consider partial recombining?
				if (MessageBox.Show("Warning: the number of files in chosen folder is big. Even though recombination of this map is possible, you may run out of memory later when you will want to split your map. You may consider PARTIAL RECOMBINING (advanced) instead of FULL RECOMBINING in order to reduce the size of the combined bitmap.\n\nAre you sure you want to proceed with COMPLETE RECOMBINING?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
			}

			// Phase 2. Set the MX / MY pair
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);

				// v1.0: Ignore files with filename not equal to 8 letters
				//       (precarious format?)
				if (abs.Length != 8)
				{
					MessageBox.Show("Illegal file detected in the source directory: "+abs+".jpg\nIt will be ignored.","Non-critical warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					continue;
				}

				string SX = abs.Substring(0, 4);
				string SY = abs.Substring(4, 4);
				int X = Int32.Parse(SX, System.Globalization.NumberStyles.HexNumber);
				int Y = Int32.Parse(SY, System.Globalization.NumberStyles.HexNumber);
				
				if (X > MX)
					MX = X;

				if (Y > MY)
					MY = Y;

				if (X < LX)
					LX = X;

				if (Y < LY)
					LY = Y;
			}

			fdata.Text = "MX: " + MX.ToString()+"; MY: "+MY.ToString();

			// Save the restoration data
			FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+".txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage((Image)Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			Bitmap tmp;
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(0, 4);
				string SY = abs.Substring(4, 4);

				// v1.0: Ignore files with filename not equal to 8 letters
				if (abs.Length != 8)
					continue;

				int X = Int32.Parse(SX, System.Globalization.NumberStyles.HexNumber);
				int Y = Int32.Parse(SY, System.Globalization.NumberStyles.HexNumber);

				tmp = (Bitmap)Bitmap.FromFile(file);
				g_Blt.DrawImage((Image)tmp, 256*(Y - LY), 256*(X - LX));

			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+".jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: "+m_path+".jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int SX = 0;  // Starting X coord
			int SY = 0;  // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;
		
			// Load the big canvas
			Bitmap blt = new Bitmap(OFG1.FileName);
			//Graphics g_blt = Graphics.FromImage(blt);

			// Get the number of constituents
			int X_AMOUNT = blt.Width / 256;
			int Y_AMOUNT = blt.Height / 256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)+".txt"))
			{
				StreamReader sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName)+".txt");
				SX = Int32.Parse(sr.ReadLine());
				SY = Int32.Parse(sr.ReadLine());
				sr.Close();
			}

			splitData.Text = "SX: "+SX.ToString()+"; "+"SY: "+SY.ToString();

			// Split into individual stuff
			if (!Directory.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)))
				Directory.CreateDirectory(Path.GetFileNameWithoutExtension(OFG1.FileName));

			string file;
			Bitmap tmp;
			for (int i=SY; i < SY + X_AMOUNT; i++)
				for (int j=SX; j < SX + Y_AMOUNT; j++)
				{
					file = j.ToString("X").PadLeft(4,'0')+i.ToString("X").PadLeft(4,'0')+".jpg";
					tmp = new Bitmap(256, 256);
					Graphics g_tmp = Graphics.FromImage((Image)tmp);
					g_tmp.DrawImage((Image)blt, 0, 0, new Rectangle(256 * (i - SY), 256 * (j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName)+"\\"+file, ImageFormat.Jpeg);
				}

			MessageBox.Show("Splitting complete.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		// Split minimap
		private void button3_Click(object sender, System.EventArgs e)
		{
			// I. Split the 4's

			int SX = 0;  // Starting X coord
			int SY = 0;  // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;
		
			string modifier = Path.GetFileNameWithoutExtension(OFG1.FileName).Substring(Path.GetFileNameWithoutExtension(OFG1.FileName).Length - 2);
			
			if (modifier != "_4" && modifier != "_8")
			{
				MessageBox.Show("Invalid JPEG source specified!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			// Load the big canvas
			Bitmap blt = new Bitmap(OFG1.FileName);

			// Get the number of constituents
			int X_AMOUNT = blt.Width / 256;
			int Y_AMOUNT = blt.Height / 256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)+".txt"))
			{
				StreamReader sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName)+".txt");
				SX = Int32.Parse(sr.ReadLine());
				SY = Int32.Parse(sr.ReadLine());
				sr.Close();
			}

			splitData.Text = "SX: "+SX.ToString()+"; "+"SY: "+SY.ToString();

			// Split into individual stuff
			if (!Directory.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)))
				Directory.CreateDirectory(Path.GetFileNameWithoutExtension(OFG1.FileName));

			string file;
			Bitmap tmp;
			for (int i=SY; i < SY + X_AMOUNT; i++)
				for (int j=SX; j < SX + Y_AMOUNT; j++)
				{
					file = (modifier == "_4") ? "z4"+j.ToString().PadLeft(3,'0')+i.ToString().PadLeft(3,'0')+".jpg" : "z8"+j.ToString().PadLeft(3,'0')+i.ToString().PadLeft(3,'0')+".jpg";
					tmp = new Bitmap(256, 256);
					Graphics g_tmp = Graphics.FromImage((Image)tmp);
					g_tmp.DrawImage((Image)blt, 0, 0, new Rectangle(256 * (i - SY), 256 * (j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName)+"\\"+file, ImageFormat.Jpeg);
				}			

			MessageBox.Show("Splitting complete.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		// Recombine minimap
		private void button4_Click(object sender, System.EventArgs e)
		{
			// I. Recombine 4's

			int MX = 0;  // Max X coord
			int MY = 0;  // Max Y coord
			int LX = 65535; // Min X coord
			int LY = 65535; // Min Y coord

			if (OFG.ShowDialog() == DialogResult.Cancel)
				return;

			// Phase 1. Make a list of JPEGs
			string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName),"z4*.jpg");
			string last_path = Path.GetDirectoryName(files[0]);
			string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
			//MessageBox.Show(m_path);
			//return;

			// Phase 2. Set the MX / MY pair
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = Int32.Parse(SX);
				int Y = Int32.Parse(SY);
				
				if (X > MX)
					MX = X;

				if (Y > MY)
					MY = Y;

				if (X < LX)
					LX = X;

				if (Y < LY)
					LY = Y;
			}

			fdata.Text = "MX: " + MX.ToString()+"; MY: "+MY.ToString();

			// Save the restoration data
			FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+"_4.txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage((Image)Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			Bitmap tmp;
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = Int32.Parse(SX);
				int Y = Int32.Parse(SY);

				tmp = (Bitmap)Bitmap.FromFile(file);
				g_Blt.DrawImage((Image)tmp, 256*(Y - LY), 256*(X - LX));

			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+"_4.jpg", ImageFormat.Jpeg);	
			MessageBox.Show("Built a combined image: "+m_path+"_4.jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// II. Recombine 8's

			MX = 0;  // Max X coord
			MY = 0;  // Max Y coord
			LX = 65535; // Min X coord
			LY = 65535; // Min Y coord

			// Phase 1. Make a list of JPEGs
			files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName),"z8*.jpg");
			last_path = Path.GetDirectoryName(files[0]);
			m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
			//MessageBox.Show(m_path);
			//return;

			// Phase 2. Set the MX / MY pair
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = Int32.Parse(SX);
				int Y = Int32.Parse(SY);
				
				if (X > MX)
					MX = X;

				if (Y > MY)
					MY = Y;

				if (X < LX)
					LX = X;

				if (Y < LY)
					LY = Y;
			}

			fdata.Text = "MX: " + MX.ToString()+"; MY: "+MY.ToString();

			// Save the restoration data
			f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+"_8.txt", FileMode.Create);
			sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
			g_Blt = Graphics.FromImage((Image)Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = Int32.Parse(SX);
				int Y = Int32.Parse(SY);

				tmp = (Bitmap)Bitmap.FromFile(file);
				g_Blt.DrawImage((Image)tmp, 256*(Y - LY), 256*(X - LX));

			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+"_8.jpg", ImageFormat.Jpeg);	
			MessageBox.Show("Built a combined image: "+m_path+"_8.jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void recomb_partial_Click(object sender, System.EventArgs e)
		{
			int LX = Int32.Parse(SX.Text); // Min X coord
			int LY = Int32.Parse(SY.Text); // Min Y coord
			int MX = LX + Int32.Parse(PX.Text) - 1;  // Max X coord
			int MY = LY + Int32.Parse(PY.Text) - 1;  // Max Y coord

			if (OFG.ShowDialog() == DialogResult.Cancel)
				return;

			// Phase 1. Make a list of JPEGs
			string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName),"????????.jpg");
			string last_path = Path.GetDirectoryName(files[0]);
			string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);

			// Save the restoration data
			FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+".txt", FileMode.Create);
			StreamWriter sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage((Image)Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			try
			{
				Bitmap tmp;
				foreach (string file in files)
				{
					string abs = Path.GetFileNameWithoutExtension(file);
					string _SX = abs.Substring(0, 4);
					string _SY = abs.Substring(4, 4);
					int X = Int32.Parse(_SX, System.Globalization.NumberStyles.HexNumber);
					int Y = Int32.Parse(_SY, System.Globalization.NumberStyles.HexNumber);

					tmp = (Bitmap)Bitmap.FromFile(file);
					g_Blt.DrawImage((Image)tmp, 256*(Y - LY), 256*(X - LX));

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error recombining the map partially: \n\n"+ex.Message+"\n\nPossibly the specified map block does not exist or not all files were found for the specified block.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath)+"\\2D Maps\\"+m_path+".jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: "+m_path+".jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
        private void button5_Click(object sender, EventArgs e)
        {
            int SX = 0;  // Starting X coord
            int SY = 0;  // Starting Y coord

            if (OFG1.ShowDialog() == DialogResult.Cancel)
                return;

            // Load the big canvas
            Bitmap blt = new Bitmap(OFG1.FileName);
            //Graphics g_blt = Graphics.FromImage(blt);

            // Get the number of constituents
            int X_AMOUNT = blt.Width / 256;
            int Y_AMOUNT = blt.Height / 256;

            // Load up the SX/XY pair, if possible. Otherwise assume (0;0).
            if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
            {
                StreamReader sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
                SX = Int32.Parse(sr.ReadLine());
                SY = Int32.Parse(sr.ReadLine());
                sr.Close();
            }

            splitData.Text = "SX: " + SX.ToString() + "; " + "SY: " + SY.ToString();

            // Split into individual stuff
            if (!Directory.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)))
                Directory.CreateDirectory(Path.GetFileNameWithoutExtension(OFG1.FileName));

            string file;
            Bitmap tmp;
            for (int i = SY; i < SY + X_AMOUNT; i++)
                for (int j = SX; j < SX + Y_AMOUNT; j++)
                {
                    file = j.ToString("X").PadLeft(4, '0') + i.ToString("X").PadLeft(4, '0') + ".bmp";
                    tmp = new Bitmap(256, 256);
                    Graphics g_tmp = Graphics.FromImage((Image)tmp);
                    g_tmp.DrawImage((Image)blt, 0, 0, new Rectangle(256 * (i - SY), 256 * (j - SX), 256, 256), GraphicsUnit.Pixel);
                    tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Bmp);
                }

            MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int MX = 0;  // Max X coord
            int MY = 0;  // Max Y coord
            int LX = 65535; // Min X coord
            int LY = 65535; // Min Y coord

            if (OFG.ShowDialog() == DialogResult.Cancel)
                return;

            // Phase 1. Make a list of JPEGs
            string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "????????.jpg");
            string last_path = Path.GetDirectoryName(files[0]);
            string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
            //MessageBox.Show(m_path);
            //return;

            if (files.GetUpperBound(0) > 800)
            {
                // Too many files. Consider partial recombining?
                if (MessageBox.Show("Warning: the number of files in chosen folder is big. Even though recombination of this map is possible, you may run out of memory later when you will want to split your map. You may consider PARTIAL RECOMBINING (advanced) instead of FULL RECOMBINING in order to reduce the size of the combined bitmap.\n\nAre you sure you want to proceed with COMPLETE RECOMBINING?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            // Phase 2. Set the MX / MY pair
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);

                // v1.0: Ignore files with filename not equal to 8 letters
                //       (precarious format?)
                if (abs.Length != 8)
                {
                    MessageBox.Show("Illegal file detected in the source directory: " + abs + ".jpg\nIt will be ignored.", "Non-critical warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                string SX = abs.Substring(0, 4);
                string SY = abs.Substring(4, 4);
                int X = Int32.Parse(SX, System.Globalization.NumberStyles.HexNumber);
                int Y = Int32.Parse(SY, System.Globalization.NumberStyles.HexNumber);

                if (X > MX)
                    MX = X;

                if (Y > MY)
                    MY = Y;

                if (X < LX)
                    LX = X;

                if (Y < LY)
                    LY = Y;
            }

            fdata.Text = "MX: " + MX.ToString() + "; MY: " + MY.ToString();

            // Save the restoration data
            FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f_out);
            sw.WriteLine(LX.ToString());
            sw.WriteLine(LY.ToString());
            sw.Close();
            f_out.Close();

            // Phase 3. Create the canvas
            Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
            Graphics g_Blt = Graphics.FromImage((Image)Blt);
            g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

            // Phase 4. Fill the canvas
            Bitmap tmp;
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);
                string SX = abs.Substring(0, 4);
                string SY = abs.Substring(4, 4);

                // v1.0: Ignore files with filename not equal to 8 letters
                if (abs.Length != 8)
                    continue;

                int X = Int32.Parse(SX, System.Globalization.NumberStyles.HexNumber);
                int Y = Int32.Parse(SY, System.Globalization.NumberStyles.HexNumber);

                tmp = (Bitmap)Bitmap.FromFile(file);
                g_Blt.DrawImage((Image)tmp, 256 * (Y - LY), 256 * (X - LX));

            }
            Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".bmp", ImageFormat.Bmp);
            MessageBox.Show("Built a combined image: " + m_path + ".bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int LX = Int32.Parse(SX.Text); // Min X coord
            int LY = Int32.Parse(SY.Text); // Min Y coord
            int MX = LX + Int32.Parse(PX.Text) - 1;  // Max X coord
            int MY = LY + Int32.Parse(PY.Text) - 1;  // Max Y coord

            if (OFG.ShowDialog() == DialogResult.Cancel)
                return;

            // Phase 1. Make a list of JPEGs
            string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "????????.jpg");
            string last_path = Path.GetDirectoryName(files[0]);
            string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);

            // Save the restoration data
            FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f_out);
            sw.WriteLine(LX.ToString());
            sw.WriteLine(LY.ToString());
            sw.Close();
            f_out.Close();

            // Phase 3. Create the canvas
            Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
            Graphics g_Blt = Graphics.FromImage((Image)Blt);
            g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

            // Phase 4. Fill the canvas
            try
            {
                Bitmap tmp;
                foreach (string file in files)
                {
                    string abs = Path.GetFileNameWithoutExtension(file);
                    string _SX = abs.Substring(0, 4);
                    string _SY = abs.Substring(4, 4);
                    int X = Int32.Parse(_SX, System.Globalization.NumberStyles.HexNumber);
                    int Y = Int32.Parse(_SY, System.Globalization.NumberStyles.HexNumber);

                    tmp = (Bitmap)Bitmap.FromFile(file);
                    g_Blt.DrawImage((Image)tmp, 256 * (Y - LY), 256 * (X - LX));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error recombining the map partially: \n\n" + ex.Message + "\n\nPossibly the specified map block does not exist or not all files were found for the specified block.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".bmp", ImageFormat.Bmp);
            MessageBox.Show("Built a combined image: " + m_path + ".bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // I. Split the 4's

            int SX = 0;  // Starting X coord
            int SY = 0;  // Starting Y coord

            if (OFG1.ShowDialog() == DialogResult.Cancel)
                return;

            string modifier = Path.GetFileNameWithoutExtension(OFG1.FileName).Substring(Path.GetFileNameWithoutExtension(OFG1.FileName).Length - 2);

            if (modifier != "_4" && modifier != "_8")
            {
                MessageBox.Show("Invalid source specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load the big canvas
            Bitmap blt = new Bitmap(OFG1.FileName);

            // Get the number of constituents
            int X_AMOUNT = blt.Width / 256;
            int Y_AMOUNT = blt.Height / 256;

            // Load up the SX/XY pair, if possible. Otherwise assume (0;0).
            if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
            {
                StreamReader sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
                SX = Int32.Parse(sr.ReadLine());
                SY = Int32.Parse(sr.ReadLine());
                sr.Close();
            }

            splitData.Text = "SX: " + SX.ToString() + "; " + "SY: " + SY.ToString();

            // Split into individual stuff
            if (!Directory.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName)))
                Directory.CreateDirectory(Path.GetFileNameWithoutExtension(OFG1.FileName));

            string file;
            Bitmap tmp;
            for (int i = SY; i < SY + X_AMOUNT; i++)
                for (int j = SX; j < SX + Y_AMOUNT; j++)
                {
                    file = (modifier == "_4") ? "z4" + j.ToString().PadLeft(3, '0') + i.ToString().PadLeft(3, '0') + ".bmp" : "z8" + j.ToString().PadLeft(3, '0') + i.ToString().PadLeft(3, '0') + ".bmp";
                    tmp = new Bitmap(256, 256);
                    Graphics g_tmp = Graphics.FromImage((Image)tmp);
                    g_tmp.DrawImage((Image)blt, 0, 0, new Rectangle(256 * (i - SY), 256 * (j - SX), 256, 256), GraphicsUnit.Pixel);
                    tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Bmp);
                }

            MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // I. Recombine 4's

            int MX = 0;  // Max X coord
            int MY = 0;  // Max Y coord
            int LX = 65535; // Min X coord
            int LY = 65535; // Min Y coord

            if (OFG.ShowDialog() == DialogResult.Cancel)
                return;

            // Phase 1. Make a list of JPEGs
            string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "z4*.jpg");
            string last_path = Path.GetDirectoryName(files[0]);
            string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
            //MessageBox.Show(m_path);
            //return;

            // Phase 2. Set the MX / MY pair
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);
                string SX = abs.Substring(2, 3);
                string SY = abs.Substring(5, 3);
                int X = Int32.Parse(SX);
                int Y = Int32.Parse(SY);

                if (X > MX)
                    MX = X;

                if (Y > MY)
                    MY = Y;

                if (X < LX)
                    LX = X;

                if (Y < LY)
                    LY = Y;
            }

            fdata.Text = "MX: " + MX.ToString() + "; MY: " + MY.ToString();

            // Save the restoration data
            FileStream f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(f_out);
            sw.WriteLine(LX.ToString());
            sw.WriteLine(LY.ToString());
            sw.Close();
            f_out.Close();

            // Phase 3. Create the canvas
            Bitmap Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
            Graphics g_Blt = Graphics.FromImage((Image)Blt);
            g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

            // Phase 4. Fill the canvas
            Bitmap tmp;
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);
                string SX = abs.Substring(2, 3);
                string SY = abs.Substring(5, 3);
                int X = Int32.Parse(SX);
                int Y = Int32.Parse(SY);

                tmp = (Bitmap)Bitmap.FromFile(file);
                g_Blt.DrawImage((Image)tmp, 256 * (Y - LY), 256 * (X - LX));

            }
            Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.bmp", ImageFormat.Bmp);
            MessageBox.Show("Built a combined image: " + m_path + "_4.bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // II. Recombine 8's

            MX = 0;  // Max X coord
            MY = 0;  // Max Y coord
            LX = 65535; // Min X coord
            LY = 65535; // Min Y coord

            // Phase 1. Make a list of JPEGs
            files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "z8*.jpg");
            last_path = Path.GetDirectoryName(files[0]);
            m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);
            //MessageBox.Show(m_path);
            //return;

            // Phase 2. Set the MX / MY pair
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);
                string SX = abs.Substring(2, 3);
                string SY = abs.Substring(5, 3);
                int X = Int32.Parse(SX);
                int Y = Int32.Parse(SY);

                if (X > MX)
                    MX = X;

                if (Y > MY)
                    MY = Y;

                if (X < LX)
                    LX = X;

                if (Y < LY)
                    LY = Y;
            }

            fdata.Text = "MX: " + MX.ToString() + "; MY: " + MY.ToString();

            // Save the restoration data
            f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_8.txt", FileMode.Create);
            sw = new StreamWriter(f_out);
            sw.WriteLine(LX.ToString());
            sw.WriteLine(LY.ToString());
            sw.Close();
            f_out.Close();

            // Phase 3. Create the canvas
            Blt = new Bitmap(256 * (MY - LY + 1), 256 * (MX - LX + 1));
            g_Blt = Graphics.FromImage((Image)Blt);
            g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

            // Phase 4. Fill the canvas
            foreach (string file in files)
            {
                string abs = Path.GetFileNameWithoutExtension(file);
                string SX = abs.Substring(2, 3);
                string SY = abs.Substring(5, 3);
                int X = Int32.Parse(SX);
                int Y = Int32.Parse(SY);

                tmp = (Bitmap)Bitmap.FromFile(file);
                g_Blt.DrawImage((Image)tmp, 256 * (Y - LY), 256 * (X - LX));

            }
            Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_8.bmp", ImageFormat.Bmp);
            MessageBox.Show("Built a combined image: " + m_path + "_8.bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

		#endregion

		#region Configuration

		private void btnSaveCfg_Click(object sender, System.EventArgs e)
		{
			StreamWriter cfg = new StreamWriter(new FileStream(Path.GetDirectoryName(Application.ExecutablePath)+"\\ToEE World Builder.ini", FileMode.Create));
			cfg.WriteLine(tDialogEd.Text);
			cfg.WriteLine(tScriptEd.Text);
			cfg.WriteLine(tDialogs.Text);
			cfg.WriteLine(tScripts.Text);
			cfg.WriteLine(cfgDelEmpty.Checked.ToString());
			cfg.WriteLine(chkObjIDGen.Checked.ToString());
            cfg.WriteLine(tWBBridge.Text);
			cfg.Close();
			MessageBox.Show("Configuration saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			if (cfgBrowser.ShowDialog() == DialogResult.OK)
				tDialogEd.Text = cfgBrowser.FileName;
		}

		private void btnBrowse2_Click(object sender, System.EventArgs e)
		{
			if (cfgBrowser.ShowDialog() == DialogResult.OK)
				tScriptEd.Text = cfgBrowser.FileName;	
		}

		private void btnBrowse3_Click(object sender, System.EventArgs e)
		{
			if (cfgDialogs.ShowDialog() == DialogResult.OK)
				tDialogs.Text = Path.GetDirectoryName(cfgDialogs.FileName);
		}

		private void btnBrowse4_Click(object sender, System.EventArgs e)
		{
			if (cfgScripts.ShowDialog() == DialogResult.OK)
				tScripts.Text = Path.GetDirectoryName(cfgScripts.FileName);
		}

		#endregion

		#region Dialog Editor Interface

		private void btnLoadDialogs_Click(object sender, System.EventArgs e)
		{
			if (tDialogs.Text == "")
			{
				MessageBox.Show("The dialog folder is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			lstDialogs.Items.Clear();
			string[] Dialogs = Directory.GetFiles(tDialogs.Text, "*.dlg");

			foreach(string DLG in Dialogs)
			{
				string filename = Path.GetFileNameWithoutExtension(DLG);
				string ID = filename.Substring(0, 5);
				string NAME = filename.Substring(5);

				lstDialogs.Items.Add(ID+"\t"+NAME);
			}
		}

		private void btnDelDialog_Click(object sender, System.EventArgs e)
		{
			if (lstDialogs.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this dialog permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] file_items = lstDialogs.Items[lstDialogs.SelectedIndex].ToString().Split('\t');
			string filename = file_items[0] + file_items[1];
			File.Delete(tDialogs.Text+"\\"+filename+".dlg");
			lstDialogs.Items.Remove(lstDialogs.Items[lstDialogs.SelectedIndex]);
		}

		private void btnEditDialog_Click(object sender, System.EventArgs e)
		{
			if (lstDialogs.SelectedIndex == -1)
				return;

			if (tDialogEd.Text == "")
			{
				MessageBox.Show("The external dialog editor is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string[] file_items = lstDialogs.Items[lstDialogs.SelectedIndex].ToString().Split('\t');
			string filename = file_items[0] + file_items[1] + ".dlg";

			System.Diagnostics.Process.Start(tDialogEd.Text, tDialogs.Text+"\\"+filename);
		}

		#endregion

		#region Script Editor Interface

		private void btnLoadScripts_Click(object sender, System.EventArgs e)
		{
			if (tScripts.Text == "")
			{
				MessageBox.Show("The script folder is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			lstScripts.Items.Clear();
			string[] Scripts = Directory.GetFiles(tScripts.Text, "py*.py");

			foreach(string PY in Scripts)
			{
				string filename = Path.GetFileNameWithoutExtension(PY);
				string ID = filename.Substring(2, 5);
				string NAME = filename.Substring(7);

				lstScripts.Items.Add(ID+"\t"+NAME);
			}	
		}

		private void btnEditScript_Click(object sender, System.EventArgs e)
		{
			if (lstScripts.SelectedIndex == -1)
				return;

			if (tScriptEd.Text == "")
			{
				MessageBox.Show("The external script editor is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			string[] file_items = lstScripts.Items[lstScripts.SelectedIndex].ToString().Split('\t');
			string filename = "py" + file_items[0] + file_items[1] + ".py";

			System.Diagnostics.Process.Start(tScriptEd.Text, tScripts.Text+"\\"+filename);	
		}

		private void btnDelScript_Click(object sender, System.EventArgs e)
		{
			if (lstScripts.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this script permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] file_items = lstScripts.Items[lstScripts.SelectedIndex].ToString().Split('\t');
			string filename = file_items[0] + file_items[1];
			File.Delete(tScripts.Text+"\\"+"py"+filename+".py");
			lstScripts.Items.Remove(lstScripts.Items[lstScripts.SelectedIndex]);		
		}

		#endregion

		#region Help

		// Special NPC inventory slots
		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Normally when you add an item to the NPC inventory you assign it as a loot, the NPC does not wear this item by default. You can use the following special inventory slots to make NPCs wear different items (armor, weapons, etc.):\n\n200 - Helmet\n201 - Necklace\n202 - Gloves\n203 - Primary Weapon\n204 - Secondary Weapon\n205 - Armor\n206 - Primary Ring\n207 - Secondary Ring\n208 - Boots\n209 - Ammo\n210 - Cloak\n211 - Shield\n212 - Robe\n213 - Bracers\n214 - Bardic Item\n215 - Lockpicks", "Mobile Objects: Special NPC Inventory Slots", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// About box
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			AboutForm a = new AboutForm();
			a.ShowDialog();
		}

		// Creating merchants
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("In order to create a merchant, you need to create a dummy invisible container that will serve as a merchant's inventory, and then link it with the merchant itself. You can follow the following basic tutorial to learn this trick:\n\n1) Go to the \"Objects\" tab and create a new mobile object.\n2) Set the prototype to Tutorial Chest A (#1048). The coordinates don't matter.\n3) Add some items to the container inventory. These objects will be sold by the merchant in the future.\n4) Set the object flags OF_DONTDRAW, OF_INVISIBLE, OF_NO_BLOCK, and OF_DYNAMIC. This is essential.\n5) Save the container.\n6) Create a new mobile object and set it to be Blacksmith (#14010). Set its coordinates.\n7) Go to the NPC/Critters tab and set the \"Substitute inventory\" flag.\n8) Click on \"Define\" and select your Tutorial Chest A from the list to link it.\n9) Save your blacksmith MOB.\n10) Enjoy!\n\nNote that your Blacksmith NPC will be naked, so you'll need to set his \"loot\" inventory and assign some items from there to the NPC worn items as well (see the help topic about the special NPC inventory slots to learn how to do this).\n\nVERY IMPORTANT NOTE: You NEED to save your container/NPC every time you ADD or DELETE an item from it! If you forget to do it, the editor may corrupt all the data in your container/NPC file!","Creating a NPC Merchant",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		// Creating respawnable inv merchants
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Creating a merchant with a respawnable inventory is not much harder than creating a generic merchant. Follow the basic tutorial to create a merchant (but **DON'T** set the OF_DYNAMIC flag for the substitute inventory container! This flag shouldn't be set for merchants with respawnable inventory!), but observe the following rules in addition to the ones mentioned in that tutorial:\n\n1) The merchant and its substitute inventory container must be CLOSE to each other. For example, if the merchant himself has the coordinates (505, 457), the substitute inventory container can be assigned the (509, 457) coordinates or something like that.\n2) An inventory source must be set for the substitute inventory container. It should correspond to the ID in INVENSOURCE.MES from which to respawn the inventory.\n\nEnjoy!\nRemember: for a merchant to respawn his inventory, you must rest (not wait!) 24 hours, presumably on the same map where the merchant is set, outside the 800x600 area where the merchant is! Otherwise, you won't see the inventory respawn!", "Mobile Objects - Respawnable Inventories", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Modifying rest options for maps
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("You can control the resting options for all maps in the game (e.g. on which maps you can rest, on which it is dangerous, and where the resting is impossible or you can only pass time)b.\n\nTo do it, you should modify the RANDOM_ENCOUNTER.PY script file. At the bottom of this file there's a function called CAN_SLEEP. It can return different values depending on the map ID (per MapList.mes):\n\nSLEEP_SAFE - it's safe to sleep in the area\nSLEEP_DANGEROUS - resting may provoke a random encounter\nSLEEP_IMPOSSIBLE - rest is not possible here\nSLEEP_PASS_TIME_ONLY - only passing time is possible", "Modifying resting options for maps", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        // Waypoint IDs
        private void commonWaypointAnimationIDsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The following animation IDs can be used for almost all objects when defining an animated waypoint. An animated waypoint can have up to 8 animations defined. Some waypoint anim ID combinations can be used to achieve some special effect (e.g. a combination of Special Animations #1 for Blacksmith makes him play his 'striking with his hammer' animation). Note that if an object doesn't have an animation that you requested, a substitute animation will be chosen by cascading down to a nearest animation ID that the object has.\n\n0 - No animation\n1 - Special Animation 1\n2 - Special Animation 2\n3 - Special Animation 3\n\nPlease note that not all characters have special animations.\nAlso note that the first slot in waypoint animation HAS to be set to a special animation ID other than 0, otherwise the whole sequence won't work.", "Waypoint Animation IDs", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
		#endregion

		#region Jump Point Editor

		string OpenJP = "";
		int OpenJP_Max = 0;
		TabReader tr;
		private void btnOpenJP_Click(object sender, System.EventArgs e)
		{
			MultiODLG.Filter = "Jump point list (jumppoint.tab)|jumppoint.tab";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				OpenJP = MultiODLG.FileName;
				tr = new TabReader(MultiODLG.FileName, FileMode.Open);

				for (int i=0; i<tr.Data.Count; i++)
				{
					string[] elements = tr.Data[i].ToString().Split('\t');
					lstJumpPoints.Items.Add(elements[0]+": "+elements[1]+" (Map "+elements[2]+" at X="+elements[3]+";Y="+elements[4]+")");

					if (Int32.Parse(elements[0]) > OpenJP_Max)
						OpenJP_Max = Int32.Parse(elements[0]);
				}
			}
		}

		private void btnSaveJP_Click(object sender, System.EventArgs e)
		{
			if (OpenJP == "")
			{
				MessageBox.Show("No jump point file is open.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			if (MessageBox.Show("Are you sure you want to save the jump points file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			StreamWriter sw = new StreamWriter(new FileStream(OpenJP, FileMode.Create));
			for (int i=0; i<tr.Data.Count; i++)
				sw.WriteLine(tr.Data[i].ToString());

			sw.Close();

			MessageBox.Show("File saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void lstJumpPoints_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstJumpPoints.SelectedIndex == -1)
				return;

			string[] el = tr.Data[lstJumpPoints.SelectedIndex].ToString().Split('\t');

			JPIndex.Text = el[0];
			JPName.Text = el[1];
			JPMap.Text = el[2];
			JPX.Text = el[3];
			JPY.Text = el[4];
		}

		private void btnDelPoint_Click(object sender, System.EventArgs e)
		{
			if (lstJumpPoints.SelectedIndex == -1)
				return;

			tr.Data.RemoveAt(lstJumpPoints.SelectedIndex);
			lstJumpPoints.Items.Remove(lstJumpPoints.Items[lstJumpPoints.SelectedIndex]);
		}

		private void btnAddPoint_Click(object sender, System.EventArgs e)
		{
			if (OpenJP == "")
				return;

			// Check if a jump point already exists
			for (int i=0; i<tr.Data.Count; i++)
			{
				if (tr.Data[i].ToString().Split('\t')[0] == JPIndex.Text)
				{
					MessageBox.Show("This jump point already exists!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
					return;
				}
			}

			tr.Data.Add(JPIndex.Text+"\t"+JPName.Text+"\t"+JPMap.Text+"\t"+JPX.Text+"\t"+JPY.Text);
			lstJumpPoints.Items.Add(JPIndex.Text+": "+JPName.Text+" (Map "+JPMap.Text+" at X="+JPX.Text+";Y="+JPY.Text+")");
		}

		private void btnUpdatePoint_Click(object sender, System.EventArgs e)
		{
			if (OpenJP == "")
				return;

			if (lstJumpPoints.SelectedIndex == -1)
				return;

			tr.Data[lstJumpPoints.SelectedIndex] = JPIndex.Text+"\t"+JPName.Text+"\t"+JPMap.Text+"\t"+JPX.Text+"\t"+JPY.Text;
			lstJumpPoints.Items[lstJumpPoints.SelectedIndex] = JPIndex.Text+": "+JPName.Text+" (Map "+JPMap.Text+" at X="+JPX.Text+";Y="+JPY.Text+")";
		}

		#endregion

		#region DLL Editor

		private string DLL_Path = "";
		private void btnLoadDLL_Click(object sender, System.EventArgs e)
		{
			MultiODLG.Filter = "Game library (temple.dll)|temple.dll";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				FileInfo fi = new FileInfo(MultiODLG.FileName);
				if ((fi.Length != 3440640) && (fi.Length != 6881280))
				{
					MessageBox.Show("This DLL file is incompatible with the ToEE World Builder!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				DLL_Path = MultiODLG.FileName;
				LawfulGood.Enabled = true;
				LawfulNeutral.Enabled = true;
				LawfulEvil.Enabled = true;
				NeutralGood.Enabled = true;
				TrueNeutral.Enabled = true;
				NeutralEvil.Enabled = true;
				ChaoticGood.Enabled = true;
				ChaoticNeutral.Enabled = true;
				ChaoticEvil.Enabled = true;
				PCCount.Enabled = true;
				chkEnableDebug.Enabled = true;

				// DLL loading code
				BinaryReader br = new BinaryReader(new FileStream(MultiODLG.FileName, FileMode.Open));
				br.BaseStream.Seek(0x0002BBEF, SeekOrigin.Begin);
				PCCount.Text = br.ReadByte().ToString();
				br.BaseStream.Seek(0x002ACE40, SeekOrigin.Begin);
				TrueNeutral.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE44, SeekOrigin.Begin);
				LawfulNeutral.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE48, SeekOrigin.Begin);
				ChaoticNeutral.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE50, SeekOrigin.Begin);
				NeutralGood.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE54, SeekOrigin.Begin);
				LawfulGood.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE58, SeekOrigin.Begin);
				ChaoticGood.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE60, SeekOrigin.Begin);
				NeutralEvil.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE64, SeekOrigin.Begin);
				LawfulEvil.Text = br.ReadUInt32().ToString();
				br.BaseStream.Seek(0x002ACE68, SeekOrigin.Begin);
				ChaoticEvil.Text = br.ReadUInt32().ToString();

				// Debug info
				br.BaseStream.Seek(0x001DFECF, SeekOrigin.Begin);
				byte B1 = br.ReadByte();
				br.BaseStream.Seek(0x001DFEFE, SeekOrigin.Begin);
				byte B2 = br.ReadByte();
				if (B1 != B2)
					MessageBox.Show("Warning: there has been an error parsing the debug output DLL code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

				if (B1 == 0x74)
					chkEnableDebug.Checked = false;
				else
					chkEnableDebug.Checked = true;

				br.Close();
			}
		}

		private void btnSaveDLL_Click(object sender, System.EventArgs e)
		{
			if (DLL_Path == "")
			{
				MessageBox.Show("Please open the TEMPLE.DLL first!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Are you sure you want to save the TEMPLE.DLL?\n\nHINT: You may want to create a backup before you save!", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			BinaryWriter bw = new BinaryWriter(new FileStream(DLL_Path, FileMode.Open));

			// PC count
			bw.BaseStream.Seek(0x0002BBEF, SeekOrigin.Begin);
			bw.Write(byte.Parse(PCCount.Text));
			bw.BaseStream.Seek(0x0002BC4F, SeekOrigin.Begin);
			bw.Write((byte)(8 - byte.Parse(PCCount.Text)));
			bw.BaseStream.Seek(0x000B0187, SeekOrigin.Begin);
			bw.Write((byte)(8 - byte.Parse(PCCount.Text)));

			// Area locations
			bw.BaseStream.Seek(0x002ACE40, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(TrueNeutral.Text));
			bw.BaseStream.Seek(0x002ACE44, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(LawfulNeutral.Text));
			bw.BaseStream.Seek(0x002ACE48, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(ChaoticNeutral.Text));
			bw.BaseStream.Seek(0x002ACE50, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(NeutralGood.Text));
			bw.BaseStream.Seek(0x002ACE54, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(LawfulGood.Text));
			bw.BaseStream.Seek(0x002ACE58, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(ChaoticGood.Text));
			bw.BaseStream.Seek(0x002ACE60, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(NeutralEvil.Text));
			bw.BaseStream.Seek(0x002ACE64, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(LawfulEvil.Text));
			bw.BaseStream.Seek(0x002ACE68, SeekOrigin.Begin);
			bw.Write(UInt32.Parse(ChaoticEvil.Text));

			if (chkEnableDebug.Checked)
			{
				bw.BaseStream.Seek(0x001DFECF, SeekOrigin.Begin);
				bw.Write((byte)0x75);
				bw.BaseStream.Seek(0x001DFEFE, SeekOrigin.Begin);
				bw.Write((byte)0x75);
			}
			else
			{
				bw.BaseStream.Seek(0x001DFECF, SeekOrigin.Begin);
				bw.Write((byte)0x74);
				bw.BaseStream.Seek(0x001DFEFE, SeekOrigin.Begin);
				bw.Write((byte)0x74);
			}

			bw.Close();

			MessageBox.Show("TEMPLE.DLL Saved!","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		#endregion

		#region Prototype Editor

		private void btnSaveProtos_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save all prototypes and descriptions?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Save protos
			StreamWriter sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath)+"\\protos.tab", false);

			for(int i=0; i<protos.Count; i++)
				sw.WriteLine(protos[i]);

			sw.Close();

			// Save descriptions
			StreamWriter sw2 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath)+"\\description.mes", false);

			for(int i=0; i<desc.Count; i++)
				sw2.WriteLine(desc[i]);

			sw2.Close();

			// Save long descriptions
			StreamWriter sw3 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath)+"\\long_description.mes", false);

			for(int i=0; i<ldesc.Count; i++)
				sw3.WriteLine(ldesc[i]);

			sw3.Close();

			MessageBox.Show("Prototypes and descriptions saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void CurProto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Load prototype properties
			lstProtoProps.Items.Clear();
			ArrayList a = ProHelper.PRO_GetColumnNames();

			// Set proto ID
			tProtoID.Text = CurProto.Items[CurProto.SelectedIndex].ToString().Split('#')[1];

			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int k=0; k<protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					protoLine = k;
					break;
				}
			}

			// Read properties from memory
			for (int i=0; i<a.Count; i++)
				lstProtoProps.Items.Add(a[i] + protos[protoLine].ToString().Split('\t')[i].Replace((char)0x0B,' '));

		}

		private void lstProtoProps_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstProtoProps.SelectedIndex == -1)
				return;

			// Set the value field
			tPropValue.Text = lstProtoProps.Items[lstProtoProps.SelectedIndex].ToString().Split('|')[1].Split('\t')[1];

			// TODO: IntelliProperties
			IntelliProp.Items.Clear();
			ArrayList ar_ip = new ArrayList();

			switch (lstProtoProps.SelectedIndex)
			{
				case 1: // OBJECT TYPE
					ar_ip = ProHelper.PRO_GetObjType();
					break;
				case 20: // OBJECT FLAGS (OF_*)
					ar_ip = ProHelper.PRO_GetObjectFlags();
					break;
				case 21: // SPELL FLAGS
					ar_ip = ProHelper.PRO_GetSpellFlags();
					break;
				case 24: // OBJECT SIZE
					ar_ip = ProHelper.PRO_GetObjSize();
					break;
				case 27: // MATERIAL
					ar_ip = ProHelper.PRO_GetMaterial();
					break;
				case 37: // PORTAL FLAGS
					ar_ip = ProHelper.PRO_GetPortalFlags();
					break;
				case 41: // CONTAINER FLAGS
					ar_ip = ProHelper.PRO_GetContainerFlags();
					break;
				case 46: // SCENERY FLAGS
					ar_ip = ProHelper.PRO_GetSceneryFlags();
					break;
				case 50: // ITEM FLAGS
					ar_ip = ProHelper.PRO_GetItemFlags();
					break;
				case 61: // EQUIPMENT SLOT FLAGS
					ar_ip = ProHelper.PRO_GetInvSlotFlags();
					break;
				case 63: // WEAPON FLAGS
					ar_ip = ProHelper.PRO_GetWeaponFlags();
					break;
				case 65: // MISSILE TYPE
					ar_ip = ProHelper.PRO_GetMissileType();
					break;
				case 69: // DAMAGE TYPE
					ar_ip = ProHelper.PRO_GetDamageType();
					break;
				case 72: // WEAPON CLASS
					ar_ip = ProHelper.PRO_GetWeaponClass();
					break;
				case 74: // AMMO FLAGS
					ar_ip = ProHelper.PRO_GetAmmoFlags();
					break;
				case 76: // AMMO TYPE
					ar_ip = ProHelper.PRO_GetAmmoType();
					break;
				case 77: // ARMOR FLAGS
					ar_ip = ProHelper.PRO_GetArmorFlags();
					break;
				case 82: // ARMOR TYPE
					ar_ip = ProHelper.PRO_GetArmorType();
					break;
				case 83: // HELM TYPE
					ar_ip = ProHelper.PRO_GetHelmType();
					break;
				case 86: // COIN TYPE
					ar_ip = ProHelper.PRO_GetCoinType();
					break;
				case 87: // FOOD FLAGS
					ar_ip = ProHelper.PRO_GetFoodFlags();
					break;
				case 94: // BAG FLAGS
					ar_ip = ProHelper.PRO_GetBagFlags();
					break;
				case 96: // GENERIC FLAGS
					ar_ip = ProHelper.PRO_GetGenericFlags();
					break;
				case 99: // CRITTER FLAGS
					ar_ip = ProHelper.PRO_GetCritterFlags();
					break;
				case 100: // CRITTER FLAGS 2
					ar_ip = ProHelper.PRO_GetCritterFlagsII();
					break;
				case 108: // RACE
					ar_ip = ProHelper.PRO_GetRace();
					break;
				case 109: // GENDER
					ar_ip = ProHelper.PRO_GetGender();
					break;
				case 113: // ALIGNMENT
					ar_ip = ProHelper.PRO_GetAlignment();
					break;
				case 114: // DEITY
					ar_ip = ProHelper.PRO_GetDeity();
					break;
				case 115: // DOMAIN 1
				case 116: // DOMAIN 2
					ar_ip = ProHelper.PRO_GetDomain();
					break;
				case 117: // POS/NEG
					ar_ip = ProHelper.PRO_GetPosNeg();
					break;
				case 134:
				case 138:
				case 142:
				case 146: // MONSTER DAMAGE TYPE
					ar_ip = ProHelper.PRO_GetMonsterDamType();
					break;
				case 148: // HAIR COLOR
					ar_ip = ProHelper.PRO_GetHairColor();
					break;
				case 149: // HAIR TYPE
					ar_ip = ProHelper.PRO_GetHairType();
					break;
				case 152: // NPC FLAGS
					ar_ip = ProHelper.PRO_GetNPCFlags();
					break;
				case 163: // CREATURE TYPE
					ar_ip = ProHelper.PRO_GetCreatureType();
					break;
				case 164: // CREATURE SUBTYPE
					ar_ip = ProHelper.PRO_GetCreatureSubType();
					break;
				case 165: // NPC LOOT SHARE
					ar_ip = ProHelper.PRO_GetNPCLootShare();
					break;
				case 166: // TRAP FLAGS
					ar_ip = ProHelper.PRO_GetTrapFlags();
					break;
				case 228:
				case 230:
				case 232:
				case 234:
				case 236: // CHARACTER CLASS
					ar_ip = ProHelper.PRO_GetClass();
					break;
				case 238:
				case 240:
				case 242:
				case 244:
				case 246:
				case 248:
				case 250:
				case 252:
				case 254:
				case 256: // CHARACTER SKILLS
					ar_ip = ProHelper.PRO_GetSkill();
					break;
				case 168:
				case 171:
				case 174:
				case 177:
				case 180:
				case 183:
				case 186:
				case 189:
				case 192:
				case 195:
				case 198: 
				case 201: 
				case 204:
				case 207:
				case 210:
				case 213:
				case 216:
				case 219:
				case 222:
				case 225: // PROPERTIES
					ar_ip = ProHelper.PRO_GetItemProps();
					break;
				case 258:
				case 259:
				case 260:
				case 261:
				case 262:
				case 263:
				case 264:
				case 265:
				case 266:
				case 267: // FEATS
					ar_ip = ProHelper.PRO_GetFeats();
					break;
				default:
					break;
			}

			if (ar_ip.Count > 0)
			{
				for (int i=0; i<ar_ip.Count; i++)
					IntelliProp.Items.Add(ar_ip[i]);
			}
		}

		private void btnIPInsert_Click(object sender, System.EventArgs e)
		{
			if (IntelliProp.Items.Count == 0 || IntelliProp.SelectedIndex == -1)
				return;

			if (tPropValue.Text == "")
				tPropValue.Text = IntelliProp.Items[IntelliProp.SelectedIndex].ToString();
			else
				tPropValue.Text += " " + IntelliProp.Items[IntelliProp.SelectedIndex].ToString();
		}

		private void btnIPReplace_Click(object sender, System.EventArgs e)
		{
			if (IntelliProp.Items.Count == 0 || IntelliProp.SelectedIndex == -1)
				return;
		
			tPropValue.Text = IntelliProp.Items[IntelliProp.SelectedIndex].ToString();
		}

		private void btnUpdateProto_Click(object sender, System.EventArgs e)
		{
			if (lstProtoProps.SelectedIndex == -1)
				return;

			// Check if a player is about to modify the proto's type and warn him
			if (lstProtoProps.SelectedIndex == 1)
			{
				if (MessageBox.Show("Warning: unless you're sure what you are doing, modifying the type directly can have unpredictable results in game mechanics, since the proto ID might get outside the valid range for the new type! Are you sure you want to update the type?","Please confirm dangerous operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					return;
			}

			// If an unidentified description was specified, check if there's one,
			// otherwise add it.
			if (lstProtoProps.SelectedIndex == 55)
			{
				if (tPropValue.Text.Trim().Length != 0)
				{
					if (int.Parse(tPropValue.Text) < 20000)
					{
						MessageBox.Show("An unidentified description identifier must be 20000 or greater!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					bool EXISTS = false;
					for (int t=0; t<lstDesc.Items.Count; t++)
					{
						if (lstDesc.Items[t].ToString().Split(':')[0] == tPropValue.Text)
						{
							EXISTS = true;
							break;
						}
					}

					if (!EXISTS)
					{
						int targetLine = -1;
						int lineID = int.Parse(tPropValue.Text);
						for (int i=0; i<lstDesc.Items.Count; i++)
						{
							string listidx = lstDesc.Items[i].ToString().Split(':')[0];
							if (lineID <= Int32.Parse(listidx))
							{
								targetLine = i;
								break;
							}
						}
						if (targetLine == -1)
							lstDesc.Items.Add(tPropValue.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
						else
							lstDesc.Items.Insert(targetLine, tPropValue.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));

						targetLine = -1;
						for (int i=0; i<desc.Count; i++)
						{
							if (desc[i].ToString().Trim() == "")
								continue;

							if (desc[i].ToString().IndexOf("{") != 0)
								continue;

							string listidx = desc[i].ToString().Split('{','}')[1];
							if (lineID <= Int32.Parse(listidx))
							{
								// + v1.0: See if there's a comment and an empty line above +
								int j = i;
								if (j > 10)
								{
									if (ldesc[j-1].ToString().Length > 0)
									{
										if (desc[j-1].ToString().Substring(0, 1) == "/")
										{
											i--;
											if (desc[j-2].ToString().Trim() == "")
												i--;
											if (desc[j-3].ToString().Trim() == "")
												i--;
											if (desc[j-4].ToString().Trim() == "")
												i--;
											if (desc[j-5].ToString().Trim() == "")
												i--;
										}
									}
								}
								// - v1.0: advanced comment parsing -

								targetLine = i;
								break;
							}
						}
						if (targetLine == -1)
						{
							desc.Add("{"+tPropValue.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");
							MessageBox.Show("A new unidentified description line was added: #"+tPropValue.Text,"Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
						else
						{
							desc.Insert(targetLine, "{"+tPropValue.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");
							MessageBox.Show("A new unidentified description line was added: #"+tPropValue.Text,"Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
						}
					}
				}
			}

			// Set the line value
			lstProtoProps.Items[lstProtoProps.SelectedIndex] = lstProtoProps.Items[lstProtoProps.SelectedIndex].ToString().Split('|')[0]+"|\t"+tPropValue.Text;

			string proto_line = "";
			for (int i=0; i<334; i++)
			{
				if (i != 333)
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1] + "\t";
				else
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1];
			}

			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int k=0; k<protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					protoLine = k;
					break;
				}
			}

			// Set the protos line
			protos[protoLine] = proto_line;

			// Modify the objtype in hashtable so the mob editor keeps in line
			Proto_Types[CurProto.Text] = lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1];
		}

		
		private void btnDelProto_Click(object sender, System.EventArgs e)
		{
			if (CurProto.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this prototype permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Delete a prototype
			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int k=0; k<protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					protoLine = k;
					break;
				}
			}

			// Remove the corresponding description
			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().IndexOf(tProtoID.Text+":") == 0)
				{
					lstDesc.Items.RemoveAt(i);

					// Delete from memory
					for (int j=0; j<desc.Count; j++)
					{
						if (desc[j].ToString().IndexOf("{"+tProtoID.Text+"}") == 0)
							desc.RemoveAt(j);
					}

					// The same for long descriptions
					for (int l=0; l<ldesc.Count; l++)
					{
						if (ldesc[l].ToString().IndexOf("{"+tProtoID.Text+"}") == 0)
							ldesc.RemoveAt(l);
					}
				}
			}

			// Remove the proto
			protos.RemoveAt(protoLine);
			Prototype.Items.RemoveAt(CurProto.SelectedIndex);
			ChestInvProtos.Items.RemoveAt(CurProto.SelectedIndex);
			NpcInvProtos.Items.RemoveAt(CurProto.SelectedIndex);
			CurProto.Items.RemoveAt(CurProto.SelectedIndex);

			// Remove the hashtable entry
			Proto_Types.Remove(CurProto.Text);

			// Clean up
			lstProtoProps.Items.Clear();

			MessageBox.Show("Prototype deleted.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnAddProto_Click(object sender, System.EventArgs e)
		{
			if (CurProto.Text == "")
			{
				MessageBox.Show("Please choose the parent prototype", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (tProtoID.Text == "")
			{
				MessageBox.Show("Please specify the prototype identifier", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (int.Parse(tProtoID.Text) > 16999)
			{
				MessageBox.Show("Identifiers above 16999 are not accepted by the game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Check for identifier validity
			string objtype = lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1];
			int minID = -1;
			int maxID = -1;

			switch (objtype)
			{
				// ensure that the object is in the proper bank
				case "obj_t_portal":
					minID = 0;
					maxID = 999;
					break;
				case "obj_t_container":
					minID = 1000;
					maxID = 1999;
					break;
				case "obj_t_scenery":
					minID = 2000;
					maxID = 2999;
					break;
				case "obj_t_projectile":
					minID = 3000;
					maxID = 3999;
					break;
				case "obj_t_weapon":
					minID = 4000;
					maxID = 4999;
					break;
				case "obj_t_ammo":
					minID = 5000;
					maxID = 5999;
					break;
				case "obj_t_armor":
					minID = 6000;
					maxID = 6999;
					break;
				case "obj_t_money":
					minID = 7000;
					maxID = 7999;
					break;
				case "obj_t_food":
					minID = 8000;
					maxID = 8999;
					break;
				case "obj_t_scroll":
					minID = 9000;
					maxID = 9999;
					break;
				case "obj_t_key":
					minID = 10000;
					maxID = 19999;
					break;
				case "obj_t_written":
					minID = 11000;
					maxID = 11999;
					break;
				case "obj_t_generic":
					minID = 12000;
					maxID = 12999;
					break;
				case "obj_t_pc":
					minID = 13000;
					maxID = 13999;
					break;
				case "obj_t_npc":
					minID = 14000;
					maxID = 14999;
					break;
				case "obj_t_trap":
					minID = 15000;
					maxID = 15999;
					break;
				case "obj_t_bag":
					minID = 16000;
					maxID = 16999;
					break;
				default:
					throw new Exception("Unexpected Error 008: Invalid object type passed to get_obj_type_id_values");
			}

			if (int.Parse(tProtoID.Text) < minID || int.Parse(tProtoID.Text) > maxID)
			{
				MessageBox.Show("The prototype identifier for this object type ("+objtype+") must be between "+minID.ToString()+" and "+maxID.ToString()+"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Check if the prototype already exists
			bool PROTO_EXISTS = false;
			for (int k=0; k<protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					PROTO_EXISTS = true;
					break;
				}
			}

			bool DESC_EXISTS = false;
			for (int l=0; l<desc.Count; l++)
			{
				if (desc[l].ToString().Trim() == "")
					continue;

				if (desc[l].ToString().IndexOf("{") != 0)
					continue;

				if (desc[l].ToString().Split('{','}')[1] == tProtoID.Text)
				{
					DESC_EXISTS = true;
					break;
				}
			}

			if (PROTO_EXISTS)
			{
				MessageBox.Show("The prototype with the given identifier already exists, please specify another ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (DESC_EXISTS)
			{
				MessageBox.Show("The description with the given identifier already exists, please specify another ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Add a new proto if the ID doesn't yet exist
			string proto_line = tProtoID.Text + "\t";
			
			// TODO: VERIFY: This is the description line
			lstProtoProps.Items[23] = lstProtoProps.Items[23].ToString().Split('|')[0]+"|\t"+tProtoID.Text;

			for (int i=1; i<334; i++)
			{
				if (i != 333)
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1] + "\t";
				else
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1];
			}

			int lineID = Int32.Parse(tProtoID.Text);
			int targetLine = -1;
			for (int i=0; i<protos.Count; i++)
			{
				if (protos[i].ToString().Trim() == "")
					continue;

				string listidx = protos[i].ToString().Split('\t')[0];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}

			if (targetLine == -1)
				protos.Add(proto_line);
			else
				protos.Insert(targetLine, proto_line);

			//OLD WAY OF DOING THINGS, TO BE REMOVED
			//protos.Add(proto_line);

			CurProto.Items.Add(CurProto.Text.Split('#')[0]+"#"+tProtoID.Text);
			CurProto.SelectedItem = CurProto.Text.Split('#')[0]+"#"+tProtoID.Text;
			Prototype.Items.Add(CurProto.Text.Split('#')[0]+"#"+tProtoID.Text);
			ChestInvProtos.Items.Add(CurProto.Text.Split('#')[0]+"#"+tProtoID.Text);
			NpcInvProtos.Items.Add(CurProto.Text.Split('#')[0]+"#"+tProtoID.Text);

			// Add a description
			targetLine = -1;
			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				lstDesc.Items.Add(tProtoID.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
			else
				lstDesc.Items.Insert(targetLine, tProtoID.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));

			targetLine = -1;
			for (int i=0; i<desc.Count; i++)
			{
				if (desc[i].ToString().Trim() == "")
					continue;

				if (desc[i].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[i].ToString().Split('{','}')[1];
				if (lineID <= Int32.Parse(listidx))
				{
					// + v1.0: See if there's a comment and an empty line above +
					int j = i;
					if (j > 10)
					{
						if (desc[j-1].ToString().Length > 0)
						{
							if (desc[j-1].ToString().Substring(0, 1) == "/")
								i--;
							if (desc[j-2].ToString().Trim() == "")
								i--;
							if (desc[j-3].ToString().Trim() == "")
								i--;
							if (desc[j-4].ToString().Trim() == "")
								i--;
							if (desc[j-5].ToString().Trim() == "")
								i--;
						}
					}
					// - v1.0: advanced comment parsing -

					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				desc.Add("{"+tProtoID.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");
			else
				desc.Insert(targetLine, "{"+tProtoID.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");

			// OLD WAY OF DOING THINGS, TO BE DELETED
			//lstDesc.Items.Add(tProtoID.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
			//desc.Add("{"+tProtoID.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");

			// Add a hashtable entry
			if (Proto_Types[CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text] == null)
				Proto_Types.Add(CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text, lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1]);
			else
				Proto_Types[CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text] = lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1];

			MessageBox.Show("A new prototype has been added with ID #"+tProtoID.Text+"\n\nHINT: Don't forget to save protos.tab and description.mes!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnGoToDesc_Click(object sender, System.EventArgs e)
		{
			if (CurProto.SelectedIndex == -1 || tProtoID.Text == "")
				return;

			string proto_id = CurProto.Items[CurProto.SelectedIndex].ToString().Split('#')[1];

			// Check if an appropriate description exists and go to description tab
			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().IndexOf(proto_id+":") == 0)
				{
					// Switch the tabs
					lstDesc.SelectedIndex = i;
					GenericTab.SelectedTab = gg_YX_Descriptions;
				}
			}
		}

        private void lstProtoProps_DoubleClick(object sender, EventArgs e)
        {
            // Clean an entry
            if (btnDblClickClean.Checked)
            {
                tPropValue.Text = "";
                btnUpdateProto_Click(sender, e);
            }
        }
		#endregion

		#region Description Editor

		private bool DESC_CALLBACK = false;
		private void btnSaveDesc_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save all descriptions?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Save descriptions
			StreamWriter sw2 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath)+"\\description.mes", false);

			for(int i=0; i<desc.Count; i++)
				sw2.WriteLine(desc[i]);

			sw2.Close();

			// Save long descriptions
			StreamWriter sw3 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath)+"\\long_description.mes", false);

			for(int i=0; i<ldesc.Count; i++)
				sw3.WriteLine(ldesc[i]);

			sw3.Close();

			MessageBox.Show("Descriptions saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);		
		}

		private void lstDesc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
				return;

			// Needed to prevent the autoupdate cleanup
			if (DESC_CALLBACK)
			{
				DESC_CALLBACK = false;
				return;
			}

			tDescID.Text = lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
			tDescript.Text = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2);

			// Check if a long description exists. If it does, load it.
			string Lookup = "{" + tDescID.Text + "}";

			for (int i=0; i<ldesc.Count; i++)
			{
				if (ldesc[i].ToString().IndexOf(Lookup) == 0)
				{
					string[] l_des = ldesc[i].ToString().Split('{','}');
					tLongDescript.Text = l_des[3];
					break;
				}
				else
					tLongDescript.Text = "";
			}
		}

		private void btnLookUpProto_Click(object sender, System.EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
				return;

			if (int.Parse(tDescID.Text) >= 20000)
			{
				MessageBox.Show("Description identifiers above 20000 are reserved for unidentified item descriptions and unknown/known NPC names. They don't correspond to prototypes.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			string ProtoName = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];

			if (CurProto.Items.IndexOf(ProtoName) == -1)
			{
				MessageBox.Show("The selected prototype was not found!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			CurProto.SelectedItem = ProtoName;
			GenericTab.SelectedTab = ff_YT_Prototypes;
		}

		private void btnSetDescs_Click(object sender, System.EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
			{
				MessageBox.Show("Please choose a description from the list first.","Nothing to update",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			string ProtoString = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
			string LookString = "{" + tDescID.Text + "}";

			// Set the short description
			DESC_CALLBACK = true;
			lstDesc.Items[lstDesc.SelectedIndex] = tDescID.Text+": "+tDescript.Text;

			for (int i=0; i<desc.Count; i++)
			{
				if (desc[i].ToString().IndexOf(LookString) == 0)
				{
					desc[i] = LookString + "{" + tDescript.Text + "}";
					break;
				}
			}

			// Update the protos, if the entry is under 20000 (not the unknown description)

			if (int.Parse(tDescID.Text) < 20000)
			{

				int proto_index = -1;
				for (int s=0; s<CurProto.Items.Count; s++)
				{
					if (CurProto.Items[s].ToString() == ProtoString)
					{
						proto_index = s;
						break;
					}
				}

				// Modify the hash table
				if (Proto_Types[tDescript.Text + " -> #" + tDescID.Text] == null)
					Proto_Types.Add(tDescript.Text + " -> #" + tDescID.Text, Proto_Types[Prototype.Items[proto_index]].ToString());

				if (proto_index != -1)
				{
					Prototype.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					CurProto.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					ChestInvProtos.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					NpcInvProtos.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':')+2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
				}
			}

			// Set the long description or remove it, if tlongdescript == ""
			if (tLongDescript.Text.Trim() != "")
			{
				// Set
				bool ALREADY_EXISTS = false;
				for (int i=0; i<ldesc.Count; i++)
				{
					if (ldesc[i].ToString().IndexOf(LookString) == 0)
					{
						ALREADY_EXISTS = true;
						ldesc[i] = LookString + "{" + tLongDescript.Text + "}";
						break;
					}
				}
				if (!ALREADY_EXISTS)
				{
					int targetLine = -1;
					int lineID = int.Parse(tDescID.Text);

					for (int i=0; i<ldesc.Count; i++)
					{
						if (ldesc[i].ToString().Trim() == "")
							continue;

						if (ldesc[i].ToString().IndexOf("{") != 0)
							continue;

						string listidx = ldesc[i].ToString().Split('{','}')[1];
						if (lineID <= Int32.Parse(listidx))
						{
							// + v1.0: See if there's a comment and an empty line above +
							int j = i;
							if (j > 10)
							{
								if (ldesc[j-1].ToString().Length > 0)
								{
									if (ldesc[j-1].ToString().Substring(0, 1) == "/")
									{
										i--;
										if (ldesc[j-2].ToString().Trim() == "")
											i--;
										if (ldesc[j-3].ToString().Trim() == "")
											i--;
										if (ldesc[j-4].ToString().Trim() == "")
											i--;
										if (ldesc[j-5].ToString().Trim() == "")
											i--;
									}
								}
							}
							// - v1.0: advanced comment parsing -

							targetLine = i;
							break;
						}
					}

					if (targetLine == -1)
						ldesc.Add(LookString + "{" + tLongDescript.Text + "}");
					else
						ldesc.Insert(targetLine, LookString + "{" + tLongDescript.Text + "}");
				}
				// OLD WAY OF DOING THINGS, TO BE REMOVED
				// ldesc.Add(LookString + "{" + tLongDescript.Text + "}");
			}
			else
			{
				// Remove
				for (int i=0; i<ldesc.Count; i++)
				{
					if (ldesc[i].ToString().IndexOf(LookString) == 0)
					{
						ldesc.RemoveAt(i);
						break;
					}
				}
			}

			MessageBox.Show("Description entry updated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnAddDesc_Click(object sender, System.EventArgs e)
		{
			if (tDescID.Text == "")
			{
				MessageBox.Show("Please specify an identifier for the new description","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}

			bool ALREADY_EXISTS = false;
			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().Split(':')[0] == tDescID.Text)
				{
					ALREADY_EXISTS = true;
					break;
				}
			}

			if (ALREADY_EXISTS)
			{
				MessageBox.Show("A description with this ID already exists!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			
			if (Int32.Parse(tDescID.Text) < 20000)
			{
				MessageBox.Show("Descriptions with numbers under 20000 are reserved for prototypes and must be added together with a prototype. Please use a prototype editor mode to create a prototype with this ID first. The description entry will be added automatically and could be changed later at any time.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			// Add a description
			int targetLine = -1;
			int lineID = int.Parse(tDescID.Text);

			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				lstDesc.Items.Add(tDescID.Text+": "+tDescript.Text);
			else
				lstDesc.Items.Insert(targetLine, tDescID.Text+": "+tDescript.Text);

			for (int j=0; j<desc.Count; j++)
			{
				if (desc[j].ToString().Trim() == "")
					continue;

				if (desc[j].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[j].ToString().Split('{','}')[1];
				if (lineID <= Int32.Parse(listidx))
				{
					// + v1.0: See if there's a comment and an empty line above +
					int i = j;
					if (i > 10)
					{
						if (desc[i-1].ToString().Length > 0)
						{
							if (desc[i-1].ToString().Substring(0, 1) == "/")
							{
								j--;
								if (desc[i-2].ToString().Trim() == "")
									j--;
								if (desc[i-3].ToString().Trim() == "")
									j--;
								if (desc[i-4].ToString().Trim() == "")
									i--;
								if (desc[i-5].ToString().Trim() == "")
									i--;
							}
						}
					}
					// - v1.0: advanced comment parsing - 

					targetLine = j;
					break;
				}
			}
			if (targetLine == -1)
				desc.Add("{"+tDescID.Text+"}{"+tDescript.Text+"}");
			else
				desc.Insert(targetLine, "{"+tDescID.Text+"}{"+tDescript.Text+"}");

			MessageBox.Show("A description has been added: #"+tDescID.Text, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnRemoveDesc_Click(object sender, System.EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
				return;

			if (MessageBox.Show("WARNING: Deleting descriptions may lead to dangling description references in protos.tab. You must be absolutely sure in what you are doing. Are you sure you want to delete this description?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			int targetLine = -1;
			int lineID = int.Parse(tDescID.Text);

			for (int i=0; i<lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine != -1)
				lstDesc.Items.RemoveAt(targetLine);

			for (int j=0; j<desc.Count; j++)
			{
				if (desc[j].ToString().Trim() == "")
					continue;

				if (desc[j].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[j].ToString().Split('{','}')[1];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = j;
					break;
				}
			}
			if (targetLine != -1)
				desc.RemoveAt(targetLine);

			// v1.0: delete long description if it exists
			for (int k=0; k<ldesc.Count; k++)
			{
				if (ldesc[k].ToString().Trim() == "")
					continue;

				if (ldesc[k].ToString().IndexOf("{") != 0)
					continue;

				string listidx = ldesc[k].ToString().Split('{','}')[1];
				if (lineID <= Int32.Parse(listidx))
				{
					targetLine = k;
					break;
				}
			}
			if (targetLine != -1)
				ldesc.RemoveAt(targetLine);

			MessageBox.Show("A description has been deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);																																																																																 
		}

		#endregion

		#region Map Properties Editor

		string MapPrp = "";
		string GlobalLit = "";
		private void btnOpenProps_Click(object sender, System.EventArgs e)
		{
			MultiODLG.Filter = "Map properties file (map.prp)|map.prp";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				MapPrp = MultiODLG.FileName;
				BinaryReader br = new BinaryReader(new FileStream(MapPrp, FileMode.Open));
				tArtEntry.Text = br.ReadUInt32().ToString();
				br.ReadUInt32().ToString(); // Useless. tArtEntry was initially
				                            // supposed to be 64bit, but Worlded
				                            // sometimes flushed buffers here
				tMapWidth.Text = (br.ReadUInt64() / 64).ToString();
				tMapHeight.Text = (br.ReadUInt64() / 64).ToString();
				br.Close();
				tArtEntry.Enabled = true;
				tMapWidth.Enabled = true;
				tMapHeight.Enabled = true;
				btnSaveProps.Enabled = true;
			}
		}

		private void btnSaveProps_Click(object sender, System.EventArgs e)
		{
			if (MapPrp == "")
				return;

			if (MessageBox.Show("Are you sure you want to save the map properties?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			BinaryWriter bw = new BinaryWriter(new FileStream(MapPrp, FileMode.Create));
			bw.Write(UInt64.Parse(tArtEntry.Text));
			bw.Write(UInt64.Parse(tMapWidth.Text)*64);
			bw.Write(UInt64.Parse(tMapWidth.Text)*64);
			bw.Close();
			MessageBox.Show("Saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		private void btnOpenGLT_Click(object sender, System.EventArgs e)
		{
			MultiODLG.Filter = "Global lighting data (global.lit)|global.lit";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				GlobalLit = MultiODLG.FileName;
				BinaryReader br = new BinaryReader(new FileStream(GlobalLit, FileMode.Open));
				tGLT1.Text = br.ReadUInt32().ToString();
				tGLT2.SelectedIndex = br.ReadInt32();
				tGLTRed.Text = br.ReadSingle().ToString();
				tGLTGreen.Text = br.ReadSingle().ToString();
				tGLTBlue.Text = br.ReadSingle().ToString();
				tGLT3.Text = br.ReadSingle().ToString();
				tGLT4.Text = br.ReadSingle().ToString();
				tGLT5.Text = br.ReadSingle().ToString();
				tGLTStartAngle.Text = br.ReadSingle().ToString();
				tGLTEndAngle.Text = br.ReadSingle().ToString();
				tGLT6.Text = br.ReadSingle().ToString();
				tGLT7.Text = br.ReadSingle().ToString();
				tGLT8.Text = br.ReadSingle().ToString();
				br.Close();
				tGLT1.Enabled = true;
				tGLT2.Enabled = true;
				tGLTRed.Enabled = true;
				tGLTGreen.Enabled = true;
				tGLTBlue.Enabled = true;
				tGLT3.Enabled = true;
				tGLT4.Enabled = true;
				tGLT5.Enabled = true;
				tGLTStartAngle.Enabled = true;
				tGLTEndAngle.Enabled = true;
				tGLT6.Enabled = true;
				tGLT7.Enabled = true;
				tGLT8.Enabled = true;
				btnSaveGLT.Enabled = true;
			}	
		}

		private void btnSaveGLT_Click(object sender, System.EventArgs e)
		{
			if (GlobalLit == "")
				return;

			if (MessageBox.Show("Are you sure you want to save the global lighting data?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			try
			{
				BinaryWriter bw = new BinaryWriter(new FileStream(GlobalLit, FileMode.Create));
				bw.Write(UInt32.Parse(tGLT1.Text));
				bw.Write((int)tGLT2.SelectedIndex);
				bw.Write(Single.Parse(tGLTRed.Text));
				bw.Write(Single.Parse(tGLTGreen.Text));
				bw.Write(Single.Parse(tGLTBlue.Text));
				bw.Write(Single.Parse(tGLT3.Text));
				bw.Write(Single.Parse(tGLT4.Text));
				bw.Write(Single.Parse(tGLT5.Text));
				bw.Write(Single.Parse(tGLTStartAngle.Text));
				bw.Write(Single.Parse(tGLTEndAngle.Text));
				bw.Write(Single.Parse(tGLT6.Text));
				bw.Write(Single.Parse(tGLT7.Text));
				bw.Write(Single.Parse(tGLT8.Text));
				bw.Close();
				MessageBox.Show("Saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				MessageBox.Show("There was an error saving GLOBAL.LIT. Possibly one or more fields contain an illegal value.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

        private void btnNewGLT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to create a new global lighting file? (if you answer yes, you'll be asked to point to the folder where you want to save your file)", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            SaveFileDialog sdlg = new SaveFileDialog();
            sdlg.Filter = "Global lighting data (global.lit)|global.lit";
            sdlg.FileName = "global.lit";
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                GlobalLit = sdlg.FileName;
                tGLT1.Text = "1";
                tGLT2.SelectedIndex = 3;
                tGLTRed.Text = "0";
                tGLTGreen.Text = "0";
                tGLTBlue.Text = "0";
                tGLT3.Text = "0";
                tGLT4.Text = "0";
                tGLT5.Text = "0";
                tGLTStartAngle.Text = "0";
                tGLTEndAngle.Text = "0";
                tGLT6.Text = "0";
                tGLT7.Text = "0";
                tGLT8.Text = "0";
                tGLT1.Enabled = true;
                tGLT2.Enabled = true;
                tGLTRed.Enabled = true;
                tGLTGreen.Enabled = true;
                tGLTBlue.Enabled = true;
                tGLT3.Enabled = true;
                tGLT4.Enabled = true;
                tGLT5.Enabled = true;
                tGLTStartAngle.Enabled = true;
                tGLTEndAngle.Enabled = true;
                tGLT6.Enabled = true;
                tGLT7.Enabled = true;
                tGLT8.Enabled = true;
                btnSaveGLT.Enabled = true;
            }
        }

		#endregion

		#region Sector Editor

		private string SecFile = "";
		private byte WallFlag4 = 0;
		private byte WallFlag5 = 0;
		private byte WallFlag6 = 0;
		private byte WallFlag7 = 0;

		// Callbacks
		private bool SEC_CALLBACK = false;
		private bool AUTO_CALLBACK = false;

		// Static object hashtable
		private ArrayList static_objlist = new ArrayList();
		private ArrayList static_objguid = new ArrayList();

		// + SVB Stuff +
		private string SVB_Bitmap = "ENOSVB";
		// - SVB Stuff -

		private void btnOpenSec_Click(object sender, System.EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Please close the Sector Analyzer/Painter before opening sector!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			OpenSEC o = new OpenSEC();
			if (o.ShowDialog() == DialogResult.OK)
			{
				SEC_CALLBACK = true;

				if (chkAutoTile.Checked)
				{
					chkAutoTile.Checked = false;
					AUTO_CALLBACK = true;
				}

				// Safety: set the TX/TY min to 0 and max to 1000000
				TX.Minimum = 0;
				TY.Minimum = 0;
				TX.Maximum = 1000000;
				TY.Maximum = 1000000;
				FromTX.Minimum = 0;
				FromTY.Minimum = 0;
				FromTX.Maximum = 1000000;
				FromTY.Maximum = 1000000;
				ToTX.Minimum = 0;
				ToTY.Minimum = 0;
				ToTX.Maximum = 1000000;
				ToTY.Maximum = 1000000;
				Light10_X.Minimum = 0;
				Light10_X.Value = 0;
				Light10_X.Maximum = 1000000;
				Light11_Y.Minimum = 0;
				Light11_Y.Value = 0;
				Light11_Y.Maximum = 1000000;

				// Lights cleanup
				LightID.Minimum = 0;
				LightID.Maximum = 0; // max = # lights created
				LightID.Value = 0;
				SetLightEdInterfaceState(0, new Helper.LightInfo());

				// Load the sector file
				SecFile = "Sectors\\"+o.FileToOpen+".sec";
				tabSectorEd.Enabled = true;
				btnSaveSec.Enabled = true;
				btnDelLights.Enabled = true;
				btnDelObjects.Enabled = true;
				btnResetTiles.Enabled = true;

				SecFile = "Sectors\\"+o.FileToOpen+".sec";

				int minX = -1;
				int maxX = -1;
				int minY = -1;
				int maxY = -1;

				Helper.Sec_GetMinMax(o.FileToOpen, ref minY, ref maxY, ref minX, ref maxX);
				tu_0_0.Text = String.Format("({0},{1})", minX, minY);
				tu_X_0.Text = String.Format("({0},{1})", maxX, minY);
				tu_0_Y.Text = String.Format("({0},{1})", minX, maxY);
				tu_X_Y.Text = String.Format("({0},{1})", maxX, maxY);
				tv_0_0.Text = String.Format("({0},{1})", minX, minY);
				tv_X_0.Text = String.Format("({0},{1})", maxX, minY);
				tv_0_Y.Text = String.Format("({0},{1})", minX, maxY);
				tv_X_Y.Text = String.Format("({0},{1})", maxX, maxY);

				tCurSector.Text = o.FileToOpen+".sec";

				// Load the file
				BinaryReader r_sec = new BinaryReader(new FileStream(SecFile, FileMode.Open));
				
				// Cleanup
				Helper.SectorLights.Clear();
				Helper.SectorLightsChunk.Clear();
				Helper.SectorTiles.Clear();

				// Load lights
				uint LightCount = r_sec.ReadUInt32(); // the # of lights
				
				Helper.LightInfo light = new Helper.LightInfo();
				
				// Check if lights can be loaded	
				bool CanLoadLights = true;
				long approx_pos = (long)LightCount * 108;
				long real_pos = -1;

				if (LightCount > 0)
				{
					long p_Stream = r_sec.BaseStream.Position;

					r_sec.BaseStream.Seek(0, SeekOrigin.Begin);
					long p_StreamA = 0;

					while ((r_sec.ReadUInt64() != 0xAA000400000001))
					{
						p_StreamA++;
						real_pos = r_sec.BaseStream.Position;
						r_sec.BaseStream.Seek(p_StreamA, SeekOrigin.Begin);
					}
                    
					real_pos -= 65547; // compensate for tiles and light count
					r_sec.BaseStream.Seek(p_Stream, SeekOrigin.Begin);

					if (real_pos != approx_pos)
					{
                        // v1.7.5c: Disabled the old light editor. The code remains for compatibility only.
						//MessageBox.Show("Warning: This sector contains unsupported light data structures. Light editing will be disabled for this sector unless you remove all lights.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);

						btnLightAdd.Enabled = false;
						CanLoadLights = false;
					}
					else
					{
						btnLightAdd.Enabled = true;
					}
				}
				else
				{
					real_pos = approx_pos;
				}

				if (CanLoadLights)
				{
					for (int i=0; i<LightCount; i++)
					{
						Helper.LoadLight(r_sec, ref light);
						Helper.SectorLights.Add(light);
						LightID.Maximum++;
						SetLightEdInterfaceState(1, light); // light is passed on
					}
					if (Helper.SectorLights.Count > 0)
					{
						SetLightEdInterfaceState(1, new Helper.LightInfo());
						LightID.Maximum--; // compensate for light #0
						LightID_ValueChanged(null, null); // load light #0
					}
				}
				else
				{
					// Load as one single chunk
					r_sec.BaseStream.Seek(0, SeekOrigin.Begin);
					Helper.SectorLightsChunk.Add(r_sec.ReadBytes((int)(real_pos) + 4));
				}

					// OLDER WAY OF LOADING LIGHTS, TO BE REMOVED
					// Helper.SectorLights.Add(r_sec.ReadBytes(108));

				// Load tiledata
				for (int j=0; j<4096; j++)
					Helper.SectorTiles.Add(r_sec.ReadBytes(16));

				// Skip past the unknown empty data
				r_sec.ReadBytes(48);

				// Load the unified block of objects 
				// (objects are loaded as a chunk of bytes, so that the
				// array can be walked through later by sector object manager)
				Helper.SectorObjects.Clear();
				while (r_sec.BaseStream.Position != r_sec.BaseStream.Length)
					Helper.SectorObjects.Add(r_sec.ReadByte());

				r_sec.Close();

				// + v1.1: Static object parser +
				
				static_objlist = new ArrayList();
				static_objguid = new ArrayList();
				SetStaticObjInterfaceState(false);

				if (Helper.SectorObjects.Count != 4) /* 0x04 = NO OBJECTS */
				{
					// First of all, dump SectorObjects to a temporary OFF file
					BinaryWriter w_off = new BinaryWriter(new FileStream("temp.off", FileMode.Create));
					for (int i=0; i<Helper.SectorObjects.Count; i++)
						w_off.Write((byte)Helper.SectorObjects[i]);
					w_off.Close();

					// Walk through the object dump to detect object boundaries
					long p_Stream = 0;
					bool IS_OBJECT = false;
					BinaryReader r_off = new BinaryReader(new FileStream("temp.off", FileMode.Open));

					while (r_off.BaseStream.Position != r_off.BaseStream.Length - 60)
					{
						p_Stream = r_off.BaseStream.Position;
						IS_OBJECT = true;

						if (r_off.ReadByte() != 0x77)
							IS_OBJECT = false;

						r_off.BaseStream.Seek(p_Stream + 1, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 2, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 3, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 4, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x01)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 5, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 28, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 29, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 30, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 31, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 32, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 33, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 34, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;
						r_off.BaseStream.Seek(p_Stream + 35, SeekOrigin.Begin);
						if (r_off.ReadByte() != 0x00)
							IS_OBJECT = false;

						// If it's a new object boundary, add the pointer to
						// that object to the objlist
						if (IS_OBJECT)
							static_objlist.Add(p_Stream);

						p_Stream++;
						r_off.BaseStream.Seek(p_Stream, SeekOrigin.Begin);
					}

					// Add the last object's terminal location and close up
					static_objlist.Add(r_off.BaseStream.Length - 4);
					r_off.Close();

					// Read the static object properties and add them to the list
					// Note that the last object pointer is terminal, and thus
					// must not be used.
					BinaryReader readobj = new BinaryReader(new FileStream("temp.off", FileMode.Open));
					for(int itm = 0; itm<static_objlist.Count - 1; itm++)
					{
						// Acquire a pointer and read all the needed data
						readobj.BaseStream.Seek((long)static_objlist[itm] + 0x0C, SeekOrigin.Begin);
						Int16 proto_id = readobj.ReadInt16();
						readobj.BaseStream.Seek((long)static_objlist[itm] + 0x34, SeekOrigin.Begin);
						UInt32 type = readobj.ReadUInt32();
						readobj.BaseStream.Seek((long)static_objlist[itm] + 0x3A, SeekOrigin.Begin);
						long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes)type);
						readobj.BaseStream.Seek(BlocksToSkip * 4 + 1, SeekOrigin.Current);
						UInt32 x_coord = readobj.ReadUInt32();
						UInt32 y_coord = readobj.ReadUInt32();
						// + GUID +
						readobj.BaseStream.Seek((long)static_objlist[itm] + 0x1C, SeekOrigin.Begin);
						string proto_guid = Helper.GEN_ConvertBytesToStringGUID(readobj.ReadBytes(24));
						// - GUID -
						string proto_name = "";
						try
						{
							proto_name = Helper.Proto_By_ID[proto_id.ToString()].ToString();
						}
						catch (Exception)
						{
							// can't yet be added
							MessageBox.Show("The object embedded in this sector file has a proto ID that has been added recently (or that doesn't exist in PROTOS.TAB). Therefore, if the prototype was added recently, the PROTOS.TAB must be reloaded for this object to be parsed correctly. Please restart ToEE World Builder if you want the object name to be properly displayed.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
							proto_name = "(NOT PARSABLE)";
						}

						static_objguid.Add(proto_guid);
						SecObjList.Items.Add(itm.ToString()+":\t("+x_coord.ToString()+","+y_coord.ToString()+")\t\t\t"+proto_name);
					}
					readobj.Close();

					// Delete the temporary OFF file
					File.Delete("temp.off");
				}

				// - v1.1: Static object parser -

				// Set TX/TY to minimal possible X/Y for this sector
				TX.Value = minX; 
				TY.Value = minY; 
				TX.Minimum = TX.Value;
				TY.Minimum = TY.Value;
				TX.Maximum = TX.Value + 63;
				TY.Maximum = TY.Value + 63;
				FromTX.Value = minX; 
				FromTY.Value = minY; 
				FromTX.Minimum = FromTX.Value;
				FromTY.Minimum = FromTY.Value;
				FromTX.Maximum = FromTX.Value + 63;
				FromTY.Maximum = FromTY.Value + 63;
				ToTX.Value = minX; 
				ToTY.Value = minY; 
				ToTX.Minimum = ToTX.Value;
				ToTY.Minimum = ToTY.Value;
				ToTX.Maximum = ToTX.Value + 63;
				ToTY.Maximum = ToTY.Value + 63;
				Light10_X.Value = minX;
				Light11_Y.Value = minY;
				Light10_X.Minimum = Light10_X.Value;
				Light10_X.Maximum = Light10_X.Value + 63;
				Light11_Y.Minimum = Light11_Y.Value;
				Light11_Y.Maximum = Light11_Y.Value + 63;

				// Load the SVB file, if it exists
				string SVBFile = "Sectors\\"+Path.GetFileNameWithoutExtension(SecFile)+".svb";

				if (File.Exists(SVBFile))
				{
					SVB_Bitmap = "";
					BinaryReader r_svb = new BinaryReader(new FileStream(SVBFile, FileMode.Open));

					for (int i=0; i<2304; i++)
						SVB_Bitmap += Helper.GEN_UInt64_To_Bitmap(r_svb.ReadUInt64());

					// +DEBUG+
					// MessageBox.Show(SVB_Bitmap.Length.ToString());
					// -DEBUG-

					r_svb.Close();
				}
				else
				{
					// Clean up the previous SVB info
					SVB_Bitmap = Helper.SVB_NewBitmap();
				}

				// Load the HSD file, if it exists
				string HSDFile = "Sectors\\hsd"+Path.GetFileNameWithoutExtension(SecFile)+".hsd";
				
				if (File.Exists(HSDFile))
				{
					BinaryReader r_hsd = new BinaryReader(new FileStream(HSDFile, FileMode.Open));
					r_hsd.ReadInt32(); // version tag, skipping it

					for (int i=0; i<36864; i++)
						Helper.HSD_Tiles[i] = r_hsd.ReadByte();

					r_hsd.Close();
				}
				else
				{
					// Clean up the previous HSD info
					Helper.HSD_Tiles = Helper.HSD_NewArray();
				}

				btnLoadTile_Click(null, null); // Load the first tile

				if (AUTO_CALLBACK)
				{
					AUTO_CALLBACK = false;
					chkAutoTile.Checked = true;
				}
			}
		}

		private void btnNewSector_Click(object sender, System.EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Please close the Sector Analyzer/Painter before creating a new sector!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			CreateNewSector cn = new CreateNewSector();
			if (cn.ShowDialog() == DialogResult.OK)
			{
				if (cn.FileToOpen == "")
					return;

				SEC_CALLBACK = true;

				if (chkAutoTile.Checked)
				{
					chkAutoTile.Checked = false;
					AUTO_CALLBACK = true;
				}

				// Safety: set the TX/TY min to 0 and max to 1000000
				TX.Minimum = 0;
				TY.Minimum = 0;
				TX.Maximum = 1000000;
				TY.Maximum = 1000000;
				FromTX.Minimum = 0;
				FromTY.Minimum = 0;
				FromTX.Maximum = 1000000;
				FromTY.Maximum = 1000000;
				ToTX.Minimum = 0;
				ToTY.Minimum = 0;
				ToTX.Maximum = 1000000;
				ToTY.Maximum = 1000000;
				Light10_X.Minimum = 0;
				Light10_X.Value = 0;
				Light10_X.Maximum = 1000000;
				Light11_Y.Minimum = 0;
				Light11_Y.Value = 0;
				Light11_Y.Maximum = 1000000;

				btnLightAdd.Enabled = true;

				// Lights cleanup
				LightID.Minimum = 0;
				LightID.Maximum = 0; // max = # lights created
				LightID.Value = 0;
				SetLightEdInterfaceState(0, new Helper.LightInfo());

				// Create a new sector file data
				SecFile = "Sectors\\"+cn.FileToOpen+".sec";
				tabSectorEd.Enabled = true;
				btnSaveSec.Enabled = true;
				btnDelLights.Enabled = true;
				btnDelObjects.Enabled = true;
				btnResetTiles.Enabled = true;
				
				Helper.SEC_CreateNewData();

				tu_0_0.Text = String.Format("({0},{1})", cn.minX, cn.minY);
				tu_X_0.Text = String.Format("({0},{1})", cn.maxX, cn.minY);
				tu_0_Y.Text = String.Format("({0},{1})", cn.minX, cn.maxY);
				tu_X_Y.Text = String.Format("({0},{1})", cn.maxX, cn.maxY);
				tv_0_0.Text = String.Format("({0},{1})", cn.minX, cn.minY);
				tv_X_0.Text = String.Format("({0},{1})", cn.maxX, cn.minY);
				tv_0_Y.Text = String.Format("({0},{1})", cn.minX, cn.maxY);
				tv_X_Y.Text = String.Format("({0},{1})", cn.maxX, cn.maxY);

				tCurSector.Text = cn.FileToOpen+".sec";

	            // clean up static object list
				static_objlist = new ArrayList();
				static_objguid = new ArrayList();
				SetStaticObjInterfaceState(false);

				// Set TX/TY to minimal possible X/Y for this sector
				TX.Value = cn.minX; 
				TY.Value = cn.minY; 
				TX.Minimum = TX.Value;
				TY.Minimum = TY.Value;
				TX.Maximum = TX.Value + 63;
				TY.Maximum = TY.Value + 63;
				FromTX.Value = cn.minX; 
				FromTY.Value = cn.minY; 
				FromTX.Minimum = FromTX.Value;
				FromTY.Minimum = FromTY.Value;
				FromTX.Maximum = FromTX.Value + 63;
				FromTY.Maximum = FromTY.Value + 63;
				ToTX.Value = cn.minX; 
				ToTY.Value = cn.minY; 
				ToTX.Minimum = ToTX.Value;
				ToTY.Minimum = ToTY.Value;
				ToTX.Maximum = ToTX.Value + 63;
				ToTY.Maximum = ToTY.Value + 63;
				Light10_X.Value = cn.minX;
				Light11_Y.Value = cn.minY;
				Light10_X.Minimum = Light10_X.Value;
				Light10_X.Maximum = Light10_X.Value + 63;
				Light11_Y.Minimum = Light11_Y.Value;
				Light11_Y.Maximum = Light11_Y.Value + 63;

				// Make sure the SVB/HSD data is empty when a new sector is created
				SVB_Bitmap = Helper.SVB_NewBitmap();
				Helper.HSD_Tiles = Helper.HSD_NewArray();

				btnLoadTile_Click(null, null); // Load the first tile

				if (AUTO_CALLBACK)
				{
					AUTO_CALLBACK = false;
					chkAutoTile.Checked = true;
				}
			}
		}

		private void btnSaveSec_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the current sector file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string SVBFile = "Sectors\\"+Path.GetFileNameWithoutExtension(SecFile)+".svb";
			string HSDFile = "Sectors\\hsd"+Path.GetFileNameWithoutExtension(SecFile)+".hsd";

			BinaryWriter w_sec = new BinaryWriter(new FileStream(SecFile, FileMode.Create));

			if (Helper.SectorLightsChunk.Count == 0)
			{
				w_sec.Write(Helper.SectorLights.Count); // the number of light objects

				for (int i=0; i<Helper.SectorLights.Count; i++)
					Helper.SaveLight(w_sec, (Helper.LightInfo)Helper.SectorLights[i]);
			}
			else
			{
				w_sec.Write((byte[])Helper.SectorLightsChunk[0]);
			}

				// OLD WAY OF WRITING BACK LIGHTS. TO BE REMOVED.
				// w_sec.Write((byte[])Helper.SectorLights[i]); // write a light

			for (int i=0; i<4096; i++)
				w_sec.Write((byte[])Helper.SectorTiles[i]); // write tiledata

			Helper.SEC_WriteUnknownEmptyAreas(w_sec); // write unknown stuff

			for (int i=0; i<Helper.SectorObjects.Count; i++)
				w_sec.Write((byte)Helper.SectorObjects[i]); // write objects

			w_sec.Close();

			// Saving the SVB file
			if (SVB_Bitmap.IndexOf("1") == -1)
			{
				// no data is set or ENOSVB, so delete the SVB file if it exists
				if(cfgDelEmpty.Checked)
				{
					if(File.Exists(SVBFile))        
						File.Delete(SVBFile);
				}
				else
				{
					BinaryWriter w_svb = new BinaryWriter(new FileStream(SVBFile, FileMode.Create));
					ArrayList svb_bytes = Helper.MOB_BitmapToBytes(SVB_Bitmap);			

					foreach (object block in svb_bytes)
						w_svb.Write((byte)block);

					w_svb.Close();
				}
			}
			else
			{
				// flush all the data to disk
				BinaryWriter w_svb = new BinaryWriter(new FileStream(SVBFile, FileMode.Create));
				ArrayList svb_bytes = Helper.MOB_BitmapToBytes(SVB_Bitmap);			

				foreach (object block in svb_bytes)
					w_svb.Write((byte)block);

				w_svb.Close();
			}

			// Saving the HSD file
			if (Helper.HSD_CheckIsSaveNecessary())
			{
				// saving is necessary (at least one subtile is set)
				BinaryWriter w_hsd = new BinaryWriter(new FileStream(HSDFile, FileMode.Create));
				
				w_hsd.Write((Int32)0x02); // save the HSD version tag

				for (int i=0; i<36864; i++)
					w_hsd.Write(Helper.HSD_Tiles[i]); // save the tile info

				w_hsd.Close();
			}
			else
			{
				// no water subtiles were set, delete the HSD file if it exists
				if(cfgDelEmpty.Checked)
				{
					if(File.Exists(HSDFile))
						File.Delete(HSDFile);
				}
				else
				{
					BinaryWriter w_hsd = new BinaryWriter(new FileStream(HSDFile, FileMode.Create));
				
					w_hsd.Write((Int32)0x02); // save the HSD version tag

					for (int i=0; i<36864; i++)
						w_hsd.Write(Helper.HSD_Tiles[i]); // save the tile info

					w_hsd.Close();
				}
			}

			MessageBox.Show("Sector saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnDelLights_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Warning: this operation will delete all lights in this sector!\nAre you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			Helper.SectorLights.Clear();
			Helper.SectorLightsChunk.Clear();
			LightID.Minimum = 0;
			LightID.Value = 0;
			LightID.Maximum = 0;
			SetLightEdInterfaceState(0, new Helper.LightInfo());
			btnLightAdd.Enabled = true;

			MessageBox.Show("Lights removed.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnDelObjects_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Warning: this operation will delete all objects in this sector!\nAre you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			Helper.SectorObjects.Clear();
			Helper.SectorObjects.Add((byte)0x00);
			Helper.SectorObjects.Add((byte)0x00);
			Helper.SectorObjects.Add((byte)0x00);
			Helper.SectorObjects.Add((byte)0x00);

			// v1.1a: Clean up static object cache
			SecObjList.Items.Clear();
			static_objlist = new ArrayList();
			static_objguid = new ArrayList();
			SetStaticObjInterfaceState(false);

			MessageBox.Show("Objects removed.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnResetTiles_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Warning: this operation will reset all tiles to the Fully Passable state!\nAre you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			byte[] tiledata = new byte[16];
			tiledata[0] = 0x02;

			for (int j=1; j<16; j++)
				tiledata[j] = 0x00;

			for (int i=0; i<4096; i++)
				Helper.SectorTiles[i] = tiledata;

			if (MessageBox.Show("Do you want to clear the sector visibility blocking information for all tiles as well?","Please confirm additional operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				SVB_Bitmap = Helper.SVB_NewBitmap();

			if (MessageBox.Show("Do you want to clear the negative height/water tile information for all tiles as well?","Please confirm additional operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				Helper.HSD_Tiles = Helper.HSD_NewArray();

			MessageBox.Show("Tile data reset.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);		
		}
		
		private void btnUpdateTile_Click(object sender, System.EventArgs e)
		{
			// VERIFY: Is this STX/STY calculation routine working correctly?
			int STX = -1; // final X location in the sector file
			int STY = -1; // final Y location in the sector file

			STX = (int)TX.Value - (int)TX.Minimum;
			STY = (int)TY.Value - (int)TY.Minimum;

			if (STX > 63 || STX < 0)
			{
				MessageBox.Show("Warning: the X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (STY > 63 || STY < 0)
			{
				MessageBox.Show("Warning: the Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			bool INTERNAL_CALLBACK = chkAutoTile.Checked;

			// CRITICAL: Tile creation routine! Add support for new tile stuff here!
			SetWallFlags();
			SetWaterFlags(STX, STY);
            SVB_Bitmap = SetSVBFlags(SVB_Bitmap, Helper.SVB_GetTileAddress(STX, STY));
			//SVB_Bitmap = Helper.SVB_SetPropertyLine(SVB_Bitmap, destflags, Helper.SVB_GetTileAddress(STX, STY));

			byte[] tile = Helper.SEC_MakeTileData((byte)cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
			Helper.SEC_SetTileData(STX, STY, tile);

			chkAutoTile.Checked = INTERNAL_CALLBACK;

			// v1.6: Display the message only if outside the sys message queue
			if ((!SysMsg.SM_PAINT_TILE) && (!SysMsg.SM_SVB1) && (!SysMsg.SM_SVB2) && (!SysMsg.SM_SVB3) && (!SysMsg.SM_SVB4))
				MessageBox.Show("Tile updated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		private void btnUpdateAllTiles_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Warning: this will update all tiles in the current sector with the information defined above! Are you sure you want to continue?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
				return;

			int STX = -1;
			int STY = -1;

			bool INTERNAL_CALLBACK = chkAutoTile.Checked;

			for (STX = 0; STX < 64; STX++)
			{
				for (STY = 0; STY < 64; STY++)
				{
					// CRITICAL: Tile creation routine! Add support for new tile stuff here!
					SetWallFlags();
					SetWaterFlags(STX, STY);
                    SVB_Bitmap = SetSVBFlags(SVB_Bitmap, Helper.SVB_GetTileAddress(STX, STY));
                    byte[] tile = Helper.SEC_MakeTileData((byte)cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
					Helper.SEC_SetTileData(STX, STY, tile);
				}
			}

			chkAutoTile.Checked = INTERNAL_CALLBACK;
			MessageBox.Show("All tiles updated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		private void btnUpdateBoxTiles_Click(object sender, System.EventArgs e)
		{
			if ((FromTX.Value == ToTX.Value && FromTY.Value == ToTY.Value) || (FromTX.Value > ToTX.Value) || (FromTY.Value > ToTY.Value))
			{
				MessageBox.Show("Invalid tile box specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Warning: this will update a group of tiles with the information defined above. Are you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			int From_STX = (int)(FromTX.Value - FromTX.Minimum);
			int From_STY = (int)(FromTY.Value - FromTY.Minimum);
			int To_STX = (int)(ToTX.Value - ToTX.Minimum);
			int To_STY = (int)(ToTY.Value - ToTY.Minimum);

			// string destflags = SetSVBFlags();

			if (From_STX > 63 || From_STX < 0)
			{
				MessageBox.Show("Warning: the From_X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (From_STY > 63 || From_STY < 0)
			{
				MessageBox.Show("Warning: the From_Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (To_STX > 63 || To_STX < 0)
			{
				MessageBox.Show("Warning: the To_X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (To_STY > 63 || To_STY < 0)
			{
				MessageBox.Show("Warning: the To_Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			int Cur_TX = -1;
			int Cur_TY = -1;
			bool INTERNAL_CALLBACK = chkAutoTile.Checked;

			for (Cur_TX = From_STX; Cur_TX <= To_STX; Cur_TX++)
			{
				for (Cur_TY = From_STY; Cur_TY <= To_STY; Cur_TY++)
				{
					// CRITICAL: Tile creation routine! Add support for new tile stuff here!
					SetWallFlags();
					SetWaterFlags(Cur_TX, Cur_TY);
                    SVB_Bitmap = SetSVBFlags(SVB_Bitmap, Helper.SVB_GetTileAddress(Cur_TX, Cur_TY));
					byte[] tile = Helper.SEC_MakeTileData((byte)cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
					Helper.SEC_SetTileData(Cur_TX, Cur_TY, tile);
				}
			}

			chkAutoTile.Checked = INTERNAL_CALLBACK;
			MessageBox.Show("A box of tiles updated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		
		private void btnLoadTile_Click(object sender, System.EventArgs e)
		{
			int RealTY = (int)(TY.Value - TY.Minimum);
			int RealTX = (int)(TX.Value - TX.Minimum);
			byte[] tile;

			if (SEC_CALLBACK)
			{
				SEC_CALLBACK = false;
				tile = (byte[])Helper.SectorTiles[0];
			}
			else
			{
				tile = (byte[])Helper.SectorTiles[RealTY*64+RealTX];
			}

			// CRITICAL: Load the known tile data (unknown is skipped atm)
			cmbTileSound.SelectedIndex = tile[0];

			WallFlag4 = tile[4];
			WallFlag5 = tile[5];
			WallFlag6 = tile[6];
			WallFlag7 = tile[7];
			
			byte[] wflagbytes = {   tile[4],
									tile[5],
									tile[6],
									tile[7]};
			
			// Load the wall flags (using a MOB routine to carry out the task)
			string WallBitmap = Helper.MOB_BytesToBitmap(wflagbytes);
			GetWallFlags(WallBitmap);

			// Load the SVB data
			if (SVB_Bitmap.IndexOf("1") != -1) /* SVB file was loaded or created */
			{
				// First, get the index to the first bit of the tile
				int SVB_index = Helper.SVB_GetTileAddress(RealTX, RealTY);
				
				// Load the properties
				SVB1_UR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index) == TriState.True) ? true : false;
				SVB2_UR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 1) == TriState.True) ? true : false;
				SVB3_UR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 2) == TriState.True) ? true : false;
				SVB4_UR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 3) == TriState.True) ? true : false;
				SVB1_UM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 4) == TriState.True) ? true : false;
				SVB2_UM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 4 + 1) == TriState.True) ? true : false;
				SVB3_UM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 4 + 2) == TriState.True) ? true : false;
				SVB4_UM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 4 + 3) == TriState.True) ? true : false;
				SVB1_UL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 8 ) == TriState.True) ? true : false;
				SVB2_UL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 8 + 1) == TriState.True) ? true : false;
				SVB3_UL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 8 + 2) == TriState.True) ? true : false;
				SVB4_UL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 8 + 3) == TriState.True) ? true : false;
				SVB1_MR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4) == TriState.True) ? true : false;
				SVB2_MR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 1) == TriState.True) ? true : false;
				SVB3_MR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 2) == TriState.True) ? true : false;
				SVB4_MR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 3) == TriState.True) ? true : false;
				SVB1_MM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 4) == TriState.True) ? true : false;
				SVB2_MM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 4 + 1) == TriState.True) ? true : false;
				SVB3_MM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 4 + 2) == TriState.True) ? true : false;
				SVB4_MM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 4 + 3) == TriState.True) ? true : false;
				SVB1_ML.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 8) == TriState.True) ? true : false;
				SVB2_ML.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 8 + 1) == TriState.True) ? true : false;
				SVB3_ML.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 8 + 2) == TriState.True) ? true : false;
				SVB4_ML.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 192*4 + 8 + 3) == TriState.True) ? true : false;
				SVB1_LR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4) == TriState.True) ? true : false;
				SVB2_LR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 1) == TriState.True) ? true : false;
				SVB3_LR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 2) == TriState.True) ? true : false;
				SVB4_LR.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 3) == TriState.True) ? true : false;
				SVB1_LM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 4) == TriState.True) ? true : false;
				SVB2_LM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 4 + 1) == TriState.True) ? true : false;
				SVB3_LM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 4 + 2) == TriState.True) ? true : false;
				SVB4_LM.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 4 + 3) == TriState.True) ? true : false;
				SVB1_LL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 8) == TriState.True) ? true : false;
				SVB2_LL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 8 + 1) == TriState.True) ? true : false;
				SVB3_LL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 8 + 2) == TriState.True) ? true : false;
				SVB4_LL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 384*4 + 8 + 3) == TriState.True) ? true : false;
			}
			else /* SVB file is empty, but we must make sure that flags are cleared anyway */
			{
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
				SVB2_UL.Checked = false;
				SVB2_UM.Checked = false;
				SVB2_UR.Checked = false;
				SVB2_ML.Checked = false;
				SVB2_MM.Checked = false;
				SVB2_MR.Checked = false;
				SVB2_LL.Checked = false;
				SVB2_LM.Checked = false;
				SVB2_LR.Checked = false;
				SVB3_UL.Checked = false;
				SVB3_UM.Checked = false;
				SVB3_UR.Checked = false;
				SVB3_ML.Checked = false;
				SVB3_MM.Checked = false;
				SVB3_MR.Checked = false;
				SVB3_LL.Checked = false;
				SVB3_LM.Checked = false;
				SVB3_LR.Checked = false;
				SVB4_UL.Checked = false;
				SVB4_UM.Checked = false;
				SVB4_UR.Checked = false;
				SVB4_ML.Checked = false;
				SVB4_MM.Checked = false;
				SVB4_MR.Checked = false;
				SVB4_LL.Checked = false;
				SVB4_LM.Checked = false;
				SVB4_LR.Checked = false;
			}

			// Water support (HSD)
			int HSD_index = Helper.HSD_GetTileAddress(RealTX, RealTY) - 1;

			HSD_UR.Checked = (Helper.HSD_Tiles[HSD_index] != 0x00) ? true : false;
			HSD_UM.Checked = (Helper.HSD_Tiles[HSD_index + 1] != 0x00) ? true : false;
			HSD_UL.Checked = (Helper.HSD_Tiles[HSD_index + 2] != 0x00) ? true : false;
			HSD_MR.Checked = (Helper.HSD_Tiles[HSD_index + 3] != 0x00) ? true : false;
			HSD_MM.Checked = (Helper.HSD_Tiles[HSD_index + 4] != 0x00) ? true : false;
			HSD_ML.Checked = (Helper.HSD_Tiles[HSD_index + 5] != 0x00) ? true : false;
			HSD_LR.Checked = (Helper.HSD_Tiles[HSD_index + 6] != 0x00) ? true : false;
			HSD_LM.Checked = (Helper.HSD_Tiles[HSD_index + 7] != 0x00) ? true : false;
			HSD_LL.Checked = (Helper.HSD_Tiles[HSD_index + 8] != 0x00) ? true : false;
			HGT_UR.Value = Helper.HSD_Tiles[HSD_index];
			HGT_UM.Value = Helper.HSD_Tiles[HSD_index + 1];
			HGT_UL.Value = Helper.HSD_Tiles[HSD_index + 2];
			HGT_MR.Value = Helper.HSD_Tiles[HSD_index + 3];
			HGT_MM.Value = Helper.HSD_Tiles[HSD_index + 4];
			HGT_ML.Value = Helper.HSD_Tiles[HSD_index + 5];
			HGT_LR.Value = Helper.HSD_Tiles[HSD_index + 6];
			HGT_LM.Value = Helper.HSD_Tiles[HSD_index + 7];
			HGT_LL.Value = Helper.HSD_Tiles[HSD_index + 8];
		}	

		// Set the WallFlag variables based on the passability setting
		private void SetWallFlags()
		{
			// Set Wall Flags
			uint FLAGS = 0;
			if (TILE_BLOCKS.Checked)
				FLAGS += (uint)0x00000001;
			if (TILE_SINKS.Checked)
				FLAGS += (uint)0x00000002;
			if (TILE_CAN_FLY_OVER.Checked)
				FLAGS += (uint)0x00000004;
			if (TILE_ICY.Checked)
				FLAGS += (uint)0x00000008;
			if (TILE_NATURAL.Checked)
				FLAGS += (uint)0x00000010;
			if (TILE_SOUNDPROOF.Checked)
				FLAGS += (uint)0x00000020;
			if (TILE_INDOOR.Checked)
				FLAGS += (uint)0x00000040;
			if (TILE_REFLECTIVE.Checked)
				FLAGS += (uint)0x00000080;
			if (TILE_BLOCKS_VISION.Checked)
				FLAGS += (uint)0x00000100;

			/* The following flags are reversed (e.g. _UR stands for _LL etc.) */
			if (TILE_BLOCKS_UR.Checked)
				FLAGS += (uint)0x00000200;
			if (TILE_BLOCKS_UM.Checked)
				FLAGS += (uint)0x00000400;
			if (TILE_BLOCKS_UL.Checked)
				FLAGS += (uint)0x00000800;
			if (TILE_BLOCKS_MR.Checked)
				FLAGS += (uint)0x00001000;
			if (TILE_BLOCKS_MM.Checked)
				FLAGS += (uint)0x00002000;
			if (TILE_BLOCKS_ML.Checked)
				FLAGS += (uint)0x00004000;
			if (TILE_BLOCKS_LR.Checked)
				FLAGS += (uint)0x00008000;
			if (TILE_BLOCKS_LM.Checked)
				FLAGS += (uint)0x00010000;
			if (TILE_BLOCKS_LL.Checked)
				FLAGS += (uint)0x00020000;

			if (TILE_FLYOVER_UR.Checked)
				FLAGS += (uint)0x00040000;
			if (TILE_FLYOVER_UM.Checked)
				FLAGS += (uint)0x00080000;
			if (TILE_FLYOVER_UL.Checked)
				FLAGS += (uint)0x00100000;
			if (TILE_FLYOVER_MR.Checked)
				FLAGS += (uint)0x00200000;
			if (TILE_FLYOVER_MM.Checked)
				FLAGS += (uint)0x00400000;
			if (TILE_FLYOVER_ML.Checked)
				FLAGS += (uint)0x00800000;
			if (TILE_FLYOVER_LR.Checked)
				FLAGS += (uint)0x01000000;
			if (TILE_FLYOVER_LM.Checked)
				FLAGS += (uint)0x02000000;
			if (TILE_FLYOVER_LL.Checked)
				FLAGS += (uint)0x04000000;

			if (TILE_FLYOVER_COVER.Checked)
				FLAGS += (uint)0x08000000;

			// Convert flags to a byte array for WallFlagX variables
			byte[] flagbytes = Helper.GEN_ConvertFlagsToByteArray(FLAGS);

			// Set the wall flags
			WallFlag4 = flagbytes[0];
			WallFlag5 = flagbytes[1];
			WallFlag6 = flagbytes[2];
			WallFlag7 = flagbytes[3];

			// SVB: Set the sector visibility blocking from set parameters
			if (SVB_Bitmap == "ENOSVB")
				SVB_Bitmap = Helper.SVB_NewBitmap();

			// DEBUG ONLY
			// MessageBox.Show(System.Convert.ToString(FLAGS, 2));
			// MessageBox.Show(System.Convert.ToString(flagbytes[0], 2));
		}

		public void SetWaterFlags(int RealTX, int RealTY)
		{
			// Set the water flags
			int HSD_index = Helper.HSD_GetTileAddress(RealTX, RealTY) - 1;

			Helper.HSD_ModifyProperty(HSD_index, HSD_UR.Checked, (byte)HGT_UR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 1, HSD_UM.Checked, (byte)HGT_UM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 2, HSD_UL.Checked, (byte)HGT_UL.Value);
			Helper.HSD_ModifyProperty(HSD_index + 3, HSD_MR.Checked, (byte)HGT_MR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 4, HSD_MM.Checked, (byte)HGT_MM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 5, HSD_ML.Checked, (byte)HGT_ML.Value);
			Helper.HSD_ModifyProperty(HSD_index + 6, HSD_LR.Checked, (byte)HGT_LR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 7, HSD_LM.Checked, (byte)HGT_LM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 8, HSD_LL.Checked, (byte)HGT_LL.Value);
		}

		// Get the loaded wall flags
		public void GetWallFlags(string Bitmap)
		{
			TILE_BLOCKS.Checked = false;
			TILE_SINKS.Checked = false;
			TILE_CAN_FLY_OVER.Checked = false;
			TILE_ICY.Checked = false;
			TILE_NATURAL.Checked = false;
			TILE_SOUNDPROOF.Checked = false;
			TILE_INDOOR.Checked = false;
			TILE_REFLECTIVE.Checked = false;
			TILE_BLOCKS_VISION.Checked = false;
			TILE_BLOCKS_UR.Checked = false;
			TILE_BLOCKS_UM.Checked = false;
			TILE_BLOCKS_UL.Checked = false;
			TILE_BLOCKS_MR.Checked = false;
			TILE_BLOCKS_MM.Checked = false;
			TILE_BLOCKS_ML.Checked = false;
			TILE_BLOCKS_LR.Checked = false;
			TILE_BLOCKS_LM.Checked = false;
			TILE_BLOCKS_LL.Checked = false;
			TILE_FLYOVER_UR.Checked = false;
			TILE_FLYOVER_UM.Checked = false;
			TILE_FLYOVER_UL.Checked = false;
			TILE_FLYOVER_MR.Checked = false;
			TILE_FLYOVER_MM.Checked = false;
			TILE_FLYOVER_ML.Checked = false;
			TILE_FLYOVER_LR.Checked = false;
			TILE_FLYOVER_LM.Checked = false;
			TILE_FLYOVER_LL.Checked = false;
			TILE_FLYOVER_COVER.Checked = false;

			if (Helper.MOB_GetPropertyState(Bitmap, 0) == TriState.True)
				TILE_BLOCKS.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 1) == TriState.True)
				TILE_SINKS.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 2) == TriState.True)
				TILE_CAN_FLY_OVER.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 3) == TriState.True)
				TILE_ICY.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 4) == TriState.True)
				TILE_NATURAL.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 5) == TriState.True)
				TILE_SOUNDPROOF.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 6) == TriState.True)
				TILE_INDOOR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 7) == TriState.True)
				TILE_REFLECTIVE.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 8) == TriState.True)
				TILE_BLOCKS_VISION.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 9) == TriState.True)
				TILE_BLOCKS_UR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 10) == TriState.True)
				TILE_BLOCKS_UM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 11) == TriState.True)
				TILE_BLOCKS_UL.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 12) == TriState.True)
				TILE_BLOCKS_MR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 13) == TriState.True)
				TILE_BLOCKS_MM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 14) == TriState.True)
				TILE_BLOCKS_ML.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 15) == TriState.True)
				TILE_BLOCKS_LR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 16) == TriState.True)
				TILE_BLOCKS_LM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 17) == TriState.True)
				TILE_BLOCKS_LL.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 18) == TriState.True)
				TILE_FLYOVER_UR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 19) == TriState.True)
				TILE_FLYOVER_UM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 20) == TriState.True)
				TILE_FLYOVER_UL.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 21) == TriState.True)
				TILE_FLYOVER_MR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 22) == TriState.True)
				TILE_FLYOVER_MM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 23) == TriState.True)
				TILE_FLYOVER_ML.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 24) == TriState.True)
				TILE_FLYOVER_LR.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 25) == TriState.True)
				TILE_FLYOVER_LM.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 26) == TriState.True)
				TILE_FLYOVER_LL.Checked = true;
			if (Helper.MOB_GetPropertyState(Bitmap, 27) == TriState.True)
				TILE_FLYOVER_COVER.Checked = true;

			return;
		}
	
		private string SetSVBFlags(string SVB_destprop, int SVB_index)
		{
			//string SVB_destprop = "000000000000000000000000000000000000";
			//int SVB_index = 0;

			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index, SVB1_UR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 1, SVB2_UR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 2, SVB3_UR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 3, SVB4_UR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 4, SVB1_UM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 5, SVB2_UM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 6, SVB3_UM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 7, SVB4_UM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 8, SVB1_UL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 9, SVB2_UL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 10, SVB3_UL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 11, SVB4_UL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4, SVB1_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+1, SVB2_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+2, SVB3_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+3, SVB4_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+4, SVB1_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+5, SVB2_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+6, SVB3_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+7, SVB4_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+8, SVB1_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+9, SVB2_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+10, SVB3_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4+11, SVB4_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4, SVB1_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+1, SVB2_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+2, SVB3_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+3, SVB4_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+4, SVB1_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+5, SVB2_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+6, SVB3_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+7, SVB4_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+8, SVB1_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+9, SVB2_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+10, SVB3_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4+11, SVB4_LL.Checked);

			return SVB_destprop;
		}

		private void TX_ValueChanged(object sender, System.EventArgs e)
		{
			if (chkAutoTile.Checked)
				btnLoadTile_Click(null, null);
		}
		
		private void TY_ValueChanged(object sender, System.EventArgs e)
		{
			if (chkAutoTile.Checked)
				btnLoadTile_Click(null, null);
		}

		private void HSD_LR_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_LR.Enabled = HSD_LR.Checked;

			if (HGT_LR.Enabled && HGT_LR.Value == 0)
				HGT_LR.Value = 36;
		}

		private void HSD_LM_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_LM.Enabled = HSD_LM.Checked;

			if (HGT_LM.Enabled && HGT_LM.Value == 0)
				HGT_LM.Value = 36;
		}

		private void HSD_LL_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_LL.Enabled = HSD_LL.Checked;

			if (HGT_LL.Enabled && HGT_LL.Value == 0)
				HGT_LL.Value = 36;
		}

		private void HSD_MR_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_MR.Enabled = HSD_MR.Checked;

			if (HGT_MR.Enabled && HGT_MR.Value == 0)
				HGT_MR.Value = 36;
		}

		private void HSD_MM_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_MM.Enabled = HSD_MM.Checked;

			if (HGT_MM.Enabled && HGT_MM.Value == 0)
				HGT_MM.Value = 36;
		}

		private void HSD_ML_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_ML.Enabled = HSD_ML.Checked;

			if (HGT_ML.Enabled && HGT_ML.Value == 0)
				HGT_ML.Value = 36;
		}

		private void HSD_UR_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_UR.Enabled = HSD_UR.Checked;

			if (HGT_UR.Enabled && HGT_UR.Value == 0)
				HGT_UR.Value = 36;
		}

		private void HSD_UM_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_UM.Enabled = HSD_UM.Checked;

			if (HGT_UM.Enabled && HGT_UM.Value == 0)
				HGT_UM.Value = 36;
		}

		private void HSD_UL_CheckedChanged(object sender, System.EventArgs e)
		{
			HGT_UL.Enabled = HSD_UL.Checked;

			if (HGT_UL.Enabled && HGT_UL.Value == 0)
				HGT_UL.Value = 36;
		}

		// Light editor functions
		private void SetLightEdInterfaceState(int sid, Helper.LightInfo light)
		{
			switch(sid)
			{
				case 0: // state 0: all data disabled, light = null
					LightID.Enabled = false;
					Light1.Enabled = false;
					Light2.Enabled = false;
					Light3.Enabled = false;
					Light4.Enabled = false;
					Light5.Enabled = false;
					Light6.Enabled = false;
					Light7.Enabled = false;
					Light8.Enabled = false;
					Light9.Enabled = false;
					Light10_X.Enabled = false;
					Light11_Y.Enabled = false;
					Light12.Enabled = false;
					Light13.Enabled = false;
					Light14.Enabled = false;
					Light15.Enabled = false;
					Light16.Enabled = false;
					Light17.Enabled = false;
					Light18.Enabled = false;
					Light19.Enabled = false;
					Light20.Enabled = false;
					Light21.Enabled = false;
					Light22.Enabled = false;
					Light23.Enabled = false;
					Light24.Enabled = false;
					Light25.Enabled = false;
					Light26.Enabled = false;
					Light27.Enabled = false;
					Light28.Enabled = false;
					Light29.Enabled = false;
					Light30.Enabled = false;
					break;
				case 1: // state 1: enable all data, light = null
					LightID.Enabled = true;
					Light1.Enabled = true;
					Light2.Enabled = true;
					Light3.Enabled = true;
					Light4.Enabled = true;
					Light5.Enabled = true;
					Light6.Enabled = true;
					Light7.Enabled = true;
					Light8.Enabled = true;
					Light9.Enabled = true;
					Light10_X.Enabled = true;
					Light11_Y.Enabled = true;
					Light12.Enabled = true;
					Light13.Enabled = true;
					Light14.Enabled = true;
					Light15.Enabled = true;
					Light16.Enabled = true;
					Light17.Enabled = true;
					Light18.Enabled = true;
					Light19.Enabled = true;
					Light20.Enabled = true;
					Light21.Enabled = true;
					Light22.Enabled = true;
					Light23.Enabled = true;
					Light24.Enabled = true;
					Light25.Enabled = true;
					Light26.Enabled = true;
					Light27.Enabled = true;
					Light28.Enabled = true;
					Light29.Enabled = true;
					Light30.Enabled = true;
					break;
				case 2:	// state 2: reset all boxes, light = null
					LightID.Value = 0;
					Light1.Text = "0";
					Light2.Text = "0";
					Light3.Text = "0";
					Light4.Text = "0";
					Light5.Text = "0";
					Light6.Text = "0";
					Light7.Text = "0";
					Light8.Text = "0";
					Light9.Text = "0";
					Light10_X.Text = "0";
					Light11_Y.Text = "0";
					Light12.Text = "0";
					Light13.Text = "0";
					Light14.Text = "0";
					Light15.Text = "0";
					Light16.Text = "0";
					Light17.Text = "0";
					Light18.Text = "0";
					Light19.Text = "0";
					Light20.Text = "0";
					Light21.Text = "0";
					Light22.Text = "0";
					Light23.Text = "0";
					Light24.Text = "0";
					Light25.Text = "0";
					Light26.Text = "0";
					Light27.Text = "0";
					Light28.Text = "0";
					Light29.Text = "0";
					Light30.Text = "0";
					break;
				case 3: // state 3: load a light from 'light'
					Light1.Text = light.unknown1.ToString();
					Light2.Text = light.unknown2.ToString();
					Light3.Text = light.unknown3_ltype.ToString();
					Light4.Text = light.unknown4_flags.ToString();
					Light5.Text = light.red.ToString();
					Light6.Text = light.blue.ToString();
					Light7.Text = light.green.ToString();
					Light8.Text = light.unknown5.ToString();
					Light9.Text = light.unknown6.ToString();
					Light10_X.Value = (decimal)light.loc_x;
					Light11_Y.Value = (decimal)light.loc_y;
					Light12.Text = light.ofs_x.ToString();
					Light13.Text = light.ofs_y.ToString();
					Light14.Text = light.ofs_z.ToString();
					Light15.Text = light.unknown7.ToString();
					Light16.Text = light.unknown8.ToString();
					Light17.Text = light.unknown9.ToString();
					Light18.Text = light.radius.ToString();
					Light19.Text = light.unknown10.ToString();
					Light20.Text = light.unknown11.ToString();
					Light21.Text = light.unknown12.ToString();
					Light22.Text = light.unknown13.ToString();
					Light23.Text = light.unknown14_start_angle.ToString();
					Light24.Text = light.unknown15_end_angle.ToString();
					Light25.Text = light.unknown16.ToString();
					Light26.Text = light.unknown17_facing_x.ToString();
					Light27.Text = light.unknown18_facing_y.ToString();
					Light28.Text = light.unknown19_facing_z.ToString();
					Light29.Text = light.unknown20_affects_color.ToString();
					Light30.Text = light.unknown21.ToString();
					break;
				default:
					MessageBox.Show("Unexpected Error 020: Illegal state passed to SetLightEdInterfaceState!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
					break;
			}
		}

		// Create a LightInfo structure from the current data
		private Helper.LightInfo CreateLightInfo()
		{
			Helper.LightInfo light = new Helper.LightInfo();
			light.struct_errorlevel = 0;

			try
			{
				light.unknown1 = uint.Parse(Light1.Text);
				light.unknown2 = uint.Parse(Light2.Text);
				light.unknown3_ltype = uint.Parse(Light3.Text);
				light.unknown4_flags = uint.Parse(Light4.Text);
				light.red = byte.Parse(Light5.Text);
				light.blue = byte.Parse(Light6.Text);
				light.green = byte.Parse(Light7.Text);
				light.unknown5 = byte.Parse(Light8.Text);
				light.unknown6 = uint.Parse(Light9.Text);
				light.loc_x = (uint)Light10_X.Value;
				light.loc_y = (uint)Light11_Y.Value;
				light.ofs_x = float.Parse(Light12.Text);
				light.ofs_y = float.Parse(Light13.Text);
				light.ofs_z = float.Parse(Light14.Text);
				light.unknown7 = float.Parse(Light15.Text);
				light.unknown8 = float.Parse(Light16.Text);
				light.unknown9 = float.Parse(Light17.Text);
				light.radius = float.Parse(Light18.Text);
				light.unknown10 = float.Parse(Light19.Text);
				light.unknown11 = uint.Parse(Light20.Text);
				light.unknown12 = uint.Parse(Light21.Text);
				light.unknown13 = uint.Parse(Light22.Text);
				light.unknown14_start_angle = float.Parse(Light23.Text);
				light.unknown15_end_angle = float.Parse(Light24.Text);
				light.unknown16 = float.Parse(Light25.Text);
				light.unknown17_facing_x = float.Parse(Light26.Text);
				light.unknown18_facing_y = float.Parse(Light27.Text);
				light.unknown19_facing_z = float.Parse(Light28.Text);
				light.unknown20_affects_color = float.Parse(Light29.Text);
				light.unknown21 = uint.Parse(Light30.Text);
			}
			catch (Exception)
			{
				// Illegal parameters were passed, set errorlevel and return
				light.struct_errorlevel = -1;
				return light;
			}

			return light;
		}

		private bool LIGHT_CALLBACK = false;
		private void LightID_ValueChanged(object sender, System.EventArgs e)
		{
			if (LIGHT_CALLBACK)
			{
				LIGHT_CALLBACK = false;
				SetLightEdInterfaceState(0, new Helper.LightInfo());
			}

			SetLightEdInterfaceState(3, (Helper.LightInfo)Helper.SectorLights[(int)LightID.Value]);		
		}

		private void btnLightUpdate_Click(object sender, System.EventArgs e)
		{
			// Is the interface state valid?
			if (LightID.Enabled == false)
			{
				MessageBox.Show("No light to update.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			Helper.LightInfo t_light = CreateLightInfo();

			if (t_light.struct_errorlevel == -1)
			{
				MessageBox.Show("There was an error passing light parameters. Please check the validity of all data in the text boxes. Data not updated.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}

			Helper.SectorLights[(int)LightID.Value] = t_light;
			MessageBox.Show("Light updated.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnDelLight_Click(object sender, System.EventArgs e)
		{
			// Check for the interface state validity first		
			if (LightID.Enabled == false)
			{
				MessageBox.Show("No light to delete.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Are you sure you want to delete the current light?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			if (LightID.Value != 0)
			{
				Helper.SectorLights.RemoveAt((int)LightID.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				ArrayList p_lightarr = new ArrayList();

				for (int i=0; i<Helper.SectorLights.Count; i++)
					p_lightarr.Add(Helper.SectorLights[i]);

				Helper.SectorLights = p_lightarr;
			
				LightID.Value = 0;
				LightID.Maximum = Helper.SectorLights.Count - 1;

				MessageBox.Show("Light deleted.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				// Light ID = #0
				Helper.SectorLights.RemoveAt((int)LightID.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				if (Helper.SectorLights.Count > 0)
				{
					ArrayList p_lightarr = new ArrayList();

					for (int i=0; i<Helper.SectorLights.Count; i++)
						p_lightarr.Add(Helper.SectorLights[i]);

					Helper.SectorLights = p_lightarr;
					LightID.Value = 0;
					LightID.Maximum--;
					LightID_ValueChanged(null, null); // update #0 location
				}
				else
				{
					Helper.SectorLights.Clear();
					SetLightEdInterfaceState(0, new Helper.LightInfo());
				}

				MessageBox.Show("Light deleted.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void btnLightAdd_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to create a new light based on the current prototype (if any)?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			if (LightID.Enabled == false)
			{
				// there were no lights for this sector, so we need to create a
				// bank for lights on this map
				SetLightEdInterfaceState(1, new Helper.LightInfo());
				Helper.LightInfo light = new Helper.LightInfo();
				light.loc_x = (uint)Light10_X.Minimum;
				light.loc_y = (uint)Light11_Y.Minimum;
				Helper.SectorLights.Add(light);
				SetLightEdInterfaceState(3, light);
				LightID.Minimum = 0;
				LightID.Value = 0;
				LightID.Maximum = 0;
				LightID_ValueChanged(null, null);
			}
			else
			{
				// just add a new light to this map, use the current light as a prototype
				Helper.LightInfo light = CreateLightInfo();
				light.loc_x = (uint)Light10_X.Value;
				light.loc_y = (uint)Light11_Y.Value;
				Helper.SectorLights.Add(light);
				LightID.Maximum++;
				LightID.Value = LightID.Maximum; //auto pass parameters
			}			

			MessageBox.Show("Light added.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void SetStaticObjInterfaceState(bool state)
		{
			btnDelObj.Enabled = state;
			btnXtrObj.Enabled = state;

			if (state == false)
				SecObjList.Items.Clear();
		}

		private void SecObjList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (SecObjList.SelectedIndex != -1)
			{
				btnDelObj.Enabled = true;
				btnXtrObj.Enabled = true;
			}
			else
			{
				btnDelObj.Enabled = false;
				btnXtrObj.Enabled = false;
			}
		}

		private void btnXtrObj_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to extract this object?\n\nHINT: Extracting an object means creating a MOB file that can later be edited in an object editor and re-embedded into the sector file. An extracted object will be automatically copied to the 'Mobiles' folder of your ToEE World Builder installation and will be available for immediate editing.\n\nNOTE: Static objects use the so-called 'null GUID' (there is no need to store a GUID for a static object, so the GUID field is filled with random values, which are often the same for all objects in a sector), which pretty much means that a lot of static objects may have same GUIDs in the same sector file. Please remember this when extracting static objects, since certain (if not all!) static objects may overwrite previously extracted static objects!","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			long ptr_start = (long)static_objlist[SecObjList.SelectedIndex];
			long ptr_end = (long)(static_objlist[SecObjList.SelectedIndex+1]);

			string mob_target = "Mobiles\\"+static_objguid[SecObjList.SelectedIndex]+".mob";

			// The MOB target already exists
			if (File.Exists(mob_target))
			{
				if (MessageBox.Show("Warning: the MOB file with the following GUID already exists:\n"+static_objguid[SecObjList.SelectedIndex]+".mob"+"\n\nAre you sure you want to extract the new MOB, thus overwriting the old one?","The MOB Target Already Exists",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
					File.Delete(mob_target); // delete the old MOB target
				else
					return;
			}

			BinaryWriter mob_ex = new BinaryWriter(new FileStream(mob_target, FileMode.Create));

			for (long ptr=ptr_start; ptr<ptr_end; ptr++)
			{
				mob_ex.Write((byte)Helper.SectorObjects[(int)ptr]);
			}

			mob_ex.Close();
			MessageBox.Show("Static object extracted as:\n\n"+static_objguid[SecObjList.SelectedIndex]+".mob","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnDelObj_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this object from the sector?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			long ptr_start = (long)static_objlist[SecObjList.SelectedIndex];
			long ptr_end = (long)(static_objlist[SecObjList.SelectedIndex+1]);

			for (long ptr=ptr_start; ptr<ptr_end; ptr++)
			{
				Helper.SectorObjects.RemoveAt((int)ptr_start);
			}

			// Tricky: we have to reload all the objects now, refill the
			// object list and object GUID structures, AND decrease the
			// object count by 1!
			SecObjList.Items.Clear();
			static_objlist.Clear();
			static_objguid.Clear();

			// Acquire the previous count of static objects in a sector
			// (65536 max... I know it's a hack, but whatever!...)
			byte COUNT_1 = (byte)Helper.SectorObjects[Helper.SectorObjects.Count - 4];
			byte COUNT_2 = (byte)Helper.SectorObjects[Helper.SectorObjects.Count - 3];

			uint count = (uint)(COUNT_2 * 256 + COUNT_1);
			count--;

			COUNT_1 = (byte)count;
			COUNT_2 = (byte)(count >> 8);
			Helper.SectorObjects[Helper.SectorObjects.Count - 4] = COUNT_1;
			Helper.SectorObjects[Helper.SectorObjects.Count - 3] = COUNT_2;

			if (Helper.SectorObjects.Count != 4) /* 0x04 = NO OBJECTS */
			{
				// First of all, dump SectorObjects to a temporary OFF file
				BinaryWriter w_off = new BinaryWriter(new FileStream("temp.off", FileMode.Create));
				for (int i=0; i<Helper.SectorObjects.Count; i++)
					w_off.Write((byte)Helper.SectorObjects[i]);
				w_off.Close();

				// Walk through the object dump to detect object boundaries
				long p_Stream = 0;
				bool IS_OBJECT = false;
				BinaryReader r_off = new BinaryReader(new FileStream("temp.off", FileMode.Open));

				while (r_off.BaseStream.Position != r_off.BaseStream.Length - 60)
				{
					p_Stream = r_off.BaseStream.Position;
					IS_OBJECT = true;

					if (r_off.ReadByte() != 0x77)
						IS_OBJECT = false;

					r_off.BaseStream.Seek(p_Stream + 1, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 2, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 3, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 4, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x01)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 5, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 28, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 29, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 30, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 31, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 32, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 33, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 34, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;
					r_off.BaseStream.Seek(p_Stream + 35, SeekOrigin.Begin);
					if (r_off.ReadByte() != 0x00)
						IS_OBJECT = false;

					// If it's a new object boundary, add the pointer to
					// that object to the objlist
					if (IS_OBJECT)
						static_objlist.Add(p_Stream);

					p_Stream++;
					r_off.BaseStream.Seek(p_Stream, SeekOrigin.Begin);
				}

				// Add the last object's terminal location and close up
				static_objlist.Add(r_off.BaseStream.Length - 4);
				r_off.Close();

				// Read the static object properties and add them to the list
				// Note that the last object pointer is terminal, and thus
				// must not be used.
				BinaryReader readobj = new BinaryReader(new FileStream("temp.off", FileMode.Open));
				for(int itm = 0; itm<static_objlist.Count - 1; itm++)
				{
					// Acquire a pointer and read all the needed data
					readobj.BaseStream.Seek((long)static_objlist[itm] + 0x0C, SeekOrigin.Begin);
					Int16 proto_id = readobj.ReadInt16();
					readobj.BaseStream.Seek((long)static_objlist[itm] + 0x34, SeekOrigin.Begin);
					UInt32 type = readobj.ReadUInt32();
					readobj.BaseStream.Seek((long)static_objlist[itm] + 0x3A, SeekOrigin.Begin);
					long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes)type);
					readobj.BaseStream.Seek(BlocksToSkip * 4 + 1, SeekOrigin.Current);
					UInt32 x_coord = readobj.ReadUInt32();
					UInt32 y_coord = readobj.ReadUInt32();
					// + GUID +
					readobj.BaseStream.Seek((long)static_objlist[itm] + 0x1C, SeekOrigin.Begin);
					string proto_guid = Helper.GEN_ConvertBytesToStringGUID(readobj.ReadBytes(24));
					// - GUID -
					string proto_name = Helper.Proto_By_ID[proto_id.ToString()].ToString();

					static_objguid.Add(proto_guid);
					SecObjList.Items.Add(itm.ToString()+":\t("+x_coord.ToString()+","+y_coord.ToString()+")\t\t\t"+proto_name);
				}
				readobj.Close();

				// Delete the temporary OFF file
				File.Delete("temp.off");
			}
			else
			{
				SetStaticObjInterfaceState(false);
			}

			btnDelObj.Enabled = false;
			btnXtrObj.Enabled = false;
			MessageBox.Show("Static object deleted.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			SectorLookup sl = new SectorLookup();
			sl.Show();
		}

		// Call the sector analyzer
		private SectorAnalysis san;
		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Sector analyzer/painter is already running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (Helper.SectorTiles.Count == 0)
			{
				MessageBox.Show("No sector is loaded! Load a sector first.","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			SysMsg.SM_SAN_ENABLED=true; // System message to control runtime

			san = new SectorAnalysis();
			san.MIN_X = (int)TX.Minimum;
			san.MIN_Y = (int)TY.Minimum;

			if (SVB_Bitmap.Length > 1000)
				san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

			if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
				san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap

			san.Show();
		}

        // start the extended sector light editor
        private void sectorLightEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LightEditorEx led = new LightEditorEx();
            led.ShowDialog();
        }

        // SVB wizard call
        private void btnSVBWizard_Click(object sender, EventArgs e)
        {
            //SVBWizard swiz = new SVBWizard();
            //swiz.ShowDialog();
        }

		#endregion

		#region Area Cleaner

		private void btnCleanArea_Click(object sender, System.EventArgs e)
		{
			if (!chkMOB.Checked && !chkSECSVB.Checked && !chkCLIPPING.Checked && !chkGMESH.Checked && !chkPND.Checked && !chkHSD.Checked)
			{
				MessageBox.Show("Nothing was chosen to clean up!","Nothing to clean up",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			MultiODLG.Filter = "Point to any file in your map folder|*.*";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				string path = Path.GetDirectoryName(MultiODLG.FileName);

				if (chkMOB.Checked)
				{
					// clean up MOB files
					string[] mob_files = Directory.GetFiles(path, "*.mob");
					foreach (string mob in mob_files)
						File.Delete(mob);
				}

				if (chkSECSVB.Checked)
				{
					// clean up SEC/SVB files
					string[] sec_files = Directory.GetFiles(path, "*.sec");
					foreach (string sec in sec_files)
						File.Delete(sec);
					string[] svb_files = Directory.GetFiles(path, "*.svb");
					foreach (string svb in svb_files)
						File.Delete(svb);
				}

				if (chkHSD.Checked)
				{
					// clean up HSD files
					string[] hsd_files = Directory.GetFiles(path, "*.hsd");
					foreach (string hsd in hsd_files)
						File.Delete(hsd);
				}

				if (chkCLIPPING.Checked)
				{
					// clean up clipping info
					BinaryWriter bw = new BinaryWriter(new FileStream(path+"\\clipping.cif", FileMode.Create));
					bw.Write((Int32)0x00);
					bw.Close();
					BinaryWriter bw2 = new BinaryWriter(new FileStream(path+"\\clipping.cgf", FileMode.Create));
					bw2.Write((Int32)0x00);
					bw2.Close();
				}

				if (chkGMESH.Checked)
				{
					// clean up ground mesh info
					BinaryWriter bw3 = new BinaryWriter(new FileStream(path+"\\gmesh.gmf", FileMode.Create));
					bw3.Write((Int32)0x00);
					bw3.Close();
					BinaryWriter bw4 = new BinaryWriter(new FileStream(path+"\\gmesh.gmi", FileMode.Create));
					bw4.Write((Int32)0x00);
					bw4.Close();
				}

				if (chkPND.Checked)
				{
					// clean up pathnodes
					BinaryWriter bw5 = new BinaryWriter(new FileStream(path+"\\pathnode.pnd", FileMode.Create));
					bw5.Write((Int32)0x00);
					bw5.Close();
				}
			}

			MessageBox.Show("Area cleaned up.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
		#endregion

		#region System Message Queue Processor

		// The system message heartbeat, parsed every 1ms or so
		// Must be maximally optimized in order not to screw things up
		private void WM_SysMsg_Tick(object sender, System.EventArgs e)
		{
            // v2.0.0: Interoperability with ToEE console support
            if (File.Exists(Helper.InteropPath))
            {
                bool DATA_PASS_ON = false;
                string wbl_data = "";
                try
                {
                    StreamReader sr = new StreamReader(Helper.InteropPath);
                    wbl_data = sr.ReadLine();
                    sr.Close();
                }
                catch (Exception) { }
                if (wbl_data != "")
                {
                    string[] wbl_data_arr = wbl_data.Split(' ');
                    wbl_data = "";
                    switch (wbl_data_arr[0])
                    {
                        case "OBJLOC": // location -> object editor
                            if (LocationX.Enabled)
                            {
                                LocationX.Value = decimal.Parse(wbl_data_arr[1]);
                                LocationY.Value = decimal.Parse(wbl_data_arr[2]);
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create or open an object first! (e.g. click 'New' or 'Open')", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "OBJLOCR": // location -> object editor (with rotation)
                            if (LocationX.Enabled)
                            {
                                LocationX.Value = decimal.Parse(wbl_data_arr[1]);
                                LocationY.Value = decimal.Parse(wbl_data_arr[2]);
                                pRotation.Checked = true;
                                wbl_data_arr[3] = wbl_data_arr[3].Replace(".",System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                                vRotation.Text = wbl_data_arr[3];
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create or open an object first! (e.g. click 'New' or 'Open')", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "WAYLOC": // location -> object editor waypoint
                            if (vWayX.Enabled)
                            {
                                vWayX.Text = wbl_data_arr[1];
                                vWayY.Text = wbl_data_arr[2];
                                btnWayAdd_Click(null, null);
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a waypoints entry first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "WAYLOCR": // location -> object editor waypoint with rotation
                            if (vWayX.Enabled)
                            {
                                vWayX.Text = wbl_data_arr[1];
                                vWayY.Text = wbl_data_arr[2];
                                wbl_data_arr[3] = wbl_data_arr[3].Replace(".", System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                                vWayRot.Text = wbl_data_arr[3];
                                cRotWpt.Checked = true;
                                btnWayAdd_Click(null, null);
                                cRotWpt.Checked = false;
                                vWayRot.Text = "0";
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a waypoints entry first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;

                        case "STDDLOC": // location -> object editor day standpoint
                            if (vDayX.Enabled)
                            {
                                vDayX.Text = wbl_data_arr[1];
                                vDayY.Text = wbl_data_arr[2];
                                vDayMap.Text = wbl_data_arr[3];
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a standpoints entry first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "STDNLOC": // location -> object editor night standpoint
                            if (vNightX.Enabled)
                            {
                                vNightX.Text = wbl_data_arr[1];
                                vNightY.Text = wbl_data_arr[2];
                                vNightMap.Text = wbl_data_arr[3];
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a standpoints entry first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "STDSLOC": // location -> object editor scout standpoint
                            if (vScoutX.Enabled)
                            {
                                vScoutX.Text = wbl_data_arr[1];
                                vScoutY.Text = wbl_data_arr[2];
                                vScoutMap.Text = wbl_data_arr[3];
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please create a scout standpoint entry first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        case "SECLOC": // location -> sector editor
                            TX.Value = decimal.Parse(wbl_data_arr[1]);
                            TY.Value = decimal.Parse(wbl_data_arr[2]);
                            break;
                        case "JMPLOC": // location -> jump point editor
                            if (JPX.Enabled)
                            {
                                JPX.Text = wbl_data_arr[1];
                                JPY.Text = wbl_data_arr[2];
                                JPMap.Text = wbl_data_arr[3];
                            }
                            else
                            {
                                File.Delete(Helper.InteropPath);
                                MessageBox.Show("Please open a jump point file first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            break;
                        default:
                            DATA_PASS_ON = true;
                            break;
                    }
                    if (!DATA_PASS_ON)
                        File.Delete(Helper.InteropPath);
                }
            }

			// MESSAGE:       SM_REMEMBER_COORDS
			// QUEUE FORMAT:  X, Y
			// QUEUE OUTCOME: Location is set to (X,Y) and object editor is
			//                focused.
			if (SysMsg.SM_REMEMBER_COORDS)
			{
				try
				{
					LocationX.Value = decimal.Parse(SysMsg.SM_REMEMBER_COORDS_QUEUE[0].ToString()); // x
					LocationY.Value = decimal.Parse(SysMsg.SM_REMEMBER_COORDS_QUEUE[1].ToString()); // y
					SysMsg.SM_REMEMBER_COORDS_QUEUE.Clear();
					SysMsg.SM_REMEMBER_COORDS = false;
					this.GenericTab.SelectedIndex = 0;
					this.Focus();
				}
				catch (Exception)
				{
					SysMsg.SM_REMEMBER_COORDS_QUEUE.Clear();
					SysMsg.SM_REMEMBER_COORDS = false;
					MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_REMEMBER_COORDS system message.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}

            // MESSAGE        SM_PROTO_SEARCH
            // QUEUE FORMAT:  PARAM, TARGET
            // QUEUE OUTCOME: Prototype PARAM is selected and the protos
            //                editor (TARGET=0) or object editor (TARGET=1)
            //                is started
            if (SysMsg.SM_PROTO_SEARCH)
            {
                try
                {
                    if (SysMsg.SM_PROTO_SEARCH_TARGET == 0)
                    {
                        CurProto.SelectedIndex = CurProto.Items.IndexOf(SysMsg.SM_PROTO_SEARCH_PARAM);
                        this.GenericTab.SelectedIndex = 5;
                    }
                    else
                    {
                        Prototype.SelectedIndex = Prototype.Items.IndexOf(SysMsg.SM_PROTO_SEARCH_PARAM);
                        this.GenericTab.SelectedIndex = 0;
                    }

                    SysMsg.SM_PROTO_SEARCH = false;
                    SysMsg.SM_PROTO_SEARCH_PARAM = "";
                }
                catch (Exception)
                {
                    SysMsg.SM_PROTO_SEARCH = false;
                    MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PROTO_SEARCH system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

			// MESSAGE:       SM_PAINT_TILE
			// QUEUE FORMAT:  X, Y, FOOTSTEP_SOUND
			// QUEUE OUTCOME: Sector tile at (X,Y) is updated, data in the sector
			//                viewer/painter is modified to reflect the update.
			if (SysMsg.SM_PAINT_TILE)
			{
				try
				{
					bool MSG_CALLBACK = chkAutoTile.Checked;
					chkAutoTile.Checked = false;
					TX.Value = int.Parse(SysMsg.SM_PAINT_TILE_QUEUE[0].ToString());
					TY.Value = int.Parse(SysMsg.SM_PAINT_TILE_QUEUE[1].ToString());
                    cmbTileSound.SelectedIndex = int.Parse(SysMsg.SM_PAINT_TILE_QUEUE[2].ToString());
					chkAutoTile.Checked = MSG_CALLBACK;
					btnUpdateTile_Click(null, null);

					if (SVB_Bitmap.Length > 1000)
						san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

					if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
						san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap

					SysMsg.SM_PAINT_TILE_QUEUE.Clear();
					SysMsg.SM_PAINT_TILE = false;
				}
				catch (Exception)
				{
					SysMsg.SM_PAINT_TILE_QUEUE.Clear();
					SysMsg.SM_PAINT_TILE = false;
#if DEBUG
					MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE system message.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
#endif
				}
			}

			// MESSAGE:       SM_PAINT_NOTHING
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: All flags in the sector editor are reset.
			if (SysMsg.SM_PAINT_NOTHING)
			{
				SysMsg.SM_PAINT_NOTHING = false;
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
				SVB2_UL.Checked = false;
				SVB2_UM.Checked = false;
				SVB2_UR.Checked = false;
				SVB2_ML.Checked = false;
				SVB2_MM.Checked = false;
				SVB2_MR.Checked = false;
				SVB2_LL.Checked = false;
				SVB2_LM.Checked = false;
				SVB2_LR.Checked = false;
				SVB3_UL.Checked = false;
				SVB3_UM.Checked = false;
				SVB3_UR.Checked = false;
				SVB3_ML.Checked = false;
				SVB3_MM.Checked = false;
				SVB3_MR.Checked = false;
				SVB3_LL.Checked = false;
				SVB3_LM.Checked = false;
				SVB3_LR.Checked = false;
				SVB4_UL.Checked = false;
				SVB4_UM.Checked = false;
				SVB4_UR.Checked = false;
				SVB4_ML.Checked = false;
				SVB4_MM.Checked = false;
				SVB4_MR.Checked = false;
				SVB4_LL.Checked = false;
				SVB4_LM.Checked = false;
				SVB4_LR.Checked = false;
				TILE_BLOCKS.Checked = false;
				TILE_SINKS.Checked = false;
				TILE_CAN_FLY_OVER.Checked = false;
				TILE_ICY.Checked = false;
				TILE_NATURAL.Checked = false;
				TILE_SOUNDPROOF.Checked = false;
				TILE_INDOOR.Checked = false;
				TILE_REFLECTIVE.Checked = false;
				TILE_BLOCKS_VISION.Checked = false;
				TILE_BLOCKS_UR.Checked = false;
				TILE_BLOCKS_UM.Checked = false;
				TILE_BLOCKS_UL.Checked = false;
				TILE_BLOCKS_MR.Checked = false;
				TILE_BLOCKS_MM.Checked = false;
				TILE_BLOCKS_ML.Checked = false;
				TILE_BLOCKS_LR.Checked = false;
				TILE_BLOCKS_LM.Checked = false;
				TILE_BLOCKS_LL.Checked = false;
				TILE_FLYOVER_UR.Checked = false;
				TILE_FLYOVER_UM.Checked = false;
				TILE_FLYOVER_UL.Checked = false;
				TILE_FLYOVER_MR.Checked = false;
				TILE_FLYOVER_MM.Checked = false;
				TILE_FLYOVER_ML.Checked = false;
				TILE_FLYOVER_LR.Checked = false;
				TILE_FLYOVER_LM.Checked = false;
				TILE_FLYOVER_LL.Checked = false;
				TILE_FLYOVER_COVER.Checked = false;
				HSD_UR.Checked = false;
				HSD_UM.Checked = false;
				HSD_UL.Checked = false;
				HSD_MR.Checked = false;
				HSD_MM.Checked = false;
				HSD_ML.Checked = false;
				HSD_LR.Checked = false;
				HSD_LM.Checked = false;
				HSD_LL.Checked = false;
			}

			// MESSAGE:       SM_PAINT_IMPASSABLE
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: All flags in the sector editor are set to 'blocks'.
			if (SysMsg.SM_PAINT_IMPASSABLE)
			{
				SysMsg.SM_PAINT_IMPASSABLE = false;
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
				SVB2_UL.Checked = false;
				SVB2_UM.Checked = false;
				SVB2_UR.Checked = false;
				SVB2_ML.Checked = false;
				SVB2_MM.Checked = false;
				SVB2_MR.Checked = false;
				SVB2_LL.Checked = false;
				SVB2_LM.Checked = false;
				SVB2_LR.Checked = false;
				SVB3_UL.Checked = false;
				SVB3_UM.Checked = false;
				SVB3_UR.Checked = false;
				SVB3_ML.Checked = false;
				SVB3_MM.Checked = false;
				SVB3_MR.Checked = false;
				SVB3_LL.Checked = false;
				SVB3_LM.Checked = false;
				SVB3_LR.Checked = false;
				SVB4_UL.Checked = false;
				SVB4_UM.Checked = false;
				SVB4_UR.Checked = false;
				SVB4_ML.Checked = false;
				SVB4_MM.Checked = false;
				SVB4_MR.Checked = false;
				SVB4_LL.Checked = false;
				SVB4_LM.Checked = false;
				SVB4_LR.Checked = false;
				TILE_BLOCKS.Checked = false;
				TILE_SINKS.Checked = false;
				TILE_CAN_FLY_OVER.Checked = false;
				TILE_ICY.Checked = false;
				TILE_NATURAL.Checked = false;
				TILE_SOUNDPROOF.Checked = false;
				TILE_INDOOR.Checked = false;
				TILE_REFLECTIVE.Checked = false;
				TILE_BLOCKS_VISION.Checked = false;
				TILE_BLOCKS_UR.Checked = true;
				TILE_BLOCKS_UM.Checked = true;
				TILE_BLOCKS_UL.Checked = true;
				TILE_BLOCKS_MR.Checked = true;
				TILE_BLOCKS_MM.Checked = true;
				TILE_BLOCKS_ML.Checked = true;
				TILE_BLOCKS_LR.Checked = true;
				TILE_BLOCKS_LM.Checked = true;
				TILE_BLOCKS_LL.Checked = true;
				TILE_FLYOVER_UR.Checked = false;
				TILE_FLYOVER_UM.Checked = false;
				TILE_FLYOVER_UL.Checked = false;
				TILE_FLYOVER_MR.Checked = false;
				TILE_FLYOVER_MM.Checked = false;
				TILE_FLYOVER_ML.Checked = false;
				TILE_FLYOVER_LR.Checked = false;
				TILE_FLYOVER_LM.Checked = false;
				TILE_FLYOVER_LL.Checked = false;
				TILE_FLYOVER_COVER.Checked = false;
				HSD_UR.Checked = false;
				HSD_UM.Checked = false;
				HSD_UL.Checked = false;
				HSD_MR.Checked = false;
				HSD_MM.Checked = false;
				HSD_ML.Checked = false;
				HSD_LR.Checked = false;
				HSD_LM.Checked = false;
				HSD_LL.Checked = false;
			}

			// MESSAGE:       SM_PAINT_FLYOVER
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: All flags in the sector editor are set to fly over.
			if (SysMsg.SM_PAINT_FLYOVER)
			{
				SysMsg.SM_PAINT_FLYOVER = false;
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
				SVB2_UL.Checked = false;
				SVB2_UM.Checked = false;
				SVB2_UR.Checked = false;
				SVB2_ML.Checked = false;
				SVB2_MM.Checked = false;
				SVB2_MR.Checked = false;
				SVB2_LL.Checked = false;
				SVB2_LM.Checked = false;
				SVB2_LR.Checked = false;
				SVB3_UL.Checked = false;
				SVB3_UM.Checked = false;
				SVB3_UR.Checked = false;
				SVB3_ML.Checked = false;
				SVB3_MM.Checked = false;
				SVB3_MR.Checked = false;
				SVB3_LL.Checked = false;
				SVB3_LM.Checked = false;
				SVB3_LR.Checked = false;
				SVB4_UL.Checked = false;
				SVB4_UM.Checked = false;
				SVB4_UR.Checked = false;
				SVB4_ML.Checked = false;
				SVB4_MM.Checked = false;
				SVB4_MR.Checked = false;
				SVB4_LL.Checked = false;
				SVB4_LM.Checked = false;
				SVB4_LR.Checked = false;
				TILE_BLOCKS.Checked = false;
				TILE_SINKS.Checked = false;
				TILE_CAN_FLY_OVER.Checked = false;
				TILE_ICY.Checked = false;
				TILE_NATURAL.Checked = false;
				TILE_SOUNDPROOF.Checked = false;
				TILE_INDOOR.Checked = false;
				TILE_REFLECTIVE.Checked = false;
				TILE_BLOCKS_VISION.Checked = false;
				TILE_BLOCKS_UR.Checked = false;
				TILE_BLOCKS_UM.Checked = false;
				TILE_BLOCKS_UL.Checked = false;
				TILE_BLOCKS_MR.Checked = false;
				TILE_BLOCKS_MM.Checked = false;
				TILE_BLOCKS_ML.Checked = false;
				TILE_BLOCKS_LR.Checked = false;
				TILE_BLOCKS_LM.Checked = false;
				TILE_BLOCKS_LL.Checked = false;
				TILE_FLYOVER_UR.Checked = true;
				TILE_FLYOVER_UM.Checked = true;
				TILE_FLYOVER_UL.Checked = true;
				TILE_FLYOVER_MR.Checked = true;
				TILE_FLYOVER_MM.Checked = true;
				TILE_FLYOVER_ML.Checked = true;
				TILE_FLYOVER_LR.Checked = true;
				TILE_FLYOVER_LM.Checked = true;
				TILE_FLYOVER_LL.Checked = true;
				TILE_FLYOVER_COVER.Checked = false;
				HSD_UR.Checked = false;
				HSD_UM.Checked = false;
				HSD_UL.Checked = false;
				HSD_MR.Checked = false;
				HSD_MM.Checked = false;
				HSD_ML.Checked = false;
				HSD_LR.Checked = false;
				HSD_LM.Checked = false;
				HSD_LL.Checked = false;
			}

			// MESSAGE:       SM_PAINT_FLYOVER_COVER
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: All flags in the sector editor are set to fly over,
			//                the 'fly over/cover' flag is added
			if (SysMsg.SM_PAINT_FLYOVER_COVER)
			{
				SysMsg.SM_PAINT_FLYOVER_COVER = false;
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
				SVB2_UL.Checked = false;
				SVB2_UM.Checked = false;
				SVB2_UR.Checked = false;
				SVB2_ML.Checked = false;
				SVB2_MM.Checked = false;
				SVB2_MR.Checked = false;
				SVB2_LL.Checked = false;
				SVB2_LM.Checked = false;
				SVB2_LR.Checked = false;
				SVB3_UL.Checked = false;
				SVB3_UM.Checked = false;
				SVB3_UR.Checked = false;
				SVB3_ML.Checked = false;
				SVB3_MM.Checked = false;
				SVB3_MR.Checked = false;
				SVB3_LL.Checked = false;
				SVB3_LM.Checked = false;
				SVB3_LR.Checked = false;
				SVB4_UL.Checked = false;
				SVB4_UM.Checked = false;
				SVB4_UR.Checked = false;
				SVB4_ML.Checked = false;
				SVB4_MM.Checked = false;
				SVB4_MR.Checked = false;
				SVB4_LL.Checked = false;
				SVB4_LM.Checked = false;
				SVB4_LR.Checked = false;
				TILE_BLOCKS.Checked = false;
				TILE_SINKS.Checked = false;
				TILE_CAN_FLY_OVER.Checked = false;
				TILE_ICY.Checked = false;
				TILE_NATURAL.Checked = false;
				TILE_SOUNDPROOF.Checked = false;
				TILE_INDOOR.Checked = false;
				TILE_REFLECTIVE.Checked = false;
				TILE_BLOCKS_VISION.Checked = false;
				TILE_BLOCKS_UR.Checked = false;
				TILE_BLOCKS_UM.Checked = false;
				TILE_BLOCKS_UL.Checked = false;
				TILE_BLOCKS_MR.Checked = false;
				TILE_BLOCKS_MM.Checked = false;
				TILE_BLOCKS_ML.Checked = false;
				TILE_BLOCKS_LR.Checked = false;
				TILE_BLOCKS_LM.Checked = false;
				TILE_BLOCKS_LL.Checked = false;
				TILE_FLYOVER_UR.Checked = true;
				TILE_FLYOVER_UM.Checked = true;
				TILE_FLYOVER_UL.Checked = true;
				TILE_FLYOVER_MR.Checked = true;
				TILE_FLYOVER_MM.Checked = true;
				TILE_FLYOVER_ML.Checked = true;
				TILE_FLYOVER_LR.Checked = true;
				TILE_FLYOVER_LM.Checked = true;
				TILE_FLYOVER_LL.Checked = true;
				TILE_FLYOVER_COVER.Checked = true;
				HSD_UR.Checked = false;
				HSD_UM.Checked = false;
				HSD_UL.Checked = false;
				HSD_MR.Checked = false;
				HSD_MM.Checked = false;
				HSD_ML.Checked = false;
				HSD_LR.Checked = false;
				HSD_LM.Checked = false;
				HSD_LL.Checked = false;
			}

			// MESSAGE:       SM_ADD_SVB1
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: SVB Bit 1 is set in the sector editor
			if (SysMsg.SM_ADD_SVB1)
			{
				SysMsg.SM_ADD_SVB1 = false;
				SVB1_UL.Checked = true;
				SVB1_UM.Checked = true;
				SVB1_UR.Checked = true;
				SVB1_ML.Checked = true;
				SVB1_MM.Checked = true;
				SVB1_MR.Checked = true;
				SVB1_LL.Checked = true;
				SVB1_LM.Checked = true;
				SVB1_LR.Checked = true;
			}

			// MESSAGE:       SM_REMOVE_SVB1
			// QUEUE FORMAT:  (null)
			// QUEUE OUTCOME: SVB Bit 1 is reset in the sector editor
			if (SysMsg.SM_REMOVE_SVB1)
			{
				SysMsg.SM_REMOVE_SVB1 = false;
				SVB1_UL.Checked = false;
				SVB1_UM.Checked = false;
				SVB1_UR.Checked = false;
				SVB1_ML.Checked = false;
				SVB1_MM.Checked = false;
				SVB1_MR.Checked = false;
				SVB1_LL.Checked = false;
				SVB1_LM.Checked = false;
				SVB1_LR.Checked = false;
			}

            // MESSAGE:       SM_SVB1
            // QUEUE FORMAT:  X,Y
            // QUEUE OUTCOME: SVB Bit 1 is set in the sector editor, over the other options
            if (SysMsg.SM_SVB1)
            {
    			TX.Value = int.Parse(SysMsg.SM_SVB1_X.ToString());
	    		TY.Value = int.Parse(SysMsg.SM_SVB1_Y.ToString());
                btnLoadTile_Click(null, null);
                SVB1_UL.Checked = true;
                SVB1_UM.Checked = true;
                SVB1_UR.Checked = true;
                SVB1_ML.Checked = true;
                SVB1_MM.Checked = true;
                SVB1_MR.Checked = true;
                SVB1_LL.Checked = true;
                SVB1_LM.Checked = true;
                SVB1_LR.Checked = true;

                try
                {
                    btnUpdateTile_Click(null, null);

                    if (SVB_Bitmap.Length > 1000)
                        san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

                    if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
                        san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap
                    SysMsg.SM_SVB1 = false;
                }
                catch (Exception)
                {
                    SysMsg.SM_SVB1 = false;

#if DEBUG
                    MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE_IN_SVB system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }

            // MESSAGE:       SM_SVB2
            // QUEUE FORMAT:  X,Y
            // QUEUE OUTCOME: SVB Bit 2 is set in the sector editor, over the other options
            if (SysMsg.SM_SVB2)
            {
                TX.Value = int.Parse(SysMsg.SM_SVB2_X.ToString());
                TY.Value = int.Parse(SysMsg.SM_SVB2_Y.ToString());
                btnLoadTile_Click(null, null);
                SVB2_UL.Checked = true;
                SVB2_UM.Checked = true;
                SVB2_UR.Checked = true;
                SVB2_ML.Checked = true;
                SVB2_MM.Checked = true;
                SVB2_MR.Checked = true;
                SVB2_LL.Checked = true;
                SVB2_LM.Checked = true;
                SVB2_LR.Checked = true;

                try
                {
                    btnUpdateTile_Click(null, null);

                    if (SVB_Bitmap.Length > 1000)
                        san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

                    if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
                        san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap
                    SysMsg.SM_SVB2 = false;
                }
                catch (Exception)
                {
                    SysMsg.SM_SVB2 = false;

#if DEBUG
                    MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE_IN_SVB system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }

            // MESSAGE:       SM_SVB3
            // QUEUE FORMAT:  X,Y
            // QUEUE OUTCOME: SVB Bit 3 is set in the sector editor, over the other options
            if (SysMsg.SM_SVB3)
            {
                TX.Value = int.Parse(SysMsg.SM_SVB3_X.ToString());
                TY.Value = int.Parse(SysMsg.SM_SVB3_Y.ToString());
                btnLoadTile_Click(null, null);
                SVB3_UL.Checked = true;
                SVB3_UM.Checked = true;
                SVB3_UR.Checked = true;
                SVB3_ML.Checked = true;
                SVB3_MM.Checked = true;
                SVB3_MR.Checked = true;
                SVB3_LL.Checked = true;
                SVB3_LM.Checked = true;
                SVB3_LR.Checked = true;

                try
                {
                    btnUpdateTile_Click(null, null);

                    if (SVB_Bitmap.Length > 1000)
                        san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

                    if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
                        san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap
                    SysMsg.SM_SVB3 = false;
                }
                catch (Exception)
                {
                    SysMsg.SM_SVB3 = false;

#if DEBUG
                    MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE_IN_SVB system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }

            // MESSAGE:       SM_SVB4
            // QUEUE FORMAT:  X,Y
            // QUEUE OUTCOME: SVB Bit 4 is set in the sector editor, over the other options
            if (SysMsg.SM_SVB4)
            {
                TX.Value = int.Parse(SysMsg.SM_SVB4_X.ToString());
                TY.Value = int.Parse(SysMsg.SM_SVB4_Y.ToString());
                btnLoadTile_Click(null, null);
                SVB4_UL.Checked = true;
                SVB4_UM.Checked = true;
                SVB4_UR.Checked = true;
                SVB4_ML.Checked = true;
                SVB4_MM.Checked = true;
                SVB4_MR.Checked = true;
                SVB4_LL.Checked = true;
                SVB4_LM.Checked = true;
                SVB4_LR.Checked = true;

                try
                {
                    btnUpdateTile_Click(null, null);

                    if (SVB_Bitmap.Length > 1000)
                        san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

                    if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
                        san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap
                    SysMsg.SM_SVB4 = false;
                }
                catch (Exception)
                {
                    SysMsg.SM_SVB4 = false;

#if DEBUG
                    MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE_IN_SVB system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                }
            }

			// MESSAGE:       SM_TEST_MSG
			// QUEUE FORMAT:  Any number of string objects or a null queue
			// QUEUE OUTCOME: A test debug message (leave it here for reference)
			if (SysMsg.SM_TEST_MSG)
			{
				string queue = "";

				foreach (object block in SysMsg.SM_TEST_MSG_QUEUE)
					queue += block.ToString()+" ";

				// Clear the message queue for TEST_MSG
				SysMsg.SM_TEST_MSG = false;
				SysMsg.SM_TEST_MSG_QUEUE.Clear();

				MessageBox.Show("Test message queue processed:\n"+queue,"Done",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}

			// Post-process: reset current app directory
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
		}

		#endregion

		#region World Map Path Editor

		private string WM_File = "";
		private ArrayList WM_Paths = new ArrayList();
		private void btnOpenWorldMap_Click(object sender, System.EventArgs e)
		{
			MultiODLG.Filter = "World Map Paths File (worldmap_ui_paths.bin)|worldmap_ui_paths.bin";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				w_Paths.Items.Clear();
				w_PathCodes.Items.Clear();

				WM_File = MultiODLG.FileName;
				WM_Paths = new ArrayList();

				// Process the paths file
				BinaryReader r_wmp = new BinaryReader(new FileStream(WM_File, FileMode.Open));
				int num_paths = r_wmp.ReadInt32();
				uint PARAM1 = 0;
				uint PARAM2 = 0;
				uint PARAM3 = 0;
				uint PARAM4 = 0;
				uint PATH_SIZE = 0;
				ArrayList PATH = new ArrayList();
				
				for (int i=0; i<num_paths; i++)
				{
					PATH = new ArrayList();
					ProcessEntry(r_wmp, ref PARAM1, ref PARAM2, ref PARAM3, ref PARAM4, ref PATH_SIZE, ref PATH);
					
					w_Paths.Items.Add("#"+i.ToString()+": ("+PARAM1.ToString()+","+PARAM2.ToString()+") - ("+PARAM3.ToString()+","+PARAM4.ToString()+")");
					WM_Paths.Add(PATH);
				}

				r_wmp.Close();
				btnAddPath.Enabled = true;
				btnDelPath.Enabled = true;
				btnSaveWorldMap.Enabled = true;
				tPar1.Enabled = true;
				tPar2.Enabled = true;
				tPar3.Enabled = true;
				tPar4.Enabled = true;
				w_PathCodes.Enabled = true;
				w_Opcodes.Enabled = true;
				w_Paths.Enabled = true;
				btnSetOpcode.Enabled = true;
				btnInsertOpcode.Enabled = true;
				btnDeleteOpcode.Enabled = true;
				btnUpdatePath.Enabled = true;
			}
		}

		// Process a single path node
		private void ProcessEntry(BinaryReader r_wmp, ref uint op1, ref uint op2, ref uint op3, ref uint op4, ref uint pathsize, ref ArrayList path)
		{
			op1 = r_wmp.ReadUInt32();
			op2 = r_wmp.ReadUInt32();
			op3 = r_wmp.ReadUInt32();
			op4 = r_wmp.ReadUInt32();
			pathsize = r_wmp.ReadUInt32();
			uint opt_pathsize = 4 - (pathsize % 4); // compensate 0xFD entries
			                                        // for WMP optimization tech
			for (uint i=0; i<pathsize; i++)
				path.Add(r_wmp.ReadByte());

			if (opt_pathsize != 4)
			{
				for (uint j=0; j<opt_pathsize; j++)
					r_wmp.ReadByte();
			}
		}

		private void w_Paths_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			w_PathCodes.Items.Clear();

			string PathInfo = w_Paths.Items[w_Paths.SelectedIndex].ToString();
			string[] PathInfo_A = PathInfo.Split('-');
			string Path_Par1 = PathInfo_A[0].Split('(',')',',')[1].Trim();
			string Path_Par2 = PathInfo_A[0].Split('(',')',',')[2].Trim();
			string Path_Par3 = PathInfo_A[1].Split('(',')',',')[1].Trim();
			string Path_Par4 = PathInfo_A[1].Split('(',')',',')[2].Trim();
			tPar1.Text = Path_Par1;
			tPar2.Text = Path_Par2;
			tPar3.Text = Path_Par3;
			tPar4.Text = Path_Par4;

			int opcodes_in_path = ((ArrayList)WM_Paths[w_Paths.SelectedIndex]).Count;

			for (int j=0; j<opcodes_in_path; j++)
			{
				byte op_value = (byte)((ArrayList)WM_Paths[w_Paths.SelectedIndex])[j];
				w_PathCodes.Items.Add(w_Opcodes.Items[(int)op_value]);
			}
		}

		private void btnSaveWorldMap_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the world map paths?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;

			BinaryWriter bw = new BinaryWriter(new FileStream(WM_File, FileMode.Create));
			// Save the # of paths
			bw.Write((uint)w_Paths.Items.Count);

			// Save each path
			for (int i=0; i<w_Paths.Items.Count; i++)
			{
				string PathInfo = w_Paths.Items[i].ToString();
				string[] PathInfo_A = PathInfo.Split('-');
				string Path_Par1 = PathInfo_A[0].Split('(',')',',')[1].Trim();
				string Path_Par2 = PathInfo_A[0].Split('(',')',',')[2].Trim();
				string Path_Par3 = PathInfo_A[1].Split('(',')',',')[1].Trim();
				string Path_Par4 = PathInfo_A[1].Split('(',')',',')[2].Trim();
				bw.Write(UInt32.Parse(Path_Par1));
				bw.Write(UInt32.Parse(Path_Par2));
				bw.Write(UInt32.Parse(Path_Par3));
				bw.Write(UInt32.Parse(Path_Par4));
	
				int opcodes_in_path = ((ArrayList)WM_Paths[i]).Count;
				bw.Write(opcodes_in_path);

				for (int j=0; j<opcodes_in_path; j++)
					bw.Write((byte)((ArrayList)WM_Paths[i])[j]);

				if (opcodes_in_path % 4 != 0)
				{
					for (int k=0; k<(4-(opcodes_in_path%4)); k++)
						bw.Write((byte)0xFD);
				}

			}

			bw.Close();

			MessageBox.Show("World map paths saved.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void w_PathCodes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			byte op_value = (byte)((ArrayList)WM_Paths[w_Paths.SelectedIndex])[w_PathCodes.SelectedIndex];					
			w_Opcodes.SelectedIndex = (int)op_value;
			tPathElem.Text = w_PathCodes.SelectedIndex.ToString();
		}

		private void btnDelPath_Click(object sender, System.EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this path?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;

			int pid_to_remove = w_Paths.SelectedIndex;

			WM_Paths.RemoveAt(pid_to_remove);
			w_Paths.Items.RemoveAt(pid_to_remove);
			w_PathCodes.Items.Clear();
		}

		private void btnAddPath_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to add a path with current coordinates?","Please confirm operation",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
				return;

			w_Paths.Items.Add("#NEW: ("+tPar1.Text+","+tPar2.Text+") - ("+tPar3.Text+","+tPar4.Text+")");
			WM_Paths.Add(new ArrayList()); // a new path reference

			MessageBox.Show("Path added.","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnSetOpcode_Click(object sender, System.EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			if (w_Opcodes.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an opcode!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			((ArrayList)WM_Paths[w_Paths.SelectedIndex])[w_PathCodes.SelectedIndex] = (byte)w_Opcodes.SelectedIndex;
			w_PathCodes.Items[w_PathCodes.SelectedIndex] = w_Opcodes.Items[w_Opcodes.SelectedIndex];
		}

		private void btnInsertOpcode_Click(object sender, System.EventArgs e)
		{
			if (w_Opcodes.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an opcode!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return;
			}

			if (w_PathCodes.SelectedIndex == -1 || w_PathCodes.Items.Count == 0)
			{
				((ArrayList)WM_Paths[w_Paths.SelectedIndex]).Add((byte)w_Opcodes.SelectedIndex);
				w_PathCodes.Items.Add(w_Opcodes.Items[w_Opcodes.SelectedIndex]);
				return;
			}

			((ArrayList)WM_Paths[w_Paths.SelectedIndex]).Insert(w_PathCodes.SelectedIndex, (byte)w_Opcodes.SelectedIndex);
			w_PathCodes.Items.Insert(w_PathCodes.SelectedIndex, w_Opcodes.Items[w_Opcodes.SelectedIndex]);
		}

		private void btnDeleteOpcode_Click(object sender, System.EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			((ArrayList)WM_Paths[w_Paths.SelectedIndex]).RemoveAt(w_PathCodes.SelectedIndex);
			w_PathCodes.Items.RemoveAt(w_PathCodes.SelectedIndex);
		}

		private void btnUpdatePath_Click(object sender, System.EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			w_Paths.Items[w_Paths.SelectedIndex] = "#"+w_Paths.SelectedIndex.ToString()+": ("+tPar1.Text+","+tPar2.Text+") - ("+tPar3.Text+","+tPar4.Text+")";
		}

		#endregion

		#region Addin system calls and Path Node Generator
		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			PathNodeGen p = new PathNodeGen();
			p.ShowDialog();
		}
		#endregion

        #region Proto Search Call and other Tools

        private void dayNightTransitionsEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DayNightEd dnWnd = new DayNightEd();
            dnWnd.ShowDialog();
        }

        private void prototypeSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProtoSearch psWnd = new ProtoSearch();

            for (int i = 0; i < Prototype.Items.Count; i++)
                psWnd.protos.Add(Prototype.Items[i]);
            for (int i = 0; i < protos.Count; i++)
                psWnd.protos_complete.Add(protos[i]);
            psWnd.ShowDialog();
        }
        #endregion

        #region TEU Addins
        private void whatAreTheseAddinsForToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Object Viewer: displays a tree-like representation of all objects you have in a specified folder, with their properties in raw state. Allows to view properties which are not editable by the World Builder.\n\nSector Sort Tool: this is a very important utility which must be ran on your sectors if you embedded new static objects in them. It will sort the static objects so they are in correct order for the game to load. Automatically runs on Sectors folder of the ToEE World Builder when started.\n\nScript Override Tool: Compensates for the lack of an option in ToEEWB to directly override scripts in the mobile objects. Allows you to create a scripts entry in a mobile object and override used scripts from there without having to waste precious prototypes. If an object is loaded in ToEEWB, it will automatically be loaded into the Script Override Tool upon startup. Note that if you add the script override and save it in the override tool, you MUST reload the object in ToEEWB, or your override information will be lost!", "Addin usage information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mobileObjectViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            System.Diagnostics.Process.Start("Addins\\ObjView.exe");
        }

        private void sectorSortUtilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            System.Diagnostics.Process.Start("Addins\\SectorSort.exe", "\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors" + "\"");
        }

        private void scriptOverrideToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));

            if (MobileName.Text != "<NO OBJECT LOADED>")
                System.Diagnostics.Process.Start("Addins\\ScriptOverride.exe", "\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\Mobiles\\" + MobileName.Text + ".mob\"");
            else
                System.Diagnostics.Process.Start("Addins\\ScriptOverride.exe");
        }
        #endregion
    }
}
