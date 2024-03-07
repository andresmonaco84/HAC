using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmGraficoRotatividade : FrmBase
    {
        // MatMed        
        //private IMaterialMedicamento _matMed;
        //private IMaterialMedicamento MatMed
        //{
        //    get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        //}

        private IMovimentacaoMensal _movitacaomensal;
        private IMovimentacaoMensal MovimentacaoMensal
        {
            get { return _movitacaomensal != null ? _movitacaomensal : _movitacaomensal = (IMovimentacaoMensal)Global.Common.GetObject(typeof(IMovimentacaoMensal)); }
        }

        ZedGraphControl zgcRot = new ZedGraphControl();

        public FrmGraficoRotatividade()
        {
            InitializeComponent();
        }

        private void SetSize()
        {
            zgcRot.Location = new Point(10, 10);
            zgcRot.Size = new Size(pnlGrafico.Width - 10,
                                   pnlGrafico.Height - 10);
        }

        /// <summary>
        /// Obtêm o número de meses de acordo com a qtd de dias
        /// sempre arredondando o retorno para cima
        /// </summary>
        /// <param name="dias"></param>
        /// <returns></returns>
        private int ObterNumMeses(int dias)
        {
            if (dias <= 31) return 1;

            int resto = (dias % 30);

            if (resto > 27)
            {
                return (dias / 30) + ObterNumMeses(resto);
            }
            else
            {
                return dias / 30;
            }            
        }

        /// <summary>
        /// GerarGrafico
        /// Obs.: Enviar período de parâmetro com meses cheios
        /// </summary>
        /// <param name="dtoMatMed"></param>
        /// <param name="dataInicio"></param>
        /// <param name="dataTermino"></param>
        public void GerarGrafico(MaterialMedicamentoDTO dtoMatMed,
                                 DateTime dataInicio,
                                 DateTime dataTermino)
        {
            GraphPane grPane = zgcRot.GraphPane;            
            
            // Atribui os títulos
            grPane.Title.Text = string.Format("Índice de Rotatividade - {0} ({1} à {2})", dtoMatMed.NomeFantasia, dataInicio.ToString("MM/yyyy"), dataTermino.ToString("MM/yyyy"));
            grPane.XAxis.Title.Text = "Data";
            grPane.YAxis.Title.Text = "Índice";

            dataInicio = dataInicio.AddMonths(-1);
            
            double x, y = 0;
            PointPairList pplRot = new PointPairList();
            int numMeses = ObterNumMeses(dataTermino.Subtract(dataInicio.AddDays(-1)).Days);
            DateTime dataX = dataInicio.AddMonths(1);
            MovimentacaoMensalDTO dtoMensal = new MovimentacaoMensalDTO();
            dtoMensal.IdtProduto.Value = dtoMatMed.Idt.Value;
            dtoMensal.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
            for (int index = 1; index <= numMeses; index++)
            {
                x = new XDate(dataX);
                //y = (double)MatMed.ObterRotatividade(dtoMatMed, dataX.AddMonths(-1), dataX.AddDays(-1));
                dtoMensal.Mes.Value = dataX.AddMonths(-1).Month;
                dtoMensal.Ano.Value = dataX.AddMonths(-1).Year;
                dtoMensal = MovimentacaoMensal.ObtemIndiceRotatividade(dtoMensal);
                y = (double)decimal.Parse(dtoMensal.IndiceRotatividade.Value.ToString());

                pplRot.Add(x, y);

                dataX = dataX.AddMonths(1);
            }

            grPane.AddCurve("Índice de Rotatividade", pplRot, Color.Blue, SymbolType.UserDefined);
            grPane.XAxis.Type = AxisType.Date;
            grPane.XAxis.MajorGrid.IsVisible = true;
            grPane.YAxis.MajorGrid.IsVisible = true;

            zgcRot.AxisChange();

            //Adiciona o gráfico gerado no panel
            pnlGrafico.Controls.Add(zgcRot);

            this.ShowDialog();
        }

        private void FrmGraficoRotatividade_Load(object sender, EventArgs e)
        {
            SetSize();
        }
    }
}