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
    public partial class NewCalculatioinFormula : Form
    {
        public NewCalculatioinFormula()
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
        private void button1_Click(object sender, EventArgs e)
        {
            double TaxIncome = double.Parse(textBox1.Text);

            double result = CalculateTaxFromIncome(TaxIncome);

            label1.Text = result.ToString();
        }
    }
}
