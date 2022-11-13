using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMC_IncomeTaxCalculation
{
    public partial class NewRegimeCalculation : Form
    {
        public NewRegimeCalculation()
        {
            InitializeComponent();
        }



        protected double CalculateTaxFromIncome(double income)
        {
            double tax = 0, tax1 = 0, tax2 = 0, tax3 = 0;
            double cess = 0;
            double exemptIncome = income > 250000 ? 250000 : income;    //Exempt Income                   
            double incomeChargable10pc = 0.00;                  // Income at 10%
            double incomeChargable20pc = 0.00;                 //  Income at 20%
            double incomeChargable30pc = 0.00;                 // Income  at 30%

            if (income < 250000)
                return tax;
            else
            {

                if ((income - exemptIncome) > 0)
                {

                    if ((income - exemptIncome) < 500000)
                    {
                        double newincome1 = income - 250000;

                        if (newincome1 < income)
                        {
                            incomeChargable10pc = newincome1;
                        }
                        else
                        {
                            incomeChargable10pc = income - newincome1;
                        }

                        tax1 = incomeChargable10pc * 0.05;
                    }

                    if ((income > 500000))
                    {
                        incomeChargable10pc = 250000;
                        tax1 = incomeChargable10pc * 0.05;
                    }


                }

                if ((income - (exemptIncome + incomeChargable10pc)) > 0)
                {

                    if ((income - (exemptIncome + incomeChargable10pc)) > 500000)
                    {
                        incomeChargable20pc = 500000;
                        tax2 = incomeChargable20pc * 0.2;
                    }
                    else
                    {

                        incomeChargable20pc = (income - (exemptIncome + incomeChargable10pc));
                        tax2 = incomeChargable20pc * 0.2;
                    }


                }

                if ((income - (exemptIncome + incomeChargable10pc + incomeChargable20pc)) > 0)
                {
                    if ((income - (exemptIncome + incomeChargable10pc + incomeChargable20pc)) > 0)
                    {
                        incomeChargable30pc = (income - (exemptIncome + incomeChargable10pc + incomeChargable20pc));
                        tax3 = incomeChargable30pc * 0.3;

                    }

                    else
                    {
                        incomeChargable30pc = 0;
                        tax3 = incomeChargable30pc * 0.3;
                    }



                }

                double lessTaxCredit = 0;                        //Less: Tax Credit
                //if (income <= 500000)
                //{
                //    lessTaxCredit = 2000; //(having total taxable income upto Rs. 5 lacs)
                //}
                tax = ((tax1 + tax2 + tax3) - lessTaxCredit);
                cess = tax * 0.00;

                tax = tax + cess;
                return tax;


            }
        }

        private decimal GetOldTax(decimal taxableIncome)
        {

           //     decimal fifteenLacs = 1500000;
             //   decimal twelveAndHalfLacs = 1250000;
                decimal tenLacs = 1000000;
               // decimal sevenAndHalfLacs = 750000;
                decimal fiveLacs = 500000;
            decimal twoAndHalfLacs = 250000;

            if (taxableIncome <= fiveLacs)
            {
                return 0;
            }

            if (taxableIncome > tenLacs)
            {
                return (taxableIncome - tenLacs) * 0.3m + GetOldTax(tenLacs);
            }
            else if (taxableIncome > fiveLacs && taxableIncome <= tenLacs)
            {
                return (taxableIncome - fiveLacs) * 0.2m + GetOldTax(fiveLacs);
            }
            else if (taxableIncome > twoAndHalfLacs && taxableIncome <= fiveLacs)
            {
                return (taxableIncome - twoAndHalfLacs) * 0.05m + GetOldTax(twoAndHalfLacs);
            }
            else if (taxableIncome <= twoAndHalfLacs)
            {
                return 0;
            }

            return 0;
        }

        private decimal GetNewTax(decimal taxableIncome)
        {
               decimal fifteenLacs = 1500000;
               decimal twelveAndHalfLacs = 1250000;
               decimal tenLacs = 1000000;
               decimal sevenAndHalfLacs = 750000;
               decimal fiveLacs = 500000;
               decimal twoAndHalfLacs = 250000;

            if (taxableIncome > fifteenLacs)
            {
                return (taxableIncome - fifteenLacs) * 0.3m + GetNewTax(fifteenLacs);
            }
            else if (taxableIncome > twelveAndHalfLacs && taxableIncome <= fifteenLacs)
            {
                return (taxableIncome - twelveAndHalfLacs) * 0.25m + GetNewTax(twelveAndHalfLacs);
            }
            else if (taxableIncome > tenLacs && taxableIncome <= twelveAndHalfLacs)
            {
                return (taxableIncome - tenLacs) * 0.2m + GetNewTax(tenLacs);
            }
            else if (taxableIncome > sevenAndHalfLacs && taxableIncome <= tenLacs)
            {
                return (taxableIncome - sevenAndHalfLacs) * 0.15m + GetNewTax(sevenAndHalfLacs);
            }
            else if (taxableIncome > fiveLacs && taxableIncome <= sevenAndHalfLacs)
            {
                return (taxableIncome - fiveLacs) * 0.1m + GetNewTax(fiveLacs);
            }
            else if (taxableIncome > twoAndHalfLacs && taxableIncome <= fiveLacs)
            {
                return (taxableIncome - twoAndHalfLacs) * 0.05m + GetNewTax(twoAndHalfLacs);
            }
            else if (taxableIncome <= twoAndHalfLacs)
            {
                return 0;
            }

            return 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            double TaxIncome = double.Parse(textBox1.Text);

            double result = CalculateTaxFromIncome(TaxIncome);

            double roundof = Math.Round(result, MidpointRounding.ToEven); 

            label1.Text = roundof.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(comboBox1.SelectedIndex == 0)
            {
                decimal TaxIncome1 = decimal.Parse(textBox1.Text);
                decimal result1 = GetOldTax(TaxIncome1);
                decimal roundof1 = Math.Round(result1);
                label2.Text = roundof1.ToString();
            }
           else
            {
                decimal TaxIncome = decimal.Parse(textBox1.Text);
                decimal result = GetNewTax(TaxIncome);
                decimal roundof = Math.Round(result);
                label2.Text = roundof.ToString();
            }

            


        }
    }
}
