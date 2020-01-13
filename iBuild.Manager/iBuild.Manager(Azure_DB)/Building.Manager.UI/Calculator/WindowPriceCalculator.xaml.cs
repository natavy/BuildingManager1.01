using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Building.Manager
{

    public partial class WindowPriceCalculator : Window
    {
        public WindowPriceCalculator()
        {
            InitializeComponent();
        }


        private void Boxes_Works_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateWork();
            CalculateTotal();
            CalculateTotalPrice();

        }
        private void Box_Materials_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateMaterials();
            CalculateTotal();
            CalculateTotalPrice();
        }

        private void Box_MachineWork_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateMechanization();
            CalculateTotal();
            CalculateTotalPrice();
        }

        private void Box_Win_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateTotalPrice();
        }


        public void CalculateWork()
        {
            decimal unitofwork = String.IsNullOrEmpty(Box_UnitOfWork.Text) ? 0m : Convert.ToDecimal(Box_UnitOfWork.Text);
            decimal workperhour = String.IsNullOrEmpty(Box_WorkPerHour.Text) ? 0m : Convert.ToDecimal(Box_WorkPerHour.Text);
            decimal costwork = String.IsNullOrEmpty(Box_CostWork.Text) ? 0m : Convert.ToDecimal(Box_CostWork.Text);
            decimal totalwork = (unitofwork * workperhour) + ((unitofwork * workperhour) * costwork / 100);
            Box_TotalWork.Text = totalwork.ToString();

            if (unitofwork < 0 || workperhour < 0 || costwork < 0)
            {
                MessageBox.Show("Не може да въвеждате отрицателна стойност!");
                Box_UnitOfWork.Text = String.Empty;
                Box_WorkPerHour.Text = String.Empty;
                Box_CostWork.Text = String.Empty;
                return;
            }
        }

        public void CalculateMaterials()
        {

            decimal measurematerials = String.IsNullOrEmpty(Box_MeasureMaterials.Text) ? 0m : Convert.ToDecimal(Box_MeasureMaterials.Text);
            decimal unitpricematerial = String.IsNullOrEmpty(Box_UnitPriceMaterial.Text) ? 0m : Convert.ToDecimal(Box_UnitPriceMaterial.Text);
            decimal costmaterial = String.IsNullOrEmpty(Box_CostMaterial.Text) ? 0m : Convert.ToDecimal(Box_CostMaterial.Text);
            decimal totalmaterial = (measurematerials * unitpricematerial) + ((measurematerials * unitpricematerial) * costmaterial / 100);
            Box_TotalMaterials.Text = totalmaterial.ToString();

            if (measurematerials < 0 || unitpricematerial < 0 || costmaterial < 0)
            {
                MessageBox.Show("Не може да въвеждате отрицателна стойност!");
                Box_MeasureMaterials.Text = String.Empty;
                Box_UnitPriceMaterial.Text = String.Empty;
                Box_CostMaterial.Text = String.Empty;
                return;
            }
        }

        public void CalculateMechanization()
        {
            decimal machinechange = String.IsNullOrEmpty(Box_MachineChange.Text) ? 0m : Convert.ToDecimal(Box_MachineChange.Text);
            decimal unitpricemachinework = String.IsNullOrEmpty(Box_UnitPriceMachineWork.Text) ? 0m : Convert.ToDecimal(Box_UnitPriceMachineWork.Text);
            decimal costmachinework = String.IsNullOrEmpty(Box_CostMachineWork.Text) ? 0m : Convert.ToDecimal(Box_CostMachineWork.Text);
            decimal totalmachinework = (machinechange * unitpricemachinework) + ((machinechange * unitpricemachinework) * costmachinework / 100);
            Box_TotalMachineWork.Text = totalmachinework.ToString();

            if (machinechange < 0 || unitpricemachinework < 0 || costmachinework < 0)
            {
                MessageBox.Show("Не може да въвеждате отрицателна стойност!");
                Box_MeasureMaterials.Text = String.Empty;
                Box_UnitPriceMaterial.Text = String.Empty;
                Box_CostMaterial.Text = String.Empty;
                return;
            }
        }

        public void CalculateTotal()
        {

            decimal totalwork = String.IsNullOrEmpty(Box_TotalWork.Text) ? 0m : Convert.ToDecimal(Box_TotalWork.Text);
            decimal totalmaterial = String.IsNullOrEmpty(Box_TotalMaterials.Text) ? 0m : Convert.ToDecimal(Box_TotalMaterials.Text);
            decimal totalmachinework = String.IsNullOrEmpty(Box_TotalMachineWork.Text) ? 0m : Convert.ToDecimal(Box_TotalMachineWork.Text);
            decimal total = totalwork + totalmaterial + totalmachinework;
            Box_TotalAll.Text = total.ToString();

        }

        public void CalculateTotalPrice()
        {
            decimal totalAll = String.IsNullOrEmpty(Box_TotalAll.Text) ? 0m : Convert.ToDecimal(Box_TotalAll.Text);
            decimal win = String.IsNullOrEmpty(Box_Win.Text) ? 0m : Convert.ToDecimal(Box_Win.Text);
            if (win < 0)
            {
                MessageBox.Show("Не може да въвеждате отрицателна стойност!");
                Box_Win.Text = String.Empty;
                return;
            }
            decimal totalprice = Math.Round(totalAll + (totalAll * win / 100), 2);
            Box_TotalPrice.Text = totalprice.ToString();

        }

        private void btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            foreach (UIElement control in Calculator_Grid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)control;
                    txtBox.Text=String.Empty;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;
            ActivateButton();
          
        }
        public void ActivateButton()
        {
            foreach (UIElement control in Calculator_Grid.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)control;
                    txtBox.IsReadOnly = false;
                }
            }
        }

        private void Box_TotalPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateTotalPrice();
        }
    }
}



     

