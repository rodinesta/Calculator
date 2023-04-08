using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TRPO1.Context;
using TRPO1.Entities;
using TRPO1.View;

namespace TRPO1
{
    public partial class MainWindow : Window
    {
        private string currentOperator;
        private string leftOperand;
        private string rightOperand;
        private int currentNotation;
        private int leftNotation;
        private int rightNotation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {
            string number = (string)((Button)sender).Content;
            txtResult.Text += number;
        }

        private void btnOperator_Click(object sender, RoutedEventArgs e)
        {
            string op = (string)((Button)sender).Content;

            if (currentOperator == null)
            {
                if (txtResult.Text.Equals("") || currentNotation == 0)
                {
                    MessageBox.Show("Введите число и выберите систему счисления");
                }
                else
                {
                    currentOperator = op;
                    leftOperand = txtResult.Text;
                    txtResult.Text = "";
                    leftNotation = currentNotation;
                    currentNotation = 0;
                    ClearRadioButtons();
                }
            }
            else
            {
                
                rightOperand = txtResult.Text;
                rightNotation = currentNotation;
                string result = "0";

                switch (rightNotation)
                {
                    case 2:
                        switch (currentOperator)
                        {
                            case "+":
                                result = Add(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = Subtract(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = Multiply(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = Divide(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = Modulo(leftOperand, rightOperand);
                                break;
                        }
                        break;
                    case 8:
                        switch (currentOperator)
                        {
                            case "+":
                                result = AddOctal(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = SubtractOctal(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = MultiplyOctal(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = DivideOctal(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = ModuloOctal(leftOperand, rightOperand);
                                break;
                        }
                        break;
                    case 10:
                        switch (currentOperator)
                        {
                            case "+":
                                result = (int.Parse(leftOperand) + int.Parse(rightOperand)).ToString();
                                break;
                            case "-":
                                result = (int.Parse(leftOperand) - int.Parse(rightOperand)).ToString();
                                break;
                            case "*":
                                result = (int.Parse(leftOperand) * int.Parse(rightOperand)).ToString();
                                break;
                            case "/":
                                result = (int.Parse(leftOperand) / int.Parse(rightOperand)).ToString();
                                break;
                            case "mod":
                                result = (int.Parse(leftOperand) % int.Parse(rightOperand)).ToString();
                                break;
                        }
                        break;
                    case 16:
                        switch (currentOperator)
                        {
                            case "+":
                                result = HexAddition(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = HexSubtraction(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = HexMultiplication(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = HexDivision(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = HexModulo(leftOperand, rightOperand);
                                break;
                        }
                        break;
                }

                txtResult.Text = result.ToString();
                leftOperand = result.ToString();
                currentNotation = 0;
                ClearRadioButtons();
                rightOperand = "0";
                currentOperator = op;
                txtResult.Text = "";
            }
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (currentOperator != null)
            {
                if (txtResult.Text.Equals("") || currentNotation == 0)
                {
                    MessageBox.Show("Введите число и выберите систему счисления");
                } else
                {
                    rightOperand = txtResult.Text;
                    rightNotation = currentNotation;
                    string result = "0";

                    if (leftNotation != rightNotation)
                    {
                        leftOperand = Convert(leftOperand, leftNotation, currentNotation);
                    }
            
                    switch (rightNotation)
                    {
                        case 2:
                        switch (currentOperator)
                        {
                            case "+":
                                result = Add(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = Subtract(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = Multiply(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = Divide(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = Modulo(leftOperand, rightOperand);
                                break;
                        }
                        break;
                    case 8:
                        switch (currentOperator)
                        {
                            case "+":
                                result = AddOctal(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = SubtractOctal(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = MultiplyOctal(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = DivideOctal(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = ModuloOctal(leftOperand, rightOperand);
                                break;
                        }
                        break;
                    case 10:
                        switch (currentOperator)
                        {
                            case "+":
                                result = (int.Parse(leftOperand) + int.Parse(rightOperand)).ToString();
                                break;
                            case "-":
                                result = (int.Parse(leftOperand) - int.Parse(rightOperand)).ToString();
                                break;
                            case "*":
                                result = (int.Parse(leftOperand) * int.Parse(rightOperand)).ToString();
                                break;
                            case "/":
                                result = (int.Parse(leftOperand) / int.Parse(rightOperand)).ToString();
                                break;
                            case "mod":
                                result = (int.Parse(leftOperand) % int.Parse(rightOperand)).ToString();
                                break;
                        }
                        break;
                    case 16:
                        switch (currentOperator)
                        {
                            case "+":
                                result = HexAddition(leftOperand, rightOperand);
                                break;

                            case "-":
                                result = HexSubtraction(leftOperand, rightOperand);
                                break;

                            case "*":
                                result = HexMultiplication(leftOperand, rightOperand);
                                break;

                            case "/":
                                result = HexDivision(leftOperand, rightOperand);
                                break;

                            case "mod":
                                result = HexModulo(leftOperand, rightOperand);
                                break;
                        }
                        break;
                    }
            
                    txtResult.Text = result.ToString();
                    
                    try
                    {
                        using (MyDbContext context = new())
                        {
                            Num num = new Num()
                            {
                                FirstNumber = leftOperand,
                                FirstNumberNotation = leftNotation,
                                SecondNumber = rightOperand,
                                SecondNumberNotation = rightNotation,
                                Operation = currentOperator
                            };
                            context.Nums.Add(num);
                            context.SaveChanges();
                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    
                    leftOperand = result;
                    rightOperand = "0";
                    currentOperator = null;
                }
            }
        }
        
        public class BaseViewModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler? PropertyChanged;
            public void OnPropertyChanged([CallerMemberName] string property = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
        
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            leftOperand = "0";
            leftNotation = 0;
            rightNotation = 0;
            rightOperand = "0";
            currentOperator = null;
            ClearRadioButtons();
        }
        
        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.StartsWith("-") == true) 
            {
                txtResult.Text = txtResult.Text.Remove(0, 1);
            } else
            {
                txtResult.Text = "-" + txtResult.Text;
            }
            
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = txtResult.Text + ".";
        }

        private void RadioButtonBIN_Checked(object sender, RoutedEventArgs e)
        {
            currentNotation = 2;
        }

        private void RadioButtonOCT_Checked(object sender, RoutedEventArgs e)
        {
            currentNotation = 8;
        }

        private void RadioButtonDEC_Checked(object sender, RoutedEventArgs e)
        {
            currentNotation = 10;
        }

        private void RadioButtonHEX_Checked(object sender, RoutedEventArgs e)
        {
            currentNotation = 16;
        }

        private void ClearRadioButtons()
        {
            rbBIN.IsChecked = false; 
            rbDEC.IsChecked = false; 
            rbOCT.IsChecked = false; 
            rbHEX.IsChecked = false;
        }

        private static string Convert(string num, int startNotation, int finalNotation)
        {
            int numInDec;

            //В десятичное
            numInDec = System.Convert.ToInt32(num, startNotation);
            //Из десятичного
            return System.Convert.ToString(numInDec, finalNotation);
        }

        #region BINARY
public static string Add(string num1, string num2)
        {
            int len = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(len, '0');
            num2 = num2.PadLeft(len, '0');

            string result = "";
            int carry = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                int sum = (num1[i] - '0') + (num2[i] - '0') + carry;
                result = (sum % 2) + result;
                carry = sum / 2;
            }

            if (carry > 0)
                result = carry + result;

            return result;
        }

        public static string Subtract(string num1, string num2)
        {
            int len = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(len, '0');
            num2 = num2.PadLeft(len, '0');

            string result = "";
            int borrow = 0;

            for (int i = len - 1; i >= 0; i--)
            {
                int diff = (num1[i] - '0') - (num2[i] - '0') - borrow;
                if (diff < 0)
                {
                    diff += 2;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result = diff + result;
            }

            while (result.Length > 1 && result[0] == '0')
                result = result.Substring(1);

            return result;
        }

        public static string Multiply(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;
            int[] result = new int[len1 + len2];

            for (int i = len1 - 1; i >= 0; i--)
            {
                for (int j = len2 - 1; j >= 0; j--)
                {
                    int prod = (num1[i] - '0') * (num2[j] - '0');
                    int pos1 = i + j;
                    int pos2 = i + j + 1;
                    int sum = prod + result[pos2];

                    result[pos1] += sum / 2;
                    result[pos2] = sum % 2;
                }
            }

            string resultStr = "";
            foreach (int digit in result)
                resultStr += digit;

            while (resultStr.Length > 1 && resultStr[0] == '0')
                resultStr = resultStr.Substring(1);

            return resultStr;
        }

        public static string Divide(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (IsGreaterOrEqual(num2, num1))
            {
                if (num2 == num1)
                    return "1";
                else
                    return "0";
            }

            string quotient = "";
            string remainder = num1.Substring(0, len2);
            int index = len2;

            while (index <= len1)
            {
                int div = 0;

                while (IsGreaterOrEqual(num2, remainder))
                {
                    remainder = Subtract(remainder, num2);
                    div++;
                }

                quotient += div.ToString();
                remainder += num1[index].ToString();
                index++;
            }

            if (remainder == "")
                remainder = "0";

            if (IsGreaterOrEqual(num2, remainder))
                quotient += "0";
            else
                quotient += Divide(remainder, num2);

            return quotient;
        }


        public static string Modulo(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 < len2 || num2 == "0")
                return num1;

            string remainder = num1;

            while (remainder.Length >= len2)
            {
                string sub = remainder.Substring(0, len2);

                while (IsGreaterOrEqual(sub, num2))
                {
                    sub = Subtract(sub, num2);
                }

                remainder = sub.PadLeft(remainder.Length - len2 + 1, '0') + remainder.Substring(len2);
            }

            return remainder;
        }

        private static bool IsGreaterOrEqual(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 > len2)
                return true;
            else if (len1 < len2)
                return false;

            for (int i = 0; i < len1; i++)
            {
                if (num1[i] > num2[i])
                    return true;
                else if (num1[i] < num2[i])
                    return false;
            }

            return true;
        }
        

        #endregion

        #region OCTAL
        public static string AddOctal(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 < len2)
            {
                num1 = num1.PadLeft(len2, '0');
            }
            else if (len2 < len1)
            {
                num2 = num2.PadLeft(len1, '0');
            }

            int carry = 0;
            int digit = 0;
            int sum = 0;

            StringBuilder result = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                sum = int.Parse(num1[i].ToString()) + int.Parse(num2[i].ToString()) + carry;

                digit = sum % 8;
                carry = sum / 8;

                result.Insert(0, digit.ToString());
            }

            if (carry > 0)
            {
                result.Insert(0, carry.ToString());
            }

            return result.ToString();
        }

        public static string SubtractOctal(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            if (len1 < len2)
            {
                num1 = num1.PadLeft(len2, '0');
            }
            else if (len2 < len1)
            {
                num2 = num2.PadLeft(len1, '0');
            }

            int borrow = 0;
            int digit = 0;
            int diff = 0;

            StringBuilder result = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                diff = int.Parse(num1[i].ToString()) - int.Parse(num2[i].ToString()) - borrow;

                if (diff < 0)
                {
                    diff += 8;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }

                result.Insert(0, diff.ToString());
            }

            return result.ToString().TrimStart('0');


        }
        
        public static string MultiplyOctal(string num1, string num2)
        {
            int multiplicandLength = num1.Length;
            int multiplierLength = num2.Length;

            int[,] product = new int[multiplierLength, multiplicandLength + multiplierLength];

            for (int i = multiplierLength - 1; i >= 0; i--)
            {
                int carry = 0;
                int j;

                for (j = multiplicandLength - 1; j >= 0; j--)
                {
                    int productDigit = (num2[i] - '0') * (num1[j] - '0') + carry;
                    product[i, j + i + 1] = productDigit % 8;
                    carry = productDigit / 8;
                }

                product[i, j + i + 1] = carry;
            }

            string result = string.Empty;
            int carryOver = 0;

            for (int j = multiplicandLength + multiplierLength - 1; j >= 0; j--)
            {
                int sum = carryOver;

                for (int i = 0; i < multiplierLength; i++)
                {
                    sum += product[i, j];
                }

                result = (sum % 8).ToString() + result;
                carryOver = sum / 8;
            }

            result = carryOver > 0 ? carryOver.ToString() + result : result;

            return result.TrimStart('0');
        }
        
        public static string DivideOctal(string dividend, string divisor)
        {
            int[] dividendArray = dividend.Select(c => int.Parse(c.ToString())).ToArray();
            int[] divisorArray = divisor.Select(c => int.Parse(c.ToString())).ToArray();

            if (divisorArray.Length == 1 && divisorArray[0] == 0)
                throw new DivideByZeroException();

            int[] quotientArray = new int[dividendArray.Length];
            int[] remainderArray = new int[dividendArray.Length];
            int carry = 0;

            for (int i = 0; i < dividendArray.Length; i++)
            {
                int dividendDigit = dividendArray[i] + carry * 8;
                int quotientDigit = dividendDigit / divisorArray[0];
                carry = dividendDigit % divisorArray[0];

                quotientArray[i] = quotientDigit;
                remainderArray[i] = carry;

                if (quotientDigit != 0)
                    carry = 0;
            }

            string quotientStr = string.Join("", quotientArray).TrimStart('0');

            return quotientStr;
        }
        
        public static string ModuloOctal(string num1, string num2)
        {
            int dividendLength = num1.Length;
            int divisorLength = num2.Length;

            if (divisorLength > dividendLength)
            {
                return num1;
            }

            int[] dividendArray = new int[dividendLength];
            int[] divisorArray = new int[divisorLength];

            for (int i = 0; i < dividendLength; i++)
            {
                dividendArray[i] = num1[i] - '0';
            }

            for (int i = 0; i < divisorLength; i++)
            {
                divisorArray[i] = num2[i] - '0';
            }

            int[] remainder = new int[divisorLength];

            for (int i = 0; i < dividendLength; i++)
            {
                int carry = 0;

                for (int j = 0; j < divisorLength; j++)
                {
                    int product = (remainder[j] * 8) + dividendArray[i + j] - (divisorArray[j] * ((dividendArray[i + divisorLength - 1] - carry) / divisorArray[divisorLength - 1]));

                    if (product < 0)
                    {
                        product += 64;
                        carry = 1;
                    }
                    else
                    {
                        carry = 0;
                    }

                    remainder[j] = product % 8;
                }
            }

            string remainderString = string.Join("", remainder).TrimStart('0');

            return remainderString == string.Empty ? "0" : remainderString;
        }

        #endregion

        #region HEX
        public static string HexAddition(string hex1, string hex2) {
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            int i = hex1.Length - 1;
            int j = hex2.Length - 1;

            while (i >= 0 || j >= 0 || carry != 0) {
                int digit1 = i >= 0 ? HexToDecimal(hex1[i]) : 0;
                int digit2 = j >= 0 ? HexToDecimal(hex2[j]) : 0;
                int sum = digit1 + digit2 + carry;
                carry = sum / 16;
                int digit = sum % 16;
                sb.Insert(0, DecimalToHex(digit));
                i--;
                j--;
            }

            return sb.ToString();
        }

        private static int HexToDecimal(char hex) {
            if (hex >= '0' && hex <= '9') {
                return hex - '0';
            } else if (hex >= 'A' && hex <= 'F') {
                return hex - 'A' + 10;
            } else {
                throw new ArgumentException("Invalid hex character: " + hex);
            }
        }

        private static char DecimalToHex(int decimalNumber) {
            if (decimalNumber >= 0 && decimalNumber <= 9) {
                return (char)(decimalNumber + '0');
            } else if (decimalNumber >= 10 && decimalNumber <= 15) {
                return (char)(decimalNumber - 10 + 'A');
            } else {
                throw new ArgumentException("Invalid decimal number: " + decimalNumber);
            }
        }
        
        public static string HexSubtraction(string hex1, string hex2) {
            StringBuilder sb = new StringBuilder();
            int borrow = 0;
            int i = hex1.Length - 1;
            int j = hex2.Length - 1;

            while (i >= 0 || j >= 0) {
                int digit1 = i >= 0 ? HexToDecimal(hex1[i]) : 0;
                int digit2 = j >= 0 ? HexToDecimal(hex2[j]) : 0;
                int diff = digit1 - digit2 - borrow;
                borrow = 0;
                if (diff < 0) {
                    diff += 16;
                    borrow = 1;
                }
                sb.Insert(0, DecimalToHex(diff));
                i--;
                j--;
            }

            return sb.ToString();
        }

        public static string HexDivision(string dividend, string divisor)
        {
            int decDividend = 0;
            for (int i = 0; i < dividend.Length; i++)
            {
                decDividend = decDividend * 16 + System.Convert.ToInt32(dividend[i].ToString(), 16);
            }
    
            int decDivisor = 0;
            for (int i = 0; i < divisor.Length; i++)
            {
                decDivisor = decDivisor * 16 + System.Convert.ToInt32(divisor[i].ToString(), 16);
            }
            
            int decResult = decDividend / decDivisor;

            string hexResult = "";
            while (decResult > 0)
            {
                int remainder = decResult % 16;
                hexResult = System.Convert.ToString(remainder, 16).ToUpper() + hexResult;
                decResult /= 16;
            }
            
            if (hexResult == "")
            {
                hexResult = "0";
            }

            return hexResult;
        }
        
        public static string HexMultiplication(string hex1, string hex2) {
            int[] result = new int[hex1.Length + hex2.Length];
            StringBuilder sb = new StringBuilder();

            for (int j = hex2.Length - 1; j >= 0; j--) {
                int digit2 = HexToDecimal(hex2[j]);

                for (int i = hex1.Length - 1; i >= 0; i--) {
                    int digit1 = HexToDecimal(hex1[i]);
                    int product = digit1 * digit2;
                    int index1 = i + j;
                    int index2 = i + j + 1;
                    product += result[index2];
                    result[index2] = product % 16;
                    result[index1] += product / 16;
                }
            }

            int k = 0;
            while (k < result.Length && result[k] == 0) {
                k++;
            }

            for (int i = k; i < result.Length; i++) {
                sb.Append(DecimalToHex(result[i]));
            }

            return sb.Length == 0 ? "0" : sb.ToString();
        }
        
        public static string HexModulo(string hex1, string hex2) {
                if (hex2.Equals("0")) {
                    throw new DivideByZeroException();
                }

                StringBuilder remainder = new StringBuilder();
                int i = 0;

                while (i < hex1.Length) {
                    while (remainder.Length < hex2.Length && i < hex1.Length) {
                        remainder.Append(hex1[i]);
                        i++;
                    }

                    while (CompareHexStrings(remainder.ToString(), hex2) >= 0) {
                        remainder = new StringBuilder(HexSubtraction(remainder.ToString(), hex2));
                    }
                }

                return remainder.ToString();
            }

        private static int CompareHexStrings(string hex1, string hex2) {
                if (hex1.Length < hex2.Length) {
                    return -1;
                } else if (hex1.Length > hex2.Length) {
                    return 1;
                } else {
                    return string.Compare(hex1, hex2, StringComparison.Ordinal);
                }
            }
        

        #endregion


        private void btnDiagram_Click(object sender, RoutedEventArgs e)
        {
            Diagram diagram = new();
            diagram.Show();
        }
    }
}