using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorApp
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(true)]
	public partial class MainPage : ContentPage
	{
		public double Value1 { get; set; }
		public double Value2 { get; set; }
		public string Operator { get; set; }
		public MainPage()
		{
			InitializeComponent();
			Operator = "";
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				string input = ((Button)sender).Text;

				Output.Text += input;
				Full_Calculation(input);
			}
			catch(Exception ex)
			{
				throw new Exception($"[ERROR]", ex);
			}

		}

		private void Button_Undo_Clicked(object sender, EventArgs e)
		{
			try
			{
				string input = ((Button)sender).Text;
				if (input == "C")
				{
					Output.Text = "";
					Calculation.Text = "";
					Value1 = 0;
					Value2 = 0;
					Operator = "";
				}
				if (input == "⌫")
					if (Output.Text.Length > 0)
						Output.Text = Output.Text.Remove(Output.Text.Length - 1);
			}
			catch(Exception ex)
			{
				throw new Exception($"[ERROR]", ex);
			}
		}

		private void Button_Operation_Clicked(object sender, EventArgs e)
		{
			try
			{
				if (Output.Text != "")
				{
					if (Operator == "")
					{
						Value1 = double.Parse(Output.Text);
						Operator = ((Button)sender).Text;
						Output.Text = "";
					}
					else
					{
						Button_Calc_Clicked(sender, e);
						Value1 = double.Parse(Output.Text);
						Operator = ((Button)sender).Text;
						Output.Text = "";
					}
					Full_Calculation(Operator);
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"[ERROR]", ex);
			}
		}

		private void Button_Calc_Clicked(object sender, EventArgs e)
		{
			try
			{
				Value2 = double.Parse(Output.Text);
				if (Value2 != 0)
				{
					string result = "";
					switch (Operator)
					{
						case "+":
							result = (Value1 + Value2).ToString();
							break;
						case "-":
							result = (Value1 - Value2).ToString();
							break;
						case "×":
							result = (Value1 * Value2).ToString();
							break;
						case "÷":
							result = (Value1 / Value2).ToString();
							break;
						case "%":
							result = (Value1 % Value2).ToString();
							break;
						default:
							break;
					}
					Output.Text = result;
					Calculation.Text += "=" + result;
					Operator = "";
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"[ERROR]", ex);
			}
			
		}

		private void Full_Calculation(string content)
		{
			Calculation.Text += content; 
		}
	}
}
