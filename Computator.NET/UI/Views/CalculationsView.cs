﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Computator.NET.Config;
using Computator.NET.Evaluation;

namespace Computator.NET.UI.Views
{
    public partial class CalculationsView : UserControl, ICalculationsView
    {
        private CalculationsMode _calculationsMode;

        public CalculationsView()
        {
            InitializeComponent();
            var presenter = new CalculationsPresenter(this);

            if (!DesignMode)
            {
                calculationValueTextBox.Font = CustomFonts.GetMathFont(calculationValueTextBox.Font.Size);

                calculationsHistoryDataGridView.Columns[0].DefaultCellStyle.Font =
                    CustomFonts.GetMathFont(calculationsHistoryDataGridView.Columns[0].DefaultCellStyle.Font.Size);

                calculationsHistoryDataGridView.Columns[calculationsHistoryDataGridView.Columns.Count - 1]
                    .DefaultCellStyle
                    .Font =
                    CustomFonts.GetMathFont(
                        calculationsHistoryDataGridView.Columns[calculationsHistoryDataGridView.Columns.Count - 1]
                            .DefaultCellStyle.Font.Size);
            }
        }


        public event EventHandler CalculateClicked
        {
            add { calculateButton.Click += value; }
            remove { calculateButton.Click -= value; }
        }
        public string XLabel { set { calculationsRealLabel.Text = value; } }
        public string YLabel {  set { calculationsComplexLabel.Text = value; } }
        public bool YVisible {  set
        {
            calculationsComplexLabel.Visible = value;
                calculationsImZnumericUpDown.Visible = value;
            } }

        public double X { get { return (double)valueForCalculationNumericUpDown.Value; } }
        public double Y { get { return (double)calculationsImZnumericUpDown.Value; } }

        public void AddResult(string expression, string arguments, string result)
        {
            calculationValueTextBox.Text = result;
            calculationsHistoryDataGridView.Rows.Insert(0,
                                    expression,
                                    arguments,
                                    result);
        }
    }
}
