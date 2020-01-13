using Building.Manager.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Building.Manager.Extensions;
using Building.Manager.Models;
using System.Data;
using BuisinessLayer;
using Building.Manager.InputDialog;
using MessageBox = System.Windows.MessageBox;
using CrystalDecisions.CrystalReports.Engine;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using CrystalDecisions.ReportAppServer.DataDefModel;
using DataSet = System.Data.DataSet;
using System.Collections.Generic;
using System.Windows.Controls;
using System.ComponentModel;

namespace Building.Manager.Controls
{


    public partial class OfferControl : System.Windows.Controls.UserControl
    {

        private readonly OfferViewModel _offerViewModel = new OfferViewModel();

        public OfferControl()
        {
            _offerViewModel.CalculateOfferCommand = new CalculateOfferCommand(CalculateTotal);
            _offerViewModel.PrintCommand = new PrintCommand(PrintOffer);
            _offerViewModel.SaveOfferCommand = new SaveOfferCommand(SaveOffer);
            _offerViewModel.DeleteRowCommand = new DeleteRowCommand(DeleteRow);

            InitializeComponent();
            this.DataContext = _offerViewModel;
        }

        public void AddNewService(OfferService service)
        {
            var offerServiceViewModel = service.ToViewModel();
            _offerViewModel.OfferServices.Add(offerServiceViewModel);
        }
     
        public void CalculateTotal(Offer offer)
        {

            _offerViewModel.SubTotal = _offerViewModel.OfferServices.Sum(oService => oService.Amount);
            _offerViewModel.Total = _offerViewModel.SubTotal + (_offerViewModel.SubTotal * 0.2m);
            _offerViewModel.Vat = 20;
            block_SubTotal.Text = String.Format("{0:0.00} лв.", _offerViewModel.SubTotal);
            block_VAT.Text = String.Format("{0:0 %}", 0.20);
            block_Total.Text = String.Format("{0:0.00} лв.", _offerViewModel.Total);
        }


        public void PrintOffer(Offer offer)
        {
            ReportDocument report = new ReportDocument();
            report.Load("../../OfferReport.rpt");
            report.SetDataSource(_offerViewModel.OfferServices);
            PrintWindow print = new PrintWindow();
            print.LinkReport(report);
            print.Show();

            
        }

        private ObservableCollection<Offer> savedoffers = new ObservableCollection<Offer>();

        public void SaveOffer(Offer offer)
        {
            Offer newoffer = new Offer();
            var importSymbolsForm = new ImportProviderSymbolsForm();
            if (importSymbolsForm.ShowDialog() == true)
            {
                newoffer.Name = importSymbolsForm.NameField;
                newoffer.Description = importSymbolsForm.DescriptionField;
                newoffer.CreatedDate = DateTime.Now;
            }
            else
            {
                importSymbolsForm.Close();
                return;
            }
            Services.SaveOffer(newoffer);
            foreach (var offerserviceViewModel in _offerViewModel.OfferServices)
            {
               
                OfferService ofs = offerserviceViewModel.ToDbModel();
                newoffer.OfferServices.Add(ofs);
            }
            newoffer.Total = _offerViewModel.Total;
            newoffer.VAT = _offerViewModel.Vat;
            Services.SaveOffer(newoffer);
            MessageBox.Show("Успешно запазена!");

        }
       
        public void DeleteRow(Offer offer)
        {
            OfferServiceViewModel deleterow = (OfferServiceViewModel)selectionList.SelectedItem;
            _offerViewModel.OfferServices.Remove(deleterow);
            Clear();
        }
        public void Clear()
        {
            block_SubTotal.Text = String.Empty;
            block_VAT.Text = String.Empty;
            block_Total.Text = String.Empty;
        }
  
    }
}
