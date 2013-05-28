using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class ProtoSearch : Form
	{
		public ArrayList protos = new ArrayList();
		public ArrayList protos_complete = new ArrayList();

		public ProtoSearch()
		{
			InitializeComponent();
			searchCtrls = new[]
							{
								psProtoSearch,
								psScriptSearch,
								psPortraitSearch,
								psSpellSearch,
								psFeatSearch,
								psDescriptionSearch,
								psFactionSearch,
								psNameSearch,
								psStrategySearch
							};
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

		private readonly TextBox[] searchCtrls;

		private void button1_Click(object sender, EventArgs e)
		{
			if (!searchCtrls.All(c=>string.IsNullOrEmpty(c.Text)))
			{
				lstResult.Items.Clear();

				//ArrayList a = Prototypes.GetColumnNames();
				for (int i = 0; i < protos_complete.Count; i++)
				{
					string s_Proto = protos_complete[i].ToString();
					string[] proto_details = s_Proto.Replace((char) 0x0B, ' ').Split('\t');
					var s_Proto_ID = proto_details[0]; //todo: what's in the string
					var proto_ID = short.Parse(s_Proto_ID);
					string s_description = MobHelper.ProtoById[proto_ID];


					//23 - name ID
					//portrait - 123
					//factions 154
					//feats 258-267
					//scripts 268-310
					//spells - 312 - 331
					//strat - 333

					int ok_to_go_on = 0;

					//Strategy

					if (proto_details[333].ToUpperInvariant().Contains(psStrategySearch.Text.ToUpperInvariant()) == false)
						continue;

					//Spells
					if (psSpellSearch.Text != "")
					{
						for (int pp = 312; pp < 332; pp++)
						{
							if (proto_details[pp].ToUpperInvariant().Contains(psSpellSearch.Text.ToUpperInvariant()))
								ok_to_go_on = 1;
						}
						if (ok_to_go_on == 0)
							continue;
					}

					//Scripts
					if (psScriptSearch.Text != "")
					{
						string script_ahoy = psScriptTypeDropDown.Text.ToUpperInvariant();
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
								if (proto_details[pp].ToUpperInvariant().Contains(psScriptSearch.Text.ToUpperInvariant()))
									ok_to_go_on = 1;
							}
						}
						if (script_index != 0)
						{
							if (proto_details[script_index].ToUpperInvariant().Contains(psScriptSearch.Text.ToUpperInvariant()))
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
							if (proto_details[pp].ToUpperInvariant().Contains(psFeatSearch.Text.ToUpperInvariant()))
								ok_to_go_on = 1;
						}
						if (ok_to_go_on == 0)
							continue;
					}

					//Faction
					if (proto_details[154].ToUpperInvariant().Contains(psFactionSearch.Text.ToUpperInvariant()) == false)
						continue;

					//Portrait
					if (proto_details[123].ToUpperInvariant().Contains(psPortraitSearch.Text.ToUpperInvariant()) == false)
						continue;

					if (proto_details[23].ToUpperInvariant().Contains(psNameSearch.Text.ToUpperInvariant()) == false)
						continue;

					// finally, ID and Description
					if (s_description.ToUpperInvariant().Contains(psDescriptionSearch.Text.ToUpperInvariant()) &&
						s_Proto_ID.Contains(psProtoSearch.Text.ToUpperInvariant()))
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