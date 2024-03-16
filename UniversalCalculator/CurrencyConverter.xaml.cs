using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConverter : Page
	{
		// Define conversion rates
		private const double USD_TO_EURO = 0.85189982;
		private const double USD_TO_POUND = 0.72872436;
		private const double USD_TO_INR = 74.257327;

		private const double EURO_TO_USD = 1.1739732;
		private const double EURO_TO_POUND = 0.8556672;
		private const double EURO_TO_INR = 87.00755;

		private const double POUND_TO_USD = 1.371907;
		private const double POUND_TO_EURO = 1.1686692;
		private const double POUND_TO_INR = 101.68635;

		private const double INR_TO_USD = 0.011492628;
		private const double INR_TO_EURO = 0.013492774;
		private const double INR_TO_POUND = 0.0098339397;

		public CurrencyConverter()
		{
			InitializeComponent();
		}

		private void convertButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			if (!double.TryParse(amountTextBox.Text, out amount))
			{
				resultTextBox.Text = "Please enter a valid amount.";
				return;
			}

			// Get value of the selected currency
			string fromCurrency = ((ComboBoxItem)fromCurrencyComboBox.SelectedItem).Content.ToString();
			string toCurrency = ((ComboBoxItem)toCurrencyComboBox.SelectedItem).Content.ToString();

			// Perform conversion based on selected currencies
			double result = 0;
			switch (fromCurrency)
			{
				case "US Dollar":
					result = ConvertFromUSD(amount, toCurrency);
					break;
				case "Euro":
					result = ConvertFromEUR(amount, toCurrency);
					break;
				case "British Pound":
					result = ConvertFromGBP(amount, toCurrency);
					break;
				case "Indian Rupee":
					result = ConvertFromINR(amount, toCurrency);
					break;
			}

			// Get value of the selected currency
			double toCurrencyValue = GetCurrencyValue(toCurrency);

			// Display result
			resultTextBox.Text += $"{amount} {fromCurrency} = {result} {toCurrency} \n (1 {toCurrency} = {toCurrencyValue} {fromCurrency})\n";

		}

		// Method to get the value of the selected currency
		private double GetCurrencyValue(string currency)
		{
			switch (currency)
			{
				case "US Dollar":
					return 1.0;
				case "Euro":
					return 0.85189982;
				case "British Pound":
					return 0.72872436;
				case "Indian Rupee":
					return 74.257327;
				default:
					return 0;
			}
		}

		private double ConvertFromUSD(double amount, string toCurrency)
		{
			switch (toCurrency)
			{
				case "US Dollar":
					return amount;
				case "Euro":
					return amount * USD_TO_EURO;
				case "British Pound":
					return amount * USD_TO_POUND;
				case "Indian Rupee":
					return amount * USD_TO_INR;
				default:
					return 0;
			}
		}

		private double ConvertFromEUR(double amount, string toCurrency)
		{
			switch (toCurrency)
			{
				case "US Dollar":
					return amount * EURO_TO_USD;
				case "Euro":
					return amount;
				case "British Pound":
					return amount * EURO_TO_POUND;
				case "Indian Rupee":
					return amount * EURO_TO_INR;
				default:
					return 0;
			}
		}

		private double ConvertFromGBP(double amount, string toCurrency)
		{
			switch (toCurrency)
			{
				case "US Dollar":
					return amount * POUND_TO_USD;
				case "Euro":
					return amount * POUND_TO_EURO;
				case "British Pound":
					return amount;
				case "Indian Rupee":
					return amount * POUND_TO_INR;
				default:
					return 0;
			}
		}

		private double ConvertFromINR(double amount, string toCurrency)
		{
			switch (toCurrency)
			{
				case "US Dollar":
					return amount * INR_TO_USD;
				case "Euro":
					return amount * INR_TO_EURO;
				case "British Pound":
					return amount * INR_TO_POUND;
				case "Indian Rupee":
					return amount;
				default:
					return 0;
			}
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			// Close the application
			Application.Current.Exit();
		}

		private void detailsTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}

		private void resultTextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}
	}
}