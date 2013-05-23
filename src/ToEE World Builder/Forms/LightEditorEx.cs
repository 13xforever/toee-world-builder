using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class LightEditorEx : Form
	{
		public string cur_sector = ""; // current sector file to be edited
		public ArrayList data = new ArrayList(); // other data in the sector besides lights
		public bool int_state = false; // interface state
		public LightExHelper.LightEx light = new LightExHelper.LightEx(); // a light to be edited
		public List<LightExHelper.LightEx> lights = new List<LightExHelper.LightEx>(); // a collection of all lights to process

		public LightEditorEx()
		{
			InitializeComponent();
		}

		// write back a basic light
		public void WriteLightPrimary(BinaryWriter w_sec, LightExHelper.LightEx light)
		{
			w_sec.Write(light.light_pri.light1.handle);
			w_sec.Write(light.light_pri.light1.flags);
			w_sec.Write(light.light_pri.light1.type);
			w_sec.Write(light.light_pri.light1.red);
			w_sec.Write(light.light_pri.light1.green);
			w_sec.Write(light.light_pri.light1.blue);
			w_sec.Write(light.light_pri.light1.padding1);
			w_sec.Write(light.light_pri.light1.padding2);
			w_sec.Write(light.light_pri.light1.x);
			w_sec.Write(light.light_pri.light1.y);
			w_sec.Write(light.light_pri.light1.ofs_x);
			w_sec.Write(light.light_pri.light1.ofs_y);
			w_sec.Write(light.light_pri.light1.height);
			w_sec.Write(light.light_pri.light1.direction.x);
			w_sec.Write(light.light_pri.light1.direction.y);
			w_sec.Write(light.light_pri.light1.direction.z);
			w_sec.Write(light.light_pri.light1.range);
			w_sec.Write(light.light_pri.light1.angle);
		}

		// write back the primary light particle system
		public void WriteLightPartSys(BinaryWriter w_sec, LightExHelper.LightEx light)
		{
			w_sec.Write(light.light_pri.partsys1.hash_id);
			w_sec.Write(light.light_pri.partsys1.id);
		}

		// write back the secondary light structure
		public void WriteLightSecondary(BinaryWriter w_sec, LightExHelper.LightEx light)
		{
			w_sec.Write(light.light_sec.type);
			w_sec.Write(light.light_sec.red);
			w_sec.Write(light.light_sec.green);
			w_sec.Write(light.light_sec.blue);
			w_sec.Write(light.light_sec.padding1);
			w_sec.Write(light.light_sec.direction.x);
			w_sec.Write(light.light_sec.direction.y);
			w_sec.Write(light.light_sec.direction.z);
			w_sec.Write(light.light_sec.range);
			w_sec.Write(light.light_sec.angle);
			w_sec.Write(light.light_sec.partsys2.hash_id);
			w_sec.Write(light.light_sec.partsys2.id);
		}

		// write back a complete 107-byte light
		public void WriteLightComplete(BinaryWriter w_sec, LightExHelper.LightEx light)
		{
			WriteLightPrimary(w_sec, light);
			WriteLightPartSys(w_sec, light);
			WriteLightSecondary(w_sec, light);
		}

		// write back a complete light depending on the required format
		public void WriteLightCompleteEx(BinaryWriter w_sec, LightExHelper.LightEx light, bool StorePrimaryPartsys, bool StoreSecondaryLight, bool StoreData)
		{
			WriteLightPrimary(w_sec, light);
			if ((StorePrimaryPartsys) || (StoreSecondaryLight))
				WriteLightPartSys(w_sec, light);
			if (StoreSecondaryLight)
				WriteLightSecondary(w_sec, light);
			if (StoreData)
			{
				for (int i = 0; i < data.Count; i++)
				{
					w_sec.Write((byte) data[i]);
				}
			}
		}

		// create 32-bit flags based on currently set options
		private uint GetLightFlags()
		{
			string FLAGS_BMP = MobHelper.CreateBitmap(4);

			if (StateOn.Checked)
			{
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 1);
			}
			else if (StateLockedOn.Checked)
			{
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 0);
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 1);
			}
			else if (StateDestroyed.Checked)
			{
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 0);
			}

			if (FlagAnimated.Checked)
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 2);
			if (FlagViewControls.Checked)
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 3);
			if (FlagUsePrimaryLight.Checked)
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 4);
			if (FlagUsePriPartSys.Checked)
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 5);
			if (FlagUseSecondaryLight.Checked)
				FLAGS_BMP = MobHelper.SetProperty(FLAGS_BMP, 6);

			return GenHelper.BitmapToUInt32(FLAGS_BMP);
		}

		// set flag checkboxes based on a 32-bit flag field
		private void SetLightFlags(uint flags)
		{
			string FLAGS_BMP = GenHelper.UInt32ToBitmap(flags);

			if ((FLAGS_BMP[0] == '0') && (FLAGS_BMP[1] == '0'))
			{
				StateOff.Checked = true;
				StateOn.Checked = false;
				StateDestroyed.Checked = false;
				StateLockedOn.Checked = false;
			}
			else if ((FLAGS_BMP[0] == '1') && (FLAGS_BMP[1] == '1'))
			{
				StateOff.Checked = false;
				StateOn.Checked = false;
				StateDestroyed.Checked = false;
				StateLockedOn.Checked = true;
			}
			else if ((FLAGS_BMP[0] == '0') && (FLAGS_BMP[1] == '1'))
			{
				StateOff.Checked = false;
				StateOn.Checked = true;
				StateDestroyed.Checked = false;
				StateLockedOn.Checked = false;
			}
			else if ((FLAGS_BMP[0] == '1') && (FLAGS_BMP[1] == '0'))
			{
				StateOff.Checked = false;
				StateOn.Checked = false;
				StateDestroyed.Checked = true;
				StateLockedOn.Checked = false;
			}

			if (MobHelper.GetPropertyState(FLAGS_BMP, 2) == TriState.True)
				FlagAnimated.Checked = true;
			else
				FlagAnimated.Checked = false;

			if (MobHelper.GetPropertyState(FLAGS_BMP, 3) == TriState.True)
				FlagViewControls.Checked = true;
			else
				FlagViewControls.Checked = false;

			if (MobHelper.GetPropertyState(FLAGS_BMP, 4) == TriState.True)
				FlagUsePrimaryLight.Checked = true;
			else
				FlagUsePrimaryLight.Checked = false;

			if (MobHelper.GetPropertyState(FLAGS_BMP, 5) == TriState.True)
				FlagUsePriPartSys.Checked = true;
			else
				FlagUsePriPartSys.Checked = false;

			if (MobHelper.GetPropertyState(FLAGS_BMP, 6) == TriState.True)
				FlagUseSecondaryLight.Checked = true;
			else
				FlagUseSecondaryLight.Checked = false;
		}

		// load up a light structure from the current parameters
		private LightExHelper.LightEx SetupLightStruct()
		{
			var _light = new LightExHelper.LightEx();

			_light.light_pri.light1.handle = 0;
			_light.light_pri.light1.flags = GetLightFlags();
			_light.light_pri.light1.type = (uint) PriLightType.SelectedIndex;
			_light.light_pri.light1.red = byte.Parse(PriRed.Text);
			_light.light_pri.light1.green = byte.Parse(PriGreen.Text);
			_light.light_pri.light1.blue = byte.Parse(PriBlue.Text);
			_light.light_pri.light1.padding1 = 0;
			_light.light_pri.light1.padding2 = 0;
			_light.light_pri.light1.x = uint.Parse(PriX.Text);
			_light.light_pri.light1.y = uint.Parse(PriY.Text);
			_light.light_pri.light1.ofs_x = float.Parse(PriOfsX.Text);
			_light.light_pri.light1.ofs_y = float.Parse(PriOfsY.Text);
			_light.light_pri.light1.height = float.Parse(PriHeight.Text);
			_light.light_pri.light1.direction.x = float.Parse(PriDirX.Text);
			_light.light_pri.light1.direction.y = float.Parse(PriDirY.Text);
			_light.light_pri.light1.direction.z = float.Parse(PriDirZ.Text);
			_light.light_pri.light1.range = float.Parse(PriRange.Text);
			_light.light_pri.light1.angle = float.Parse(PriAngle.Text);
			_light.light_pri.partsys1.hash_id = uint.Parse(PriPartsysHash.Text);
			_light.light_pri.partsys1.id = uint.Parse(PriPartsysID.Text);
			_light.light_sec.type = (uint) SecLightType.SelectedIndex;
			_light.light_sec.red = byte.Parse(SecRed.Text);
			_light.light_sec.green = byte.Parse(SecGreen.Text);
			_light.light_sec.blue = byte.Parse(SecBlue.Text);
			_light.light_sec.padding1 = 0;
			_light.light_sec.direction.x = float.Parse(SecDirX.Text);
			_light.light_sec.direction.y = float.Parse(SecDirY.Text);
			_light.light_sec.direction.z = float.Parse(SecDirZ.Text);
			_light.light_sec.range = float.Parse(SecRange.Text);
			_light.light_sec.angle = float.Parse(SecAngle.Text);
			_light.light_sec.partsys2.hash_id = uint.Parse(SecPartsysHash.Text);
			_light.light_sec.partsys2.id = uint.Parse(SecPartsysID.Text);

			return _light;
		}

		// set current parameters according to the light structure passed
		private void LoadLightStruct(LightExHelper.LightEx _light)
		{
			SetLightFlags(_light.light_pri.light1.flags);
			PriLightType.SelectedIndex = (int) _light.light_pri.light1.type;
			PriRed.Text = _light.light_pri.light1.red.ToString();
			PriGreen.Text = _light.light_pri.light1.green.ToString();
			PriBlue.Text = _light.light_pri.light1.blue.ToString();
			PriX.Text = _light.light_pri.light1.x.ToString();
			PriY.Text = _light.light_pri.light1.y.ToString();
			PriOfsX.Text = _light.light_pri.light1.ofs_x.ToString();
			PriOfsY.Text = _light.light_pri.light1.ofs_y.ToString();
			PriHeight.Text = _light.light_pri.light1.height.ToString();
			PriDirX.Text = _light.light_pri.light1.direction.x.ToString();
			PriDirY.Text = _light.light_pri.light1.direction.y.ToString();
			PriDirZ.Text = _light.light_pri.light1.direction.z.ToString();
			PriRange.Text = _light.light_pri.light1.range.ToString();
			PriAngle.Text = _light.light_pri.light1.angle.ToString();
			PriPartsysHash.Text = _light.light_pri.partsys1.hash_id.ToString();
			PriPartsysID.Text = _light.light_pri.partsys1.id.ToString();
			SecLightType.SelectedIndex = (int) _light.light_sec.type;
			SecRed.Text = _light.light_sec.red.ToString();
			SecGreen.Text = _light.light_sec.green.ToString();
			SecBlue.Text = _light.light_sec.blue.ToString();
			SecDirX.Text = _light.light_sec.direction.x.ToString();
			SecDirY.Text = _light.light_sec.direction.y.ToString();
			SecDirZ.Text = _light.light_sec.direction.z.ToString();
			SecRange.Text = _light.light_sec.range.ToString();
			SecAngle.Text = _light.light_sec.angle.ToString();
			SecPartsysHash.Text = _light.light_sec.partsys2.hash_id.ToString();
			SecPartsysID.Text = _light.light_sec.partsys2.id.ToString();
		}

		// Load a single light from a sector file, at the current position.
		public static LightExHelper.LightEx LoadLightFromSEC(BinaryReader br)
		{
			var _light = new LightExHelper.LightEx();
			bool HAS_PRIMARY_PARTSYS = false;
			bool HAS_SECONDARY_LIGHT = false;
			string FLAG_BITMAP;

			_light.light_pri.light1.handle = br.ReadUInt64();

			_light.light_pri.light1.flags = br.ReadUInt32();
			FLAG_BITMAP = GenHelper.UInt32ToBitmap(_light.light_pri.light1.flags);
			if (MobHelper.GetPropertyState(FLAG_BITMAP, 5) == TriState.True)
				HAS_PRIMARY_PARTSYS = true;
			if (MobHelper.GetPropertyState(FLAG_BITMAP, 6) == TriState.True)
				HAS_SECONDARY_LIGHT = true;

			_light.light_pri.light1.type = br.ReadUInt32();
			_light.light_pri.light1.red = br.ReadByte();
			_light.light_pri.light1.green = br.ReadByte();
			_light.light_pri.light1.blue = br.ReadByte();
			_light.light_pri.light1.padding1 = br.ReadByte();
			_light.light_pri.light1.padding2 = br.ReadUInt32();
			_light.light_pri.light1.x = br.ReadUInt32();
			_light.light_pri.light1.y = br.ReadUInt32();
			_light.light_pri.light1.ofs_x = br.ReadSingle();
			_light.light_pri.light1.ofs_y = br.ReadSingle();
			_light.light_pri.light1.height = br.ReadSingle();
			_light.light_pri.light1.direction.x = br.ReadSingle();
			_light.light_pri.light1.direction.y = br.ReadSingle();
			_light.light_pri.light1.direction.z = br.ReadSingle();
			_light.light_pri.light1.range = br.ReadSingle();
			_light.light_pri.light1.angle = br.ReadSingle();

			if ((HAS_PRIMARY_PARTSYS) || (HAS_SECONDARY_LIGHT))
			{
				_light.light_pri.partsys1.hash_id = br.ReadUInt32();
				_light.light_pri.partsys1.id = br.ReadUInt32();
			}

			if (HAS_SECONDARY_LIGHT)
			{
				_light.light_sec.type = br.ReadUInt32();
				_light.light_sec.red = br.ReadByte();
				_light.light_sec.green = br.ReadByte();
				_light.light_sec.blue = br.ReadByte();
				_light.light_sec.padding1 = br.ReadByte();
				_light.light_sec.direction.x = br.ReadSingle();
				_light.light_sec.direction.y = br.ReadSingle();
				_light.light_sec.direction.z = br.ReadSingle();
				_light.light_sec.range = br.ReadSingle();
				_light.light_sec.angle = br.ReadSingle();
				_light.light_sec.partsys2.hash_id = br.ReadUInt32();
				_light.light_sec.partsys2.id = br.ReadUInt32();
			}

			return _light;
		}

		// Loads the post-light data from a sector file
		private void LoadDataFromSEC(BinaryReader br)
		{
			data.Clear();
			while (br.BaseStream.Position != br.BaseStream.Length)
			{
				data.Add(br.ReadByte());
			}
		}

		// Load all lights from a sector file, and load the data
		private void LoadSectorLightInfo(BinaryReader br)
		{
			lights.Clear();
			int NUM_LIGHTS = br.ReadInt32();

			if (NUM_LIGHTS == 0)
			{
				LoadDataFromSEC(br);
				return;
			}

			for (int i = 0; i < NUM_LIGHTS; i++)
			{
				lights.Add(LoadLightFromSEC(br));
			}

			LoadDataFromSEC(br);
		}

		// Dump all lights into a sector file, and append the data
		private void SaveSectorLightInfo(BinaryWriter bw)
		{
			bw.Write(lights.Count);

			for (int i = 0; i < lights.Count; i++)
			{
				var lt = (LightExHelper.LightEx) lights[i];
				bool HAS_PRIMARY_PARTSYS = false;
				bool HAS_SECONDARY_LIGHT = false;

				string FLAG_BITMAP = GenHelper.UInt32ToBitmap(lt.light_pri.light1.flags);
				if (MobHelper.GetPropertyState(FLAG_BITMAP, 5) == TriState.True)
					HAS_PRIMARY_PARTSYS = true;
				if (MobHelper.GetPropertyState(FLAG_BITMAP, 6) == TriState.True)
					HAS_SECONDARY_LIGHT = true;

				WriteLightCompleteEx(bw, lt, HAS_PRIMARY_PARTSYS, HAS_SECONDARY_LIGHT, false);
			}

			for (int i = 0; i < data.Count; i++)
			{
				bw.Write((byte) data[i]);
			}
		}

		private void btnOpenSector_Click(object sender, EventArgs e)
		{
			var oDlg = new OpenSEC();
			if (oDlg.ShowDialog() == DialogResult.OK)
			{
				cur_sector = "Sectors\\" + oDlg.FileToOpen + ".sec";
				CurSector.Text = oDlg.FileToOpen + ".sec";

				var r_sec = new BinaryReader(new FileStream(cur_sector, FileMode.Open));
				LoadSectorLightInfo(r_sec);
				r_sec.Close();

				SetLightEdInterfaceState(true);

				if (lights.Count > 0)
					LoadLightStruct(LightByID(0));
				else
				{
					MessageBox.Show("There are currently no lights in this sector.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
					SetLightEdButtonState(1);
					ResetLightProps();
				}

				CurLight.Value = 0;
				if (lights.Count != 0)
					CurLight.Maximum = lights.Count - 1;
				else
					CurLight.Maximum = 0;
				r_sec.Close();

				PriLightType.SelectedIndex = 1;
				SecLightType.SelectedIndex = 1;

				CurLight_ValueChanged(sender, e);

				if (lights.Count == 0)
				{
					PriLightType.SelectedIndex = 0;
					SecLightType.SelectedIndex = 0;
				}
			}
		}

		private void btnQuit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void LightEditorEx_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit the Light Editor?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				e.Cancel = true;
		}

		private void SetLightEdInterfaceState(bool state)
		{
			int_state = state;
			CurLight.Enabled = state;
			StateOff.Enabled = state;
			StateOn.Enabled = state;
			StateDestroyed.Enabled = state;
			StateLockedOn.Enabled = state;
			PriLightType.Enabled = state;
			PriRed.Enabled = state;
			PriGreen.Enabled = state;
			PriBlue.Enabled = state;
			PriX.Enabled = state;
			PriY.Enabled = state;
			PriOfsX.Enabled = state;
			PriOfsY.Enabled = state;
			PriHeight.Enabled = state;
			PriDirX.Enabled = state;
			PriDirY.Enabled = state;
			PriDirZ.Enabled = state;
			PriRange.Enabled = state;
			PriAngle.Enabled = state;
			PriPartsysHash.Enabled = state;
			PriPartsysID.Enabled = state;
			SecLightType.Enabled = state;
			SecRed.Enabled = state;
			SecGreen.Enabled = state;
			SecBlue.Enabled = state;
			SecDirX.Enabled = state;
			SecDirY.Enabled = state;
			SecDirZ.Enabled = state;
			SecRange.Enabled = state;
			SecAngle.Enabled = state;
			SecPartsysHash.Enabled = state;
			SecPartsysID.Enabled = state;
			btnAddLight.Enabled = state;
			btnUpdateLight.Enabled = state;
			btnDeleteLight.Enabled = state;
			btnSaveSector.Enabled = state;
			FlagAnimated.Enabled = state;
			FlagViewControls.Enabled = state;
			FlagUsePrimaryLight.Enabled = state;
			FlagUsePriPartSys.Enabled = state;
			FlagUseSecondaryLight.Enabled = state;
			btnSetColor1.Enabled = state;
			btnSetColor2.Enabled = state;
			btnCreateHash1.Enabled = state;
			btnCreateHash2.Enabled = state;
		}

		private void SetLightEdButtonState(int state_id)
		{
			if (state_id == 0)
			{
				btnAddLight.Enabled = false;
				btnUpdateLight.Enabled = false;
				btnDeleteLight.Enabled = false;
			}
			else if (state_id == 1)
			{
				btnAddLight.Enabled = true;
				btnUpdateLight.Enabled = false;
				btnDeleteLight.Enabled = false;
			}
			else if (state_id == 2)
			{
				btnAddLight.Enabled = true;
				btnUpdateLight.Enabled = true;
				btnDeleteLight.Enabled = true;
			}
		}

		private void ResetLightProps()
		{
			PriRed.Text = "0";
			PriGreen.Text = "0";
			PriBlue.Text = "0";
			PriOfsX.Text = "0";
			PriOfsY.Text = "0";
			PriPartsysHash.Text = "0";
			PriPartsysID.Text = "0";
			PriRange.Text = "0";
			PriAngle.Text = "0";
			PriDirX.Text = "0";
			PriDirY.Text = "0";
			PriDirZ.Text = "0";
			PriHeight.Text = "0";
			PriX.Text = "0";
			PriY.Text = "0";
			PriLightType.SelectedIndex = 0;
			SecRed.Text = "0";
			SecGreen.Text = "0";
			SecBlue.Text = "0";
			SecPartsysHash.Text = "0";
			SecPartsysID.Text = "0";
			SecRange.Text = "0";
			SecAngle.Text = "0";
			SecDirX.Text = "0";
			SecDirY.Text = "0";
			SecDirZ.Text = "0";
			SecLightType.SelectedIndex = 0;
			FlagAnimated.Checked = false;
			FlagUsePrimaryLight.Checked = false;
			FlagUsePriPartSys.Checked = false;
			FlagUseSecondaryLight.Checked = false;
			FlagViewControls.Checked = false;
		}

		private void LightEditorEx_Load(object sender, EventArgs e)
		{
			SetLightEdInterfaceState(false); // disable buttons by default
			tmrLGT.Enabled = true;
		}

		// returns a light from an array by ID
		private LightExHelper.LightEx LightByID(int id)
		{
			return (LightExHelper.LightEx) lights[id];
		}

		private void CurLight_ValueChanged(object sender, EventArgs e)
		{
			if (lights.Count > 0)
				LoadLightStruct(LightByID((int) CurLight.Value));
		}

		private void btnSaveSector_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to save the sector file?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			var bw = new BinaryWriter(new FileStream(cur_sector, FileMode.Create));
			SaveSectorLightInfo(bw);
			bw.Close();

			MessageBox.Show("Sector saved.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnAddLight_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to create a new light based on the current prototype?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (btnDeleteLight.Enabled == false)
			{
				// there were no lights for this sector, so we need to create a
				// bank for lights on this map
				SetLightEdButtonState(2);
				lights.Add(SetupLightStruct());
				CurLight.Minimum = 0;
				CurLight.Value = 0;
				CurLight.Maximum = 0;
				CurLight_ValueChanged(null, null);
			}
			else
			{
				// just add a new light to this map, use the current light as a prototype
				lights.Add(SetupLightStruct());
				CurLight.Maximum++;
				CurLight.Value = CurLight.Maximum; //auto pass parameters
			}

			MessageBox.Show("Light added.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnUpdateLight_Click(object sender, EventArgs e)
		{
			lights[(int) CurLight.Value] = SetupLightStruct();
			MessageBox.Show("Light updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnDeleteLight_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete the current light?", "Please confirm operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return;

			if (CurLight.Value != 0)
			{
				lights.RemoveAt((int) CurLight.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				var p_lightarr = new  List<LightExHelper.LightEx>();

				for (int i = 0; i < lights.Count; i++)
					p_lightarr.Add(lights[i]);

				lights = p_lightarr;

				CurLight.Value = 0;
				CurLight.Maximum = lights.Count - 1;

				MessageBox.Show("Light deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				// Light ID = #0
				lights.RemoveAt((int) CurLight.Value);

				// Now, tricky stuff: we have to reload the lights and rearrange all
				// the IDs
				if (lights.Count > 0)
				{
					var p_lightarr = new List<LightExHelper.LightEx>();

					for (int i = 0; i < lights.Count; i++)
						p_lightarr.Add(lights[i]);

					SecHelper.SectorLights = p_lightarr;
					CurLight.Value = 0;
					CurLight.Maximum--;
					CurLight_ValueChanged(null, null); // update #0 location
				}
				else
				{
					lights.Clear();
					SetLightEdButtonState(1);
				}

				MessageBox.Show("Light deleted.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnSetColor1_Click(object sender, EventArgs e)
		{
			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				PriRed.Text = colorDlg.Color.R.ToString();
				PriBlue.Text = colorDlg.Color.G.ToString();
				PriGreen.Text = colorDlg.Color.B.ToString();
			}
		}

		private void btnSetColor2_Click(object sender, EventArgs e)
		{
			if (colorDlg.ShowDialog() == DialogResult.OK)
			{
				SecRed.Text = colorDlg.Color.R.ToString();
				SecBlue.Text = colorDlg.Color.G.ToString();
				SecGreen.Text = colorDlg.Color.B.ToString();
			}
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"1. The animation special effect (particle system) of the lights is defined by the Particle System Hash IDs. The generic IDs seem to have NO effect, only the Hash IDs allow you to change what animation/special FX the light uses. You can use the 'Create...' buttons to create particle hash IDs from the corresponding particle system names found in PARTSYS0.TAB.\n\n2. I honestly don't know what View Controls flag does, it might have been used in the original game editor, or it may have some effect on the light. If you find out what it means, please tell me.\n\n3. If you get weird slowdowns or CTDs after you have added a light, there's a big chance that you set up the light flags incorrectly. If the light doesn't have the Secondary Light for night (so 'Uses Secondary Light' is disabled), it seems like you MUST select the 'Uses Primary Light' flag, otherwise the game will CTD or behave weirdly. On the other hand, it looks like it's not necessary to set up the 'Uses Primary Light' flag if you have the 'Uses Secondary Light' flag set (I may be wrong here though). Please consult the original game lights to gather more information about how the flags should be set up.\n\n4. Don't forget that you can use the '...' buttons to define colors of your lights easily.",
				"Light Editor Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnCreateHash1_Click(object sender, EventArgs e)
		{
			var cp = new CreatePartsysHID();
			if (cp.ShowDialog() == DialogResult.OK)
			{
				PriPartsysHash.Text = cp.HID;
			}
		}

		private void btnCreateHash2_Click(object sender, EventArgs e)
		{
			var cp = new CreatePartsysHID();
			if (cp.ShowDialog() == DialogResult.OK)
			{
				SecPartsysHash.Text = cp.HID;
			}
		}

		private void tmrLGT_Tick(object sender, EventArgs e)
		{
			// v2.0.0: Interoperability with ToEE console support
			if (File.Exists(MobHelper.InteropPath))
			{
				string wbl_data = "";
				bool DATA_PASS_ON = false;
				try
				{
					var sr = new StreamReader(MobHelper.InteropPath);
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
						case "LGTLOC": // location -> light coords
							if (PriX.Enabled)
							{
								File.Delete(MobHelper.InteropPath);
								PriX.Text = wbl_data_arr[1];
								PriY.Text = wbl_data_arr[2];
								return;
							}
							else
							{
								File.Delete(MobHelper.InteropPath);
								MessageBox.Show("Please open a sector file in the light editor first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								return;
							}
						default:
							DATA_PASS_ON = true;
							break;
					}

					if (!DATA_PASS_ON)
						File.Delete(MobHelper.InteropPath);
				}
			}
		}
	}
}