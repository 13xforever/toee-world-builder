using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class Worlded : Form
	{
		public Worlded()
		{
			InitializeComponent();
		}

		#region Debug stuff

		private void debug_Click(object sender, EventArgs e)
		{
			// Set the message: SM_TEST_MSG
			SysMsg.SM_TEST_MSG_QUEUE.Add("test 1");
			SysMsg.SM_TEST_MSG_QUEUE.Add("test 2");
			SysMsg.SM_TEST_MSG = true;
		}

		private void debug2_Click(object sender, EventArgs e)
		{
			var sr = new StreamReader("in.feat");
			var sw = new StreamWriter("out.feat");
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

		private readonly Hashtable Descriptions = new Hashtable();
		private readonly Hashtable LongDescs = new Hashtable();
		private readonly Hashtable Proto_Types = new Hashtable();

		private readonly ArrayList desc = new ArrayList();
		private readonly ArrayList ldesc = new ArrayList();
		private readonly ArrayList protos = new ArrayList();

		private readonly Splash s = new Splash();
		private ArrayList Addins = new ArrayList();
		private int SPLASH_STATE;

		private void menuItem2_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?",
								"Please confirm quitting",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.Yes)
				Application.Exit();
		}

		private void Worlded_Closing(object sender, CancelEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit?",
								"Please confirm quitting",
								MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.No)
				e.Cancel = true;
		}

		private void Worlded_Load(object sender, EventArgs e)
		{
			// If there's no SARC file, recreate it
			if (!File.Exists("ToEE World Builder.sar"))
			{
				var sw = new StreamWriter("ToEE World Builder.sar");
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
				var sr = new StreamReader("ToEE World Builder.opc");
				string str = "";

				for (int i = 0; i < 6; i++)
					sr.ReadLine();

				wPar1.Text = sr.ReadLine();
				wPar2.Text = sr.ReadLine();
				wPar3.Text = sr.ReadLine();
				wPar4.Text = sr.ReadLine();

				while ((str = sr.ReadLine()) != "[END INTERNAL PATCH]")
					w_Opcodes.Items.Add(str);

				sr.Close();
			}

			// Load configuration
			if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\ToEE World Builder.ini"))
			{
				var cfg = new StreamReader(new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\ToEE World Builder.ini", FileMode.Open));
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
						MessageBox.Show("Your configuration file may be outdated. Please check your WB configuration (ENSURE THAT THE PATH TO TOEE-TO-WB BRIDGE IS NOT EMPTY!) and save it again.", "Obsolete configuration format", MessageBoxButtons.OK,
										MessageBoxIcon.Warning);
						tWBBridge.Text = "C:\\";
						Helper.InteropPath = "C:\\wb200_il.lri";
					}
					if (tWBBridge.Text[tWBBridge.Text.Length - 1] == '\\')
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

		private void tmrSplash_Tick(object sender, EventArgs e)
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
			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\protos.tab"))
			{
				MessageBox.Show("ToEE World Editor requires a PROTOS.TAB file!",
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\description.mes"))
			{
				MessageBox.Show("ToEE World Editor requires a DESCRIPTION.MES file!",
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			if (!File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\long_description.mes"))
			{
				MessageBox.Show("ToEE World Editor requires a LONG_DESCRIPTION.MES file!",
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				Application.Exit();
				return;
			}

			// Load PROTOS, DESCRIPTION, and LONG_DESCRIPTION files
			var f_protos = new StreamReader("protos.tab");
			var f_desc = new StreamReader("description.mes");
			var f_ldesc = new StreamReader("long_description.mes");

			string str = "";

			while ((str = f_protos.ReadLine()) != null)
				protos.Add(str);

			while ((str = f_desc.ReadLine()) != null)
			{
				desc.Add(str);
				if (str.Trim() == "")
					continue;
				if (str.Substring(0, 1) != "{")
					continue;

				string[] __DESC = str.Split('{', '}');
				try
				{
					Descriptions.Add(__DESC[1], __DESC[3]);
				}
				catch (Exception)
				{
					MessageBox.Show("Warning: duplicate description detected in DESCRIPTION.MES (entry #" + __DESC[1] + ")\n\nIt is recommended that you fix this error before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				// Adding to the description editor
				lstDesc.Items.Add(__DESC[1] + ": " + __DESC[3]);
			}

			while ((str = f_ldesc.ReadLine()) != null)
			{
				ldesc.Add(str);
				if (str.Trim() == "")
					continue;
				if (str.Substring(0, 1) != "{")
					continue;

				string[] __LDESC = str.Split('{', '}');
				try
				{
					LongDescs.Add(__LDESC[1], __LDESC[3]);
				}
				catch (Exception)
				{
					MessageBox.Show("Warning: duplicate long description detected in LONG_DESCRIPTION.MES (entry #" + __LDESC[1] + ")\n\nIt is recommended that you fix this error before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			f_ldesc.Close();
			f_desc.Close();
			f_protos.Close();

			string[] proto;
			foreach (string st in protos)
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

				string TARGET_LINE = DESC + " -> #" + ID;

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
					MessageBox.Show("Warning: duplicate prototype detected in PROTOS.TAB (entry #" + ID + ")\n\nIt is recommended that you fix this error before proceeding.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			SetInterfaceState(false);
			s.Dispose();

			// Set the default data for certain boxes
			cmbTileSound.SelectedIndex = 2;
		}

		private void CallAddin(object sender, EventArgs e)
		{
			string[] aim_nametag = sender.ToString().Split(':');
			string aim_name = aim_nametag[aim_nametag.GetUpperBound(0)].Trim();
			string proc_to_exec = "";

			var sr = new StreamReader("ToEE World Builder.aim");
			string st = "";
			while ((st = sr.ReadLine()) != "[END ADDIN LIST]")
			{
				if (st.Trim() == "")
					continue;
				if (st.Substring(0, 1) == "/")
					continue;

				string[] aim_data = st.Split('=');
				if (aim_data[0] == aim_name)
					proc_to_exec = aim_data[1];
			}
			sr.Close();

			if (proc_to_exec != "" && File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Addins\\" + proc_to_exec))
				Process.Start(Path.GetDirectoryName(Application.ExecutablePath) + "\\Addins\\" + proc_to_exec);
		}

		#endregion

		#region MOB Editor

		// + Begin MOB Fields +
		private ArrayList CHEST_INV = new ArrayList();
		private uint CONTAINER_INV_LIST_IDX;
		private uint IMPORTED_ENTRY293;
		private ArrayList IMPORTED_ENTRY30 = new ArrayList();
		private ArrayList IMPORTED_ENTRY40 = new ArrayList();
		private ArrayList IMPORTED_ENTRY41 = new ArrayList();
		private ArrayList IMPORTED_ENTRY42 = new ArrayList();
		private ArrayList IMPORTED_ENTRY73 = new ArrayList();
		private bool INDIRECT;
		private bool INDIRECT_CALLBACK;
		private bool LOADING;
		private string MOB_BITMAP = "";
		private string MOB_GUID = "";
		private byte[] MOB_GUID_BYTES = new byte[24];
		private string MOB_OBJFLAGS_BITMAP = "";
		private byte[] MOB_PROP_152 = new byte[24]; // Used to store item parent GUID
		private byte[] MOB_PROP_SUBINV = new byte[24]; // Used to store NPC substitute inventory object GUID
		private ArrayList NPC_INV = new ArrayList();
		private bool NPC_INVENSOURCE_CALLBACK;
		private uint NPC_INV_LIST_IDX;
		private ArrayList NPC_WAYPOINTS = new ArrayList(); // v1.3: waypoint sys
		private uint SAR_POS; // SARC index for containers
		private uint SAR_POS_ABL; // SARC index for abilities
		private uint SAR_POS_FCN; // SARC index for factions
		private uint SAR_POS_MDX; // SARC index for money
		private uint SAR_POS_NPC; // SARC index for NPCs
		private uint SAR_POS_STN; // SARC index for standpoints
		private uint SAR_POS_WAY; // SARC index for waypoints
		private string __MOB_OVERRIDE_NAME = "";
		// - End MOB Fields -

		private void btnNew_Click(object sender, EventArgs e)
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

		private void Prototype_SelectedIndexChanged(object sender, EventArgs e)
		{
			INDIRECT = true;

			try
			{
				MobType.SelectedIndex = MobType.Items.IndexOf(Proto_Types[Prototype.Items[Prototype.SelectedIndex]].ToString());
			}
			catch (Exception)
			{
				MessageBox.Show(
					"Unexpected Error 007: An error encountered attempting to set the mobile type. This means that PROTOS.TAB and/or DESCRIPTION.MES was changed but the files were not reparsed correctly. You need to restart ToEE World Builder in order to restore correct functionality. We are sorry for the inconvenience.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void MobType_SelectedIndexChanged(object sender, EventArgs e)
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

		private void btnOpenMob_Click(object sender, EventArgs e)
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));

			var o = new OpenMOB();
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

				uint data;
				UInt16 data_16;

				var mob = new FileStream("Mobiles\\" + o.FileToOpen + ".mob", FileMode.Open);
				var r_mob = new BinaryReader(mob);

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
				for (int i = 0; i < Prototype.Items.Count; i++)
				{
					if (Prototype.Items[i].ToString().IndexOf("#" + data.ToString()) == Prototype.Items[i].ToString().Length - data.ToString().Length - 1) //!= -1
					{
						Prototype.SelectedIndex = i;
						break;
					}
				}

				data = r_mob.ReadUInt32(); // Not used, at least for now
				data = r_mob.ReadUInt32(); // Not used, at least for now
				data = r_mob.ReadUInt32(); // Not used, at least for now

				MOB_GUID_BYTES = r_mob.ReadBytes(24); // GUID

				uint MOB_TYPE_F;
				MOB_TYPE_F = r_mob.ReadUInt32(); // Type. Ignored due to being auto-set.
				data_16 = r_mob.ReadUInt16(); // Number of properties. Ignored due to being auto-detected.

				// Read the bitmap
				// int BitmapSize = Helper.MOB_GetNumberofBitmapBlocks(Helper.GEN_GetMobileType(MobType.Text));
				int BitmapSize = Helper.MOB_GetNumberofBitmapBlocks((MobTypes) MOB_TYPE_F);
				int BitmapNoBytes = BitmapSize*4;
				var BitmapBytes = new byte[BitmapNoBytes];
				BitmapBytes = r_mob.ReadBytes(BitmapNoBytes);
				MOB_BITMAP = Helper.MOB_BytesToBitmap(BitmapBytes);

				SetInterfaceState(true);

				// Load properties
				try
				{
					LOADING = true;
					LoadMOB_Properties(r_mob, "Mobiles\\" + o.FileToOpen + ".mob");
					LOADING = false;
				}
				catch (Exception)
				{
					// Show an error message and unload the object in case
					// there was a critical error parsing the properties.
					MessageBox.Show(
						"A critical error occurred trying to load this mobile object file. It means that this file contains properties that are not yet supported in ToEE World Builder (and, therefore, the file can't be loaded correctly). In order to avoid data corruption the loading of this mobile object has been canceled.",
						"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("X Offset had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Y Offset had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Z Offset had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Radius had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Speed (Walk) had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Speed (Run) had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("Rotation had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					MessageBox.Show("3D Render Height had an invalid floating point value passed to it! It's reset to zero.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
		}

		// Save a MOB file

		private void SaveMOB()
		{
			FileStream mob;

			if (__MOB_OVERRIDE_NAME == "")
				mob = new FileStream("Mobiles\\" + MobileName.Text + ".mob", FileMode.Create);
			else
			{
				mob = new FileStream(__MOB_OVERRIDE_NAME, FileMode.Create);
				__MOB_OVERRIDE_NAME = "";
			}

			TestFloats();

			var w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(Prototype.Text.Split('#')[1]);

			// Do we have to embed in a sector? If so, use type 0x00 GUID,
			// otherwise use type 0x02 GUID
			if (Helper.EmbedMode)
			{
				MOB_GUID_BYTES[0] = 0x00;
				Helper.EmbedMode = false;
			}
			else
			{
				MOB_GUID_BYTES[0] = 0x02;
			}

			try
			{
				w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
				w_mob.Write(MOB_GUID_BYTES);
				w_mob.Write((int) Helper.GEN_GetMobileType(MobType.Text));
				w_mob.Write(Helper.MOB_GetNumberOfProperties(MOB_BITMAP));

				ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(MOB_BITMAP);

				foreach (object block in BitmapBytes)
					w_mob.Write((byte) block);

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

		private void btnSaveMob_Click(object sender, EventArgs e)
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
				MobType.Text == "obj_t_projectile" /*UNKNOWN*/||
				MobType.Text == "obj_t_trap")
			{
				if (
					MessageBox.Show(
						"Objects of the chosen type (" + MobType.Text +
						") should be embedded into sectors! Saving them as standalone MOB files may have unpredictable effect on the game. You can save the MOB file for this object only to be able to load it later and embed into a sector. Is that what you want to do?",
						"Please confirm precarious operation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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
				MessageBox.Show("Warning: You have specified an option to include a back-reference to the parent container but you forgot to choose the container itself. Please correct the error before saving.", "Error", MessageBoxButtons.OK,
								MessageBoxIcon.Exclamation);
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
				MessageBox.Show(
					"There was an error parsing object properties. Saving failed. Please check all your properties (whether they are set correctly and whether they are valid for your object type, e.g. you can't define NPC flags for a door)\n\nIt is a known issue that sometimes setting an invalid flag and then turning it off causes this error, too. In that case you may want to reload the mobile object file. Sorry for the inconvenience.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				if (File.Exists("Mobiles\\" + MobileName.Text + ".mob"))
					File.Delete("Mobiles\\" + MobileName.Text + ".mob");
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
			for (int i = 0; i < 512; i++)
			{
				TriState state = Helper.MOB_GetPropertyState(MOB_BITMAP, i);
				if (state == TriState.True)
				{
					// Main code to save props
					switch (i)
					{
						case 0:
							// obj_f_location
							uint loc_x = uint.Parse(LocationX.Text);
							uint loc_y = uint.Parse(LocationY.Text);
							w_mob.Write((byte) 0x01);
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
							uint alpha = uint.Parse(vTransparency.Text);
							w_mob.Write(alpha);
							break;
						case 7:
							// obj_f_scale
							uint scale = uint.Parse(vModelScale.Text);
							w_mob.Write(scale);
							break;
						case 21:
							// obj_f_flags
							uint objflags = GetObjectFlags();
							w_mob.Write(objflags);
							break;
						case 23:
							// obj_f_name
							uint name = uint.Parse(vObjName.Text);
							w_mob.Write(name);
							break;
						case 26:
							// obj_f_hp_pts
							uint hp = uint.Parse(vHP.Text);
							w_mob.Write(hp);
							break;
						case 27:
							// obj_f_hp_adj
							uint hp_adj = uint.Parse(vHPAdj.Text);
							w_mob.Write(hp_adj);
							break;
						case 28:
							// obj_f_hp_damage
							uint hp_dmg = uint.Parse(vHPDmg.Text);
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
							w_mob.Write(0xFFFFFFFF);
							break;
						case 46:
							// obj_f_secretdoor_flags
							var sdflags = (int) GetSecretDoorFlags();
							// now, we need to embed the door DC in here
							sdflags = Helper.MAKE_DC(sdflags, int.Parse(vSDDC.Text));
							w_mob.Write(sdflags);
							break;
						case 47:
							// obj_f_secretdoor_effectname
							uint eff = uint.Parse(vEffName.Text);
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
							uint p_flags = GetPortalFlags();
							w_mob.Write(p_flags);
							break;
						case 89:
							// obj_f_portal_lock_dc
							uint p_dc = uint.Parse(vPLockDC.Text);
							w_mob.Write(p_dc);
							break;
						case 90:
							// obj_f_portal_key_id
							uint p_key_id = uint.Parse(vPKeyID.Text);
							w_mob.Write(p_key_id);
							break;
						case 91:
							// obj_f_portal_notify_npc
							uint notify1 = uint.Parse(pNotify1.Text);
							w_mob.Write(notify1);
							break;
						case 102:
							// obj_f_container_flags
							uint contflags = GetContainerFlags();
							w_mob.Write(contflags);
							break;
						case 103:
							// obj_f_container_lock_dc
							uint dc = uint.Parse(vLockDC.Text);
							w_mob.Write(dc);
							break;
						case 104:
							// obj_f_container_key_id
							uint key_id = uint.Parse(vKeyID.Text);
							w_mob.Write(key_id);
							break;
						case 105:
							// obj_f_container_inventory_num
							w_mob.Write((uint) vChestInv.Items.Count);
							break;
						case 106:
							// obj_f_container_inventory_list_idx
							SaveLinkedMobileObjects(w_mob);
							break;
						case 107:
							// obj_f_container_inventory_source (INVENSOURCE)
							uint invsrc = uint.Parse(vInvenSource.Text);
							w_mob.Write(invsrc);
							break;
						case 108:
							// obj_f_container_notify_npc
							uint notify2 = uint.Parse(pNotify2.Text);
							w_mob.Write(notify2);
							break;
						case 121:
							// obj_f_scenery_flags
							uint scenflags = GetSceneryFlags();
							w_mob.Write(scenflags);
							break;
						case 126:
							// obj_f_scenery_teleport_to
							uint scenery_dest = uint.Parse(vTeleport.Text);
							w_mob.Write(scenery_dest);
							break;
						case 151:
							// obj_f_item_flags
							uint itemflags = GetItemFlags();
							w_mob.Write(itemflags);
							break;
						case 152:
							// obj_f_item_parent
							w_mob.Write((byte) 0x01);
							w_mob.Write(MOB_PROP_152);
							break;
						case 153:
							// obj_f_item_weight
							uint weight = uint.Parse(vWeight.Text);
							w_mob.Write(weight);
							break;
						case 154:
							// obj_f_item_worth
							uint worth = uint.Parse(vWorth.Text);
							w_mob.Write(worth);
							break;
						case 156:
							// obj_f_item_inv_location
							uint slot = uint.Parse(vInvSlot.Text);
							w_mob.Write(slot);
							break;
						case 167:
							// obj_f_item_quantity
							uint quantity = uint.Parse(vItemAmt.Text);
							w_mob.Write(quantity);
							break;
						case 187:
							// obj_f_weapon_flags
							uint weapflags = GetWeaponFlags();
							w_mob.Write(weapflags);
							break;
						case 210:
							// obj_f_ammo_quantity
							uint ammo = uint.Parse(vAmmoAmt.Text);
							w_mob.Write(ammo);
							break;
						case 219:
							// obj_f_armor_flags
							uint armorflags = GetArmorFlags();
							w_mob.Write(armorflags);
							break;
						case 220:
							// obj_f_armor_ac_adj
							int acadj = int.Parse(vACAdj.Text);
							w_mob.Write(acadj);
							break;
						case 221:
							// obj_f_armor_max_dex_bonus
							int maxdex = int.Parse(vACMaxDex.Text);
							w_mob.Write(maxdex);
							break;
						case 222:
							// obj_f_armor_arcane_spell_failure
							int sf = int.Parse(vSpellFail.Text);
							w_mob.Write(sf);
							break;
						case 223:
							// obj_f_armor_armor_check_penalty
							int chk = int.Parse(vArmorChk.Text);
							w_mob.Write(chk);
							break;
						case 230:
							// obj_f_money_quantity
							uint mamount = uint.Parse(vMoneyQuantity.Text);
							w_mob.Write(mamount);
							break;
						case 255:
							// obj_f_key_key_id
							uint id = uint.Parse(vKeyID2.Text);
							w_mob.Write(id);
							break;
						case 283:
							// obj_f_critter_flags
							uint critflags1 = GetCritterFlags1();
							w_mob.Write(critflags1);
							break;
						case 284:
							// obj_f_critter_flags2
							uint critflags2 = GetCritterFlags2();
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
							w_mob.Write((uint) vNpcInv.Items.Count);
							break;
						case 309:
							// obj_f_critter_inventory_list_idx
							SaveLinkedMobileObjectsForNPC(w_mob);
							break;
						case 310:
							// obj_f_critter_inventory_source
							uint ninvsrc = uint.Parse(vNpcInvenSource.Text);
							w_mob.Write(ninvsrc);
							break;
						case 313:
							// obj_f_critter_teleport_dest
							w_mob.Write((byte) 0x01);
							w_mob.Write(uint.Parse(vTeleX.Text));
							w_mob.Write(uint.Parse(vTeleY.Text));
							break;
						case 314:
							// obj_f_critter_teleport_map
							w_mob.Write(uint.Parse(vTeleMap.Text));
							break;
						case 317:
							// obj_f_critter_reach
							uint reach = uint.Parse(vReach.Text);
							w_mob.Write(reach);
							break;
						case 319:
							// obj_f_critter_levelup_scheme
							uint scheme = uint.Parse(vLevelup.Text);
							w_mob.Write(scheme);
							break;
						case 353:
							// obj_f_npc_flags
							uint npcflags = GetNPCFlags();
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
							w_mob.Write((byte) 0x01);
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
								MessageBox.Show("Error: AI Flags 64 were not defined correctly! Please use only 0's and 1's, no spaces and no carriage return symbols!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
								break;
							}
							w_mob.Write((byte) 0x01);
							foreach (object block in ar_tmp)
								w_mob.Write((byte) block);
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

			for (int i = 0; i < 512; i++)
			{
				TriState state = Helper.MOB_GetPropertyState(MOB_BITMAP, i);
				if (state == TriState.True)
				{
#if DEBUG
					MessageBox.Show(i.ToString() + "; ofs:" + r_mob.BaseStream.Position.ToString());
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
							SetSecretDoorFlags((uint) SDFlags);
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
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x04);
			w_mob.Write(0x06);

			if (SAR_POS_ABL == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_ABL = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_ABL);

			w_mob.Write(int.Parse(vSTR.Text));
			w_mob.Write(int.Parse(vDEX.Text));
			w_mob.Write(int.Parse(vCON.Text));
			w_mob.Write(int.Parse(vINT.Text));
			w_mob.Write(int.Parse(vWIS.Text));
			w_mob.Write(int.Parse(vCHA.Text));

			Helper.GetComp2Ex(w_mob, 6);
		}

		private uint PackGeneratorData()
		{
			// Note: spawn rate should be controlled in radiobox event handlers!
			uint gdata = 0;

			gdata = (uint) Helper.MAKE_GENID((int) gdata, int.Parse(vNPCGenData.Text));
			gdata = (uint) Helper.MAKE_SPAWNMAX((int) gdata, int.Parse(vNPCGSpawnConcurrent.Text));
			gdata = (uint) Helper.MAKE_TOTAL((int) gdata, int.Parse(vNPCGSpawnTotal.Text));

			// set flags
			if (vNPCGDay.Checked)
				gdata += (uint) Math.Pow(2, 27);
			if (vNPCGNight.Checked)
				gdata += (uint) Math.Pow(2, 28);
			if (vNPCGActive.Checked)
				gdata += (uint) Math.Pow(2, 29);
			if (vNPCGSpawnAll.Checked)
				gdata += (uint) Math.Pow(2, 30);
			if (vNPCGIgnoreTotal.Checked)
				gdata += (uint) Math.Pow(2, 31);

			return gdata;
		}

		private void UnpackGeneratorData(uint gdata)
		{
			string gbitmap = Helper.GEN_UInt32_To_Bitmap(gdata);
			var _gdata = (int) gdata;

			if ((gdata & ((uint) Math.Pow(2, 27))) != 0)
				vNPCGDay.Checked = true;
			else
				vNPCGDay.Checked = false;

			if ((gdata & ((uint) Math.Pow(2, 28))) != 0)
				vNPCGNight.Checked = true;
			else
				vNPCGNight.Checked = false;

			if ((gdata & ((uint) Math.Pow(2, 29))) != 0)
				vNPCGActive.Checked = true;
			else
				vNPCGActive.Checked = false;

			if ((gdata & ((uint) Math.Pow(2, 30))) != 0)
				vNPCGSpawnAll.Checked = true;
			else
				vNPCGSpawnAll.Checked = false;

			if ((gdata & ((uint) Math.Pow(2, 31))) != 0)
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
				int rate = Helper.GET_NPCGEN((int) flags);

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
			var i_Target = new ArrayList();
			uint mul1 = 0;
			uint mul2 = 0;
			uint num_bytes = 0;

			i_Target.Add(r_mob.ReadByte()); // leading 0x01
			mul1 = r_mob.ReadUInt32();
			mul2 = r_mob.ReadUInt32();
			r_mob.ReadUInt32(); // should be SARC here
			r_mob.BaseStream.Seek(-12, SeekOrigin.Current);

			num_bytes = mul1*mul2;
			for (int i = 0; i < num_bytes + 12; i++)
				i_Target.Add(r_mob.ReadByte());

			// post-struct
			uint r_nument = r_mob.ReadUInt32();
			uint bytes_to_add = r_nument*4 + 4;
			r_mob.BaseStream.Seek(-4, SeekOrigin.Current);

			for (uint r = 0; r < bytes_to_add; r++)
				i_Target.Add(r_mob.ReadByte());

			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, entry_ID, true);
			return i_Target;
		}

		private void ExportEntry(BinaryWriter w_mob, ArrayList entry_data)
		{
			foreach (object block in entry_data)
				w_mob.Write((byte) block);
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
			for (uint r = 0; r < r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void LoadLinkedMobileObjects(BinaryReader r_mob)
		{
			r_mob.ReadByte();
			r_mob.ReadBytes(4);
			r_mob.ReadBytes(4);
			SAR_POS = r_mob.ReadUInt32(); // SARC

			for (int i = 0; i < CONTAINER_INV_LIST_IDX; i++)
			{
				byte[] GUID = r_mob.ReadBytes(24);
				string s_GUID = Helper.GEN_ConvertBytesToStringGUID(GUID);

				try
				{
					var br = new BinaryReader(new FileStream("Mobiles\\" + s_GUID + ".mob", FileMode.Open));
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					int proto = br.ReadInt32();
					br.Close();
					vChestInv.Items.Add(Helper.Proto_By_ID[proto.ToString()] + "\t\t\t\t" + s_GUID);
				}
				catch (Exception)
				{
					MessageBox.Show("Error: Can't find the linked inventory mobile object file: \n" + s_GUID + ".mob", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			uint r_nument = r_mob.ReadUInt32();

			for (uint r = 0; r < r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void LoadLinkedMobileObjectsForNPC(BinaryReader r_mob)
		{
			r_mob.ReadByte();
			r_mob.ReadBytes(4);
			r_mob.ReadBytes(4);
			SAR_POS_NPC = r_mob.ReadUInt32(); // SARC

			for (int i = 0; i < NPC_INV_LIST_IDX; i++)
			{
				byte[] GUID = r_mob.ReadBytes(24);
				string s_GUID = Helper.GEN_ConvertBytesToStringGUID(GUID);

				try
				{
					var br = new BinaryReader(new FileStream("Mobiles\\" + s_GUID + ".mob", FileMode.Open));
					br.BaseStream.Seek(0x0C, SeekOrigin.Begin);
					int proto = br.ReadInt32();
					br.Close();
					vNpcInv.Items.Add(Helper.Proto_By_ID[proto.ToString()] + "\t\t\t\t" + s_GUID);
				}
				catch (Exception)
				{
					MessageBox.Show("Error: Can't find the linked inventory mobile object file: \n" + s_GUID + ".mob", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}

			uint r_nument = r_mob.ReadUInt32();

			for (uint r = 0; r < r_nument; r++)
				r_mob.ReadUInt32();
		}

		private void SaveMoneyIndex(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x04);
			w_mob.Write(0x04);

			if (SAR_POS_MDX == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_MDX = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_MDX);

			w_mob.Write(uint.Parse(vMoneyIdx1.Text));
			w_mob.Write(uint.Parse(vMoneyIdx2.Text));
			w_mob.Write(uint.Parse(vMoneyIdx3.Text));
			w_mob.Write(uint.Parse(vMoneyIdx4.Text));

			Helper.GetComp2Ex(w_mob, 4);
		}

		private void SaveLinkedMobileObjects(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x18);
			w_mob.Write(vChestInv.Items.Count);

			if (SAR_POS == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS);

			for (int i = 0; i < vChestInv.Items.Count; i++)
			{
				string MOB_UNIT = vChestInv.Items[i].ToString().Split('\t')[4];
				var br = new BinaryReader(new FileStream("Mobiles\\" + MOB_UNIT + ".mob", FileMode.Open));
				br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
				w_mob.Write(br.ReadBytes(24));
				br.Close();
			}

			Helper.GetComp2Ex(w_mob, (uint) vChestInv.Items.Count);
		}

		private void SaveLinkedMobileObjectsForNPC(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x18);
			w_mob.Write(vNpcInv.Items.Count);

			if (SAR_POS_NPC == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_NPC = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_NPC);

			for (int i = 0; i < vNpcInv.Items.Count; i++)
			{
				string MOB_UNIT = vNpcInv.Items[i].ToString().Split('\t')[4];
				var br = new BinaryReader(new FileStream("Mobiles\\" + MOB_UNIT + ".mob", FileMode.Open));
				br.BaseStream.Seek(0x1C, SeekOrigin.Begin);
				w_mob.Write(br.ReadBytes(24));
				br.Close();
			}

			Helper.GetComp2Ex(w_mob, (uint) vNpcInv.Items.Count);
		}

		private void SaveNPCFactions(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x04);
			w_mob.Write((uint) (vFactions.Items.Count));

			// SARC
			if (SAR_POS_FCN == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_FCN = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_FCN);

			// the structure itself
			for (int i = 0; i < vFactions.Items.Count; i++)
				w_mob.Write(uint.Parse((string) vFactions.Items[i]));

			// the post-structure
			Helper.GetComp2Ex(w_mob, (uint) (vFactions.Items.Count));
		}

		private void SaveNPCWaypoints(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x08);
			w_mob.Write((uint) (vWaypoints.Items.Count*8 + 2));

			// SARC
			if (SAR_POS_WAY == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_WAY = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_WAY);

			// Pre-structure
			w_mob.Write((uint) (vWaypoints.Items.Count));
			w_mob.Write(0x00);
			w_mob.Write(0x00);
			w_mob.Write(0x00);

			// Structure
			for (int i = 0; i < vWaypoints.Items.Count; i++)
			{
				Helper.SaveWaypoint(w_mob, (Helper.WaypointInfo) NPC_WAYPOINTS[i]);
			}

			// Post-structure
			Helper.GetComp2Ex(w_mob, (uint) (vWaypoints.Items.Count*8 + 2));
		}

		private void SaveNPCStandpoints(BinaryWriter w_mob)
		{
			w_mob.Write((byte) 0x01);
			w_mob.Write(0x08);

			if (!pScoutPoint.Checked)
				w_mob.Write(0x14);
			else
				w_mob.Write(0x1E); //0x1E for alertpoints

			// SARC
			if (SAR_POS_STN == 0)
			{
				uint sarc_idx = Helper.MOB_GenerateSARC(chkObjIDGen.Checked);
				w_mob.Write(sarc_idx); // Unknown, currently used by SARC system
				SAR_POS_STN = sarc_idx;
			}
			else
				w_mob.Write(SAR_POS_STN);

			// Filler
			var filler = new byte[48];
			for (int i = 0; i < 48; i++)
				filler[i] = 0x00;

			// Day point
			w_mob.Write(uint.Parse(vDayMap.Text));
			//w_mob.Write((uint)0x77F442AA);
			w_mob.Write((uint) 0);
			w_mob.Write(uint.Parse(vDayX.Text));
			w_mob.Write(uint.Parse(vDayY.Text));
			w_mob.Write(Single.Parse(vDayOfsX.Text));
			w_mob.Write(Single.Parse(vDayOfsY.Text));
			//w_mob.Write((uint)204);
			//w_mob.Write((uint)0x0012EB28);
			w_mob.Write(int.Parse(vDayJP.Text));
			w_mob.Write((uint) 0);
			w_mob.Write(filler);

			// Night point
			w_mob.Write(uint.Parse(vNightMap.Text));
			//w_mob.Write((uint)0x77F442AA);
			w_mob.Write((uint) 0);
			w_mob.Write(uint.Parse(vNightX.Text));
			w_mob.Write(uint.Parse(vNightY.Text));
			w_mob.Write(Single.Parse(vNightOfsX.Text));
			w_mob.Write(Single.Parse(vNightOfsY.Text));
			//w_mob.Write((uint)208);
			//w_mob.Write((uint)0x0012EB28);
			w_mob.Write(int.Parse(vNightJP.Text));
			w_mob.Write((uint) 0);
			w_mob.Write(filler);

			if (pScoutPoint.Checked)
			{
				w_mob.Write(uint.Parse(vScoutMap.Text));
				w_mob.Write((uint) 0);
				w_mob.Write(uint.Parse(vScoutX.Text));
				w_mob.Write(uint.Parse(vScoutY.Text));
				w_mob.Write(Single.Parse(vScoutOfsX.Text));
				w_mob.Write(Single.Parse(vScoutOfsY.Text));
				w_mob.Write(int.Parse(vScoutJP.Text));
				w_mob.Write((uint) 0);
				w_mob.Write(filler);
			}

			// Post-structure
			if (!pScoutPoint.Checked)
				Helper.GetComp2Ex(w_mob, 0x14);
			else
				Helper.GetComp2Ex(w_mob, 0x1E);

			//w_mob.Write((uint)0x02);
			//w_mob.Write((uint)0x0FFFFF);
			//w_mob.Write((uint)0x00);
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
			int tot_size = num_ents*8; // bytes to read since SARC

			// Load SARC
			SAR_POS_WAY = r_mob.ReadUInt32();

			// Pre-structure: detect num_way
			int bytes_read = 16;
			int num_way = r_mob.ReadInt32();
			r_mob.ReadBytes(12); // skip past entries that are zeroed out

			// Load waypoint info
			for (int i = 0; i < num_way; i++)
			{
				Helper.WaypointInfo w_loaded = Helper.LoadWaypoint(r_mob);
				bytes_read += 64;

				NPC_WAYPOINTS.Add(w_loaded);
				vWaypoints.Items.Add("(" + w_loaded.X.ToString() + ", " + w_loaded.Y.ToString() + "); #" + w_loaded.anim1 + ";#" + w_loaded.anim2 + ";#" + w_loaded.anim3 + ";#" + w_loaded.anim4 + ";#" + w_loaded.anim5 + ";#" + w_loaded.anim6 + ";#" +
									w_loaded.anim7 + ";#" + w_loaded.anim8 + "; ROT=" + w_loaded.Rotation + "; DELAY=" + w_loaded.delay);
			}

			// Attempt to predict extra structure overload and skip it
			int bytes_to_skip = tot_size - bytes_read;
			if (bytes_to_skip > 0)
				for (int k = 0; k < bytes_to_skip; k++)
					r_mob.ReadByte();

			// Skip past the post-structure
			int post_struct_idx = r_mob.ReadInt32();

			for (int j = 0; j < post_struct_idx; j++)
				r_mob.ReadInt32();
		}

		private void pReach_CheckedChanged(object sender, EventArgs e)
		{
			vReach.Enabled = pReach.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 317, vReach.Enabled);
		}

		private void pRotation_CheckedChanged(object sender, EventArgs e)
		{
			vRotation.Enabled = pRotation.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 33, vRotation.Enabled);
		}

		private void btnChgGUID_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show(
					"Are you sure you want to assign a new GUID to the current mobile object?\n\nHINT: This may be used to duplicate a mobile object.\nNOTE: Don't duplicate NPC and containers with inventory! This may have unpredictable results in the game!",
					"Please confirm GUID modification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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

		private void btnWayAdd_Click(object sender, EventArgs e)
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
				MessageBox.Show("Error defining waypoint parameters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Add a WaypointInfo structure to the array
			NPC_WAYPOINTS.Add(Helper.CreateWaypoint(uint.Parse(vWayX.Text), uint.Parse(vWayY.Text), byte.Parse(vWayAnim1.Text), byte.Parse(vWayAnim2.Text), byte.Parse(vWayAnim3.Text), byte.Parse(vWayAnim4.Text), byte.Parse(vWayAnim5.Text),
													byte.Parse(vWayAnim6.Text), byte.Parse(vWayAnim7.Text), byte.Parse(vWayAnim8.Text), float.Parse(vWayRot.Text), uint.Parse(vWayDelay.Text), cAnimWpt.Checked, cRotWpt.Checked, cDelayWpt.Checked));
			vWaypoints.Items.Add("(" + vWayX.Text + ", " + vWayY.Text + "); #" + vWayAnim1.Text + ";#" + vWayAnim2.Text + ";#" + vWayAnim3.Text + ";#" + vWayAnim4.Text + ";#" + vWayAnim5.Text + ";#" + vWayAnim6.Text + ";#" + vWayAnim7.Text + ";#" +
								vWayAnim8.Text + "; ROT=" + vWayRot.Text + "; DELAY=" + vWayDelay.Text);
		}

		private void btnWayDel_Click(object sender, EventArgs e)
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
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_CFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_CFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_CFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_CFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_CFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_CFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_CFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_CFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_CFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_CFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_CFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_CFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetSecretDoorFlags()
		{
			uint FLAGS = 0;
			if (v_SDFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_SDFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_SDFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_SDFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_SDFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_SDFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_SDFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_SDFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_SDFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_SDFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_SDFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_SDFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_SDFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (v_SDFlag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (v_SDFlag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (v_SDFlag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (v_SDFlag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (v_SDFlag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (v_SDFlag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (v_SDFlag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (v_SDFlag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (v_SDFlag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (v_SDFlag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (v_SDFlag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (v_SDFlag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (v_SDFlag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (v_SDFlag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);
			if (v_SDFlag27.Checked)
				FLAGS += (uint) Math.Pow(2, 27);
			if (v_SDFlag28.Checked)
				FLAGS += (uint) Math.Pow(2, 28);
			if (v_SDFlag29.Checked)
				FLAGS += (uint) Math.Pow(2, 29);
			if (v_SDFlag30.Checked)
				FLAGS += (uint) Math.Pow(2, 30);
			if (v_SDFlag31.Checked)
				FLAGS += (uint) Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetWeaponFlags()
		{
			uint FLAGS = 0;
			if (v_WFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_WFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_WFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_WFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_WFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_WFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_WFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_WFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_WFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_WFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_WFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_WFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_WFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetSceneryFlags()
		{
			uint FLAGS = 0;
			if (v_SFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_SFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_SFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_SFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_SFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_SFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_SFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_SFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_SFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_SFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_SFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_SFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_SFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);

			return FLAGS;
		}

		private uint GetArmorFlags()
		{
			uint FLAGS = 0;
			if (v_OAFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_OAFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_OAFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_OAFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_OAFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);

			return FLAGS;
		}

		private uint GetNPCFlags()
		{
			uint FLAGS = 0;
			if (v_NFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_NFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_NFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_NFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_NFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_NFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_NFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_NFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_NFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_NFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_NFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_NFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_NFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (v_NFlag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (v_NFlag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (v_NFlag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (v_NFlag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (v_NFlag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (v_NFlag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (v_NFlag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (v_NFlag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (v_NFlag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (v_NFlag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (v_NFlag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (v_NFlag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (v_NFlag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (v_NFlag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);
			if (v_NFlag27.Checked)
				FLAGS += (uint) Math.Pow(2, 27);
			if (v_NFlag28.Checked)
				FLAGS += (uint) Math.Pow(2, 28);
			if (v_NFlag29.Checked)
				FLAGS += (uint) Math.Pow(2, 29);
			if (v_NFlag30.Checked)
				FLAGS += (uint) Math.Pow(2, 30);
			if (v_NFlag31.Checked)
				FLAGS += (uint) Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetItemFlags()
		{
			uint FLAGS = 0;
			if (pItmFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (pItmFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (pItmFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (pItmFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (pItmFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (pItmFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (pItmFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (pItmFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (pItmFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (pItmFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (pItmFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (pItmFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (pItmFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (pItmFlag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (pItmFlag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (pItmFlag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (pItmFlag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (pItmFlag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (pItmFlag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (pItmFlag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (pItmFlag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (pItmFlag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (pItmFlag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (pItmFlag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (pItmFlag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (pItmFlag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (pItmFlag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);

			return FLAGS;
		}

		private uint GetCritterFlags1()
		{
			uint FLAGS = 0;
			if (v_C1Flag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_C1Flag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_C1Flag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_C1Flag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_C1Flag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_C1Flag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_C1Flag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_C1Flag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_C1Flag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_C1Flag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_C1Flag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_C1Flag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_C1Flag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (v_C1Flag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (v_C1Flag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (v_C1Flag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (v_C1Flag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (v_C1Flag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (v_C1Flag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (v_C1Flag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (v_C1Flag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (v_C1Flag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (v_C1Flag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (v_C1Flag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (v_C1Flag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (v_C1Flag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (v_C1Flag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);
			if (v_C1Flag27.Checked)
				FLAGS += (uint) Math.Pow(2, 27);
			if (v_C1Flag28.Checked)
				FLAGS += (uint) Math.Pow(2, 28);
			if (v_C1Flag29.Checked)
				FLAGS += (uint) Math.Pow(2, 29);
			if (v_C1Flag30.Checked)
				FLAGS += (uint) Math.Pow(2, 30);
			if (v_C1Flag31.Checked)
				FLAGS += (uint) Math.Pow(2, 31);

			return FLAGS;
		}

		private uint GetCritterFlags2()
		{
			uint FLAGS = 0;
			if (v_C2Flag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_C2Flag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_C2Flag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_C2Flag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_C2Flag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_C2Flag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_C2Flag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_C2Flag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_C2Flag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_C2Flag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (v_C2Flag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (v_C2Flag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (v_C2Flag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (v_C2Flag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (v_C2Flag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (v_C2Flag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (v_C2Flag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (v_C2Flag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (v_C2Flag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (v_C2Flag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (v_C2Flag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (v_C2Flag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (v_C2Flag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (v_C2Flag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (v_C2Flag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (v_C2Flag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (v_C2Flag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);
			if (v_C2Flag27.Checked)
				FLAGS += (uint) Math.Pow(2, 27);

			return FLAGS;
		}

		private uint GetPortalFlags()
		{
			uint FLAGS = 0;
			if (v_PFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (v_PFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (v_PFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (v_PFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (v_PFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (v_PFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (v_PFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (v_PFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (v_PFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (v_PFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);

			return FLAGS;
		}

		private uint GetObjectFlags()
		{
			uint FLAGS = 0;
			if (pObjFlag00.Checked)
				FLAGS += (uint) Math.Pow(2, 0);
			if (pObjFlag01.Checked)
				FLAGS += (uint) Math.Pow(2, 1);
			if (pObjFlag02.Checked)
				FLAGS += (uint) Math.Pow(2, 2);
			if (pObjFlag03.Checked)
				FLAGS += (uint) Math.Pow(2, 3);
			if (pObjFlag04.Checked)
				FLAGS += (uint) Math.Pow(2, 4);
			if (pObjFlag05.Checked)
				FLAGS += (uint) Math.Pow(2, 5);
			if (pObjFlag06.Checked)
				FLAGS += (uint) Math.Pow(2, 6);
			if (pObjFlag07.Checked)
				FLAGS += (uint) Math.Pow(2, 7);
			if (pObjFlag08.Checked)
				FLAGS += (uint) Math.Pow(2, 8);
			if (pObjFlag09.Checked)
				FLAGS += (uint) Math.Pow(2, 9);
			if (pObjFlag10.Checked)
				FLAGS += (uint) Math.Pow(2, 10);
			if (pObjFlag11.Checked)
				FLAGS += (uint) Math.Pow(2, 11);
			if (pObjFlag12.Checked)
				FLAGS += (uint) Math.Pow(2, 12);
			if (pObjFlag13.Checked)
				FLAGS += (uint) Math.Pow(2, 13);
			if (pObjFlag14.Checked)
				FLAGS += (uint) Math.Pow(2, 14);
			if (pObjFlag15.Checked)
				FLAGS += (uint) Math.Pow(2, 15);
			if (pObjFlag16.Checked)
				FLAGS += (uint) Math.Pow(2, 16);
			if (pObjFlag17.Checked)
				FLAGS += (uint) Math.Pow(2, 17);
			if (pObjFlag18.Checked)
				FLAGS += (uint) Math.Pow(2, 18);
			if (pObjFlag19.Checked)
				FLAGS += (uint) Math.Pow(2, 19);
			if (pObjFlag20.Checked)
				FLAGS += (uint) Math.Pow(2, 20);
			if (pObjFlag21.Checked)
				FLAGS += (uint) Math.Pow(2, 21);
			if (pObjFlag22.Checked)
				FLAGS += (uint) Math.Pow(2, 22);
			if (pObjFlag23.Checked)
				FLAGS += (uint) Math.Pow(2, 23);
			if (pObjFlag24.Checked)
				FLAGS += (uint) Math.Pow(2, 24);
			if (pObjFlag25.Checked)
				FLAGS += (uint) Math.Pow(2, 25);
			if (pObjFlag26.Checked)
				FLAGS += (uint) Math.Pow(2, 26);
			if (pObjFlag27.Checked)
				FLAGS += (uint) Math.Pow(2, 27);
			if (pObjFlag28.Checked)
				FLAGS += (uint) Math.Pow(2, 28);
			if (pObjFlag29.Checked)
				FLAGS += (uint) Math.Pow(2, 29);
			if (pObjFlag30.Checked)
				FLAGS += (uint) Math.Pow(2, 30);
			if (pObjFlag31.Checked)
				FLAGS += (uint) Math.Pow(2, 31);

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

		private void p_OWF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OSCF_CheckedChanged(object sender, EventArgs e)
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

		private void pLockDC_CheckedChanged(object sender, EventArgs e)
		{
			vLockDC.Enabled = pLockDC.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 103, vLockDC.Enabled);
		}

		private void pInvSlot_CheckedChanged(object sender, EventArgs e)
		{
			vInvSlot.Enabled = pInvSlot.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 156, vInvSlot.Enabled);
		}

		private void pParent_CheckedChanged(object sender, EventArgs e)
		{
			vParent.Enabled = pParent.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 152, vParent.Enabled);
		}

		private void pModelScale_CheckedChanged(object sender, EventArgs e)
		{
			vModelScale.Enabled = pModelScale.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 7, vModelScale.Enabled);
		}

		private void vParent_Click(object sender, EventArgs e)
		{
			var linker = new LinkMOB();
			if (linker.ShowDialog() == DialogResult.OK)
			{
				tParent.Text = linker.GUID;
				MOB_PROP_152 = linker.LinkGUID;
			}
		}

		private void pObjFlags_CheckedChanged(object sender, EventArgs e)
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

		private void p_OCOF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OSDF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OPF_CheckedChanged(object sender, EventArgs e)
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

		private void p_ONF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OIF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OCF_CheckedChanged(object sender, EventArgs e)
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

		private void p_OCF2_CheckedChanged(object sender, EventArgs e)
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

		private void p_OARF_CheckedChanged(object sender, EventArgs e)
		{
			v_OAFlag00.Enabled = p_OARF.Checked;
			v_OAFlag01.Enabled = p_OARF.Checked;
			v_OAFlag02.Enabled = p_OARF.Checked;
			v_OAFlag03.Enabled = p_OARF.Checked;
			v_OAFlag04.Enabled = p_OARF.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 219, p_OARF.Checked);
		}

		private void pInvenSource_CheckedChanged(object sender, EventArgs e)
		{
			vInvenSource.Enabled = pInvenSource.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 107, vInvenSource.Enabled);
		}

		private void pChestInv_CheckedChanged(object sender, EventArgs e)
		{
			if (!LOADING)
			{
				if (pChestInv.Checked && MobType.Text != "obj_t_container")
				{
					MessageBox.Show("You can't define the container inventory for an object of this type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void btnRemoveChestInv_Click(object sender, EventArgs e)
		{
			if (vChestInv.SelectedIndex == -1)
				return;

			if (pChestInvDel.Checked && (sender != null))
			{
				if (MessageBox.Show("Are you sure you want to remove this object from the inventory?\n\nWARNING: This will also delete the associated mobile object file!", "Please confirm removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.No)
					return;
			}

			if (pChestInvDel.Checked)
			{
				string MOB_OBJECT = vChestInv.Items[vChestInv.SelectedIndex].ToString().Split('\t')[4];
				if (File.Exists("Mobiles\\" + MOB_OBJECT + ".mob"))
					File.Delete("Mobiles\\" + MOB_OBJECT + ".mob");
			}

			vChestInv.Items.Remove(vChestInv.Items[vChestInv.SelectedIndex]);

			// R1.2: Save the container
			SaveMOB();
		}

		private void btnAddChestInv2_Click(object sender, EventArgs e)
		{
			var inv_add = new LinkMOB();
			if (inv_add.ShowDialog() == DialogResult.OK)
			{
				string ProtoName = "";
				ProtoName = inv_add.FullString.Split('\t')[inv_add.FullString.Split('\t').GetUpperBound(0)];
				ProtoName += "\t\t\t\t" + inv_add.GUID;

				vChestInv.Items.Add(ProtoName);
			}
		}

		private void btnAddChestInv_Click(object sender, EventArgs e)
		{
			// Add a new item from proto
			if (ChestInvProtos.SelectedIndex == -1)
				return;

			string objtype = Proto_Types[ChestInvProtos.SelectedItem].ToString();
			if (objtype == "obj_t_portal" || objtype == "obj_t_container" || objtype == "obj_t_scenery" || objtype == "obj_t_projectile")
			{
				MessageBox.Show("The object of this type can't be added to a container!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			var ITEM_GUID_BYTES = new byte[24];
			Helper.MOB_GenerateGUID(out ITEM_GUID, out ITEM_GUID_BYTES);
			ProtoName += "\t\t\t\t" + ITEM_GUID;

			var mob = new FileStream("Mobiles\\" + ITEM_GUID + ".mob", FileMode.Create);
			var w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(ChestInvProtos.Text.Split('#')[1]);

			int ITEM_INDEX_TO_MOBTYPE = MobType.Items.IndexOf(Proto_Types[ChestInvProtos.Items[ChestInvProtos.SelectedIndex]].ToString());
			string ITEM_TYPE = MobType.Items[ITEM_INDEX_TO_MOBTYPE].ToString();
			string ITEM_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(ITEM_TYPE));

			w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
			w_mob.Write(ITEM_GUID_BYTES);
			w_mob.Write((int) Helper.GEN_GetMobileType(ITEM_TYPE));

			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 0, true); // Location
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 21, true); // Flags
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 152, true); // Parent object back-reference
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 156, true); // Material slot

			if (IS_MONEY)
				ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 230, true); // Money quantity

			w_mob.Write(Helper.MOB_GetNumberOfProperties(ITEM_BITMAP));
			ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(ITEM_BITMAP);
			foreach (object block in BitmapBytes)
				w_mob.Write((byte) block);

			// Write properties
			// obj_f_location
			uint loc_x = uint.Parse(LocationX.Text);
			uint loc_y = uint.Parse(LocationY.Text);
			w_mob.Write((byte) 0x01);
			w_mob.Write(loc_x);
			w_mob.Write(loc_y);
			// obj_f_flags
			w_mob.Write(5172); // Pre-defined flags for inventory object
			// obj_f_item_parent
			w_mob.Write((byte) 0x01);
			w_mob.Write(MOB_GUID_BYTES);
			// obj_f_item_inv_slot
			if (!pChestInvSlot.Checked)
				w_mob.Write(vChestInv.Items.Count);
			else
			{
				w_mob.Write(int.Parse(vChestInvSlot.Text));
				pChestInvSlot.Checked = false;
			}
			// obj_f_money_quantity
			if (IS_MONEY)
				w_mob.Write(uint.Parse(tChestMoneyAmt.Text));

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

		private void btnChestInvGUID_Click(object sender, EventArgs e)
		{
			if (vChestInv.SelectedIndex == -1)
				return;

			MessageBox.Show("Mobile object GUID:\n\n" + vChestInv.Items[vChestInv.SelectedIndex].ToString().Split('\t')[4], "Object GUID", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void pOffsetX_CheckedChanged(object sender, EventArgs e)
		{
			vOffsetX.Enabled = pOffsetX.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 1, vOffsetX.Enabled);
		}

		private void pOffsetY_CheckedChanged(object sender, EventArgs e)
		{
			vOffsetY.Enabled = pOffsetY.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 2, vOffsetY.Enabled);
		}

		private void pOfsZ_CheckedChanged(object sender, EventArgs e)
		{
			vOfsZ.Enabled = pOfsZ.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 53, vOfsZ.Enabled);
		}

		private void pRadius_CheckedChanged(object sender, EventArgs e)
		{
			vRadius.Enabled = pRadius.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 38, vRadius.Enabled);
		}

		private void pSpdWalk_CheckedChanged(object sender, EventArgs e)
		{
			vSpdWalk.Enabled = pSpdWalk.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 34, vSpdWalk.Enabled);
		}

		private void pItemAmt_CheckedChanged(object sender, EventArgs e)
		{
			vItemAmt.Enabled = pItemAmt.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 167, vItemAmt.Enabled);
		}

		private void pSpdRun_CheckedChanged(object sender, EventArgs e)
		{
			vSpdRun.Enabled = pSpdRun.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 35, vSpdRun.Enabled);
		}

		private void pHeight_CheckedChanged(object sender, EventArgs e)
		{
			vHeight.Enabled = pHeight.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 39, vHeight.Enabled);
		}

		private void pMoneyQuantity_CheckedChanged(object sender, EventArgs e)
		{
			vMoneyQuantity.Enabled = pMoneyQuantity.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 230, vHeight.Enabled);
		}

		private void pTeleport_CheckedChanged(object sender, EventArgs e)
		{
			vTeleport.Enabled = pTeleport.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 126, vTeleport.Enabled);
		}

		private void pHP_CheckedChanged(object sender, EventArgs e)
		{
			vHP.Enabled = pHP.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 26, vHP.Enabled);
		}

		private void pACAdj_CheckedChanged(object sender, EventArgs e)
		{
			vACAdj.Enabled = pACAdj.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 220, vACAdj.Enabled);
		}

		private void pFaction_CheckedChanged(object sender, EventArgs e)
		{
			vFaction.Enabled = pFaction.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 362, vFaction.Enabled);
		}

		private void pHPAdj_CheckedChanged(object sender, EventArgs e)
		{
			vHPAdj.Enabled = pHPAdj.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 27, vHPAdj.Enabled);
		}

		private void pHPDmg_CheckedChanged(object sender, EventArgs e)
		{
			vHPDmg.Enabled = pHPDmg.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 28, vHPDmg.Enabled);
		}

		// + NPC Inventory functions +
		private void pNpcInv_CheckedChanged(object sender, EventArgs e)
		{
			if (!LOADING)
			{
				if (pNpcInv.Checked && MobType.Text != "obj_t_critter" && MobType.Text != "obj_t_npc")
				{
					MessageBox.Show("You can't define the NPC inventory for an object of this type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

		private void pWaypoints_CheckedChanged(object sender, EventArgs e)
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

		private void btnNpcInvGUID_Click(object sender, EventArgs e)
		{
			if (vNpcInv.SelectedIndex == -1)
				return;

			MessageBox.Show("Mobile object GUID:\n\n" + vNpcInv.Items[vNpcInv.SelectedIndex].ToString().Split('\t')[4], "Object GUID", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnRemoveNpcInv_Click(object sender, EventArgs e)
		{
			if (vNpcInv.SelectedIndex == -1)
				return;

			if (pNpcInvDel.Checked && (sender != null))
			{
				if (MessageBox.Show("Are you sure you want to remove this object from the inventory?\n\nWARNING: This will also delete the associated mobile object file!", "Please confirm removing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
					DialogResult.No)
					return;
			}

			if (pNpcInvDel.Checked)
			{
				string MOB_OBJECT = vNpcInv.Items[vNpcInv.SelectedIndex].ToString().Split('\t')[4];
				if (File.Exists("Mobiles\\" + MOB_OBJECT + ".mob"))
					File.Delete("Mobiles\\" + MOB_OBJECT + ".mob");
			}

			vNpcInv.Items.Remove(vNpcInv.Items[vNpcInv.SelectedIndex]);

			// R1.2: Save the MOB
			SaveMOB();
		}

		private void btnAddNpcInv2_Click(object sender, EventArgs e)
		{
			var inv_add = new LinkMOB();
			if (inv_add.ShowDialog() == DialogResult.OK)
			{
				string ProtoName = "";
				ProtoName = inv_add.FullString.Split('\t')[inv_add.FullString.Split('\t').GetUpperBound(0)];
				ProtoName += "\t\t\t\t" + inv_add.GUID;

				vNpcInv.Items.Add(ProtoName);
			}
		}

		private void btnAddNpcInv_Click(object sender, EventArgs e)
		{
			// Add a new item from proto
			if (NpcInvProtos.SelectedIndex == -1)
				return;

			string objtype = Proto_Types[NpcInvProtos.SelectedItem].ToString();
			if (objtype == "obj_t_portal" || objtype == "obj_t_container" || objtype == "obj_t_scenery" || objtype == "obj_t_projectile")
			{
				MessageBox.Show("The object of this type can't be added to a NPC inventory!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
			var ITEM_GUID_BYTES = new byte[24];
			Helper.MOB_GenerateGUID(out ITEM_GUID, out ITEM_GUID_BYTES);
			ProtoName += "\t\t\t\t" + ITEM_GUID;

			var mob = new FileStream("Mobiles\\" + ITEM_GUID + ".mob", FileMode.Create);
			var w_mob = new BinaryWriter(mob);

			Int16 proto = Int16.Parse(NpcInvProtos.Text.Split('#')[1]);

			int ITEM_INDEX_TO_MOBTYPE = MobType.Items.IndexOf(Proto_Types[NpcInvProtos.Items[NpcInvProtos.SelectedIndex]].ToString());
			string ITEM_TYPE = MobType.Items[ITEM_INDEX_TO_MOBTYPE].ToString();
			string ITEM_BITMAP = Helper.MOB_CreateBitmap(Helper.GEN_GetMobileType(ITEM_TYPE));

			w_mob.Write(Helper.MOB_ReturnHeader(proto, true, /*chkObjIDGen.Checked*/ true));
			w_mob.Write(ITEM_GUID_BYTES);
			w_mob.Write((int) Helper.GEN_GetMobileType(ITEM_TYPE));

			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 0, true); // Location
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 21, true); // Flags
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 152, true); // Parent object back-reference
			ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 156, true); // Material slot

			if (IS_MONEY)
				ITEM_BITMAP = Helper.MOB_ModifyProperty(ITEM_BITMAP, 230, true); // Money quantity

			w_mob.Write(Helper.MOB_GetNumberOfProperties(ITEM_BITMAP));
			ArrayList BitmapBytes = Helper.MOB_BitmapToBytes(ITEM_BITMAP);
			foreach (object block in BitmapBytes)
				w_mob.Write((byte) block);

			// Write properties
			// obj_f_location
			uint loc_x = uint.Parse(LocationX.Text);
			uint loc_y = uint.Parse(LocationY.Text);
			w_mob.Write((byte) 0x01);
			w_mob.Write(loc_x);
			w_mob.Write(loc_y);
			// obj_f_flags
			w_mob.Write(5172); // Pre-defined flags for inventory object
			// obj_f_item_parent
			w_mob.Write((byte) 0x01);
			w_mob.Write(MOB_GUID_BYTES);
			// obj_f_item_inv_slot
			if (!pNpcInvSlot.Checked)
				w_mob.Write(vNpcInv.Items.Count);
			else
			{
				w_mob.Write(int.Parse(vNpcInvSlot.Text));
				pNpcInvSlot.Checked = false;
			}
			// obj_f_money_quantity
			if (IS_MONEY)
				w_mob.Write(uint.Parse(tNpcMoneyAmt.Text));

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

		private void pNpcInvenSource_CheckedChanged(object sender, EventArgs e)
		{
			if (NPC_INVENSOURCE_CALLBACK)
			{
				NPC_INVENSOURCE_CALLBACK = false;
				return;
			}

			if (MobType.Text != "obj_t_npc")
			{
				MessageBox.Show("This is not a NPC! You can't set this property for non-NPC objects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				NPC_INVENSOURCE_CALLBACK = true;
				pNpcInvenSource.Checked = false;
			}

			vNpcInvenSource.Enabled = pNpcInvenSource.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 310, vNpcInvenSource.Enabled);
		}

		private void pSubInv_CheckedChanged(object sender, EventArgs e)
		{
			vSubInv.Enabled = pSubInv.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 364, vSubInv.Enabled);
		}

		private void vSubInv_Click(object sender, EventArgs e)
		{
			var linker = new LinkMOB();
			if (linker.ShowDialog() == DialogResult.OK)
			{
				tSubInv.Text = linker.GUID;
				MOB_PROP_SUBINV = linker.LinkGUID;
			}
		}

		private void pNpcInvSlot_CheckedChanged(object sender, EventArgs e)
		{
			vNpcInvSlot.Enabled = pNpcInvSlot.Checked;
		}

		private void pMoneyIdx_CheckedChanged(object sender, EventArgs e)
		{
			vMoneyIdx1.Enabled = pMoneyIdx.Checked;
			vMoneyIdx2.Enabled = pMoneyIdx.Checked;
			vMoneyIdx3.Enabled = pMoneyIdx.Checked;
			vMoneyIdx4.Enabled = pMoneyIdx.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 307, vMoneyIdx1.Enabled);
		}

		private void pChestInvSlot_CheckedChanged(object sender, EventArgs e)
		{
			vChestInvSlot.Enabled = pChestInvSlot.Checked;
		}

		private void pDispatcher_CheckedChanged(object sender, EventArgs e)
		{
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 44, pDispatcher.Checked);
		}

		private void pPLockDC_CheckedChanged(object sender, EventArgs e)
		{
			vPLockDC.Enabled = pPLockDC.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 89, pPLockDC.Checked);
		}

		private void pAmmoAmt_CheckedChanged(object sender, EventArgs e)
		{
			vAmmoAmt.Enabled = pAmmoAmt.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 210, pAmmoAmt.Checked);
		}

		private void pSDDC_CheckedChanged(object sender, EventArgs e)
		{
			vSDDC.Enabled = pSDDC.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 48, pSDDC.Checked);
		}

		private void pObjName_CheckedChanged(object sender, EventArgs e)
		{
			vObjName.Enabled = pObjName.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 23, pObjName.Checked);
		}

		private void pEffName_CheckedChanged(object sender, EventArgs e)
		{
			vEffName.Enabled = pEffName.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 47, pEffName.Checked);
		}

		private void pACMaxDex_CheckedChanged(object sender, EventArgs e)
		{
			vACMaxDex.Enabled = pACMaxDex.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 221, pACMaxDex.Checked);
		}

		private void pAI64_CheckedChanged(object sender, EventArgs e)
		{
			vAI64.Enabled = pAI64.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 381, pAI64.Checked);
		}

		private void pTransparency_CheckedChanged(object sender, EventArgs e)
		{
			vTransparency.Enabled = pTransparency.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 6, pTransparency.Checked);
		}

		private void pSpellFail_CheckedChanged(object sender, EventArgs e)
		{
			vSpellFail.Enabled = pSpellFail.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 222, pSpellFail.Checked);
		}

		private void pArmorChk_CheckedChanged(object sender, EventArgs e)
		{
			vArmorChk.Enabled = pArmorChk.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 223, pArmorChk.Checked);
		}

		private void pTeleDest_CheckedChanged(object sender, EventArgs e)
		{
			vTeleX.Enabled = pTeleDest.Checked;
			vTeleY.Enabled = pTeleDest.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 313, pTeleDest.Checked);
		}

		private void pTeleMap_CheckedChanged(object sender, EventArgs e)
		{
			vTeleMap.Enabled = pTeleMap.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 314, pTeleMap.Checked);
		}

		private void pNotify1_CheckedChanged(object sender, EventArgs e)
		{
			vNotify1.Enabled = pNotify1.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 91, pNotify1.Checked);
		}

		private void pNotify2_CheckedChanged(object sender, EventArgs e)
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

		private void pWeight_CheckedChanged(object sender, EventArgs e)
		{
			vWeight.Enabled = pWeight.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 153, pWeight.Checked);
		}

		private void pWorth_CheckedChanged(object sender, EventArgs e)
		{
			vWorth.Enabled = pWorth.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 154, pWorth.Checked);
		}

		private void pPKeyID_CheckedChanged(object sender, EventArgs e)
		{
			vPKeyID.Enabled = pPKeyID.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 90, pPKeyID.Checked);
		}


		private void pLevelup_CheckedChanged(object sender, EventArgs e)
		{
			vLevelup.Enabled = pLevelup.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 319, pLevelup.Checked);
		}

		private void pStandpoints_CheckedChanged(object sender, EventArgs e)
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

		private void pKeyID_CheckedChanged(object sender, EventArgs e)
		{
			vKeyID.Enabled = pKeyID.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 104, pKeyID.Checked);
		}

		private void pKeyID2_CheckedChanged(object sender, EventArgs e)
		{
			vKeyID2.Enabled = pKeyID2.Checked;
			MOB_BITMAP = Helper.MOB_ModifyProperty(MOB_BITMAP, 255, pKeyID2.Checked);
		}

		// EMBED IN SECTORS
		private void btnEmbed_Click(object sender, EventArgs e)
		{
			if (MobType.Text != "obj_t_scenery" &&
				MobType.Text != "obj_t_portal" &&
				MobType.Text != "obj_t_projectile" /*UNKNOWN*/&&
				MobType.Text != "obj_t_trap")
			{
				MessageBox.Show("Objects of the chosen type (" + MobType.Text + ") should not be embedded into sectors!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// FIX: BETA R1.1
			Helper.SectorName = Helper.SEC_GetSectorCorrespondence(int.Parse(LocationX.Text), int.Parse(LocationY.Text)).ToString() + ".sec";
			var e_sect = new EmbedInSector();
			if (e_sect.ShowDialog() == DialogResult.OK)
			{
				// Error: no file was ever specified
				if (e_sect.FileName == "")
					return;

				// If the sector doesn't exist yet, create an empty one
				if (!File.Exists(e_sect.FileName))
				{
					var w_sec = new BinaryWriter(new FileStream(e_sect.FileName, FileMode.Create));
					Helper.SEC_CreateEmptySectorFile(w_sec);
					w_sec.Close();
				}

				// Phase 1: save the temporary object file
				string tempobj = Path.GetDirectoryName(Application.ExecutablePath) + "\\temp.obj";
				__MOB_OVERRIDE_NAME = tempobj;
				Helper.EmbedMode = true; // R1.3: Embed mode to set guid type 0x00
				SaveMOB();

				// Phase 2: Find out the total number of objects in the sector file
				uint CURRENT_NUM_OF_OBJS;
				var r_obj0 = new BinaryReader(new FileStream(e_sect.FileName, FileMode.Open));
				r_obj0.BaseStream.Seek(-4, SeekOrigin.End);
				CURRENT_NUM_OF_OBJS = r_obj0.ReadUInt32();
				r_obj0.Close();
				CURRENT_NUM_OF_OBJS++; // increase the number of object entries

				// Phase 3: write the temporary object data to the sector file
				var r_obj = new BinaryReader(new FileStream(tempobj, FileMode.Open));
				var w_embed = new BinaryWriter(new FileStream(e_sect.FileName, FileMode.Open));
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

			var wp = (Helper.WaypointInfo) NPC_WAYPOINTS[vWaypoints.SelectedIndex];
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

			var inv = new ListInvenSource();
			if (inv.ShowDialog() == DialogResult.OK)
			{
				// add items here
				foreach (string item in inv.ITEMS)
				{
					string proto = "#" + item.Split(',')[0];
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

			var inv = new ListInvenSource();
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
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 0);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 0);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate2_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 1);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 1);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate3_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 2);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 2);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate4_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 3);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 3);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate5_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 4);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 4);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate6_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 5);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 5);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate7_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 6);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 6);
				SetNPCFlags(flags);
			}
		}

		private void vNPCGRate8_CheckedChanged(object sender, EventArgs e)
		{
			if (p_ONF.Checked)
			{
				uint flags = GetNPCFlags();
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 7);
				SetNPCFlags(flags);
			}
			else
			{
				p_ONF.Checked = true;
				uint flags = 0;
				flags = (uint) Helper.MAKE_NPCGEN((int) flags, 7);
				SetNPCFlags(flags);
			}
		}

		#endregion

		#region Map Splitter/Recombiner

		private void button2_Click(object sender, EventArgs e)
		{
			int MX = 0; // Max X coord
			int MY = 0; // Max Y coord
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
				if (
					MessageBox.Show(
						"Warning: the number of files in chosen folder is big. Even though recombination of this map is possible, you may run out of memory later when you will want to split your map. You may consider PARTIAL RECOMBINING (advanced) instead of FULL RECOMBINING in order to reduce the size of the combined bitmap.\n\nAre you sure you want to proceed with COMPLETE RECOMBINING?",
						"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
				int X = int.Parse(SX, NumberStyles.HexNumber);
				int Y = int.Parse(SY, NumberStyles.HexNumber);

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
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
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

				int X = int.Parse(SX, NumberStyles.HexNumber);
				int Y = int.Parse(SY, NumberStyles.HexNumber);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: " + m_path + ".jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int SX = 0; // Starting X coord
			int SY = 0; // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;

			// Load the big canvas
			var blt = new Bitmap(OFG1.FileName);
			//Graphics g_blt = Graphics.FromImage(blt);

			// Get the number of constituents
			int X_AMOUNT = blt.Width/256;
			int Y_AMOUNT = blt.Height/256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
			{
				var sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
				SX = int.Parse(sr.ReadLine());
				SY = int.Parse(sr.ReadLine());
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
					file = j.ToString("X").PadLeft(4, '0') + i.ToString("X").PadLeft(4, '0') + ".jpg";
					tmp = new Bitmap(256, 256);
					Graphics g_tmp = Graphics.FromImage(tmp);
					g_tmp.DrawImage(blt, 0, 0, new Rectangle(256*(i - SY), 256*(j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Jpeg);
				}

			MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Split minimap
		private void button3_Click(object sender, EventArgs e)
		{
			// I. Split the 4's

			int SX = 0; // Starting X coord
			int SY = 0; // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;

			string modifier = Path.GetFileNameWithoutExtension(OFG1.FileName).Substring(Path.GetFileNameWithoutExtension(OFG1.FileName).Length - 2);

			if (modifier != "_4" && modifier != "_8")
			{
				MessageBox.Show("Invalid JPEG source specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Load the big canvas
			var blt = new Bitmap(OFG1.FileName);

			// Get the number of constituents
			int X_AMOUNT = blt.Width/256;
			int Y_AMOUNT = blt.Height/256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
			{
				var sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
				SX = int.Parse(sr.ReadLine());
				SY = int.Parse(sr.ReadLine());
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
					file = (modifier == "_4") ? "z4" + j.ToString().PadLeft(3, '0') + i.ToString().PadLeft(3, '0') + ".jpg" : "z8" + j.ToString().PadLeft(3, '0') + i.ToString().PadLeft(3, '0') + ".jpg";
					tmp = new Bitmap(256, 256);
					Graphics g_tmp = Graphics.FromImage(tmp);
					g_tmp.DrawImage(blt, 0, 0, new Rectangle(256*(i - SY), 256*(j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Jpeg);
				}

			MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Recombine minimap
		private void button4_Click(object sender, EventArgs e)
		{
			// I. Recombine 4's

			int MX = 0; // Max X coord
			int MY = 0; // Max Y coord
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
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

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
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			Bitmap tmp;
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: " + m_path + "_4.jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// II. Recombine 8's

			MX = 0; // Max X coord
			MY = 0; // Max Y coord
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
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

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
			Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			g_Blt = Graphics.FromImage(Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_8.jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: " + m_path + "_8.jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void recomb_partial_Click(object sender, EventArgs e)
		{
			int LX = int.Parse(SX.Text); // Min X coord
			int LY = int.Parse(SY.Text); // Min Y coord
			int MX = LX + int.Parse(PX.Text) - 1; // Max X coord
			int MY = LY + int.Parse(PY.Text) - 1; // Max Y coord

			if (OFG.ShowDialog() == DialogResult.Cancel)
				return;

			// Phase 1. Make a list of JPEGs
			string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "????????.jpg");
			string last_path = Path.GetDirectoryName(files[0]);
			string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);

			// Save the restoration data
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
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
					int X = int.Parse(_SX, NumberStyles.HexNumber);
					int Y = int.Parse(_SY, NumberStyles.HexNumber);

					tmp = (Bitmap) Image.FromFile(file);
					g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error recombining the map partially: \n\n" + ex.Message + "\n\nPossibly the specified map block does not exist or not all files were found for the specified block.", "Error", MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				return;
			}

			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".jpg", ImageFormat.Jpeg);
			MessageBox.Show("Built a combined image: " + m_path + ".jpg", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			int SX = 0; // Starting X coord
			int SY = 0; // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;

			// Load the big canvas
			var blt = new Bitmap(OFG1.FileName);
			//Graphics g_blt = Graphics.FromImage(blt);

			// Get the number of constituents
			int X_AMOUNT = blt.Width/256;
			int Y_AMOUNT = blt.Height/256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
			{
				var sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
				SX = int.Parse(sr.ReadLine());
				SY = int.Parse(sr.ReadLine());
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
					Graphics g_tmp = Graphics.FromImage(tmp);
					g_tmp.DrawImage(blt, 0, 0, new Rectangle(256*(i - SY), 256*(j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Bmp);
				}

			MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			int MX = 0; // Max X coord
			int MY = 0; // Max Y coord
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
				if (
					MessageBox.Show(
						"Warning: the number of files in chosen folder is big. Even though recombination of this map is possible, you may run out of memory later when you will want to split your map. You may consider PARTIAL RECOMBINING (advanced) instead of FULL RECOMBINING in order to reduce the size of the combined bitmap.\n\nAre you sure you want to proceed with COMPLETE RECOMBINING?",
						"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
				int X = int.Parse(SX, NumberStyles.HexNumber);
				int Y = int.Parse(SY, NumberStyles.HexNumber);

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
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
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

				int X = int.Parse(SX, NumberStyles.HexNumber);
				int Y = int.Parse(SY, NumberStyles.HexNumber);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".bmp", ImageFormat.Bmp);
			MessageBox.Show("Built a combined image: " + m_path + ".bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button7_Click(object sender, EventArgs e)
		{
			int LX = int.Parse(SX.Text); // Min X coord
			int LY = int.Parse(SY.Text); // Min Y coord
			int MX = LX + int.Parse(PX.Text) - 1; // Max X coord
			int MY = LY + int.Parse(PY.Text) - 1; // Max Y coord

			if (OFG.ShowDialog() == DialogResult.Cancel)
				return;

			// Phase 1. Make a list of JPEGs
			string[] files = Directory.GetFiles(Path.GetDirectoryName(OFG.FileName), "????????.jpg");
			string last_path = Path.GetDirectoryName(files[0]);
			string m_path = last_path.Substring(last_path.LastIndexOf("\\") + 1);

			// Save the restoration data
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
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
					int X = int.Parse(_SX, NumberStyles.HexNumber);
					int Y = int.Parse(_SY, NumberStyles.HexNumber);

					tmp = (Bitmap) Image.FromFile(file);
					g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("There was an error recombining the map partially: \n\n" + ex.Message + "\n\nPossibly the specified map block does not exist or not all files were found for the specified block.", "Error", MessageBoxButtons.OK,
								MessageBoxIcon.Error);
				return;
			}

			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + ".bmp", ImageFormat.Bmp);
			MessageBox.Show("Built a combined image: " + m_path + ".bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button8_Click(object sender, EventArgs e)
		{
			// I. Split the 4's

			int SX = 0; // Starting X coord
			int SY = 0; // Starting Y coord

			if (OFG1.ShowDialog() == DialogResult.Cancel)
				return;

			string modifier = Path.GetFileNameWithoutExtension(OFG1.FileName).Substring(Path.GetFileNameWithoutExtension(OFG1.FileName).Length - 2);

			if (modifier != "_4" && modifier != "_8")
			{
				MessageBox.Show("Invalid source specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Load the big canvas
			var blt = new Bitmap(OFG1.FileName);

			// Get the number of constituents
			int X_AMOUNT = blt.Width/256;
			int Y_AMOUNT = blt.Height/256;

			// Load up the SX/XY pair, if possible. Otherwise assume (0;0).
			if (File.Exists(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt"))
			{
				var sr = new StreamReader(Path.GetFileNameWithoutExtension(OFG1.FileName) + ".txt");
				SX = int.Parse(sr.ReadLine());
				SY = int.Parse(sr.ReadLine());
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
					Graphics g_tmp = Graphics.FromImage(tmp);
					g_tmp.DrawImage(blt, 0, 0, new Rectangle(256*(i - SY), 256*(j - SX), 256, 256), GraphicsUnit.Pixel);
					tmp.Save(Path.GetFileNameWithoutExtension(OFG1.FileName) + "\\" + file, ImageFormat.Bmp);
				}

			MessageBox.Show("Splitting complete.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void button9_Click(object sender, EventArgs e)
		{
			// I. Recombine 4's

			int MX = 0; // Max X coord
			int MY = 0; // Max Y coord
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
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

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
			var f_out = new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.txt", FileMode.Create);
			var sw = new StreamWriter(f_out);
			sw.WriteLine(LX.ToString());
			sw.WriteLine(LY.ToString());
			sw.Close();
			f_out.Close();

			// Phase 3. Create the canvas
			var Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			Graphics g_Blt = Graphics.FromImage(Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			Bitmap tmp;
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_4.bmp", ImageFormat.Bmp);
			MessageBox.Show("Built a combined image: " + m_path + "_4.bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

			// II. Recombine 8's

			MX = 0; // Max X coord
			MY = 0; // Max Y coord
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
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

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
			Blt = new Bitmap(256*(MY - LY + 1), 256*(MX - LX + 1));
			g_Blt = Graphics.FromImage(Blt);
			g_Blt.FillRectangle(new SolidBrush(Color.Black), 0, 0, Blt.Width, Blt.Height);

			// Phase 4. Fill the canvas
			foreach (string file in files)
			{
				string abs = Path.GetFileNameWithoutExtension(file);
				string SX = abs.Substring(2, 3);
				string SY = abs.Substring(5, 3);
				int X = int.Parse(SX);
				int Y = int.Parse(SY);

				tmp = (Bitmap) Image.FromFile(file);
				g_Blt.DrawImage(tmp, 256*(Y - LY), 256*(X - LX));
			}
			Blt.Save(Path.GetDirectoryName(Application.ExecutablePath) + "\\2D Maps\\" + m_path + "_8.bmp", ImageFormat.Bmp);
			MessageBox.Show("Built a combined image: " + m_path + "_8.bmp", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Configuration

		private void btnSaveCfg_Click(object sender, EventArgs e)
		{
			var cfg = new StreamWriter(new FileStream(Path.GetDirectoryName(Application.ExecutablePath) + "\\ToEE World Builder.ini", FileMode.Create));
			cfg.WriteLine(tDialogEd.Text);
			cfg.WriteLine(tScriptEd.Text);
			cfg.WriteLine(tDialogs.Text);
			cfg.WriteLine(tScripts.Text);
			cfg.WriteLine(cfgDelEmpty.Checked.ToString());
			cfg.WriteLine(chkObjIDGen.Checked.ToString());
			cfg.WriteLine(tWBBridge.Text);
			cfg.Close();
			MessageBox.Show("Configuration saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (cfgBrowser.ShowDialog() == DialogResult.OK)
				tDialogEd.Text = cfgBrowser.FileName;
		}

		private void btnBrowse2_Click(object sender, EventArgs e)
		{
			if (cfgBrowser.ShowDialog() == DialogResult.OK)
				tScriptEd.Text = cfgBrowser.FileName;
		}

		private void btnBrowse3_Click(object sender, EventArgs e)
		{
			if (cfgDialogs.ShowDialog() == DialogResult.OK)
				tDialogs.Text = Path.GetDirectoryName(cfgDialogs.FileName);
		}

		private void btnBrowse4_Click(object sender, EventArgs e)
		{
			if (cfgScripts.ShowDialog() == DialogResult.OK)
				tScripts.Text = Path.GetDirectoryName(cfgScripts.FileName);
		}

		#endregion

		#region Dialog Editor Interface

		private void btnLoadDialogs_Click(object sender, EventArgs e)
		{
			if (tDialogs.Text == "")
			{
				MessageBox.Show("The dialog folder is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			lstDialogs.Items.Clear();
			string[] Dialogs = Directory.GetFiles(tDialogs.Text, "*.dlg");

			foreach (string DLG in Dialogs)
			{
				string filename = Path.GetFileNameWithoutExtension(DLG);
				string ID = filename.Substring(0, 5);
				string NAME = filename.Substring(5);

				lstDialogs.Items.Add(ID + "\t" + NAME);
			}
		}

		private void btnDelDialog_Click(object sender, EventArgs e)
		{
			if (lstDialogs.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this dialog permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] file_items = lstDialogs.Items[lstDialogs.SelectedIndex].ToString().Split('\t');
			string filename = file_items[0] + file_items[1];
			File.Delete(tDialogs.Text + "\\" + filename + ".dlg");
			lstDialogs.Items.Remove(lstDialogs.Items[lstDialogs.SelectedIndex]);
		}

		private void btnEditDialog_Click(object sender, EventArgs e)
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

			Process.Start(tDialogEd.Text, tDialogs.Text + "\\" + filename);
		}

		#endregion

		#region Script Editor Interface

		private void btnLoadScripts_Click(object sender, EventArgs e)
		{
			if (tScripts.Text == "")
			{
				MessageBox.Show("The script folder is not specified. Please edit the editor configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			lstScripts.Items.Clear();
			string[] Scripts = Directory.GetFiles(tScripts.Text, "py*.py");

			foreach (string PY in Scripts)
			{
				string filename = Path.GetFileNameWithoutExtension(PY);
				string ID = filename.Substring(2, 5);
				string NAME = filename.Substring(7);

				lstScripts.Items.Add(ID + "\t" + NAME);
			}
		}

		private void btnEditScript_Click(object sender, EventArgs e)
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

			Process.Start(tScriptEd.Text, tScripts.Text + "\\" + filename);
		}

		private void btnDelScript_Click(object sender, EventArgs e)
		{
			if (lstScripts.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this script permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string[] file_items = lstScripts.Items[lstScripts.SelectedIndex].ToString().Split('\t');
			string filename = file_items[0] + file_items[1];
			File.Delete(tScripts.Text + "\\" + "py" + filename + ".py");
			lstScripts.Items.Remove(lstScripts.Items[lstScripts.SelectedIndex]);
		}

		#endregion

		#region Help

		// Special NPC inventory slots
		private void menuItem4_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Normally when you add an item to the NPC inventory you assign it as a loot, the NPC does not wear this item by default. You can use the following special inventory slots to make NPCs wear different items (armor, weapons, etc.):\n\n200 - Helmet\n201 - Necklace\n202 - Gloves\n203 - Primary Weapon\n204 - Secondary Weapon\n205 - Armor\n206 - Primary Ring\n207 - Secondary Ring\n208 - Boots\n209 - Ammo\n210 - Cloak\n211 - Shield\n212 - Robe\n213 - Bracers\n214 - Bardic Item\n215 - Lockpicks",
				"Mobile Objects: Special NPC Inventory Slots", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// About box
		private void menuItem6_Click(object sender, EventArgs e)
		{
			var a = new AboutForm();
			a.ShowDialog();
		}

		// Creating merchants
		private void menuItem7_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"In order to create a merchant, you need to create a dummy invisible container that will serve as a merchant's inventory, and then link it with the merchant itself. You can follow the following basic tutorial to learn this trick:\n\n1) Go to the \"Objects\" tab and create a new mobile object.\n2) Set the prototype to Tutorial Chest A (#1048). The coordinates don't matter.\n3) Add some items to the container inventory. These objects will be sold by the merchant in the future.\n4) Set the object flags OF_DONTDRAW, OF_INVISIBLE, OF_NO_BLOCK, and OF_DYNAMIC. This is essential.\n5) Save the container.\n6) Create a new mobile object and set it to be Blacksmith (#14010). Set its coordinates.\n7) Go to the NPC/Critters tab and set the \"Substitute inventory\" flag.\n8) Click on \"Define\" and select your Tutorial Chest A from the list to link it.\n9) Save your blacksmith MOB.\n10) Enjoy!\n\nNote that your Blacksmith NPC will be naked, so you'll need to set his \"loot\" inventory and assign some items from there to the NPC worn items as well (see the help topic about the special NPC inventory slots to learn how to do this).\n\nVERY IMPORTANT NOTE: You NEED to save your container/NPC every time you ADD or DELETE an item from it! If you forget to do it, the editor may corrupt all the data in your container/NPC file!",
				"Creating a NPC Merchant", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Creating respawnable inv merchants
		private void menuItem11_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"Creating a merchant with a respawnable inventory is not much harder than creating a generic merchant. Follow the basic tutorial to create a merchant (but **DON'T** set the OF_DYNAMIC flag for the substitute inventory container! This flag shouldn't be set for merchants with respawnable inventory!), but observe the following rules in addition to the ones mentioned in that tutorial:\n\n1) The merchant and its substitute inventory container must be CLOSE to each other. For example, if the merchant himself has the coordinates (505, 457), the substitute inventory container can be assigned the (509, 457) coordinates or something like that.\n2) An inventory source must be set for the substitute inventory container. It should correspond to the ID in INVENSOURCE.MES from which to respawn the inventory.\n\nEnjoy!\nRemember: for a merchant to respawn his inventory, you must rest (not wait!) 24 hours, presumably on the same map where the merchant is set, outside the 800x600 area where the merchant is! Otherwise, you won't see the inventory respawn!",
				"Mobile Objects - Respawnable Inventories", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Modifying rest options for maps
		private void menuItem12_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"You can control the resting options for all maps in the game (e.g. on which maps you can rest, on which it is dangerous, and where the resting is impossible or you can only pass time)b.\n\nTo do it, you should modify the RANDOM_ENCOUNTER.PY script file. At the bottom of this file there's a function called CAN_SLEEP. It can return different values depending on the map ID (per MapList.mes):\n\nSLEEP_SAFE - it's safe to sleep in the area\nSLEEP_DANGEROUS - resting may provoke a random encounter\nSLEEP_IMPOSSIBLE - rest is not possible here\nSLEEP_PASS_TIME_ONLY - only passing time is possible",
				"Modifying resting options for maps", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		// Waypoint IDs
		private void commonWaypointAnimationIDsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"The following animation IDs can be used for almost all objects when defining an animated waypoint. An animated waypoint can have up to 8 animations defined. Some waypoint anim ID combinations can be used to achieve some special effect (e.g. a combination of Special Animations #1 for Blacksmith makes him play his 'striking with his hammer' animation). Note that if an object doesn't have an animation that you requested, a substitute animation will be chosen by cascading down to a nearest animation ID that the object has.\n\n0 - No animation\n1 - Special Animation 1\n2 - Special Animation 2\n3 - Special Animation 3\n\nPlease note that not all characters have special animations.\nAlso note that the first slot in waypoint animation HAS to be set to a special animation ID other than 0, otherwise the whole sequence won't work.",
				"Waypoint Animation IDs", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Jump Point Editor

		private string OpenJP = "";
		private int OpenJP_Max;
		private List<string> Data;

		private void btnOpenJP_Click(object sender, EventArgs e)
		{
			MultiODLG.Filter = "Jump point list (jumppoint.tab)|jumppoint.tab";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				OpenJP = MultiODLG.FileName;
				Data = TabReader.Read(MultiODLG.FileName);

				for (int i = 0; i < Data.Count; i++)
				{
					string[] elements = Data[i].Split('\t');
					lstJumpPoints.Items.Add(elements[0] + ": " + elements[1] + " (Map " + elements[2] + " at X=" + elements[3] + ";Y=" + elements[4] + ")");

					if (int.Parse(elements[0]) > OpenJP_Max)
						OpenJP_Max = int.Parse(elements[0]);
				}
			}
		}

		private void btnSaveJP_Click(object sender, EventArgs e)
		{
			if (OpenJP == "")
			{
				MessageBox.Show("No jump point file is open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (MessageBox.Show("Are you sure you want to save the jump points file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var sw = new StreamWriter(new FileStream(OpenJP, FileMode.Create));
			for (int i = 0; i < Data.Count; i++)
				sw.WriteLine(Data[i]);

			sw.Close();

			MessageBox.Show("File saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void lstJumpPoints_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstJumpPoints.SelectedIndex == -1)
				return;

			string[] el = Data[lstJumpPoints.SelectedIndex].ToString().Split('\t');

			JPIndex.Text = el[0];
			JPName.Text = el[1];
			JPMap.Text = el[2];
			JPX.Text = el[3];
			JPY.Text = el[4];
		}

		private void btnDelPoint_Click(object sender, EventArgs e)
		{
			if (lstJumpPoints.SelectedIndex == -1)
				return;

			Data.RemoveAt(lstJumpPoints.SelectedIndex);
			lstJumpPoints.Items.Remove(lstJumpPoints.Items[lstJumpPoints.SelectedIndex]);
		}

		private void btnAddPoint_Click(object sender, EventArgs e)
		{
			if (OpenJP == "")
				return;

			// Check if a jump point already exists
			for (int i = 0; i < Data.Count; i++)
			{
				if (Data[i].ToString().Split('\t')[0] == JPIndex.Text)
				{
					MessageBox.Show("This jump point already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			Data.Add(JPIndex.Text + "\t" + JPName.Text + "\t" + JPMap.Text + "\t" + JPX.Text + "\t" + JPY.Text);
			lstJumpPoints.Items.Add(JPIndex.Text + ": " + JPName.Text + " (Map " + JPMap.Text + " at X=" + JPX.Text + ";Y=" + JPY.Text + ")");
		}

		private void btnUpdatePoint_Click(object sender, EventArgs e)
		{
			if (OpenJP == "")
				return;

			if (lstJumpPoints.SelectedIndex == -1)
				return;

			Data[lstJumpPoints.SelectedIndex] = JPIndex.Text + "\t" + JPName.Text + "\t" + JPMap.Text + "\t" + JPX.Text + "\t" + JPY.Text;
			lstJumpPoints.Items[lstJumpPoints.SelectedIndex] = JPIndex.Text + ": " + JPName.Text + " (Map " + JPMap.Text + " at X=" + JPX.Text + ";Y=" + JPY.Text + ")";
		}

		#endregion

		#region DLL Editor

		private string DLL_Path = "";

		private void btnLoadDLL_Click(object sender, EventArgs e)
		{
			MultiODLG.Filter = "Game library (temple.dll)|temple.dll";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				var fi = new FileInfo(MultiODLG.FileName);
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
				var br = new BinaryReader(new FileStream(MultiODLG.FileName, FileMode.Open));
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

		private void btnSaveDLL_Click(object sender, EventArgs e)
		{
			if (DLL_Path == "")
			{
				MessageBox.Show("Please open the TEMPLE.DLL first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Are you sure you want to save the TEMPLE.DLL?\n\nHINT: You may want to create a backup before you save!", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var bw = new BinaryWriter(new FileStream(DLL_Path, FileMode.Open));

			// PC count
			bw.BaseStream.Seek(0x0002BBEF, SeekOrigin.Begin);
			bw.Write(byte.Parse(PCCount.Text));
			bw.BaseStream.Seek(0x0002BC4F, SeekOrigin.Begin);
			bw.Write((byte) (8 - byte.Parse(PCCount.Text)));
			bw.BaseStream.Seek(0x000B0187, SeekOrigin.Begin);
			bw.Write((byte) (8 - byte.Parse(PCCount.Text)));

			// Area locations
			bw.BaseStream.Seek(0x002ACE40, SeekOrigin.Begin);
			bw.Write(uint.Parse(TrueNeutral.Text));
			bw.BaseStream.Seek(0x002ACE44, SeekOrigin.Begin);
			bw.Write(uint.Parse(LawfulNeutral.Text));
			bw.BaseStream.Seek(0x002ACE48, SeekOrigin.Begin);
			bw.Write(uint.Parse(ChaoticNeutral.Text));
			bw.BaseStream.Seek(0x002ACE50, SeekOrigin.Begin);
			bw.Write(uint.Parse(NeutralGood.Text));
			bw.BaseStream.Seek(0x002ACE54, SeekOrigin.Begin);
			bw.Write(uint.Parse(LawfulGood.Text));
			bw.BaseStream.Seek(0x002ACE58, SeekOrigin.Begin);
			bw.Write(uint.Parse(ChaoticGood.Text));
			bw.BaseStream.Seek(0x002ACE60, SeekOrigin.Begin);
			bw.Write(uint.Parse(NeutralEvil.Text));
			bw.BaseStream.Seek(0x002ACE64, SeekOrigin.Begin);
			bw.Write(uint.Parse(LawfulEvil.Text));
			bw.BaseStream.Seek(0x002ACE68, SeekOrigin.Begin);
			bw.Write(uint.Parse(ChaoticEvil.Text));

			if (chkEnableDebug.Checked)
			{
				bw.BaseStream.Seek(0x001DFECF, SeekOrigin.Begin);
				bw.Write((byte) 0x75);
				bw.BaseStream.Seek(0x001DFEFE, SeekOrigin.Begin);
				bw.Write((byte) 0x75);
			}
			else
			{
				bw.BaseStream.Seek(0x001DFECF, SeekOrigin.Begin);
				bw.Write((byte) 0x74);
				bw.BaseStream.Seek(0x001DFEFE, SeekOrigin.Begin);
				bw.Write((byte) 0x74);
			}

			bw.Close();

			MessageBox.Show("TEMPLE.DLL Saved!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region Prototype Editor

		private void btnSaveProtos_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save all prototypes and descriptions?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Save protos
			var sw = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\protos.tab", false);

			for (int i = 0; i < protos.Count; i++)
				sw.WriteLine(protos[i]);

			sw.Close();

			// Save descriptions
			var sw2 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\description.mes", false);

			for (int i = 0; i < desc.Count; i++)
				sw2.WriteLine(desc[i]);

			sw2.Close();

			// Save long descriptions
			var sw3 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\long_description.mes", false);

			for (int i = 0; i < ldesc.Count; i++)
				sw3.WriteLine(ldesc[i]);

			sw3.Close();

			MessageBox.Show("Prototypes and descriptions saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void CurProto_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Load prototype properties
			lstProtoProps.Items.Clear();
			var columnNames = Prototypes.GetColumnNames();

			// Set proto ID
			tProtoID.Text = CurProto.Items[CurProto.SelectedIndex].ToString().Split('#')[1];

			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int i = 0; i < protos.Count; i++)
			{
				if (protos[i].ToString().Split('\t')[0] == tProtoID.Text)
				{
					protoLine = i;
					break;
				}
			}

			// Read properties from memory
			for (int i = 0; i < columnNames.Length; i++)
				lstProtoProps.Items.Add(columnNames[i] + protos[protoLine].ToString().Split('\t')[i].Replace((char) 0x0B, ' '));
		}

		private void lstProtoProps_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstProtoProps.SelectedIndex == -1)
				return;

			// Set the value field
			tPropValue.Text = lstProtoProps.Items[lstProtoProps.SelectedIndex].ToString().Split('|')[1].Split('\t')[1];
			IntelliProp.Items.Clear();
			var propertiesList = IntelliProperties.Get(lstProtoProps.SelectedIndex);
			if (propertiesList.Length > 0)
				IntelliProp.Items.AddRange(propertiesList);
		}

		private void btnIPInsert_Click(object sender, EventArgs e)
		{
			if (IntelliProp.Items.Count == 0 || IntelliProp.SelectedIndex == -1)
				return;

			if (tPropValue.Text == "")
				tPropValue.Text = IntelliProp.Items[IntelliProp.SelectedIndex].ToString();
			else
				tPropValue.Text += " " + IntelliProp.Items[IntelliProp.SelectedIndex];
		}

		private void btnIPReplace_Click(object sender, EventArgs e)
		{
			if (IntelliProp.Items.Count == 0 || IntelliProp.SelectedIndex == -1)
				return;

			tPropValue.Text = IntelliProp.Items[IntelliProp.SelectedIndex].ToString();
		}

		private void btnUpdateProto_Click(object sender, EventArgs e)
		{
			if (lstProtoProps.SelectedIndex == -1)
				return;

			// Check if a player is about to modify the proto's type and warn him
			if (lstProtoProps.SelectedIndex == 1)
			{
				if (
					MessageBox.Show(
						"Warning: unless you're sure what you are doing, modifying the type directly can have unpredictable results in game mechanics, since the proto ID might get outside the valid range for the new type! Are you sure you want to update the type?",
						"Please confirm dangerous operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
					for (int t = 0; t < lstDesc.Items.Count; t++)
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
						for (int i = 0; i < lstDesc.Items.Count; i++)
						{
							string listidx = lstDesc.Items[i].ToString().Split(':')[0];
							if (lineID <= int.Parse(listidx))
							{
								targetLine = i;
								break;
							}
						}
						if (targetLine == -1)
							lstDesc.Items.Add(tPropValue.Text + ": " + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
						else
							lstDesc.Items.Insert(targetLine, tPropValue.Text + ": " + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));

						targetLine = -1;
						for (int i = 0; i < desc.Count; i++)
						{
							if (desc[i].ToString().Trim() == "")
								continue;

							if (desc[i].ToString().IndexOf("{") != 0)
								continue;

							string listidx = desc[i].ToString().Split('{', '}')[1];
							if (lineID <= int.Parse(listidx))
							{
								// + v1.0: See if there's a comment and an empty line above +
								int j = i;
								if (j > 10)
								{
									if (ldesc[j - 1].ToString().Length > 0)
									{
										if (desc[j - 1].ToString().Substring(0, 1) == "/")
										{
											i--;
											if (desc[j - 2].ToString().Trim() == "")
												i--;
											if (desc[j - 3].ToString().Trim() == "")
												i--;
											if (desc[j - 4].ToString().Trim() == "")
												i--;
											if (desc[j - 5].ToString().Trim() == "")
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
							desc.Add("{" + tPropValue.Text + "}{" + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + "}");
							MessageBox.Show("A new unidentified description line was added: #" + tPropValue.Text, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
						else
						{
							desc.Insert(targetLine, "{" + tPropValue.Text + "}{" + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + "}");
							MessageBox.Show("A new unidentified description line was added: #" + tPropValue.Text, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
					}
				}
			}

			// Set the line value
			lstProtoProps.Items[lstProtoProps.SelectedIndex] = lstProtoProps.Items[lstProtoProps.SelectedIndex].ToString().Split('|')[0] + "|\t" + tPropValue.Text;

			string proto_line = "";
			for (int i = 0; i < 334; i++)
			{
				if (i != 333)
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1] + "\t";
				else
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1];
			}

			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int k = 0; k < protos.Count; k++)
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


		private void btnDelProto_Click(object sender, EventArgs e)
		{
			if (CurProto.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this prototype permanently?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Delete a prototype
			// Get the proto line # from proto ID
			int protoLine = 0;
			for (int k = 0; k < protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					protoLine = k;
					break;
				}
			}

			// Remove the corresponding description
			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().IndexOf(tProtoID.Text + ":") == 0)
				{
					lstDesc.Items.RemoveAt(i);

					// Delete from memory
					for (int j = 0; j < desc.Count; j++)
					{
						if (desc[j].ToString().IndexOf("{" + tProtoID.Text + "}") == 0)
							desc.RemoveAt(j);
					}

					// The same for long descriptions
					for (int l = 0; l < ldesc.Count; l++)
					{
						if (ldesc[l].ToString().IndexOf("{" + tProtoID.Text + "}") == 0)
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

			MessageBox.Show("Prototype deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnAddProto_Click(object sender, EventArgs e)
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
				MessageBox.Show("The prototype identifier for this object type (" + objtype + ") must be between " + minID.ToString() + " and " + maxID.ToString() + "!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Check if the prototype already exists
			bool PROTO_EXISTS = false;
			for (int k = 0; k < protos.Count; k++)
			{
				if (protos[k].ToString().Split('\t')[0] == tProtoID.Text)
				{
					PROTO_EXISTS = true;
					break;
				}
			}

			bool DESC_EXISTS = false;
			for (int l = 0; l < desc.Count; l++)
			{
				if (desc[l].ToString().Trim() == "")
					continue;

				if (desc[l].ToString().IndexOf("{") != 0)
					continue;

				if (desc[l].ToString().Split('{', '}')[1] == tProtoID.Text)
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
			lstProtoProps.Items[23] = lstProtoProps.Items[23].ToString().Split('|')[0] + "|\t" + tProtoID.Text;

			for (int i = 1; i < 334; i++)
			{
				if (i != 333)
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1] + "\t";
				else
					proto_line += lstProtoProps.Items[i].ToString().Split('|')[1].Split('\t')[1];
			}

			int lineID = int.Parse(tProtoID.Text);
			int targetLine = -1;
			for (int i = 0; i < protos.Count; i++)
			{
				if (protos[i].ToString().Trim() == "")
					continue;

				string listidx = protos[i].ToString().Split('\t')[0];
				if (lineID <= int.Parse(listidx))
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

			CurProto.Items.Add(CurProto.Text.Split('#')[0] + "#" + tProtoID.Text);
			CurProto.SelectedItem = CurProto.Text.Split('#')[0] + "#" + tProtoID.Text;
			Prototype.Items.Add(CurProto.Text.Split('#')[0] + "#" + tProtoID.Text);
			ChestInvProtos.Items.Add(CurProto.Text.Split('#')[0] + "#" + tProtoID.Text);
			NpcInvProtos.Items.Add(CurProto.Text.Split('#')[0] + "#" + tProtoID.Text);

			// Add a description
			targetLine = -1;
			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= int.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				lstDesc.Items.Add(tProtoID.Text + ": " + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
			else
				lstDesc.Items.Insert(targetLine, tProtoID.Text + ": " + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));

			targetLine = -1;
			for (int i = 0; i < desc.Count; i++)
			{
				if (desc[i].ToString().Trim() == "")
					continue;

				if (desc[i].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[i].ToString().Split('{', '}')[1];
				if (lineID <= int.Parse(listidx))
				{
					// + v1.0: See if there's a comment and an empty line above +
					int j = i;
					if (j > 10)
					{
						if (desc[j - 1].ToString().Length > 0)
						{
							if (desc[j - 1].ToString().Substring(0, 1) == "/")
								i--;
							if (desc[j - 2].ToString().Trim() == "")
								i--;
							if (desc[j - 3].ToString().Trim() == "")
								i--;
							if (desc[j - 4].ToString().Trim() == "")
								i--;
							if (desc[j - 5].ToString().Trim() == "")
								i--;
						}
					}
					// - v1.0: advanced comment parsing -

					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				desc.Add("{" + tProtoID.Text + "}{" + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + "}");
			else
				desc.Insert(targetLine, "{" + tProtoID.Text + "}{" + CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + "}");

			// OLD WAY OF DOING THINGS, TO BE DELETED
			//lstDesc.Items.Add(tProtoID.Text+": "+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4));
			//desc.Add("{"+tProtoID.Text+"}{"+CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4)+"}");

			// Add a hashtable entry
			if (Proto_Types[CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text] == null)
				Proto_Types.Add(CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text, lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1]);
			else
				Proto_Types[CurProto.Text.Split('#')[0].Substring(0, CurProto.Text.Split('#')[0].Length - 4) + " -> #" + tProtoID.Text] = lstProtoProps.Items[1].ToString().Split('|')[1].Split('\t')[1];

			MessageBox.Show("A new prototype has been added with ID #" + tProtoID.Text + "\n\nHINT: Don't forget to save protos.tab and description.mes!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnGoToDesc_Click(object sender, EventArgs e)
		{
			if (CurProto.SelectedIndex == -1 || tProtoID.Text == "")
				return;

			string proto_id = CurProto.Items[CurProto.SelectedIndex].ToString().Split('#')[1];

			// Check if an appropriate description exists and go to description tab
			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().IndexOf(proto_id + ":") == 0)
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

		private bool DESC_CALLBACK;

		private void btnSaveDesc_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save all descriptions?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			// Save descriptions
			var sw2 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\description.mes", false);

			for (int i = 0; i < desc.Count; i++)
				sw2.WriteLine(desc[i]);

			sw2.Close();

			// Save long descriptions
			var sw3 = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "\\long_description.mes", false);

			for (int i = 0; i < ldesc.Count; i++)
				sw3.WriteLine(ldesc[i]);

			sw3.Close();

			MessageBox.Show("Descriptions saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void lstDesc_SelectedIndexChanged(object sender, EventArgs e)
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
			tDescript.Text = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2);

			// Check if a long description exists. If it does, load it.
			string Lookup = "{" + tDescID.Text + "}";

			for (int i = 0; i < ldesc.Count; i++)
			{
				if (ldesc[i].ToString().IndexOf(Lookup) == 0)
				{
					string[] l_des = ldesc[i].ToString().Split('{', '}');
					tLongDescript.Text = l_des[3];
					break;
				}
				else
					tLongDescript.Text = "";
			}
		}

		private void btnLookUpProto_Click(object sender, EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
				return;

			if (int.Parse(tDescID.Text) >= 20000)
			{
				MessageBox.Show("Description identifiers above 20000 are reserved for unidentified item descriptions and unknown/known NPC names. They don't correspond to prototypes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string ProtoName = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];

			if (CurProto.Items.IndexOf(ProtoName) == -1)
			{
				MessageBox.Show("The selected prototype was not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			CurProto.SelectedItem = ProtoName;
			GenericTab.SelectedTab = ff_YT_Prototypes;
		}

		private void btnSetDescs_Click(object sender, EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
			{
				MessageBox.Show("Please choose a description from the list first.", "Nothing to update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string ProtoString = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
			string LookString = "{" + tDescID.Text + "}";

			// Set the short description
			DESC_CALLBACK = true;
			lstDesc.Items[lstDesc.SelectedIndex] = tDescID.Text + ": " + tDescript.Text;

			for (int i = 0; i < desc.Count; i++)
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
				for (int s = 0; s < CurProto.Items.Count; s++)
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
					Prototype.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					CurProto.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					ChestInvProtos.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
					NpcInvProtos.Items[proto_index] = lstDesc.Items[lstDesc.SelectedIndex].ToString().Substring(lstDesc.Items[lstDesc.SelectedIndex].ToString().IndexOf(':') + 2) + " -> #" + lstDesc.Items[lstDesc.SelectedIndex].ToString().Split(':')[0];
				}
			}

			// Set the long description or remove it, if tlongdescript == ""
			if (tLongDescript.Text.Trim() != "")
			{
				// Set
				bool ALREADY_EXISTS = false;
				for (int i = 0; i < ldesc.Count; i++)
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

					for (int i = 0; i < ldesc.Count; i++)
					{
						if (ldesc[i].ToString().Trim() == "")
							continue;

						if (ldesc[i].ToString().IndexOf("{") != 0)
							continue;

						string listidx = ldesc[i].ToString().Split('{', '}')[1];
						if (lineID <= int.Parse(listidx))
						{
							// + v1.0: See if there's a comment and an empty line above +
							int j = i;
							if (j > 10)
							{
								if (ldesc[j - 1].ToString().Length > 0)
								{
									if (ldesc[j - 1].ToString().Substring(0, 1) == "/")
									{
										i--;
										if (ldesc[j - 2].ToString().Trim() == "")
											i--;
										if (ldesc[j - 3].ToString().Trim() == "")
											i--;
										if (ldesc[j - 4].ToString().Trim() == "")
											i--;
										if (ldesc[j - 5].ToString().Trim() == "")
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
				for (int i = 0; i < ldesc.Count; i++)
				{
					if (ldesc[i].ToString().IndexOf(LookString) == 0)
					{
						ldesc.RemoveAt(i);
						break;
					}
				}
			}

			MessageBox.Show("Description entry updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnAddDesc_Click(object sender, EventArgs e)
		{
			if (tDescID.Text == "")
			{
				MessageBox.Show("Please specify an identifier for the new description", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			bool ALREADY_EXISTS = false;
			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				if (lstDesc.Items[i].ToString().Split(':')[0] == tDescID.Text)
				{
					ALREADY_EXISTS = true;
					break;
				}
			}

			if (ALREADY_EXISTS)
			{
				MessageBox.Show("A description with this ID already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			if (int.Parse(tDescID.Text) < 20000)
			{
				MessageBox.Show(
					"Descriptions with numbers under 20000 are reserved for prototypes and must be added together with a prototype. Please use a prototype editor mode to create a prototype with this ID first. The description entry will be added automatically and could be changed later at any time.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// Add a description
			int targetLine = -1;
			int lineID = int.Parse(tDescID.Text);

			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= int.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine == -1)
				lstDesc.Items.Add(tDescID.Text + ": " + tDescript.Text);
			else
				lstDesc.Items.Insert(targetLine, tDescID.Text + ": " + tDescript.Text);

			for (int j = 0; j < desc.Count; j++)
			{
				if (desc[j].ToString().Trim() == "")
					continue;

				if (desc[j].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[j].ToString().Split('{', '}')[1];
				if (lineID <= int.Parse(listidx))
				{
					// + v1.0: See if there's a comment and an empty line above +
					int i = j;
					if (i > 10)
					{
						if (desc[i - 1].ToString().Length > 0)
						{
							if (desc[i - 1].ToString().Substring(0, 1) == "/")
							{
								j--;
								if (desc[i - 2].ToString().Trim() == "")
									j--;
								if (desc[i - 3].ToString().Trim() == "")
									j--;
								if (desc[i - 4].ToString().Trim() == "")
									i--;
								if (desc[i - 5].ToString().Trim() == "")
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
				desc.Add("{" + tDescID.Text + "}{" + tDescript.Text + "}");
			else
				desc.Insert(targetLine, "{" + tDescID.Text + "}{" + tDescript.Text + "}");

			MessageBox.Show("A description has been added: #" + tDescID.Text, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnRemoveDesc_Click(object sender, EventArgs e)
		{
			if (lstDesc.SelectedIndex == -1)
				return;

			if (
				MessageBox.Show("WARNING: Deleting descriptions may lead to dangling description references in protos.tab. You must be absolutely sure in what you are doing. Are you sure you want to delete this description?", "Please confirm operation",
								MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			int targetLine = -1;
			int lineID = int.Parse(tDescID.Text);

			for (int i = 0; i < lstDesc.Items.Count; i++)
			{
				string listidx = lstDesc.Items[i].ToString().Split(':')[0];
				if (lineID <= int.Parse(listidx))
				{
					targetLine = i;
					break;
				}
			}
			if (targetLine != -1)
				lstDesc.Items.RemoveAt(targetLine);

			for (int j = 0; j < desc.Count; j++)
			{
				if (desc[j].ToString().Trim() == "")
					continue;

				if (desc[j].ToString().IndexOf("{") != 0)
					continue;

				string listidx = desc[j].ToString().Split('{', '}')[1];
				if (lineID <= int.Parse(listidx))
				{
					targetLine = j;
					break;
				}
			}
			if (targetLine != -1)
				desc.RemoveAt(targetLine);

			// v1.0: delete long description if it exists
			for (int k = 0; k < ldesc.Count; k++)
			{
				if (ldesc[k].ToString().Trim() == "")
					continue;

				if (ldesc[k].ToString().IndexOf("{") != 0)
					continue;

				string listidx = ldesc[k].ToString().Split('{', '}')[1];
				if (lineID <= int.Parse(listidx))
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

		private string GlobalLit = "";
		private string MapPrp = "";

		private void btnOpenProps_Click(object sender, EventArgs e)
		{
			MultiODLG.Filter = "Map properties file (map.prp)|map.prp";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				MapPrp = MultiODLG.FileName;
				var br = new BinaryReader(new FileStream(MapPrp, FileMode.Open));
				tArtEntry.Text = br.ReadUInt32().ToString();
				br.ReadUInt32().ToString(); // Useless. tArtEntry was initially
				// supposed to be 64bit, but Worlded
				// sometimes flushed buffers here
				tMapWidth.Text = (br.ReadUInt64()/64).ToString();
				tMapHeight.Text = (br.ReadUInt64()/64).ToString();
				br.Close();
				tArtEntry.Enabled = true;
				tMapWidth.Enabled = true;
				tMapHeight.Enabled = true;
				btnSaveProps.Enabled = true;
			}
		}

		private void btnSaveProps_Click(object sender, EventArgs e)
		{
			if (MapPrp == "")
				return;

			if (MessageBox.Show("Are you sure you want to save the map properties?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var bw = new BinaryWriter(new FileStream(MapPrp, FileMode.Create));
			bw.Write(ulong.Parse(tArtEntry.Text));
			bw.Write(ulong.Parse(tMapWidth.Text)*64);
			bw.Write(ulong.Parse(tMapWidth.Text)*64);
			bw.Close();
			MessageBox.Show("Saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnOpenGLT_Click(object sender, EventArgs e)
		{
			MultiODLG.Filter = "Global lighting data (global.lit)|global.lit";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				GlobalLit = MultiODLG.FileName;
				var br = new BinaryReader(new FileStream(GlobalLit, FileMode.Open));
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

		private void btnSaveGLT_Click(object sender, EventArgs e)
		{
			if (GlobalLit == "")
				return;

			if (MessageBox.Show("Are you sure you want to save the global lighting data?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			try
			{
				var bw = new BinaryWriter(new FileStream(GlobalLit, FileMode.Create));
				bw.Write(uint.Parse(tGLT1.Text));
				bw.Write(tGLT2.SelectedIndex);
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
				MessageBox.Show("Saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception)
			{
				MessageBox.Show("There was an error saving GLOBAL.LIT. Possibly one or more fields contain an illegal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnNewGLT_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show("Are you sure you want to create a new global lighting file? (if you answer yes, you'll be asked to point to the folder where you want to save your file)", "Please confirm operation", MessageBoxButtons.YesNo,
								MessageBoxIcon.Question) == DialogResult.No)
				return;

			var sdlg = new SaveFileDialog();
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

		private bool AUTO_CALLBACK;
		private bool LIGHT_CALLBACK;
		private bool SEC_CALLBACK;
		private string SVB_Bitmap = "ENOSVB";
		private string SecFile = "";
		private byte WallFlag4;
		private byte WallFlag5;
		private byte WallFlag6;
		private byte WallFlag7;
		private SectorAnalysis san;

		// Callbacks
		private ArrayList static_objguid = new ArrayList();
		private ArrayList static_objlist = new ArrayList();

		// + SVB Stuff +
		// - SVB Stuff -

		private void btnOpenSec_Click(object sender, EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Please close the Sector Analyzer/Painter before opening sector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var o = new OpenSEC();
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
				SecFile = "Sectors\\" + o.FileToOpen + ".sec";
				tabSectorEd.Enabled = true;
				btnSaveSec.Enabled = true;
				btnDelLights.Enabled = true;
				btnDelObjects.Enabled = true;
				btnResetTiles.Enabled = true;

				SecFile = "Sectors\\" + o.FileToOpen + ".sec";

				int minX, maxX, minY, maxY;
				Helper.Sec_GetMinMax(o.FileToOpen, out minY, out maxY, out minX, out maxX);
				tu_0_0.Text = string.Format("({0},{1})", minX, minY);
				tu_X_0.Text = string.Format("({0},{1})", maxX, minY);
				tu_0_Y.Text = string.Format("({0},{1})", minX, maxY);
				tu_X_Y.Text = string.Format("({0},{1})", maxX, maxY);
				tv_0_0.Text = string.Format("({0},{1})", minX, minY);
				tv_X_0.Text = string.Format("({0},{1})", maxX, minY);
				tv_0_Y.Text = string.Format("({0},{1})", minX, maxY);
				tv_X_Y.Text = string.Format("({0},{1})", maxX, maxY);

				tCurSector.Text = o.FileToOpen + ".sec";

				// Load the file
				var r_sec = new BinaryReader(new FileStream(SecFile, FileMode.Open));

				// Cleanup
				Helper.SectorLights.Clear();
				Helper.SectorLightsChunk.Clear();
				Helper.SectorTiles.Clear();

				// Load lights
				uint LightCount = r_sec.ReadUInt32(); // the # of lights

				var light = new Helper.LightInfo();

				// Check if lights can be loaded	
				bool CanLoadLights = true;
				long approx_pos = (long) LightCount*108;
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
					for (int i = 0; i < LightCount; i++)
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
					Helper.SectorLightsChunk.Add(r_sec.ReadBytes((int) (real_pos) + 4));
				}

				// OLDER WAY OF LOADING LIGHTS, TO BE REMOVED
				// Helper.SectorLights.Add(r_sec.ReadBytes(108));

				// Load tiledata
				for (int j = 0; j < 4096; j++)
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
					var w_off = new BinaryWriter(new FileStream("temp.off", FileMode.Create));
					for (int i = 0; i < Helper.SectorObjects.Count; i++)
						w_off.Write((byte) Helper.SectorObjects[i]);
					w_off.Close();

					// Walk through the object dump to detect object boundaries
					long p_Stream = 0;
					bool IS_OBJECT = false;
					var r_off = new BinaryReader(new FileStream("temp.off", FileMode.Open));

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
					var readobj = new BinaryReader(new FileStream("temp.off", FileMode.Open));
					for (int itm = 0; itm < static_objlist.Count - 1; itm++)
					{
						// Acquire a pointer and read all the needed data
						readobj.BaseStream.Seek((long) static_objlist[itm] + 0x0C, SeekOrigin.Begin);
						Int16 proto_id = readobj.ReadInt16();
						readobj.BaseStream.Seek((long) static_objlist[itm] + 0x34, SeekOrigin.Begin);
						uint type = readobj.ReadUInt32();
						readobj.BaseStream.Seek((long) static_objlist[itm] + 0x3A, SeekOrigin.Begin);
						long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes) type);
						readobj.BaseStream.Seek(BlocksToSkip*4 + 1, SeekOrigin.Current);
						uint x_coord = readobj.ReadUInt32();
						uint y_coord = readobj.ReadUInt32();
						// + GUID +
						readobj.BaseStream.Seek((long) static_objlist[itm] + 0x1C, SeekOrigin.Begin);
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
							MessageBox.Show(
								"The object embedded in this sector file has a proto ID that has been added recently (or that doesn't exist in PROTOS.TAB). Therefore, if the prototype was added recently, the PROTOS.TAB must be reloaded for this object to be parsed correctly. Please restart ToEE World Builder if you want the object name to be properly displayed.",
								"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							proto_name = "(NOT PARSABLE)";
						}

						static_objguid.Add(proto_guid);
						SecObjList.Items.Add(itm.ToString() + ":\t(" + x_coord.ToString() + "," + y_coord.ToString() + ")\t\t\t" + proto_name);
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
				string SVBFile = "Sectors\\" + Path.GetFileNameWithoutExtension(SecFile) + ".svb";

				if (File.Exists(SVBFile))
				{
					SVB_Bitmap = "";
					var r_svb = new BinaryReader(new FileStream(SVBFile, FileMode.Open));

					for (int i = 0; i < 2304; i++)
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
				string HSDFile = "Sectors\\hsd" + Path.GetFileNameWithoutExtension(SecFile) + ".hsd";

				if (File.Exists(HSDFile))
				{
					var r_hsd = new BinaryReader(new FileStream(HSDFile, FileMode.Open));
					r_hsd.ReadInt32(); // version tag, skipping it

					for (int i = 0; i < 36864; i++)
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

		private void btnNewSector_Click(object sender, EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Please close the Sector Analyzer/Painter before creating a new sector!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var cn = new CreateNewSector();
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
				SecFile = "Sectors\\" + cn.FileToOpen + ".sec";
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

				tCurSector.Text = cn.FileToOpen + ".sec";

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

		private void btnSaveSec_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the current sector file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			string SVBFile = "Sectors\\" + Path.GetFileNameWithoutExtension(SecFile) + ".svb";
			string HSDFile = "Sectors\\hsd" + Path.GetFileNameWithoutExtension(SecFile) + ".hsd";

			var w_sec = new BinaryWriter(new FileStream(SecFile, FileMode.Create));

			if (Helper.SectorLightsChunk.Count == 0)
			{
				w_sec.Write(Helper.SectorLights.Count); // the number of light objects

				for (int i = 0; i < Helper.SectorLights.Count; i++)
					Helper.SaveLight(w_sec, (Helper.LightInfo) Helper.SectorLights[i]);
			}
			else
			{
				w_sec.Write((byte[]) Helper.SectorLightsChunk[0]);
			}

			// OLD WAY OF WRITING BACK LIGHTS. TO BE REMOVED.
			// w_sec.Write((byte[])Helper.SectorLights[i]); // write a light

			for (int i = 0; i < 4096; i++)
				w_sec.Write((byte[]) Helper.SectorTiles[i]); // write tiledata

			Helper.SEC_WriteUnknownEmptyAreas(w_sec); // write unknown stuff

			for (int i = 0; i < Helper.SectorObjects.Count; i++)
				w_sec.Write((byte) Helper.SectorObjects[i]); // write objects

			w_sec.Close();

			// Saving the SVB file
			if (SVB_Bitmap.IndexOf("1") == -1)
			{
				// no data is set or ENOSVB, so delete the SVB file if it exists
				if (cfgDelEmpty.Checked)
				{
					if (File.Exists(SVBFile))
						File.Delete(SVBFile);
				}
				else
				{
					var w_svb = new BinaryWriter(new FileStream(SVBFile, FileMode.Create));
					ArrayList svb_bytes = Helper.MOB_BitmapToBytes(SVB_Bitmap);

					foreach (object block in svb_bytes)
						w_svb.Write((byte) block);

					w_svb.Close();
				}
			}
			else
			{
				// flush all the data to disk
				var w_svb = new BinaryWriter(new FileStream(SVBFile, FileMode.Create));
				ArrayList svb_bytes = Helper.MOB_BitmapToBytes(SVB_Bitmap);

				foreach (object block in svb_bytes)
					w_svb.Write((byte) block);

				w_svb.Close();
			}

			// Saving the HSD file
			if (Helper.HSD_CheckIsSaveNecessary())
			{
				// saving is necessary (at least one subtile is set)
				var w_hsd = new BinaryWriter(new FileStream(HSDFile, FileMode.Create));

				w_hsd.Write(0x02); // save the HSD version tag

				for (int i = 0; i < 36864; i++)
					w_hsd.Write(Helper.HSD_Tiles[i]); // save the tile info

				w_hsd.Close();
			}
			else
			{
				// no water subtiles were set, delete the HSD file if it exists
				if (cfgDelEmpty.Checked)
				{
					if (File.Exists(HSDFile))
						File.Delete(HSDFile);
				}
				else
				{
					var w_hsd = new BinaryWriter(new FileStream(HSDFile, FileMode.Create));

					w_hsd.Write(0x02); // save the HSD version tag

					for (int i = 0; i < 36864; i++)
						w_hsd.Write(Helper.HSD_Tiles[i]); // save the tile info

					w_hsd.Close();
				}
			}

			MessageBox.Show("Sector saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDelLights_Click(object sender, EventArgs e)
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

			MessageBox.Show("Lights removed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDelObjects_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Warning: this operation will delete all objects in this sector!\nAre you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			Helper.SectorObjects.Clear();
			Helper.SectorObjects.Add((byte) 0x00);
			Helper.SectorObjects.Add((byte) 0x00);
			Helper.SectorObjects.Add((byte) 0x00);
			Helper.SectorObjects.Add((byte) 0x00);

			// v1.1a: Clean up static object cache
			SecObjList.Items.Clear();
			static_objlist = new ArrayList();
			static_objguid = new ArrayList();
			SetStaticObjInterfaceState(false);

			MessageBox.Show("Objects removed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnResetTiles_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Warning: this operation will reset all tiles to the Fully Passable state!\nAre you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var tiledata = new byte[16];
			tiledata[0] = 0x02;

			for (int j = 1; j < 16; j++)
				tiledata[j] = 0x00;

			for (int i = 0; i < 4096; i++)
				Helper.SectorTiles[i] = tiledata;

			if (MessageBox.Show("Do you want to clear the sector visibility blocking information for all tiles as well?", "Please confirm additional operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				SVB_Bitmap = Helper.SVB_NewBitmap();

			if (MessageBox.Show("Do you want to clear the negative height/water tile information for all tiles as well?", "Please confirm additional operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				Helper.HSD_Tiles = Helper.HSD_NewArray();

			MessageBox.Show("Tile data reset.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUpdateTile_Click(object sender, EventArgs e)
		{
			// VERIFY: Is this STX/STY calculation routine working correctly?
			int STX = -1; // final X location in the sector file
			int STY = -1; // final Y location in the sector file

			STX = (int) TX.Value - (int) TX.Minimum;
			STY = (int) TY.Value - (int) TY.Minimum;

			if (STX > 63 || STX < 0)
			{
				MessageBox.Show(
					"Warning: the X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (STY > 63 || STY < 0)
			{
				MessageBox.Show(
					"Warning: the Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			bool INTERNAL_CALLBACK = chkAutoTile.Checked;

			// CRITICAL: Tile creation routine! Add support for new tile stuff here!
			SetWallFlags();
			SetWaterFlags(STX, STY);
			SVB_Bitmap = SetSVBFlags(SVB_Bitmap, Helper.SVB_GetTileAddress(STX, STY));
			//SVB_Bitmap = Helper.SVB_SetPropertyLine(SVB_Bitmap, destflags, Helper.SVB_GetTileAddress(STX, STY));

			byte[] tile = Helper.SEC_MakeTileData((byte) cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
			Helper.SEC_SetTileData(STX, STY, tile);

			chkAutoTile.Checked = INTERNAL_CALLBACK;

			// v1.6: Display the message only if outside the sys message queue
			if ((!SysMsg.SM_PAINT_TILE) && (!SysMsg.SM_SVB1) && (!SysMsg.SM_SVB2) && (!SysMsg.SM_SVB3) && (!SysMsg.SM_SVB4))
				MessageBox.Show("Tile updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUpdateAllTiles_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Warning: this will update all tiles in the current sector with the information defined above! Are you sure you want to continue?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
				DialogResult.No)
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
					byte[] tile = Helper.SEC_MakeTileData((byte) cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
					Helper.SEC_SetTileData(STX, STY, tile);
				}
			}

			chkAutoTile.Checked = INTERNAL_CALLBACK;
			MessageBox.Show("All tiles updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUpdateBoxTiles_Click(object sender, EventArgs e)
		{
			if ((FromTX.Value == ToTX.Value && FromTY.Value == ToTY.Value) || (FromTX.Value > ToTX.Value) || (FromTY.Value > ToTY.Value))
			{
				MessageBox.Show("Invalid tile box specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Warning: this will update a group of tiles with the information defined above. Are you sure you want to do this?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var From_STX = (int) (FromTX.Value - FromTX.Minimum);
			var From_STY = (int) (FromTY.Value - FromTY.Minimum);
			var To_STX = (int) (ToTX.Value - ToTX.Minimum);
			var To_STY = (int) (ToTY.Value - ToTY.Minimum);

			// string destflags = SetSVBFlags();

			if (From_STX > 63 || From_STX < 0)
			{
				MessageBox.Show(
					"Warning: the From_X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (From_STY > 63 || From_STY < 0)
			{
				MessageBox.Show(
					"Warning: the From_Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (To_STX > 63 || To_STX < 0)
			{
				MessageBox.Show(
					"Warning: the To_X coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
			}

			if (To_STY > 63 || To_STY < 0)
			{
				MessageBox.Show(
					"Warning: the To_Y coordinate goes outside of the current sector boundary. ONLY the coordinates valid for the current sector will be updated. Make sure that you update other coordinates that you planned to update in corresponding sectors!");
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
					byte[] tile = Helper.SEC_MakeTileData((byte) cmbTileSound.SelectedIndex, 0, 0, 0, WallFlag4, WallFlag5, WallFlag6, WallFlag7, 0, 0, 0, 0, 0, 0, 0, 0);
					Helper.SEC_SetTileData(Cur_TX, Cur_TY, tile);
				}
			}

			chkAutoTile.Checked = INTERNAL_CALLBACK;
			MessageBox.Show("A box of tiles updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnLoadTile_Click(object sender, EventArgs e)
		{
			var RealTY = (int) (TY.Value - TY.Minimum);
			var RealTX = (int) (TX.Value - TX.Minimum);
			byte[] tile;

			if (SEC_CALLBACK)
			{
				SEC_CALLBACK = false;
				tile = (byte[]) Helper.SectorTiles[0];
			}
			else
			{
				tile = (byte[]) Helper.SectorTiles[RealTY*64 + RealTX];
			}

			// CRITICAL: Load the known tile data (unknown is skipped atm)
			cmbTileSound.SelectedIndex = tile[0];

			WallFlag4 = tile[4];
			WallFlag5 = tile[5];
			WallFlag6 = tile[6];
			WallFlag7 = tile[7];

			byte[] wflagbytes =
				{
					tile[4],
					tile[5],
					tile[6],
					tile[7]
				};

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
				SVB1_UL.Checked = (Helper.MOB_GetPropertyState(SVB_Bitmap, SVB_index + 8) == TriState.True) ? true : false;
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
				FLAGS += 0x00000001;
			if (TILE_SINKS.Checked)
				FLAGS += 0x00000002;
			if (TILE_CAN_FLY_OVER.Checked)
				FLAGS += 0x00000004;
			if (TILE_ICY.Checked)
				FLAGS += 0x00000008;
			if (TILE_NATURAL.Checked)
				FLAGS += 0x00000010;
			if (TILE_SOUNDPROOF.Checked)
				FLAGS += 0x00000020;
			if (TILE_INDOOR.Checked)
				FLAGS += 0x00000040;
			if (TILE_REFLECTIVE.Checked)
				FLAGS += 0x00000080;
			if (TILE_BLOCKS_VISION.Checked)
				FLAGS += 0x00000100;

			/* The following flags are reversed (e.g. _UR stands for _LL etc.) */
			if (TILE_BLOCKS_UR.Checked)
				FLAGS += 0x00000200;
			if (TILE_BLOCKS_UM.Checked)
				FLAGS += 0x00000400;
			if (TILE_BLOCKS_UL.Checked)
				FLAGS += 0x00000800;
			if (TILE_BLOCKS_MR.Checked)
				FLAGS += 0x00001000;
			if (TILE_BLOCKS_MM.Checked)
				FLAGS += 0x00002000;
			if (TILE_BLOCKS_ML.Checked)
				FLAGS += 0x00004000;
			if (TILE_BLOCKS_LR.Checked)
				FLAGS += 0x00008000;
			if (TILE_BLOCKS_LM.Checked)
				FLAGS += 0x00010000;
			if (TILE_BLOCKS_LL.Checked)
				FLAGS += 0x00020000;

			if (TILE_FLYOVER_UR.Checked)
				FLAGS += 0x00040000;
			if (TILE_FLYOVER_UM.Checked)
				FLAGS += 0x00080000;
			if (TILE_FLYOVER_UL.Checked)
				FLAGS += 0x00100000;
			if (TILE_FLYOVER_MR.Checked)
				FLAGS += 0x00200000;
			if (TILE_FLYOVER_MM.Checked)
				FLAGS += 0x00400000;
			if (TILE_FLYOVER_ML.Checked)
				FLAGS += 0x00800000;
			if (TILE_FLYOVER_LR.Checked)
				FLAGS += 0x01000000;
			if (TILE_FLYOVER_LM.Checked)
				FLAGS += 0x02000000;
			if (TILE_FLYOVER_LL.Checked)
				FLAGS += 0x04000000;

			if (TILE_FLYOVER_COVER.Checked)
				FLAGS += 0x08000000;

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

			Helper.HSD_ModifyProperty(HSD_index, HSD_UR.Checked, (byte) HGT_UR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 1, HSD_UM.Checked, (byte) HGT_UM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 2, HSD_UL.Checked, (byte) HGT_UL.Value);
			Helper.HSD_ModifyProperty(HSD_index + 3, HSD_MR.Checked, (byte) HGT_MR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 4, HSD_MM.Checked, (byte) HGT_MM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 5, HSD_ML.Checked, (byte) HGT_ML.Value);
			Helper.HSD_ModifyProperty(HSD_index + 6, HSD_LR.Checked, (byte) HGT_LR.Value);
			Helper.HSD_ModifyProperty(HSD_index + 7, HSD_LM.Checked, (byte) HGT_LM.Value);
			Helper.HSD_ModifyProperty(HSD_index + 8, HSD_LL.Checked, (byte) HGT_LL.Value);
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
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 1, SVB2_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 2, SVB3_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 3, SVB4_MR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 4, SVB1_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 5, SVB2_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 6, SVB3_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 7, SVB4_MM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 8, SVB1_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 9, SVB2_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 10, SVB3_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 192*4 + 11, SVB4_ML.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4, SVB1_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 1, SVB2_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 2, SVB3_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 3, SVB4_LR.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 4, SVB1_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 5, SVB2_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 6, SVB3_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 7, SVB4_LM.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 8, SVB1_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 9, SVB2_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 10, SVB3_LL.Checked);
			SVB_destprop = Helper.MOB_ModifyProperty(SVB_destprop, SVB_index + 384*4 + 11, SVB4_LL.Checked);

			return SVB_destprop;
		}

		private void TX_ValueChanged(object sender, EventArgs e)
		{
			if (chkAutoTile.Checked)
				btnLoadTile_Click(null, null);
		}

		private void TY_ValueChanged(object sender, EventArgs e)
		{
			if (chkAutoTile.Checked)
				btnLoadTile_Click(null, null);
		}

		private void HSD_LR_CheckedChanged(object sender, EventArgs e)
		{
			HGT_LR.Enabled = HSD_LR.Checked;

			if (HGT_LR.Enabled && HGT_LR.Value == 0)
				HGT_LR.Value = 36;
		}

		private void HSD_LM_CheckedChanged(object sender, EventArgs e)
		{
			HGT_LM.Enabled = HSD_LM.Checked;

			if (HGT_LM.Enabled && HGT_LM.Value == 0)
				HGT_LM.Value = 36;
		}

		private void HSD_LL_CheckedChanged(object sender, EventArgs e)
		{
			HGT_LL.Enabled = HSD_LL.Checked;

			if (HGT_LL.Enabled && HGT_LL.Value == 0)
				HGT_LL.Value = 36;
		}

		private void HSD_MR_CheckedChanged(object sender, EventArgs e)
		{
			HGT_MR.Enabled = HSD_MR.Checked;

			if (HGT_MR.Enabled && HGT_MR.Value == 0)
				HGT_MR.Value = 36;
		}

		private void HSD_MM_CheckedChanged(object sender, EventArgs e)
		{
			HGT_MM.Enabled = HSD_MM.Checked;

			if (HGT_MM.Enabled && HGT_MM.Value == 0)
				HGT_MM.Value = 36;
		}

		private void HSD_ML_CheckedChanged(object sender, EventArgs e)
		{
			HGT_ML.Enabled = HSD_ML.Checked;

			if (HGT_ML.Enabled && HGT_ML.Value == 0)
				HGT_ML.Value = 36;
		}

		private void HSD_UR_CheckedChanged(object sender, EventArgs e)
		{
			HGT_UR.Enabled = HSD_UR.Checked;

			if (HGT_UR.Enabled && HGT_UR.Value == 0)
				HGT_UR.Value = 36;
		}

		private void HSD_UM_CheckedChanged(object sender, EventArgs e)
		{
			HGT_UM.Enabled = HSD_UM.Checked;

			if (HGT_UM.Enabled && HGT_UM.Value == 0)
				HGT_UM.Value = 36;
		}

		private void HSD_UL_CheckedChanged(object sender, EventArgs e)
		{
			HGT_UL.Enabled = HSD_UL.Checked;

			if (HGT_UL.Enabled && HGT_UL.Value == 0)
				HGT_UL.Value = 36;
		}

		// Light editor functions
		private void SetLightEdInterfaceState(int sid, Helper.LightInfo light)
		{
			switch (sid)
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
				case 2: // state 2: reset all boxes, light = null
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
					Light10_X.Value = light.loc_x;
					Light11_Y.Value = light.loc_y;
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
					MessageBox.Show("Unexpected Error 020: Illegal state passed to SetLightEdInterfaceState!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					break;
			}
		}

		// Create a LightInfo structure from the current data
		private Helper.LightInfo CreateLightInfo()
		{
			var light = new Helper.LightInfo();
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
				light.loc_x = (uint) Light10_X.Value;
				light.loc_y = (uint) Light11_Y.Value;
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

		private void LightID_ValueChanged(object sender, EventArgs e)
		{
			if (LIGHT_CALLBACK)
			{
				LIGHT_CALLBACK = false;
				SetLightEdInterfaceState(0, new Helper.LightInfo());
			}

			SetLightEdInterfaceState(3, (Helper.LightInfo) Helper.SectorLights[(int) LightID.Value]);
		}

		private void btnLightUpdate_Click(object sender, EventArgs e)
		{
			// Is the interface state valid?
			if (LightID.Enabled == false)
			{
				MessageBox.Show("No light to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Helper.LightInfo t_light = CreateLightInfo();

			if (t_light.struct_errorlevel == -1)
			{
				MessageBox.Show("There was an error passing light parameters. Please check the validity of all data in the text boxes. Data not updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			Helper.SectorLights[(int) LightID.Value] = t_light;
			MessageBox.Show("Light updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDelLight_Click(object sender, EventArgs e)
		{
			// Check for the interface state validity first		
			if (LightID.Enabled == false)
			{
				MessageBox.Show("No light to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (MessageBox.Show("Are you sure you want to delete the current light?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (LightID.Value != 0)
			{
				Helper.SectorLights.RemoveAt((int) LightID.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				var p_lightarr = new ArrayList();

				for (int i = 0; i < Helper.SectorLights.Count; i++)
					p_lightarr.Add(Helper.SectorLights[i]);

				Helper.SectorLights = p_lightarr;

				LightID.Value = 0;
				LightID.Maximum = Helper.SectorLights.Count - 1;

				MessageBox.Show("Light deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				// Light ID = #0
				Helper.SectorLights.RemoveAt((int) LightID.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				if (Helper.SectorLights.Count > 0)
				{
					var p_lightarr = new ArrayList();

					for (int i = 0; i < Helper.SectorLights.Count; i++)
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

				MessageBox.Show("Light deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnLightAdd_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to create a new light based on the current prototype (if any)?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (LightID.Enabled == false)
			{
				// there were no lights for this sector, so we need to create a
				// bank for lights on this map
				SetLightEdInterfaceState(1, new Helper.LightInfo());
				var light = new Helper.LightInfo();
				light.loc_x = (uint) Light10_X.Minimum;
				light.loc_y = (uint) Light11_Y.Minimum;
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
				light.loc_x = (uint) Light10_X.Value;
				light.loc_y = (uint) Light11_Y.Value;
				Helper.SectorLights.Add(light);
				LightID.Maximum++;
				LightID.Value = LightID.Maximum; //auto pass parameters
			}

			MessageBox.Show("Light added.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void SetStaticObjInterfaceState(bool state)
		{
			btnDelObj.Enabled = state;
			btnXtrObj.Enabled = state;

			if (state == false)
				SecObjList.Items.Clear();
		}

		private void SecObjList_SelectedIndexChanged(object sender, EventArgs e)
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

		private void btnXtrObj_Click(object sender, EventArgs e)
		{
			if (
				MessageBox.Show(
					"Are you sure you want to extract this object?\n\nHINT: Extracting an object means creating a MOB file that can later be edited in an object editor and re-embedded into the sector file. An extracted object will be automatically copied to the 'Mobiles' folder of your ToEE World Builder installation and will be available for immediate editing.\n\nNOTE: Static objects use the so-called 'null GUID' (there is no need to store a GUID for a static object, so the GUID field is filled with random values, which are often the same for all objects in a sector), which pretty much means that a lot of static objects may have same GUIDs in the same sector file. Please remember this when extracting static objects, since certain (if not all!) static objects may overwrite previously extracted static objects!",
					"Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var ptr_start = (long) static_objlist[SecObjList.SelectedIndex];
			var ptr_end = (long) (static_objlist[SecObjList.SelectedIndex + 1]);

			string mob_target = "Mobiles\\" + static_objguid[SecObjList.SelectedIndex] + ".mob";

			// The MOB target already exists
			if (File.Exists(mob_target))
			{
				if (
					MessageBox.Show("Warning: the MOB file with the following GUID already exists:\n" + static_objguid[SecObjList.SelectedIndex] + ".mob" + "\n\nAre you sure you want to extract the new MOB, thus overwriting the old one?",
									"The MOB Target Already Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					File.Delete(mob_target); // delete the old MOB target
				else
					return;
			}

			var mob_ex = new BinaryWriter(new FileStream(mob_target, FileMode.Create));

			for (long ptr = ptr_start; ptr < ptr_end; ptr++)
			{
				mob_ex.Write((byte) Helper.SectorObjects[(int) ptr]);
			}

			mob_ex.Close();
			MessageBox.Show("Static object extracted as:\n\n" + static_objguid[SecObjList.SelectedIndex] + ".mob", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDelObj_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this object from the sector?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var ptr_start = (long) static_objlist[SecObjList.SelectedIndex];
			var ptr_end = (long) (static_objlist[SecObjList.SelectedIndex + 1]);

			for (long ptr = ptr_start; ptr < ptr_end; ptr++)
			{
				Helper.SectorObjects.RemoveAt((int) ptr_start);
			}

			// Tricky: we have to reload all the objects now, refill the
			// object list and object GUID structures, AND decrease the
			// object count by 1!
			SecObjList.Items.Clear();
			static_objlist.Clear();
			static_objguid.Clear();

			// Acquire the previous count of static objects in a sector
			// (65536 max... I know it's a hack, but whatever!...)
			var COUNT_1 = (byte) Helper.SectorObjects[Helper.SectorObjects.Count - 4];
			var COUNT_2 = (byte) Helper.SectorObjects[Helper.SectorObjects.Count - 3];

			var count = (uint) (COUNT_2*256 + COUNT_1);
			count--;

			COUNT_1 = (byte) count;
			COUNT_2 = (byte) (count >> 8);
			Helper.SectorObjects[Helper.SectorObjects.Count - 4] = COUNT_1;
			Helper.SectorObjects[Helper.SectorObjects.Count - 3] = COUNT_2;

			if (Helper.SectorObjects.Count != 4) /* 0x04 = NO OBJECTS */
			{
				// First of all, dump SectorObjects to a temporary OFF file
				var w_off = new BinaryWriter(new FileStream("temp.off", FileMode.Create));
				for (int i = 0; i < Helper.SectorObjects.Count; i++)
					w_off.Write((byte) Helper.SectorObjects[i]);
				w_off.Close();

				// Walk through the object dump to detect object boundaries
				long p_Stream = 0;
				bool IS_OBJECT = false;
				var r_off = new BinaryReader(new FileStream("temp.off", FileMode.Open));

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
				var readobj = new BinaryReader(new FileStream("temp.off", FileMode.Open));
				for (int itm = 0; itm < static_objlist.Count - 1; itm++)
				{
					// Acquire a pointer and read all the needed data
					readobj.BaseStream.Seek((long) static_objlist[itm] + 0x0C, SeekOrigin.Begin);
					Int16 proto_id = readobj.ReadInt16();
					readobj.BaseStream.Seek((long) static_objlist[itm] + 0x34, SeekOrigin.Begin);
					uint type = readobj.ReadUInt32();
					readobj.BaseStream.Seek((long) static_objlist[itm] + 0x3A, SeekOrigin.Begin);
					long BlocksToSkip = Helper.MOB_GetNumberofBitmapBlocks((MobTypes) type);
					readobj.BaseStream.Seek(BlocksToSkip*4 + 1, SeekOrigin.Current);
					uint x_coord = readobj.ReadUInt32();
					uint y_coord = readobj.ReadUInt32();
					// + GUID +
					readobj.BaseStream.Seek((long) static_objlist[itm] + 0x1C, SeekOrigin.Begin);
					string proto_guid = Helper.GEN_ConvertBytesToStringGUID(readobj.ReadBytes(24));
					// - GUID -
					string proto_name = Helper.Proto_By_ID[proto_id.ToString()].ToString();

					static_objguid.Add(proto_guid);
					SecObjList.Items.Add(itm.ToString() + ":\t(" + x_coord.ToString() + "," + y_coord.ToString() + ")\t\t\t" + proto_name);
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
			MessageBox.Show("Static object deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void menuItem14_Click(object sender, EventArgs e)
		{
			var sl = new SectorLookup();
			sl.Show();
		}

		// Call the sector analyzer

		private void menuItem15_Click(object sender, EventArgs e)
		{
			if (SysMsg.SM_SAN_ENABLED)
			{
				MessageBox.Show("Sector analyzer/painter is already running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (Helper.SectorTiles.Count == 0)
			{
				MessageBox.Show("No sector is loaded! Load a sector first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			SysMsg.SM_SAN_ENABLED = true; // System message to control runtime

			san = new SectorAnalysis();
			san.MIN_X = (int) TX.Minimum;
			san.MIN_Y = (int) TY.Minimum;

			if (SVB_Bitmap.Length > 1000)
				san.SVB_BMP = SVB_Bitmap; // pass the SVB bitmap

			if (Helper.HSD_Tiles.GetUpperBound(0) > 1000)
				san.HSD_BMP = Helper.HSD_Tiles; // pass the HSD bitmap

			san.Show();
		}

		// start the extended sector light editor
		private void sectorLightEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var led = new LightEditorEx();
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

		private void btnCleanArea_Click(object sender, EventArgs e)
		{
			if (!chkMOB.Checked && !chkSECSVB.Checked && !chkCLIPPING.Checked && !chkGMESH.Checked && !chkPND.Checked && !chkHSD.Checked)
			{
				MessageBox.Show("Nothing was chosen to clean up!", "Nothing to clean up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
					var bw = new BinaryWriter(new FileStream(path + "\\clipping.cif", FileMode.Create));
					bw.Write(0x00);
					bw.Close();
					var bw2 = new BinaryWriter(new FileStream(path + "\\clipping.cgf", FileMode.Create));
					bw2.Write(0x00);
					bw2.Close();
				}

				if (chkGMESH.Checked)
				{
					// clean up ground mesh info
					var bw3 = new BinaryWriter(new FileStream(path + "\\gmesh.gmf", FileMode.Create));
					bw3.Write(0x00);
					bw3.Close();
					var bw4 = new BinaryWriter(new FileStream(path + "\\gmesh.gmi", FileMode.Create));
					bw4.Write(0x00);
					bw4.Close();
				}

				if (chkPND.Checked)
				{
					// clean up pathnodes
					var bw5 = new BinaryWriter(new FileStream(path + "\\pathnode.pnd", FileMode.Create));
					bw5.Write(0x00);
					bw5.Close();
				}
			}

			MessageBox.Show("Area cleaned up.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion

		#region System Message Queue Processor

		// The system message heartbeat, parsed every 1ms or so
		// Must be maximally optimized in order not to screw things up
		private void WM_SysMsg_Tick(object sender, EventArgs e)
		{
			// v2.0.0: Interoperability with ToEE console support
			if (File.Exists(Helper.InteropPath))
			{
				bool DATA_PASS_ON = false;
				string wbl_data = "";
				try
				{
					var sr = new StreamReader(Helper.InteropPath);
					wbl_data = sr.ReadLine();
					sr.Close();
				}
				catch (Exception)
				{
				}
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
								wbl_data_arr[3] = wbl_data_arr[3].Replace(".", NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
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
								wbl_data_arr[3] = wbl_data_arr[3].Replace(".", NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
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
					GenericTab.SelectedIndex = 0;
					Focus();
				}
				catch (Exception)
				{
					SysMsg.SM_REMEMBER_COORDS_QUEUE.Clear();
					SysMsg.SM_REMEMBER_COORDS = false;
					MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_REMEMBER_COORDS system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
						GenericTab.SelectedIndex = 5;
					}
					else
					{
						Prototype.SelectedIndex = Prototype.Items.IndexOf(SysMsg.SM_PROTO_SEARCH_PARAM);
						GenericTab.SelectedIndex = 0;
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
					MessageBox.Show("System Message Processing Error: unable to parse the queue for SM_PAINT_TILE system message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
					queue += block + " ";

				// Clear the message queue for TEST_MSG
				SysMsg.SM_TEST_MSG = false;
				SysMsg.SM_TEST_MSG_QUEUE.Clear();

				MessageBox.Show("Test message queue processed:\n" + queue, "Done", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

			// Post-process: reset current app directory
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
		}

		#endregion

		#region World Map Path Editor

		private string WM_File = "";
		private ArrayList WM_Paths = new ArrayList();

		private void btnOpenWorldMap_Click(object sender, EventArgs e)
		{
			MultiODLG.Filter = "World Map Paths File (worldmap_ui_paths.bin)|worldmap_ui_paths.bin";
			if (MultiODLG.ShowDialog() == DialogResult.OK)
			{
				w_Paths.Items.Clear();
				w_PathCodes.Items.Clear();

				WM_File = MultiODLG.FileName;
				WM_Paths = new ArrayList();

				// Process the paths file
				var r_wmp = new BinaryReader(new FileStream(WM_File, FileMode.Open));
				int num_paths = r_wmp.ReadInt32();
				uint PARAM1 = 0;
				uint PARAM2 = 0;
				uint PARAM3 = 0;
				uint PARAM4 = 0;
				uint PATH_SIZE = 0;
				var PATH = new ArrayList();

				for (int i = 0; i < num_paths; i++)
				{
					PATH = new ArrayList();
					ProcessEntry(r_wmp, ref PARAM1, ref PARAM2, ref PARAM3, ref PARAM4, ref PATH_SIZE, ref PATH);

					w_Paths.Items.Add("#" + i.ToString() + ": (" + PARAM1.ToString() + "," + PARAM2.ToString() + ") - (" + PARAM3.ToString() + "," + PARAM4.ToString() + ")");
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
			uint opt_pathsize = 4 - (pathsize%4); // compensate 0xFD entries
			// for WMP optimization tech
			for (uint i = 0; i < pathsize; i++)
				path.Add(r_wmp.ReadByte());

			if (opt_pathsize != 4)
			{
				for (uint j = 0; j < opt_pathsize; j++)
					r_wmp.ReadByte();
			}
		}

		private void w_Paths_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			w_PathCodes.Items.Clear();

			string PathInfo = w_Paths.Items[w_Paths.SelectedIndex].ToString();
			string[] PathInfo_A = PathInfo.Split('-');
			string Path_Par1 = PathInfo_A[0].Split('(', ')', ',')[1].Trim();
			string Path_Par2 = PathInfo_A[0].Split('(', ')', ',')[2].Trim();
			string Path_Par3 = PathInfo_A[1].Split('(', ')', ',')[1].Trim();
			string Path_Par4 = PathInfo_A[1].Split('(', ')', ',')[2].Trim();
			tPar1.Text = Path_Par1;
			tPar2.Text = Path_Par2;
			tPar3.Text = Path_Par3;
			tPar4.Text = Path_Par4;

			int opcodes_in_path = ((ArrayList) WM_Paths[w_Paths.SelectedIndex]).Count;

			for (int j = 0; j < opcodes_in_path; j++)
			{
				var op_value = (byte) ((ArrayList) WM_Paths[w_Paths.SelectedIndex])[j];
				w_PathCodes.Items.Add(w_Opcodes.Items[op_value]);
			}
		}

		private void btnSaveWorldMap_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the world map paths?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var bw = new BinaryWriter(new FileStream(WM_File, FileMode.Create));
			// Save the # of paths
			bw.Write((uint) w_Paths.Items.Count);

			// Save each path
			for (int i = 0; i < w_Paths.Items.Count; i++)
			{
				string PathInfo = w_Paths.Items[i].ToString();
				string[] PathInfo_A = PathInfo.Split('-');
				string Path_Par1 = PathInfo_A[0].Split('(', ')', ',')[1].Trim();
				string Path_Par2 = PathInfo_A[0].Split('(', ')', ',')[2].Trim();
				string Path_Par3 = PathInfo_A[1].Split('(', ')', ',')[1].Trim();
				string Path_Par4 = PathInfo_A[1].Split('(', ')', ',')[2].Trim();
				bw.Write(uint.Parse(Path_Par1));
				bw.Write(uint.Parse(Path_Par2));
				bw.Write(uint.Parse(Path_Par3));
				bw.Write(uint.Parse(Path_Par4));

				int opcodes_in_path = ((ArrayList) WM_Paths[i]).Count;
				bw.Write(opcodes_in_path);

				for (int j = 0; j < opcodes_in_path; j++)
					bw.Write((byte) ((ArrayList) WM_Paths[i])[j]);

				if (opcodes_in_path%4 != 0)
				{
					for (int k = 0; k < (4 - (opcodes_in_path%4)); k++)
						bw.Write((byte) 0xFD);
				}
			}

			bw.Close();

			MessageBox.Show("World map paths saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void w_PathCodes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			var op_value = (byte) ((ArrayList) WM_Paths[w_Paths.SelectedIndex])[w_PathCodes.SelectedIndex];
			w_Opcodes.SelectedIndex = op_value;
			tPathElem.Text = w_PathCodes.SelectedIndex.ToString();
		}

		private void btnDelPath_Click(object sender, EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			if (MessageBox.Show("Are you sure you want to delete this path?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			int pid_to_remove = w_Paths.SelectedIndex;

			WM_Paths.RemoveAt(pid_to_remove);
			w_Paths.Items.RemoveAt(pid_to_remove);
			w_PathCodes.Items.Clear();
		}

		private void btnAddPath_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to add a path with current coordinates?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			w_Paths.Items.Add("#NEW: (" + tPar1.Text + "," + tPar2.Text + ") - (" + tPar3.Text + "," + tPar4.Text + ")");
			WM_Paths.Add(new ArrayList()); // a new path reference

			MessageBox.Show("Path added.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnSetOpcode_Click(object sender, EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			if (w_Opcodes.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an opcode!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			((ArrayList) WM_Paths[w_Paths.SelectedIndex])[w_PathCodes.SelectedIndex] = (byte) w_Opcodes.SelectedIndex;
			w_PathCodes.Items[w_PathCodes.SelectedIndex] = w_Opcodes.Items[w_Opcodes.SelectedIndex];
		}

		private void btnInsertOpcode_Click(object sender, EventArgs e)
		{
			if (w_Opcodes.SelectedIndex == -1)
			{
				MessageBox.Show("Please select an opcode!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (w_PathCodes.SelectedIndex == -1 || w_PathCodes.Items.Count == 0)
			{
				((ArrayList) WM_Paths[w_Paths.SelectedIndex]).Add((byte) w_Opcodes.SelectedIndex);
				w_PathCodes.Items.Add(w_Opcodes.Items[w_Opcodes.SelectedIndex]);
				return;
			}

			((ArrayList) WM_Paths[w_Paths.SelectedIndex]).Insert(w_PathCodes.SelectedIndex, (byte) w_Opcodes.SelectedIndex);
			w_PathCodes.Items.Insert(w_PathCodes.SelectedIndex, w_Opcodes.Items[w_Opcodes.SelectedIndex]);
		}

		private void btnDeleteOpcode_Click(object sender, EventArgs e)
		{
			if (w_PathCodes.SelectedIndex == -1)
				return;

			((ArrayList) WM_Paths[w_Paths.SelectedIndex]).RemoveAt(w_PathCodes.SelectedIndex);
			w_PathCodes.Items.RemoveAt(w_PathCodes.SelectedIndex);
		}

		private void btnUpdatePath_Click(object sender, EventArgs e)
		{
			if (w_Paths.SelectedIndex == -1)
				return;

			w_Paths.Items[w_Paths.SelectedIndex] = "#" + w_Paths.SelectedIndex.ToString() + ": (" + tPar1.Text + "," + tPar2.Text + ") - (" + tPar3.Text + "," + tPar4.Text + ")";
		}

		#endregion

		#region Addin system calls and Path Node Generator

		private void menuItem17_Click(object sender, EventArgs e)
		{
			var p = new PathNodeGen();
			p.ShowDialog();
		}

		#endregion

		#region Proto Search Call and other Tools

		private void dayNightTransitionsEditorToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var dnWnd = new DayNightEd();
			dnWnd.ShowDialog();
		}

		private void prototypeSearchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var psWnd = new ProtoSearch();

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
			MessageBox.Show(
				"Object Viewer: displays a tree-like representation of all objects you have in a specified folder, with their properties in raw state. Allows to view properties which are not editable by the World Builder.\n\nSector Sort Tool: this is a very important utility which must be ran on your sectors if you embedded new static objects in them. It will sort the static objects so they are in correct order for the game to load. Automatically runs on Sectors folder of the ToEE World Builder when started.\n\nScript Override Tool: Compensates for the lack of an option in ToEEWB to directly override scripts in the mobile objects. Allows you to create a scripts entry in a mobile object and override used scripts from there without having to waste precious prototypes. If an object is loaded in ToEEWB, it will automatically be loaded into the Script Override Tool upon startup. Note that if you add the script override and save it in the override tool, you MUST reload the object in ToEEWB, or your override information will be lost!",
				"Addin usage information", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void mobileObjectViewerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
			Process.Start("Addins\\ObjView.exe");
		}

		private void sectorSortUtilityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
			Process.Start("Addins\\SectorSort.exe", "\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\Sectors" + "\"");
		}

		private void scriptOverrideToolToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));

			if (MobileName.Text != "<NO OBJECT LOADED>")
				Process.Start("Addins\\ScriptOverride.exe", "\"" + Path.GetDirectoryName(Application.ExecutablePath) + "\\Mobiles\\" + MobileName.Text + ".mob\"");
			else
				Process.Start("Addins\\ScriptOverride.exe");
		}

		#endregion
	}
}