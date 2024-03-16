/* Jayden Nason and Namita Mehta, 2024, Universal Calculator,
 * Universal Calculator is a UWP application designed to have multiple calculators as part of one application.
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.Media.Devices;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Calculator
{
	/// <summary>
	/// Mortgage calculator.
	/// </summary>
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Calculates and returns the monthly interest rate from the yearly interest rate
		/// </summary>
		/// <param name="yearlyInterest"></param>
		/// <returns>monthly interest rate as double</returns>
		private double calculateMonthlyInterest(double yearlyInterest)
		{
			double result;
			int months = 12;

			result = yearlyInterest / months;
			return result;
		}
		/// <summary>
		/// Calculates and returns the monthly repayments required, interest and principle.
		/// </summary>
		/// <param name="numYears"></param>
		/// <param name="numMonths"></param>
		/// <param name="yearlyInterest"></param>
		/// <param name="principle"></param>
		/// <returns>monthly repayments as double</returns>
		private double calculateRepayments(int numYears, int numMonths, double yearlyInterest, double principle)
		{
			int months;
			double monthlyInterest;
			double result;

			monthlyInterest = calculateMonthlyInterest(yearlyInterest);

			months = numMonths + numYears * 12;

			result = principle * ((monthlyInterest * Math.Pow((1.0 + monthlyInterest), months)) / (Math.Pow((1.0 + monthlyInterest), months) - 1.0));

			return result;
		}
		/// <summary>
		/// When the calculate button is pressed the monthly interest and monthly repayments fields will be filled.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principle;
			double yearlyInterest;
			int numYears;
			int numMonths;

			try
			{
				principle = double.Parse(principleTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please make sure principle is correctly formatted. " + ex.Message);
				await dialogMessage.ShowAsync();
				principleTextBox.Focus(FocusState.Programmatic);
				principleTextBox.SelectAll();
				return;
			}

			try
			{
				yearlyInterest = double.Parse(yearlyInterestTextBox.Text) / 100;
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please make sure yearly interest is correctly formatted, 2.5% would be \"2.5\" without quotes. \n" + ex.Message);
				await dialogMessage.ShowAsync();
				yearlyInterestTextBox.Focus(FocusState.Programmatic);
				yearlyInterestTextBox.SelectAll();
				return;
			}

			try
			{
				numYears = int.Parse(yearsTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please make sure the number of years is correctly formatted. " + ex.Message);
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			try
			{
				numMonths = int.Parse(monthsTextBox.Text);
			}
			catch (Exception ex)
			{
				var dialogMessage = new MessageDialog("Please make sure the number of months is correctly formatted. " + ex.Message);
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			if (principle < 0)
			{
				var dialogMessage = new MessageDialog("Principle cannot be negative.");
				await dialogMessage.ShowAsync();
				principleTextBox.Focus(FocusState.Programmatic);
				principleTextBox.SelectAll();
				return;
			}

			if (numYears < 0 | numMonths < 0)
			{
				var dialogMessage = new MessageDialog("Number of years/months cannot be negative.");
				await dialogMessage.ShowAsync();
				return;
			}

			monthlyInterestTextBox.Text = calculateMonthlyInterest(yearlyInterest).ToString("P");

			monthlyRepaymentsTextBox.Text = calculateRepayments(numYears, numMonths, yearlyInterest, principle).ToString("C");

		}
		/// <summary>
		/// Navigates back to the main menu.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}
	}
}
