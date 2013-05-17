using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using WorldBuilder.Helpers;

namespace WorldBuilder.Forms
{
	public partial class SectorAnalysis : Form
	{
		// IMPORTANT: public variables to carry minX/minY
		public int MinX;
		public int MinY;

		public bool SVB1_STATE;
		public bool SVB2_STATE;
		public bool SVB3_STATE;
		public bool SVB4_STATE;
		public string SVB_BMP = "";

		private readonly Hsd hsd;

		public SectorAnalysis(Hsd hsd)
		{
			InitializeComponent();
			this.hsd = hsd;
		}
		
		/// <summary>
		/// Main routine to draw the sector blocks (4096 10*10 blocks)
		/// </summary>
		private void OnRefreshViewPortClick(object sender, EventArgs e)
		{
			CurPosXY.Text = string.Format("X={0}, Y={1}", MinX, MinY);
			Graphics viewportGfx = viewport.CreateGraphics();

			// Prepare the rectangles
			//for (int X=0; X<64; X++)
			//	for (int Y=0; Y<64; Y++)
			//		ptr_vp.FillRectangle(Brushes.White, 10*X, 10*Y, 10, 10);

			// Draw the blocked stuff
			for (int x1 = 63; x1 >= 0; x1--)
				for (int y1 = 0; y1 < 64; y1++)
				{
					var tile = SecHelper.SectorTiles[y1*64 + x1];

					byte[] wflagbytes = {tile[4], tile[5], tile[6], tile[7]};

					// Load the wall flags (using a MOB routine to carry out the task)
					string WallBitmap = MobHelper.BytesToBitmap(wflagbytes);

					// Test for BLOCKED
					for (int T = 9; T <= 17; T++)
					{
						if (MobHelper.GetPropertyState(WallBitmap, T) == TriState.True)
						{
							viewportGfx.FillRectangle(Brushes.RoyalBlue, 630 - (10*x1), 10*y1, 10, 10);
							break;
						}
					}

					// Test for FLYOVER
					for (int T = 18; T <= 26; T++)
					{
						if (MobHelper.GetPropertyState(WallBitmap, T) == TriState.True)
						{
							viewportGfx.FillRectangle(Brushes.DarkCyan, 630 - (10*x1), 10*y1, 10, 10);
							break;
						}
					}

					// Test for FLYOVER/COVER
					if (MobHelper.GetPropertyState(WallBitmap, 27) == TriState.True)
					{
						viewportGfx.FillRectangle(Brushes.LimeGreen, 630 - (10*x1), 10*y1, 10, 10);
					}

					// Test for SVB_BIT1 (EXTEND)
					if (SVB_BMP != "")
					{
						int SVB_index = SvbHelper.SVB_GetTileAddress(x1, y1); // ptr to UL corner

						for (int i = 0; i <= 2; i++)
						{
							for (int j = 0; j <= 2; j++)
							{
								if (MobHelper.GetPropertyState(SVB_BMP, SVB_index + i*192*4 + j*4) == TriState.True)
								{
									viewportGfx.FillRectangle(Brushes.Sienna, 630 - (10*x1), 10*y1, 7, 7);
									break;
								}
							}
						}
					}

					// Test for SVB_BIT2 (END)
					if (SVB_BMP != "")
					{
						int SVB_index = SvbHelper.SVB_GetTileAddress(x1, y1);

						for (int i = 0; i <= 2; i++)
						{
							for (int j = 0; j <= 2; j++)
							{
								if (MobHelper.GetPropertyState(SVB_BMP, SVB_index + i*192*4 + j*4 + 1) == TriState.True)
								{
									viewportGfx.FillRectangle(Brushes.DarkGoldenrod, 630 - (10*x1), 10*y1, 7, 7);
									break;
								}
							}
						}
					}

					// Test for SVB_BIT3 (ARCHWAY)
					if (SVB_BMP != "")
					{
						int SVB_index = SvbHelper.SVB_GetTileAddress(x1, y1);

						for (int i = 0; i <= 2; i++)
						{
							for (int j = 0; j <= 2; j++)
							{
								if (MobHelper.GetPropertyState(SVB_BMP, SVB_index + i*192*4 + j*4 + 2) == TriState.True)
								{
									viewportGfx.FillRectangle(Brushes.DarkGray, 630 - (10*x1), 10*y1, 7, 7);
									break;
								}
							}
						}
					}

					// Test for SVB_BIT4 (ARCHWAY)
					if (SVB_BMP != "")
					{
						int SVB_index = SvbHelper.SVB_GetTileAddress(x1, y1);

						for (int i = 0; i <= 2; i++)
						{
							for (int j = 0; j <= 2; j++)
							{
								if (MobHelper.GetPropertyState(SVB_BMP, SVB_index + i*192*4 + j*4 + 3) == TriState.True)
								{
									viewportGfx.FillRectangle(Brushes.Tomato, 630 - (10*x1), 10*y1, 7, 7);
									break;
								}
							}
						}
					}

					// Test for HSD WATER
					if (hsd.Tiles.Length > 1000) /* safety check */
					{
						int HSD_index = Hsd.GetTileAddress(x1, y1) - 1;

						for (int T = 0; T < 9; T++)
						{
							if (hsd.Tiles[HSD_index + T] != 0x00)
							{
								viewportGfx.FillRectangle(Brushes.PowderBlue, 630 - (10*x1) + 4, 10*y1 + 4, 6, 6);
								break;
							}
						}
					}
				}
			for (int X = 0; X < 64; X++)
				viewportGfx.DrawLine(Pens.Black, (float) X*10, 0F, (float) X*10, 640F);
			for (int Y = 0; Y < 64; Y++)
				viewportGfx.DrawLine(Pens.Black, 0F, (float) Y*10, 640F, (float) Y*10);
		}

		private void SectorAnalysis_Load(object sender, EventArgs e)
		{
			//btnRefreshSAViewPort_Click(null, null);
			cmbTileSound.SelectedIndex = 2;
		}

		private void viewport_MouseMove(object sender, MouseEventArgs e)
		{
			// Refresh the X and Y coords
			if (e.Button == MouseButtons.Left) // pass the request down the call
				viewport_MouseDown(sender, e); // stack to paint if LMB is held.

			CurPosXY.Text = "X=" + (MinX + ((640 - e.X)/10)).ToString() + ", Y=" + (MinY + (e.Y/10)).ToString();
		}

		private void viewport_MouseDown(object sender, MouseEventArgs e)
		{
			if (chkPaintMode.Checked)
			{
				if (SysMsg.SM_PAINT_TILE)
					return; // haven't finished painting yet

				int X = e.X/10;
				int Y = e.Y/10;

				// Set the properties

				// Draw the dark gray rectangle ('painted')
				Graphics ptr_vp = viewport.CreateGraphics();
				ptr_vp.FillRectangle(Brushes.DarkGray, 10*X, 10*Y, 10, 10);
				ptr_vp.DrawRectangle(Pens.Black, 10*X, 10*Y, 10, 10);

				// Send the system messages
				if (SVB1_STATE)
				{
					SysMsg.SM_SVB1_X = (MinX + ((640 - e.X)/10));
					SysMsg.SM_SVB1_Y = (MinY + (e.Y/10));
					SysMsg.SM_SVB1 = true;
					return;
				}
				else if (SVB2_STATE)
				{
					SysMsg.SM_SVB2_X = (MinX + ((640 - e.X)/10));
					SysMsg.SM_SVB2_Y = (MinY + (e.Y/10));
					SysMsg.SM_SVB2 = true;
					return;
				}
				else if (SVB3_STATE)
				{
					SysMsg.SM_SVB3_X = (MinX + ((640 - e.X)/10));
					SysMsg.SM_SVB3_Y = (MinY + (e.Y/10));
					SysMsg.SM_SVB3 = true;
					return;
				}
				else if (SVB4_STATE)
				{
					SysMsg.SM_SVB4_X = (MinX + ((640 - e.X)/10));
					SysMsg.SM_SVB4_Y = (MinY + (e.Y/10));
					SysMsg.SM_SVB4 = true;
					return;
				}

				SysMsg.SM_PAINT_TILE_QUEUE.Add((MinX + ((640 - e.X)/10)).ToString());
				SysMsg.SM_PAINT_TILE_QUEUE.Add((MinY + (e.Y/10)).ToString());
				SysMsg.SM_PAINT_TILE_QUEUE.Add(cmbTileSound.SelectedIndex);
				SysMsg.SM_PAINT_TILE = true;
			}

			if (chkRememberForObject.Checked)
			{
				// Send the system message
				SysMsg.SM_REMEMBER_COORDS_QUEUE.Add((MinX + ((640 - e.X)/10)).ToString());
				SysMsg.SM_REMEMBER_COORDS_QUEUE.Add((MinY + (e.Y/10)).ToString());
				SysMsg.SM_REMEMBER_COORDS = true;
			}
		}

		private void SectorAnalysis_Paint(object sender, PaintEventArgs e)
		{
			//btnRefreshSAViewPort_Click(sender, e);
		}

		private void SectorAnalysis_Closing(object sender, CancelEventArgs e)
		{
			SysMsg.SM_SAN_ENABLED = false;
		}

		private void btnQuick1_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_PAINT_NOTHING = true;
		}

		private void btnQuick2_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_PAINT_IMPASSABLE = true;
		}

		private void btnQuick3_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_PAINT_FLYOVER = true;
		}

		private void btnQuick4_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_PAINT_FLYOVER_COVER = true;
		}

		private void btnQuick5_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_ADD_SVB1 = true;
		}

		private void btnQuick6_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
			SysMsg.SM_REMOVE_SVB1 = true;
		}

		private void btnTotalRefreshSA_Click(object sender, EventArgs e)
		{
			Graphics ptr_vp = viewport.CreateGraphics();
			ptr_vp.FillRectangle(Brushes.White, 0, 0, viewport.Width, viewport.Height);
			OnRefreshViewPortClick(sender, e);
		}

		private void btnAddExtend_Click(object sender, EventArgs e)
		{
			SVB1_STATE = true;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
		}

		private void btnAddEnd_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = true;
			SVB3_STATE = false;
			SVB4_STATE = false;
		}

		private void btnAddBase_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = true;
			SVB4_STATE = false;
		}

		private void btnAddArchway_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = true;
		}

		private void btnCancelSVB_Click(object sender, EventArgs e)
		{
			SVB1_STATE = false;
			SVB2_STATE = false;
			SVB3_STATE = false;
			SVB4_STATE = false;
		}
	}
}