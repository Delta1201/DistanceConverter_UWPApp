/*Created by: Dhaval Tailor
 *Created on: 3rd  October, 2020
 * Niagara college: Year 1, Term 2,Lab 2
 * Modified on: 14th Nove, 2024
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture.Frames;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace sdLab2
{
	public sealed partial class MainPage : Page
	{
		private const float KmToMilesConversionRate = 1.609f;

		public MainPage()
		{
			this.InitializeComponent();
		}

		// Convert Kilometers to Miles
		private void btnMiles_Click(object sender, RoutedEventArgs e)
		{
			if (IsValidInput(txtBoxUserInput.Text, out float kilometers))
			{
				//btnKms.Visibility = Visibility.Collapsed;
				btnKms.Opacity = 0.5;
				btnMiles.Opacity = 1;
				float miles = kilometers / KmToMilesConversionRate;
				txtBoxShowUserInput.Text = $"{kilometers} Kilometers is";
				txtBoxResult.Text = $"{Math.Round(miles, 2)} miles";
			}
			else
			{
				DisplayError("Please enter a valid number for kilometers.");
			}
		}

		// Convert Miles to Kilometers
		private void btnKms_Click(object sender, RoutedEventArgs e)
		{
			if (IsValidInput(txtBoxUserInput.Text, out float miles))
			{
				//btnMiles.Visibility = Visibility.Collapsed;
				btnMiles.Opacity = 0.5;
				btnKms.Opacity = 1;
				float kilometers = miles * KmToMilesConversionRate;
				txtBoxShowUserInput.Text = $"{miles} Miles is";
				txtBoxResult.Text = $"{Math.Round(kilometers, 2)} kilometers";
			}
			else
			{
				DisplayError("Please enter a valid number for miles.");
			}
		}

		// Reset all fields
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			txtBoxUserInput.Text = string.Empty;
			txtBoxShowUserInput.Text = string.Empty;
			txtBoxResult.Text = string.Empty;
			txtBoxUserInput.PlaceholderText = "Enter a number"; // Reset placeholder text
			btnMiles.Opacity = 1;
			btnKms.Opacity = 1;
		}

		// Validate if input is a valid float number
		private bool IsValidInput(string input, out float number)
		{
			// Ensure input is not null or empty and that it can be parsed as a float
			if (!string.IsNullOrWhiteSpace(input) && float.TryParse(input, out number) && number >= 0)
			{
				return true;
			}
			else
			{
				number = 0;
				return false;
			}
		}

		// Display error message and clear result fields
		private void DisplayError(string message)
		{
			txtBoxShowUserInput.Text = message;
			txtBoxResult.Text = string.Empty;
		}
	}
}

