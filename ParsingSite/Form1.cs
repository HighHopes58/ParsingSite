using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ParsingSite
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			textBox1.Text = ParsingResult();
		}

		private string ParsingResult()
		{

			WebClient client = new WebClient();
			// Set user agent and also accept-encoding headers.
			client.Headers["User-Agent"] = "test_bot";

			string value = client.DownloadString("site");
			//<td class="td-price"><p class="p-item"><span style="float:right; margin-right:10px">800 грн</span></p></td>
			//< td class='td-price'><p class='p-item'><span style = 'float:right; margin-right:10px' > ([0 - 9]) +\S
			string parsing_value = System.Text.RegularExpressions.Regex.Match(value, @"<td class='td-price'><p class='p-item'><span style='float:right; margin-right:10px'>([0-9]+\S)").Groups[1].Value;
			
			return "Parsing info = " + parsing_value + "\n";

		}

		
	}
}
