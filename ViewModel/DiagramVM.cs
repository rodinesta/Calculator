using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using TRPO1.Context;

namespace TRPO1.ViewModel;

public class DiagramVM
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    private double _countBIN;

    public double countBIN
    {
        get { return _countBIN; }
        set
        {
            _countBIN = value;
            OnPropertyChanged(nameof(countBIN));
        }
    }
    
    private double _countOCT;

    public double countOCT
    {
        get { return _countOCT; }
        set
        {
            _countOCT = value;
            OnPropertyChanged(nameof(countOCT));
        }
    }
    
    private double _countDEC;

    public double countDEC
    {
        get { return _countDEC; }
        set
        {
            _countDEC = value;
            OnPropertyChanged(nameof(countDEC));
        }
    }
    
    private double _countHEX;

    public double countHEX
    {
        get { return _countHEX; }
        set
        {
            _countHEX = value;
            OnPropertyChanged(nameof(countHEX));
        }
    }

    public DiagramVM()
    {
        try
        {
            MyDbContext context = new();

            int countBIN1 = context.Nums.Count(o => o.FirstNumberNotation == 2);
            int countBIN2 = context.Nums.Count(o => o.SecondNumberNotation == 2);
            int countOCT1 = context.Nums.Count(o => o.FirstNumberNotation == 8);
            int countOCT2 = context.Nums.Count(o => o.SecondNumberNotation == 8);
            int countDEC1 = context.Nums.Count(o => o.FirstNumberNotation == 10);
            int countDEC2 = context.Nums.Count(o => o.SecondNumberNotation == 10);
            int countHEX1 = context.Nums.Count(o => o.FirstNumberNotation == 16);
            int countHEX2 = context.Nums.Count(o => o.SecondNumberNotation == 16);
            countBIN = (countBIN1 + countBIN2) * 10;
            countOCT = (countOCT1 + countOCT2) * 10;
            countDEC = (countDEC1 + countDEC2) * 10;
            countHEX = (countHEX1 + countHEX2) * 10;
        }
        catch (Exception ec)
        {
            MessageBox.Show(ec.ToString());
        }
    }
}