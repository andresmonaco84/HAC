using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Framework.ValueObject;
using HospitalAnaCosta.Framework.Collections.Generics;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.IO;
using HospitalAnaCosta.Framework.Compress;
namespace UnitTestFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTreeSubProp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BasicFunctions.RetornaMes(1));

            MessageBox.Show(BasicFunctions.RetornaMes(9));

            MessageBox.Show(BasicFunctions.RetornaMes(12));
        }

        private void btnInt32_Click(object sender, EventArgs e)
        {
            MessageBox.Show("555 - " + BasicFunctions.IsNumeric(555, typeof(Int32)));

            MessageBox.Show("abc - " + BasicFunctions.IsNumeric("abc", typeof(Int32)));

            MessageBox.Show("-55 - " + BasicFunctions.IsNumeric("-55", typeof(Int32)));

            MessageBox.Show("2147483647 - " + BasicFunctions.IsNumeric("2147483647", typeof(Int32)));

            MessageBox.Show("2147483648 - " + BasicFunctions.IsNumeric("2147483648", typeof(Int32)));

        }

        private void btnConverteStringData_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("TESTE 1 - 13/02/2007");

                DateTime data = BasicFunctions.ConverterStringData("13/02/2007", null);

                MessageBox.Show(data.ToString());

                MessageBox.Show("TESTE 2 - 13/02/2007 15:23:49");

                DateTime data2 = BasicFunctions.ConverterStringData("13/02/2007", "15:23:49");

                MessageBox.Show(data2.ToString());

                MessageBox.Show("TESTE 3 - 27/32/2007 15:23:49");

                DateTime data3 = BasicFunctions.ConverterStringData("27/32/2007", "15:23:49");

                MessageBox.Show(data3.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConverteDataString_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString());

            string strData = BasicFunctions.ConverterDataString(DateTime.Now);

            MessageBox.Show(strData);
        }

        private void btnConverteDataString2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString() + " - yyyyMMdd");

            string strData = BasicFunctions.ConverterDataString(DateTime.Now, "yyyyMMdd");

            MessageBox.Show(strData);
        }

        private void btnUltimoDiaMesInt_Click(object sender, EventArgs e)
        {
            int intUltimoDiaMes = BasicFunctions.UltimoDiaDoMes(2, 2006);

            MessageBox.Show(intUltimoDiaMes.ToString());
        }

        private void btnUltimoDiaMesDateTime_Click(object sender, EventArgs e)
        {
            DateTime datUltimoDiaMes = BasicFunctions.UltimaDataDoMes(2, 2006);

            MessageBox.Show(datUltimoDiaMes.ToString("dd/MM/yyyy"));
        }

        private void btnManipulacaoString_Click(object sender, EventArgs e)
        {
            string cep = "11025-150";
            string cepSemFormatacao = BasicFunctions.RemoverFormatacao(cep);
            cep = BasicFunctions.FormatarCEP(cepSemFormatacao);

            string nomeCompleto = "Carlos Eduardo";
            string nome = BasicFunctions.Left(nomeCompleto, 6);

            //string cnpj = "4447124000170";
            string cnpj = "17217977000168";
            string cnpjSemFormatacao = BasicFunctions.FormatarCNPJ(cnpj);

            string cpf = "16231359824";
            //string cpf = "6231359824";
            string cpfSemFormatacao = BasicFunctions.FormatarCPF(cpf);
        }

        private void btnValueObjectTestarEntidade_Click(object sender, EventArgs e)
        {            
            VOSerializer<EnderecoVO> oVOSerializer = new VOSerializer<EnderecoVO>();
            EnderecoVO enEnderecoVO = new EnderecoVO(1, "Rua 1");

            // Serialize the dto to xml.
            string strXml = oVOSerializer.SerializeVO(enEnderecoVO);

            // Write the serialized dto as xml.
            MessageBox.Show("Serialized VO");
            MessageBox.Show(strXml);

            // Deserialize the xml to the data transfer object.
            EnderecoVO enDesEnderecoVO = (EnderecoVO)oVOSerializer.DeserializeXml(strXml, new EnderecoVO());

            // Write the deserialized dto values.
            MessageBox.Show("Deseralized VO");
            MessageBox.Show("Endereco Id : " + enDesEnderecoVO.Idt);
            MessageBox.Show("Endereco Completo : " + enDesEnderecoVO.EnderecoCompleto);
            MessageBox.Show("Data Atualização : " + enDesEnderecoVO.DataAtualizacao.ToString("dd/MM/yyyy HH:mm.ss"));
        }

        private void btnValueObjectTestarLista_Click(object sender, EventArgs e)
        {
            VOSerializer<EnderecoVO> oVOSerializer = new VOSerializer<EnderecoVO>();
            List<EnderecoVO> lstvo = new List<EnderecoVO>();
            EnderecoVO vo = new EnderecoVO(1, "Rua 1");
            lstvo.Add(vo);

            vo = new EnderecoVO(2, "Rua 2");
            lstvo.Add(vo);

            // Serialize the dto to xml.
            string strXml = oVOSerializer.SerializeVO(lstvo);

            // Write the serialized dto as xml.
            MessageBox.Show("Serialized List<VO>");
            MessageBox.Show(strXml);

            // Deserialize the xml to the data transfer object.
            List<EnderecoVO> lstDvo = (List<EnderecoVO>)oVOSerializer.DeserializeXml(strXml, new List<EnderecoVO>());

            // Write the deserialized dto values.
            MessageBox.Show("Deseralized VO");

            foreach (EnderecoVO endDto in lstDvo)
            {
                MessageBox.Show("Endereco Id : " + endDto.Idt);
                MessageBox.Show("Endereco Completo : " + endDto.EnderecoCompleto);
                MessageBox.Show("Data Atualização : " + endDto.DataAtualizacao.ToString("dd/MM/yyyy HH:mm.ss"));
            }
        }

        private void btnCriptografia_Click(object sender, EventArgs e)
        {
            string senhaCriptografada = BasicFunctions.CriptografarMd5Hash("");
            bool bSenhaOK = BasicFunctions.VerificarMd5Hash("", senhaCriptografada);
        }

        private void btnOrdenarGenerics_Click(object sender, EventArgs e)
        {
            List<EnderecoVO> lstEndereco = new List<EnderecoVO>();
            
            EnderecoVO enEnderecoVO = null;
            enEnderecoVO = new EnderecoVO(1, "Rua Alfaia Rodrigues, 168");
            lstEndereco.Add(enEnderecoVO);

            enEnderecoVO = new EnderecoVO(2, "Rua Tocantins, 62");
            lstEndereco.Add(enEnderecoVO);

            enEnderecoVO = new EnderecoVO(3, "Rua Torres Homem, 100");
            lstEndereco.Add(enEnderecoVO);

            enEnderecoVO = new EnderecoVO(4, "Av. Ana Costa, 1500");
            lstEndereco.Add(enEnderecoVO);

            GenericsSorter<EnderecoVO> gs = new GenericsSorter<EnderecoVO>();
            lstEndereco = gs.OrdenaLista(lstEndereco, cboSortExpression.SelectedItem.ToString(), gs.ObterSortDirection(cboSortDirection.SelectedItem.ToString()));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboSortDirection.SelectedIndex = 0;
            cboSortExpression.SelectedIndex = 0;
        }

        private void btnObterProduto_Click(object sender, EventArgs e)
        {
            //Sempre que criar uma árvore atribuindo false no construtor,
            //estou querendo dizer que vou trazer todos os atributos da tabela
            //correspondente, mas não vou trazer nada das tabelas filhas

            //Para efeito de teste, não codifiquei a classe Business
            ProdutoData daoProduto = new ProdutoData();
            ProdutoVO enProdutoVO = null;
            //Recupera apenas o Produto
            //Cria a arvore produto (negando tudo)
            ProdutoVO.Tree treeProduto = new ProdutoVO.Tree(false);
            enProdutoVO = daoProduto.Obter(1, treeProduto);

            //Recupera apenas Produto e Fornecedor
            enProdutoVO = null;
            //Cria a arvore produto (negando tudo)
            treeProduto = new ProdutoVO.Tree(false);
            //Cria a arvore fornecedor (negando tudo)
            FornecedorVO.Tree treeFornecedor = new FornecedorVO.Tree(false);
            treeProduto.FornecedorTree = treeFornecedor;
            enProdutoVO = daoProduto.Obter(1, treeProduto);

            //Recupera tudo de maneira simplificada (Produto, Fornecedor e Endereco)
            enProdutoVO = null;
            treeProduto = new ProdutoVO.Tree(true);
            enProdutoVO = daoProduto.Obter(1, treeProduto);

            //Recupera tudo (Produto, Fornecedor e Endereco) manualmente
            enProdutoVO = null;
            //Cria a arvore produto (negando tudo)
            treeProduto = new ProdutoVO.Tree(false);
            //Cria a arvore de fornecedor (negando tudo)
            treeFornecedor = new FornecedorVO.Tree(false);
            //Configuro a arvore de fornecedor para recuperar endereço
            treeFornecedor.RecuperarEndereco = true;
            //Atribuo a árvore de fornecedor na árvore de produto
            treeProduto.FornecedorTree = treeFornecedor;            
            enProdutoVO = daoProduto.Obter(1, treeProduto);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblCompress.Text = "Compactado";            
            LosFormatter formatter = new LosFormatter();
            StringWriter writer = new StringWriter();
            formatter.Serialize(writer, txtTexto.Text);            
            byte[] bytes = Convert.FromBase64String(writer.ToString());
            // COMPACTAR VIEWSTATE
            bytes = HacCompress.Compactar(bytes);

            txtResultado.Text = Convert.ToBase64String(bytes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCompress.Text = "Descompactado";
            byte[] bytes = Convert.FromBase64String(txtTexto.Text);
            // DESCOMPACTAR VIEWSTATE   
            bytes = HacCompress.Descompactar(bytes);
            LosFormatter formatter = new LosFormatter();
            txtResultado.Text = formatter.Deserialize(Convert.ToBase64String(bytes)).ToString();
        }
        
    }
}