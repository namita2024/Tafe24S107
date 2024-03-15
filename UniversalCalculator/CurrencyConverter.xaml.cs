using System;
using System.Windows;

namespace CurrencyConverter
{
	public partial class MainWindow : Window
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

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Convert_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			if (!double.TryParse(txtAmount.Text, out amount))
			{
				MessageBox.Show("Please enter a valid amount.");
				return;
			}

			double result = 0;

			// Perform conversion based on selected currencies
			switch (cmbFromCurrency.Text)
			{
				case "US Dollar":
					switch (cmbToCurrency.Text)
					{
						case "Euro":
							result = amount * USD_TO_EURO;
							break;
						case "British Pound":
							result = amount * USD_TO_POUND;
							break;
						case "Indian Rupee":
							result = amount * USD_TO_INR;
							break;
					}
					break;

				case "Euro":
					switch (cmbToCurrency.Text)
					{
						case "US Dollar":
							result = amount * EURO_TO_USD;
							break;
						case "British Pound":
							result = amount * EURO_TO_POUND;
							break;
						case "Indian Rupee":
							result = amount * EURO_TO_INR;
							break;
					}
					break;

				case "British Pound":
					switch (cmbToCurrency.Text)
					{
						case "US Dollar":
							result = amount * POUND_TO_USD;
							break;
						case "Euro":
							result = amount * POUND_TO_EURO;
							break;
						case "Indian Rupee":
							result = amount * POUND_TO_INR;
							break;
					}
					break;

				case "Indian Rupee":
					switch (cmbToCurrency.Text)
					{
						case "US Dollar":
							result = amount * INR_TO_USD;
							break;
						case "Euro":
							result = amount * INR_TO_EURO;
							break;
						case "British Pound":
							result = amount * INR_TO_POUND;
							break;
					}
					break;
			}

			txtResult.Text = $"{amount} {cmbFromCurrency.Text} = {result} {cmbToCurrency.Text}";
			txtDetails.Text = $"{amount} {cmbFromCurrency.Text} = {result} {cmbToCurrency.Text}";
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}