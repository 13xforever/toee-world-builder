using System.Collections.Generic;
using System.IO;

namespace WorldBuilder.Helpers
{
	public static class IntelliProperties
	{
		static IntelliProperties()
		{
			Empty = new string[0];
			Feats = ReadFeats();
		}

		public static string[] Get(int idx)
		{
			switch (idx)
			{
				case   1: return ObjectType;
				case  20: return ObjectFlags;
				case  21: return SpellFlags;
				case  24: return ObjectSize;
				case  27: return Material;
				case  37: return PortalFlags;
				case  41: return ContainerFlags;
				case  46: return SceneryFlags;
				case  50: return ItemFlags;
				case  61: return InventorySlotFlags;
				case  63: return WeaponFlags;
				case  65: return MissileType;
				case  69: return DamageType;
				case  72: return WeaponClass;
				case  74: return AmmoFlags;
				case  76: return AmmoType;
				case  77: return ArmorFlags;
				case  82: return ArmorType;
				case  83: return HelmType;
				case  86: return CoinType;
				case  87: return FoodFlags;
				case  94: return BagOfHoldingFlags;
				case  96: return GenericFlags;
				case  99: return CritterFlags;
				case 100: return CritterFlags2;
				case 108: return Race;
				case 109: return Gender;
				case 113: return Alignment;
				case 114: return Deity;
				case 115:
				case 116: return Domain;
				case 117: return PositiveAndNegative;
				case 134:
				case 138:
				case 142:
				case 146: return MonsterDamageType;
				case 148: return HairColor;
				case 149: return HairType;
				case 152: return NpcFlags;
				case 163: return CreatureType;
				case 164: return CreatureSubType;
				case 165: return NpcLootShare;
				case 166: return TrapFlags;
				case 228:
				case 230:
				case 232:
				case 234:
				case 236: return Class;
				case 238:
				case 240:
				case 242:
				case 244:
				case 246:
				case 248:
				case 250:
				case 252:
				case 254:
				case 256: return Skills;
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
				case 225: return ItemProperties;
				case 258:
				case 259:
				case 260:
				case 261:
				case 262:
				case 263:
				case 264:
				case 265:
				case 266:
				case 267: return Feats;
				default : return Empty;
			}
		}

		private static readonly string[] ObjectType = new[]
						{
							"obj_t_bag",
							"obj_t_trap",
							"obj_t_npc",
							"obj_t_pc",
							"obj_t_generic",
							"obj_t_written",
							"obj_t_key",
							"obj_t_scroll",
							"obj_t_food",
							"obj_t_money",
							"obj_t_armor",
							"obj_t_ammo",
							"obj_t_weapon",
							"obj_t_projectile",
							"obj_t_scenery",
							"obj_t_container",
							"obj_t_portal"
						};

		private static readonly string[] ObjectFlags = new[]
						{
							"OF_RADIUS_SET",
							"OF_TELEPORTED",
							"OF_ANIMATED_DEAD",
							"OF_HEIGHT_SET",
							"OF_UNUSED_08000000",
							"OF_DISALLOW_WADING",
							"OF_TRAP_SPOTTED",
							"OF_TRAP_PC",
							"OF_EXTINCT",
							"OF_INVULNERABLE",
							"OF_TEXT_FLOATER",
							"OF_DONTLIGHT",
							"OF_STONED",
							"OF_UNUSED_40000",
							"OF_WADING",
							"OF_NOHEIGHT",
							"OF_RANDOM_SIZE",
							"OF_PROVIDES_COVER",
							"OF_DYNAMIC",
							"OF_INVENTORY",
							"OF_CLICK_THROUGH",
							"OF_NO_BLOCK",
							"OF_INVISIBLE",
							"OF_DONTDRAW",
							"OF_SHRUNK",
							"OF_TRANSLUCENT",
							"OF_SHOOT_THROUGH",
							"OF_SEE_THROUGH",
							"OF_TEXT",
							"OF_FLAT",
							"OF_OFF",
							"OF_DESTROYED"
						};

		private static readonly string[] SpellFlags = new []
						{
							"OSF_HARDENED_HANDS",
							"OSF_FAMILIAR",
							"OSF_ENSHROUDED",
							"OSF_DRUNK",
							"OSF_MIND_CONTROLLED",
							"OSF_TEMPUS_FUGIT",
							"OSF_SPOKEN_WITH_DEAD",
							"OSF_ENTANGLED",
							"OSF_CHARMED",
							"OSF_MAGNETIC_INVERSION",
							"OSF_WATER_WALKING",
							"OSF_PASSWALLED",
							"OSF_SHRUNK",
							"OSF_MIRRORED",
							"OSF_POLYMORPHED",
							"OSF_STONED",
							"OSF_ILLUSION",
							"OSF_SUMMONED",
							"OSF_FULL_REFLECTION",
							"OSF_BONDS_OF_MAGIC",
							"OSF_ANTI_MAGIC_SHELL",
							"OSF_SHIELDED",
							"OSF_DETECTING_INVISIBLE",
							"OSF_DETECTING_TRAPS",
							"OSF_DETECTING_ALIGNMENT",
							"OSF_DETECTING_MAGIC",
							"OSF_BODY_OF_WATER",
							"OSF_BODY_OF_AIR",
							"OSF_BODY_OF_EARTH",
							"OSF_BODY_OF_FIRE",
							"OSF_FLOATING",
							"OSF_INVISIBLE"
						};

		private static readonly string[] ObjectSize = new [] {"size_clossal", "size_gargantuan", "size_huge", "size_large", "size_medium", "size_small", "size_tiny", "size_fine", "size_none"};
		private static readonly string[] Material = new [] {"mat_powder", "mat_fire", "mat_force", "mat_gas", "mat_paper", "mat_liquid", "mat_cloth", "mat_glass", "mat_metal", "mat_flesh", "mat_plant", "mat_wood", "mat_brick", "mat_stone"};
		private static readonly string[] PortalFlags = new [] {"OPF_OPEN", "OPF_NOT_STICKY", "OPF_BUSTED", "OPF_LOCKED_NIGHT", "OPF_LOCKED_DAY", "OPF_ALWAYS_LOCKED", "OPF_NEVER_LOCKED", "OPF_MAGICALLY_HELD", "OPF_JAMMED", "OPF_LOCKED"};

		private static readonly string[] ContainerFlags = new []
						{
							"OCOF_HAS_BEEN_OPENED",
							"OCOF_OPEN",
							"OCOF_INVEN_SPAWN_INDEPENDENT",
							"OCOF_INVEN_SPAWN_ONCE",
							"OCOF_NOT_STICKY",
							"OCOF_BUSTED",
							"OCOF_LOCKED_NIGHT",
							"OCOF_LOCKED_DAY",
							"OCOF_ALWAYS_LOCKED",
							"OCOF_NEVER_LOCKED",
							"OCOF_MAGICALLY_HELD",
							"OCOF_JAMMED",
							"OCOF_LOCKED"
						};

		private static readonly string[] SceneryFlags = new []
						{
							"OSCF_USE_OPEN_WORLDMAP",
							"OSCF_TAGGED_SCENERY",
							"OSCF_RESPAWNING",
							"OSCF_UNDER_ALL",
							"OSCF_SOUND_EXTRA_LARGE",
							"OSCF_SOUND_MEDIUM",
							"OSCF_SOUND_SMALL",
							"OSCF_RESPAWNABLE",
							"OSCF_IS_FIRE",
							"OSCF_MARKS_TOWNMAP",
							"OSCF_NOCTURNAL",
							"OSCF_BUSTED",
							"OSCF_NO_AUTO_ANIMATE"
						};

		private static readonly string[] ItemFlags = new []
						{
							"OIF_NO_TRANSFER",
							"OIF_USES_WAND_ANIM",
							"OIF_NO_LOOT",
							"OIF_EXPIRES_AFTER_USE",
							"OIF_DRAW_WHEN_PARENTED",
							"OIF_VALID_AI_ACTION",
							"OIF_NO_RANGED_USE",
							"OIF_NO_NPC_PICKUP",
							"OIF_UBER",
							"OIF_NO_DECAY",
							"OIF_USE_IS_THROW",
							"OIF_STOLEN",
							"OIF_MT_TRIGGERED",
							"OIF_PERSISTENT",
							"OIF_LIGHT_XLARGE",
							"OIF_LIGHT_LARGE",
							"OIF_LIGHT_MEDIUM",
							"OIF_LIGHT_SMALL",
							"OIF_NEEDS_TARGET",
							"OIF_CAN_USE_BOX",
							"OIF_NEEDS_SPELL",
							"OIF_NO_DROP",
							"OIF_NO_DISPLAY",
							"OIF_NO_PICKPOCKET",
							"OIF_IS_MAGICAL",
							"OIF_WONT_SELL",
							"OIF_IDENTIFIED"
						};

		private static readonly string[] InventorySlotFlags = new []
						{
							"OIF_WEAR_2HAND_REQUIRED",
							"OIF_WEAR_LOCKPICKS",
							"OIF_WEAR_BARDIC_ITEM",
							"OIF_WEAR_BRACERS",
							"OIF_WEAR_ROBES",
							"OIF_WEAR_BUCKLER",
							"OIF_WEAR_CLOAK",
							"OIF_WEAR_AMMO",
							"OIF_WEAR_BOOTS",
							"OIF_WEAR_UNUSED_3",
							"OIF_WEAR_RING",
							"OIF_WEAR_ARMOR",
							"OIF_WEAR_UNUSED_2",
							"OIF_WEAR_UNUSED_1",
							"OIF_WEAR_GLOVES",
							"OIF_WEAR_NECKLACE",
							"OIF_WEAR_HELMET"
						};

		private static readonly string[] WeaponFlags = new []
						{
							"OWF_MAGIC_STAFF",
							"OWF_WEAPON_LOADED",
							"OWF_RANGED_WEAPON",
							"OWF_DEFAULT_THROWS",
							"OWF_DAMAGE_ARMOR",
							"OWF_IGNORE_RESISTANCE",
							"OWF_BOOMERANGS",
							"OWF_TRANS_PROJECTILE",
							"OWF_THROWABLE",
							"OWF_UNUSED_2",
							"OWF_UNUSED_1",
							"OWF_SILENT",
							"OWF_LOUD",
							"OWF_TWO_HANDED"
						};

		private static readonly string[] MissileType = new[]
						{
							"bottle",
							"ball_of_fire",
							"shuriken",
							"halfling_sai",
							"trident",
							"light_hammer",
							"throwing_axe",
							"javelin",
							"dart",
							"spear",
							"shortspear",
							"club",
							"dagger",
							"magic_missile",
							"bullet",
							"bolt",
							"arrow"
						};

		private static readonly string[] DamageType = new []
						{
							"D20DT_MAGIC",
							"D20DT_BLOOD_LOSS",
							"D20DT_FORCE",
							"D20DT_POSITIVE_ENERGY",
							"D20DT_POISON",
							"D20DT_SUBDUAL",
							"D20DT_NEGATIVE_ENERGY",
							"D20DT_SONIC",
							"D20DT_FIRE",
							"D20DT_ELECTRICITY",
							"D20DT_COLD",
							"D20DT_ACID",
							"D20DT_SLASHING_AND_BLUDGEONING_AND_PIERCING",
							"D20DT_SLASHING_AND_BLUDGEONING",
							"D20DT_PIERCING_AND_SLASHING",
							"D20DT_BLUDGEONING_AND_PIERCING",
							"D20DT_SLASHING",
							"D20DT_PIERCING",
							"D20DT_BLUDGEONING",
							"D20DT_UNSPECIFIED"
						};

		private static readonly string[] WeaponClass = new []
						{
							"grenade",
							"grapple",
							"repeating_crossbow",
							"whip",
							"hand_crossbow",
							"dwarven_urgrosh",
							"two_bladed_sword",
							"dire_flail",
							"spike_chain",
							"orc_double_axe",
							"gnome_hooked_hammer",
							"dwarven_waraxe",
							"bastard_sword",
							"siangham",
							"nunchaku",
							"kama",
							"halfling_siangham",
							"halfling_nunchaku",
							"kukri",
							"halfling_kama",
							"composite_longbow",
							"longbow",
							"composite_shortbow",
							"shortbow",
							"scythe",
							"ranseur",
							"longspear",
							"halberd",
							"guisarme",
							"greatsword",
							"greatclub",
							"greataxe",
							"glaive",
							"heavy_flail",
							"falchion",
							"warhammer",
							"scimitar",
							"rapier",
							"heavy_pick",
							"longsword",
							"heavy_lance",
							"light_flail",
							"battleaxe",
							"short_sword",
							"light_pick",
							"light_lance",
							"handaxe",
							"heavy_crossbow",
							"sling",
							"light_crossbow",
							"quarterstaff",
							"morningstar",
							"heavy_mace",
							"sickle",
							"light_mace",
							"spiked_gauntlet",
							"punching_dagger",
							"unarmed_strike_small_being",
							"unarmed_strike_medium_sized_being",
							"gauntlet"
						};

		private static readonly string[] AmmoFlags = new [] {"OAF_NONE"};
		private static readonly string[] AmmoType = new [] {"bullet", "bolt", "arrow"};
		private static readonly string[] ArmorFlags = new[] {"OARF_ARMOR_NONE", "OARF_HELM_TYPE_2", "OARF_HELM_TYPE_1", "OARF_ARMOR_TYPE_2", "OARF_ARMOR_TYPE_1"};
		private static readonly string[] ArmorType = new [] {"ARMOR_TYPE_SHIELD", "ARMOR_TYPE_HEAVY", "ARMOR_TYPE_MEDIUM", "ARMOR_TYPE_LIGHT"};
		private static readonly string[] HelmType = new [] {"HELM_TYPE_LARGE", "HELM_TYPE_MEDIUM", "HELM_TYPE_SMALL"};
		private static readonly string[] CoinType = new [] {"Platinum", "Gold", "Silver", "Copper"};
		private static readonly string[] FoodFlags = new [] {"OFF_NONE"};
		private static readonly string[] BagOfHoldingFlags = new [] {"OBF_HOLDING_1000", "OBF_HOLDING_500"};
		private static readonly string[] GenericFlags = new [] {"OGF_IS_LOCKPICK", "OGF_IS_TRAP_DEVICE", "OGF_IS_GRENADE"};

		private static readonly string[] CritterFlags = new[]
						{
							"OCF_FATIGUE_LIMITING",
							"OCF_UNUSED_40000000",
							"OCF_MECHANICAL",
							"OCF_NON_LETHAL_COMBAT",
							"OCF_NO_FLEE",
							"OCF_UNUSED_04000000",
							"OCF_UNUSED_02000000",
							"OCF_UNRESSURECTABLE",
							"OCF_UNREVIVIFIABLE",
							"OCF_LIGHT_XLARGE",
							"OCF_LIGHT_LARGE",
							"OCF_LIGHT_MEDIUM",
							"OCF_LIGHT_SMALL",
							"OCF_COMBAT_MODE_ACTIVE",
							"OCF_ENCOUNTER",
							"OCF_SPELL_FLEE",
							"OCF_MONSTER",
							"OCF_SURRENDERED",
							"OCF_MUTE",
							"OCF_SLEEPING",
							"OCF_UNUSED_00000800",
							"OCF_UNUSED_00000400",
							"OCF_UNUSED_00000200",
							"OCF_HAS_ARCANE_ABILITY",
							"OCF_BLINDED",
							"OCF_PARALYZED",
							"OCF_STUNNED",
							"OCF_FLEEING",
							"OCF_UNUSED_00000008",
							"OCF_EXPERIENCE_AWARDED",
							"OCF_MOVING_SILENTLY",
							"OCF_IS_CONCEALED"
						};

		private static readonly string[] CritterFlags2 = new[]
						{
							"OCF2_ACTION5_PAUSED",
							"OCF2_ACTION4_PAUSED",
							"OCF2_ACTION3_PAUSED",
							"OCF2_ACTION2_PAUSED",
							"OCF2_ACTION1_PAUSED",
							"OCF2_ACTION0_PAUSED",
							"OCF2_TARGET_LOCK",
							"OCF2_REACTION_6",
							"OCF2_REACTION_5",
							"OCF2_REACTION_4",
							"OCF2_REACTION_3",
							"OCF2_REACTION_2",
							"OCF2_REACTION_1",
							"OCF2_REACTION_0",
							"OCF2_NO_DISINTEGRATE",
							"OCF2_NO_SLIP",
							"OCF2_DARK_SIGHT",
							"OCF2_ELEMENTAL",
							"OCF2_NIGH_INVULNERABLE",
							"OCF2_NO_BLOOD_SPLOTCHES",
							"OCF2_NO_PICKPOCKET",
							"OCF2_NO_DECAY",
							"OCF2_SLOW_PARTY",
							"OCF2_FATIGUE_DRAINING",
							"OCF2_USING_BOOMERANG",
							"OCF2_AUTO_ANIMATES",
							"OCF2_ITEM_STOLEN"
						};

		private static readonly string[] Race = new [] {"race_dwarf", "race_elf", "race_gnome", "race_halfelf", "race_halforc", "race_halfling", "race_human"};
		private static readonly string[] Gender = new [] {"female", "male"};

		private static readonly string[] Alignment = new []
						{
							"align_chaotic_evil",
							"align_lawful_evil",
							"align_neutral_evil",
							"align_chaotic_good",
							"align_lawful_good",
							"align_neutral_good",
							"align_chaotic_neutral",
							"align_lawful_neutral",
							"align_true_neutral"
						};

		private static readonly string[] Deity = new []
						{
							"Ralishaz",
							"Pyremius",
							"Norebo",
							"Procan",
							"Lolth",
							"Zuggtmoy",
							"Old Faith",
							"Yondalla",
							"Wee Jas",
							"Vecna",
							"St. Cuthbert",
							"Pelor",
							"Olidammara",
							"Obad-Hai",
							"Nerull",
							"Moradin",
							"Kord",
							"Hextor",
							"Heironeous",
							"Gruumsh",
							"Garl Glittergold",
							"Fharlanghn",
							"Erythnul",
							"Ehlonna",
							"Corellon Larethian",
							"Boccob",
							"No Deity"
						};

		private static readonly string[] Domain = new []
						{
							"WATER",
							"TRICKERY",
							"TRAVEL",
							"STRENGTH",
							"PROTECTION",
							"PLANT",
							"MAGIC",
							"LUCK",
							"KNOWLEDGE",
							"HEALING",
							"GOOD",
							"FIRE",
							"EVIL",
							"EARTH",
							"DESTRUCTION",
							"DEATH",
							"CHAOS",
							"ANIMAL",
							"NONE"
						};

		private static readonly string[] PositiveAndNegative =  new [] {"Positive", "Negative"};
		private static readonly string[] MonsterDamageType = new[] {"Sting", "Slam", "Slap", "Gore", "Rake", "Claw", "Bite"};
		private static readonly string[] HairColor = new [] {"White", "Pink", "Light Brown", "Brown", "Blue", "Blonde", "Black"};
		private static readonly string[] HairType = new [] {"Ponytail2 (f)", "Medium (m)", "Mohawk (m/f)", "Braids (f)", "Bald (m)", "Pigtails (f)", "Mullet (m)", "Topknot (m/f)", "Shorthair (m/f)", "Ponytail (m/f)", "Longhair (m/f)"};

		private static readonly string[] NpcFlags = new []
						{
							"ONF_EXTRAPLANAR",
							"ONF_BOSS_MONSTER",
							"ONF_NO_ATTACK",
							"ONF_BACKING_OFF",
							"ONF_UNUSED_08000000",
							"ONF_UNUSED_04000000",
							"ONF_UNUSED_02000000",
							"ONF_DEMAINTAIN_SPELLS",
							"ONF_GENERATOR_RATE3",
							"ONF_GENERATOR_RATE2",
							"ONF_GENERATOR_RATE1",
							"ONF_GENERATED",
							"ONF_GENERATOR",
							"ONF_CAST_HIGHEST",
							"ONF_NO_EQUIP",
							"ONF_CHECK_LEADER",
							"ONF_FAMILIAR",
							"ONF_FENCE",
							"ONF_WANDERS_IN_DARK",
							"ONF_WANDERS",
							"ONF_KOS_OVERRIDE",
							"ONF_FORCED_FOLLOWER",
							"ONF_USE_ALERTPOINTS",
							"ONF_KOS",
							"ONF_UNUSED_00000080",
							"ONF_LOGBOOK_IGNORES",
							"ONF_JILTED",
							"ONF_AI_SPREAD_OUT",
							"ONF_AI_WAIT_HERE",
							"ONF_WAYPOINTS_NIGHT",
							"ONF_WAYPOINTS_DAY",
							"ONF_EX_FOLLOWER"
						};

		private static readonly string[] CreatureType = new []
						{
							"mc_type_vermin",
							"mc_type_undead",
							"mc_type_shapechanger",
							"mc_type_plant",
							"mc_type_outsider",
							"mc_type_ooze",
							"mc_type_monstrous_humanoid",
							"mc_type_magical_beast",
							"mc_type_humanoid",
							"mc_type_giant",
							"mc_type_fey",
							"mc_type_elemental",
							"mc_type_dragon",
							"mc_type_construct",
							"mc_type_beast",
							"mc_type_animal",
							"mc_type_aberration"
						};

		private static readonly string[] CreatureSubType = new []
						{
							"mc_subtype_water",
							"mc_subtype_slaadi",
							"mc_subtype_reptilian",
							"mc_subtype_orc",
							"mc_subtype_incorporeal",
							"mc_subtype_lawful",
							"mc_subtype_human",
							"mc_subtype_halfling",
							"mc_subtype_half_orc",
							"mc_subtype_guardinal",
							"mc_subtype_good",
							"mc_subtype_goblinoid",
							"mc_subtype_gnome",
							"mc_subtype_gnoll",
							"mc_subtype_formian",
							"mc_subtype_fire",
							"mc_subtype_evil",
							"mc_subtype_elf",
							"mc_subtype_electricity",
							"mc_subtype_earth",
							"mc_subtype_dwarf",
							"mc_subtype_devil",
							"mc_subtype_demon",
							"mc_subtype_chaotic",
							"mc_subtype_cold",
							"mc_subtype_extraplaner",
							"mc_subtype_aquatic",
							"mc_subtype_air"
						};

		private static readonly string[] NpcLootShare = new [] {"nothing", "one_fifth_of_all", "one_third_of_all", "all_arcane_scrolls_nothing_else", "half_share_money_only", "normal"};
		private static readonly string[] TrapFlags = new [] {"OTF_BUSTED"};
		private static readonly string[] Class = new [] {"Wizard", "Sorcerer", "Rogue", "Ranger", "Fighter", "Druid", "Cleric", "Bard", "Barbarian"};

		private static readonly string[] Skills = new []
						{
							"Bluff",
							"Climb",
							"Concentration",
							"Craft",
							"Diplomacy",
							"Disable Device",
							"Escape Artist",
							"Gather Information",
							"Heal",
							"Hide",
							"Intimidate",
							"Intuit Direction",
							"Jump",
							"Listen",
							"Knowledge (Arcana)",
							"Move Silently",
							"Open Lock",
							"Search",
							"Sense Motive",
							"Spellcraft",
							"Sleight of Hand",
							"Spot",
							"Survival",
							"Swim",
							"Tumble",
							"Use Magic Device"
						};

		private static readonly string[] ItemProperties = new []
						{
							"Bardic-Inspire Greatness",
							"Bardic-Suggestion",
							"Bardic-Inspire Competence",
							"Bardic-Fascinate",
							"Bardic-Countersong",
							"Bardic-Inspire Courage",
							"Failed_Copy_Scroll",
							"Ring of Change",
							"Weapon Silver",
							"Rod of Smiting",
							"Buckler",
							"Useable Item X Times Per Day",
							"Bracers of Archery",
							"Amulet of Natural Armor",
							"Amulet of Mighty Fists",
							"Necklace of Detection",
							"Charisma Competence Bonus",
							"Unholy Water",
							"Holy Water",
							"sp-Spheres of Fire-proj",
							"Jaer",
							"Bardic Instrument Magical",
							"Bardic Instrument",
							"Composite Bow",
							"Thieves Tools Masterwork",
							"Thieves Tools",
							"Normal Projectile Particles",
							"Fragarach",
							"Elemental Gem",
							"Golden Skull",
							"Familiar Hp Bonus",
							"Familiar Save Bonus",
							"Familiar Skill Bonus",
							"Sword of Life Stealing",
							"Ring of Animal Summoning",
							"Weapon Mighty Cleaving",
							"Weapon Flame Tongue",
							"Armor Spell Resistance",
							"Armor Shadow",
							"Armor Silent Moves",
							"Boots of speed",
							"Keoghtom",
							"Ring of freedom of movement",
							"UseableMagicStaff",
							"Elemental Resistance per round",
							"Dagger of Venom",
							"Ring of Invisibility",
							"Staff Of Striking",
							"Elemental Resistance",
							"Proof Against Detection Location",
							"Proof Against Poison",
							"Luck Poison Save Bonus",
							"Frost Bow",
							"Item Particle System",
							"Saving Throw Resistance Bonus",
							"Attribute Enhancement Bonus",
							"Skill Competence Bonus",
							"Skill Circumstance Bonus",
							"UseableItem",
							"Crossbow",
							"Shield Enhancement Bonus",
							"Shield Bonus",
							"Armor Masterwork",
							"Armor Bonus",
							"Damage Bonus",
							"To Hit Bonus",
							"Weapon Chaotic",
							"Weapon Lawful",
							"Weapon Unholy",
							"Weapon Holy",
							"Weapon Shocking Burst",
							"Weapon Icy Burst",
							"Weapon Flaming Burst",
							"Weapon Bane",
							"Weapon Disruption",
							"Weapon Shock",
							"Weapon Frost",
							"Weapon Flaming",
							"Deflection Bonus",
							"Weapon Defending Bonus",
							"Weapon Masterwork",
							"Monster Confusion Immunity",
							"Monster Special Fade Out",
							"Monster Subdual Immunity",
							"Monster Poison Immunity",
							"Monster Fast Healing",
							"Monster Minotaur Charge",
							"Monster Incorporeal",
							"Monster Spider",
							"Monster Hooting Fungi",
							"Monster Untripable",
							"Monster Plant",
							"Monster Stable",
							"Monster Superior Two Weapon Fighting",
							"Monster DR Slashing",
							"Monster DR Bludgeoning",
							"Monster DR Holy",
							"Monster DR Silver",
							"Monster DR All",
							"Monster DR Magic",
							"Monster DR Cold-Holy",
							"Monster DR Cold",
							"Monster Lamia",
							"Monster Zombie",
							"Monster Smiting",
							"Monster Spell Resistance",
							"Monster Juggernaut",
							"Monster Splitting",
							"Monster Ooze Split",
							"Monster Salamander",
							"Monster Regeneration 1",
							"Monster Regeneration 2",
							"Monster Regeneration 5",
							"Monster Energy Resistance",
							"Monster Energy Immunity",
							"Monster Melee Paralysis No Elf",
							"Monster Melee Paralysis",
							"Monster Carrion Crawler",
							"Monster Melee Poison",
							"Monster Melee Disease",
							"Monster Fire Bats",
							"Monster Stirge",
							"Monster Bonus Damage",
							"Monster Damage Type",
							"Monster Banshee Charisma Drain"
						};

		private static readonly string[] Feats;
		private static readonly string[] Empty;

		private static string[] ReadFeats()
		{
			StreamReader reader;
			if (File.Exists("ToEE World Builder.ftd"))
				reader = new StreamReader("ToEE World Builder.ftd");
			else
			{
				var stream = MiscHelper.GetResourceStreamThatEndsWith(".ftd");
				if (stream == null)
					return Empty;

				reader = new StreamReader(stream);
			}
			using (reader)
			{
				var result = new List<string>();
				string str;
				while ((str = reader.ReadLine()) != null)
					result.Add(str.Split('\t')[1].Trim());
				return result.ToArray();
			}
		}
	}
}