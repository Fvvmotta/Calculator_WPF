using System.Windows;
using System.Windows.Controls;

namespace Calculator_WPF;

public partial class MainWindow : Window
{
    double lastNumber, result;
    SelectedOperator selectedOperator;

    public MainWindow()
    {
        InitializeComponent();

        acButton.Click += AcButton_Click;
        negativeButton.Click += NegativeButton_Click;
        percentageButton.Click += PercentageButton_Click;
        equalsButton.Click += EqualsButton_Click;
    }

    private void EqualsButton_Click(object sender, RoutedEventArgs e)
    {
        double newNumber;
        if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
        {
            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }
            resultLabel.Content = result.ToString();
        }
    }

    private void PercentageButton_Click(object sender, RoutedEventArgs e)
    {
        double tempNumber;

        if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
        {
            tempNumber = tempNumber / 100;
            if (lastNumber != 0)
                tempNumber *= lastNumber;
            resultLabel.Content = tempNumber.ToString();
        }
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
        if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            lastNumber = lastNumber * -1;
            resultLabel.Content = lastNumber.ToString();
        }
    }

    private void AcButton_Click(object sender, RoutedEventArgs e)
    {
        resultLabel.Content = "0";
        result = 0;
        lastNumber = 0;
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
        if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
        {
            resultLabel.Content = "0";
        }

        if (sender == mutiplicationButton)
            selectedOperator = SelectedOperator.Multiplication;
        if (sender == divisionButton)
            selectedOperator = SelectedOperator.Division;
        if (sender == plusButton)
            selectedOperator = SelectedOperator.Addition;
        if (sender == minusButton)
            selectedOperator = SelectedOperator.Subtraction;
    }
    private void pointButton_Click(object sender, RoutedEventArgs e)
    {
        if (!resultLabel.Content.ToString().Contains("."))
        {
            resultLabel.Content = $"{resultLabel.Content},";
        }
    }
    private void numberButton_Click(object sender, RoutedEventArgs e)
    {
        int selectedValue = int.Parse((sender as Button).Content.ToString());
        
        if (resultLabel.Content.ToString() == "0")
        {
            resultLabel.Content = $"{selectedValue}";
        }
        else
        {
            resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
        }
    }
}
