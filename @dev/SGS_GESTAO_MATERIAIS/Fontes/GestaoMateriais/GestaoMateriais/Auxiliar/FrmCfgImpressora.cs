using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Impressao;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmCfgImpressora : FrmBase
    {
        private const string _NomePadraoBixolon = "BIXOLON SRP-350";

        public FrmCfgImpressora()
        {
            InitializeComponent();
        }

        private void RegistrarImpressoraPedidos()
        {            
            if (rbBemaImprimir.Checked)
            {
                txtNomeBixolon.Text = string.Empty;
                txtNomeBixolon.Enabled = false;
                Utilitario.RegistrarWindows(Utilitario.ModeloImpressoraPedidos.BEMATECH.ToString(), Utilitario.ModeloImpressoraPedidosNomeRegistro());
                Utilitario.RegistrarWindows(string.Empty, Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
            }
            else if (rbBixoImprimir.Checked)
            {
                txtNomeBixolon.Text = _NomePadraoBixolon;
                txtNomeBixolon.Enabled = true;
                Utilitario.RegistrarWindows(Utilitario.ModeloImpressoraPedidos.BIXOLON.ToString(), Utilitario.ModeloImpressoraPedidosNomeRegistro());
                Utilitario.RegistrarWindows(txtNomeBixolon.Text, Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
            }
        }

        private void RegistrarPortaZebra(bool hac)
        {
            if (hac)
            {
                if (rbSerialHAC.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Serial1, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
                else if (rbParalelaHAC.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Paralela1, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
                else if (rbSerialHAC2.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Serial2, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
                else if (rbParalelaHAC2.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Paralela2, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
                else if (rbRedeUSB_HAC.Checked)
                {
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.USB, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
                    Utilitario.RegistrarWindows(txtNomeImpHAC.Text, ImpZebra.ImpressoraZebraUSBNomeRegistroHAC());
                }
                if (!rbRedeUSB_HAC.Checked)
                    Utilitario.RegistrarWindows(string.Empty, ImpZebra.ImpressoraZebraUSBNomeRegistroHAC());
            }
            else
            {
                if (rbSerialACS.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Serial1, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
                else if (rbParalelaACS.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Paralela1, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
                else if (rbSerialACS2.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Serial2, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
                else if (rbParalelaACS2.Checked)
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.Paralela2, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
                else if (rbRedeUSB_ACS.Checked)
                {
                    Utilitario.RegistrarWindows(Utilitario.PortaComunicacao.USB, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
                    Utilitario.RegistrarWindows(txtNomeImpACS.Text, ImpZebra.ImpressoraZebraUSBNomeRegistroACS());
                }
                if (!rbRedeUSB_ACS.Checked)
                    Utilitario.RegistrarWindows(string.Empty, ImpZebra.ImpressoraZebraUSBNomeRegistroACS());
            }
        }

        private void DesabilitarSerial(string senderName)
        {
            if (senderName == rbSerialHAC.Name)
            { ConfigurarControles(grbACS.Controls, true); rbSerialACS.Enabled = false; }
            else if (senderName == rbSerialHAC2.Name)
            { ConfigurarControles(grbACS.Controls, true); rbSerialACS2.Enabled = false; }
            else if (senderName == rbSerialACS.Name)
            { ConfigurarControles(grbHAC.Controls, true); rbSerialHAC.Enabled = false; }
            else if (senderName == rbSerialACS2.Name)
            { ConfigurarControles(grbHAC.Controls, true); rbSerialHAC2.Enabled = false; }

            txtNomeImpHAC.Enabled = txtNomeImpACS.Enabled = false;
        }

        private void DesabilitarParalela(string senderName)
        {
            if (senderName == rbParalelaHAC.Name)
            { ConfigurarControles(grbACS.Controls, true); rbParalelaACS.Enabled = false; }
            else if (senderName == rbParalelaHAC2.Name)
            { ConfigurarControles(grbACS.Controls, true); rbParalelaACS2.Enabled = false; }
            else if (senderName == rbParalelaACS.Name)
            { ConfigurarControles(grbHAC.Controls, true); rbParalelaHAC.Enabled = false; }
            else if (senderName == rbParalelaACS2.Name)
            { ConfigurarControles(grbHAC.Controls, true); rbParalelaHAC2.Enabled = false; }

            txtNomeImpHAC.Enabled = txtNomeImpACS.Enabled = false;
        }

        private void FrmCfgImpressora_Load(object sender, EventArgs e)
        {
            string impressoraPedido = Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistro());

            txtNomeBixolon.Enabled = false;

            if (!string.IsNullOrEmpty(impressoraPedido))
            {
                if (impressoraPedido == Utilitario.ModeloImpressoraPedidos.BEMATECH.ToString())
                    rbBemaImprimir.Checked = true;
                else if (impressoraPedido == Utilitario.ModeloImpressoraPedidos.BIXOLON.ToString())
                {
                    rbBixoImprimir.Checked = true;
                    txtNomeBixolon.Enabled = true;
                    txtNomeBixolon.Text = Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
                    if (string.IsNullOrEmpty(txtNomeBixolon.Text))
                    {
                        txtNomeBixolon.Text = _NomePadraoBixolon;
                        Utilitario.RegistrarWindows(txtNomeBixolon.Text, Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
                    }
                }
            }
            else
            {
                //Por enquanto a padrão vai continuar sendo a BEMATECH
                //Lembrar depois se for alterar isso, no método ImpressaoPedido.Imprimir
                rbBemaImprimir.Checked = true;                
            }
            
            string portaZebraHAC = Utilitario.ObterRegistroWindows(ImpZebra.PortaImpressoraZebraNomeRegistroHAC());

            if (!string.IsNullOrEmpty(portaZebraHAC))
            {
                if (portaZebraHAC == Utilitario.PortaComunicacao.Paralela1)
                { rbParalelaHAC.Checked = true; DesabilitarParalela(rbParalelaHAC.Name); }
                else if (portaZebraHAC == Utilitario.PortaComunicacao.Serial1)
                { rbSerialHAC.Checked = true; DesabilitarSerial(rbSerialHAC.Name); }
                else if (portaZebraHAC == Utilitario.PortaComunicacao.Paralela2)
                { rbParalelaHAC2.Checked = true; DesabilitarParalela(rbParalelaHAC2.Name); }
                else if (portaZebraHAC == Utilitario.PortaComunicacao.Serial2)
                { rbSerialHAC2.Checked = true; DesabilitarSerial(rbSerialHAC2.Name); }
                else if (portaZebraHAC == Utilitario.PortaComunicacao.USB)
                {
                    txtNomeImpHAC.Enabled = rbRedeUSB_HAC.Checked = true;                    
                    txtNomeImpHAC.Text = Utilitario.ObterRegistroWindows(ImpZebra.ImpressoraZebraUSBNomeRegistroHAC());
                }
                if (portaZebraHAC != Utilitario.PortaComunicacao.USB) txtNomeImpHAC.Enabled = false;
            }
            
            string portaZebraACS = Utilitario.ObterRegistroWindows(ImpZebra.PortaImpressoraZebraNomeRegistroACS());

            if (!string.IsNullOrEmpty(portaZebraACS))
            {                
                if (portaZebraACS == Utilitario.PortaComunicacao.Paralela1)
                { rbParalelaACS.Checked = true; DesabilitarParalela(rbParalelaACS.Name); }
                else if (portaZebraACS == Utilitario.PortaComunicacao.Serial1)
                { rbSerialACS.Checked = true; DesabilitarSerial(rbSerialACS.Name); }
                else if (portaZebraACS == Utilitario.PortaComunicacao.Paralela2)
                { rbParalelaACS2.Checked = true; DesabilitarParalela(rbParalelaACS2.Name); }
                else if (portaZebraACS == Utilitario.PortaComunicacao.Serial2)
                { rbSerialACS2.Checked = true; DesabilitarSerial(rbSerialACS2.Name); }
                else if (portaZebraACS == Utilitario.PortaComunicacao.USB)
                {
                    txtNomeImpACS.Enabled = rbRedeUSB_ACS.Checked = true;
                    txtNomeImpACS.Text = Utilitario.ObterRegistroWindows(ImpZebra.ImpressoraZebraUSBNomeRegistroACS());
                }
                if (portaZebraACS != Utilitario.PortaComunicacao.USB) txtNomeImpACS.Enabled = false;
            }

            if (string.IsNullOrEmpty(portaZebraHAC) && string.IsNullOrEmpty(portaZebraACS))
            {
                rbParalelaHAC.Checked = true;
                rbParalela_Click(rbParalelaHAC, null);

                rbParalelaACS2.Checked = true;
                rbParalela_Click(rbParalelaACS2, null);
            }            
        }        

        private void rbBemaImprimir_Click(object sender, EventArgs e)
        {            
            RegistrarImpressoraPedidos();
        }

        private void rbBixoImprimir_Click(object sender, EventArgs e)
        {            
            RegistrarImpressoraPedidos();
        }

        private void rbSerial_Click(object sender, EventArgs e)
        {
            string senderName = ((HospitalAnaCosta.SGS.Componentes.HacRadioButton)sender).Name;
            bool hac = senderName.ToUpper().IndexOf("HAC") > -1 ? true : false;
            RegistrarPortaZebra(hac);
            DesabilitarSerial(senderName);
            if (hac)
            { txtNomeImpHAC.Text = string.Empty; txtNomeImpHAC.Enabled = false; }
            else
            { txtNomeImpACS.Text = string.Empty; txtNomeImpACS.Enabled = false; }
        }

        private void rbParalela_Click(object sender, EventArgs e)
        {
            string senderName = ((HospitalAnaCosta.SGS.Componentes.HacRadioButton)sender).Name;
            bool hac = senderName.ToUpper().IndexOf("HAC") > -1 ? true : false;
            RegistrarPortaZebra(hac);
            DesabilitarParalela(senderName);
            if (hac)
            { txtNomeImpHAC.Text = string.Empty; txtNomeImpHAC.Enabled = false; }
            else
            { txtNomeImpACS.Text = string.Empty; txtNomeImpACS.Enabled = false; }
        }

        private void rbRedeUSBHAC_Click(object sender, EventArgs e)
        {
            if (rbRedeUSB_HAC.Checked)
            {                
                MessageBox.Show("Digite o nome de instalação local da impressora e clique em OK.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbRedeUSB_HAC.Enabled = txtNomeImpHAC.Enabled = true;                
                txtNomeImpHAC.Focus();
            }
        }

        private void rbRedeUSBACS_Click(object sender, EventArgs e)
        {
            if (rbRedeUSB_ACS.Checked)
            {                
                MessageBox.Show("Digite o nome de instalação local da impressora e clique em OK.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbRedeUSB_ACS.Enabled = txtNomeImpACS.Enabled = true;                
                txtNomeImpACS.Focus();                
            }
        }

        private void btnOkHAC_Click(object sender, EventArgs e)
        {
            if (rbRedeUSB_HAC.Checked)
            {
                if (string.IsNullOrEmpty(txtNomeImpHAC.Text))
                {
                    MessageBox.Show("Digite o nome de instalação local da impressora.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeImpHAC.Focus();
                    return;
                }
                else if (txtNomeImpACS.Text == txtNomeImpHAC.Text)
                {
                    MessageBox.Show("Nome de instalação local da impressora não pode ser igual à do ACS.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeImpACS.Focus();
                    return;
                }
                RegistrarPortaZebra(true);
                ConfigurarControles(grbACS.Controls, true);
                if (!rbRedeUSB_ACS.Checked) txtNomeImpACS.Enabled = false;
                MessageBox.Show("Por USB/Rede configurada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnOkACS_Click(object sender, EventArgs e)
        {
            if (rbRedeUSB_ACS.Checked)
            {
                if (string.IsNullOrEmpty(txtNomeImpACS.Text))
                {
                    MessageBox.Show("Digite o nome de instalação local da impressora.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeImpACS.Focus();
                    return;
                }
                else if (txtNomeImpACS.Text == txtNomeImpHAC.Text)
                {
                    MessageBox.Show("Nome de instalação local da impressora não pode ser igual à do HAC.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeImpACS.Focus();
                    return;
                }
                RegistrarPortaZebra(false);
                ConfigurarControles(grbHAC.Controls, true);
                if (!rbRedeUSB_HAC.Checked) txtNomeImpHAC.Enabled = false;
                MessageBox.Show("Por USB/Rede configurada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void btnZerarHAC_Click(object sender, EventArgs e)
        {
            Utilitario.RegistrarWindows(string.Empty, ImpZebra.PortaImpressoraZebraNomeRegistroHAC());
            Utilitario.RegistrarWindows(string.Empty, ImpZebra.ImpressoraZebraUSBNomeRegistroHAC());
            rbRedeUSB_HAC.Checked = rbSerialHAC.Checked = rbSerialHAC2.Checked = rbParalelaHAC.Checked = rbParalelaHAC2.Checked = false;
            txtNomeImpHAC.Text = string.Empty;
            ConfigurarControles(grbACS.Controls, true);
        }

        private void btnZerarACS_Click(object sender, EventArgs e)
        {
            Utilitario.RegistrarWindows(string.Empty, ImpZebra.PortaImpressoraZebraNomeRegistroACS());
            Utilitario.RegistrarWindows(string.Empty, ImpZebra.ImpressoraZebraUSBNomeRegistroACS());
            rbRedeUSB_ACS.Checked = rbSerialACS.Checked = rbSerialACS2.Checked = rbParalelaACS.Checked = rbParalelaACS2.Checked = false;
            txtNomeImpACS.Text = string.Empty;
            ConfigurarControles(grbHAC.Controls, true);
        }

        private void txtNomeBixolon_Validating(object sender, CancelEventArgs e)
        {
            Utilitario.RegistrarWindows(txtNomeBixolon.Text, Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
            MessageBox.Show("Nome BIXOLON configurada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Eventos comentados sem uso (provisório)

        private void rbBematech_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbBematech.Checked)
            //{
            //    grbPorta.Enabled = false;
            //    rbParalela.Checked = true;
            //}
            //else
            //{
            //    grbPorta.Enabled = true;
            //    rbParalela.Checked = false;
            //    rbSerial.Checked = false;
            //}
        }

        private void rbZebra_CheckedChanged(object sender, EventArgs e)
        {
            //if (rbZebra.Checked)
            //{
            //    string porta = Utilitario.ObterPorta(ImpZebra.ObterPortaImpressoraRegistro());

            //    if (!string.IsNullOrEmpty(porta))
            //    {
            //        if (porta == Utilitario.PortaComunicacao.Paralela)
            //        {
            //            rbParalela.Checked = true;
            //        }
            //        else if (porta == Utilitario.PortaComunicacao.Serial)
            //        {
            //            rbSerial.Checked = true;
            //        }
            //    }
            //    else
            //    {
            //        rbParalela.Checked = false;
            //        rbSerial.Checked = false;
            //    }
            //}            
        }        

        #endregion        
    }
}