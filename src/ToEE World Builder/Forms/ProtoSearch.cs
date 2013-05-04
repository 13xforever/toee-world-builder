using System;
using System.Collections;
using System.Windows.Forms;

namespace WorldBuilder
{
	public partial class ProtoSearch : Form
	{
		public ArrayList protos = new ArrayList();
		public ArrayList protos_complete = new ArrayList();

		public ProtoSearch()
		{
			InitializeComponent();
		}

		private void btnSearchProto_Click(object sender, EventArgs e)
		{
			if (psCriterion.Text != "")
			{
				lstResult.Items.Clear();

				for (int i = 0; i < protos.Count; i++)
				{
					string s_Proto = protos[i].ToString();
					if (s_Proto.ToLower().Contains(psCriterion.Text.ToLower()))
						lstResult.Items.Add(s_Proto);
				}

				if (lstResult.Items.Count == 0)
					MessageBox.Show("The search returned no results.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void lstResult_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstResult.Items.Count == 0)
				return;
			if (lstResult.SelectedIndex == -1)
				return;

			// Invoke a system message to load the proto/object editor
			SysMsg.SM_PROTO_SEARCH_PARAM = lstResult.Items[lstResult.SelectedIndex].ToString();
			SysMsg.SM_PROTO_SEARCH_TARGET = rbTargetProtos.Checked ? 0 : 1;
			SysMsg.SM_PROTO_SEARCH = true;
		}

		private void psCriterion_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void psCriterion_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnSearchProto_Click(null, null);
			}
		}


		private void button2_Click(object sender, EventArgs e)
		{
			if (button2.Text == "Advanced Search...")
			{
				//this.Size = System.Drawing.Size(468, 530);
				button2.Text = "Simple Search...";
				button1.Visible = true;
				label4.Visible = true;
				label5.Visible = true;
				label6.Visible = true;
				label7.Visible = true;
				label8.Visible = true;
				label9.Visible = true;
				psProtoLabel.Visible = true;
				psDescriptionLabel.Visible = true;
				psProtoSearch.Visible = true;
				psDescriptionSearch.Visible = true;
				psStrategyLabel.Visible = true;
				psNameLabel.Visible = true;
				psNameSearch.Visible = true;
				psStrategySearch.Visible = true;
				psScriptSearch.Visible = true;
				psPortraitSearch.Visible = true;
				psSpellSearch.Visible = true;
				psFeatSearch.Visible = true;
				psFactionSearch.Visible = true;
				psScriptTypeDropDown.Visible = true;
				label1.Visible = false;
				psCriterion.Visible = false;
				btnSearchProto.Visible = false;
			}
			else
			{
				//this.Size = System.Drawing.Size(468, 530);
				button2.Text = "Advanced Search...";
				button1.Visible = false;
				label4.Visible = false;
				label5.Visible = false;
				label6.Visible = false;
				label7.Visible = false;
				label8.Visible = false;
				label9.Visible = false;
				psProtoLabel.Visible = false;
				psDescriptionLabel.Visible = false;
				psProtoSearch.Visible = false;
				psDescriptionSearch.Visible = false;
				psStrategyLabel.Visible = false;
				psNameLabel.Visible = false;
				psNameSearch.Visible = false;
				psStrategySearch.Visible = false;
				psScriptSearch.Visible = false;
				psPortraitSearch.Visible = false;
				psSpellSearch.Visible = false;
				psFeatSearch.Visible = false;
				psFactionSearch.Visible = false;
				psScriptTypeDropDown.Visible = false;
				label1.Visible = true;
				psCriterion.Visible = true;
				btnSearchProto.Visible = true;
			}
		}

		private void label3_Click_1(object sender, EventArgs e)
		{
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
		}

		private void ProtoSearch_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (psProtoSearch.Text != "" || psScriptSearch.Text != "" || psPortraitSearch.Text != "" || psSpellSearch.Text != "" || psFeatSearch.Text != "" || psDescriptionSearch.Text != "" || psFactionSearch.Text != "" || psNameSearch.Text != "" ||
				psStrategySearch.Text != "")
			{
				lstResult.Items.Clear();

				//ArrayList a = ProHelper.PRO_GetColumnNames();
				for (int i = 0; i < protos_complete.Count; i++)
				{
					string s_Proto = protos_complete[i].ToString();
					string[] proto_details = s_Proto.Replace((char) 0x0B, ' ').Split('\t');
					string s_Proto_ID = proto_details[0];
					string s_description = Helper.Proto_By_ID[s_Proto_ID].ToString();


					//23 - name ID
					//portrait - 123
					//factions 154
					//feats 258-267
					//scripts 268-310
					//spells - 312 - 331
					//strat - 333

					int ok_to_go_on = 0;

					//Strategy

					if (proto_details[333].ToLower().Contains(psStrategySearch.Text.ToLower()) == false)
						continue;

					//Spells
					if (psSpellSearch.Text != "")
					{
						for (int pp = 312; pp < 332; pp++)
						{
							if (proto_details[pp].ToLower().Contains(psSpellSearch.Text.ToLower()))
								ok_to_go_on = 1;
						}
						if (ok_to_go_on == 0)
							continue;
					}

					//Scripts
					if (psScriptSearch.Text != "")
					{
						string script_ahoy = psScriptTypeDropDown.Text.ToLower();
						int script_index = 0;
						switch (script_ahoy)
						{
							case "san_dialog":
								script_index = 277;
								break;
							case "san_first_heartbeat":
								script_index = 278;
								break;
							case "san_dying":
								script_index = 280;
								break;
							case "san_enter_combat":
								script_index = 281;
								break;
							case "san_exit_combat":
								script_index = 282;
								break;
							case "san_start_combat":
								script_index = 283;
								break;
							case "san_end_combat":
								script_index = 284;
								break;
							case "san_heartbeat":
								script_index = 287;
								break;
							case "san_insert_item":
								script_index = 289;
								break;
							case "san_remove_item":
								script_index = 296;
								break;
							case "san_join":
								script_index = 304;
								break;
							case "san_disband":
								script_index = 305;
								break;
							case "san_new_map":
								script_index = 306;
								break;
							case "san_trap":
								script_index = 307;
								break;
							case "san_spell_cast":
								script_index = 309;
								break;
							case "san_unlock_attempt":
								script_index = 310;
								break;
							default:
								script_index = 0;
								break;
						}
						ok_to_go_on = 0;
						if (script_index == 0)
						{
							for (int pp = 268; pp < 311; pp++)
							{
								if (proto_details[pp].ToLower().Contains(psScriptSearch.Text.ToLower()))
									ok_to_go_on = 1;
							}
						}
						if (script_index != 0)
						{
							if (proto_details[script_index].ToLower().Contains(psScriptSearch.Text.ToLower()))
								ok_to_go_on = 1;
						}
						if (ok_to_go_on == 0)
							continue;
					}

					//Feats
					if (psFeatSearch.Text != "")
					{
						ok_to_go_on = 0;
						for (int pp = 258; pp < 268; pp++)
						{
							if (proto_details[pp].ToLower().Contains(psFeatSearch.Text.ToLower()))
								ok_to_go_on = 1;
						}
						if (ok_to_go_on == 0)
							continue;
					}

					//Faction
					if (proto_details[154].ToLower().Contains(psFactionSearch.Text.ToLower()) == false)
						continue;

					//Portrait
					if (proto_details[123].ToLower().Contains(psPortraitSearch.Text.ToLower()) == false)
						continue;

					if (proto_details[23].ToLower().Contains(psNameSearch.Text.ToLower()) == false)
						continue;

					// finally, ID and Description
					if (s_description.ToLower().Contains(psDescriptionSearch.Text.ToLower()) && s_Proto_ID.Contains(psProtoSearch.Text.ToLower()))
					{
						lstResult.Items.Add(s_description + " -> #" + proto_details[0]);
					}
				}

				if (lstResult.Items.Count == 0)
					MessageBox.Show("The search returned no results.", "No results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
	}
}