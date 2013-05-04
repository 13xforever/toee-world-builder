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
using System.Collections;
using System.IO;

namespace WorldBuilder
{
	/// <summary>
	/// Helper class for protos editor
	/// </summary>
	public class ProHelper
	{
		public ProHelper(){}

        // Default column names, loaded before the patch file is parsed
		public static ArrayList PRO_GetColumnNames()
		{
			ArrayList ar = new ArrayList();

			for (int i=0; i<334; i++)
				ar.Add(("Unknown #"+(i+1).ToString().PadRight(20,' ')+"|\t"));

			ar[0] = "Line Number                  |\t";
			ar[1] = "Object Type                  |\t";
			//ar[2] = "Description                  |\t";
			ar[6] = "Model Scale (%)              |\t";
			ar[20] = "Object Flags                 |\t";
			ar[21] = "Spell Flags                  |\t";
			ar[23] = "Description ID               |\t";
			ar[24] = "Object Size                  |\t";
			ar[27] = "Material                     |\t";
			ar[30] = "Category (per category.mes)  |\t";
			ar[31] = "Rotation                     |\t";
			ar[32] = "Speed (walk)                 |\t";
			ar[33] = "Speed (run)                  |\t";
			ar[34] = "Object Model                 |\t";
			ar[35] = "Target Size                  |\t";
            ar[37] = "Portal Flags                 |\t";
			ar[38] = "Portal Picklock DC           |\t";
			ar[39] = "Portal Trap/Key ID           |\t";
			ar[41] = "Container Flags              |\t";
			ar[42] = "Container Lock DC            |\t";
			ar[43] = "Container Key/Trap ID        |\t";
			ar[44] = "Cont./NPC Inventory Source   |\t";
			ar[50] = "Item Flags                   |\t";
			ar[51] = "Item Weight                  |\t";
			ar[52] = "Item Value (in copper)       |\t";
            ar[53] = "Inventory Icon               |\t";
			ar[55] = "Unidentified Description ID  |\t";
            ar[59] = "Number of Charges            |\t";
			ar[61] = "Equipment Slot Flags         |\t";
			ar[62] = "Object Color (?)             |\t";
			ar[63] = "Weapon Flags                 |\t";
			ar[64] = "Weapon Range                 |\t";
			ar[65] = "Ammo type                    |\t";
			ar[68] = "Critical Hit Multiplier      |\t";
			ar[69] = "Damage Type                  |\t";
			ar[70] = "Damage Dice                  |\t";
			ar[72] = "Weapon Class                 |\t";
            ar[73] = "Critical Hit Threat Range    |\t";
			ar[75] = "Stack Size                   |\t";
			ar[76] = "Ammo Type                    |\t";
			ar[79] = "Armor Max Dexterity Bonus    |\t";
			ar[80] = "Spell Failure                |\t";
			ar[81] = "Skill Check Penalty          |\t";
			ar[82] = "Armor Type                   |\t";
			ar[83] = "Helmet Type                  |\t";
			ar[86] = "Coin Type                    |\t";
			ar[89] = "Key ID                       |\t";
			ar[94] = "Bag of Holding Flags         |\t";
			ar[99] = "Critter Flags                |\t";
			ar[101] = "Strength                     |\t";
			ar[102] = "Dexterity                    |\t";
			ar[103] = "Constitution                 |\t";
			ar[104] = "Intelligence                 |\t";
			ar[105] = "Wisdom                       |\t";
			ar[106] = "Charisma                     |\t";
			ar[108] = "Race                         |\t";
			ar[109] = "Gender                       |\t";
			ar[113] = "Alignment                    |\t";
			ar[114] = "Deity                        |\t";
			ar[115] = "Domain 1                     |\t";
			ar[116] = "Domain 2                     |\t";
			ar[117] = "Negative/Positive (?)        |\t";
			ar[123] = "Picture #                    |\t";
			ar[129] = "NPC Description (If Unknown) |\t";
			ar[130] = "Reach                        |\t";
			ar[132] = "Number of Attacks (?)        |\t";
			ar[133] = "Creature Damage Dice         |\t";
			ar[134] = "Creature Damage Type         |\t";
			ar[135] = "To Hit (?)                   |\t";
			ar[136] = "Number of Attacks (?)        |\t";
			ar[137] = "Creature Damage Dice         |\t";
			ar[138] = "Creature Damage Type         |\t";
			ar[139] = "To Hit (?)                   |\t";
			ar[140] = "Number of Attacks (?)        |\t";
			ar[141] = "Creature Damage Dice         |\t";
			ar[142] = "Creature Damage Type         |\t";
			ar[143] = "To Hit (?)                   |\t";
			ar[144] = "Number of Attacks (?)        |\t";
			ar[145] = "Creature Damage Dice         |\t";
			ar[146] = "Creature Damage Type         |\t";
			ar[147] = "To Hit (?)                   |\t";
			ar[148] = "Hair Color                   |\t";
			ar[149] = "Hair Type                    |\t";
			ar[152] = "NPC Flags                    |\t";
			ar[157] = "Challenge Rating (CR)        |\t";
			ar[158] = "Base Reflex Save             |\t";
			ar[159] = "Base Fortitude Save          |\t";
			ar[160] = "Base Will Save               |\t";
			ar[161] = "Natural Armor Class          |\t";
			ar[162] = "Hit Dice (HD)                |\t";
			ar[163] = "Creature Type                |\t";
			ar[164] = "Creature Subtype             |\t";
			ar[165] = "NPC Loot Share Amount        |\t";
			ar[166] = "Trap Flags                   |\t";
			ar[167] = "Trap Difficulty              |\t";
			ar[168] = "Property 1 Type              |\t";
			ar[169] = "Property 1 Param. 1          |\t";
			ar[170] = "Property 1 Param. 2          |\t";
			ar[171] = "Property 2 Type              |\t";
			ar[172] = "Property 2 Param. 1          |\t";
			ar[173] = "Property 2 Param. 2          |\t";
			ar[174] = "Property 3 Type              |\t";
			ar[175] = "Property 3 Param. 1          |\t";
			ar[176] = "Property 3 Param. 2          |\t";
			ar[177] = "Property 4 Type              |\t";
			ar[178] = "Property 4 Param. 1          |\t";
			ar[179] = "Property 4 Param. 2          |\t";
			ar[180] = "Property 5 Type              |\t";
			ar[181] = "Property 5 Param. 1          |\t";
			ar[182] = "Property 5 Param. 2          |\t";
			ar[183] = "Property 6 Type              |\t";
			ar[184] = "Property 6 Param. 1          |\t";
			ar[185] = "Property 6 Param. 2          |\t";
			ar[186] = "Property 7 Type              |\t";
			ar[187] = "Property 7 Param. 1          |\t";
			ar[188] = "Property 7 Param. 2          |\t";
			ar[189] = "Property 8 Type              |\t";
			ar[190] = "Property 8 Param. 1          |\t";
			ar[191] = "Property 8 Param. 2          |\t";
			ar[192] = "Property 9 Type              |\t";
			ar[193] = "Property 9 Param. 1          |\t";
			ar[194] = "Property 9 Param. 2          |\t";
			ar[195] = "Property 10 Type             |\t";
			ar[196] = "Property 10 Param. 1         |\t"; 
			ar[197] = "Property 10 Param. 2         |\t";
			ar[198] = "Property 11 Type             |\t";
			ar[199] = "Property 11 Param. 1         |\t";
			ar[200] = "Property 11 Param. 2         |\t";
			ar[201] = "Property 12 Type             |\t";
			ar[202] = "Property 12 Param. 1         |\t";
			ar[203] = "Property 12 Param. 2         |\t";
			ar[204] = "Property 13 Type             |\t";
			ar[205] = "Property 13 Param. 1         |\t";
			ar[206] = "Property 13 Param. 2         |\t";
			ar[207] = "Property 14 Type             |\t";
			ar[208] = "Property 14 Param. 1         |\t";
			ar[209] = "Property 14 Param. 2         |\t";
			ar[210] = "Property 15 Type             |\t";
			ar[211] = "Property 15 Param. 1         |\t";
			ar[212] = "Property 15 Param. 2         |\t";
			ar[213] = "Property 16 Type             |\t";
			ar[214] = "Property 16 Param. 1         |\t";
			ar[215] = "Property 16 Param. 2         |\t";
			ar[216] = "Property 17 Type             |\t";
			ar[217] = "Property 17 Param. 1         |\t";
			ar[218] = "Property 17 Param. 2         |\t";
			ar[219] = "Property 18 Type             |\t";
			ar[220] = "Property 18 Param. 1         |\t";
			ar[221] = "Property 18 Param. 2         |\t";
			ar[222] = "Property 19 Type             |\t";
			ar[223] = "Property 19 Param. 1         |\t";
			ar[224] = "Property 19 Param. 2         |\t";
			ar[225] = "Property 20 Type             |\t";
			ar[226] = "Property 20 Param. 1         |\t";
			ar[227] = "Property 20 Param. 2         |\t";
			ar[228] = "Class 1                      |\t";
			ar[229] = "Class 1 Level                |\t";
			ar[230] = "Class 2                      |\t";
			ar[231] = "Class 2 Level                |\t";
			ar[232] = "Class 3                      |\t";
			ar[233] = "Class 3 Level                |\t";
			ar[234] = "Class 4                      |\t";
			ar[235] = "Class 4 Level                |\t";
			ar[236] = "Class 5                      |\t";
			ar[237] = "Class 5 Level                |\t";
			ar[238] = "Skill 1                      |\t";
			ar[239] = "Skill 1 Level                |\t";
			ar[240] = "Skill 2                      |\t";
			ar[241] = "Skill 2 Level                |\t";
			ar[242] = "Skill 3                      |\t";
			ar[243] = "Skill 3 Level                |\t";
			ar[244] = "Skill 4                      |\t";
			ar[245] = "Skill 4 Level                |\t";
			ar[246] = "Skill 5                      |\t";
			ar[247] = "Skill 5 Level                |\t";
			ar[248] = "Skill 6                      |\t";
			ar[249] = "Skill 6 Level                |\t";
			ar[250] = "Skill 7                      |\t";
			ar[251] = "Skill 7 Level                |\t";
			ar[252] = "Skill 8                      |\t";
			ar[253] = "Skill 8 Level                |\t";
			ar[254] = "Skill 9                      |\t";
			ar[255] = "Skill 9 Level                |\t";
			ar[256] = "Skill 10                     |\t";
			ar[257] = "Skill 10 Level               |\t";
			ar[258] = "Feat                         |\t";
			ar[259] = "Feat                         |\t";
			ar[260] = "Feat                         |\t";
			ar[261] = "Feat                         |\t";
			ar[262] = "Feat                         |\t";
			ar[263] = "Feat                         |\t";
			ar[264] = "Feat                         |\t";
			ar[265] = "Feat                         |\t";
			ar[266] = "Feat                         |\t";
			ar[267] = "Feat                         |\t";
			ar[268] = "Script: san_examine          |\t";
			ar[269] = "Script: san_use              |\t";
			ar[270] = "Script: san_destroy          |\t";
			ar[271] = "Script: san_unlock           |\t";
			ar[272] = "Script: san_get              |\t";
			ar[273] = "Script: san_drop             |\t";
			ar[274] = "Script: san_throw            |\t";
			ar[275] = "Script: san_hit              |\t";
			ar[276] = "Script: san_miss             |\t";
			ar[277] = "Script: san_dialog           |\t";
			ar[278] = "Script: san_first_heartbeat  |\t";
			ar[279] = "Script: san_catching_thief_pc|\t";
			ar[280] = "Script: san_dying            |\t";
			ar[281] = "Script: san_enter_combat     |\t";
			ar[282] = "Script: san_exit_combat      |\t";
			ar[283] = "Script: san_start_combat     |\t";
			ar[284] = "Script: san_end_combat       |\t";
			ar[285] = "Script: san_buy_object       |\t";
			ar[286] = "Script: san_resurrect        |\t";
			ar[287] = "Script: san_heartbeat        |\t";
			ar[288] = "Script: san_leader_killing   |\t";
			ar[289] = "Script: san_insert_item      |\t";
			ar[290] = "Script: san_will_kos         |\t";
			ar[291] = "Script: san_taking_damage    |\t";
			ar[292] = "Script: san_wield_on         |\t";
			ar[293] = "Script: san_wield_off        |\t";
			ar[294] = "Script: san_critter_hits     |\t";
			ar[295] = "Script: san_new_sector       |\t";
			ar[296] = "Script: san_remove_item      |\t";
			ar[297] = "Script: san_leader_sleeping  |\t";
			ar[298] = "Script: san_bust             |\t";
			ar[299] = "Script: san_dialog_override  |\t";
			ar[300] = "Script: san_transfer         |\t";
			ar[301] = "Script: san_caught_thief     |\t";
			ar[302] = "Script: san_critical_hit     |\t";
			ar[303] = "Script: san_critical_miss    |\t";
			ar[304] = "Script: san_join             |\t";
			ar[305] = "Script: san_disband          |\t";
			ar[306] = "Script: san_new_map          |\t";
			ar[307] = "Script: san_trap             |\t";
			ar[308] = "Script: san_true_seeing      |\t";
			ar[309] = "Script: san_spell_cast       |\t";
			ar[310] = "Script: san_unlock_attempt   |\t";
			ar[311] = "Waypoint anim (?)            |\t";
			ar[312] = "Spell                        |\t";
			ar[313] = "Spell                        |\t";
			ar[314] = "Spell                        |\t";
			ar[315] = "Spell                        |\t";
			ar[316] = "Spell                        |\t";
			ar[317] = "Spell                        |\t";
			ar[318] = "Spell                        |\t";
			ar[319] = "Spell                        |\t";
			ar[320] = "Spell                        |\t";
			ar[321] = "Spell                        |\t";
			ar[322] = "Spell                        |\t";
			ar[323] = "Spell                        |\t";
			ar[324] = "Spell                        |\t";
			ar[325] = "Spell                        |\t";
			ar[326] = "Spell                        |\t";
			ar[327] = "Spell                        |\t";
			ar[328] = "Spell                        |\t";
			ar[329] = "Spell                        |\t";
			ar[330] = "Spell                        |\t";
			ar[331] = "Spell                        |\t";
			ar[332] = "Name (Known)                 |\t";
			ar[333] = "AI Strategy Type             |\t";

			// + v1.1: smart patcher for newly found proto fields +
			if (File.Exists("ToEE World Builder.pfr"))
			{
				StreamReader sr = new StreamReader("ToEE World Builder.pfr");
				string proto_patch_name = "";
				string[] proto_patch_name_arr = null;

				while ((proto_patch_name = sr.ReadLine()) != "[END PROTO FIELD PATCH]")
				{
					if (proto_patch_name.Trim() == "")
						continue;

					if (proto_patch_name.Substring(0, 2) == "//") // comment
						continue;

					proto_patch_name_arr = proto_patch_name.Split('=');
					ar[int.Parse(proto_patch_name_arr[0])] = proto_patch_name_arr[1].PadRight(29, ' ')+"|\t";
				}

				sr.Close();
			}
			// - v1.1: smart patcher for newly found proto fields -

			return ar;
		}

		// + Patch v1.4.421 +
		// $Update author: Sapricon$
		// $Target revision: v1.4.421$
		// AN INTELLIPROPERTIES UPDATE TO INCLUDE NEW FIELDS

		// Template
		public static ArrayList PRO_Sapri_GetData()
		{
			ArrayList ar = new ArrayList();

			return ar;
		}

		public static ArrayList PRO_GetCritterFlagsII()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OCF2_ACTION5_PAUSED");
			ar.Add("OCF2_ACTION4_PAUSED");
			ar.Add("OCF2_ACTION3_PAUSED");
			ar.Add("OCF2_ACTION2_PAUSED");
			ar.Add("OCF2_ACTION1_PAUSED");
			ar.Add("OCF2_ACTION0_PAUSED");
			ar.Add("OCF2_TARGET_LOCK");
			ar.Add("OCF2_REACTION_6");
			ar.Add("OCF2_REACTION_5");
			ar.Add("OCF2_REACTION_4");
			ar.Add("OCF2_REACTION_3");
			ar.Add("OCF2_REACTION_2");
			ar.Add("OCF2_REACTION_1");
			ar.Add("OCF2_REACTION_0");
			ar.Add("OCF2_NO_DISINTEGRATE");
			ar.Add("OCF2_NO_SLIP");
			ar.Add("OCF2_DARK_SIGHT");
			ar.Add("OCF2_ELEMENTAL");
			ar.Add("OCF2_NIGH_INVULNERABLE");
			ar.Add("OCF2_NO_BLOOD_SPLOTCHES");
			ar.Add("OCF2_NO_PICKPOCKET");
			ar.Add("OCF2_NO_DECAY");
			ar.Add("OCF2_SLOW_PARTY");
			ar.Add("OCF2_FATIGUE_DRAINING");
			ar.Add("OCF2_USING_BOOMERANG");
			ar.Add("OCF2_AUTO_ANIMATES");
			ar.Add("OCF2_ITEM_STOLEN");

			return ar;
		}

		public static ArrayList PRO_GetArmorFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OARF_ARMOR_NONE");
			ar.Add("OARF_HELM_TYPE_2");
			ar.Add("OARF_HELM_TYPE_1");
			ar.Add("OARF_ARMOR_TYPE_2");
			ar.Add("OARF_ARMOR_TYPE_1");

			return ar;
		}

		public static ArrayList PRO_GetGenericFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OGF_IS_LOCKPICK");
			ar.Add("OGF_IS_TRAP_DEVICE");
			ar.Add("OGF_IS_GRENADE");

			return ar;
		}

		public static ArrayList PRO_GetSceneryFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OSCF_USE_OPEN_WORLDMAP");
			ar.Add("OSCF_TAGGED_SCENERY");
			ar.Add("OSCF_RESPAWNING");
			ar.Add("OSCF_UNDER_ALL");
			ar.Add("OSCF_SOUND_EXTRA_LARGE");
			ar.Add("OSCF_SOUND_MEDIUM");
			ar.Add("OSCF_SOUND_SMALL");
			ar.Add("OSCF_RESPAWNABLE");
			ar.Add("OSCF_IS_FIRE");
			ar.Add("OSCF_MARKS_TOWNMAP");
			ar.Add("OSCF_NOCTURNAL");
			ar.Add("OSCF_BUSTED");
			ar.Add("OSCF_NO_AUTO_ANIMATE");

			return ar;
		}

		public static ArrayList PRO_GetSpellFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OSF_HARDENED_HANDS");
			ar.Add("OSF_FAMILIAR");
			ar.Add("OSF_ENSHROUDED");
			ar.Add("OSF_DRUNK");
			ar.Add("OSF_MIND_CONTROLLED");
			ar.Add("OSF_TEMPUS_FUGIT");
			ar.Add("OSF_SPOKEN_WITH_DEAD");
			ar.Add("OSF_ENTANGLED");
			ar.Add("OSF_CHARMED");
			ar.Add("OSF_MAGNETIC_INVERSION");
			ar.Add("OSF_WATER_WALKING");
			ar.Add("OSF_PASSWALLED");
			ar.Add("OSF_SHRUNK");
			ar.Add("OSF_MIRRORED");
			ar.Add("OSF_POLYMORPHED");
			ar.Add("OSF_STONED");
			ar.Add("OSF_ILLUSION");
			ar.Add("OSF_SUMMONED");
			ar.Add("OSF_FULL_REFLECTION");
			ar.Add("OSF_BONDS_OF_MAGIC");
			ar.Add("OSF_ANTI_MAGIC_SHELL");
			ar.Add("OSF_SHIELDED");
			ar.Add("OSF_DETECTING_INVISIBLE");
			ar.Add("OSF_DETECTING_TRAPS");
			ar.Add("OSF_DETECTING_ALIGNMENT");
			ar.Add("OSF_DETECTING_MAGIC");
			ar.Add("OSF_BODY_OF_WATER");
			ar.Add("OSF_BODY_OF_AIR");
			ar.Add("OSF_BODY_OF_EARTH");
			ar.Add("OSF_BODY_OF_FIRE");
			ar.Add("OSF_FLOATING");
			ar.Add("OSF_INVISIBLE");

			return ar;
		}

		public static ArrayList PRO_GetTrapFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OTF_BUSTED");
			
			return ar;
		}

		public static ArrayList PRO_GetAmmoFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OAF_NONE");
			
			return ar;
		}

		public static ArrayList PRO_GetFoodFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OFF_NONE");
			
			return ar;
		}

		// - Patch v1.4.421 -

		public static ArrayList PRO_GetObjectFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OF_RADIUS_SET");
			ar.Add("OF_TELEPORTED");
			ar.Add("OF_ANIMATED_DEAD");
			ar.Add("OF_HEIGHT_SET");
			ar.Add("OF_UNUSED_08000000");
			ar.Add("OF_DISALLOW_WADING");
			ar.Add("OF_TRAP_SPOTTED");
			ar.Add("OF_TRAP_PC");
			ar.Add("OF_EXTINCT");
			ar.Add("OF_INVULNERABLE");
			ar.Add("OF_TEXT_FLOATER");
			ar.Add("OF_DONTLIGHT");
			ar.Add("OF_STONED");
			ar.Add("OF_UNUSED_40000");
			ar.Add("OF_WADING");
			ar.Add("OF_NOHEIGHT");
			ar.Add("OF_RANDOM_SIZE");
			ar.Add("OF_PROVIDES_COVER");
			ar.Add("OF_DYNAMIC");
			ar.Add("OF_INVENTORY");
			ar.Add("OF_CLICK_THROUGH");
			ar.Add("OF_NO_BLOCK");
			ar.Add("OF_INVISIBLE");
			ar.Add("OF_DONTDRAW");
			ar.Add("OF_SHRUNK");
			ar.Add("OF_TRANSLUCENT");
			ar.Add("OF_SHOOT_THROUGH");
			ar.Add("OF_SEE_THROUGH");
			ar.Add("OF_TEXT");
			ar.Add("OF_FLAT");
			ar.Add("OF_OFF");
			ar.Add("OF_DESTROYED");

			return ar;
		}

		// NPC Loot Share
		public static ArrayList PRO_GetNPCLootShare()
		{
			ArrayList ar = new ArrayList();

			ar.Add("nothing");
			ar.Add("one_fifth_of_all");
			ar.Add("one_third_of_all");
			ar.Add("all_arcane_scrolls_nothing_else");
			ar.Add("half_share_money_only");
			ar.Add("normal");

			return ar;
		}

		// Object Size
		public static ArrayList PRO_GetObjSize()
		{
			ArrayList ar = new ArrayList();

			ar.Add("size_clossal");
			ar.Add("size_gargantuan");
			ar.Add("size_huge");
			ar.Add("size_large");
			ar.Add("size_medium");
			ar.Add("size_small");
			ar.Add("size_tiny");
			ar.Add("size_fine");
			ar.Add("size_none");

			return ar;
		}

		// Object Type
		public static ArrayList PRO_GetObjType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("obj_t_bag");
			ar.Add("obj_t_trap");
			ar.Add("obj_t_npc");
			ar.Add("obj_t_pc");
			ar.Add("obj_t_generic");
			ar.Add("obj_t_written");
			ar.Add("obj_t_key");
			ar.Add("obj_t_scroll");
			ar.Add("obj_t_food");
			ar.Add("obj_t_money");
			ar.Add("obj_t_armor");
			ar.Add("obj_t_ammo");
			ar.Add("obj_t_weapon");
			ar.Add("obj_t_projectile");
			ar.Add("obj_t_scenery");
			ar.Add("obj_t_container");
			ar.Add("obj_t_portal");

			return ar;
		}

		// Material
		public static ArrayList PRO_GetMaterial()
		{
			ArrayList ar = new ArrayList();

			ar.Add("mat_powder");
			ar.Add("mat_fire");
			ar.Add("mat_force");
			ar.Add("mat_gas");
			ar.Add("mat_paper");
			ar.Add("mat_liquid");
			ar.Add("mat_cloth");
			ar.Add("mat_glass");
			ar.Add("mat_metal");
			ar.Add("mat_flesh");
			ar.Add("mat_plant");
			ar.Add("mat_wood");
			ar.Add("mat_brick");
			ar.Add("mat_stone");

			return ar;
		}

		// Portal flags
		public static ArrayList PRO_GetPortalFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OPF_OPEN");
			ar.Add("OPF_NOT_STICKY");
			ar.Add("OPF_BUSTED");
			ar.Add("OPF_LOCKED_NIGHT");
			ar.Add("OPF_LOCKED_DAY");
			ar.Add("OPF_ALWAYS_LOCKED");
			ar.Add("OPF_NEVER_LOCKED");
			ar.Add("OPF_MAGICALLY_HELD");
			ar.Add("OPF_JAMMED");
			ar.Add("OPF_LOCKED");

			return ar;
		}

		// Container flags
		public static ArrayList PRO_GetContainerFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OCOF_HAS_BEEN_OPENED");
			ar.Add("OCOF_OPEN");
			ar.Add("OCOF_INVEN_SPAWN_INDEPENDENT");
			ar.Add("OCOF_INVEN_SPAWN_ONCE");
			ar.Add("OCOF_NOT_STICKY");
			ar.Add("OCOF_BUSTED");
			ar.Add("OCOF_LOCKED_NIGHT");
			ar.Add("OCOF_LOCKED_DAY");
			ar.Add("OCOF_ALWAYS_LOCKED");
			ar.Add("OCOF_NEVER_LOCKED");
			ar.Add("OCOF_MAGICALLY_HELD");
			ar.Add("OCOF_JAMMED");
			ar.Add("OCOF_LOCKED");

			return ar;
		}

		// Item flags
		public static ArrayList PRO_GetItemFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OIF_NO_TRANSFER");
			ar.Add("OIF_USES_WAND_ANIM");
			ar.Add("OIF_NO_LOOT");
			ar.Add("OIF_EXPIRES_AFTER_USE");
			ar.Add("OIF_DRAW_WHEN_PARENTED");
			ar.Add("OIF_VALID_AI_ACTION");
			ar.Add("OIF_NO_RANGED_USE");
			ar.Add("OIF_NO_NPC_PICKUP");
			ar.Add("OIF_UBER");
			ar.Add("OIF_NO_DECAY");
			ar.Add("OIF_USE_IS_THROW");
			ar.Add("OIF_STOLEN");
			ar.Add("OIF_MT_TRIGGERED");
			ar.Add("OIF_PERSISTENT");
			ar.Add("OIF_LIGHT_XLARGE");
			ar.Add("OIF_LIGHT_LARGE");
			ar.Add("OIF_LIGHT_MEDIUM");
			ar.Add("OIF_LIGHT_SMALL");
			ar.Add("OIF_NEEDS_TARGET");
			ar.Add("OIF_CAN_USE_BOX");
			ar.Add("OIF_NEEDS_SPELL");
			ar.Add("OIF_NO_DROP");
			ar.Add("OIF_NO_DISPLAY");
			ar.Add("OIF_NO_PICKPOCKET");
			ar.Add("OIF_IS_MAGICAL");
			ar.Add("OIF_WONT_SELL");
			ar.Add("OIF_IDENTIFIED");

			return ar;
		}

		// Inventory slot flags
		public static ArrayList PRO_GetInvSlotFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OIF_WEAR_2HAND_REQUIRED");
			ar.Add("OIF_WEAR_LOCKPICKS");
			ar.Add("OIF_WEAR_BARDIC_ITEM");
			ar.Add("OIF_WEAR_BRACERS");
			ar.Add("OIF_WEAR_ROBES");
			ar.Add("OIF_WEAR_BUCKLER");
			ar.Add("OIF_WEAR_CLOAK");
			ar.Add("OIF_WEAR_AMMO");
			ar.Add("OIF_WEAR_BOOTS");
			ar.Add("OIF_WEAR_UNUSED_3");
			ar.Add("OIF_WEAR_RING");
			ar.Add("OIF_WEAR_ARMOR");
			ar.Add("OIF_WEAR_UNUSED_2");
			ar.Add("OIF_WEAR_UNUSED_1");
			ar.Add("OIF_WEAR_GLOVES");
			ar.Add("OIF_WEAR_NECKLACE");
			ar.Add("OIF_WEAR_HELMET");

			return ar;
		}

		// Weapon flags
		public static ArrayList PRO_GetWeaponFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OWF_MAGIC_STAFF");
			ar.Add("OWF_WEAPON_LOADED");
			ar.Add("OWF_RANGED_WEAPON");
			ar.Add("OWF_DEFAULT_THROWS");
			ar.Add("OWF_DAMAGE_ARMOR");
			ar.Add("OWF_IGNORE_RESISTANCE");
			ar.Add("OWF_BOOMERANGS");
			ar.Add("OWF_TRANS_PROJECTILE");
			ar.Add("OWF_THROWABLE");
			ar.Add("OWF_UNUSED_2");
			ar.Add("OWF_UNUSED_1");
			ar.Add("OWF_SILENT");
			ar.Add("OWF_LOUD");
			ar.Add("OWF_TWO_HANDED");

			return ar;
		}

		// Missile type?
		public static ArrayList PRO_GetMissileType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("bottle");
			ar.Add("ball_of_fire");
			ar.Add("shuriken");
			ar.Add("halfling_sai");
			ar.Add("trident");
			ar.Add("light_hammer");
			ar.Add("throwing_axe");
			ar.Add("javelin");
			ar.Add("dart");
			ar.Add("spear");
			ar.Add("shortspear");
			ar.Add("club");
			ar.Add("dagger");
			ar.Add("magic_missile");
			ar.Add("bullet");
			ar.Add("bolt");
			ar.Add("arrow");

			return ar;
		}

		// Damage type
		public static ArrayList PRO_GetDamageType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("D20DT_MAGIC");
			ar.Add("D20DT_BLOOD_LOSS");
			ar.Add("D20DT_FORCE");
			ar.Add("D20DT_POSITIVE_ENERGY");
			ar.Add("D20DT_POISON");
			ar.Add("D20DT_SUBDUAL");
			ar.Add("D20DT_NEGATIVE_ENERGY");
			ar.Add("D20DT_SONIC");
			ar.Add("D20DT_FIRE");
			ar.Add("D20DT_ELECTRICITY");
			ar.Add("D20DT_COLD");
			ar.Add("D20DT_ACID");
			ar.Add("D20DT_SLASHING_AND_BLUDGEONING_AND_PIERCING");
			ar.Add("D20DT_SLASHING_AND_BLUDGEONING");
			ar.Add("D20DT_PIERCING_AND_SLASHING");
			ar.Add("D20DT_BLUDGEONING_AND_PIERCING");
			ar.Add("D20DT_SLASHING");
			ar.Add("D20DT_PIERCING");
			ar.Add("D20DT_BLUDGEONING");
			ar.Add("D20DT_UNSPECIFIED");

			return ar;
		}

		// Weapon class
		public static ArrayList PRO_GetWeaponClass()
		{
			ArrayList ar = new ArrayList();

			ar.Add("grenade");
			ar.Add("grapple");
			ar.Add("repeating_crossbow");
			ar.Add("whip");
			ar.Add("hand_crossbow");
			ar.Add("dwarven_urgrosh");
			ar.Add("two_bladed_sword");
			ar.Add("dire_flail");
			ar.Add("spike_chain");
			ar.Add("orc_double_axe");
			ar.Add("gnome_hooked_hammer");
			ar.Add("dwarven_waraxe");
			ar.Add("bastard_sword");
			ar.Add("siangham");
			ar.Add("nunchaku");
			ar.Add("kama");
			ar.Add("halfling_siangham");
			ar.Add("halfling_nunchaku");
			ar.Add("kukri");
			ar.Add("halfling_kama");
			ar.Add("composite_longbow");
			ar.Add("longbow");
			ar.Add("composite_shortbow");
			ar.Add("shortbow");
			ar.Add("scythe");
			ar.Add("ranseur");
			ar.Add("longspear");
			ar.Add("halberd");
			ar.Add("guisarme");
			ar.Add("greatsword");
			ar.Add("greatclub");
			ar.Add("greataxe");
			ar.Add("glaive");
			ar.Add("heavy_flail");
			ar.Add("falchion");
			ar.Add("warhammer");
			ar.Add("scimitar");
			ar.Add("rapier");
			ar.Add("heavy_pick");
			ar.Add("longsword");
			ar.Add("heavy_lance");
			ar.Add("light_flail");
			ar.Add("battleaxe");
			ar.Add("short_sword");
			ar.Add("light_pick");
			ar.Add("light_lance");
			ar.Add("handaxe");
			ar.Add("heavy_crossbow");
			ar.Add("sling");
			ar.Add("light_crossbow");
			ar.Add("quarterstaff");
			ar.Add("morningstar");
			ar.Add("heavy_mace");
			ar.Add("sickle");
			ar.Add("light_mace");
			ar.Add("spiked_gauntlet");
			ar.Add("punching_dagger");
			ar.Add("unarmed_strike_small_being");
			ar.Add("unarmed_strike_medium_sized_being");
			ar.Add("gauntlet");

			return ar;
		}

		// Ammo Type
		public static ArrayList PRO_GetAmmoType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("bullet");
			ar.Add("bolt");
			ar.Add("arrow");

			return ar;
		}

		// Armor Type
		public static ArrayList PRO_GetArmorType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("ARMOR_TYPE_SHIELD");
			ar.Add("ARMOR_TYPE_HEAVY");
			ar.Add("ARMOR_TYPE_MEDIUM");
			ar.Add("ARMOR_TYPE_LIGHT");

			return ar;
		}

		// Helm Type
		public static ArrayList PRO_GetHelmType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("HELM_TYPE_LARGE");
			ar.Add("HELM_TYPE_MEDIUM");
			ar.Add("HELM_TYPE_SMALL");
	
			return ar;
		}

		// Coin Type
		public static ArrayList PRO_GetCoinType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Platinum");
			ar.Add("Gold");
			ar.Add("Silver");
			ar.Add("Copper");

			return ar;
		}

		// Bag of Holding Flags
		public static ArrayList PRO_GetBagFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OBF_HOLDING_1000");
			ar.Add("OBF_HOLDING_500");

			return ar;
		}

		// Critter Flags
		public static ArrayList PRO_GetCritterFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("OCF_FATIGUE_LIMITING");
			ar.Add("OCF_UNUSED_40000000");
			ar.Add("OCF_MECHANICAL");
			ar.Add("OCF_NON_LETHAL_COMBAT");
			ar.Add("OCF_NO_FLEE");
			ar.Add("OCF_UNUSED_04000000");
			ar.Add("OCF_UNUSED_02000000");
			ar.Add("OCF_UNRESSURECTABLE");
			ar.Add("OCF_UNREVIVIFIABLE");
			ar.Add("OCF_LIGHT_XLARGE");
			ar.Add("OCF_LIGHT_LARGE");
			ar.Add("OCF_LIGHT_MEDIUM");
			ar.Add("OCF_LIGHT_SMALL");
			ar.Add("OCF_COMBAT_MODE_ACTIVE");
			ar.Add("OCF_ENCOUNTER");
			ar.Add("OCF_SPELL_FLEE");
			ar.Add("OCF_MONSTER");
			ar.Add("OCF_SURRENDERED");
			ar.Add("OCF_MUTE");
			ar.Add("OCF_SLEEPING");
			ar.Add("OCF_UNUSED_00000800");
			ar.Add("OCF_UNUSED_00000400");
			ar.Add("OCF_UNUSED_00000200");
			ar.Add("OCF_HAS_ARCANE_ABILITY");
			ar.Add("OCF_BLINDED");
			ar.Add("OCF_PARALYZED");
			ar.Add("OCF_STUNNED");
			ar.Add("OCF_FLEEING");
			ar.Add("OCF_UNUSED_00000008");
			ar.Add("OCF_EXPERIENCE_AWARDED");
			ar.Add("OCF_MOVING_SILENTLY");
			ar.Add("OCF_IS_CONCEALED");

			return ar;
		}

		// Race
		public static ArrayList PRO_GetRace()
		{
			ArrayList ar = new ArrayList();

			ar.Add("race_dwarf");
			ar.Add("race_elf");
			ar.Add("race_gnome");
			ar.Add("race_halfelf");
			ar.Add("race_halforc");
			ar.Add("race_halfling");
			ar.Add("race_human");

			return ar;
		}
	
		// Gender
		public static ArrayList PRO_GetGender()
		{
			ArrayList ar = new ArrayList();

			ar.Add("female");
			ar.Add("male");

			return ar;
		}

		// Alignment
		public static ArrayList PRO_GetAlignment()
		{
			ArrayList ar = new ArrayList();

			ar.Add("align_chaotic_evil");
			ar.Add("align_lawful_evil");
			ar.Add("align_neutral_evil");
			ar.Add("align_chaotic_good");
			ar.Add("align_lawful_good");
			ar.Add("align_neutral_good");
			ar.Add("align_chaotic_neutral");
			ar.Add("align_lawful_neutral");
			ar.Add("align_true_neutral");

			return ar;
		}

		// Deity
		public static ArrayList PRO_GetDeity()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Ralishaz");
			ar.Add("Pyremius");
			ar.Add("Norebo");
			ar.Add("Procan");
			ar.Add("Lolth");
			ar.Add("Zuggtmoy");
			ar.Add("Old Faith");
			ar.Add("Yondalla");
			ar.Add("Wee Jas");
			ar.Add("Vecna");
			ar.Add("St. Cuthbert");
			ar.Add("Pelor");
			ar.Add("Olidammara");
			ar.Add("Obad-Hai");
			ar.Add("Nerull");
			ar.Add("Moradin");
			ar.Add("Kord");
			ar.Add("Hextor");
			ar.Add("Heironeous");
			ar.Add("Gruumsh");
			ar.Add("Garl Glittergold");
			ar.Add("Fharlanghn");
			ar.Add("Erythnul");
			ar.Add("Ehlonna");
			ar.Add("Corellon Larethian");
			ar.Add("Boccob");
			ar.Add("No Deity");

			return ar;
		}

		// Domain
		public static ArrayList PRO_GetDomain()
		{
			ArrayList ar = new ArrayList();

			ar.Add("WATER");
			ar.Add("TRICKERY");
			ar.Add("TRAVEL");
			ar.Add("STRENGTH");
			ar.Add("PROTECTION");
			ar.Add("PLANT");
			ar.Add("MAGIC");
			ar.Add("LUCK");
			ar.Add("KNOWLEDGE");
			ar.Add("HEALING");
			ar.Add("GOOD");
			ar.Add("FIRE");
			ar.Add("EVIL");
			ar.Add("EARTH");
			ar.Add("DESTRUCTION");
			ar.Add("DEATH");
			ar.Add("CHAOS");
			ar.Add("ANIMAL");
			ar.Add("NONE");

			return ar;
		}

		// Positive/Negative
		public static ArrayList PRO_GetPosNeg()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Positive");
			ar.Add("Negative");

			return ar;
		}

		// Monster Damage Type
		public static ArrayList PRO_GetMonsterDamType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Sting");
			ar.Add("Slam");
			ar.Add("Slap");
			ar.Add("Gore");
			ar.Add("Rake");
			ar.Add("Claw");
			ar.Add("Bite");

			return ar;
		}

		// Hair color
		public static ArrayList PRO_GetHairColor()
		{
			ArrayList ar = new ArrayList();

			ar.Add("White");
			ar.Add("Pink");
			ar.Add("Light Brown");
			ar.Add("Brown");
			ar.Add("Blue");
			ar.Add("Blonde");
			ar.Add("Black");

			return ar;
		}

		// Hair type
		public static ArrayList PRO_GetHairType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Ponytail2 (f)");
			ar.Add("Medium (m)");
			ar.Add("Mohawk (m/f)");
			ar.Add("Braids (f)");
			ar.Add("Bald (m)");
			ar.Add("Pigtails (f)");
			ar.Add("Mullet (m)");
			ar.Add("Topknot (m/f)");
			ar.Add("Shorthair (m/f)");
			ar.Add("Ponytail (m/f)");
			ar.Add("Longhair (m/f)");

			return ar;
		}

		// NPC flags
		public static ArrayList PRO_GetNPCFlags()
		{
			ArrayList ar = new ArrayList();

			ar.Add("ONF_EXTRAPLANAR");
			ar.Add("ONF_BOSS_MONSTER");
			ar.Add("ONF_NO_ATTACK");
			ar.Add("ONF_BACKING_OFF");
			ar.Add("ONF_UNUSED_08000000");
			ar.Add("ONF_UNUSED_04000000");
			ar.Add("ONF_UNUSED_02000000");
			ar.Add("ONF_DEMAINTAIN_SPELLS");
			ar.Add("ONF_GENERATOR_RATE3");
			ar.Add("ONF_GENERATOR_RATE2");
			ar.Add("ONF_GENERATOR_RATE1");
			ar.Add("ONF_GENERATED");
			ar.Add("ONF_GENERATOR");
			ar.Add("ONF_CAST_HIGHEST");
			ar.Add("ONF_NO_EQUIP");
			ar.Add("ONF_CHECK_LEADER");
			ar.Add("ONF_FAMILIAR");
			ar.Add("ONF_FENCE");
			ar.Add("ONF_WANDERS_IN_DARK");
			ar.Add("ONF_WANDERS");
			ar.Add("ONF_KOS_OVERRIDE");
			ar.Add("ONF_FORCED_FOLLOWER");
			ar.Add("ONF_USE_ALERTPOINTS");
			ar.Add("ONF_KOS");
			ar.Add("ONF_UNUSED_00000080");
			ar.Add("ONF_LOGBOOK_IGNORES");
			ar.Add("ONF_JILTED");
			ar.Add("ONF_AI_SPREAD_OUT");
			ar.Add("ONF_AI_WAIT_HERE");
			ar.Add("ONF_WAYPOINTS_NIGHT");
			ar.Add("ONF_WAYPOINTS_DAY");
			ar.Add("ONF_EX_FOLLOWER");

			return ar;
		}

		// Creature Type
		public static ArrayList PRO_GetCreatureType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("mc_type_vermin");
			ar.Add("mc_type_undead");
			ar.Add("mc_type_shapechanger");
			ar.Add("mc_type_plant");
			ar.Add("mc_type_outsider");
			ar.Add("mc_type_ooze");
			ar.Add("mc_type_monstrous_humanoid");
			ar.Add("mc_type_magical_beast");
			ar.Add("mc_type_humanoid");
			ar.Add("mc_type_giant");
			ar.Add("mc_type_fey");
			ar.Add("mc_type_elemental");
			ar.Add("mc_type_dragon");
			ar.Add("mc_type_construct");
			ar.Add("mc_type_beast");
			ar.Add("mc_type_animal");
			ar.Add("mc_type_aberration");

			return ar;
		}

		// Creature Subtype
		public static ArrayList PRO_GetCreatureSubType()
		{
			ArrayList ar = new ArrayList();

			ar.Add("mc_subtype_water");
			ar.Add("mc_subtype_slaadi");
			ar.Add("mc_subtype_reptilian");
			ar.Add("mc_subtype_orc");
			ar.Add("mc_subtype_incorporeal");
			ar.Add("mc_subtype_lawful");
			ar.Add("mc_subtype_human");
			ar.Add("mc_subtype_halfling");
			ar.Add("mc_subtype_half_orc");
			ar.Add("mc_subtype_guardinal");
			ar.Add("mc_subtype_good");
			ar.Add("mc_subtype_goblinoid");
			ar.Add("mc_subtype_gnome");
			ar.Add("mc_subtype_gnoll");
			ar.Add("mc_subtype_formian");
			ar.Add("mc_subtype_fire");
			ar.Add("mc_subtype_evil");
			ar.Add("mc_subtype_elf");
			ar.Add("mc_subtype_electricity");
			ar.Add("mc_subtype_earth");
			ar.Add("mc_subtype_dwarf");
			ar.Add("mc_subtype_devil");
			ar.Add("mc_subtype_demon");
			ar.Add("mc_subtype_chaotic");
			ar.Add("mc_subtype_cold");
			ar.Add("mc_subtype_extraplaner");
			ar.Add("mc_subtype_aquatic");
			ar.Add("mc_subtype_air");

			return ar;
		}

		// Class
		public static ArrayList PRO_GetClass()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Wizard");
			ar.Add("Sorcerer");
			ar.Add("Rogue");
			ar.Add("Ranger");
			ar.Add("Fighter");
			ar.Add("Druid");
			ar.Add("Cleric");
			ar.Add("Bard");
			ar.Add("Barbarian");

			return ar;
		}

		// Skill
		public static ArrayList PRO_GetSkill()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Bluff");
			ar.Add("Climb");
			ar.Add("Concentration");
			ar.Add("Craft");
			ar.Add("Diplomacy");
			ar.Add("Disable Device");
			ar.Add("Escape Artist");
			ar.Add("Gather Information");
			ar.Add("Heal");
			ar.Add("Hide");
			ar.Add("Intimidate");
			ar.Add("Intuit Direction");
			ar.Add("Jump");
			ar.Add("Listen");
			ar.Add("Knowledge (Arcana)");
			ar.Add("Move Silently");
			ar.Add("Open Lock");
			ar.Add("Search");
			ar.Add("Sense Motive");
			ar.Add("Spellcraft");
			ar.Add("Sleight of Hand");
			ar.Add("Spot");
			ar.Add("Survival");
			ar.Add("Swim");
			ar.Add("Tumble");
			ar.Add("Use Magic Device");

			return ar;
		}

		// Item Properties
		public static ArrayList PRO_GetItemProps()
		{
			ArrayList ar = new ArrayList();

			ar.Add("Bardic-Inspire Greatness");
			ar.Add("Bardic-Suggestion");
			ar.Add("Bardic-Inspire Competence");
			ar.Add("Bardic-Fascinate");
			ar.Add("Bardic-Countersong");
			ar.Add("Bardic-Inspire Courage");
			ar.Add("Failed_Copy_Scroll");
			ar.Add("Ring of Change");
			ar.Add("Weapon Silver");
			ar.Add("Rod of Smiting");
			ar.Add("Buckler");
			ar.Add("Useable Item X Times Per Day");
			ar.Add("Bracers of Archery");
			ar.Add("Amulet of Natural Armor");
			ar.Add("Amulet of Mighty Fists");
			ar.Add("Necklace of Detection");
			ar.Add("Charisma Competence Bonus");
			ar.Add("Unholy Water");
			ar.Add("Holy Water");
			ar.Add("sp-Spheres of Fire-proj");
			ar.Add("Jaer");
			ar.Add("Bardic Instrument Magical");
			ar.Add("Bardic Instrument");
			ar.Add("Composite Bow");
			ar.Add("Thieves Tools Masterwork");
			ar.Add("Thieves Tools");
			ar.Add("Normal Projectile Particles");
			ar.Add("Fragarach");
			ar.Add("Elemental Gem");
			ar.Add("Golden Skull");
			ar.Add("Familiar Hp Bonus");
			ar.Add("Familiar Save Bonus");
			ar.Add("Familiar Skill Bonus");
			ar.Add("Sword of Life Stealing");
			ar.Add("Ring of Animal Summoning");
			ar.Add("Weapon Mighty Cleaving");
			ar.Add("Weapon Flame Tongue");
			ar.Add("Armor Spell Resistance");
			ar.Add("Armor Shadow");
			ar.Add("Armor Silent Moves");
			ar.Add("Boots of speed");
			ar.Add("Keoghtom");
			ar.Add("Ring of freedom of movement");
			ar.Add("UseableMagicStaff");
			ar.Add("Elemental Resistance per round");
			ar.Add("Dagger of Venom");
			ar.Add("Ring of Invisibility");
			ar.Add("Staff Of Striking");
			ar.Add("Elemental Resistance");
			ar.Add("Proof Against Detection Location");
			ar.Add("Proof Against Poison");
			ar.Add("Luck Poison Save Bonus");
			ar.Add("Frost Bow");
			ar.Add("Item Particle System");
			ar.Add("Saving Throw Resistance Bonus");
			ar.Add("Attribute Enhancement Bonus");
			ar.Add("Skill Competence Bonus");
			ar.Add("Skill Circumstance Bonus");
			ar.Add("UseableItem");
			ar.Add("Crossbow");
			ar.Add("Shield Enhancement Bonus");
			ar.Add("Shield Bonus");
			ar.Add("Armor Masterwork");
			ar.Add("Armor Bonus");
			ar.Add("Damage Bonus");
			ar.Add("To Hit Bonus");
			ar.Add("Weapon Chaotic");
			ar.Add("Weapon Lawful");
			ar.Add("Weapon Unholy");
			ar.Add("Weapon Holy");
			ar.Add("Weapon Shocking Burst");
			ar.Add("Weapon Icy Burst");
			ar.Add("Weapon Flaming Burst");
			ar.Add("Weapon Bane");
			ar.Add("Weapon Disruption");
			ar.Add("Weapon Shock");
			ar.Add("Weapon Frost");
			ar.Add("Weapon Flaming");
			ar.Add("Deflection Bonus");
			ar.Add("Weapon Defending Bonus");
			ar.Add("Weapon Masterwork");
			ar.Add("Monster Confusion Immunity");
			ar.Add("Monster Special Fade Out");
			ar.Add("Monster Subdual Immunity");
			ar.Add("Monster Poison Immunity");
			ar.Add("Monster Fast Healing");
			ar.Add("Monster Minotaur Charge");
			ar.Add("Monster Incorporeal");
			ar.Add("Monster Spider");
			ar.Add("Monster Hooting Fungi");
			ar.Add("Monster Untripable");
			ar.Add("Monster Plant");
			ar.Add("Monster Stable");
			ar.Add("Monster Superior Two Weapon Fighting");
			ar.Add("Monster DR Slashing");
			ar.Add("Monster DR Bludgeoning");
			ar.Add("Monster DR Holy");
			ar.Add("Monster DR Silver");
			ar.Add("Monster DR All");
			ar.Add("Monster DR Magic");
			ar.Add("Monster DR Cold-Holy");
			ar.Add("Monster DR Cold");
			ar.Add("Monster Lamia");
			ar.Add("Monster Zombie");
			ar.Add("Monster Smiting");
			ar.Add("Monster Spell Resistance");
			ar.Add("Monster Juggernaut");
			ar.Add("Monster Splitting");
			ar.Add("Monster Ooze Split");
			ar.Add("Monster Salamander");
			ar.Add("Monster Regeneration 1");
			ar.Add("Monster Regeneration 2");
			ar.Add("Monster Regeneration 5");
			ar.Add("Monster Energy Resistance");
			ar.Add("Monster Energy Immunity");
			ar.Add("Monster Melee Paralysis No Elf");
			ar.Add("Monster Melee Paralysis");
			ar.Add("Monster Carrion Crawler");
			ar.Add("Monster Melee Poison");
			ar.Add("Monster Melee Disease");
			ar.Add("Monster Fire Bats");
			ar.Add("Monster Stirge");
			ar.Add("Monster Bonus Damage");
			ar.Add("Monster Damage Type");
			ar.Add("Monster Banshee Charisma Drain");

			return ar;
		}

		public static ArrayList PRO_GetFeats()
		{
			ArrayList ar = new ArrayList();

			// + v1.4: Universal feat loader by Sapricon +
			if (File.Exists("ToEE World Builder.ftd"))
			{
				StreamReader sr = new StreamReader("ToEE World Builder.ftd");
				string str = "";
				
				while ((str=sr.ReadLine())!=null)
				{
					ar.Add(str.Split('\t')[1].Trim());
				}

				sr.Close();
				return ar;
			}
			// - v1.4: Universal feat loader by Sapricon -

			ar.Add("Acrobatic");
			ar.Add("Agile");
			ar.Add("Alertness");
			ar.Add("Animal Affinity");
			ar.Add("Armor Proficiency (light)");
			ar.Add("Armor Proficiency (medium)");
			ar.Add("Armor Proficiency (heavy)");
			ar.Add("Athletic");
			ar.Add("Augment Summoning");
			ar.Add("Blind-fight");
			ar.Add("Brew Potion");
			ar.Add("Cleave");
			ar.Add("Combat Casting");
			ar.Add("Combat Expertise");
			ar.Add("Craft Magic Arms and Armor");
			ar.Add("Craft Rod");
			ar.Add("Craft Staff");
			ar.Add("Craft Wand");
			ar.Add("Craft Wondrous Item");
			ar.Add("Deceitful");
			ar.Add("Deft Hands");
			ar.Add("Diehard");
			ar.Add("Diligent");
			ar.Add("Deflect Arrows");
			ar.Add("Dodge");
			ar.Add("Empower Spell");
			ar.Add("Endurance");
			ar.Add("Enlarge Spell");
			ar.Add("Eschew Materials");
			ar.Add("Exotic Weapon Proficiency (Halfling Kama)");
			ar.Add("Exotic Weapon Proficiency (Kukri)");
			ar.Add("Exotic Weapon Proficiency (Halfling Nunchaku)");
			ar.Add("Exotic Weapon Proficiency (Halfling Siangham)");
			ar.Add("Exotic Weapon Proficiency (Kama)");
			ar.Add("Exotic Weapon Proficiency (Nunchaku)");
			ar.Add("Exotic Weapon Proficiency (Siangham)");
			ar.Add("Exotic Weapon Proficiency (Bastard Sword)");
			ar.Add("Exotic Weapon Proficiency (Dwarven Waraxe)");
			ar.Add("Exotic Weapon Proficiency (Gnome Hooked Hammer)");
			ar.Add("Exotic Weapon Proficiency (Orc Double Axe)");
			ar.Add("Exotic Weapon Proficiency (Spike Chain)");
			ar.Add("Exotic Weapon Proficiency (Dire Flail)");
			ar.Add("Exotic Weapon Proficiency (Two-bladed Sword)");
			ar.Add("Exotic Weapon Proficiency (Dwarven Urgrosh)");
			ar.Add("Exotic Weapon Proficiency (Hand Crossbow)");
			ar.Add("Exotic Weapon Proficiency (Shuriken)");
			ar.Add("Exotic Weapon Proficiency (Whip)");
			ar.Add("Exotic Weapon Proficiency (Repeating Crossbow)");
			ar.Add("Exotic Weapon Proficiency (Net)");
			ar.Add("Extend Spell");
			ar.Add("Extra Turning");
			ar.Add("Far Shot");
			ar.Add("Forge Ring");
			ar.Add("Great Cleave");
			ar.Add("Great Fortitude");
			ar.Add("Greater Spell Focus (Abjuration)");
			ar.Add("Greater Spell Focus (Conjuration)");
			ar.Add("Greater Spell Focus (Divination)");
			ar.Add("Greater Spell Focus (Enchantment)");
			ar.Add("Greater Spell Focus (Evocation)");
			ar.Add("Greater Spell Focus (Illusion)");
			ar.Add("Greater Spell Focus (Necromancy)");
			ar.Add("Greater Spell Focus (Transmutation)");
			ar.Add("Greater Spell Penetration");
			ar.Add("Greater Two Weapon Fighting");
			ar.Add("Greater Weapon Focus (Gauntlet)");
			ar.Add("Greater Weapon Focus (Unarmed strike)");
			ar.Add("Greater Weapon Focus (Unarmed strike - small being)");
			ar.Add("Greater Weapon Focus (Dagger)");
			ar.Add("Greater Weapon Focus (Punching Dagger)");
			ar.Add("Greater Weapon Focus (Spiked Gauntlet)");
			ar.Add("Greater Weapon Focus (Light Mace)");
			ar.Add("Greater Weapon Focus (Sickle)");
			ar.Add("Greater Weapon Focus (Club)");
			ar.Add("Greater Weapon Focus (Shortspear)");
			ar.Add("Greater Weapon Focus (Heavy mace)");
			ar.Add("Greater Weapon Focus (Morningstar)");
			ar.Add("Greater Weapon Focus (Quarterstaff)");
			ar.Add("Greater Weapon Focus (Spear)");
			ar.Add("Greater Weapon Focus (Light Crossbow)");
			ar.Add("Greater Weapon Focus (Dart)");
			ar.Add("Greater Weapon Focus (Sling)");
			ar.Add("Greater Weapon Focus (Heavy Crossbow)");
			ar.Add("Greater Weapon Focus (Javelin)");
			ar.Add("Greater Weapon Focus (Throwing Axe)");
			ar.Add("Greater Weapon Focus (Light Hammer)");
			ar.Add("Greater Weapon Focus (Handaxe)");
			ar.Add("Greater Weapon Focus (Light Lance)");
			ar.Add("Greater Weapon Focus (Light Pick)");
			ar.Add("Greater Weapon Focus (Sap)");
			ar.Add("Greater Weapon Focus (Short Sword)");
			ar.Add("Greater Weapon Focus (Battleaxe)");
			ar.Add("Greater Weapon Focus (Light Flail)");
			ar.Add("Greater Weapon Focus (Heavy Lance)");
			ar.Add("Greater Weapon Focus (Longsword)");
			ar.Add("Greater Weapon Focus (Heavy Pick)");
			ar.Add("Greater Weapon Focus (Rapier)");
			ar.Add("Greater Weapon Focus (Scimitar)");
			ar.Add("Greater Weapon Focus (Trident)");
			ar.Add("Greater Weapon Focus (Warhammer)");
			ar.Add("Greater Weapon Focus (Falchion)");
			ar.Add("Greater Weapon Focus (Heavy Flail)");
			ar.Add("Greater Weapon Focus (Glaive)");
			ar.Add("Greater Weapon Focus (Greataxe)");
			ar.Add("Greater Weapon Focus (Greatclub)");
			ar.Add("Greater Weapon Focus (Greatsword)");
			ar.Add("Greater Weapon Focus (Guisarme)");
			ar.Add("Greater Weapon Focus (Halberd)");
			ar.Add("Greater Weapon Focus (Longspear)");
			ar.Add("Greater Weapon Focus (Ranseur)");
			ar.Add("Greater Weapon Focus (Scythe)");
			ar.Add("Greater Weapon Focus (Shortbow)");
			ar.Add("Greater Weapon Focus (Composite Shortbow)");
			ar.Add("Greater Weapon Focus (Longbow)");
			ar.Add("Greater Weapon Focus (Composite Longbow)");
			ar.Add("Greater Weapon Focus (Halfling Kama)");
			ar.Add("Greater Weapon Focus (Kukri)");
			ar.Add("Greater Weapon Focus (Halfling Nunchaku)");
			ar.Add("Greater Weapon Focus (Halfling Siangham)");
			ar.Add("Greater Weapon Focus (Kama)");
			ar.Add("Greater Weapon Focus (Nunchaku)");
			ar.Add("Greater Weapon Focus (Siangham)");
			ar.Add("Greater Weapon Focus (Bastard Sword)");
			ar.Add("Greater Weapon Focus (Dwarven Waraxe)");
			ar.Add("Greater Weapon Focus (Gnome Hooked Hammer)");
			ar.Add("Greater Weapon Focus (Orc Double Axe)");
			ar.Add("Greater Weapon Focus (Spike Chain)");
			ar.Add("Greater Weapon Focus (Dire Flail)");
			ar.Add("Greater Weapon Focus (Two-bladed Sword)");
			ar.Add("Greater Weapon Focus (Dwarven Urgrosh)");
			ar.Add("Greater Weapon Focus (Hand Crossbow)");
			ar.Add("Greater Weapon Focus (Shuriken)");
			ar.Add("Greater Weapon Focus (Whip)");
			ar.Add("Greater Weapon Focus (Repeating Crossbow)");
			ar.Add("Greater Weapon Focus (Net)");
			ar.Add("Greater Weapon Focus (Grapple)");
			ar.Add("Greater Weapon Focus (Ray)");
			ar.Add("Greater Weapon Specialization");
			ar.Add("Heighten Spell");
			ar.Add("Improved Bull Rush");
			ar.Add("Improved Counterspell");
			ar.Add("Improved Critical (Gauntlet)");
			ar.Add("Improved Critical (Unarmed strike)");
			ar.Add("Improved Critical (Unarmed strike - small being)");
			ar.Add("Improved Critical (Dagger)");
			ar.Add("Improved Critical (Punching Dagger)");
			ar.Add("Improved Critical (Spiked Gauntlet)");
			ar.Add("Improved Critical (Light Mace)");
			ar.Add("Improved Critical (Sickle)");
			ar.Add("Improved Critical (Club)");
			ar.Add("Improved Critical (Shortpear)");
			ar.Add("Improved Critical (Heavy mace)");
			ar.Add("Improved Critical (Morningstar)");
			ar.Add("Improved Critical (Quarterstaff)");
			ar.Add("Improved Critical (Spear)");
			ar.Add("Improved Critical (Light Crossbow)");
			ar.Add("Improved Critical (Dart)");
			ar.Add("Improved Critical (Sling)");
			ar.Add("Improved Critical (Heavy Crossbow)");
			ar.Add("Improved Critical (Javelin)");
			ar.Add("Improved Critical (Throwing Axe)");
			ar.Add("Improved Critical (Light Hammer)");
			ar.Add("Improved Critical (Handaxe)");
			ar.Add("Improved Critical (Light Lance)");
			ar.Add("Improved Critical (Light Pick)");
			ar.Add("Improved Critical (Sap)");
			ar.Add("Improved Critical (Short Sword)");
			ar.Add("Improved Critical (Battleaxe)");
			ar.Add("Improved Critical (Light Flail)");
			ar.Add("Improved Critical (Heavy Lance)");
			ar.Add("Improved Critical (Longsword)");
			ar.Add("Improved Critical (Heavy Pick)");
			ar.Add("Improved Critical (Rapier)");
			ar.Add("Improved Critical (Scimitar)");
			ar.Add("Improved Critical (Trident)");
			ar.Add("Improved Critical (Warhammer)");
			ar.Add("Improved Critical (Falchion)");
			ar.Add("Improved Critical (Heavy Flail)");
			ar.Add("Improved Critical (Glaive)");
			ar.Add("Improved Critical (Greataxe)");
			ar.Add("Improved Critical (Greatclub)");
			ar.Add("Improved Critical (Greatsword)");
			ar.Add("Improved Critical (Guisarme)");
			ar.Add("Improved Critical (Halberd)");
			ar.Add("Improved Critical (Longspear)");
			ar.Add("Improved Critical (Ranseur)");
			ar.Add("Improved Critical (Scythe)");
			ar.Add("Improved Critical (Shortbow)");
			ar.Add("Improved Critical (Composite Shortbow)");
			ar.Add("Improved Critical (Longbow)");
			ar.Add("Improved Critical (Composite Longbow)");
			ar.Add("Improved Critical (Halfling Kama)");
			ar.Add("Improved Critical (Kukri)");
			ar.Add("Improved Critical (Halfling Nunchaku)");
			ar.Add("Improved Critical (Halfling Siangham)");
			ar.Add("Improved Critical (Kama)");
			ar.Add("Improved Critical (Nunchaku)");
			ar.Add("Improved Critical (Siangham)");
			ar.Add("Improved Critical (Bastard Sword)");
			ar.Add("Improved Critical (Dwarven Waraxe)");
			ar.Add("Improved Critical (Gnome Hooked Hammer)");
			ar.Add("Improved Critical (Orc Double Axe)");
			ar.Add("Improved Critical (Spike Chain)");
			ar.Add("Improved Critical (Dire Flail)");
			ar.Add("Improved Critical (Two-bladed Sword)");
			ar.Add("Improved Critical (Dwarven Urgrosh)");
			ar.Add("Improved Critical (Hand Crossbow)");
			ar.Add("Improved Critical (Shuriken)");
			ar.Add("Improved Critical (Whip)");
			ar.Add("Improved Critical (Repeating Crossbow)");
			ar.Add("Improved Critical (Net)");
			ar.Add("Improved Disarm");
			ar.Add("Improved Feint");
			ar.Add("Improved Grapple");
			ar.Add("Improved Initiative");
			ar.Add("Improved Overrun");
			ar.Add("Improved Shield Bash");
			ar.Add("Improved Trip");
			ar.Add("Improved Two-Weapon Fighting");
			ar.Add("Improved Turning");
			ar.Add("Improved Unarmed Strike");
			ar.Add("Improved Uncanny Dodge");
			ar.Add("Investigator");
			ar.Add("Iron Will");
			ar.Add("Leadership");
			ar.Add("Lightning Reflexes");
			ar.Add("Magical Affinity");
			ar.Add("Manyshot");
			ar.Add("Martial Weapon Proficiency (Throwing Axe)");
			ar.Add("Martial Weapon Proficiency (Light Hammer)");
			ar.Add("Martial Weapon Proficiency (Handaxe)");
			ar.Add("Martial Weapon Proficiency (Light Lance)");
			ar.Add("Martial Weapon Proficiency (Light Pick)");
			ar.Add("Martial Weapon Proficiency (Sap)");
			ar.Add("Martial Weapon Proficiency (Short Sword)");
			ar.Add("Martial Weapon Proficiency (Battleaxe)");
			ar.Add("Martial Weapon Proficiency (Light Flail)");
			ar.Add("Martial Weapon Proficiency (Heavy Lance)");
			ar.Add("Martial Weapon Proficiency (Longsword)");
			ar.Add("Martial Weapon Proficiency (Heavy Pick)");
			ar.Add("Martial Weapon Proficiency (Rapier)");
			ar.Add("Martial Weapon Proficiency (Scimitar)");
			ar.Add("Martial Weapon Proficiency (Trident)");
			ar.Add("Martial Weapon Proficiency (Warhammer)");
			ar.Add("Martial Weapon Proficiency (Falchion)");
			ar.Add("Martial Weapon Proficiency (Heavy Flail)");
			ar.Add("Martial Weapon Proficiency (Glaive)");
			ar.Add("Martial Weapon Proficiency (Greataxe)");
			ar.Add("Martial Weapon Proficiency (Greatclub)");
			ar.Add("Martial Weapon Proficiency (Greatsword)");
			ar.Add("Martial Weapon Proficiency (Guisarme)");
			ar.Add("Martial Weapon Proficiency (Halberd)");
			ar.Add("Martial Weapon Proficiency (Longspear)");
			ar.Add("Martial Weapon Proficiency (Ranseur)");
			ar.Add("Martial Weapon Proficiency (Scythe)");
			ar.Add("Martial Weapon Proficiency (Shortbow)");
			ar.Add("Martial Weapon Proficiency (Composite Shortbow)");
			ar.Add("Martial Weapon Proficiency (Longbow)");
			ar.Add("Martial Weapon Proficiency (Composite Longbow)");
			ar.Add("Maximize Spell");
			ar.Add("Mobility");
			ar.Add("Mounted Archery");
			ar.Add("Mounted Combat");
			ar.Add("Natural Spell");
			ar.Add("Negotiator");
			ar.Add("Nimble Fingers");
			ar.Add("Persuasive");
			ar.Add("Point Blank Shot");
			ar.Add("Power Attack");
			ar.Add("Precise Shot");
			ar.Add("Quick Draw");
			ar.Add("Quicken Spell");
			ar.Add("Rapid Shot");
			ar.Add("Rapid Reload");
			ar.Add("Ride-by Attack");
			ar.Add("Run");
			ar.Add("Scribe Scroll");
			ar.Add("Self Sufficient");
			ar.Add("Shield Proficiency");
			ar.Add("Shot on the Run");
			ar.Add("Silent Spell");
			ar.Add("Simple Weapon Proficiency");
			ar.Add("Skill Focus (Alchemy)");
			ar.Add("Skill Focus (Animal Empathy)");
			ar.Add("Skill Focus (Appraise)");
			ar.Add("Skill Focus (Balance)");
			ar.Add("Skill Focus (Bluff)");
			ar.Add("Skill Focus (Climb)");
			ar.Add("Skill Focus (Concentration)");
			ar.Add("Skill Focus (Craft)");
			ar.Add("Skill Focus (Decipher Script)");
			ar.Add("Skill Focus (Diplomacy)");
			ar.Add("Skill Focus (Disable Device)");
			ar.Add("Skill Focus (Disguise)");
			ar.Add("Skill Focus (Escape Artist)");
			ar.Add("Skill Focus (Forgery)");
			ar.Add("Skill Focus (Gather Information)");
			ar.Add("Skill Focus (Handle Animal)");
			ar.Add("Skill Focus (Heal)");
			ar.Add("Skill Focus (Hide)");
			ar.Add("Skill Focus (Innuendo)");
			ar.Add("Skill Focus (Intimidate)");
			ar.Add("Skill Focus (Intuit Direction)");
			ar.Add("Skill Focus (Jump)");
			ar.Add("Skill Focus (Knowledge)");
			ar.Add("Skill Focus (Listen)");
			ar.Add("Skill Focus (Move Silently)");
			ar.Add("Skill Focus (Open Lock)");
			ar.Add("Skill Focus (Performance)");
			ar.Add("Skill Focus (Pick Pocket)");
			ar.Add("Skill Focus (Profession)");
			ar.Add("Skill Focus (Read Lips)");
			ar.Add("Skill Focus (Ride)");
			ar.Add("Skill Focus (Scry)");
			ar.Add("Skill Focus (Search)");
			ar.Add("Skill Focus (Sense Motive)");
			ar.Add("Skill Focus (Speak Language)");
			ar.Add("Skill Focus (Spellcraft)");
			ar.Add("Skill Focus (Spot)");
			ar.Add("Skill Focus (Swim)");
			ar.Add("Skill Focus (Tumble)");
			ar.Add("Skill Focus (Use Device)");
			ar.Add("Skill Focus (Use Rope)");
			ar.Add("Skill Focus (Survival)");
			ar.Add("Snatch Arrows");
			ar.Add("Spell Focus (Abjuration)");
			ar.Add("Spell Focus (Conjuration)");
			ar.Add("Spell Focus (Divination)");
			ar.Add("Spell Focus (Enchantment)");
			ar.Add("Spell Focus (Evocation)");
			ar.Add("Spell Focus (Illusion)");
			ar.Add("Spell Focus (Necromancy)");
			ar.Add("Spell Focus (Transmutation)");
			ar.Add("Spell Mastery");
			ar.Add("Spell Penetration");
			ar.Add("Spirited Charge");
			ar.Add("Spring Attack");
			ar.Add("Stealthy");
			ar.Add("Still Spell");
			ar.Add("Stunning Fist");
			ar.Add("Sunder");
			ar.Add("Toughness");
			ar.Add("Tower Shield Proficiency");
			ar.Add("Track");
			ar.Add("Trample");
			ar.Add("Two-Weapon Fighting");
			ar.Add("Two-Weapon Defense");
			ar.Add("Weapon Finesse (Gauntlet)");
			ar.Add("Weapon Finesse (Unarmed strike)");
			ar.Add("Weapon Finesse (Unarmed strike - small being)");
			ar.Add("Weapon Finesse (Dagger)");
			ar.Add("Weapon Finesse (Punching Dagger)");
			ar.Add("Weapon Finesse (Spiked Gauntlet)");
			ar.Add("Weapon Finesse (Light Mace)");
			ar.Add("Weapon Finesse (Sickle)");
			ar.Add("Weapon Finesse (Club)");
			ar.Add("Weapon Finesse (Shortspear)");
			ar.Add("Weapon Finesse (Heavy mace)");
			ar.Add("Weapon Finesse (Morningstar)");
			ar.Add("Weapon Finesse (Quarterstaff)");
			ar.Add("Weapon Finesse (Spear)");
			ar.Add("Weapon Finesse (Light Crossbow)");
			ar.Add("Weapon Finesse (Dart)");
			ar.Add("Weapon Finesse (Sling)");
			ar.Add("Weapon Finesse (Heavy Crossbow)");
			ar.Add("Weapon Finesse (Javelin)");
			ar.Add("Weapon Finesse (Throwing Axe)");
			ar.Add("Weapon Finesse (Light Hammer)");
			ar.Add("Weapon Finesse (Handaxe)");
			ar.Add("Weapon Finesse (Light Lance)");
			ar.Add("Weapon Finesse (Light Pick)");
			ar.Add("Weapon Finesse (Sap)");
			ar.Add("Weapon Finesse (Short Sword)");
			ar.Add("Weapon Finesse (Battleaxe)");
			ar.Add("Weapon Finesse (Light Flail)");
			ar.Add("Weapon Finesse (Heavy Lance)");
			ar.Add("Weapon Finesse (Longsword)");
			ar.Add("Weapon Finesse (Heavy Pick)");
			ar.Add("Weapon Finesse (Rapier)");
			ar.Add("Weapon Finesse (Scimitar)");
			ar.Add("Weapon Finesse (Trident)");
			ar.Add("Weapon Finesse (Warhammer)");
			ar.Add("Weapon Finesse (Falchion)");
			ar.Add("Weapon Finesse (Heavy Flail)");
			ar.Add("Weapon Finesse (Glaive)");
			ar.Add("Weapon Finesse (Greataxe)");
			ar.Add("Weapon Finesse (Greatclub)");
			ar.Add("Weapon Finesse (Greatsword)");
			ar.Add("Weapon Finesse (Guisarme)");
			ar.Add("Weapon Finesse (Halberd)");
			ar.Add("Weapon Finesse (Longspear)");
			ar.Add("Weapon Finesse (Ranseur)");
			ar.Add("Weapon Finesse (Scythe)");
			ar.Add("Weapon Finesse (Shortbow)");
			ar.Add("Weapon Finesse (Composite Shortbow)");
			ar.Add("Weapon Finesse (Longbow)");
			ar.Add("Weapon Finesse (Composite Longbow)");
			ar.Add("Weapon Finesse (Halfling Kama)");
			ar.Add("Weapon Finesse (Kukri)");
			ar.Add("Weapon Finesse (Halfling Nunchaku)");
			ar.Add("Weapon Finesse (Halfling Siangham)");
			ar.Add("Weapon Finesse (Kama)");
			ar.Add("Weapon Finesse (Nunchaku)");
			ar.Add("Weapon Finesse (Siangham)");
			ar.Add("Weapon Finesse (Bastard Sword)");
			ar.Add("Weapon Finesse (Dwarven Waraxe)");
			ar.Add("Weapon Finesse (Gnome Hooked Hammer)");
			ar.Add("Weapon Finesse (Orc Double Axe)");
			ar.Add("Weapon Finesse (Spike Chain)");
			ar.Add("Weapon Finesse (Dire Flail)");
			ar.Add("Weapon Finesse (Two-bladed Sword)");
			ar.Add("Weapon Finesse (Dwarven Urgrosh)");
			ar.Add("Weapon Finesse (Hand Crossbow)");
			ar.Add("Weapon Finesse (Shuriken)");
			ar.Add("Weapon Finesse (Whip)");
			ar.Add("Weapon Finesse (Repeating Crossbow)");
			ar.Add("Weapon Finesse (Net)");
			ar.Add("Weapon Finesse (Grapple)");
			ar.Add("Weapon Finesse (Ray)");
			ar.Add("Weapon Focus (Gauntlet)");
			ar.Add("Weapon Focus (Unarmed strike)");
			ar.Add("Weapon Focus (Unarmed strike - small being)");
			ar.Add("Weapon Focus (Dagger)");
			ar.Add("Weapon Focus (Punching Dagger)");
			ar.Add("Weapon Focus (Spiked Gauntlet)");
			ar.Add("Weapon Focus (Light Mace)");
			ar.Add("Weapon Focus (Sickle)");
			ar.Add("Weapon Focus (Club)");
			ar.Add("Weapon Focus (Shortspear)");
			ar.Add("Weapon Focus (Heavy mace)");
			ar.Add("Weapon Focus (Morningstar)");
			ar.Add("Weapon Focus (Quarterstaff)");
			ar.Add("Weapon Focus (Spear)");
			ar.Add("Weapon Focus (Light Crossbow)");
			ar.Add("Weapon Focus (Dart)");
			ar.Add("Weapon Focus (Sling)");
			ar.Add("Weapon Focus (Heavy Crossbow)");
			ar.Add("Weapon Focus (Javelin)");
			ar.Add("Weapon Focus (Throwing Axe)");
			ar.Add("Weapon Focus (Light Hammer)");
			ar.Add("Weapon Focus (Handaxe)");
			ar.Add("Weapon Focus (Light Lance)");
			ar.Add("Weapon Focus (Light Pick)");
			ar.Add("Weapon Focus (Sap)");
			ar.Add("Weapon Focus (Short Sword)");
			ar.Add("Weapon Focus (Battleaxe)");
			ar.Add("Weapon Focus (Light Flail)");
			ar.Add("Weapon Focus (Heavy Lance)");
			ar.Add("Weapon Focus (Longsword)");
			ar.Add("Weapon Focus (Heavy Pick)");
			ar.Add("Weapon Focus (Rapier)");
			ar.Add("Weapon Focus (Scimitar)");
			ar.Add("Weapon Focus (Trident)");
			ar.Add("Weapon Focus (Warhammer)");
			ar.Add("Weapon Focus (Falchion)");
			ar.Add("Weapon Focus (Heavy Flail)");
			ar.Add("Weapon Focus (Glaive)");
			ar.Add("Weapon Focus (Greataxe)");
			ar.Add("Weapon Focus (Greatclub)");
			ar.Add("Weapon Focus (Greatsword)");
			ar.Add("Weapon Focus (Guisarme)");
			ar.Add("Weapon Focus (Halberd)");
			ar.Add("Weapon Focus (Longspear)");
			ar.Add("Weapon Focus (Ranseur)");
			ar.Add("Weapon Focus (Scythe)");
			ar.Add("Weapon Focus (Shortbow)");
			ar.Add("Weapon Focus (Composite Shortbow)");
			ar.Add("Weapon Focus (Longbow)");
			ar.Add("Weapon Focus (Composite Longbow)");
			ar.Add("Weapon Focus (Halfling Kama)");
			ar.Add("Weapon Focus (Kukri)");
			ar.Add("Weapon Focus (Halfling Nunchaku)");
			ar.Add("Weapon Focus (Halfling Siangham)");
			ar.Add("Weapon Focus (Kama)");
			ar.Add("Weapon Focus (Nunchaku)");
			ar.Add("Weapon Focus (Siangham)");
			ar.Add("Weapon Focus (Bastard Sword)");
			ar.Add("Weapon Focus (Dwarven Waraxe)");
			ar.Add("Weapon Focus (Gnome Hooked Hammer)");
			ar.Add("Weapon Focus (Orc Double Axe)");
			ar.Add("Weapon Focus (Spike Chain)");
			ar.Add("Weapon Focus (Dire Flail)");
			ar.Add("Weapon Focus (Two-bladed Sword)");
			ar.Add("Weapon Focus (Dwarven Urgrosh)");
			ar.Add("Weapon Focus (Hand Crossbow)");
			ar.Add("Weapon Focus (Shuriken)");
			ar.Add("Weapon Focus (Whip)");
			ar.Add("Weapon Focus (Repeating Crossbow)");
			ar.Add("Weapon Focus (Net)");
			ar.Add("Weapon Focus (Grapple)");
			ar.Add("Weapon Focus (Ray)");
			ar.Add("Weapon Specialization (Gauntlet)");
			ar.Add("Weapon Specialization (Unarmed strike)");
			ar.Add("Weapon Specialization (Unarmed strike - small being)");
			ar.Add("Weapon Specialization (Dagger)");
			ar.Add("Weapon Specialization (Punching Dagger)");
			ar.Add("Weapon Specialization (Spiked Gauntlet)");
			ar.Add("Weapon Specialization (Light Mace)");
			ar.Add("Weapon Specialization (Sickle)");
			ar.Add("Weapon Specialization (Club)");
			ar.Add("Weapon Specialization (Shortspear)");
			ar.Add("Weapon Specialization (Heavy mace)");
			ar.Add("Weapon Specialization (Morningstar)");
			ar.Add("Weapon Specialization (Quarterstaff)");
			ar.Add("Weapon Specialization (Spear)");
			ar.Add("Weapon Specialization (Light Crossbow)");
			ar.Add("Weapon Specialization (Dart)");
			ar.Add("Weapon Specialization (Sling)");
			ar.Add("Weapon Specialization (Heavy Crossbow)");
			ar.Add("Weapon Specialization (Javelin)");
			ar.Add("Weapon Specialization (Throwing Axe)");
			ar.Add("Weapon Specialization (Light Hammer)");
			ar.Add("Weapon Specialization (Handaxe)");
			ar.Add("Weapon Specialization (Light Lance)");
			ar.Add("Weapon Specialization (Light Pick)");
			ar.Add("Weapon Specialization (Sap)");
			ar.Add("Weapon Specialization (Short Sword)");
			ar.Add("Weapon Specialization (Battleaxe)");
			ar.Add("Weapon Specialization (Light Flail)");
			ar.Add("Weapon Specialization (Heavy Lance)");
			ar.Add("Weapon Specialization (Longsword)");
			ar.Add("Weapon Specialization (Heavy Pick)");
			ar.Add("Weapon Specialization (Rapier)");
			ar.Add("Weapon Specialization (Scimitar)");
			ar.Add("Weapon Specialization (Trident)");
			ar.Add("Weapon Specialization (Warhammer)");
			ar.Add("Weapon Specialization (Falchion)");
			ar.Add("Weapon Specialization (Heavy Flail)");
			ar.Add("Weapon Specialization (Glaive)");
			ar.Add("Weapon Specialization (Greataxe)");
			ar.Add("Weapon Specialization (Greatclub)");
			ar.Add("Weapon Specialization (Greatsword)");
			ar.Add("Weapon Specialization (Guisarme)");
			ar.Add("Weapon Specialization (Halberd)");
			ar.Add("Weapon Specialization (Longspear)");
			ar.Add("Weapon Specialization (Ranseur)");
			ar.Add("Weapon Specialization (Scythe)");
			ar.Add("Weapon Specialization (Shortbow)");
			ar.Add("Weapon Specialization (Composite Shortbow)");
			ar.Add("Weapon Specialization (Longbow)");
			ar.Add("Weapon Specialization (Composite Longbow)");
			ar.Add("Weapon Specialization (Halfling Kama)");
			ar.Add("Weapon Specialization (Kukri)");
			ar.Add("Weapon Specialization (Halfling Nunchaku)");
			ar.Add("Weapon Specialization (Halfling Siangham)");
			ar.Add("Weapon Specialization (Kama)");
			ar.Add("Weapon Specialization (Nunchaku)");
			ar.Add("Weapon Specialization (Siangham)");
			ar.Add("Weapon Specialization (Bastard Sword)");
			ar.Add("Weapon Specialization (Dwarven Waraxe)");
			ar.Add("Weapon Specialization (Gnome Hooked Hammer)");
			ar.Add("Weapon Specialization (Orc Double Axe)");
			ar.Add("Weapon Specialization (Spike Chain)");
			ar.Add("Weapon Specialization (Dire Flail)");
			ar.Add("Weapon Specialization (Two-bladed Sword)");
			ar.Add("Weapon Specialization (Dwarven Urgrosh)");
			ar.Add("Weapon Specialization (Hand Crossbow)");
			ar.Add("Weapon Specialization (Shuriken)");
			ar.Add("Weapon Specialization (Whip)");
			ar.Add("Weapon Specialization (Repeating Crossbow)");
			ar.Add("Weapon Specialization (Net)");
			ar.Add("Weapon Specialization (Grapple)");
			ar.Add("Whirlwind Attack");
			ar.Add("Barbarian Rage");
			ar.Add("Stunning Attacks");
			ar.Add("Wholeness of Body");
			ar.Add("Lay on Hands");
			ar.Add("Smite Evil");
			ar.Add("Remove Disease");
			ar.Add("Detect Evil");
			ar.Add("Aura of Courage");
			ar.Add("Divine Health");
			ar.Add("Divine Grace");
			ar.Add("Special Mount");
			ar.Add("Code of Conduct");
			ar.Add("Associates");
			ar.Add("Defensive Roll");
			ar.Add("Turn Undead");
			ar.Add("Rebuke Undead");
			ar.Add("Domain Power");
			ar.Add("Spontaneous Casting Cure");
			ar.Add("Spontaneous Casting Inflict");
			ar.Add("Combat Reflexes");
			ar.Add("Martial Weapon Proficiency All");
			ar.Add("Simple Weapon Proficiency Druid");
			ar.Add("Simple Weapon Proficiency Monk");
			ar.Add("Simple Weapon Proficiency Rogue");
			ar.Add("Simple Weapon Proficiency Wizard");
			ar.Add("Simple Weapon Proficiency Elf");
			ar.Add("Uncanny Dodge");
			ar.Add("Fast Movement");
			ar.Add("Bardic Music");
			ar.Add("Bardic Knowledge");
			ar.Add("Nature Sense");
			ar.Add("Woodland Stride");
			ar.Add("Trackless Step");
			ar.Add("Resist Natures Lure");
			ar.Add("Wild Shape");
			ar.Add("Venom Immunity");
			ar.Add("Armor Proficiency Druid");
			ar.Add("Flurry of Blows");
			ar.Add("Evasion");
			ar.Add("Still Mind");
			ar.Add("Purity of Body");
			ar.Add("Improved Evasion");
			ar.Add("Ki Strike");
			ar.Add("Sneak Attack");
			ar.Add("Trapfinding");
			ar.Add("Crippling Strike");
			ar.Add("Opportunist");
			ar.Add("Skill Mastery");
			ar.Add("Slippery Mind");
			ar.Add("Call Familiar");
			ar.Add("Favored Enemy Aberration");
			ar.Add("Favored Enemy Animal");
			ar.Add("Favored Enemy Beast");
			ar.Add("Favored Enemy Construct");
			ar.Add("Favored Enemy Dragon");
			ar.Add("Favored Enemy Elemental");
			ar.Add("Favored Enemy Fey");
			ar.Add("Favored Enemy Giant");
			ar.Add("Favored Enemy Magical Beast");
			ar.Add("Favored Enemy Monsterous Humanoid");
			ar.Add("Favored Enemy Ooze");
			ar.Add("Favored Enemy Plant");
			ar.Add("Favored Enemy Shapechanger");
			ar.Add("Favored Enemy Undead");
			ar.Add("Favored Enemy Vermin");
			ar.Add("Favored Enemy Outsider Evil");
			ar.Add("Favored Enemy Outsider Good");
			ar.Add("Favored Enemy Outsider Lawful");
			ar.Add("Favored Enemy Outsider Chaotic");
			ar.Add("Favored Enemy Humanoid Goblinoid");
			ar.Add("Favored Enemy Humanoid Reptilian");
			ar.Add("Favored Enemy Humanoid Dwarf");
			ar.Add("Favored Enemy Humanoid Elf");
			ar.Add("Favored Enemy Humanoid Gnoll");
			ar.Add("Favored Enemy Humanoid Gnome");
			ar.Add("Favored Enemy Humanoid Halfling");
			ar.Add("Favored Enemy Humanoid Orc");
			ar.Add("Favored Enemy Humanoid Human");
			ar.Add("Ambidexterity Ranger");
			ar.Add("Two Weapon Fighting Ranger");
			ar.Add("Improved Two Weapon Fighting Ranger");
			ar.Add("Animal Companion");
			ar.Add("Two Weapon Fighting Style");
			ar.Add("Archery Style");
			ar.Add("Widen Spell");
			ar.Add("Rapid Shot (Ranger)");
			ar.Add("Many Shot (Ranger)");
			ar.Add("Simple Weapon Proficiency Bard");

			return ar;
		}
	}
}
